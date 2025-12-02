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
    internal class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            try
            {
                return await _context.Classes
                    .Include(c => c.Teacher)
                    .Include(c => c.StudentClasses)
                    .Include(c => c.Courses)
                    .Include(c => c.SchoolDays)
                    .OrderByDescending(c => c.CreateAt)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Classes
                    .Include(c => c.Teacher)
                    .Include(c => c.StudentClasses)
                    .Include(c => c.Courses)
                    .Include(c => c.SchoolDays)
                    .FirstOrDefaultAsync(c => c.ClassId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Class> CreateAsync(Class entity)
        {
            try
            {
                entity.CreateAt = DateTime.Now;
                entity.UpdateAt = DateTime.Now;
                entity.CurrentStudent ??= 0;

                await _context.Classes.AddAsync(entity);
                await _context.SaveChangesAsync();

                // Load navigation properties
                await _context.Entry(entity)
                    .Reference(c => c.Teacher)
                    .LoadAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Class> UpdateAsync(Class entity)
        {
            try
            {
                entity.UpdateAt = DateTime.Now;

                _context.Classes.Update(entity);
                await _context.SaveChangesAsync();

                // Reload to get updated navigation properties
                await _context.Entry(entity)
                    .Reference(c => c.Teacher)
                    .LoadAsync();

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
                var entity = await _context.Classes.FindAsync(id);
                if (entity == null)
                    return false;

                _context.Classes.Remove(entity);
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
                return await _context.Classes.AnyAsync(c => c.ClassId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Class>> GetByTeacherIdAsync(int teacherId)
        {
            try
            {
                return await _context.Classes
                    .Include(c => c.Teacher)
                    .Include(c => c.StudentClasses)
                    .Where(c => c.TeacherId == teacherId)
                    .OrderByDescending(c => c.StartDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Class>> GetByStatusAsync(int status)
        {
            try
            {
                return await _context.Classes
                    .Include(c => c.Teacher)
                    .Include(c => c.StudentClasses)
                    .Where(c => c.Status == status)
                    .OrderByDescending(c => c.StartDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Class>> GetActiveClassesAsync()
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Now);
                return await _context.Classes
                    .Include(c => c.Teacher)
                    .Include(c => c.StudentClasses)
                    .Where(c => c.StartDate <= today && c.EndDate >= today && c.Status == 1)
                    .OrderBy(c => c.ClassName)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ClassNameExistsAsync(string className, int? excludeClassId = null)
        {
            try
            {
                var query = _context.Classes.Where(c => c.ClassName == className);

                if (excludeClassId.HasValue)
                    query = query.Where(c => c.ClassId != excludeClassId.Value);

                return await query.AnyAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetStudentCountAsync(int classId)
        {
            try
            {
                var classEntity = await _context.Classes
                    .Where(c => c.ClassId == classId)
                    .Select(c => c.CurrentStudent)
                    .FirstOrDefaultAsync();

                return classEntity ?? 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
