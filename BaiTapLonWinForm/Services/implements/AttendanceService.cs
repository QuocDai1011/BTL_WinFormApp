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
}
