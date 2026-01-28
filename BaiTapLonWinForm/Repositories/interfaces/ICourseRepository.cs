using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        #region feature/trung branch 
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
        #endregion

        #region feature/ha branch 
        Course? GetCourseByClassId(long classId);

        #endregion

        #region feature/nhan branch 
        decimal Getamount(int courseId);

        List<CourseDto> GetAllCourse();

        List<Class>? GetClassByCourseId(int courseId);

        void Add(Receipt receipt);

        Receipt GetByTransferContent(string content);

        void UpdateStatus(int receiptId, string status);

        bool ExistReceipt(int studentId, int classId);
        #endregion
    }
}
