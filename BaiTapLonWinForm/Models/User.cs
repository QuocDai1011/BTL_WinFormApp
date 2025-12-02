using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("user")]
[Index("Email", Name = "UQ__user__AB6E6164816B992A", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("first_name")]
    [StringLength(255)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(255)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("password_hashing")]
    [Unicode(false)]
    public string PasswordHashing { get; set; } = null!;

    [Column("gender")]
    public bool? Gender { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("phone_number")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [Column("role_id")]
    public byte RoleId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("User")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
