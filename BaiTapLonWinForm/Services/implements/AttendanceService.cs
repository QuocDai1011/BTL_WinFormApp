using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IClassSessionRepository _sessionRepo;
        private readonly ICompreFaceApiService _faceApi;
        private readonly IClassRepository _classRepo;
        public AttendanceService(
            IAttendanceRepository attendanceRepo,
            IStudentRepository studentRepo,
            IClassSessionRepository sessionRepo,
            IClassRepository classRepo,
            ICompreFaceApiService faceApi)
        {
            _attendanceRepo = attendanceRepo;
            _studentRepo = studentRepo;
            _sessionRepo = sessionRepo;
            _faceApi = faceApi;
            _classRepo = classRepo;
        }

        public async Task<(bool success, string studentName, DateTime? checkInTime, string message)> TakeAttendanceByFaceAsync(
            int sessionId, byte[] capturedImage)
        {
            try
            {
                var (recognizeSuccess, studentId, confidence, recognizeMessage) =
                    await _faceApi.RecognizeFaceAsync(capturedImage);

                if (!recognizeSuccess || !studentId.HasValue)
                {
                    return (false, null, null, recognizeMessage);
                }

                var session = await _sessionRepo.GetByIdAsync(sessionId);
                if (session == null)
                {
                    return (false, null, null, "Buổi học không tồn tại!");
                }

                var isInClass = await _studentRepo.IsStudentInClassAsync(studentId.Value, session.ClassId);
                if (!isInClass)
                {
                    return (false, null, null, "Sinh viên không thuộc lớp này!");
                }

                var existing = await _attendanceRepo.GetByStudentAndSessionAsync(studentId.Value, sessionId);
                if (existing != null)
                {
                    var student = await _studentRepo.GetByIdAsync(studentId.Value);
                    string studentName = $"{student.User.LastName} {student.User.FirstName}";
                    return (false, studentName, existing.CheckInTime, "Sinh viên đã điểm danh rồi!");
                }

                var attendance = new Attendance
                {
                    StudentId = studentId.Value,
                    SessionId = sessionId,
                    IsPresent = true,
                    CheckInTime = DateTime.Now,
                    Note = $"Face Recognition - Confidence: {confidence:P1}"
                };

                await _attendanceRepo.AddAsync(attendance);

                var studentInfo = await _studentRepo.GetByIdAsync(studentId.Value);
                string name = $"{studentInfo.User.LastName} {studentInfo.User.FirstName}";

                return (true, name, attendance.CheckInTime, "Điểm danh thành công!");
            }
            catch (Exception ex)
            {
                return (false, null, null, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool success, string message)> TakeManualAttendanceAsync(
            int studentId, int sessionId, bool isPresent, string note = null)
        {
            try
            {
                var existing = await _attendanceRepo.GetByStudentAndSessionAsync(studentId, sessionId);

                if (existing != null)
                {
                    existing.IsPresent = isPresent;
                    existing.Note = note ?? "Manual Attendance";
                    await _attendanceRepo.UpdateAsync(existing);
                    return (true, "Cập nhật điểm danh thành công!");
                }
                else
                {
                    var attendance = new Attendance
                    {
                        StudentId = studentId,
                        SessionId = sessionId,
                        IsPresent = isPresent,
                        CheckInTime = DateTime.Now,
                        Note = note ?? "Manual Attendance"
                    };

                    await _attendanceRepo.AddAsync(attendance);
                    return (true, "Điểm danh thành công!");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<List<AttendanceRecord>> GetSessionAttendanceAsync(int sessionId)
        {
            try
            {
                var session = await _sessionRepo.GetByIdAsync(sessionId);
                if (session == null) return new List<AttendanceRecord>();

                var students = await _studentRepo.GetStudentsByClassIdAsync(session.ClassId);
                var attendances = await _attendanceRepo.GetBySessionIdAsync(sessionId);

                var records = students.Select(s => new AttendanceRecord
                {
                    StudentId = s.StudentId,
                    StudentName = $"{s.User.LastName} {s.User.FirstName}",
                    Email = s.User.Email,
                    IsPresent = attendances.Any(a => a.StudentId == s.StudentId && a.IsPresent),
                    CheckInTime = attendances.FirstOrDefault(a => a.StudentId == s.StudentId)?.CheckInTime,
                    Note = attendances.FirstOrDefault(a => a.StudentId == s.StudentId)?.Note
                }).ToList();

                return records;
            }
            catch
            {
                return new List<AttendanceRecord>();
            }
        }

        public async Task<(int present, int absent, double rate)> GetAttendanceStatsAsync(int sessionId)
        {
            try
            {
                var records = await GetSessionAttendanceAsync(sessionId);
                int total = records.Count;
                int present = records.Count(r => r.IsPresent);
                int absent = total - present;
                double rate = total > 0 ? (double)present / total * 100 : 0;

                return (present, absent, rate);
            }
            catch
            {
                return (0, 0, 0);
            }
        }

        Task<List<Attendance>> IAttendanceService.GetSessionAttendanceAsync(int sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReceptionCheckInResult> CheckInAtReceptionAsync(byte[] capturedImage)
        {
            var result = new ReceptionCheckInResult();

            try
            {
                // BƯỚC 1: Nhận diện khuôn mặt
                var (isRecognized, studentId, confidence, msg) = await _faceApi.RecognizeFaceAsync(capturedImage);

                if (!isRecognized || !studentId.HasValue)
                {
                    result.Success = false;
                    result.Message = "Không nhận diện được khuôn mặt hoặc chưa đăng ký.";
                    return result;
                }

                // BƯỚC 2: Lấy thông tin sinh viên và các lớp đang học
                // Hàm GetByIdAsync trong StudentRepo đã Include(s => s.StudentClasses).ThenInclude(sc => sc.Class)
                var student = await _studentRepo.GetByIdAsync(studentId.Value);

                if (student == null)
                {
                    result.Success = false;
                    result.Message = "Dữ liệu sinh viên không tồn tại trong hệ thống.";
                    return result;
                }

                // Fill thông tin cơ bản để hiển thị dù có check-in được hay không
                result.StudentId = student.StudentId;
                result.StudentName = $"{student.User.LastName} {student.User.FirstName}";
                result.StudentCode = student.StudentId.ToString(); // Hoặc mã sinh viên nếu có
                result.Avatar = capturedImage; // Trả lại ảnh vừa chụp để hiển thị

                // BƯỚC 3: Tìm lớp học đang diễn ra (Logic khớp Lịch + Giờ)
                var activeClass = FindActiveBooking(student, DateTime.Now);

                if (activeClass == null)
                {
                    result.Success = false;
                    result.Message = $"Xin chào {result.StudentName}. Bạn không có lịch học vào khung giờ này.";
                    return result;
                }

                result.ClassName = activeClass.ClassName;
                result.ShiftName = GetShiftName(activeClass.Shift);

                // BƯỚC 4: Tìm Session (Buổi học) của ngày hôm nay
                // Logic này giả định Session đã được sinh ra trước đó
                var sessions = await _sessionRepo.GetByClassIdAsync(activeClass.ClassId);

                // Tìm session khớp ngày hôm nay (So sánh DateOnly hoặc DateTime)
                var today = DateOnly.FromDateTime(DateTime.Now);

                // Giả sử ClassSession có thuộc tính Date (kiểu DateOnly hoặc DateTime)
                // Nếu Model ClassSession chưa có Date, bạn cần logic tính toán dựa trên StartDate + SchoolDays
                var todaySession = sessions.FirstOrDefault(s => s.SessionDate == today);

                if (todaySession == null)
                {
                    result.Success = false;
                    result.Message = "Lớp học có lịch hôm nay nhưng chưa tạo Buổi học (Session) trên hệ thống.";
                    return result;
                }

                // BƯỚC 5: Thực hiện điểm danh
                var existingAttendance = await _attendanceRepo.GetByStudentAndSessionAsync(studentId.Value, todaySession.SessionId);

                if (existingAttendance != null)
                {
                    // Đã điểm danh rồi
                    result.Success = true;
                    result.CheckInTime = existingAttendance.CheckInTime;
                    result.Message = $"Bạn đã điểm danh lúc {existingAttendance.CheckInTime?.ToString("HH:mm")}.";
                }
                else
                {
                    // Chưa điểm danh -> Tạo mới
                    var newAttendance = new Attendance
                    {
                        StudentId = studentId.Value,
                        SessionId = todaySession.SessionId,
                        IsPresent = true,
                        CheckInTime = DateTime.Now,
                        Note = $"Auto Check-in (Confidence: {confidence:P0})"
                    };

                    await _attendanceRepo.AddAsync(newAttendance);

                    result.Success = true;
                    result.CheckInTime = newAttendance.CheckInTime;
                    result.Message = "Điểm danh thành công! Chúc bạn buổi học vui vẻ.";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Lỗi hệ thống: {ex.Message}";
                return result;
            }
        }


        private Class? FindActiveBooking(Student student, DateTime currentTime)
        {
            // 1. Lấy thứ trong tuần (Monday, Tuesday...)
            var currentDayOfWeek = currentTime.DayOfWeek;

            // 2. Duyệt qua các lớp sinh viên đang tham gia
            foreach (var sc in student.StudentClasses)
            {
                var classInfo = sc.Class;

                // Check 1: Lớp có đang Active không?
                if (classInfo.Status != 1) continue; // 1 = Active/In Progress

                // Check 2: Hôm nay có phải ngày học không?
                // Lưu ý: ClassRepository cần Include SchoolDays
                if (classInfo.SchoolDays == null || !classInfo.SchoolDays.Any(d => d.DayOfWeek.ToString() == currentDayOfWeek.ToString()))
                {
                    continue;
                }

                // Check 3: Có đúng ca (Shift) không?
                // Bạn cần định nghĩa giờ bắt đầu/kết thúc cho từng Ca
                if (IsTimeInShift(currentTime, classInfo.Shift))
                {
                    return classInfo;
                }
            }
            return null;
        }

        private bool IsTimeInShift(DateTime time, byte shift)
        {
            // Lấy TimeSpan từ giờ hiện tại
            TimeSpan now = time.TimeOfDay;

            TimeSpan start, end;

            switch (shift)
            {
                case 1: // Ca 1: 8:00 - 9:30
                    start = new TimeSpan(8, 0, 0);
                    end = new TimeSpan(9, 30, 0);
                    break;

                case 2: // Ca 2: 9:30 - 11:00
                    start = new TimeSpan(9, 30, 0);
                    end = new TimeSpan(11, 0, 0);
                    break;

                case 3: // Ca 3: 14:00 - 15:30
                    start = new TimeSpan(14, 0, 0);
                    end = new TimeSpan(15, 30, 0);
                    break;

                case 4: // Ca 4: 15:30 - 17:00
                    start = new TimeSpan(15, 30, 0);
                    end = new TimeSpan(17, 0, 0);
                    break;

                case 5: // Ca 5: 18:00 - 19:30
                    start = new TimeSpan(18, 0, 0);
                    end = new TimeSpan(19, 30, 0);
                    break;

                case 6: // Ca 6: 19:30 - 21:00
                    start = new TimeSpan(19, 30, 0);
                    end = new TimeSpan(21, 0, 0);
                    break;

                default:
                    return false;
            }

            return now >= start && now <= end;
        }


        private string GetShiftName(byte shift)
        {
            return shift switch
            {
                1 => "Sáng",
                2 => "Chiều",
                3 => "Tối",
                _ => "Khác"
            };
        }

    }
    /// <summary>
    /// DTO cho kết quả điểm danh
    /// </summary>
    public class AttendanceRecord
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public bool IsPresent { get; set; }
        public DateTime? CheckInTime { get; set; }
        public string Note { get; set; }
    }

    public class ReceptionCheckInResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentCode { get; set; }
        public string ClassName { get; set; }
        public string ShiftName { get; set; }
        public DateTime? CheckInTime { get; set; }
        public byte[] Avatar { get; set; } // Ảnh chụp từ camera
    }
}
