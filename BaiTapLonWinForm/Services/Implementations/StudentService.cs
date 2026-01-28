using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public List<Student> getAllStudentByClassId(long classId)
        {
            List<Student> students = new List<Student>();
            students = _studentRepository.getAllStudentByClassId(classId);
            if (students != null && students.Count > 0) 
            {
                return students;
            }
            return null;
        }
        public async Task<(bool Success, string Message, Student Data)> GetStudentByUserIdAsync(long userId)
        {
            try
            {
                if (userId <= 0)
                    return (false, "User ID không hợp lệ", null);

                var student = await _studentRepository.GetByUserIdAsync(userId);

                if (student == null)
                    return (false, "Không tìm thấy học sinh với User ID này", null);

                return (true, "Lấy thông tin học sinh thành công", student);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }
    }
}
