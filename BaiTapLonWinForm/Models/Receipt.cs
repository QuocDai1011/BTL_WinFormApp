using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[PrimaryKey("StudentId", "ClassId", "PromotionId")]
[Table("receipt")]
public partial class Receipt
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Key]
    [Column("class_id")]
    public int ClassId { get; set; }

    [Key]
    [Column("promotion_id")]
    public int PromotionId { get; set; }

    [Column("amount", TypeName = "decimal(12, 3)")]
    public decimal Amount { get; set; }

    [Column("payment_date")]
    public DateOnly? PaymentDate { get; set; }

    [Column("payment_method")]
    [StringLength(30)]
    [Unicode(false)]
    public string? PaymentMethod { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("number_of_payments")]
    public int? NumberOfPayments { get; set; }

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }
}
