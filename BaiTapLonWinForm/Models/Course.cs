using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("course")]
[Index("CourseCode", Name = "UQ__course__AB6B45F12F0466D5", IsUnique = true)]
public partial class Course
{
    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("course_code")]
    [StringLength(20)]
    [Unicode(false)]
    public string CourseCode { get; set; } = null!;

    [Column("course_name")]
    [StringLength(255)]
    public string CourseName { get; set; } = null!;

    [Column("number_sessions")]
    public int NumberSessions { get; set; }

    [Column("tuition", TypeName = "decimal(12, 3)")]
    public decimal Tuition { get; set; }

    [Column("level")]
    [StringLength(5)]
    [Unicode(false)]
    public string Level { get; set; } = null!;

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Courses")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
