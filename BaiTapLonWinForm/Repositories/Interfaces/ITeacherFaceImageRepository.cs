using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface ITeacherFaceImageRepository
    {
        Task<TeacherFaceImage> AddAsync(TeacherFaceImage image);
        Task<int> CountByTeacherIdAsync(int teacherId);
        Task<bool> DeleteByTeacherIdAsync(int teacherId);

        Task<List<TeacherFaceImage>> GetByStudentIdAsync(int teacherId);

    }
}
