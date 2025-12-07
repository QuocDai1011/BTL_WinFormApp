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
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<(bool Success, string Message, IEnumerable<Class> Data)> GetAllClassesAsync()
        {
            try
            {
                var classes = await _classRepository.GetAllAsync();
                return (true, $"Lấy danh sách {classes.Count()} lớp học thành công", classes);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Class Data)> GetClassByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID lớp học không hợp lệ", null);

                var classEntity = await _classRepository.GetByIdAsync(id);

                if (classEntity == null)
                    return (false, "Không tìm thấy lớp học", null);

                return (true, "Lấy thông tin lớp học thành công", classEntity);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Class Data)> CreateClassAsync(Class classEntity)
        {
            try
            {
                // Validation
                var (isValid, message) = ClassValidator.ValidateForCreate(classEntity);
                if (!isValid)
                    return (false, message, null);

                var createdClass = await _classRepository.CreateAsync(classEntity);
                return (true, "Tạo lớp học thành công", createdClass);
            }
            catch (DbUpdateException ex)
            {
                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Class Data)> UpdateClassAsync(Class classEntity)
        {
            try
            {
                // Validation
                var (isValid, message) = ClassValidator.ValidateForUpdate(classEntity);
                if (!isValid)
                    return (false, message, null);

                // Check exists
                if (!await _classRepository.ExistsAsync(classEntity.ClassId))
                    return (false, "Không tìm thấy lớp học", null);

                var updatedClass = await _classRepository.UpdateAsync(classEntity);

                if (updatedClass == null)
                    return (false, "Không thể cập nhật lớp học", null);

                return (true, "Cập nhật lớp học thành công", updatedClass);
            }
            catch (DbUpdateException ex)
            {
                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteClassAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID lớp học không hợp lệ");

                var classEntity = await _classRepository.GetByIdAsync(id);
                if (classEntity == null)
                    return (false, "Không tìm thấy lớp học");

                // Validate can delete
                var (canDelete, message) = ClassValidator.CanDeleteClass(classEntity);
                if (!canDelete)
                    return (false, message);

                var result = await _classRepository.DeleteAsync(id);

                if (!result)
                    return (false, "Không thể xóa lớp học");

                return (true, "Xóa lớp học thành công");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                    return (false, "Không thể xóa lớp học vì có dữ liệu liên quan (học sinh, khóa học, ngày học)");

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Class> Data)> GetClassesByTeacherAsync(int teacherId)
        {
            try
            {
                if (teacherId <= 0)
                    return (false, "Teacher ID không hợp lệ", null);

                var classes = await _classRepository.GetByTeacherIdAsync(teacherId);
                return (true, $"Lấy danh sách {classes.Count()} lớp học của giáo viên thành công", classes);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Class> Data)> GetClassesByStatusAsync(int status)
        {
            try
            {
                var classes = await _classRepository.GetByStatusAsync(status);
                return (true, $"Lấy danh sách {classes.Count()} lớp học theo trạng thái thành công", classes);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Class> Data)> GetActiveClassesAsync()
        {
            try
            {
                var classes = await _classRepository.GetActiveClassesAsync();
                return (true, $"Lấy danh sách {classes.Count()} lớp học đang hoạt động thành công", classes);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> CanAddStudentAsync(int classId)
        {
            try
            {
                if (classId <= 0)
                    return (false, "ID lớp học không hợp lệ");

                var classEntity = await _classRepository.GetByIdAsync(classId);
                if (classEntity == null)
                    return (false, "Không tìm thấy lớp học");

                var (canAdd, errorMessage) = ClassValidator.CanAddStudent(classEntity);

                if (!canAdd)
                    return (false, errorMessage);

                return (true, "Có thể thêm học sinh vào lớp");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> UpdateStudentCountAsync(int classId, int count)
        {
            try
            {
                if (classId <= 0)
                    return (false, "ID lớp học không hợp lệ");

                var classEntity = await _classRepository.GetByIdAsync(classId);
                if (classEntity == null)
                    return (false, "Không tìm thấy lớp học");

                var newCount = (classEntity.CurrentStudent ?? 0) + count;
                classEntity.CurrentStudent = newCount;

                // Validate student capacity
                var (isValid, errorMessage) = ClassValidator.ValidateStudentCapacity(
                    classEntity.CurrentStudent,
                    classEntity.MaxStudent);

                if (!isValid)
                    return (false, errorMessage);

                await _classRepository.UpdateAsync(classEntity);

                return (true, $"Cập nhật số lượng học sinh thành công. Số học sinh hiện tại: {newCount}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> AddStudentsToClassAsync(int classId, List<int> studentIds)
        {
            try
            {
                // Kiểm tra lớp tồn tại
                var classEntity = await _classRepository.GetByIdAsync(classId);
                if (classEntity == null) return (false, "Lớp học không tồn tại.");

                // Kiểm tra sĩ số tối đa
                int currentCount = classEntity.CurrentStudent ?? 0;
                int maxCount = classEntity.MaxStudent ?? 0;

                if (maxCount > 0 && (currentCount + studentIds.Count) > maxCount)
                {
                    return (false, $"Lớp đã đầy hoặc không đủ chỗ. Còn trống {maxCount - currentCount} chỗ.");
                }


                foreach (var studentId in studentIds)
                {
                    var studentClass = new StudentClass
                    {
                        ClassId = classId,
                        StudentId = studentId,
                        CreateAt = DateTime.Now,
                    };

                    bool result = await _classRepository.AddStudentToClass(studentClass);
                }

                // Cập nhật lại số lượng học viên
                classEntity.CurrentStudent += studentIds.Count;
                await _classRepository.UpdateAsync(classEntity);

                return (true, "Thêm học viên thành công.");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }
    }
}
