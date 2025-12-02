using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("admin")]
public partial class Admin
{
    [Key]
    [Column("admin_id")]
    public int AdminId { get; set; }

    [Column("salary", TypeName = "decimal(12, 3)")]
    public decimal? Salary { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Admins")]
    public virtual User User { get; set; } = null!;
}
