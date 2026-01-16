using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Receipt
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int PromotionId { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;

    public virtual ICollection<ReceiptPayment> ReceiptPayments { get; set; } = new List<ReceiptPayment>();

    public virtual Student Student { get; set; } = null!;
}
