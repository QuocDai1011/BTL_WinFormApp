using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class Attendance
{
    public long AttendanceId { get; set; }

    public int StudentId { get; set; }

    public int SessionId { get; set; }

    public bool IsPresent { get; set; }

    public DateTime? CheckInTime { get; set; }

    public string? Note { get; set; }
}
