using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public List<CourseDto> GetAllCourse()
        {
            return _context.Courses
                .AsNoTracking()
                .Select(c => new CourseDto
                {
                    CourseId = c.CourseId,
                    CourseCode = c.CourseCode,
                    CourseName = c.CourseName,
                    NumberSessions = c.NumberSessions,
                    Level = c.Level,
                    Tuition = c.Tuition,
                    EndDate = c.Classes
                        .Max(cl => (DateOnly?)cl.EndDate)
                }).ToList();
        }

        public decimal Getamount(int courseId)
        {
            return _context.Courses
                .AsNoTracking()
                .Where(c => c.CourseId == courseId)
                .Select(c => c.Tuition)
                .FirstOrDefault();
        }

        public List<Class>? GetClassByCourseId(int courseId)
        {
            return _context.Classes
                .AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.SchoolDays)
                .Include(c => c.Teacher)
                    .ThenInclude(c => c.User)
                .Where(c => c.CourseId == courseId)
                .ToList();
        }

        public void Add(Receipt receipt)
        {
            receipt.CreateAt = DateTime.Now;

            _context.Receipts.Add(receipt);
            _context.SaveChanges();
        }

        public Receipt GetByTransferContent(string content)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int receiptId, string status)
        {
            throw new NotImplementedException();
        }

        public bool ExistReceipt(int studentId, int classId)
        {
            return _context.Receipts.Any(r =>
                r.StudentId == studentId &&
                r.ClassId == classId);
        }
    }
}
