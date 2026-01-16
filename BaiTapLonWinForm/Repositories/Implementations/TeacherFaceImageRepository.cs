using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class TeacherFaceImageRepository : ITeacherFaceImageRepository
    {
        private readonly EnglishCenterDbContext _context;
        public TeacherFaceImageRepository(EnglishCenterDbContext context) { _context = context; }
        public async Task<TeacherFaceImage> AddAsync(TeacherFaceImage image)
        {
            _context.TeacherFaceImages.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<int> CountByTeacherIdAsync(int teacherId)
        {
            return await _context.TeacherFaceImages.CountAsync(f => f.TeacherId == teacherId);
        }

        public async Task<bool> DeleteByTeacherIdAsync(int teacherId)
        {
            var images = await _context.TeacherFaceImages.Where(f => f.TeacherId == teacherId).ToListAsync();
            _context.TeacherFaceImages.RemoveRange(images);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TeacherFaceImage>> GetByStudentIdAsync(int teacherId)
        {
            return await _context.TeacherFaceImages
                .Where(f => f.TeacherId == teacherId)
                .OrderByDescending(f => f.UploadedDate)
                .ToListAsync();
        }
    }
}
