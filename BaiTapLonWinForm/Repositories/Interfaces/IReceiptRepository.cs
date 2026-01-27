using BaiTapLonWinForm.DTOs;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        List<ReceiptDto> GetAllReceiptByStudentId(int studentId);
        void UpdateStatusReceipt(int studentId, int classId);
    }
}
