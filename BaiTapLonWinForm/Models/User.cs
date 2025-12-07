using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHashing { get; set; } = null!;

    public bool? Gender { get; set; }

    public string? Address { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte RoleId { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
