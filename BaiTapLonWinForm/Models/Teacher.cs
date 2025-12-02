using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("teacher")]
public partial class Teacher
{
    [Key]
    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("salary")]
    public int? Salary { get; set; }

    [Column("experience_year")]
    public int? ExperienceYear { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [ForeignKey("UserId")]
    [InverseProperty("Teachers")]
    public virtual User User { get; set; } = null!;
}
