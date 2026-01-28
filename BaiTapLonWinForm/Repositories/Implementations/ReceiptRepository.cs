using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly EnglishCenterDbContext _context;

        public ReceiptRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public List<ReceiptDto> GetAllReceiptByStudentId(int studentId)
        {
            return _context.Receipts
                .AsNoTracking()
                .Include(r => r.Class)
                    .ThenInclude(c => c.SchoolDays)
                .Include(r => r.Student)
                    .ThenInclude(s => s.User)
                .Where(r => r.StudentId == studentId)
                .Select(r => new ReceiptDto
                {
                    NameCourse = r.Class.ClassName,
                    NameStudent = r.Student.User.FirstName + r.Student.User.LastName,
                    SchoolDay = string.Join(", ",
                        r.Class.SchoolDays
                            .OrderBy(sd => sd.SchoolDayId)
                            .Select(sd => sd.SchoolDayId)),
                    StartDate = r.Class.StartDate,
                    EndDate = r.Class.EndDate,
                    CreateAt = r.CreateAt,
                    TotalAmount = r.TotalAmount,
                    PaidAmount = r.PaidAmount,
                    Status = r.Status
                }).ToList();
        }
    }
}
