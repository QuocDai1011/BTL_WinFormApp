using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IClassSessionRepository _sessionRepo;
        private readonly ICompreFaceApiService _faceApi;


        // Cho phép check-in sớm 30 phút trước giờ học
        private const int WINDOW_OPEN_MINUTES_BEFORE = 30;

        // Nếu check-in sau 15 phút kể từ giờ bắt đầu -> Đánh dấu là LATE
        private const int LATE_THRESHOLD_MINUTES = 15;

        public AttendanceService(
            IAttendanceRepository attendanceRepo,
            IStudentRepository studentRepo,
            IClassSessionRepository sessionRepo,
            ICompreFaceApiService faceApi)
        {
            _attendanceRepo = attendanceRepo;
            _studentRepo = studentRepo;
            _sessionRepo = sessionRepo;
            _faceApi = faceApi;
        }

        public async Task<ReceptionCheckInResult> CheckInAtReceptionAsync(byte[] capturedImage)
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine($"[DEBUG SYSTEM] BẮT ĐẦU CHECK-IN: {DateTime.Now:HH:mm:ss dd/MM/yyyy}");

            var result = new ReceptionCheckInResult();

            try
            {
                Console.WriteLine("[DEBUG STEP 1] Đang gửi ảnh lên AI Server...");
                var (isRecognized, subject, confidence, msg) = await _faceApi.RecognizeFaceAsync(capturedImage);

                if (!isRecognized || string.IsNullOrEmpty(subject))
                {
                    result.Success = false;
                    result.Message = "Không nhận diện được khuôn mặt.";
                    return result;
                }
                Console.WriteLine($"[DEBUG SUCCESS] ID: {subject} (Confidence: {confidence:P0})");
                
                result.confidence = confidence;

                if (!int.TryParse(subject, out int studentId))
                {
                    result.Success = false;
                    // Nếu là Teacher check-in nhầm máy Student thì báo lỗi nhẹ nhàng
                    if (subject.StartsWith("TEA_"))
                        result.Message = "Máy này chỉ dành cho Học viên (Phát hiện Giáo viên).";
                    else
                        result.Message = $"Mã nhận diện không hợp lệ: {subject}";

                    return result;
                }

                var student = await _studentRepo.GetByIdAsync(int.Parse(subject));
                if (student == null || student.StudentClasses == null)
                {
                    result.Success = false;
                    result.Message = "Lỗi dữ liệu sinh viên (Không tìm thấy hoặc thiếu Class Include).";
                    return result;
                }

                result.StudentId = student.StudentId;
                result.StudentName = $"{student.User?.LastName} {student.User?.FirstName}";
                result.StudentCode = student.StudentId.ToString();
                result.Avatar = capturedImage;

                // (Chỉ tìm lớp đang diễn ra, hết giờ là thôi)
                Console.WriteLine($"[DEBUG STEP 3] Tìm lớp cho: {result.StudentName}...");
                var activeClass = FindActiveBooking(student, DateTime.Now);

                if (activeClass == null)
                {
                    result.Success = false;
                    result.Message = $"Xin chào {result.StudentName}. Không tìm thấy lịch học phù hợp lúc này.";
                    Console.WriteLine("[DEBUG FAIL] Không tìm thấy lớp (Do chưa đến giờ hoặc đã hết giờ học).");
                    return result;
                }

                Console.WriteLine($"[DEBUG SUCCESS] Lớp: {activeClass.ClassName} - Ca {activeClass.Shift}");
                result.ClassName = activeClass.ClassName;
                result.ShiftName = GetShiftName(activeClass.Shift);

                // BƯỚC 4: LẤY SESSION
                var sessions = await _sessionRepo.GetByClassIdAsync(activeClass.ClassId);
                var todayDateOnly = DateOnly.FromDateTime(DateTime.Now);
                var todaySession = sessions.FirstOrDefault(s => s.SessionDate == todayDateOnly);

                if (todaySession == null)
                {
                    result.Success = false;
                    result.Message = "Chưa có lịch học (Session) trên hệ thống hôm nay.";
                    return result;
                }

                //  xử lý đi muộn (LATE)
                var (shiftStart, _) = GetShiftTimes(activeClass.Shift);
                var lateTimeLimit = shiftStart.Add(TimeSpan.FromMinutes(LATE_THRESHOLD_MINUTES));
                var currentTime = DateTime.Now.TimeOfDay;

                bool isLate = currentTime > lateTimeLimit;
                string lateNote = isLate ? " - LATE (Đi muộn)" : "";
                string displayMessage = isLate ? "Điểm danh thành công (Đi muộn)." : "Điểm danh thành công!";

                if (isLate)
                {
                    result.isLate = true;
                    Console.WriteLine($"[DEBUG STATUS] ⚠️ Sinh viên đi muộn! Giờ: {currentTime:hh\\:mm} > Ngưỡng: {lateTimeLimit:hh\\:mm}");
                }

                //

                var existing = await _attendanceRepo.GetByStudentAndSessionAsync(int.Parse(subject), todaySession.SessionId);

                if (existing != null)
                {
                    result.Success = true;
                    result.CheckInTime = existing.CheckInTime;
                    result.Message = $"Bạn đã điểm danh lúc {existing.CheckInTime:HH:mm}.";
                }
                else
                {
                    var newAtt = new Attendance
                    {
                        StudentId = int.Parse(subject),
                        SessionId = todaySession.SessionId,
                        IsPresent = true,
                        CheckInTime = DateTime.Now,
                        Note = $"Face Check-in ({confidence:P0}){lateNote}"
                    };

                    await _attendanceRepo.AddAsync(newAtt);
                    result.Success = true;
                    result.CheckInTime = newAtt.CheckInTime;
                    result.Message = displayMessage;
                    Console.WriteLine($"[DEBUG END] Đã lưu điểm danh. Note: {newAtt.Note}");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG EXCEPTION] {ex}");
                result.Success = false;
                result.Message = "Lỗi Server: " + ex.Message;
                return result;
            }
        }



        private Class? FindActiveBooking(Student student, DateTime currentTime)
        {
            string currentDayVi = ConvertToVietnameseDay(currentTime.DayOfWeek);

            foreach (var sc in student.StudentClasses)
            {
                var cls = sc.Class;
                if (cls == null || cls.Status != 1) continue;
                if (cls.SchoolDays == null || !cls.SchoolDays.Any()) continue;

                // 1. Kiểm tra ngày
                bool isDayMatch = cls.SchoolDays.Any(d =>
                    d.DayOfWeek.Trim().Equals(currentDayVi, StringComparison.OrdinalIgnoreCase) ||
                    (currentTime.DayOfWeek == DayOfWeek.Sunday &&
                     (d.DayOfWeek.Trim().Equals("Chủ Nhật", StringComparison.OrdinalIgnoreCase) ||
                      d.DayOfWeek.Trim().Equals("Chu Nhat", StringComparison.OrdinalIgnoreCase)))
                );

                if (!isDayMatch) continue;

                // 2. Kiểm tra giờ (Logic Mới: Chỉ từ Start-30p đến End)
                if (IsTimeInBookingWindow(currentTime, cls.Shift))
                {
                    return cls;
                }
            }
            return null;
        }

        /// <summary>
        /// Kiểm tra xem giờ hiện tại có nằm trong khoảng thời gian Check-in không.
        /// Từ [Start - 30p] đến [End]. Không mở rộng sau khi kết thúc.
        /// </summary>
        private bool IsTimeInBookingWindow(DateTime time, byte shift)
        {
            TimeSpan now = time.TimeOfDay;

            var (start, end) = GetShiftTimes(shift);

            // Cửa sổ mở: Trước giờ học 30 phút
            var windowOpen = start.Subtract(TimeSpan.FromMinutes(WINDOW_OPEN_MINUTES_BEFORE));

            // Cửa sổ đóng: Đúng giờ kết thúc lớp học (Không cho phép checkout sau giờ)
            var windowClose = end;

            // Debug logic
            Console.WriteLine($"   [Window Check] Ca {shift}: {windowOpen:hh\\:mm} -> {windowClose:hh\\:mm} | Now: {now:hh\\:mm}");

            return now >= windowOpen && now <= windowClose;
        }

        private (TimeSpan start, TimeSpan end) GetShiftTimes(byte shift)
        {
            return shift switch
            {
                1 => (new TimeSpan(8, 0, 0), new TimeSpan(9, 30, 0)),
                2 => (new TimeSpan(9, 30, 0), new TimeSpan(11, 0, 0)),
                3 => (new TimeSpan(14, 0, 0), new TimeSpan(15, 30, 0)),
                4 => (new TimeSpan(15, 30, 0), new TimeSpan(17, 0, 0)),
                5 => (new TimeSpan(18, 0, 0), new TimeSpan(19, 30, 0)),
                6 => (new TimeSpan(19, 30, 0), new TimeSpan(21, 0, 0)),
                _ => (TimeSpan.Zero, TimeSpan.Zero)
            };
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

        private string GetShiftName(byte shift)
        {
            var (s, e) = GetShiftTimes(shift);
            return $"Ca {shift} ({s:hh\\:mm} - {e:hh\\:mm})";
        }

        public async Task<(bool success, string message)> TakeManualAttendanceAsync(int studentId, int sessionId, bool isPresent, string note = null)
        {
            try
            {
                var existing = await _attendanceRepo.GetByStudentAndSessionAsync(studentId, sessionId);
                if (existing != null)
                {
                    existing.IsPresent = isPresent; existing.Note = note ?? "Manual Update";
                    await _attendanceRepo.UpdateAsync(existing);
                }
                else
                {
                    await _attendanceRepo.AddAsync(new Attendance
                    {
                        StudentId = studentId,
                        SessionId = sessionId,
                        IsPresent = isPresent,
                        CheckInTime = DateTime.Now,
                        Note = note ?? "Manual"
                    });
                }
                return (true, "Thành công");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public async Task<List<AttendanceRecord>> GetSessionAttendanceAsync(int sessionId)
        {
            try
            {
                var session = await _sessionRepo.GetByIdAsync(sessionId);
                if (session == null) return new List<AttendanceRecord>();
                var students = await _studentRepo.GetStudentsByClassIdAsync(session.ClassId);
                var attendances = await _attendanceRepo.GetBySessionIdAsync(sessionId);
                return students.Select(s => new AttendanceRecord
                {
                    StudentId = s.StudentId,
                    StudentName = $"{s.User.LastName} {s.User.FirstName}",
                    Email = s.User.Email,
                    IsPresent = attendances.Any(a => a.StudentId == s.StudentId && a.IsPresent),
                    CheckInTime = attendances.FirstOrDefault(a => a.StudentId == s.StudentId)?.CheckInTime,
                    Note = attendances.FirstOrDefault(a => a.StudentId == s.StudentId)?.Note
                }).ToList();
            }
            catch { return new List<AttendanceRecord>(); }
        }

        public async Task<(int present, int absent, double rate)> GetAttendanceStatsAsync(int sessionId)
        {
            var list = await GetSessionAttendanceAsync(sessionId);
            int p = list.Count(x => x.IsPresent);
            return (p, list.Count - p, list.Count > 0 ? (double)p / list.Count * 100 : 0);
        }

        public Task<(bool success, string studentName, DateTime? checkInTime, string message)> TakeAttendanceByFaceAsync(int sessionId, byte[] capturedImage) => throw new NotImplementedException();
        Task<List<Attendance>> IAttendanceService.GetSessionAttendanceAsync(int sessionId) => throw new NotImplementedException();
    }


// --- DTO CLASSES ---
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
        public byte[] Avatar { get; set; }
        public bool isLate { get; set; }
        public double confidence { get; set; }
        }
}