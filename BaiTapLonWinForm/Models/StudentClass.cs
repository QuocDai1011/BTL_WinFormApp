namespace BaiTapLonWinForm.Models;

public partial class StudentClass
{
    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
