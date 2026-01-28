using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Teacher GetAllTeacherByClassId(long classId);
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> UpdateAsync(Teacher entity);
        Task<bool> ExistsAsync(int id);
        Task<bool> UserIdExistsAsync(long userId, int? excludeTeacherId = null);
        int GetTeacherByUserId(long userId);
        Task<IEnumerable<Teacher>> GetAllAsync();
 
        Task<Teacher?> GetByUserIdAsync(long userId);
        Task<Teacher> CreateAsync(Teacher entity);
        Task<bool> DeleteAsync(int id);
        
        Task<IEnumerable<Teacher>> GetTeachersWithClassesAsync();
        Task<IEnumerable<Teacher>> GetTeachersByExperienceAsync(int minYears, int maxYears);
        Task<IEnumerable<Teacher>> GetAvailableTeachersAsync();
        Task<int> GetClassCountAsync(int teacherId);

        Task<bool> IsTeacherUserMatchAsync(int teacherId, long userId);
        Task<bool> IsUserIdAssignedToOtherTeacherAsync(long userId, int currentTeacherId);
    }
}
