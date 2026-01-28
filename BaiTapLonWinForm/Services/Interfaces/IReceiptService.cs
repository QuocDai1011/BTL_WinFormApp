using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IReceiptService
    {
        List<ReceiptDto> GetAllReceiptByStudentId(int studentId);
    }
}
