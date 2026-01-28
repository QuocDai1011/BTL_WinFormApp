using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EnglishCenterDbContext _context;

        public CourseRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public Course? GetCourseByClassId(long classId)
        {
            Course? course = _context.Classes
                .Include(c => c.Course)
                .Where(c => c.ClassId == classId)
                .Select(c => c.Course)
                .FirstOrDefault();
            return course;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            try
            {
                return await _context.Courses
                    .OrderByDescending(c => c.CreateAt)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Courses
                    .FirstOrDefaultAsync(c => c.CourseId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Course?> GetByCourseCodeAsync(string courseCode)
        {
            try
            {
                return await _context.Courses
                    .FirstOrDefaultAsync(c => c.CourseCode == courseCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Course> CreateAsync(Course entity)
        {
            try
            {
                entity.CreateAt = DateTime.Now;
                entity.UpdateAt = DateTime.Now;

                await _context.Courses.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            try
            {
                entity.UpdateAt = DateTime.Now;

                _context.Courses.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Courses.FindAsync(id);
                if (entity == null)
                    return false;

                _context.Courses.Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                return await _context.Courses.AnyAsync(c => c.CourseId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CourseCodeExistsAsync(string courseCode, int? excludeCourseId = null)
        {
            try
            {
                var query = _context.Courses.Where(c => c.CourseCode == courseCode);

                if (excludeCourseId.HasValue)
                    query = query.Where(c => c.CourseId != excludeCourseId.Value);

                return await query.AnyAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesByLevelAsync(string level)
        {
            try
            {
                return await _context.Courses
                    .Where(c => c.Level == level)
                    .OrderBy(c => c.CourseName)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesWithClassesAsync()
        {
            try
            {
                return await _context.Courses
                    .OrderBy(c => c.CourseName)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Course>> SearchByNameAsync(string keyword)
        {
            try
            {
                return await _context.Courses
                    .Where(c => c.CourseName.Contains(keyword) || c.CourseCode.Contains(keyword))
                    .OrderBy(c => c.CourseName)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetClassCountAsync(int courseId)
        {
            try
            {
                var course = await _context.Courses
                    .FirstOrDefaultAsync(c => c.CourseId == courseId);

                return course?.Classes.Count ?? 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesByTuitionRangeAsync(decimal minTuition, decimal maxTuition)
        {
            try
            {
                return await _context.Courses
                    .Where(c => c.Tuition >= minTuition && c.Tuition <= maxTuition)
                    .OrderBy(c => c.Tuition)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetTotalStudentByClassCode(string classCode)
        {
            int totalStudents = await
                (from co in _context.Courses
                 join cl in _context.Classes
                     on co.CourseId equals cl.CourseId
                 join s in _context.StudentClasses
                     on cl.ClassId equals s.ClassId
                 where co.CourseCode.Contains(classCode)
                 select s.StudentId
                )
                .Distinct()
                .CountAsync();

            return totalStudents;
        }


        public async Task<int> GetTotalStudentByOtherClassCode()
        {
            return await
                (from co in _context.Courses
                 join cl in _context.Classes
                     on co.CourseId equals cl.CourseId
                 join s in _context.StudentClasses
                     on cl.ClassId equals s.ClassId
                 where !new[] { "MOVERS", "FLYERS", "KET" }
                        .Contains(co.CourseCode)
                       && !co.CourseCode.StartsWith("IELTS")
                 select s.StudentId
                )
                .Distinct()
                .CountAsync();
        }
 
    }
}
