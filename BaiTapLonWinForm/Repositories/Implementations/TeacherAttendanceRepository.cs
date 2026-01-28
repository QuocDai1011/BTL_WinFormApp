using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class TeacherAttendanceRepository : ITeacherAttendanceRepository
    {
        private readonly EnglishCenterDbContext _context;

        public TeacherAttendanceRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public async Task<TeacherAttendance> AddAsync(TeacherAttendance attendance)
        {
            _context.TeacherAttendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<List<TeacherAttendance>> GetBySessionIdAsync(int sessionId)
        {
            return await _context.TeacherAttendances
                .Include(a => a.Teacher)
                .ThenInclude(s => s.User)
                .Where(a => a.SessionId == sessionId)
                .ToListAsync();
        }

        public async Task<TeacherAttendance> GetByTeacherAndSessionAsync(int teacherId, int sessionId)
        {
            return await _context.TeacherAttendances
                .FirstOrDefaultAsync(a => a.TeacherId == teacherId && a.SessionId == sessionId);
        }

        public async Task<bool> UpdateAsync(TeacherAttendance attendance)
        {
            _context.TeacherAttendances.Update(attendance);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
