using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        #region feature/trung branch 
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> GetByUserIdAsync(long userId);
        Task<Student> CreateAsync(Student entity);
        Task<Student?> UpdateAsync(Student entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> UserIdExistsAsync(long userId, int? excludeStudentId = null);
        Task<IEnumerable<Student>> GetStudentsWithClassesAsync();
        Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
        Task<IEnumerable<Student>> SearchByNameAsync(string keyword);
        Task<int> GetClassCountAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsWithoutClassAsync();
        Task<bool> IsStudentInClassAsync(int studentId, int classId);
        #endregion

        #region feature/ha branch
        List<Student> getAllStudentByClassId(long classId);

        #endregion

        #region feature/nhan branch
        Student? GetStudentByStudentId(int studentId);

        bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data);

        List<ClassDto> GetClassesByStudenId(int studentId);
        #endregion
    }
}
