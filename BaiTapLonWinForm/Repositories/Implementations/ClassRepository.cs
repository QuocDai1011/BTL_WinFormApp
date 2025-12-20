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
        public List<Class> getAllClasses(long teacherId)
        {
            return _context.Classes
                   .Where(c => c.TeacherId == teacherId)
                   .ToList();
        }

        public Class GetClassById(long classId)
        {
            var existClass = _context.Classes.FirstOrDefault(u => u.ClassId == classId);
            if (existClass != null)
            {
                return existClass;
            }
            return null;
        }

        public void UpdateClassesStatus(List<Class> updatedClasses)
        {
            foreach (var cls in updatedClasses)
            {
                var existing = _context.Classes.Find(cls.ClassId);
                if (existing == null) continue;

                existing.Status = cls.Status;
                //existing.UpdatedAt = DateTime.Now;
            }

            _context.SaveChanges();
        }
    }
}
