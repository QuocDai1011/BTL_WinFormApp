using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.interfaces
{
    public interface ICourseService
    {
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
    }
}
