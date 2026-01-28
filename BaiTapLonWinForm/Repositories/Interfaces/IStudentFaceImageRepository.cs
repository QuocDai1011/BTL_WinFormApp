using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IStudentFaceImageRepository
    {
        Task<StudentFaceImage> AddAsync(StudentFaceImage image);
        Task<List<StudentFaceImage>> GetByStudentIdAsync(int studentId);
        Task<int> CountByStudentIdAsync(int studentId);
        Task<bool> DeleteByStudentIdAsync(int studentId);
        Task<StudentFaceImage> GetByIdAsync(int imageId);
    }
}