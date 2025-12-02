using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course?> GetByCourseCodeAsync(string courseCode);
        Task<Course> CreateAsync(Course entity);
        Task<Course> UpdateAsync(Course entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> CourseCodeExistsAsync(string courseCode, int? excludeCourseId = null);
        Task<IEnumerable<Course>> GetCoursesByLevelAsync(string level);
        Task<IEnumerable<Course>> GetCoursesWithClassesAsync();
        Task<IEnumerable<Course>> SearchByNameAsync(string keyword);
        Task<int> GetClassCountAsync(int courseId);
        Task<IEnumerable<Course>> GetCoursesByTuitionRangeAsync(decimal minTuition, decimal maxTuition);
    }
}
