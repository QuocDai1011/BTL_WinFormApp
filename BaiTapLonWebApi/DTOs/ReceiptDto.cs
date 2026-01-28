using System.ComponentModel;

namespace BaiTapLonWebApi.DTOs
{
    public class ReceiptDto
    {
        public decimal? TotalAmount { get; set; }

        public decimal? PaidAmount { get; set; }

        public string? Status { get; set; }
    }
}
