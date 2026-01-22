namespace BaiTapLonWinForm.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        public string CourseCode { get; set; } = null!;

        public string CourseName { get; set; } = null!;

        public int NumberSessions { get; set; }

        public decimal Tuition { get; set; }

        public string Level { get; set; } = null!;

        public DateOnly? EndDate { get; set; }
    }
}
