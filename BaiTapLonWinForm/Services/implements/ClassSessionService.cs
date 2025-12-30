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
    public class ClassSessionService : IClassSessionService
    {
        private readonly IClassSessionRepository _sessionRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IClassRepository _classRepo;

        public ClassSessionService(
            IClassSessionRepository sessionRepo,
            ITeacherRepository teacherRepo,
            IClassRepository classRepo)
        {
            _sessionRepo = sessionRepo;
            _teacherRepo = teacherRepo;
            _classRepo = classRepo;
        }

        public async Task<(bool success, int sessionCount, string message)> CreateSessionsAsync(int classId)
        {
            try
            {
                var classInfo = await _classRepo.GetByIdAsync(classId);

                if (classInfo == null)
                    return (false, 0, "Không tìm thấy lớp học.");

                if (classInfo.SchoolDays == null || !classInfo.SchoolDays.Any())
                    return (false, 0, "Lớp học chưa được cấu hình ngày học (Thứ). Vui lòng cập nhật lớp học trước.");


                await _sessionRepo.DeleteByClassIdAsync(classId);

                List<ClassSession> newSessions = new List<ClassSession>();

                DateTime currentDate = classInfo.StartDate.ToDateTime(TimeOnly.MinValue);
                DateTime endDate = classInfo.EndDate.ToDateTime(TimeOnly.MinValue);

                int sessionNum = 1;

                var selectedDayIds = classInfo.SchoolDays.Select(sd => sd.SchoolDayId).ToList();

                while (currentDate <= endDate)
                {
                    byte currentDayId = MapDayOfWeekToSchoolDayId(currentDate.DayOfWeek);

                    if (selectedDayIds.Contains(currentDayId))
                    {
                        var session = new ClassSession
                        {
                            ClassId = classId,
                            SessionDate = DateOnly.FromDateTime(currentDate), 
                            SessionNumber = sessionNum,
                            CreateAt = DateTime.Now
                        };

                        newSessions.Add(session);
                        sessionNum++;
                    }


                    currentDate = currentDate.AddDays(1);
                }

                if (newSessions.Count > 0)
                {
                    await _sessionRepo.AddRangeAsync(newSessions);
                    return (true, newSessions.Count, $"Đã tạo thành công {newSessions.Count} buổi học lên lịch.");
                }

                return (false, 0, "Không tạo được buổi học nào. Vui lòng kiểm tra khoảng thời gian bắt đầu/kết thúc.");
            }
            catch (Exception ex)
            {
                return (false, 0, $"Lỗi sinh lịch: {ex.Message}");
            }
        }

        private byte MapDayOfWeekToSchoolDayId(DayOfWeek day)
        {

            switch (day)
            {
                case DayOfWeek.Monday: return 2;
                case DayOfWeek.Tuesday: return 3;
                case DayOfWeek.Wednesday: return 4;
                case DayOfWeek.Thursday: return 5;
                case DayOfWeek.Friday: return 6;
                case DayOfWeek.Saturday: return 7;
                case DayOfWeek.Sunday: return 8; // Hãy sửa thành 1 nếu DB của bạn CN là 1
                default: return 0;
            }
        }

        

        
    }
}
