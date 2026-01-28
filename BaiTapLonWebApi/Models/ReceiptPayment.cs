using System;
using System.Collections.Generic;

namespace BaiTapLonWebApi.Models;

public partial class ReceiptPayment
{
    public int PaymentId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int PromotionId { get; set; }

    public decimal? PayAmount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Receipt Receipt { get; set; } = null!;
}
