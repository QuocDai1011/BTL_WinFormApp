using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_BuyCourse : UserControl
    {
        private readonly ICourseService _service;
        private readonly int _studentId;
        public UC_BuyCourse(ICourseService service, int studentId)
        {
            _service = service;
            _studentId = studentId;
            InitializeComponent();
            LoadCourse();
        }

        private int CalculateItemGap(int itemCount, int itemWidth)
        {
            int C = renderControl.ClientSize.Width;
            return (C - itemCount * itemWidth) / (itemCount + 1);
        }

        private void LoadCourse()
        {
            var courses = _service.GetAllCourse();

            if (courses == null || courses.Count == 0)
            {
                MessageHelper.ShowError("Không có khóa học", "Lỗi");
                return;
            }

            renderControl.Controls.Clear();

            int itemWidth = 270;
            int n = 4;
            int gap = CalculateItemGap(n, itemWidth);

            int x = gap;

            FlowLayoutPanel flpRender = new FlowLayoutPanel();
            flpRender.AutoScroll = true;
            renderControl.Controls.Add(flpRender);
            flpRender.Dock = DockStyle.Fill;

            foreach (var item in courses)
            {
                var course = new UC_Course();
                course.Width = itemWidth;
                course.LoadCourse(item);
                course.CourseSelected += LoadDetailCourse;


                course.Margin = new Padding(gap, 10, 0, 10);

                flpRender.Controls.Add(course);
            }

            renderControl.ResumeLayout();
        }


        private void LoadDetailCourse(int courseId)
        {
            var detail = new UC_DetailCourse(_service, _studentId, courseId);
            detail.LoadDetailCourse(courseId);

            renderControl.Controls.Clear();
            detail.Dock = DockStyle.Fill;
            renderControl.Controls.Add(detail);
        }
    }
}
