using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("school_day")]
public partial class SchoolDay
{
    [Key]
    [Column("school_day_id")]
    public byte SchoolDayId { get; set; }

    [Column("day_of_week")]
    [StringLength(100)]
    public string DayOfWeek { get; set; } = null!;

    [ForeignKey("SchoolDayId")]
    [InverseProperty("SchoolDays")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
