using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.View.Admin.Receipt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        Task<List<ReceiptDTO>> GetAllReceiptsAsync();
        Task<bool> ConfirmReceipt(int studentId, int ClassId);
    }
}
