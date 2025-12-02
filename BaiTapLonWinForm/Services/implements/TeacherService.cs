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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetAllTeachersAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetAllAsync();
                return (true, $"Lấy danh sách {teachers.Count()} giáo viên thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Teacher Data)> GetTeacherByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID giáo viên không hợp lệ", null);

                var teacher = await _teacherRepository.GetByIdAsync(id);

                if (teacher == null)
                    return (false, "Không tìm thấy giáo viên", null);

                return (true, "Lấy thông tin giáo viên thành công", teacher);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Teacher Data)> GetTeacherByUserIdAsync(long userId)
        {
            try
            {
                if (userId <= 0)
                    return (false, "User ID không hợp lệ", null);

                var teacher = await _teacherRepository.GetByUserIdAsync(userId);

                if (teacher == null)
                    return (false, "Không tìm thấy giáo viên với User ID này", null);

                return (true, "Lấy thông tin giáo viên thành công", teacher);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Teacher Data)> CreateTeacherAsync(Teacher teacher)
        {
            try
            {
                // Validation
                var (isValid, message) = TeacherValidator.ValidateForCreate(teacher);
                if (!isValid)
                    return (false, message, null);

                // Check user exists in teacher table
                if (await _teacherRepository.UserIdExistsAsync(teacher.UserId))
                    return (false, "User ID này đã được gán cho giáo viên khác", null);

                var createdTeacher = await _teacherRepository.CreateAsync(teacher);
                return (true, "Tạo giáo viên thành công", createdTeacher);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_teacher_user") == true)
                    return (false, "User ID không tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Teacher Data)> UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                // Validation
                var (isValid, message) = TeacherValidator.ValidateForUpdate(teacher);
                if (!isValid)
                    return (false, message, null);

                // Check exists
                if (!await _teacherRepository.ExistsAsync(teacher.TeacherId))
                    return (false, "Không tìm thấy giáo viên", null);

                // Check user exists (exclude current teacher)
                if (await _teacherRepository.UserIdExistsAsync(teacher.UserId, teacher.TeacherId))
                    return (false, "User ID này đã được gán cho giáo viên khác", null);

                var updatedTeacher = await _teacherRepository.UpdateAsync(teacher);

                if (updatedTeacher == null)
                    return (false, "Không thể cập nhật giáo viên", null);

                return (true, "Cập nhật giáo viên thành công", updatedTeacher);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_teacher_user") == true)
                    return (false, "User ID không tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteTeacherAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID giáo viên không hợp lệ");

                var teacher = await _teacherRepository.GetByIdAsync(id);
                if (teacher == null)
                    return (false, "Không tìm thấy giáo viên");

                // Validate can delete
                var (canDelete, message) = TeacherValidator.CanDeleteTeacher(teacher);
                if (!canDelete)
                    return (false, message);

                var result = await _teacherRepository.DeleteAsync(id);

                if (!result)
                    return (false, "Không thể xóa giáo viên");

                return (true, "Xóa giáo viên thành công");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                    return (false, "Không thể xóa giáo viên vì có dữ liệu liên quan (lớp học)");

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetTeachersWithClassesAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetTeachersWithClassesAsync();
                return (true, $"Lấy danh sách {teachers.Count()} giáo viên đang có lớp học thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetTeachersByExperienceAsync(int minYears, int maxYears)
        {
            try
            {
                if (minYears < 0 || maxYears < 0)
                    return (false, "Số năm kinh nghiệm không hợp lệ", null);

                if (minYears > maxYears)
                    return (false, "Số năm tối thiểu không thể lớn hơn số năm tối đa", null);

                var teachers = await _teacherRepository.GetTeachersByExperienceAsync(minYears, maxYears);
                return (true, $"Lấy danh sách {teachers.Count()} giáo viên theo kinh nghiệm thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetAvailableTeachersAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetAvailableTeachersAsync();
                return (true, $"Lấy danh sách {teachers.Count()} giáo viên có thể nhận lớp thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> CanAssignClassAsync(int teacherId)
        {
            try
            {
                if (teacherId <= 0)
                    return (false, "ID giáo viên không hợp lệ");

                var teacher = await _teacherRepository.GetByIdAsync(teacherId);
                if (teacher == null)
                    return (false, "Không tìm thấy giáo viên");

                var (canAssign, message) = TeacherValidator.CanAssignClass(teacher);

                if (!canAssign)
                    return (false, message);

                return (true, "Giáo viên có thể nhận thêm lớp học");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, int Data)> GetClassCountAsync(int teacherId)
        {
            try
            {
                if (teacherId <= 0)
                    return (false, "ID giáo viên không hợp lệ", 0);

                var count = await _teacherRepository.GetClassCountAsync(teacherId);
                return (true, $"Giáo viên đang có {count} lớp học", count);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }
    }
}
