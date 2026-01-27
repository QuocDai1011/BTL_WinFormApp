namespace BaiTapLonWinForm.DTOs
{
    public class ClassDto
    {
        public int ClassId { get; set; }
        public string? CourseName { get; set; }
        public string? ClassName { get; set; }
        public string? Node { get; set; }
        public int Shift { get; set; }
        public List<int>? SchoolDay { get; set; }
        public string? SchoolDayString { get; set; }
        public string? TeacherName { get; set; }
    }
}
