using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EnglistCenterContext _context;
        public StudentRepository(EnglistCenterContext context)
        {
            _context = context;
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
    }
}
