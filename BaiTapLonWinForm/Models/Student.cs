namespace BaiTapLonWinForm.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public long UserId { get; set; }

    public string? PhoneNumberOfParents { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();


    public virtual ICollection<StudentFaceImage> StudentFaceImages { get; set; } = new List<StudentFaceImage>();

    public virtual User User { get; set; } = null!;
}
