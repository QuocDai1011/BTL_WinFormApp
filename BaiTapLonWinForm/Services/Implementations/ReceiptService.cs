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

        public List<ReceiptDto> GetAllReceiptByStudentId(int studentId)
        {
            var data = _receiptRepository.GetAllReceiptByStudentId(studentId);

            if (data == null) return [];

            return data;
        }
    }
}