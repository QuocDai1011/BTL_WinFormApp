using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        decimal Getamount(int courseId);

        List<CourseDto> GetAllCourse();

        List<Class>? GetClassByCourseId(int courseId);

        void Add(Receipt receipt);

        Receipt GetByTransferContent(string content);

        void UpdateStatus(int receiptId, string status);

        bool ExistReceipt(int studentId, int classId);
    }
}
