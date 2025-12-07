using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.interfaces
{
    public interface IClassService
    {
        Task<(bool Success, string Message, IEnumerable<Class> Data)> GetAllClassesAsync();
        Task<(bool Success, string Message, Class Data)> GetClassByIdAsync(int id);
        Task<(bool Success, string Message, Class Data)> CreateClassAsync(Class classEntity);
        Task<(bool Success, string Message, Class Data)> UpdateClassAsync(Class classEntity);
        Task<(bool Success, string Message)> DeleteClassAsync(int id);
        Task<(bool Success, string Message, IEnumerable<Class> Data)> GetClassesByTeacherAsync(int teacherId);
        Task<(bool Success, string Message, IEnumerable<Class> Data)> GetClassesByStatusAsync(int status);
        Task<(bool Success, string Message, IEnumerable<Class> Data)> GetActiveClassesAsync();
        Task<(bool Success, string Message)> CanAddStudentAsync(int classId);
        Task<(bool Success, string Message)> UpdateStudentCountAsync(int classId, int count);

        Task<(bool Success, string Message)> AddStudentsToClassAsync(int classId, List<int> studentIds);
    }
}
