using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public long UserId { get; set; }

    public int? Salary { get; set; }

    public int? ExperienceYear { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual User User { get; set; } = null!;
}
