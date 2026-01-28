using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
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
    }
}
