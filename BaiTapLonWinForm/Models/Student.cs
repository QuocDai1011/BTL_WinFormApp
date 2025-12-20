using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("student")]
public partial class Student
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("phone_number_of_parents")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PhoneNumberOfParents { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    [ForeignKey("UserId")]
    [InverseProperty("Students")]
    public virtual User User { get; set; } = null!;
}
