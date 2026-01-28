
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.View.Admin.Class;
using BaiTapLonWinForm.View.Admin.Course;
using BaiTapLonWinForm.View.Admin.Receipt;
using BaiTapLonWinForm.View.Admin.Schedule;
using BaiTapLonWinForm.View.Admin.Students;
using BaiTapLonWinForm.View.Admin.Teacher;
using BaiTapLonWinForm.View.Setting;
using BaiTapLonWinForm.Views.Admin.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    public partial class HomePage : Form, INavigationHandler
    {
        private Panel currentActivePanel;
        private readonly Color hoverColor = Color.FromArgb(52, 152, 219);
        private readonly Color normalColor = Color.Transparent;
        private readonly Color activeColor = Color.FromArgb(52, 152, 219);

        private readonly ServiceHub _serviceHub;
        private long _userId;
        public HomePage(ServiceHub serviceHub, long userId = 2)
        {
            InitializeComponent();
            InitializeMenuEvents();
            currentActivePanel = pnlDashboard;

            // Load dashboard by default
            _serviceHub = serviceHub;
            _userId = userId;
            LoadUserControl(new DashBoard(_serviceHub));

            this.Load += HomePage_Load;
        }



        #region Menu Item Events Setup
        private void InitializeMenuEvents()
        {
            // Dashboard
            SetupMenuItem(pnlDashboard, picDashboard, lblDashboard);

            // My Class
            SetupMenuItem(pnlMyClass, picMyClass, lblMyClass);

            // Student List
            SetupMenuItem(pnlStudentList, picStudentList, lblStudentList);

            // Teacher List
            SetupMenuItem(pnlTeacherList, picTeacherList, lblTeacherList);

            // Course
            SetupMenuItem(pnlCourse, picCourse, lblCourse);

            // Management
            SetupMenuItem(pnlManagement, picManagement, lblManagement);

            // Settings
            SetupMenuItem(pnlSettings, picSettings, lblSettings);

            // Logout
            SetupMenuItem(pnlSchedule, pbSchedule, lblSchedule);

            // Receipt Management
            SetupMenuItem(pnlReceiptManagement, pbReceipt, lblReceipt);
            //Attendance
            SetupMenuItem(pnlAttendance, pbAttendance, lblAttendance);


        }

        private void SetupMenuItem(Panel panel, PictureBox picture, Label label)
        {
            // Panel events
            panel.MouseEnter += MenuItem_MouseEnter;
            panel.MouseLeave += MenuItem_MouseLeave;

            // PictureBox events
            picture.MouseEnter += MenuItem_MouseEnter;
            picture.MouseLeave += MenuItem_MouseLeave;

            // Label events
            label.MouseEnter += MenuItem_MouseEnter;
            label.MouseLeave += MenuItem_MouseLeave;
        }
        #endregion

        #region Hover Effects
        private void MenuItem_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel parentPanel = GetParentPanel(control);

            if (parentPanel != null && parentPanel != currentActivePanel)
            {
                parentPanel.BackColor = hoverColor;
                Cursor = Cursors.Hand;
            }
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel parentPanel = GetParentPanel(control);

            if (parentPanel != null && parentPanel != currentActivePanel)
            {
                parentPanel.BackColor = normalColor;
                Cursor = Cursors.Default;
            }
        }

        private Panel GetParentPanel(Control control)
        {
            if (control is Panel)
                return control as Panel;

            return control?.Parent as Panel;
        }

        private void SetActiveMenuItem(Panel panel)
        {
            // Reset previous active panel
            if (currentActivePanel != null)
            {
                currentActivePanel.BackColor = normalColor;
            }

            // Set new active panel
            currentActivePanel = panel;
            currentActivePanel.BackColor = activeColor;
        }
        #endregion

        #region Menu Click Events
        private void Dashboard_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlDashboard);
            LoadUserControl(new DashBoard(_serviceHub));
        }

        private void MyClass_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlMyClass);
            LoadUserControl(new ClassManagement(_serviceHub));
        }

        private void StudentList_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlStudentList);
            LoadUserControl(new StudentManagement(_serviceHub));
        }

        private void TeacherList_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlTeacherList);
            LoadUserControl(new TeacherManagement(_serviceHub));
        }

        private void Courses_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlCourse);
            var courseManagement = new CourseManagement(_serviceHub);
            courseManagement.RequestOpenDetail += (s, course) =>
            {
                var detailView = new CourseDetail();
                detailView.LoadData(course);

                detailView.BackRequested += (s2, e2) =>
                {
                    // Load lại danh sách khi bấm Back
                    Courses_Click(null, null);
                };

                // Load Detail View đè lên ContentPanel
                LoadUserControl(detailView);
            };
            LoadUserControl(courseManagement);

        }

        private void Management_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlManagement);
            LoadUserControl(new TeacherAttendanceControl(_serviceHub));
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlSettings);
            LoadUserControl(new Setting(_serviceHub, _userId));
        }

        private void Attendance_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlAttendance);
            LoadUserControl(new FaceAttendance(_serviceHub));
        }

        private void Schedule_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlSchedule);
            LoadUserControl(new WeeklySchedule(_serviceHub));
        }
        private void ReceiptManagement_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlReceiptManagement);
            LoadUserControl(new ReceiptManagement(_serviceHub));
        }

        #endregion

        #region Load User Control
        private void LoadUserControl(UserControl userControl)
        {
            try
            {
                contentPanel.Controls.Clear();
                userControl.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(userControl);
                userControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải giao diện: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load function auto update status in class
        private async void HomePage_Load(object? sender, EventArgs e)
        {
            await updateAutoStatus();
        }
        // update status trong class
        private async Task updateAutoStatus()
        {
            int count = await _serviceHub.ClassService.UpdateClassStatusesAutoAsync();

            if (count > 0)
            {
                MessageHelper.ShowSuccess($"Đã cập nhật trạng thái cho {count} lớp học");
            }
        }

        public void NavigateToClassDetail(int classId)
        {
            SetActiveMenuItem(pnlMyClass);
            LoadUserControl(new ClassDetailControl(_serviceHub, classId));
        }
        #endregion

        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMyClass_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            contentPanel.Controls.Clear();
            var userControl = new ReceiptManagement(_serviceHub);
            userControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(userControl);
        }
    }

}
