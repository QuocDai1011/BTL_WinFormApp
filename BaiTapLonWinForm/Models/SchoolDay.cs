using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class SchoolDay
{
    public byte SchoolDayId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
