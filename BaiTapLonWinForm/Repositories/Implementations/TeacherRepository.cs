using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EnglishCenterDbContext _context;
        
        public TeacherRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public Teacher GetAllTeacherByClassId(int classId)
        {
            return _context.Classes
                .AsNoTracking()
                .Where(c => c.ClassId == classId)
                .Include(c => c.Teacher)
                .Select(c => c.Teacher)
                .FirstOrDefault();
        }
        
        public async Task<Teacher?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Teachers
                    .AsNoTracking()
                    .Include(t => t.User)
                    .Include(t => t.Classes)
                    .FirstOrDefaultAsync(t => t.TeacherId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<Teacher> UpdateAsync(Teacher entity)
        {
            try
            {
                _context.Teachers.Update(entity);
                await _context.SaveChangesAsync();

                // Reload to get updated navigation properties
                await _context.Entry(entity)
                    .Reference(t => t.User)
                    .LoadAsync();

                return entity;
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
                return await _context.Teachers
                    .AsNoTracking()
                    .AnyAsync(t => t.TeacherId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UserIdExistsAsync(long userId, int? excludeTeacherId = null)
        {
            try
            {
                var query = _context.Teachers
                    .AsNoTracking()
                    .Where(t => t.UserId == userId);

                if (excludeTeacherId.HasValue)
                    query = query.Where(t => t.TeacherId != excludeTeacherId.Value);

                return await query.AnyAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetTeacherByUserId(long userId)
        {
            return (int)_context.Teachers
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .Select(t => (int?)t.TeacherId)
                .FirstOrDefault();
        }
    }
}
