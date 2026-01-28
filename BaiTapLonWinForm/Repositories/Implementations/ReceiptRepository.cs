using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.View.Admin.Receipt.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using BaiTapLonWinForm.DTOs;
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

        public async Task<bool> ConfirmReceipt(int studentId, int ClassId)
        {
            var receipt = await _context.Receipts
               .FirstOrDefaultAsync(r => r.StudentId == studentId && r.ClassId == ClassId);
            if (receipt == null)
            {
                return false;
            }
            else
            {
                receipt.Status = "PAID";
                receipt.UpdateAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<ReceiptDTO>> GetAllReceiptsAsync()
        {
            var receipts = await (
                from r in _context.Receipts
                join s in _context.Students on r.StudentId equals s.StudentId
                join c in _context.Classes on r.ClassId equals c.ClassId
                join co in _context.Courses on c.CourseId equals co.CourseId
                join u in _context.Users on s.UserId equals u.UserId
                join p in _context.Promotions on r.PromotionId equals p.PromotionId
                select new ReceiptDTO
                {
                    StudentId = s.StudentId,
                    ClassId = c.ClassId,
                    PromotionId = p.PromotionId,
                    FullName = u.FirstName + ' ' + u.LastName,
                    ClassName = c.ClassName,
                    PromotionName = p.PromotionName,
                    Tuition = co.Tuition,
                    Status = r.Status,
                    CreateAt = (DateTime)r.CreateAt
                }
            ).AsNoTracking().ToListAsync();

            return receipts;
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
