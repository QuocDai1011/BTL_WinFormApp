using System.ComponentModel;

namespace BaiTapLonWinForm.DTOs
{
    public class ReceiptDto
    {
        [DisplayName("Khóa học")]
        public string? NameCourse { get; set; }
        public string? NameStudent { get; set; }
        public string? SchoolDay { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        [DisplayName("Mã hóa đơn")]
        public int? receiptId { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? CreateAt { get; set; }

        [DisplayName("Tổng tiền")]
        public decimal? TotalAmount { get; set; }

        [DisplayName("Đã thanh toán")]
        public decimal? PaidAmount { get; set; }

        [DisplayName("Trạng thái")]
        public string? Status { get; set; }
    }
}
