using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class TeacherAttendanceService : ITeacherAttendanceService
    {
        private readonly ITeacherAttendanceRepository _attRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IClassSessionRepository _sessionRepo;
        private readonly ICompreFaceApiService _faceApi;
        private readonly IClassRepository _classRepo;

        // Cấu hình thời gian (giống bên Student)
        private const int LATE_THRESHOLD_MINUTES = 15;
        private const int WINDOW_OPEN_MINUTES_BEFORE = 30;

        public TeacherAttendanceService(
            ITeacherAttendanceRepository teacherAttendanceRepository,
            ITeacherRepository teacherRepository,
            IClassSessionRepository classSessionRepository,
            ICompreFaceApiService compreFaceApiService,
            IClassRepository classRepository)
        {
            _attRepo = teacherAttendanceRepository;
            _teacherRepo = teacherRepository;
            _sessionRepo = classSessionRepository;
            _faceApi = compreFaceApiService;
            _classRepo = classRepository;
        }

        public async Task<TeacherCheckInResult> CheckInAsync(byte[] capturedImage)
        {
            var result = new TeacherCheckInResult();
            try
            {
                // Nhận diện khuôn mặt qua API
                var recognition = await _faceApi.RecognizeFaceAsync(capturedImage);

                if (!recognition.success || string.IsNullOrEmpty(recognition.subject))
                {
                    result.Success = false;
                    result.Message = "Không nhận diện được khuôn mặt.";
                    return result;
                }

                // Kiểm tra tiền tố TEA_ (Bắt buộc cho giảng viên)
                if (!recognition.subject.StartsWith("TEA_"))
                {
                    result.Success = false;
                    result.Message = "Khuôn mặt này không phải là Giảng viên (Có thể là Học viên).";
                    return result;
                }

                // Tách lấy ID (Ví dụ: TEA_10 => 10)
                if (!int.TryParse(recognition.subject.Replace("TEA_", ""), out int teacherId))
                {
                    result.Success = false;
                    result.Message = "Lỗi định dạng ID giảng viên.";
                    return result;
                }

                var teacher = await _teacherRepo.GetByIdAsync(teacherId);
                if (teacher == null)
                {
                    result.Success = false;
                    result.Message = "Không tìm thấy thông tin giảng viên trong DB.";
                    return result;
                }

                result.teacherId = teacher.TeacherId;
                result.teacherName = $"{teacher.User?.FirstName} {teacher.User?.LastName}";

                // 4. Tìm ca dạy hiện tại (Dựa vào giờ hệ thống)
                var activeClass = await FindActiveTeachingClass(teacherId, DateTime.Now);

                if (activeClass == null)
                {
                    result.Success = false;
                    result.Message = $"Xin chào {result.teacherName}. Không tìm thấy lịch dạy phù hợp lúc này.";
                    return result;
                }

                result.ClassName = activeClass.ClassName;
                result.ShiftName = GetShiftName(activeClass.Shift);

                // Tìm buổi học (Session) hôm nay trong DB
                var sessions = await _sessionRepo.GetByClassIdAsync(activeClass.ClassId);
                var todayDate = DateOnly.FromDateTime(DateTime.Now);
                var todaySession = sessions.FirstOrDefault(s => s.SessionDate == todayDate);

                if (todaySession == null)
                {
                    result.Success = false;
                    result.Message = $"Lớp {activeClass.ClassName} chưa được tạo lịch (Session) cho ngày hôm nay.";
                    return result;
                }

                // Kiểm tra đi muộn (LATE)
                var (shiftStart, _) = GetShiftTimes(activeClass.Shift);
                var lateTimeLimit = shiftStart.Add(TimeSpan.FromMinutes(LATE_THRESHOLD_MINUTES));
                bool isLate = DateTime.Now.TimeOfDay > lateTimeLimit;
                
                result.isLate = isLate;
                string statusText = isLate ? "Late" : "OnTime";
                string noteText = isLate ? "Đi muộn" : "";

                // Lưu Check-in hoặc cập nhật nếu đã có
                var existing = await _attRepo.GetByTeacherAndSessionAsync(teacherId, todaySession.SessionId);

                if (existing != null)
                {
                    result.Success = true;
                    result.CheckInTime = existing.CheckInTime;
                    result.Message = $"Đã điểm danh trước đó lúc {existing.CheckInTime:HH:mm}.";
                }
                else
                {
                    var newAtt = new TeacherAttendance
                    {
                        TeacherId = teacherId,
                        SessionId = todaySession.SessionId,
                        CheckInTime = DateTime.Now,
                        Status = statusText,
                        Note = $"Face Check-in ({recognition.confidence:P0}) {noteText}".Trim()
                    };

                    await _attRepo.AddAsync(newAtt);
                    
                    result.Success = true;
                    result.CheckInTime = newAtt.CheckInTime;
                    result.Message = isLate ? "Điểm danh thành công (Đi muộn)." : "Điểm danh thành công!";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Lỗi hệ thống: " + ex.Message;
                return result;
            }
        }

        public async Task<Class?> FindActiveTeachingClass(int teacherId, DateTime time)
        {
            var classes = await _classRepo.GetByTeacherIdAsync(teacherId);

            string currentDayVi = ConvertToVietnameseDay(time.DayOfWeek);

            foreach (var cls in classes)
            {
                // Chỉ xét lớp đang diễn ra
                if (cls.Status != 0) continue;

                if (cls.SchoolDays == null || !cls.SchoolDays.Any()) continue;

                bool isDayMatch = cls.SchoolDays.Any(d =>
                    (d.DayOfWeek ?? "").Trim().Equals(currentDayVi, StringComparison.OrdinalIgnoreCase) ||
                    (time.DayOfWeek == DayOfWeek.Sunday &&
                     ((d.DayOfWeek ?? "").Trim().Equals("Chủ Nhật", StringComparison.OrdinalIgnoreCase) ||
                      (d.DayOfWeek ?? "").Trim().Equals("Chu Nhat", StringComparison.OrdinalIgnoreCase)))
                );

                if (!isDayMatch) continue;

                if (IsTimeInBookingWindow(time, cls.Shift))
                {
                    return cls;
                }
            }
            return null;
        }


        private bool IsTimeInBookingWindow(DateTime time, byte shift)
        {
            TimeSpan now = time.TimeOfDay;
            var (start, end) = GetShiftTimes(shift);

            var windowOpen = start.Subtract(TimeSpan.FromMinutes(WINDOW_OPEN_MINUTES_BEFORE));
            
            var windowClose = end;

            return now >= windowOpen && now <= windowClose;
        }

        private (TimeSpan start, TimeSpan end) GetShiftTimes(byte shift)
        {
            return shift switch
            {
                1 => (new TimeSpan(7, 0, 0), new TimeSpan(9, 0, 0)),
                2 => (new TimeSpan(9, 0, 0), new TimeSpan(11, 0, 0)),
                3 => (new TimeSpan(13, 0, 0), new TimeSpan(15, 0, 0)),
                4 => (new TimeSpan(15, 0, 0), new TimeSpan(17, 0, 0)),
                5 => (new TimeSpan(17, 30, 0), new TimeSpan(19, 30, 0)),
                6 => (new TimeSpan(19, 30, 0), new TimeSpan(21, 30, 0)),
                _ => (TimeSpan.Zero, TimeSpan.Zero)
            };
        }

        private string GetShiftName(byte shift)
        {
            var (s, e) = GetShiftTimes(shift);
            return $"Ca {shift} ({s:hh\\:mm} - {e:hh\\:mm})";
        }

        private string ConvertToVietnameseDay(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => "Thứ 2",
                DayOfWeek.Tuesday => "Thứ 3",
                DayOfWeek.Wednesday => "Thứ 4",
                DayOfWeek.Thursday => "Thứ 5",
                DayOfWeek.Friday => "Thứ 6",
                DayOfWeek.Saturday => "Thứ 7",
                DayOfWeek.Sunday => "Chủ nhật",
                _ => ""
            };
        }
    }
}