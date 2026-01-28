using BaiTapLonWinForm.View.Admin.Receipt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<List<ReceiptDTO>> GetAllReceiptsAsync();
        Task<bool> ConfirmReceipt(int studentId, int ClassId);
    }
}
