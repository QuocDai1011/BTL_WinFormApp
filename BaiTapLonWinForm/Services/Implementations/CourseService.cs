using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<(bool Success, string Message, IEnumerable<Course> Data)> GetAllCoursesAsync()
        {
            try
            {
                var courses = await _courseRepository.GetAllAsync();
                return (true, $"Lấy danh sách {courses.Count()} khóa học thành công", courses);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public Course? GetCourseByClassId(long classId)
        {
            var course = _courseRepository.GetCourseByClassId(classId);
            if (course == null)
            {
                throw new Exception("Course not found for the given class ID.");
            }
            return course;
        }

        public async Task<(bool Success, string Message, Course Data)> GetCourseByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID khóa học không hợp lệ", null);

                var course = await _courseRepository.GetByIdAsync(id);

                if (course == null)
                    return (false, "Không tìm thấy khóa học", null);

                return (true, "Lấy thông tin khóa học thành công", course);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Course Data)> GetCourseByCourseCodeAsync(string courseCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(courseCode))
                    return (false, "Mã khóa học không được để trống", null);

                var course = await _courseRepository.GetByCourseCodeAsync(courseCode);

                if (course == null)
                    return (false, "Không tìm thấy khóa học với mã này", null);

                return (true, "Lấy thông tin khóa học thành công", course);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Course Data)> CreateCourseAsync(Course course)
        {
            try
            {
                // Validation
                var (isValid, message) = CourseValidator.ValidateForCreate(course);
                if (!isValid)
                    return (false, message, null);

                // Check course code exists
                if (await _courseRepository.CourseCodeExistsAsync(course.CourseCode))
                    return (false, "Mã khóa học đã tồn tại trong hệ thống", null);

                var createdCourse = await _courseRepository.CreateAsync(course);
                return (true, "Tạo khóa học thành công", createdCourse);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("UQ__course__AB6B45F1") == true)
                    return (false, "Mã khóa học đã tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Course Data)> UpdateCourseAsync(Course course)
        {
            try
            {
                // Validation
                var (isValid, message) = CourseValidator.ValidateForUpdate(course);
                if (!isValid)
                    return (false, message, null);

                // Check exists
                if (!await _courseRepository.ExistsAsync(course.CourseId))
                    return (false, "Không tìm thấy khóa học", null);

                // Check course code exists (exclude current course)
                if (await _courseRepository.CourseCodeExistsAsync(course.CourseCode, course.CourseId))
                    return (false, "Mã khóa học đã được sử dụng bởi khóa học khác", null);

                // Validate tuition change (optional business rule)
                var oldCourse = await _courseRepository.GetByIdAsync(course.CourseId);
                if (oldCourse != null)
                {
                    var tuitionValidation = CourseValidator.ValidateTuitionUpdate(oldCourse.Tuition, course.Tuition);
                    if (!tuitionValidation.IsValid)
                    {
                        // Warning only, not blocking
                        // You can log this or show warning to user
                    }
                }

                var updatedCourse = await _courseRepository.UpdateAsync(course);

                if (updatedCourse == null)
                    return (false, "Không thể cập nhật khóa học", null);

                return (true, "Cập nhật khóa học thành công", updatedCourse);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("UQ__course__AB6B45F1") == true)
                    return (false, "Mã khóa học đã được sử dụng bởi khóa học khác", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteCourseAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID khóa học không hợp lệ");

                var course = await _courseRepository.GetByIdAsync(id);
                if (course == null)
                    return (false, "Không tìm thấy khóa học");

                // Validate can delete
                var (canDelete, message) = CourseValidator.CanDeleteCourse(course);
                if (!canDelete)
                    return (false, message);

                var result = await _courseRepository.DeleteAsync(id);

                if (!result)
                    return (false, "Không thể xóa khóa học");

                return (true, "Xóa khóa học thành công");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                    return (false, "Không thể xóa khóa học vì có dữ liệu liên quan (lớp học)");

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Course> Data)> GetCoursesByLevelAsync(string level)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(level))
                    return (false, "Cấp độ không được để trống", null);

                var courses = await _courseRepository.GetCoursesByLevelAsync(level);
                return (true, $"Lấy danh sách {courses.Count()} khóa học cấp độ {level} thành công", courses);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Course> Data)> GetCoursesWithClassesAsync()
        {
            try
            {
                var courses = await _courseRepository.GetCoursesWithClassesAsync();
                return (true, $"Lấy danh sách {courses.Count()} khóa học đang có lớp thành công", courses);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Course> Data)> SearchCoursesByNameAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return (false, "Từ khóa tìm kiếm không được để trống", null);

                if (keyword.Length < 2)
                    return (false, "Từ khóa tìm kiếm phải có ít nhất 2 ký tự", null);

                var courses = await _courseRepository.SearchByNameAsync(keyword);
                return (true, $"Tìm thấy {courses.Count()} khóa học", courses);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }
        public async Task<(bool Success, string Message, int Data)> GetClassCountAsync(int courseId)
        {
            try
            {
                if (courseId <= 0)
                    return (false, "ID khóa học không hợp lệ", 0);

                var count = await _courseRepository.GetClassCountAsync(courseId);
                return (true, $"Khóa học đang có {count} lớp học", count);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }


        public async Task<(bool Success, string Message, IEnumerable<Course> Data)> GetCoursesByTuitionRangeAsync(decimal minTuition, decimal maxTuition)
        {
            try
            {
                if (minTuition < 0 || maxTuition < 0)
                    return (false, "Học phí không thể nhỏ hơn 0", null);

                if (minTuition > maxTuition)
                    return (false, "Học phí tối thiểu không thể lớn hơn học phí tối đa", null);

                var courses = await _courseRepository.GetCoursesByTuitionRangeAsync(minTuition, maxTuition);
                return (true, $"Tìm thấy {courses.Count()} khóa học trong khoảng học phí {minTuition:N0} - {maxTuition:N0}", courses);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, int Data)> GetTotalStudentByClassCodeAsync(string classCode)
        {
            if(await _courseRepository.GetTotalStudentByClassCode(classCode) == 0 ||
                    await _courseRepository.GetTotalStudentByClassCode(classCode) < 0)
            {
                return (false, "Lớp học không tồn tại hoặc không có sinh viên nào", 0);
            }

            return (true, "Lấy tổng số sinh viên trong lớp học thành công", 
                await _courseRepository.GetTotalStudentByClassCode(classCode) );
        }

        public async Task<(bool Success, string Message, int Data)> GetTotalStudentByOtherClassCodeAsync()
        {
            if(await _courseRepository.GetTotalStudentByOtherClassCode() <= 0)
            {
                return (false, "Lỗi khi lấy tổng số sinh viên trong các lớp học khác", 0);
            }
            
            return (true, "Lấy tổng số sinh viên trong các lớp học khác thành công",
                await _courseRepository.GetTotalStudentByOtherClassCode());
        }
    }
}
