using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class TeacherAttendance
{
    public long AttendanceId { get; set; }

    public int TeacherId { get; set; }

    public int SessionId { get; set; }

    public DateTime? CheckInTime { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public virtual ClassSession Session { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
