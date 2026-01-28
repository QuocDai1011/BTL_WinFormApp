using BaiTapLonWebApi.DTOs;
using BaiTapLonWebApi.Repositories.ReceiptRepo;

namespace BaiTapLonWebApi.Services.ReceiptService
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepo _receiptRepo;

        public ReceiptService(IReceiptRepo receiptRepo)
        {
            _receiptRepo = receiptRepo;
        }

        public async void CreateRecept(ReceiptDto data)
        {

        }
    }
}
