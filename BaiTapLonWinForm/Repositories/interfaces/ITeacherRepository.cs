using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher?> GetByUserIdAsync(long userId);
        Task<Teacher> CreateAsync(Teacher entity);
        Task<Teacher> UpdateAsync(Teacher entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> UserIdExistsAsync(long userId, int? excludeTeacherId = null);
        Task<IEnumerable<Teacher>> GetTeachersWithClassesAsync();
        Task<IEnumerable<Teacher>> GetTeachersByExperienceAsync(int minYears, int maxYears);
        Task<IEnumerable<Teacher>> GetAvailableTeachersAsync();
        Task<int> GetClassCountAsync(int teacherId);
    }
}
