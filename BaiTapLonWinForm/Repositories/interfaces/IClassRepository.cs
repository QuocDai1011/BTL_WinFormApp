using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class?> GetByIdAsync(int id);
        Task<Class> CreateAsync(Class entity);
        Task<Class> UpdateAsync(Class entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Class>> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<Class>> GetByStatusAsync(int status);
        Task<IEnumerable<Class>> GetActiveClassesAsync();

        Task<bool> AddStudentToClass(StudentClass studentClass);
    }
}
