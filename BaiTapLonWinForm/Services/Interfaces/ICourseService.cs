using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ICourseService
    {
        decimal GetAmount(int courseId);
        List<CourseDto>? GetAllCourse();

        List<CourseClassDto>? GetAllClassByCourseId(int courseId);

        void CreateReceipt(int studentId, int classId, decimal amount);

        bool ExistReceipt(int studentId, int classId);
    }
}
