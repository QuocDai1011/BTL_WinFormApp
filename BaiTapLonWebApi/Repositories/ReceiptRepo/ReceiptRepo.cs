using BaiTapLonWebApi.Models;

namespace BaiTapLonWebApi.Repositories.ReceiptRepo
{
    public class ReceiptRepo : IReceiptRepo
    {
        private readonly EnglistCenterContext _context;

        public ReceiptRepo(EnglistCenterContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateReceipt(Receipt data)
        {
            try
            {
                await _context.Receipts.AddAsync(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
