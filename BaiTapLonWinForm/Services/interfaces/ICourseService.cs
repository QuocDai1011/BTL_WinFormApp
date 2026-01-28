using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ICourseService
    {
        #region feature/trung branch
        Task<(bool Success, string Message, IEnumerable<Course> Data)> GetAllCoursesAsync();
        Task<(bool Success, string Message, Course Data)> GetCourseByIdAsync(int id);
        Task<(bool Success, string Message, Course Data)> GetCourseByCourseCodeAsync(string courseCode);
        Task<(bool Success, string Message, Course Data)> CreateCourseAsync(Course course);
        Task<(bool Success, string Message, Course Data)> UpdateCourseAsync(Course course);
        Task<(bool Success, string Message)> DeleteCourseAsync(int id);
        Task<(bool Success, string Message, IEnumerable<Course> Data)> GetCoursesByLevelAsync(string level);
        Task<(bool Success, string Message, IEnumerable<Course> Data)> GetCoursesWithClassesAsync();
        Task<(bool Success, string Message, IEnumerable<Course> Data)> SearchCoursesByNameAsync(string keyword);
        Task<(bool Success, string Message, int Data)> GetClassCountAsync(int courseId);
        Task<(bool Success, string Message, IEnumerable<Course> Data)> GetCoursesByTuitionRangeAsync(decimal minTuition, decimal maxTuition);

        #endregion

        #region feature/ha branch 
        Course? GetCourseByClassId(long classId);
        #endregion

        #region feature/nhan branch
        decimal GetAmount(int courseId);
        List<CourseDto>? GetAllCourse();

        List<CourseClassDto>? GetAllClassByCourseId(int courseId);

        void CreateReceipt(int studentId, int classId, decimal amount);

        bool ExistReceipt(int studentId, int classId);
        #endregion
    }
}
