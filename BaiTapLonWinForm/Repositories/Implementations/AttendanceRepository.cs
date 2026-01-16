using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly EnglishCenterDbContext _context;

        public AttendanceRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> GetByStudentAndSessionAsync(int studentId, int sessionId)
        {
            return await _context.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == studentId && a.SessionId == sessionId);
        }

        public async Task<List<Attendance>> GetBySessionIdAsync(int sessionId)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .ThenInclude(s => s.User)
                .Where(a => a.SessionId == sessionId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> CountPresentBySessionAsync(int sessionId)
        {
            return await _context.Attendances
                .CountAsync(a => a.SessionId == sessionId && a.IsPresent);
        }

        public async Task<int> CountAbsentBySessionAsync(int sessionId)
        {
            return await _context.Attendances
                .CountAsync(a => a.SessionId == sessionId && !a.IsPresent);
        }
    }
}
