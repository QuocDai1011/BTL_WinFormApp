using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.DTOs;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly EnglishCenterDbContext _context;
        public StudentRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public List<Student> getAllStudentByClassId(long classId)
        {
            return _context.StudentClasses
                .AsNoTracking()
                .Where(sc => sc.ClassId == classId)
                .Include(sc => sc.Student)
                .Select(sc => sc.Student)
                .ToList();
        }
        public List<ClassDto> GetClassesByStudenId(int studentId)
        {
            return _context.Classes
                .AsNoTracking()
                .Where(c => c.StudentClasses.Any(sc => sc.StudentId == studentId))
                .Select(c => new ClassDto
                {
                    ClassId = c.ClassId,
                    CourseName = c.Course.CourseName,
                    ClassName = c.ClassName,
                    Node = c.Note,
                    Shift = c.Shift,

                    SchoolDay = string.Join(", ",
                        c.SchoolDays
                            .OrderBy(sd => sd.SchoolDayId)
                            .Select(sd => sd.DayOfWeek)),

                    TeacherName = c.Teacher.User.FirstName + " " + c.Teacher.User.LastName,
                })
                .ToList();
        }


        public Student? GetStudentByStudentId(int studentId)
        {
            return _context.Students
                .AsNoTracking()
                .Include(s => s.User)
                .FirstOrDefault(s => s.StudentId == studentId);
        }

        public bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data)
        {
            var student = _context.Students
                .Include(u => u.User)
                .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null) return false;

            var user = student.User;

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Email = data.Email;
            user.Gender = data.Gender;
            user.DateOfBirth = data.DateOfBirth;
            user.PhoneNumber = data.PhoneNumber;
            student.PhoneNumberOfParents = data.PhoneNumberOfParents;
            user.Address = data.Address;

            _context.SaveChanges();
            return true;
        }

        public async Task<bool> IsStudentInClassAsync(int studentId, int classId)
        {
            return await _context.StudentClasses
                .AnyAsync(sc => sc.StudentId == studentId && sc.ClassId == classId);
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                    .Include(s => s.User)
                    .Include(f => f.StudentFaceImages)
                    .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Students
                    .Include(s => s.User)
                    .Include(s => s.StudentClasses)
                        .ThenInclude(sc => sc.Class)
                            .ThenInclude(c => c.SchoolDays)
                    .FirstOrDefaultAsync(s => s.StudentId == id)
                    ?? null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Student?> GetByUserIdAsync(long userId)
        {
            try
            {
                return await _context.Students
                    .Include(s => s.User)
                    .Include(s => s.StudentClasses)
                        .ThenInclude(sc => sc.Class)
                    .FirstOrDefaultAsync(s => s.UserId == userId)
                    ?? null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            try
            {
                await _context.Students.AddAsync(entity);
                await _context.SaveChangesAsync();

                // Load navigation properties
                await _context.Entry(entity)
                    .Reference(s => s.User)
                    .LoadAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Student?> UpdateAsync(Student entity)
        {
            try
            {
                var existingStudent = await _context.Students
                                            .Include(s => s.User) 
                                            .FirstOrDefaultAsync(s => s.StudentId == entity.StudentId);
                
                if (existingStudent == null) return null;
                
                existingStudent.PhoneNumberOfParents = entity.PhoneNumberOfParents;

                if (entity.User != null && existingStudent.User != null)
                {
                    existingStudent.User.FirstName = entity.User.FirstName;
                    existingStudent.User.LastName = entity.User.LastName;
                    existingStudent.User.Email = entity.User.Email;
                    existingStudent.User.DateOfBirth = entity.User.DateOfBirth;
                    existingStudent.User.Address = entity.User.Address;
                    existingStudent.User.PhoneNumber = entity.User.PhoneNumber;
                    existingStudent.User.Gender = entity.User.Gender;
                    existingStudent.User.IsActive = entity.User.IsActive;
                    existingStudent.User.UpdateAt = DateTime.Now;
                }

                await _context.SaveChangesAsync();

                return existingStudent;


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
                var entity = await _context.Students.FindAsync(id);
                if (entity == null)
                    return false;

                _context.Students.Remove(entity);
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
                return await _context.Students.AnyAsync(s => s.StudentId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UserIdExistsAsync(long userId, int? excludeStudentId = null)
        {
            try
            {
                var query = _context.Students.Where(s => s.UserId == userId);

                if (excludeStudentId.HasValue)
                    query = query.Where(s => s.StudentId != excludeStudentId.Value);

                return await query.AnyAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsWithClassesAsync()
        {
            try
            {
                return await _context.Students
                    .Include(s => s.User)
                    .Include(s => s.StudentClasses)
                        .ThenInclude(sc => sc.Class)
                    .Where(s => s.StudentClasses.Any())
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
        {
            try
            {
                return await _context.Students
                    .Include(s => s.User)
                    .Include(s => s.StudentClasses)
                        .ThenInclude(sc => sc.Class)
                    .Where(s => s.StudentClasses.Any(sc => sc.ClassId == classId))
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> SearchByNameAsync(string keyword)
        {
            try
            {
                return await _context.Students
                    .Include(s => s.User)
                    .Include(s => s.StudentClasses)
                    .Where(s => s.User.FirstName.Contains(keyword) ||
                               s.User.Email.Contains(keyword) ||
                               s.User.LastName.Contains(keyword))
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetClassCountAsync(int studentId)
        {
            try
            {
                var student = await _context.Students
                    .Include(s => s.StudentClasses)
                    .FirstOrDefaultAsync(s => s.StudentId == studentId);

                return student?.StudentClasses.Count ?? 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsWithoutClassAsync()
        {
            try
            {
                return await _context.Students
                    .Include(s => s.User)
                    .Include(s => s.StudentClasses)
                    .Where(s => !s.StudentClasses.Any())
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }     
    }
}
