namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    partial class DashBoard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel mainPanel;

        private System.Windows.Forms.Panel cardStudents;
        private System.Windows.Forms.Panel cardClasses;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Panel cardTeachers;

        private FontAwesome.Sharp.IconPictureBox iconStudents;
        private FontAwesome.Sharp.IconPictureBox iconClasses;
        private FontAwesome.Sharp.IconPictureBox iconRevenue;
        private FontAwesome.Sharp.IconPictureBox iconTeachers;

        private System.Windows.Forms.Label lblStudentsValue;
        private System.Windows.Forms.Label lblStudentsTitle;
        private System.Windows.Forms.Label lblStudentsSub;

        private System.Windows.Forms.Label lblClassesValue;
        private System.Windows.Forms.Label lblClassesTitle;
        private System.Windows.Forms.Label lblClassesSub;

        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Label lblRevenueSub;

        private System.Windows.Forms.Label lblTeachersValue;
        private System.Windows.Forms.Label lblTeachersTitle;
        private System.Windows.Forms.Label lblTeachersSub;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            mainPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            cardStudents = new Panel();
            iconStudents = new FontAwesome.Sharp.IconPictureBox();
            lblStudentsValue = new Label();
            lblStudentsTitle = new Label();
            lblStudentsSub = new Label();
            cardRevenue = new Panel();
            iconRevenue = new FontAwesome.Sharp.IconPictureBox();
            lblRevenueValue = new Label();
            lblRevenueTitle = new Label();
            lblRevenueSub = new Label();
            cardTeachers = new Panel();
            iconTeachers = new FontAwesome.Sharp.IconPictureBox();
            lblTeachersValue = new Label();
            lblTeachersTitle = new Label();
            lblTeachersSub = new Label();
            cardClasses = new Panel();
            iconClasses = new FontAwesome.Sharp.IconPictureBox();
            lblClassesValue = new Label();
            lblClassesTitle = new Label();
            lblClassesSub = new Label();
            mainPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            cardStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconStudents).BeginInit();
            cardRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconRevenue).BeginInit();
            cardTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconTeachers).BeginInit();
            cardClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconClasses).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(flowLayoutPanel1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1494, 820);
            mainPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1532, 820);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(cardStudents);
            panel1.Controls.Add(cardRevenue);
            panel1.Controls.Add(cardTeachers);
            panel1.Controls.Add(cardClasses);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1491, 150);
            panel1.TabIndex = 5;
            // 
            // cardStudents
            // 
            cardStudents.BackColor = Color.FromArgb(52, 152, 219);
            cardStudents.Controls.Add(iconStudents);
            cardStudents.Controls.Add(lblStudentsValue);
            cardStudents.Controls.Add(lblStudentsTitle);
            cardStudents.Controls.Add(lblStudentsSub);
            cardStudents.Location = new Point(12, 13);
            cardStudents.Margin = new Padding(3, 3, 100, 3);
            cardStudents.Name = "cardStudents";
            cardStudents.Padding = new Padding(0, 0, 100, 0);
            cardStudents.Size = new Size(280, 120);
            cardStudents.TabIndex = 0;
            // 
            // iconStudents
            // 
            iconStudents.BackColor = Color.FromArgb(52, 152, 219);
            iconStudents.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            iconStudents.IconColor = Color.White;
            iconStudents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconStudents.IconSize = 40;
            iconStudents.Location = new Point(220, 10);
            iconStudents.Name = "iconStudents";
            iconStudents.Size = new Size(40, 40);
            iconStudents.TabIndex = 0;
            iconStudents.TabStop = false;
            // 
            // lblStudentsValue
            // 
            lblStudentsValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblStudentsValue.ForeColor = Color.White;
            lblStudentsValue.Location = new Point(15, 0);
            lblStudentsValue.Name = "lblStudentsValue";
            lblStudentsValue.Size = new Size(199, 60);
            lblStudentsValue.TabIndex = 1;
            lblStudentsValue.Text = "1,234";
            // 
            // lblStudentsTitle
            // 
            lblStudentsTitle.ForeColor = Color.White;
            lblStudentsTitle.Location = new Point(15, 60);
            lblStudentsTitle.Name = "lblStudentsTitle";
            lblStudentsTitle.Size = new Size(188, 23);
            lblStudentsTitle.TabIndex = 2;
            lblStudentsTitle.Text = "Tổng học viên";
            // 
            // lblStudentsSub
            // 
            lblStudentsSub.ForeColor = Color.WhiteSmoke;
            lblStudentsSub.Location = new Point(15, 80);
            lblStudentsSub.Name = "lblStudentsSub";
            lblStudentsSub.Size = new Size(199, 23);
            lblStudentsSub.TabIndex = 3;
            lblStudentsSub.Text = "+12% so với tháng trước";
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.FromArgb(241, 196, 15);
            cardRevenue.Controls.Add(iconRevenue);
            cardRevenue.Controls.Add(lblRevenueValue);
            cardRevenue.Controls.Add(lblRevenueTitle);
            cardRevenue.Controls.Add(lblRevenueSub);
            cardRevenue.Location = new Point(395, 13);
            cardRevenue.Margin = new Padding(3, 3, 100, 3);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Padding = new Padding(0, 0, 100, 0);
            cardRevenue.Size = new Size(280, 120);
            cardRevenue.TabIndex = 2;
            // 
            // iconRevenue
            // 
            iconRevenue.BackColor = Color.FromArgb(241, 196, 15);
            iconRevenue.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            iconRevenue.IconColor = Color.White;
            iconRevenue.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconRevenue.IconSize = 40;
            iconRevenue.Location = new Point(220, 10);
            iconRevenue.Name = "iconRevenue";
            iconRevenue.Size = new Size(40, 40);
            iconRevenue.TabIndex = 0;
            iconRevenue.TabStop = false;
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblRevenueValue.ForeColor = Color.White;
            lblRevenueValue.Location = new Point(15, 0);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(205, 60);
            lblRevenueValue.TabIndex = 1;
            lblRevenueValue.Text = "2.5 tỷ";
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.ForeColor = Color.White;
            lblRevenueTitle.Location = new Point(15, 60);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(177, 23);
            lblRevenueTitle.TabIndex = 2;
            lblRevenueTitle.Text = "Doanh thu";
            // 
            // lblRevenueSub
            // 
            lblRevenueSub.ForeColor = Color.WhiteSmoke;
            lblRevenueSub.Location = new Point(15, 80);
            lblRevenueSub.Name = "lblRevenueSub";
            lblRevenueSub.Size = new Size(219, 23);
            lblRevenueSub.TabIndex = 3;
            lblRevenueSub.Text = "+18% so với tháng trước";
            // 
            // cardTeachers
            // 
            cardTeachers.BackColor = Color.FromArgb(155, 89, 182);
            cardTeachers.Controls.Add(iconTeachers);
            cardTeachers.Controls.Add(lblTeachersValue);
            cardTeachers.Controls.Add(lblTeachersTitle);
            cardTeachers.Controls.Add(lblTeachersSub);
            cardTeachers.Location = new Point(1161, 13);
            cardTeachers.Margin = new Padding(3, 3, 100, 3);
            cardTeachers.Name = "cardTeachers";
            cardTeachers.Padding = new Padding(0, 0, 100, 0);
            cardTeachers.Size = new Size(280, 120);
            cardTeachers.TabIndex = 3;
            // 
            // iconTeachers
            // 
            iconTeachers.BackColor = Color.FromArgb(155, 89, 182);
            iconTeachers.IconChar = FontAwesome.Sharp.IconChar.ChalkboardTeacher;
            iconTeachers.IconColor = Color.White;
            iconTeachers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconTeachers.IconSize = 40;
            iconTeachers.Location = new Point(220, 10);
            iconTeachers.Name = "iconTeachers";
            iconTeachers.Size = new Size(40, 40);
            iconTeachers.TabIndex = 0;
            iconTeachers.TabStop = false;
            // 
            // lblTeachersValue
            // 
            lblTeachersValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTeachersValue.ForeColor = Color.White;
            lblTeachersValue.Location = new Point(19, 0);
            lblTeachersValue.Name = "lblTeachersValue";
            lblTeachersValue.Size = new Size(185, 50);
            lblTeachersValue.TabIndex = 1;
            lblTeachersValue.Text = "78";
            // 
            // lblTeachersTitle
            // 
            lblTeachersTitle.ForeColor = Color.White;
            lblTeachersTitle.Location = new Point(15, 60);
            lblTeachersTitle.Name = "lblTeachersTitle";
            lblTeachersTitle.Size = new Size(100, 23);
            lblTeachersTitle.TabIndex = 2;
            lblTeachersTitle.Text = "Giáo viên";
            // 
            // lblTeachersSub
            // 
            lblTeachersSub.ForeColor = Color.WhiteSmoke;
            lblTeachersSub.Location = new Point(15, 80);
            lblTeachersSub.Name = "lblTeachersSub";
            lblTeachersSub.Size = new Size(216, 23);
            lblTeachersSub.TabIndex = 3;
            lblTeachersSub.Text = "5 giáo viên mới tháng này";
            // 
            // cardClasses
            // 
            cardClasses.BackColor = Color.FromArgb(46, 204, 113);
            cardClasses.Controls.Add(iconClasses);
            cardClasses.Controls.Add(lblClassesValue);
            cardClasses.Controls.Add(lblClassesTitle);
            cardClasses.Controls.Add(lblClassesSub);
            cardClasses.Location = new Point(778, 13);
            cardClasses.Margin = new Padding(3, 3, 100, 3);
            cardClasses.Name = "cardClasses";
            cardClasses.Padding = new Padding(0, 0, 100, 0);
            cardClasses.Size = new Size(280, 120);
            cardClasses.TabIndex = 1;
            // 
            // iconClasses
            // 
            iconClasses.BackColor = Color.FromArgb(46, 204, 113);
            iconClasses.IconChar = FontAwesome.Sharp.IconChar.Chalkboard;
            iconClasses.IconColor = Color.White;
            iconClasses.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconClasses.IconSize = 40;
            iconClasses.Location = new Point(220, 10);
            iconClasses.Name = "iconClasses";
            iconClasses.Size = new Size(40, 40);
            iconClasses.TabIndex = 0;
            iconClasses.TabStop = false;
            // 
            // lblClassesValue
            // 
            lblClassesValue.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblClassesValue.ForeColor = Color.White;
            lblClassesValue.Location = new Point(9, 0);
            lblClassesValue.Name = "lblClassesValue";
            lblClassesValue.Size = new Size(205, 50);
            lblClassesValue.TabIndex = 1;
            lblClassesValue.Text = "48";
            // 
            // lblClassesTitle
            // 
            lblClassesTitle.ForeColor = Color.White;
            lblClassesTitle.Location = new Point(15, 60);
            lblClassesTitle.Name = "lblClassesTitle";
            lblClassesTitle.Size = new Size(100, 23);
            lblClassesTitle.TabIndex = 2;
            lblClassesTitle.Text = "Lớp học";
            // 
            // lblClassesSub
            // 
            lblClassesSub.ForeColor = Color.WhiteSmoke;
            lblClassesSub.Location = new Point(15, 80);
            lblClassesSub.Name = "lblClassesSub";
            lblClassesSub.Size = new Size(199, 23);
            lblClassesSub.TabIndex = 3;
            lblClassesSub.Text = "12 lớp đang mở đăng ký";
            // 
            // DashBoard
            // 
            Controls.Add(mainPanel);
            Name = "DashBoard";
            Size = new Size(1494, 820);
            mainPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            cardStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconStudents).EndInit();
            cardRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconRevenue).EndInit();
            cardTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconTeachers).EndInit();
            cardClasses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconClasses).EndInit();
            ResumeLayout(false);
        }
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
    }
}
