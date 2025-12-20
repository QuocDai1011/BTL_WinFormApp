using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWinForm.Models;

[Table("role")]
public partial class Role
{
    [Key]
    [Column("role_id")]
    public byte RoleId { get; set; }

    [Column("role_name")]
    [StringLength(20)]
    [Unicode(false)]
    public string? RoleName { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
