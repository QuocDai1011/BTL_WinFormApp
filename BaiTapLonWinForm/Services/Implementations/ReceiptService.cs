using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.View.Admin.Receipt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using BaiTapLonWinForm.DTOs;
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

        public Task<bool> ConfirmReceipt(int studentId, int ClassId)
        {
            return _receiptRepository.ConfirmReceipt(studentId, ClassId);
        }

        public async Task<List<ReceiptDTO>> GetAllReceiptsAsync()
        {
            return await _receiptRepository.GetAllReceiptsAsync();
        }

        public List<ReceiptDto> GetAllReceiptByStudentId(int studentId)
        {
            var data = _receiptRepository.GetAllReceiptByStudentId(studentId);

            if (data == null) return [];

            return data;
        }
    }
}
