using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> GetByUserIdAsync(long userId);
        Task<Student> CreateAsync(Student entity);
        Task<Student> UpdateAsync(Student entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> UserIdExistsAsync(long userId, int? excludeStudentId = null);
        Task<IEnumerable<Student>> GetStudentsWithClassesAsync();
        Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
        Task<IEnumerable<Student>> SearchByNameAsync(string keyword);
        Task<int> GetClassCountAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsWithoutClassAsync();

    }
}
