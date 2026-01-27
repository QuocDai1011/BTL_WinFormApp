namespace BaiTapLonWinForm.DTOs
{
    public class ScheduleDto
    {
        public int? ClassId { get; set; }
        public string? Course { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Shift { get; set; }
        public List<int>? SchoolDays { get; set; }
        public string? TeacherName { get; set; }
    }
}
