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

        public Teacher GetAllTeacherByClassId(long classId)
        {
            var teacher = _context.Classes
            .Where(c => c.ClassId == classId)
            .Include(c => c.Teacher)
            .Select(c => c.Teacher)
            .FirstOrDefault();
            return teacher;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            try
            {
                return await _context.Teachers
                    .Include(t => t.User)
                    .Include(t => t.Classes)
                    .Include(f => f.TeacherFaceImages)
                    .AsNoTracking()
                    .OrderByDescending(t => t.TeacherId)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

      
        public async Task<Teacher?> GetByUserIdAsync(long userId)
        {
            try
            {
                return await _context.Teachers
                    .Include(t => t.User)
                    .Include(t => t.Classes)
                    .FirstOrDefaultAsync(t => t.UserId == userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Teacher> CreateAsync(Teacher entity)
        {
            try
            {
                await _context.Teachers.AddAsync(entity);
                await _context.SaveChangesAsync();

                // Load navigation properties
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Teachers.FindAsync(id);
                if (entity == null)
                    return false;

                _context.Teachers.Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Teacher>> GetTeachersWithClassesAsync()
        {
            try
            {
                return await _context.Teachers
                    .Include(t => t.User)
                    .Include(t => t.Classes)
                    .Where(t => t.Classes.Any())
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Teacher>> GetTeachersByExperienceAsync(int minYears, int maxYears)
        {
            try
            {
                return await _context.Teachers
                    .Include(t => t.User)
                    .Include(t => t.Classes)
                    .Where(t => t.ExperienceYear >= minYears && t.ExperienceYear <= maxYears)
                    .OrderByDescending(t => t.ExperienceYear)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAvailableTeachersAsync()
        {
            try
            {
                // Giáo viên có ít hơn 10 lớp (có thể điều chỉnh)
                return await _context.Teachers
                    .Include(t => t.User)
                    .Include(t => t.Classes)
                    .Where(t => t.User.IsActive == true)
                    .Where(t => t.Classes.Count < 10)
                    .OrderBy(t => t.Classes.Count)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetClassCountAsync(int teacherId)
        {
            try
            {
                var teacher = await _context.Teachers
                    .Include(t => t.Classes)
                    .FirstOrDefaultAsync(t => t.TeacherId == teacherId);

                return teacher?.Classes.Count ?? 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsTeacherUserMatchAsync(int teacherId, long userId)
        {
            try
            {
                return await _context.Teachers
              .AnyAsync(t => t.TeacherId == teacherId && t.UserId == userId);
            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsUserIdAssignedToOtherTeacherAsync(long userId, int currentTeacherId)
        {
            try
            {
                return await _context.Teachers
                .AnyAsync(t => t.UserId == userId && t.TeacherId != currentTeacherId);
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
