using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IClassService
    {
        #region feature/trung branch
        Class GetClassById(int classId);
        List<Class> UpdateClassesStatusList(List<Class> updatedClasses);
        Task<(bool Success, string Message, IEnumerable<Class>? Data)> GetAllClassesAsync();
        Task<(bool Success, string Message, Class? Data)> GetClassByIdAsync(int id);
        Task<(bool Success, string Message, Class? Data)> CreateClassAsync(Class classEntity);
        Task<(bool Success, string Message, Class? Data)> UpdateClassAsync(Class classEntity);
        Task<(bool Success, string Message)> DeleteClassAsync(int id);
        Task<(bool Success, string Message, IEnumerable<Class>? Data)> GetClassesByTeacherAsync(int teacherId);
        Task<(bool Success, string Message, IEnumerable<Class> Data)> GetClassesByStatusAsync(int status);
        Task<(bool Success, string Message, IEnumerable<Class> Data)> GetActiveClassesAsync();
        Task<(bool Success, string Message)> CanAddStudentAsync(int classId);

        Task<(bool Success, string Message)> AddStudentsToClassAsync(int classId, List<int> studentIds);

        Task<(bool Success, string Message)> RemoveStudentFromClassAsync(int classId, int studentId);

        (bool Success, string Message, IEnumerable<Class>? Data) getClassesByStudentId(int studentId);

        // chạy trong program, tự động chạy khi run app để cập nhật status theo ngày hiện tại
        Task<int> UpdateClassStatusesAutoAsync();

        // hàm dùng để lấy lịch giảng dạy của giảng viên theo khoảng thời gian
        Task<List<ClassSession>> GetScheduleForWeekFromClassAsync(DateOnly weekStart, DateOnly weekEnd);

        #endregion

        #region feature/ha branch 
        Task<List<Class>> GetAllClassAsync(int teacherId);

        #endregion
    }
}
