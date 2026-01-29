using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public decimal? Salary { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
