using System;
using System.Collections.Generic;

namespace BaiTapLonWebApi.Models;

public partial class Receipt
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int PromotionId { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? Status { get; set; }

    public string TxnRef { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Promotion Promotion { get; set; } = null!;

    public virtual ICollection<ReceiptPayment> ReceiptPayments { get; set; } = new List<ReceiptPayment>();
}
