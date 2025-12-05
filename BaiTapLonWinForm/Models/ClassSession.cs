using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class ClassSession
{
    public int SessionId { get; set; }

    public int ClassId { get; set; }

    public DateOnly SessionDate { get; set; }

    public int SessionNumber { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Class Class { get; set; } = null!;
}
