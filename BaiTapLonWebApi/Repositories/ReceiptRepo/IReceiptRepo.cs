using BaiTapLonWebApi.Models;

namespace BaiTapLonWebApi.Repositories.ReceiptRepo
{
    public interface IReceiptRepo
    {
        Task<bool> CreateReceipt(Receipt data);
    }
}
