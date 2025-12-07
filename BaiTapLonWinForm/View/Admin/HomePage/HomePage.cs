
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.View.Admin.Class;
using BaiTapLonWinForm.View.Admin.Students;
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
    public partial class HomePage : Form
    {
        private Panel currentActivePanel;
        private readonly Color hoverColor = Color.FromArgb(52, 152, 219);
        private readonly Color normalColor = Color.Transparent;
        private readonly Color activeColor = Color.FromArgb(52, 152, 219);
        private readonly ServiceHub _serviceHub; 
        public HomePage(ServiceHub serviceHub)
        {
            InitializeComponent();
            InitializeMenuEvents();
            currentActivePanel = pnlDashboard;

            // Load dashboard by default
            _serviceHub = serviceHub;
            LoadUserControl(new DashBoard(_serviceHub));
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
            SetupMenuItem(pnlLogout, picLogout, lblLogout);
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
            LoadUserControl(new TeacherManagementControl());
        }

        private void Courses_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlCourse);
            LoadUserControl(new CourseManagementControl());
        }

        private void Management_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlManagement);
            LoadUserControl(new GeneralManagementControl());
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnlSettings);
            LoadUserControl(new SettingsControl());
        }

        private void Attendance_Click(object sender, EventArgs e)
        {
            SetActiveMenuItem(pnAttendance);
            LoadUserControl(new FaceAttendance(_serviceHub));
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //Perform logout
                 this.Hide();
                //LoginForm loginForm = new LoginForm();
                //loginForm.ShowDialog();
                this.Close();

                MessageBox.Show("Đăng xuất thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
    }

    #region Sample User Controls (Replace with your actual controls)

    public class ClassManagementControl : UserControl
    {
        public ClassManagementControl()
        {
            var label = new Label
            {
                Text = "QUẢN LÝ LỚP HỌC",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            BackColor = Color.White;
        }
    }

    public class StudentManagementControl : UserControl
    {
        public StudentManagementControl()
        {
            var label = new Label
            {
                Text = "QUẢN LÝ HỌC SINH",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            BackColor = Color.White;
        }
    }

    public class TeacherManagementControl : UserControl
    {
        public TeacherManagementControl()
        {
            var label = new Label
            {
                Text = "QUẢN LÝ GIÁO VIÊN",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            BackColor = Color.White;
        }
    }

    public class CourseManagementControl : UserControl
    {
        public CourseManagementControl()
        {
            var label = new Label
            {
                Text = "QUẢN LÝ KHÓA HỌC",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            BackColor = Color.White;
        }
    }

    public class GeneralManagementControl : UserControl
    {
        public GeneralManagementControl()
        {
            var label = new Label
            {
                Text = "QUẢN LÝ CHUNG",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            BackColor = Color.White;
        }
    }

    public class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            var label = new Label
            {
                Text = "CÀI ĐẶT HỆ THỐNG",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(label);
            BackColor = Color.White;
        }
    }

    #endregion
}
