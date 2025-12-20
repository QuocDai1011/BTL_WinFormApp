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
    internal class SchoolDayRepository : ISchoolDayRepository
    {
        private readonly EnglishCenterDbContext _context;

        public SchoolDayRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public List<string> GetListSchoolDaysByClassId(int classId)
        {
            var days = _context.Classes
                .Include(c => c.SchoolDays)
                .Where(c => c.ClassId == classId)
                .SelectMany(c => c.SchoolDays)
                .Select(sd => sd.DayOfWeek)
                .ToList();
            return days;
        }
    }
}
