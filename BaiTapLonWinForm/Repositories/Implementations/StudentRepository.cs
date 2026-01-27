
﻿using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                .Where(sc => sc.ClassId == classId)
                .Include(sc => sc.Student)
                .Select(sc => sc.Student)
                .ToList();
        }

        public List<ClassDto> GetClassesByStudenId(int studentId)
        {
            return _context.Classes
                .Where(c => c.StudentClasses.Any(sc => sc.StudentId == studentId))
                .Select(c => new ClassDto
                {
                    ClassId = c.ClassId,
                    CourseName = c.Course.CourseName,
                    ClassName = c.ClassName,
                    Node = c.Note,
                    Shift = c.Shift,

                    SchoolDay = c.SchoolDays
                        .OrderBy(sd => sd.SchoolDayId)
                        .Select(sd => (int)sd.SchoolDayId)
                        .ToList(),

                    TeacherName = c.Teacher.User.FirstName + " " + c.Teacher.User.LastName,
                })
                .ToList();
        }

        public List<ScheduleDto> GetScheduleClass(int studentId)
        {
            return _context.StudentClasses
                .Where(s => s.StudentId == studentId)
                .Select(s => new ScheduleDto
                {
                    ClassId = s.ClassId,
                    Course = s.Class.ClassName,
                    StartDate = s.Class.StartDate,
                    EndDate = s.Class.EndDate,
                    Shift = s.Class.Shift,
                    SchoolDays = s.Class.SchoolDays
                        .OrderBy(sd => sd.SchoolDayId)
                        .Select(sd => (int)sd.SchoolDayId)
                        .ToList(),
                    TeacherName = s.Class.Teacher.User.FirstName + " " + s.Class.Teacher.User.LastName
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
    }
}
