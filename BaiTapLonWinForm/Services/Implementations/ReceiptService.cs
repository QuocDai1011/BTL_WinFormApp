using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public void ChangeStatusReceipt(ReceiptDto data)
        {
            if (!data.CreateAt.HasValue)
                return;

            if (data.Status == "PAID") return;

            if ((DateTime.Now - data.CreateAt.Value).TotalHours >= 24)
            {
                _receiptRepository.UpdateStatusReceipt(data.StudentId, data.ClassId);
            }
        }

        public List<ReceiptDto> GetAllReceiptByStudentId(int studentId)
        {
            var data = _receiptRepository.GetAllReceiptByStudentId(studentId);

            if (data == null) return [];

            return data;
        }
    }
}