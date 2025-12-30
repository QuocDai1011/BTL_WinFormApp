using BaiTapLonWinForm.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace BaiTapLonWinForm.View.Admin.Course
{
    public partial class CourseDetail : UserControl
    {
        public event EventHandler BackRequested;
        private Models.Course _course;

        public CourseDetail()
        {
            InitializeComponent();
            btnBack.Click += (s, e) => BackRequested?.Invoke(this, EventArgs.Empty);
            btnAddClass.Click += BtnAddClass_Click;
        }

        #region load data
        public void LoadData(Models.Course course)
        {
            _course = course;

            lblCourseName.Text = course.CourseName;
            lblCourseCode.Text = $"#{course.CourseCode} | Level: {course.Level}";

            int classCount = course.Classes?.Count ?? 0;
            int totalStudents = course.Classes?.Sum(c => c.CurrentStudent ?? 0) ?? 0;

            UpdateStatCard(cardClasses, classCount.ToString("00"));
            UpdateStatCard(cardStudents, totalStudents.ToString());
            UpdateStatCard(cardTuition, $"{course.Tuition:N0} đ");

            LoadClassGrid();
        }

        private void UpdateStatCard(Guna.UI2.WinForms.Guna2ShadowPanel card, string value)
        {
            foreach (Control c in card.Controls)
            {
                if (c is Label lbl && c.Font.Size > 12) 
                {
                    lbl.Text = value;
                }
            }
        }

        private void LoadClassGrid()
        {
            if (dgvClasses.Columns.Count == 0)
            {
                dgvClasses.Columns.Add("ClassName", "Tên lớp");
                dgvClasses.Columns.Add("Teacher", "Giảng viên");
                dgvClasses.Columns.Add("Schedule", "Lịch học");
                dgvClasses.Columns.Add("Students", "Sĩ số");
                dgvClasses.Columns.Add("Status", "Trạng thái");

                var btnCol = new DataGridViewButtonColumn();
                btnCol.HeaderText = "";
                btnCol.Text = "Xem lớp";
                btnCol.UseColumnTextForButtonValue = true;
                dgvClasses.Columns.Add(btnCol);
            }

            dgvClasses.Rows.Clear();

            if (_course.Classes != null)
            {
                foreach (var c in _course.Classes)
                {
                    string teacherName = c.Teacher != null ? $"{c.Teacher.User.FirstName} {c.Teacher.User.LastName}" : "Chưa gán"; // Giả sử model Teacher có User
                    string status = c.Status == 1 ? "Đang mở" : "Đóng";

                    dgvClasses.Rows.Add(
                        c.ClassName,
                        teacherName,
                        $"{c.StartDate:dd/MM} - {c.EndDate:dd/MM}",
                        $"{c.CurrentStudent}/{c.MaxStudent}",
                        status
                    );
                }
            }
        }
        #endregion

        #region handle events

        private void BtnAddClass_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Thêm lớp học mới cho khóa {_course.CourseCode}");
        }
        #endregion
    }
}