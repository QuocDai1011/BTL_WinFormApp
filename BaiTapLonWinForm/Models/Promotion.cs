using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("promotion")]
public partial class Promotion
{
    [Key]
    [Column("promotion_id")]
    public int PromotionId { get; set; }

    [Column("promotion_name")]
    public string PromotionName { get; set; } = null!;

    [Column("discount_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DiscountType { get; set; }

    [Column("discount_value", TypeName = "decimal(12, 3)")]
    public decimal DiscountValue { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }
}
