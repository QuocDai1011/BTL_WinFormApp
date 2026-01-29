

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
            pnlAttendance = new Panel();
            pbAttendance = new PictureBox();
            lblAttendance = new Label();
            pnlSidebarFooter = new Panel();
            lblVersion = new Label();
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
            pnlAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAttendance).BeginInit();
            pnlSidebarFooter.SuspendLayout();
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
            sidebarPanel.Controls.Add(pnlAttendance);
            sidebarPanel.Controls.Add(pnlSidebarFooter);
            sidebarPanel.Controls.Add(pnlSettings);
            sidebarPanel.Controls.Add(pnlManagement);
            sidebarPanel.Controls.Add(pnlCourse);
            sidebarPanel.Controls.Add(pnlTeacherList);
            sidebarPanel.Controls.Add(pnlStudentList);
            sidebarPanel.Controls.Add(pnlMyClass);
            sidebarPanel.Controls.Add(pnlDashboard);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 80);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(280, 811);
            sidebarPanel.TabIndex = 0;
            // 
            // pnlSchedule
            // 
            pnlSchedule.BackColor = Color.Transparent;
            pnlSchedule.Controls.Add(pbSchedule);
            pnlSchedule.Controls.Add(lblSchedule);
            pnlSchedule.Cursor = Cursors.Hand;
            pnlSchedule.Location = new Point(15, 596);
            pnlSchedule.Name = "pnlSchedule";
            pnlSchedule.Size = new Size(250, 55);
            pnlSchedule.TabIndex = 10;
            pnlSchedule.Click += Schedule_Click;
            // 
            // pbSchedule
            // 
            pbSchedule.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            pbSchedule.Location = new Point(20, 12);
            pbSchedule.Name = "pbSchedule";
            pbSchedule.Size = new Size(32, 32);
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
            lblSchedule.Location = new Point(65, 17);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(111, 20);
            lblSchedule.TabIndex = 1;
            lblSchedule.Text = "Thời khóa biểu";
            lblSchedule.Click += Schedule_Click;
            // 
            // pnlAttendance
            // 
            pnlAttendance.BackColor = Color.Transparent;
            pnlAttendance.Controls.Add(pbAttendance);
            pnlAttendance.Controls.Add(lblAttendance);
            pnlAttendance.Cursor = Cursors.Hand;
            pnlAttendance.Location = new Point(15, 449);
            pnlAttendance.Name = "pnlAttendance";
            pnlAttendance.Size = new Size(250, 55);
            pnlAttendance.TabIndex = 9;
            pnlAttendance.Click += Attendance_Click;
            // 
            // pbAttendance
            // 
            pbAttendance.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            pbAttendance.Location = new Point(20, 12);
            pbAttendance.Name = "pbAttendance";
            pbAttendance.Size = new Size(32, 32);
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
            lblAttendance.Location = new Point(65, 17);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(84, 20);
            lblAttendance.TabIndex = 1;
            lblAttendance.Text = "Điểm danh";
            lblAttendance.Click += Attendance_Click;
            // 
            // pnlSidebarFooter
            // 
            pnlSidebarFooter.BackColor = Color.FromArgb(52, 73, 94);
            pnlSidebarFooter.Controls.Add(lblVersion);
            pnlSidebarFooter.Dock = DockStyle.Bottom;
            pnlSidebarFooter.Location = new Point(0, 761);
            pnlSidebarFooter.Name = "pnlSidebarFooter";
            pnlSidebarFooter.Size = new Size(280, 50);
            pnlSidebarFooter.TabIndex = 8;
            // 
            // lblVersion
            // 
            lblVersion.Dock = DockStyle.Fill;
            lblVersion.Font = new Font("Segoe UI", 9F);
            lblVersion.ForeColor = Color.FromArgb(189, 195, 199);
            lblVersion.Location = new Point(0, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(280, 50);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Version 1.0.0\r\n© 2024 Tre Xanh";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSettings
            // 
            pnlSettings.BackColor = Color.Transparent;
            pnlSettings.Controls.Add(picSettings);
            pnlSettings.Controls.Add(lblSettings);
            pnlSettings.Cursor = Cursors.Hand;
            pnlSettings.Location = new Point(15, 680);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(250, 55);
            pnlSettings.TabIndex = 6;
            pnlSettings.Click += Settings_Click;
            pnlSettings.Paint += pnlSettings_Paint;
            pnlSettings.MouseEnter += MenuItem_MouseEnter;
            pnlSettings.MouseLeave += MenuItem_MouseLeave;
            // 
            // picSettings
            // 
            picSettings.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picSettings.Location = new Point(20, 12);
            picSettings.Name = "picSettings";
            picSettings.Size = new Size(32, 32);
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
            lblSettings.Location = new Point(65, 17);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(56, 20);
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
            pnlManagement.Location = new Point(15, 370);
            pnlManagement.Name = "pnlManagement";
            pnlManagement.Size = new Size(250, 55);
            pnlManagement.TabIndex = 5;
            pnlManagement.Click += Management_Click;
            pnlManagement.MouseEnter += MenuItem_MouseEnter;
            pnlManagement.MouseLeave += MenuItem_MouseLeave;
            // 
            // picManagement
            // 
            picManagement.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picManagement.Location = new Point(20, 12);
            picManagement.Name = "picManagement";
            picManagement.Size = new Size(32, 32);
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
            lblManagement.Location = new Point(65, 17);
            lblManagement.Name = "lblManagement";
            lblManagement.Size = new Size(86, 20);
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
            pnlCourse.Location = new Point(15, 300);
            pnlCourse.Name = "pnlCourse";
            pnlCourse.Size = new Size(250, 55);
            pnlCourse.TabIndex = 4;
            pnlCourse.Click += Courses_Click;
            pnlCourse.MouseEnter += MenuItem_MouseEnter;
            pnlCourse.MouseLeave += MenuItem_MouseLeave;
            // 
            // picCourse
            // 
            picCourse.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picCourse.Location = new Point(20, 12);
            picCourse.Name = "picCourse";
            picCourse.Size = new Size(32, 32);
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
            lblCourse.Location = new Point(65, 17);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(73, 20);
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
            pnlTeacherList.Location = new Point(15, 230);
            pnlTeacherList.Name = "pnlTeacherList";
            pnlTeacherList.Size = new Size(250, 55);
            pnlTeacherList.TabIndex = 3;
            pnlTeacherList.Click += TeacherList_Click;
            pnlTeacherList.MouseEnter += MenuItem_MouseEnter;
            pnlTeacherList.MouseLeave += MenuItem_MouseLeave;
            // 
            // picTeacherList
            // 
            picTeacherList.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picTeacherList.Location = new Point(20, 12);
            picTeacherList.Name = "picTeacherList";
            picTeacherList.Size = new Size(32, 32);
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
            lblTeacherList.Location = new Point(65, 17);
            lblTeacherList.Name = "lblTeacherList";
            lblTeacherList.Size = new Size(82, 20);
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
            pnlStudentList.Location = new Point(15, 160);
            pnlStudentList.Name = "pnlStudentList";
            pnlStudentList.Size = new Size(250, 55);
            pnlStudentList.TabIndex = 2;
            pnlStudentList.Click += StudentList_Click;
            pnlStudentList.MouseEnter += MenuItem_MouseEnter;
            pnlStudentList.MouseLeave += MenuItem_MouseLeave;
            // 
            // picStudentList
            // 
            picStudentList.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picStudentList.Location = new Point(20, 12);
            picStudentList.Name = "picStudentList";
            picStudentList.Size = new Size(32, 32);
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
            lblStudentList.Location = new Point(65, 17);
            lblStudentList.Name = "lblStudentList";
            lblStudentList.Size = new Size(69, 20);
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
            pnlMyClass.Location = new Point(15, 90);
            pnlMyClass.Name = "pnlMyClass";
            pnlMyClass.Size = new Size(250, 55);
            pnlMyClass.TabIndex = 1;
            pnlMyClass.Click += MyClass_Click;
            pnlMyClass.Paint += pnlMyClass_Paint;
            pnlMyClass.MouseEnter += MenuItem_MouseEnter;
            pnlMyClass.MouseLeave += MenuItem_MouseLeave;
            // 
            // picMyClass
            // 
            picMyClass.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picMyClass.Location = new Point(20, 12);
            picMyClass.Name = "picMyClass";
            picMyClass.Size = new Size(32, 32);
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
            lblMyClass.Location = new Point(65, 17);
            lblMyClass.Name = "lblMyClass";
            lblMyClass.Size = new Size(63, 20);
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
            pnlDashboard.Location = new Point(15, 20);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(250, 55);
            pnlDashboard.TabIndex = 0;
            pnlDashboard.Click += Dashboard_Click;
            pnlDashboard.Paint += pnlDashboard_Paint;
            pnlDashboard.MouseEnter += MenuItem_MouseEnter;
            pnlDashboard.MouseLeave += MenuItem_MouseLeave;
            // 
            // picDashboard
            // 
            picDashboard.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picDashboard.Location = new Point(20, 12);
            picDashboard.Name = "picDashboard";
            picDashboard.Size = new Size(32, 32);
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
            lblDashboard.Location = new Point(65, 17);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(83, 20);
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
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1184, 80);
            headerPanel.TabIndex = 1;
            // 
            // pnlHeaderRight
            // 
            pnlHeaderRight.Controls.Add(picUserAvatar);
            pnlHeaderRight.Controls.Add(lblUserName);
            pnlHeaderRight.Cursor = Cursors.Hand;
            pnlHeaderRight.Dock = DockStyle.Right;
            pnlHeaderRight.Location = new Point(934, 0);
            pnlHeaderRight.Name = "pnlHeaderRight";
            pnlHeaderRight.Size = new Size(248, 78);
            pnlHeaderRight.TabIndex = 2;
            // 
            // picUserAvatar
            // 
            picUserAvatar.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            picUserAvatar.Location = new Point(150, 15);
            picUserAvatar.Name = "picUserAvatar";
            picUserAvatar.Size = new Size(50, 50);
            picUserAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picUserAvatar.TabIndex = 1;
            picUserAvatar.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(52, 73, 94);
            lblUserName.Location = new Point(30, 30);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(89, 20);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Admin User";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(120, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(526, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ TRUNG TÂM TRE XANH";
            // 
            // logoBox
            // 
            logoBox.Image = BaiTapLonWinForm.Properties.Resources.logo2019_png_1;
            logoBox.Location = new Point(20, 10);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(80, 60);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(236, 240, 241);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(280, 80);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(30, 30, 30, 30);
            contentPanel.Size = new Size(904, 811);
            contentPanel.TabIndex = 2;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1184, 891);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Controls.Add(headerPanel);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trung Tâm Anh Ngữ Tre Xanh - Quản Lý";
            WindowState = FormWindowState.Maximized;
            sidebarPanel.ResumeLayout(false);
            pnlSchedule.ResumeLayout(false);
            pnlSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSchedule).EndInit();
            pnlAttendance.ResumeLayout(false);
            pnlAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAttendance).EndInit();
            pnlSidebarFooter.ResumeLayout(false);
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
        private Panel pnlAttendance;
    }
}
