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
    internal class ClassRepository : IClassRepository
    {
        private readonly EnglishCenterDbContext _context;

        public ClassRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAllClassesAsync(int teacherId)
        {
            return await _context.Classes
                .AsNoTracking()
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();
        }

        public Class GetClassById(int classId)
        {
            return _context.Classes
                .AsNoTracking()
                .FirstOrDefault(u => u.ClassId == classId);
        }

        public void UpdateClassesStatus(List<Class> updatedClasses)
        {
            foreach (var cls in updatedClasses)
            {
                var existing = _context.Classes.Find(cls.ClassId);
                if (existing == null) continue;

                existing.Status = cls.Status;
            }

            _context.SaveChanges();
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            try
            {
                return await _context.Classes
                    .Include(c => c.Teacher)
                       .ThenInclude(u => u.User)
                    .Include(c => c.StudentClasses)
                    .Include(c => c.Course)
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
            return await _context.Classes
                .AsNoTracking()
                .Include(c => c.Course)          
                .Include(c => c.Teacher)
                    .ThenInclude(t => t.User)   
                .Include(c => c.StudentClasses)
                    .ThenInclude(sc => sc.Student)
                        .ThenInclude(s => s.User) 
                .Include(sd => sd.SchoolDays)
                .FirstOrDefaultAsync(c => c.ClassId == id);
        }

        public async Task<Class> CreateAsync(Class entity)
        {
            try
            {
                entity.CreateAt = DateTime.Now;
                entity.UpdateAt = DateTime.Now;
                entity.CurrentStudent ??= 0;

                if (entity.SchoolDays != null)
                {
                    var selectedIds = entity.SchoolDays.Select(sc => sc.SchoolDayId).ToList();

                    entity.SchoolDays.Clear();


                    foreach (var id in selectedIds)
                    {
                        var dayInDb = await _context.SchoolDays.FindAsync(id);

                        if (dayInDb != null)
                        {
                            entity.SchoolDays.Add(dayInDb);
                        }
                    }
                }

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


        public async Task<Models.Class> UpdateAsync(Models.Class updateModel)
        {

            var existingClass = await _context.Classes
                .Include(c => c.SchoolDays)
                .FirstOrDefaultAsync(c => c.ClassId == updateModel.ClassId);

            if (existingClass == null) return null;

           
            var oldCurrentStudent = existingClass.CurrentStudent;
            var oldCreateAt = existingClass.CreateAt;
            var oldStatus = existingClass.Status;
            
            _context.Entry(existingClass).CurrentValues.SetValues(updateModel);


            existingClass.CurrentStudent = oldCurrentStudent;
            existingClass.CreateAt = oldCreateAt;
             existingClass.Status = oldStatus;

            existingClass.UpdateAt = DateTime.Now; 

            existingClass.SchoolDays.Clear();

            if (updateModel.SchoolDays != null)
            {
                foreach (var dayFromUI in updateModel.SchoolDays)
                {
                    // Tìm ngày trong DB dựa trên ID để tránh lỗi Tracking
                    var dayInDb = await _context.SchoolDays.FindAsync(dayFromUI.SchoolDayId);

                    if (dayInDb != null)
                    {
                        existingClass.SchoolDays.Add(dayInDb);
                    }    
                }
            }

            // 4. Lưu thay đổi xuống Database
            await _context.SaveChangesAsync();

            return existingClass;
        }

        public async Task<bool> UpdateStatusAsync(Class entity)
        {
            var rowsAffected = await _context.Classes
                .Where(c => c.ClassId == entity.ClassId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.Status, entity.Status)
                    .SetProperty(c => c.UpdateAt, DateTime.Now)
                );

            return rowsAffected > 0;
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

        public async Task<bool> AddStudentToClass(StudentClass studentClass)
        {
            try
            {
                _context.StudentClasses.Add(studentClass);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RemoveStudentFromClassAsync(int classId, int studentId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var studentClass = await _context.StudentClasses
                    .FirstOrDefaultAsync(sc => sc.ClassId == classId && sc.StudentId == studentId);

                if (studentClass == null) return false;

                _context.StudentClasses.Remove(studentClass);

                await _context.SaveChangesAsync();

                var classEntity = await _context.Classes.FindAsync(classId);
                if (classEntity != null)
                {

                    int realCount = await _context.StudentClasses
                                            .CountAsync(sc => sc.ClassId == classId);

                    classEntity.CurrentStudent = realCount;
                    classEntity.UpdateAt = DateTime.Now;

                    _context.Classes.Update(classEntity);
                    await _context.SaveChangesAsync(); 
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"Lỗi khi xóa học viên: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public  IEnumerable<Class> GetClassByStudentId(int studentId)
        {
            try
            {
                return _context.StudentClasses
                   .Where(sc => sc.StudentId == studentId)
                   .Include(sc => sc.Class)
                   .Select(c => c.Class)
                   .ToList();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // kiểm tra xem có trùng lịch học không và trả về lớp đã bị trùng 
        public async Task<bool> CheckTeacherScheduleConflictAsync(int teacherId, byte shift, DateOnly startDate, DateOnly endDate, List<byte> dayIds, int? ignoreClassId = null)
        {
            // Bắt đầu truy vấn từ bảng Classes
            var query = _context.Classes
                // Include SchoolDays để check các thứ trong tuần
                .Include(c => c.SchoolDays)
                .Where(c =>
                    // 1. Cùng giáo viên
                    c.TeacherId == teacherId &&

                    // 2. Cùng ca học
                    c.Shift == shift &&

                    // 3. Khoảng thời gian giao nhau (Logic giao thoa chuẩn)
                    // (Ngày bắt đầu của A <= Ngày kết thúc của B) VÀ (Ngày kết thúc của A >= Ngày bắt đầu của B)
                    c.StartDate <= endDate && c.EndDate >= startDate &&

                    // Chỉ check các lớp Đang hoạt động hoặc Sắp mở (Giả sử Status != 2 là Đã kết thúc/Hủy)
                    // Bạn cần điều chỉnh theo quy ước Status của bạn (ví dụ Status != Cancelled)
                    c.Status != 2
                );

            if (ignoreClassId.HasValue)
            {
                query = query.Where(c => c.ClassId != ignoreClassId.Value);
            }

           
            var conflictingClass = await query
                .Where(c => c.SchoolDays.Any(sd => dayIds.Contains(sd.SchoolDayId)))
                .FirstOrDefaultAsync();

            return conflictingClass != null;
        }

        public async Task<List<Class>> GetClassesActiveInRangeAsync(DateOnly startDate, DateOnly endDate)
        {
            return await _context.Classes
                .AsNoTracking() 
                .Include(c => c.Teacher).ThenInclude(t => t.User) 
                .Include(c => c.Course)                           
                .Include(c => c.SchoolDays)                     
                .Where(c =>
                    (c.Status == 0 || c.Status == -1) &&              
                    c.StartDate <= endDate &&     
                    c.EndDate >= startDate        
                )
                .ToListAsync();
        }
    }
}
