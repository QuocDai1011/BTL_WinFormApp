using BaiTapLonWinForm.Models;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Course
{
    public partial class CourseCard : UserControl
    {
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler<Models.Course> OnCardClicked;
        private Models.Course course;

        // Lưu màu chủ đạo để dùng cho hiệu ứng hover
        private Color _themeColor = Color.FromArgb(46, 204, 113);
        private Color _hoverBackColor;

        public CourseCard()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

            this.Click += (s, e) => InvokeCardClick();

            // Gán cho Panel chính (quan trọng nhất)
            cardPanel.Click += (s, e) => InvokeCardClick();

            // Gán sự kiện Hover cho Main Panel và các control con (trừ buttons)
            // Để đảm bảo khi di chuột vào label/panel con thì card vẫn giữ trạng thái hover
            this.AttachHoverEvents(this);
            this.AttachHoverEvents(cardPanel);
            foreach (Control c in cardPanel.Controls)
            {
                if (!(c is Guna2Button))
                    this.AttachHoverEvents(c);
                    c.Click += (s, e) => InvokeCardClick();
            }
        }

        private void InvokeCardClick()
        {
            // Kiểm tra xem course có null không và bắn sự kiện ra ngoài
            if (course != null)
            {
                OnCardClicked?.Invoke(this, course);
            }
        }

        private void AttachHoverEvents(Control control)
        {
            control.MouseEnter += (s, e) => OnHoverEnter();
            control.MouseLeave += (s, e) => OnHoverLeave();
        }

        private void OnHoverEnter()
        {
            // HIỆU ỨNG MỀM DẺO: 
            // 1. Đổi màu nền sang màu nhạt của theme (Tint)
            cardPanel.FillColor = _hoverBackColor;

            // 2. Đổi màu bóng đổ sang màu theme nhưng trong suốt hơn
            cardPanel.ShadowColor = Color.FromArgb(100, _themeColor);
            cardPanel.ShadowDepth = 80; // Tăng độ sâu bóng một chút

            this.Cursor = Cursors.Hand;
        }

        private void OnHoverLeave()
        {
            // Trả về mặc định
            cardPanel.FillColor = Color.White;
            cardPanel.ShadowColor = Color.Black;
            cardPanel.ShadowDepth = 40;

            this.Cursor = Cursors.Default;
        }

        public void SetCourseData(Models.Course courseData)
        {
            course = courseData;

            // Bind Data
            lblCourseCode.Text = $"#{course.CourseCode}";
            lblCourseName.Text = course.CourseName;
            lblSessions.Text = $"{course.NumberSessions} buổi";
            lblPrice.Text = $"{course.Tuition:N0} đ";

            // Setup Color Theme
            ConfigureLevelStyle(course.Level);
        }

        private void ConfigureLevelStyle(string level)
        {
            badgeLevel.Text = level;

            Color bgLevel, foreLevel;

            switch (level?.ToLower())
            {
                case "beginner":
                case "a1":
                case "starters":
                    _themeColor = Color.FromArgb(46, 204, 113); // Green
                    break;

                case "intermediate":
                case "a2":
                case "movers":
                case "flyers":
                    _themeColor = Color.FromArgb(52, 152, 219); // Blue
                    break;

                case "advanced":
                case "b1":
                case "b2":
                case "ielts":
                    _themeColor = Color.FromArgb(231, 76, 60); // Red
                    break;

                default:
                    _themeColor = Color.Gray;
                    break;
            }

            // Tính toán màu nền nhạt (Tint 90%) cho hiệu ứng Hover
            _hoverBackColor = ControlPaint.Light(_themeColor, 1.8f);
            // Lưu ý: Nếu màu quá sáng, ControlPaint.Light có thể trả về trắng, nên dùng công thức pha màu thủ công nếu cần.
            // Ở đây dùng Color.FromArgb(15, _themeColor) đè lên trắng là đẹp nhất, nhưng set FillColor trực tiếp an toàn hơn.
            _hoverBackColor = Color.FromArgb(245, 250, 255); // Mặc định màu xanh nhạt rất nhẹ
            if (_themeColor.R > 200) _hoverBackColor = Color.FromArgb(255, 245, 245); // Nếu theme đỏ -> nền hồng nhạt

            // Apply màu

            // Apply màu cho Giá tiền
            lblPrice.ForeColor = _themeColor;

            // Apply màu cho Badge Level
            badgeLevel.FillColor = Color.FromArgb(30, _themeColor); // Nền badge trong suốt 30%
            badgeLevel.ForeColor = _themeColor;
        }
    }
}