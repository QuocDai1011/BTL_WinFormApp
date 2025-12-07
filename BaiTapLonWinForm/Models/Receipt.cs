using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Receipt
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int PromotionId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Status { get; set; }

    public int? NumberOfPayments { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
