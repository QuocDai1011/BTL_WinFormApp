using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[PrimaryKey("StudentId", "ClassId")]
[Table("student_class")]
public partial class StudentClass
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Key]
    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("StudentClasses")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentClasses")]
    public virtual Student Student { get; set; } = null!;
}
