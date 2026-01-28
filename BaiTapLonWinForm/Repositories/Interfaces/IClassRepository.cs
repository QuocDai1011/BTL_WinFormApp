using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IClassRepository
    {
        #region feature/trung branch
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class?> GetByIdAsync(int id);
        Task<Class> CreateAsync(Class entity);
        Task<Class> UpdateAsync(Class entity);
        Task<bool> UpdateStatusAsync(Class entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Class>> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<Class>> GetByStatusAsync(int status);
        Task<IEnumerable<Class>> GetActiveClassesAsync();

        IEnumerable<Class> GetClassByStudentId(int studentId);

        Task<bool> AddStudentToClass(StudentClass studentClass);

        Task<bool> RemoveStudentFromClassAsync(int classId, int studentId);

        // kiểm tra trùng lịch học 
        Task<bool> CheckTeacherScheduleConflictAsync(int teacherId, byte shift, DateOnly startDate,
            DateOnly endDate, List<byte> dayIds, int? ignoreClassId = null);

        Task<List<Class>> GetClassesActiveInRangeAsync(DateOnly startDate, DateOnly endDate);
        #endregion

        #region feature/ha branch
        List<Class> getAllClasses(long teacherId);
        Class GetClassById(long classId);
        void UpdateClassesStatus(List<Class> updatedClasses);
        #endregion
    }
}
