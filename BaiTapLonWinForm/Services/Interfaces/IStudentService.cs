using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IStudentService
    {
        #region feature/trung

        Task<(bool Success, string Message, IEnumerable<Student> Data)> GetAllStudentsAsync();
        Task<(bool Success, string Message, Student? Data)> GetStudentByUserIdAsync(long userId);
        Task<(bool Success, string Message)> RegisterStudentFullAsync(
            User user,
            Student student,
            List<byte[]>? faceImages = null
        );
        Task<(bool Success, string Message, Student? Data)> UpdateStudentAsync(Student student);
        Task<(bool Success, string Message, Student? Data)> GetStudentByIdAsync(int studentId);
        Task<(bool Success, string Message)> DeleteStudentAsync(int id);
        Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsWithClassesAsync();
        Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsByClassIdAsync(int classId);
        Task<(bool Success, string Message, IEnumerable<Student>? Data)> SearchStudentsByNameAsync(string keyword);
        Task<(bool Success, string Message, int Data)> GetClassCountAsync(int studentId);
        Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsWithoutClassAsync();
        Task<(bool Success, string Message)> CanEnrollClassAsync(int studentId);

        #endregion


        #region feature/ha

        List<Student> GetAllStudentByClassId(long classId);

        #endregion


        #region feature/nhan

        Student? GetStudentByStudentId(int studentId);
        bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data);
        List<ClassDto> GetClassesByStudentId(int studentId);

        #endregion
    }
}
