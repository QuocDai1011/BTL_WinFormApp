using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.interfaces
{
    public interface IStudentService
    {
        Task<(bool Success, string Message, IEnumerable<Student> Data)> GetAllStudentsAsync();
        Task<(bool Success, string Message, Student Data)> GetStudentByIdAsync(int? id);
        Task<(bool Success, string Message, Student Data)> GetStudentByUserIdAsync(long userId);
        Task<(bool Success, string Message, Student Data)> CreateStudentAsync(Student student);
        Task<(bool Success, string Message, Student Data)> UpdateStudentAsync(Student student);
        Task<(bool Success, string Message)> DeleteStudentAsync(int id);
        Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsWithClassesAsync();
        Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsByClassIdAsync(int classId);
        Task<(bool Success, string Message, IEnumerable<Student> Data)> SearchStudentsByNameAsync(string keyword);
        Task<(bool Success, string Message, int Data)> GetClassCountAsync(int studentId);
        Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsWithoutClassAsync();
        Task<(bool Success, string Message)> CanEnrollClassAsync(int studentId);
    }
}
