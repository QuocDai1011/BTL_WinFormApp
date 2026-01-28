using System.ComponentModel;

namespace BaiTapLonWinForm.DTOs
{
    public class CourseClassDto
    {
        public int ClassID { get; set; }

        [DisplayName("Tên lớp")]
        public string ClassName { get; set; } = null!;

        [DisplayName("Sỉ số hiện tại")]
        public int? CurrentStudent { get; set; }

        [DisplayName("Sỉ số tối đa")]
        public int? MaxStudent { get; set; }

        [DisplayName("Ngày bắt đầu")]
        public DateOnly StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        public DateOnly EndDate { get; set; }

        [DisplayName("Ngày học")]
        public string? SchoolDay { get; set; }

        [DisplayName("Ca học")]
        public byte Shift { get; set; }

        [DisplayName("Trạng thái")]
        public string? Status { get; set; }

        [DisplayName("Giảng viên")]
        public string TeacherName { get; set; } = null!;

        [DisplayName("Mua khóa học")]
        public string? Tuition { get; set; }
    }
}
