namespace BaiTapLonWinForm.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public long UserId { get; set; }

    public int? Salary { get; set; }

    public int? ExperienceYear { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    public virtual ICollection<TeacherFaceImage> TeacherFaceImages { get; set; } = new List<TeacherFaceImage>();

    public virtual User User { get; set; } = null!;
}

