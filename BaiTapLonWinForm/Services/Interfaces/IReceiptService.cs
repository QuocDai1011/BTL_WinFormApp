using BaiTapLonWinForm.View.Admin.Receipt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<List<ReceiptDTO>> GetAllReceiptsAsync();
        Task<bool> ConfirmReceipt(int studentId, int ClassId);
        List<ReceiptDto> GetAllReceiptByStudentId(int studentId);
    }
}
