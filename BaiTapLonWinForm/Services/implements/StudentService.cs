using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using BaiTapLonWinForm.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();
                return (true, $"Lấy danh sách {students.Count()} học sinh thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Student Data)> GetStudentByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID học sinh không hợp lệ", null);

                var student = await _studentRepository.GetByIdAsync(id);

                if (student == null)
                    return (false, "Không tìm thấy học sinh", null);

                return (true, "Lấy thông tin học sinh thành công", student);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
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

        public async Task<(bool Success, string Message, Student Data)> CreateStudentAsync(Student student)
        {
            try
            {
                // Validation
                var (isValid, message) = StudentValidator.ValidateForCreate(student);
                if (!isValid)
                    return (false, message, null);

                // Check user exists in student table
                if (await _studentRepository.UserIdExistsAsync(student.UserId))
                    return (false, "User ID này đã được gán cho học sinh khác", null);

                var createdStudent = await _studentRepository.CreateAsync(student);
                return (true, "Tạo học sinh thành công", createdStudent);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_student_user") == true)
                    return (false, "User ID không tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Student Data)> UpdateStudentAsync(Student student)
        {
            try
            {
                // Validation
                var (isValid, message) = StudentValidator.ValidateForUpdate(student);
                if (!isValid)
                    return (false, message, null);

                // Check exists
                if (!await _studentRepository.ExistsAsync(student.StudentId))
                    return (false, "Không tìm thấy học sinh", null);

                // Check user exists (exclude current student)
                if (await _studentRepository.UserIdExistsAsync(student.UserId, student.StudentId))
                    return (false, "User ID này đã được gán cho học sinh khác", null);

                var updatedStudent = await _studentRepository.UpdateAsync(student);

                if (updatedStudent == null)
                    return (false, "Không thể cập nhật học sinh", null);

                return (true, "Cập nhật học sinh thành công", updatedStudent);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_student_user") == true)
                    return (false, "User ID không tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteStudentAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID học sinh không hợp lệ");

                var student = await _studentRepository.GetByIdAsync(id);
                if (student == null)
                    return (false, "Không tìm thấy học sinh");

                // Validate can delete
                var (canDelete, message) = StudentValidator.CanDeleteStudent(student);
                if (!canDelete)
                    return (false, message);

                var result = await _studentRepository.DeleteAsync(id);

                if (!result)
                    return (false, "Không thể xóa học sinh");

                return (true, "Xóa học sinh thành công");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                    return (false, "Không thể xóa học sinh vì có dữ liệu liên quan (lớp học)");

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsWithClassesAsync()
        {
            try
            {
                var students = await _studentRepository.GetStudentsWithClassesAsync();
                return (true, $"Lấy danh sách {students.Count()} học sinh đang có lớp học thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsByClassIdAsync(int classId)
        {
            try
            {
                if (classId <= 0)
                    return (false, "ID lớp học không hợp lệ", null);

                var students = await _studentRepository.GetStudentsByClassIdAsync(classId);
                return (true, $"Lấy danh sách {students.Count()} học sinh của lớp thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> SearchStudentsByNameAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return (false, "Từ khóa tìm kiếm không được để trống", null);

                if (keyword.Length < 2)
                    return (false, "Từ khóa tìm kiếm phải có ít nhất 2 ký tự", null);

                var students = await _studentRepository.SearchByNameAsync(keyword);
                return (true, $"Tìm thấy {students.Count()} học sinh", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, int Data)> GetClassCountAsync(int studentId)
        {
            try
            {
                if (studentId <= 0)
                    return (false, "ID học sinh không hợp lệ", 0);

                var count = await _studentRepository.GetClassCountAsync(studentId);
                return (true, $"Học sinh đang học {count} lớp", count);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsWithoutClassAsync()
        {
            try
            {
                var students = await _studentRepository.GetStudentsWithoutClassAsync();
                return (true, $"Lấy danh sách {students.Count()} học sinh chưa có lớp thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> CanEnrollClassAsync(int studentId)
        {
            try
            {
                if (studentId <= 0)
                    return (false, "ID học sinh không hợp lệ");

                var student = await _studentRepository.GetByIdAsync(studentId);
                if (student == null)
                    return (false, "Không tìm thấy học sinh");

                var (canEnroll, message) = StudentValidator.CanEnrollClass(student);

                if (!canEnroll)
                    return (false, message);

                return (true, "Học sinh có thể đăng ký thêm lớp học");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public Task<(bool Success, string Message, Student Data)> GetStudentByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
