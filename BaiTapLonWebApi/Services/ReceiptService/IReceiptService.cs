using BaiTapLonWebApi.DTOs;

namespace BaiTapLonWebApi.Services.ReceiptService
{
    public interface IReceiptService
    {
        void CreateRecept(ReceiptDto data);
    }
}
