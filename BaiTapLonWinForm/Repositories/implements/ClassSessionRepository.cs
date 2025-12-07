using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.implements
{
    public class ClassSessionRepository : IClassSessionRepository
    {
        private readonly AppDbContext _context;

        public ClassSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClassSession> AddAsync(ClassSession session)
        {
            _context.ClassSessions.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<ClassSession> GetByIdAsync(int sessionId)
        {
            return await _context.ClassSessions
                .Include(cs => cs.Class)
                .FirstOrDefaultAsync(cs => cs.SessionId == sessionId);
        }

        public async Task<List<ClassSession>> GetByClassIdAsync(int classId)
        {
            return await _context.ClassSessions
                .Where(cs => cs.ClassId == classId)
                .OrderBy(cs => cs.SessionNumber)
                .ToListAsync();
        }

        public async Task<int> CreateSessionsForClassAsync(int classId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_create_class_sessions @p0", classId);
            return await _context.ClassSessions.CountAsync(cs => cs.ClassId == classId);
        }

        public async Task<bool> UpdateAsync(ClassSession session)
        {
            _context.ClassSessions.Update(session);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
