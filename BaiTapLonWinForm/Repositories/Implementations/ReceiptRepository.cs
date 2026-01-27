using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly EnglistCenterContext _context;

        public ReceiptRepository(EnglistCenterContext context)
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
                    StudentId = r.StudentId,
                    ClassId = r.ClassId,
                    NameCourse = r.Class.ClassName,
                    NameStudent = r.Student.User.FirstName + r.Student.User.LastName,
                    SchoolDay = string.Join(", ",
                        r.Class.SchoolDays
                            .OrderBy(sd => sd.SchoolDayId)
                            .Select(sd => sd.SchoolDayId)),
                    StartDate = r.Class.StartDate,
                    EndDate = r.Class.EndDate,
                    CreateAt = r.CreateAt,
                    UpdatedAt = r.UpdateAt,
                    TotalAmount = r.TotalAmount,
                    PaidAmount = r.PaidAmount,
                    Status = r.Status
                }).ToList();
        }

        public void UpdateStatusReceipt(int studentId, int classId)
        {
            var receipt = _context.Receipts
                .FirstOrDefault(r => r.StudentId == studentId &&
                    r.ClassId == classId);

            if (receipt == null) return;

            receipt.Status = "FALSE";
            receipt.UpdateAt = DateTime.Now;

            _context.SaveChangesAsync();
        }
    }
}
