using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Vadilate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public Teacher getAllTeacherByClassId(long classId)
        {
            return _teacherRepository.GetAllTeacherByClassId(classId);
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

        public int GetTeacherByUserId(long userId)
        {
            return _teacherRepository.GetTeacherByUserId(userId);
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

    }
}
