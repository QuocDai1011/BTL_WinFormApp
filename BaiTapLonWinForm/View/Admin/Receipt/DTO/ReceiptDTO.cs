using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.View.Admin.Receipt.DTO
{
    public class ReceiptDTO
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int PromotionId { get; set; }

        public string FullName { get; set; }
        public string PromotionName { get; set; }
        public string ClassName { get; set; }
        public decimal Tuition { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
