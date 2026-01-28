namespace BaiTapLonWinForm.Models;

public partial class Attendance
{
    public long AttendanceId { get; set; }

    public int StudentId { get; set; }

    public int SessionId { get; set; }

    public bool IsPresent { get; set; }

    public DateTime? CheckInTime { get; set; }

    public string? Note { get; set; }

    public virtual ClassSession Session { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
