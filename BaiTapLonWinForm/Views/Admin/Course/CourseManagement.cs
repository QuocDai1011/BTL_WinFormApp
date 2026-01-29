using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Course
{
    public partial class CourseManagement : UserControl
    {
        private List<Models.Course> courses;
        private readonly ServiceHub _serviceHub;
        public event EventHandler<Models.Course> RequestOpenDetail;
        public CourseManagement(ServiceHub serviceHub)
        {
            InitializeComponent();
            InitializeEvents();
            _serviceHub = serviceHub;
            this.Load += CourseManagement_Load;
        }

        private async void CourseManagement_Load(object? sender, EventArgs e)
        {
            var result = await _serviceHub.CourseService.GetAllCoursesAsync();
            if (result.Success)
                LoadCourses(result.Data.ToList());
            else
                MessageHelper.ShowError($"Lỗi: {result.Message}");
        }

        private void InitializeEvents()
        {
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnAddCourse.Click += BtnAddCourse_Click;
        }

        #region load data and display
        public void LoadCourses(List<Models.Course> courseList)
        {
            courses = courseList;
            DisplayCourses(courses);
        }

        private void DisplayCourses(List<Models.Course> coursesToDisplay)
        {
            flowLayoutPanelCourses.Controls.Clear();

            flowLayoutPanelCourses.Padding = new Padding(35, 20, 0, 50);

            foreach (var course in coursesToDisplay)
            {
                var cardItem = new CourseCard();
                cardItem.SetCourseData(course);

                cardItem.Margin = new Padding(10, 10, 10, 15);

                // Đăng ký events
                cardItem.EditClicked += (s, e) => OnEditCourse(course);
                cardItem.DeleteClicked += (s, e) => OnDeleteCourse(course);
                cardItem.OnCardClicked += (s, selectedCourse) =>
                {
                    // Bắn sự kiện lên cấp cha (HomePage)
                    RequestOpenDetail?.Invoke(this, selectedCourse);
                };
                flowLayoutPanelCourses.Controls.Add(cardItem);
            }
        }
        #endregion

        #region handle envents
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayCourses(courses);
            }
            else
            {
                var filteredCourses = courses.Where(c =>
                    c.CourseCode.ToLower().Contains(searchText) ||
                    c.CourseName.ToLower().Contains(searchText) ||
                    c.Level.ToLower().Contains(searchText)
                ).ToList();

                DisplayCourses(filteredCourses);
            }
        }

        private void BtnAddCourse_Click(object sender, EventArgs e)
        {
            // Xử lý thêm khóa học mới
            MessageBox.Show("Chức năng thêm khóa học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnEditCourse(Models.Course course)
        {
            // Xử lý chỉnh sửa khóa học
            MessageBox.Show($"Chỉnh sửa khóa học: {course.CourseName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnDeleteCourse(Models.Course course)
        {
            // Xử lý xóa khóa học
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khóa học '{course.CourseName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                courses.Remove(course);
                DisplayCourses(courses);
                MessageBox.Show("Đã xóa khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
