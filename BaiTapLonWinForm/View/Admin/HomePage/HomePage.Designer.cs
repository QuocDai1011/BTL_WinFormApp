

namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;

        // Main Panels
        private Panel sidebarPanel;
        private Panel headerPanel;

        // Header Components
        private PictureBox logoBox;
        private Label lblTitle;
        private Label lblUserName;
        private PictureBox picUserAvatar;
        private Panel pnlHeaderRight;

        // Sidebar Menu Items
        private Panel pnlDashboard;
        private PictureBox picDashboard;
        private Label lblDashboard;

        private Panel pnlMyClass;
        private PictureBox picMyClass;
        private Label lblMyClass;

        private Panel pnlStudentList;
        private PictureBox picStudentList;
        private Label lblStudentList;

        private Panel pnlTeacherList;
        private PictureBox picTeacherList;
        private Label lblTeacherList;

        private Panel pnlCourse;
        private PictureBox picCourse;
        private Label lblCourse;

        private Panel pnlManagement;
        private PictureBox picManagement;
        private Label lblManagement;

        private Panel pnlSettings;
        private PictureBox picSettings;
        private Label lblSettings;

        private Panel pnlLogout;
        private PictureBox picLogout;
        private Label lblLogout;

        // Sidebar Footer
        private Panel pnlSidebarFooter;
        private Label lblVersion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            pnlSchedule = new Panel();
            pbSchedule = new PictureBox();
            lblSchedule = new Label();
            pnAttendance = new Panel();
            pbAttendance = new PictureBox();
            lblAttendance = new Label();
            pnlSidebarFooter = new Panel();
            lblVersion = new Label();
            pnlLogout = new Panel();
            picLogout = new PictureBox();
            lblLogout = new Label();
            pnlSettings = new Panel();
            picSettings = new PictureBox();
            lblSettings = new Label();
            pnlManagement = new Panel();
            picManagement = new PictureBox();
            lblManagement = new Label();
            pnlCourse = new Panel();
            picCourse = new PictureBox();
            lblCourse = new Label();
            pnlTeacherList = new Panel();
            picTeacherList = new PictureBox();
            lblTeacherList = new Label();
            pnlStudentList = new Panel();
            picStudentList = new PictureBox();
            lblStudentList = new Label();
            pnlMyClass = new Panel();
            picMyClass = new PictureBox();
            lblMyClass = new Label();
            pnlDashboard = new Panel();
            picDashboard = new PictureBox();
            lblDashboard = new Label();
            headerPanel = new Panel();
            pnlHeaderRight = new Panel();
            picUserAvatar = new PictureBox();
            lblUserName = new Label();
            lblTitle = new Label();
            logoBox = new PictureBox();
            contentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            pnlSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSchedule).BeginInit();
            pnAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAttendance).BeginInit();
            pnlSidebarFooter.SuspendLayout();
            pnlLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogout).BeginInit();
            pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSettings).BeginInit();
            pnlManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picManagement).BeginInit();
            pnlCourse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCourse).BeginInit();
            pnlTeacherList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTeacherList).BeginInit();
            pnlStudentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picStudentList).BeginInit();
            pnlMyClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyClass).BeginInit();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).BeginInit();
            headerPanel.SuspendLayout();
            pnlHeaderRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(41, 128, 185);
            sidebarPanel.Controls.Add(pnlSchedule);
            sidebarPanel.Controls.Add(pnAttendance);
            sidebarPanel.Controls.Add(pnlSidebarFooter);
            sidebarPanel.Controls.Add(pnlLogout);
            sidebarPanel.Controls.Add(pnlSettings);
            sidebarPanel.Controls.Add(pnlManagement);
            sidebarPanel.Controls.Add(pnlCourse);
            sidebarPanel.Controls.Add(pnlTeacherList);
            sidebarPanel.Controls.Add(pnlStudentList);
            sidebarPanel.Controls.Add(pnlMyClass);
            sidebarPanel.Controls.Add(pnlDashboard);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 100);
            sidebarPanel.Margin = new Padding(4);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(350, 903);
            sidebarPanel.TabIndex = 0;
            // 
            // pnlSchedule
            // 
            pnlSchedule.BackColor = Color.Transparent;
            pnlSchedule.Controls.Add(pbSchedule);
            pnlSchedule.Controls.Add(lblSchedule);
            pnlSchedule.Cursor = Cursors.Hand;
            pnlSchedule.Location = new Point(13, 619);
            pnlSchedule.Margin = new Padding(4);
            pnlSchedule.Name = "pnlSchedule";
            pnlSchedule.Size = new Size(312, 69);
            pnlSchedule.TabIndex = 10;
            pnlSchedule.Click += Schedule_Click;
            // 
            // pbSchedule
            // 
            pbSchedule.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            pbSchedule.Location = new Point(25, 15);
            pbSchedule.Margin = new Padding(4);
            pbSchedule.Name = "pbSchedule";
            pbSchedule.Size = new Size(40, 40);
            pbSchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pbSchedule.TabIndex = 0;
            pbSchedule.TabStop = false;
            pbSchedule.Click += Schedule_Click;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblSchedule.ForeColor = Color.White;
            lblSchedule.Location = new Point(81, 21);
            lblSchedule.Margin = new Padding(4, 0, 4, 0);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(139, 25);
            lblSchedule.TabIndex = 1;
            lblSchedule.Text = "Thời khóa biểu";
            lblSchedule.Click += Schedule_Click;
            // 
            // pnAttendance
            // 
            pnAttendance.BackColor = Color.Transparent;
            pnAttendance.Controls.Add(pbAttendance);
            pnAttendance.Controls.Add(lblAttendance);
            pnAttendance.Cursor = Cursors.Hand;
            pnAttendance.Location = new Point(19, 549);
            pnAttendance.Margin = new Padding(4);
            pnAttendance.Name = "pnAttendance";
            pnAttendance.Size = new Size(312, 69);
            pnAttendance.TabIndex = 9;
            pnAttendance.Click += Attendance_Click;
            // 
            // pbAttendance
            // 
            pbAttendance.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            pbAttendance.Location = new Point(25, 15);
            pbAttendance.Margin = new Padding(4);
            pbAttendance.Name = "pbAttendance";
            pbAttendance.Size = new Size(40, 40);
            pbAttendance.SizeMode = PictureBoxSizeMode.Zoom;
            pbAttendance.TabIndex = 0;
            pbAttendance.TabStop = false;
            pbAttendance.Click += Attendance_Click;
            // 
            // lblAttendance
            // 
            lblAttendance.AutoSize = true;
            lblAttendance.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblAttendance.ForeColor = Color.White;
            lblAttendance.Location = new Point(81, 21);
            lblAttendance.Margin = new Padding(4, 0, 4, 0);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(106, 25);
            lblAttendance.TabIndex = 1;
            lblAttendance.Text = "Điểm danh";
            lblAttendance.Click += Attendance_Click;
            // 
            // pnlSidebarFooter
            // 
            pnlSidebarFooter.BackColor = Color.FromArgb(52, 73, 94);
            pnlSidebarFooter.Controls.Add(lblVersion);
            pnlSidebarFooter.Dock = DockStyle.Bottom;
            pnlSidebarFooter.Location = new Point(0, 841);
            pnlSidebarFooter.Margin = new Padding(4);
            pnlSidebarFooter.Name = "pnlSidebarFooter";
            pnlSidebarFooter.Size = new Size(350, 62);
            pnlSidebarFooter.TabIndex = 8;
            // 
            // lblVersion
            // 
            lblVersion.Dock = DockStyle.Fill;
            lblVersion.Font = new Font("Segoe UI", 9F);
            lblVersion.ForeColor = Color.FromArgb(189, 195, 199);
            lblVersion.Location = new Point(0, 0);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(350, 62);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Version 1.0.0\r\n© 2024 Tre Xanh";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLogout
            // 
            pnlLogout.BackColor = Color.Transparent;
            pnlLogout.Controls.Add(picLogout);
            pnlLogout.Controls.Add(lblLogout);
            pnlLogout.Cursor = Cursors.Hand;
            pnlLogout.Location = new Point(19, 768);
            pnlLogout.Margin = new Padding(4);
            pnlLogout.Name = "pnlLogout";
            pnlLogout.Size = new Size(312, 69);
            pnlLogout.TabIndex = 7;
            pnlLogout.Click += Logout_Click;
            pnlLogout.MouseEnter += MenuItem_MouseEnter;
            pnlLogout.MouseLeave += MenuItem_MouseLeave;
            // 
            // picLogout
            // 
            picLogout.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picLogout.Location = new Point(25, 15);
            picLogout.Margin = new Padding(4);
            picLogout.Name = "picLogout";
            picLogout.Size = new Size(40, 40);
            picLogout.SizeMode = PictureBoxSizeMode.Zoom;
            picLogout.TabIndex = 0;
            picLogout.TabStop = false;
            picLogout.Click += Logout_Click;
            picLogout.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblLogout
            // 
            lblLogout.AutoSize = true;
            lblLogout.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblLogout.ForeColor = Color.White;
            lblLogout.Location = new Point(81, 21);
            lblLogout.Margin = new Padding(4, 0, 4, 0);
            lblLogout.Name = "lblLogout";
            lblLogout.Size = new Size(101, 25);
            lblLogout.TabIndex = 1;
            lblLogout.Text = "Đăng xuất";
            lblLogout.Click += Logout_Click;
            lblLogout.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlSettings
            // 
            pnlSettings.BackColor = Color.Transparent;
            pnlSettings.Controls.Add(picSettings);
            pnlSettings.Controls.Add(lblSettings);
            pnlSettings.Cursor = Cursors.Hand;
            pnlSettings.Location = new Point(19, 681);
            pnlSettings.Margin = new Padding(4);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(312, 69);
            pnlSettings.TabIndex = 6;
            pnlSettings.Click += Settings_Click;
            pnlSettings.MouseEnter += MenuItem_MouseEnter;
            pnlSettings.MouseLeave += MenuItem_MouseLeave;
            // 
            // picSettings
            // 
            picSettings.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picSettings.Location = new Point(25, 15);
            picSettings.Margin = new Padding(4);
            picSettings.Name = "picSettings";
            picSettings.Size = new Size(40, 40);
            picSettings.SizeMode = PictureBoxSizeMode.Zoom;
            picSettings.TabIndex = 0;
            picSettings.TabStop = false;
            picSettings.Click += Settings_Click;
            picSettings.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblSettings.ForeColor = Color.White;
            lblSettings.Location = new Point(81, 21);
            lblSettings.Margin = new Padding(4, 0, 4, 0);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(73, 25);
            lblSettings.TabIndex = 1;
            lblSettings.Text = "Cài đặt";
            lblSettings.Click += Settings_Click;
            lblSettings.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlManagement
            // 
            pnlManagement.BackColor = Color.Transparent;
            pnlManagement.Controls.Add(picManagement);
            pnlManagement.Controls.Add(lblManagement);
            pnlManagement.Cursor = Cursors.Hand;
            pnlManagement.Location = new Point(19, 462);
            pnlManagement.Margin = new Padding(4);
            pnlManagement.Name = "pnlManagement";
            pnlManagement.Size = new Size(312, 69);
            pnlManagement.TabIndex = 5;
            pnlManagement.Click += Management_Click;
            pnlManagement.MouseEnter += MenuItem_MouseEnter;
            pnlManagement.MouseLeave += MenuItem_MouseLeave;
            // 
            // picManagement
            // 
            picManagement.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picManagement.Location = new Point(25, 15);
            picManagement.Margin = new Padding(4);
            picManagement.Name = "picManagement";
            picManagement.Size = new Size(40, 40);
            picManagement.SizeMode = PictureBoxSizeMode.Zoom;
            picManagement.TabIndex = 0;
            picManagement.TabStop = false;
            picManagement.Click += Management_Click;
            picManagement.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblManagement
            // 
            lblManagement.AutoSize = true;
            lblManagement.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblManagement.ForeColor = Color.White;
            lblManagement.Location = new Point(81, 21);
            lblManagement.Margin = new Padding(4, 0, 4, 0);
            lblManagement.Name = "lblManagement";
            lblManagement.Size = new Size(109, 25);
            lblManagement.TabIndex = 1;
            lblManagement.Text = "Chấm công";
            lblManagement.Click += Management_Click;
            lblManagement.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlCourse
            // 
            pnlCourse.BackColor = Color.Transparent;
            pnlCourse.Controls.Add(picCourse);
            pnlCourse.Controls.Add(lblCourse);
            pnlCourse.Cursor = Cursors.Hand;
            pnlCourse.Location = new Point(19, 375);
            pnlCourse.Margin = new Padding(4);
            pnlCourse.Name = "pnlCourse";
            pnlCourse.Size = new Size(312, 69);
            pnlCourse.TabIndex = 4;
            pnlCourse.Click += Courses_Click;
            pnlCourse.MouseEnter += MenuItem_MouseEnter;
            pnlCourse.MouseLeave += MenuItem_MouseLeave;
            // 
            // picCourse
            // 
            picCourse.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picCourse.Location = new Point(25, 15);
            picCourse.Margin = new Padding(4);
            picCourse.Name = "picCourse";
            picCourse.Size = new Size(40, 40);
            picCourse.SizeMode = PictureBoxSizeMode.Zoom;
            picCourse.TabIndex = 0;
            picCourse.TabStop = false;
            picCourse.Click += Courses_Click;
            picCourse.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCourse.ForeColor = Color.White;
            lblCourse.Location = new Point(81, 21);
            lblCourse.Margin = new Padding(4, 0, 4, 0);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(92, 25);
            lblCourse.TabIndex = 1;
            lblCourse.Text = "Khóa học";
            lblCourse.Click += Courses_Click;
            lblCourse.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlTeacherList
            // 
            pnlTeacherList.BackColor = Color.Transparent;
            pnlTeacherList.Controls.Add(picTeacherList);
            pnlTeacherList.Controls.Add(lblTeacherList);
            pnlTeacherList.Cursor = Cursors.Hand;
            pnlTeacherList.Location = new Point(19, 288);
            pnlTeacherList.Margin = new Padding(4);
            pnlTeacherList.Name = "pnlTeacherList";
            pnlTeacherList.Size = new Size(312, 69);
            pnlTeacherList.TabIndex = 3;
            pnlTeacherList.Click += TeacherList_Click;
            pnlTeacherList.MouseEnter += MenuItem_MouseEnter;
            pnlTeacherList.MouseLeave += MenuItem_MouseLeave;
            // 
            // picTeacherList
            // 
            picTeacherList.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picTeacherList.Location = new Point(25, 15);
            picTeacherList.Margin = new Padding(4);
            picTeacherList.Name = "picTeacherList";
            picTeacherList.Size = new Size(40, 40);
            picTeacherList.SizeMode = PictureBoxSizeMode.Zoom;
            picTeacherList.TabIndex = 0;
            picTeacherList.TabStop = false;
            picTeacherList.Click += TeacherList_Click;
            picTeacherList.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblTeacherList
            // 
            lblTeacherList.AutoSize = true;
            lblTeacherList.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTeacherList.ForeColor = Color.White;
            lblTeacherList.Location = new Point(81, 21);
            lblTeacherList.Margin = new Padding(4, 0, 4, 0);
            lblTeacherList.Name = "lblTeacherList";
            lblTeacherList.Size = new Size(103, 25);
            lblTeacherList.TabIndex = 1;
            lblTeacherList.Text = "Giảng viên";
            lblTeacherList.Click += TeacherList_Click;
            lblTeacherList.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlStudentList
            // 
            pnlStudentList.BackColor = Color.Transparent;
            pnlStudentList.Controls.Add(picStudentList);
            pnlStudentList.Controls.Add(lblStudentList);
            pnlStudentList.Cursor = Cursors.Hand;
            pnlStudentList.Location = new Point(19, 200);
            pnlStudentList.Margin = new Padding(4);
            pnlStudentList.Name = "pnlStudentList";
            pnlStudentList.Size = new Size(312, 69);
            pnlStudentList.TabIndex = 2;
            pnlStudentList.Click += StudentList_Click;
            pnlStudentList.MouseEnter += MenuItem_MouseEnter;
            pnlStudentList.MouseLeave += MenuItem_MouseLeave;
            // 
            // picStudentList
            // 
            picStudentList.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picStudentList.Location = new Point(25, 15);
            picStudentList.Margin = new Padding(4);
            picStudentList.Name = "picStudentList";
            picStudentList.Size = new Size(40, 40);
            picStudentList.SizeMode = PictureBoxSizeMode.Zoom;
            picStudentList.TabIndex = 0;
            picStudentList.TabStop = false;
            picStudentList.Click += StudentList_Click;
            picStudentList.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblStudentList
            // 
            lblStudentList.AutoSize = true;
            lblStudentList.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblStudentList.ForeColor = Color.White;
            lblStudentList.Location = new Point(81, 21);
            lblStudentList.Margin = new Padding(4, 0, 4, 0);
            lblStudentList.Name = "lblStudentList";
            lblStudentList.Size = new Size(87, 25);
            lblStudentList.TabIndex = 1;
            lblStudentList.Text = "Học viên";
            lblStudentList.Click += StudentList_Click;
            lblStudentList.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlMyClass
            // 
            pnlMyClass.BackColor = Color.Transparent;
            pnlMyClass.Controls.Add(picMyClass);
            pnlMyClass.Controls.Add(lblMyClass);
            pnlMyClass.Cursor = Cursors.Hand;
            pnlMyClass.Location = new Point(19, 112);
            pnlMyClass.Margin = new Padding(4);
            pnlMyClass.Name = "pnlMyClass";
            pnlMyClass.Size = new Size(312, 69);
            pnlMyClass.TabIndex = 1;
            pnlMyClass.Click += MyClass_Click;
            pnlMyClass.MouseEnter += MenuItem_MouseEnter;
            pnlMyClass.MouseLeave += MenuItem_MouseLeave;
            // 
            // picMyClass
            // 
            picMyClass.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picMyClass.Location = new Point(25, 15);
            picMyClass.Margin = new Padding(4);
            picMyClass.Name = "picMyClass";
            picMyClass.Size = new Size(40, 40);
            picMyClass.SizeMode = PictureBoxSizeMode.Zoom;
            picMyClass.TabIndex = 0;
            picMyClass.TabStop = false;
            picMyClass.Click += MyClass_Click;
            picMyClass.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblMyClass
            // 
            lblMyClass.AutoSize = true;
            lblMyClass.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblMyClass.ForeColor = Color.White;
            lblMyClass.Location = new Point(81, 21);
            lblMyClass.Margin = new Padding(4, 0, 4, 0);
            lblMyClass.Name = "lblMyClass";
            lblMyClass.Size = new Size(80, 25);
            lblMyClass.TabIndex = 1;
            lblMyClass.Text = "Lớp học";
            lblMyClass.Click += MyClass_Click;
            lblMyClass.MouseEnter += MenuItem_MouseEnter;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(52, 152, 219);
            pnlDashboard.Controls.Add(picDashboard);
            pnlDashboard.Controls.Add(lblDashboard);
            pnlDashboard.Cursor = Cursors.Hand;
            pnlDashboard.Location = new Point(19, 25);
            pnlDashboard.Margin = new Padding(4);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(312, 69);
            pnlDashboard.TabIndex = 0;
            pnlDashboard.Click += Dashboard_Click;
            pnlDashboard.MouseEnter += MenuItem_MouseEnter;
            pnlDashboard.MouseLeave += MenuItem_MouseLeave;
            // 
            // picDashboard
            // 
            picDashboard.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picDashboard.Location = new Point(25, 15);
            picDashboard.Margin = new Padding(4);
            picDashboard.Name = "picDashboard";
            picDashboard.Size = new Size(40, 40);
            picDashboard.SizeMode = PictureBoxSizeMode.Zoom;
            picDashboard.TabIndex = 0;
            picDashboard.TabStop = false;
            picDashboard.Click += Dashboard_Click;
            picDashboard.MouseEnter += MenuItem_MouseEnter;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.White;
            lblDashboard.Location = new Point(81, 21);
            lblDashboard.Margin = new Padding(4, 0, 4, 0);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(103, 25);
            lblDashboard.TabIndex = 1;
            lblDashboard.Text = "Tổng quan";
            lblDashboard.Click += Dashboard_Click;
            lblDashboard.MouseEnter += MenuItem_MouseEnter;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.BorderStyle = BorderStyle.FixedSingle;
            headerPanel.Controls.Add(pnlHeaderRight);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(logoBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1882, 100);
            headerPanel.TabIndex = 1;
            // 
            // pnlHeaderRight
            // 
            pnlHeaderRight.Controls.Add(picUserAvatar);
            pnlHeaderRight.Controls.Add(lblUserName);
            pnlHeaderRight.Cursor = Cursors.Hand;
            pnlHeaderRight.Dock = DockStyle.Right;
            pnlHeaderRight.Location = new Point(1570, 0);
            pnlHeaderRight.Margin = new Padding(4);
            pnlHeaderRight.Name = "pnlHeaderRight";
            pnlHeaderRight.Size = new Size(310, 98);
            pnlHeaderRight.TabIndex = 2;
            // 
            // picUserAvatar
            // 
            picUserAvatar.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picUserAvatar.Location = new Point(188, 19);
            picUserAvatar.Margin = new Padding(4);
            picUserAvatar.Name = "picUserAvatar";
            picUserAvatar.Size = new Size(62, 62);
            picUserAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picUserAvatar.TabIndex = 1;
            picUserAvatar.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(52, 73, 94);
            lblUserName.Location = new Point(38, 38);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(112, 25);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Admin User";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(150, 28);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(657, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM TRE XANH";
            // 
            // logoBox
            // 
            logoBox.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            logoBox.Location = new Point(25, 12);
            logoBox.Margin = new Padding(4);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(100, 75);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(236, 240, 241);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(350, 100);
            contentPanel.Margin = new Padding(4);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(38);
            contentPanel.Size = new Size(1532, 903);
            contentPanel.TabIndex = 2;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1882, 1003);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(4);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trung Tâm Anh Ngữ Tre Xanh - Quản Lý";
            sidebarPanel.ResumeLayout(false);
            pnlSchedule.ResumeLayout(false);
            pnlSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSchedule).EndInit();
            pnAttendance.ResumeLayout(false);
            pnAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAttendance).EndInit();
            pnlSidebarFooter.ResumeLayout(false);
            pnlLogout.ResumeLayout(false);
            pnlLogout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogout).EndInit();
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSettings).EndInit();
            pnlManagement.ResumeLayout(false);
            pnlManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picManagement).EndInit();
            pnlCourse.ResumeLayout(false);
            pnlCourse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCourse).EndInit();
            pnlTeacherList.ResumeLayout(false);
            pnlTeacherList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTeacherList).EndInit();
            pnlStudentList.ResumeLayout(false);
            pnlStudentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picStudentList).EndInit();
            pnlMyClass.ResumeLayout(false);
            pnlMyClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyClass).EndInit();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            pnlHeaderRight.ResumeLayout(false);
            pnlHeaderRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }
        private Panel contentPanel;
        private Panel pnAttendance;
        private PictureBox pbAttendance;
        private Label lblAttendance;
        private Panel pnlSchedule;
        private PictureBox pbSchedule;
        private Label lblSchedule;
    }
}
