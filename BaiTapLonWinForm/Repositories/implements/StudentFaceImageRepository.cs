using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.implements
{
    public class StudentFaceImageRepository : IStudentFaceImageRepository
    {
        private readonly AppDbContext _context;

        public StudentFaceImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentFaceImage> AddAsync(StudentFaceImage image)
        {
            _context.StudentFaceImages.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<List<StudentFaceImage>> GetByStudentIdAsync(int studentId)
        {
            return await _context.StudentFaceImages
                .Where(f => f.StudentId == studentId)
                .OrderByDescending(f => f.UploadedDate)
                .ToListAsync();
        }

        public async Task<int> CountByStudentIdAsync(int studentId)
        {
            return await _context.StudentFaceImages
                .CountAsync(f => f.StudentId == studentId);
        }

        public async Task<bool> DeleteByStudentIdAsync(int studentId)
        {
            var images = await _context.StudentFaceImages
                .Where(f => f.StudentId == studentId)
                .ToListAsync();

            _context.StudentFaceImages.RemoveRange(images);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentFaceImage> GetByIdAsync(int imageId)
        {
            return await _context.StudentFaceImages.FindAsync(imageId);
        }
    }
}
