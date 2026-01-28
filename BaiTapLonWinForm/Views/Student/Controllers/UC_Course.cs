using BaiTapLonWinForm.DTOs;
using System.Globalization;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Course : UserControl
    {
        public event Action<int> CourseSelected;
        private int _courseId;
        public UC_Course()
        {
            InitializeComponent();
        }

        public void LoadCourse(CourseDto data)
        {
            _courseId = data.CourseId;
            lbCourseName.Text = data.CourseName;
            lbEndDate.Text = "Kết thúc: " + data.EndDate?.ToString("dd/MM/yyyy") ?? "----";
            lbLevel.Text = data.Level;

            var culture = new CultureInfo("vi-VN");
            culture.NumberFormat.CurrencySymbol = "VNĐ";
            lbTuition.Text = data.Tuition.ToString("c", culture);

            if (data.EndDate.HasValue)
            {
                var today = DateOnly.FromDateTime(DateTime.Now);

                if (data.EndDate < today)
                {
                    lbEndDate.ForeColor = Color.Red;        // đã kết thúc
                }
                else if (data.EndDate == today)
                {
                    lbEndDate.ForeColor = Color.Orange;     // kết thúc hôm nay
                }
                else
                {
                    lbEndDate.ForeColor = Color.Green;      // còn hạn
                }
            }
            else
            {
                lbEndDate.ForeColor = Color.Gray;           // chưa có ngày
                lbEndDate.Text = "Chưa mở lớp";
            }

        }

        private void pnlContain_Click(object sender, EventArgs e)
        {
            CourseSelected?.Invoke(_courseId);
        }
    }
}
