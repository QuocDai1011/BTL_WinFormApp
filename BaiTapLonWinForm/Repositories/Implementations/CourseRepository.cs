using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
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
                .AsNoTracking()
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
                    .AsNoTracking()
                    .OrderByDescending(c => c.CreateAt)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
