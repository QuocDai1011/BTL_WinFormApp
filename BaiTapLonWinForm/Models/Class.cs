using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("class")]
public partial class Class
{
    [Key]
    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("class_name")]
    public string ClassName { get; set; } = null!;

    [Column("current_student")]
    public int? CurrentStudent { get; set; }

    [Column("max_student")]
    public int? MaxStudent { get; set; }

    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly EndDate { get; set; }

    [Column("shift")]
    public byte Shift { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("online_meeting_link")]
    [StringLength(255)]
    [Unicode(false)]
    public string? OnlineMeetingLink { get; set; }

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    [ForeignKey("TeacherId")]
    [InverseProperty("Classes")]
    public virtual Teacher Teacher { get; set; } = null!;

    [ForeignKey("ClassId")]
    [InverseProperty("Classes")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("ClassId")]
    [InverseProperty("Classes")]
    public virtual ICollection<SchoolDay> SchoolDays { get; set; } = new List<SchoolDay>();
}
