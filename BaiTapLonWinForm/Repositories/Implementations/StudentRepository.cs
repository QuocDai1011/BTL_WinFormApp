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
                .Where(sc => sc.ClassId == classId)
                .Include(sc => sc.Student)
                .Select(sc => sc.Student)
                .ToList();
        }

    }
}
