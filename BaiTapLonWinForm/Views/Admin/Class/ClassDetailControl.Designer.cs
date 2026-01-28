namespace BaiTapLonWinForm.View.Admin.Class
{
    partial class ClassDetailControl
    {
        private System.ComponentModel.IContainer components = null;

        // --- EXISTING CONTROLS ---
        private Panel pnlHeader;
        private Label lblClassAndCouse;
        private Panel pnlSidebar;
        private GroupBox grpGeneral;
        private Label lblTimeTitle;
        private Label lblTimeValue;
        private Label lblShiftTitle;
        private Label lblShiftValue;
        private Label lblDaysTitle;
        private Label lblDaysValue;
        private Label lblRoomTitle;
        private LinkLabel lnkOnlineLink;
        private GroupBox grpTeacher;
        private Label lblTeacherName;
        private Label lblTeacherPhone;
        private Label lblTeacherEmail;
        private GroupBox grpStats;
        private Label lblProgressTitle;
        private Label lblStudentCount;
        private Panel pnlProgressBg;
        private Panel pnlProgressVal;
        private Label lblNoteTitle;
        private Panel pnlMain;

        // --- NEW CONTROLS FOR EDIT TAB ---
        private Guna.UI2.WinForms.Guna2Panel pnlEditContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlEditHeader;
        private Label lblEditTitle;

        // Class Name
        private Label lblEditClassName;
        private Guna.UI2.WinForms.Guna2TextBox txtClassName;

        // Course Selection
        private Label lblEditCourse;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCourse;

        // Teacher Selection
        private Label lblEditTeacher;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTeacher;

        // Shift
        private Label lblEditShift;
        private Guna.UI2.WinForms.Guna2ComboBox cmbShift;

        // Date Range
        private Label lblEditStartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Label lblEditEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;

        // Max Students
        private Label lblEditMaxStudent;
        private Guna.UI2.WinForms.Guna2NumericUpDown numMaxStudent;

        // Online Link
        private Label lblEditOnlineLink;
        private Guna.UI2.WinForms.Guna2TextBox txtOnlineLink;

        // Note
        private Label lblEditNote;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;

        // Action Buttons
        private Guna.UI2.WinForms.Guna2Button btnSaveChanges;
        private Guna.UI2.WinForms.Guna2Button btnCancelEdit;

        private System.Windows.Forms.Label lblEditDays;
        private System.Windows.Forms.FlowLayoutPanel pnlDaysContainer;
        private Guna.UI2.WinForms.Guna2Button btnMon;
        private Guna.UI2.WinForms.Guna2Button btnTue;
        private Guna.UI2.WinForms.Guna2Button btnWed;
        private Guna.UI2.WinForms.Guna2Button btnThu;
        private Guna.UI2.WinForms.Guna2Button btnFri;
        private Guna.UI2.WinForms.Guna2Button btnSat;
        private Guna.UI2.WinForms.Guna2Button btnSun;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges45 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges46 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges33 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges34 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges35 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges36 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges37 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges38 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges39 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges40 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges41 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges42 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges43 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges44 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Panel();
            lblClassAndCouse = new Label();
            pnlSidebar = new Panel();
            grpGeneral = new GroupBox();
            lblEndDate = new Label();
            lblStartDate = new Label();
            lblShift = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            lblRoomTitle = new Label();
            lnkOnlineLink = new LinkLabel();
            grpTeacher = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            lblPhoneNumber = new Label();
            lblTeacherName = new Label();
            lblTeacherEmail = new Label();
            grpStats = new GroupBox();
            lblNote = new Label();
            lblProgressTitle = new Label();
            lblStudentCount = new Label();
            pnlProgressBg = new Panel();
            pnlProgressVal = new Panel();
            lblNoteTitle = new Label();
            lblTimeTitle = new Label();
            lblTimeValue = new Label();
            lblShiftTitle = new Label();
            lblShiftValue = new Label();
            lblDaysTitle = new Label();
            lblDaysValue = new Label();
            lblTeacherPhone = new Label();
            pnlMain = new Panel();
            TabControls = new Guna.UI2.WinForms.Guna2TabControl();
            tabPage1 = new TabPage();
            btnAddStudent = new Guna.UI2.WinForms.Guna2Button();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            dgvStudents = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colDob = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label6 = new Label();
            tabPage2 = new TabPage();
            pnlEditContainer = new Guna.UI2.WinForms.Guna2Panel();
            lblEstimate = new Label();
            lblErrorDayofWeek = new Label();
            lblErrorEndDate = new Label();
            lblErrorStartDate = new Label();
            lblErrorClassName = new Label();
            btnCancelEdit = new Guna.UI2.WinForms.Guna2Button();
            btnSaveChanges = new Guna.UI2.WinForms.Guna2Button();
            txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            lblEditNote = new Label();
            txtOnlineLink = new Guna.UI2.WinForms.Guna2TextBox();
            lblEditOnlineLink = new Label();
            numMaxStudent = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblEditMaxStudent = new Label();
            dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblEditEndDate = new Label();
            dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblEditStartDate = new Label();
            cmbShift = new Guna.UI2.WinForms.Guna2ComboBox();
            lblEditShift = new Label();
            cmbTeacher = new Guna.UI2.WinForms.Guna2ComboBox();
            lblEditTeacher = new Label();
            cmbCourse = new Guna.UI2.WinForms.Guna2ComboBox();
            lblEditCourse = new Label();
            txtClassName = new Guna.UI2.WinForms.Guna2TextBox();
            lblEditClassName = new Label();
            pnlEditHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblEditTitle = new Label();
            lblEditDays = new Label();
            pnlDaysContainer = new FlowLayoutPanel();
            btnMon = new Guna.UI2.WinForms.Guna2Button();
            btnTue = new Guna.UI2.WinForms.Guna2Button();
            btnWed = new Guna.UI2.WinForms.Guna2Button();
            btnThu = new Guna.UI2.WinForms.Guna2Button();
            btnFri = new Guna.UI2.WinForms.Guna2Button();
            btnSat = new Guna.UI2.WinForms.Guna2Button();
            btnSun = new Guna.UI2.WinForms.Guna2Button();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            grpGeneral.SuspendLayout();
            grpTeacher.SuspendLayout();
            grpStats.SuspendLayout();
            pnlProgressBg.SuspendLayout();
            pnlMain.SuspendLayout();
            TabControls.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            guna2Panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlEditContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxStudent).BeginInit();
            pnlEditHeader.SuspendLayout();
            pnlDaysContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(94, 148, 255);
            pnlHeader.Controls.Add(lblClassAndCouse);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.ForeColor = Color.White;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(30, 10, 30, 10);
            pnlHeader.Size = new Size(1480, 61);
            pnlHeader.TabIndex = 2;
            // 
            // lblClassAndCouse
            // 
            lblClassAndCouse.AutoSize = true;
            lblClassAndCouse.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblClassAndCouse.ForeColor = Color.White;
            lblClassAndCouse.Location = new Point(25, 16);
            lblClassAndCouse.Name = "lblClassAndCouse";
            lblClassAndCouse.Size = new Size(146, 31);
            lblClassAndCouse.TabIndex = 0;
            lblClassAndCouse.Text = "Tên Lớp Học";
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.Controls.Add(grpGeneral);
            pnlSidebar.Controls.Add(grpTeacher);
            pnlSidebar.Controls.Add(grpStats);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 61);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(20);
            pnlSidebar.Size = new Size(400, 789);
            pnlSidebar.TabIndex = 1;
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(lblEndDate);
            grpGeneral.Controls.Add(lblStartDate);
            grpGeneral.Controls.Add(lblShift);
            grpGeneral.Controls.Add(label5);
            grpGeneral.Controls.Add(label4);
            grpGeneral.Controls.Add(label1);
            grpGeneral.Controls.Add(lblRoomTitle);
            grpGeneral.Controls.Add(lnkOnlineLink);
            grpGeneral.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpGeneral.Location = new Point(23, 10);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new Size(360, 351);
            grpGeneral.TabIndex = 0;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "Thông Tin";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 10F);
            lblEndDate.ForeColor = Color.Gray;
            lblEndDate.Location = new Point(140, 148);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(31, 23);
            lblEndDate.TabIndex = 7;
            lblEndDate.Text = "---";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 10F);
            lblStartDate.ForeColor = Color.Gray;
            lblStartDate.Location = new Point(137, 99);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(31, 23);
            lblStartDate.TabIndex = 6;
            lblStartDate.Text = "---";
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.Font = new Font("Segoe UI", 10F);
            lblShift.ForeColor = Color.Gray;
            lblShift.Location = new Point(96, 199);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(31, 23);
            lblShift.TabIndex = 5;
            lblShift.Text = "---";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(14, 199);
            label5.Name = "label5";
            label5.Size = new Size(67, 23);
            label5.TabIndex = 4;
            label5.Text = "Ca học:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(13, 148);
            label4.Name = "label4";
            label4.Size = new Size(121, 23);
            label4.TabIndex = 3;
            label4.Text = "Ngày kết thúc:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(13, 99);
            label1.Name = "label1";
            label1.Size = new Size(118, 23);
            label1.TabIndex = 2;
            label1.Text = "Ngày bắt đầu:";
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.Font = new Font("Segoe UI", 10F);
            lblRoomTitle.ForeColor = Color.Gray;
            lblRoomTitle.Location = new Point(14, 35);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(44, 23);
            lblRoomTitle.TabIndex = 0;
            lblRoomTitle.Text = "Link:";
            // 
            // lnkOnlineLink
            // 
            lnkOnlineLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lnkOnlineLink.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkOnlineLink.Location = new Point(64, 35);
            lnkOnlineLink.Name = "lnkOnlineLink";
            lnkOnlineLink.Size = new Size(291, 58);
            lnkOnlineLink.TabIndex = 1;
            lnkOnlineLink.TabStop = true;
            lnkOnlineLink.Text = "---";
            // 
            // grpTeacher
            // 
            grpTeacher.Controls.Add(label3);
            grpTeacher.Controls.Add(label2);
            grpTeacher.Controls.Add(lblPhoneNumber);
            grpTeacher.Controls.Add(lblTeacherName);
            grpTeacher.Controls.Add(lblTeacherEmail);
            grpTeacher.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpTeacher.Location = new Point(17, 367);
            grpTeacher.Name = "grpTeacher";
            grpTeacher.Size = new Size(360, 164);
            grpTeacher.TabIndex = 1;
            grpTeacher.TabStop = false;
            grpTeacher.Text = "Giảng Viên Phụ Trách";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(20, 121);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 5;
            label3.Text = "SDT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(20, 77);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 4;
            label2.Text = "Email:";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 9F);
            lblPhoneNumber.ForeColor = Color.Gray;
            lblPhoneNumber.Location = new Point(70, 121);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(27, 20);
            lblPhoneNumber.TabIndex = 3;
            lblPhoneNumber.Text = "---";
            // 
            // lblTeacherName
            // 
            lblTeacherName.AutoSize = true;
            lblTeacherName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTeacherName.ForeColor = Color.FromArgb(50, 50, 50);
            lblTeacherName.Location = new Point(10, 35);
            lblTeacherName.Name = "lblTeacherName";
            lblTeacherName.Size = new Size(158, 25);
            lblTeacherName.TabIndex = 1;
            lblTeacherName.Text = "Chưa phân công";
            // 
            // lblTeacherEmail
            // 
            lblTeacherEmail.AutoSize = true;
            lblTeacherEmail.Font = new Font("Segoe UI", 9F);
            lblTeacherEmail.ForeColor = Color.Gray;
            lblTeacherEmail.Location = new Point(70, 78);
            lblTeacherEmail.Name = "lblTeacherEmail";
            lblTeacherEmail.Size = new Size(27, 20);
            lblTeacherEmail.TabIndex = 2;
            lblTeacherEmail.Text = "---";
            // 
            // grpStats
            // 
            grpStats.Controls.Add(lblNote);
            grpStats.Controls.Add(lblProgressTitle);
            grpStats.Controls.Add(lblStudentCount);
            grpStats.Controls.Add(pnlProgressBg);
            grpStats.Controls.Add(lblNoteTitle);
            grpStats.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpStats.Location = new Point(17, 546);
            grpStats.Name = "grpStats";
            grpStats.Size = new Size(360, 229);
            grpStats.TabIndex = 2;
            grpStats.TabStop = false;
            grpStats.Text = "Sĩ Số Ghi Chú";
            // 
            // lblNote
            // 
            lblNote.Font = new Font("Segoe UI", 10F);
            lblNote.Location = new Point(20, 155);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(320, 52);
            lblNote.TabIndex = 4;
            lblNote.Text = "---";
            // 
            // lblProgressTitle
            // 
            lblProgressTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblProgressTitle.Location = new Point(20, 40);
            lblProgressTitle.Name = "lblProgressTitle";
            lblProgressTitle.Size = new Size(77, 23);
            lblProgressTitle.TabIndex = 0;
            lblProgressTitle.Text = "Sỉ số:";
            // 
            // lblStudentCount
            // 
            lblStudentCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStudentCount.Location = new Point(240, 40);
            lblStudentCount.Name = "lblStudentCount";
            lblStudentCount.Size = new Size(100, 23);
            lblStudentCount.TabIndex = 1;
            lblStudentCount.Text = "0/0 Học viên";
            lblStudentCount.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlProgressBg
            // 
            pnlProgressBg.BackColor = Color.WhiteSmoke;
            pnlProgressBg.BorderStyle = BorderStyle.FixedSingle;
            pnlProgressBg.Controls.Add(pnlProgressVal);
            pnlProgressBg.Location = new Point(20, 70);
            pnlProgressBg.Name = "pnlProgressBg";
            pnlProgressBg.Size = new Size(320, 15);
            pnlProgressBg.TabIndex = 2;
            // 
            // pnlProgressVal
            // 
            pnlProgressVal.BackColor = Color.SeaGreen;
            pnlProgressVal.Location = new Point(0, 0);
            pnlProgressVal.Name = "pnlProgressVal";
            pnlProgressVal.Size = new Size(0, 13);
            pnlProgressVal.TabIndex = 0;
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNoteTitle.Location = new Point(20, 110);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(131, 23);
            lblNoteTitle.TabIndex = 3;
            lblNoteTitle.Text = "Ghi chú nội bộ:";
            // 
            // lblTimeTitle
            // 
            lblTimeTitle.Location = new Point(0, 0);
            lblTimeTitle.Name = "lblTimeTitle";
            lblTimeTitle.Size = new Size(100, 23);
            lblTimeTitle.TabIndex = 0;
            // 
            // lblTimeValue
            // 
            lblTimeValue.Location = new Point(0, 0);
            lblTimeValue.Name = "lblTimeValue";
            lblTimeValue.Size = new Size(100, 23);
            lblTimeValue.TabIndex = 0;
            // 
            // lblShiftTitle
            // 
            lblShiftTitle.Location = new Point(0, 0);
            lblShiftTitle.Name = "lblShiftTitle";
            lblShiftTitle.Size = new Size(100, 23);
            lblShiftTitle.TabIndex = 0;
            // 
            // lblShiftValue
            // 
            lblShiftValue.Location = new Point(0, 0);
            lblShiftValue.Name = "lblShiftValue";
            lblShiftValue.Size = new Size(100, 23);
            lblShiftValue.TabIndex = 0;
            // 
            // lblDaysTitle
            // 
            lblDaysTitle.Location = new Point(0, 0);
            lblDaysTitle.Name = "lblDaysTitle";
            lblDaysTitle.Size = new Size(100, 23);
            lblDaysTitle.TabIndex = 0;
            // 
            // lblDaysValue
            // 
            lblDaysValue.Location = new Point(0, 0);
            lblDaysValue.Name = "lblDaysValue";
            lblDaysValue.Size = new Size(100, 23);
            lblDaysValue.TabIndex = 0;
            // 
            // lblTeacherPhone
            // 
            lblTeacherPhone.Location = new Point(0, 0);
            lblTeacherPhone.Name = "lblTeacherPhone";
            lblTeacherPhone.Size = new Size(100, 23);
            lblTeacherPhone.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.WhiteSmoke;
            pnlMain.Controls.Add(TabControls);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(400, 61);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.Size = new Size(1080, 789);
            pnlMain.TabIndex = 0;
            // 
            // TabControls
            // 
            TabControls.Controls.Add(tabPage1);
            TabControls.Controls.Add(tabPage2);
            TabControls.Dock = DockStyle.Fill;
            TabControls.ItemSize = new Size(180, 50);
            TabControls.Location = new Point(10, 10);
            TabControls.Margin = new Padding(0);
            TabControls.Name = "TabControls";
            TabControls.Padding = new Point(0, 0);
            TabControls.SelectedIndex = 0;
            TabControls.Size = new Size(1060, 769);
            TabControls.TabButtonHoverState.BorderColor = Color.Empty;
            TabControls.TabButtonHoverState.FillColor = Color.FromArgb(240, 240, 240);
            TabControls.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            TabControls.TabButtonHoverState.ForeColor = Color.Black;
            TabControls.TabButtonHoverState.InnerColor = Color.FromArgb(240, 240, 240);
            TabControls.TabButtonIdleState.BorderColor = Color.Empty;
            TabControls.TabButtonIdleState.FillColor = Color.Transparent;
            TabControls.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            TabControls.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            TabControls.TabButtonIdleState.InnerColor = Color.Transparent;
            TabControls.TabButtonSelectedState.BorderColor = Color.Empty;
            TabControls.TabButtonSelectedState.FillColor = Color.Transparent;
            TabControls.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            TabControls.TabButtonSelectedState.ForeColor = Color.FromArgb(53, 41, 123);
            TabControls.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            TabControls.TabButtonSize = new Size(180, 50);
            TabControls.TabIndex = 0;
            TabControls.TabMenuBackColor = Color.White;
            TabControls.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnAddStudent);
            tabPage1.Controls.Add(btnDelete);
            tabPage1.Controls.Add(dgvStudents);
            tabPage1.Controls.Add(guna2Panel1);
            tabPage1.Location = new Point(4, 54);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1052, 711);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách học viên";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BorderRadius = 8;
            btnAddStudent.CustomizableEdges = customizableEdges1;
            btnAddStudent.DisabledState.BorderColor = Color.DarkGray;
            btnAddStudent.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddStudent.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddStudent.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddStudent.FillColor = Color.FromArgb(46, 204, 113);
            btnAddStudent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(663, 633);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddStudent.Size = new Size(180, 50);
            btnAddStudent.TabIndex = 23;
            btnAddStudent.Text = "+ Thêm học viên";
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnDelete
            // 
            btnDelete.BorderRadius = 8;
            btnDelete.CustomizableEdges = customizableEdges3;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.FromArgb(231, 76, 60);
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(861, 633);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDelete.Size = new Size(154, 50);
            btnDelete.TabIndex = 24;
            btnDelete.Text = "Xóa học viên";
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.ColumnHeadersHeight = 40;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { colName, colDob, colPhone, colEmail });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            dgvStudents.Location = new Point(3, 53);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 40;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1046, 567);
            dgvStudents.TabIndex = 2;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colName.HeaderText = "Họ và Tên";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colDob
            // 
            colDob.HeaderText = "Ngày Sinh";
            colDob.MinimumWidth = 6;
            colDob.Name = "colDob";
            colDob.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "SĐT";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(94, 148, 255);
            guna2Panel1.BorderRadius = 8;
            guna2Panel1.Controls.Add(label6);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(3, 3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1046, 50);
            guna2Panel1.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(20, 6);
            label6.Name = "label6";
            label6.Size = new Size(261, 37);
            label6.TabIndex = 0;
            label6.Text = "Danh sách học viên";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pnlEditContainer);
            tabPage2.Location = new Point(4, 54);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1052, 711);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chỉnh sửa lớp học";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlEditContainer
            // 
            pnlEditContainer.AutoScroll = true;
            pnlEditContainer.BackColor = Color.White;
            pnlEditContainer.Controls.Add(lblEstimate);
            pnlEditContainer.Controls.Add(lblErrorDayofWeek);
            pnlEditContainer.Controls.Add(lblErrorEndDate);
            pnlEditContainer.Controls.Add(lblErrorStartDate);
            pnlEditContainer.Controls.Add(lblErrorClassName);
            pnlEditContainer.Controls.Add(btnCancelEdit);
            pnlEditContainer.Controls.Add(btnSaveChanges);
            pnlEditContainer.Controls.Add(txtNote);
            pnlEditContainer.Controls.Add(lblEditNote);
            pnlEditContainer.Controls.Add(txtOnlineLink);
            pnlEditContainer.Controls.Add(lblEditOnlineLink);
            pnlEditContainer.Controls.Add(numMaxStudent);
            pnlEditContainer.Controls.Add(lblEditMaxStudent);
            pnlEditContainer.Controls.Add(dtpEndDate);
            pnlEditContainer.Controls.Add(lblEditEndDate);
            pnlEditContainer.Controls.Add(dtpStartDate);
            pnlEditContainer.Controls.Add(lblEditStartDate);
            pnlEditContainer.Controls.Add(cmbShift);
            pnlEditContainer.Controls.Add(lblEditShift);
            pnlEditContainer.Controls.Add(cmbTeacher);
            pnlEditContainer.Controls.Add(lblEditTeacher);
            pnlEditContainer.Controls.Add(cmbCourse);
            pnlEditContainer.Controls.Add(lblEditCourse);
            pnlEditContainer.Controls.Add(txtClassName);
            pnlEditContainer.Controls.Add(lblEditClassName);
            pnlEditContainer.Controls.Add(pnlEditHeader);
            pnlEditContainer.Controls.Add(lblEditDays);
            pnlEditContainer.Controls.Add(pnlDaysContainer);
            pnlEditContainer.CustomizableEdges = customizableEdges45;
            pnlEditContainer.Dock = DockStyle.Fill;
            pnlEditContainer.Location = new Point(3, 3);
            pnlEditContainer.Name = "pnlEditContainer";
            pnlEditContainer.ShadowDecoration.CustomizableEdges = customizableEdges46;
            pnlEditContainer.Size = new Size(1046, 705);
            pnlEditContainer.TabIndex = 0;
            // 
            // lblEstimate
            // 
            lblEstimate.AutoSize = true;
            lblEstimate.ForeColor = Color.Green;
            lblEstimate.Location = new Point(540, 143);
            lblEstimate.Name = "lblEstimate";
            lblEstimate.Size = new Size(50, 20);
            lblEstimate.TabIndex = 33;
            lblEstimate.Text = "label7";
            lblEstimate.Visible = false;
            // 
            // lblErrorDayofWeek
            // 
            lblErrorDayofWeek.AutoSize = true;
            lblErrorDayofWeek.ForeColor = Color.Red;
            lblErrorDayofWeek.Location = new Point(537, 589);
            lblErrorDayofWeek.Name = "lblErrorDayofWeek";
            lblErrorDayofWeek.Size = new Size(50, 20);
            lblErrorDayofWeek.TabIndex = 32;
            lblErrorDayofWeek.Text = "label7";
            lblErrorDayofWeek.Visible = false;
            // 
            // lblErrorEndDate
            // 
            lblErrorEndDate.AutoSize = true;
            lblErrorEndDate.ForeColor = Color.Red;
            lblErrorEndDate.Location = new Point(530, 358);
            lblErrorEndDate.Name = "lblErrorEndDate";
            lblErrorEndDate.Size = new Size(50, 20);
            lblErrorEndDate.TabIndex = 26;
            lblErrorEndDate.Text = "label9";
            lblErrorEndDate.Visible = false;
            // 
            // lblErrorStartDate
            // 
            lblErrorStartDate.AutoSize = true;
            lblErrorStartDate.ForeColor = Color.Red;
            lblErrorStartDate.Location = new Point(40, 351);
            lblErrorStartDate.Name = "lblErrorStartDate";
            lblErrorStartDate.Size = new Size(50, 20);
            lblErrorStartDate.TabIndex = 25;
            lblErrorStartDate.Text = "label8";
            lblErrorStartDate.Visible = false;
            // 
            // lblErrorClassName
            // 
            lblErrorClassName.AutoSize = true;
            lblErrorClassName.ForeColor = Color.Red;
            lblErrorClassName.Location = new Point(49, 147);
            lblErrorClassName.Name = "lblErrorClassName";
            lblErrorClassName.Size = new Size(50, 20);
            lblErrorClassName.TabIndex = 24;
            lblErrorClassName.Text = "label7";
            lblErrorClassName.Visible = false;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.BorderRadius = 8;
            btnCancelEdit.CustomizableEdges = customizableEdges7;
            btnCancelEdit.DisabledState.BorderColor = Color.DarkGray;
            btnCancelEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelEdit.FillColor = Color.FromArgb(231, 76, 60);
            btnCancelEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelEdit.ForeColor = Color.White;
            btnCancelEdit.Location = new Point(890, 630);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancelEdit.Size = new Size(130, 50);
            btnCancelEdit.TabIndex = 22;
            btnCancelEdit.Text = "✖ Hủy";
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BorderRadius = 8;
            btnSaveChanges.CustomizableEdges = customizableEdges9;
            btnSaveChanges.DisabledState.BorderColor = Color.DarkGray;
            btnSaveChanges.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSaveChanges.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSaveChanges.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSaveChanges.FillColor = Color.FromArgb(46, 204, 113);
            btnSaveChanges.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(700, 630);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSaveChanges.Size = new Size(180, 50);
            btnSaveChanges.TabIndex = 21;
            btnSaveChanges.Text = "💾 Lưu Thay Đổi";
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // txtNote
            // 
            txtNote.BorderRadius = 8;
            txtNote.Cursor = Cursors.IBeam;
            txtNote.CustomizableEdges = customizableEdges11;
            txtNote.DefaultText = "";
            txtNote.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNote.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNote.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNote.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNote.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNote.Font = new Font("Segoe UI", 10.2F);
            txtNote.ForeColor = Color.Black;
            txtNote.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNote.Location = new Point(41, 519);
            txtNote.Margin = new Padding(3, 4, 3, 4);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Nhập ghi chú về lớp học...";
            txtNote.SelectedText = "";
            txtNote.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtNote.Size = new Size(450, 100);
            txtNote.TabIndex = 18;
            // 
            // lblEditNote
            // 
            lblEditNote.AutoSize = true;
            lblEditNote.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditNote.Location = new Point(41, 489);
            lblEditNote.Name = "lblEditNote";
            lblEditNote.Size = new Size(142, 25);
            lblEditNote.TabIndex = 17;
            lblEditNote.Text = "Ghi chú nội bộ";
            // 
            // txtOnlineLink
            // 
            txtOnlineLink.BorderRadius = 8;
            txtOnlineLink.Cursor = Cursors.IBeam;
            txtOnlineLink.CustomizableEdges = customizableEdges13;
            txtOnlineLink.DefaultText = "";
            txtOnlineLink.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtOnlineLink.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtOnlineLink.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtOnlineLink.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtOnlineLink.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOnlineLink.Font = new Font("Segoe UI", 10.2F);
            txtOnlineLink.ForeColor = Color.Black;
            txtOnlineLink.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOnlineLink.Location = new Point(530, 419);
            txtOnlineLink.Margin = new Padding(3, 4, 3, 4);
            txtOnlineLink.Name = "txtOnlineLink";
            txtOnlineLink.PlaceholderText = "https://meet.google.com/...";
            txtOnlineLink.SelectedText = "";
            txtOnlineLink.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtOnlineLink.Size = new Size(450, 45);
            txtOnlineLink.TabIndex = 16;
            // 
            // lblEditOnlineLink
            // 
            lblEditOnlineLink.AutoSize = true;
            lblEditOnlineLink.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditOnlineLink.Location = new Point(530, 389);
            lblEditOnlineLink.Name = "lblEditOnlineLink";
            lblEditOnlineLink.Size = new Size(148, 25);
            lblEditOnlineLink.TabIndex = 15;
            lblEditOnlineLink.Text = "Link học online";
            // 
            // numMaxStudent
            // 
            numMaxStudent.BackColor = Color.Transparent;
            numMaxStudent.BorderRadius = 8;
            numMaxStudent.Cursor = Cursors.IBeam;
            numMaxStudent.CustomizableEdges = customizableEdges15;
            numMaxStudent.Font = new Font("Segoe UI", 10.2F);
            numMaxStudent.Location = new Point(40, 419);
            numMaxStudent.Margin = new Padding(3, 4, 3, 4);
            numMaxStudent.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numMaxStudent.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numMaxStudent.Name = "numMaxStudent";
            numMaxStudent.ShadowDecoration.CustomizableEdges = customizableEdges16;
            numMaxStudent.Size = new Size(450, 45);
            numMaxStudent.TabIndex = 14;
            numMaxStudent.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblEditMaxStudent
            // 
            lblEditMaxStudent.AutoSize = true;
            lblEditMaxStudent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditMaxStudent.Location = new Point(40, 389);
            lblEditMaxStudent.Name = "lblEditMaxStudent";
            lblEditMaxStudent.Size = new Size(109, 25);
            lblEditMaxStudent.TabIndex = 13;
            lblEditMaxStudent.Text = "Sĩ số tối đa";
            // 
            // dtpEndDate
            // 
            dtpEndDate.BorderRadius = 8;
            dtpEndDate.Checked = true;
            dtpEndDate.CustomizableEdges = customizableEdges17;
            dtpEndDate.FillColor = Color.White;
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(530, 301);
            dtpEndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpEndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.ShadowDecoration.CustomizableEdges = customizableEdges18;
            dtpEndDate.Size = new Size(450, 45);
            dtpEndDate.TabIndex = 12;
            dtpEndDate.Value = new DateTime(2025, 12, 22, 21, 8, 8, 845);
            // 
            // lblEditEndDate
            // 
            lblEditEndDate.AutoSize = true;
            lblEditEndDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditEndDate.Location = new Point(530, 271);
            lblEditEndDate.Name = "lblEditEndDate";
            lblEditEndDate.Size = new Size(136, 25);
            lblEditEndDate.TabIndex = 11;
            lblEditEndDate.Text = "Ngày kết thúc";
            // 
            // dtpStartDate
            // 
            dtpStartDate.BorderRadius = 8;
            dtpStartDate.Checked = true;
            dtpStartDate.CustomizableEdges = customizableEdges19;
            dtpStartDate.FillColor = Color.White;
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(40, 301);
            dtpStartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpStartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.ShadowDecoration.CustomizableEdges = customizableEdges20;
            dtpStartDate.Size = new Size(450, 45);
            dtpStartDate.TabIndex = 10;
            dtpStartDate.Value = new DateTime(2025, 12, 22, 21, 8, 8, 875);
            // 
            // lblEditStartDate
            // 
            lblEditStartDate.AutoSize = true;
            lblEditStartDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditStartDate.Location = new Point(40, 271);
            lblEditStartDate.Name = "lblEditStartDate";
            lblEditStartDate.Size = new Size(132, 25);
            lblEditStartDate.TabIndex = 9;
            lblEditStartDate.Text = "Ngày bắt đầu";
            // 
            // cmbShift
            // 
            cmbShift.BackColor = Color.Transparent;
            cmbShift.BorderRadius = 8;
            cmbShift.CustomizableEdges = customizableEdges21;
            cmbShift.DrawMode = DrawMode.OwnerDrawFixed;
            cmbShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShift.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbShift.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbShift.Font = new Font("Segoe UI", 10.2F);
            cmbShift.ForeColor = Color.Black;
            cmbShift.ItemHeight = 39;
            cmbShift.Location = new Point(530, 201);
            cmbShift.Name = "cmbShift";
            cmbShift.ShadowDecoration.CustomizableEdges = customizableEdges22;
            cmbShift.Size = new Size(450, 45);
            cmbShift.TabIndex = 8;
            // 
            // lblEditShift
            // 
            lblEditShift.AutoSize = true;
            lblEditShift.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditShift.Location = new Point(530, 171);
            lblEditShift.Name = "lblEditShift";
            lblEditShift.Size = new Size(71, 25);
            lblEditShift.TabIndex = 7;
            lblEditShift.Text = "Ca học";
            // 
            // cmbTeacher
            // 
            cmbTeacher.BackColor = Color.Transparent;
            cmbTeacher.BorderRadius = 8;
            cmbTeacher.CustomizableEdges = customizableEdges23;
            cmbTeacher.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeacher.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbTeacher.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbTeacher.Font = new Font("Segoe UI", 10.2F);
            cmbTeacher.ForeColor = Color.Black;
            cmbTeacher.ItemHeight = 39;
            cmbTeacher.Location = new Point(40, 201);
            cmbTeacher.Name = "cmbTeacher";
            cmbTeacher.ShadowDecoration.CustomizableEdges = customizableEdges24;
            cmbTeacher.Size = new Size(450, 45);
            cmbTeacher.TabIndex = 6;
            // 
            // lblEditTeacher
            // 
            lblEditTeacher.AutoSize = true;
            lblEditTeacher.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditTeacher.Location = new Point(40, 171);
            lblEditTeacher.Name = "lblEditTeacher";
            lblEditTeacher.Size = new Size(107, 25);
            lblEditTeacher.TabIndex = 5;
            lblEditTeacher.Text = "Giảng viên";
            // 
            // cmbCourse
            // 
            cmbCourse.BackColor = Color.Transparent;
            cmbCourse.BorderRadius = 8;
            cmbCourse.CustomizableEdges = customizableEdges25;
            cmbCourse.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCourse.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCourse.Font = new Font("Segoe UI", 10.2F);
            cmbCourse.ForeColor = Color.Black;
            cmbCourse.ItemHeight = 39;
            cmbCourse.Location = new Point(530, 91);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.ShadowDecoration.CustomizableEdges = customizableEdges26;
            cmbCourse.Size = new Size(450, 45);
            cmbCourse.TabIndex = 4;
            // 
            // lblEditCourse
            // 
            lblEditCourse.AutoSize = true;
            lblEditCourse.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditCourse.Location = new Point(530, 61);
            lblEditCourse.Name = "lblEditCourse";
            lblEditCourse.Size = new Size(94, 25);
            lblEditCourse.TabIndex = 3;
            lblEditCourse.Text = "Khóa học";
            // 
            // txtClassName
            // 
            txtClassName.BorderRadius = 8;
            txtClassName.Cursor = Cursors.IBeam;
            txtClassName.CustomizableEdges = customizableEdges27;
            txtClassName.DefaultText = "";
            txtClassName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtClassName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtClassName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtClassName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtClassName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtClassName.Font = new Font("Segoe UI", 10.2F);
            txtClassName.ForeColor = Color.Black;
            txtClassName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtClassName.Location = new Point(40, 91);
            txtClassName.Margin = new Padding(3, 4, 3, 4);
            txtClassName.Name = "txtClassName";
            txtClassName.PlaceholderText = "Nhập tên lớp học";
            txtClassName.SelectedText = "";
            txtClassName.ShadowDecoration.CustomizableEdges = customizableEdges28;
            txtClassName.Size = new Size(450, 45);
            txtClassName.TabIndex = 2;
            // 
            // lblEditClassName
            // 
            lblEditClassName.AutoSize = true;
            lblEditClassName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditClassName.Location = new Point(40, 61);
            lblEditClassName.Name = "lblEditClassName";
            lblEditClassName.Size = new Size(114, 25);
            lblEditClassName.TabIndex = 1;
            lblEditClassName.Text = "Tên lớp học";
            // 
            // pnlEditHeader
            // 
            pnlEditHeader.BackColor = Color.FromArgb(94, 148, 255);
            pnlEditHeader.BorderRadius = 8;
            pnlEditHeader.Controls.Add(lblEditTitle);
            pnlEditHeader.CustomizableEdges = customizableEdges29;
            pnlEditHeader.Dock = DockStyle.Top;
            pnlEditHeader.Location = new Point(0, 0);
            pnlEditHeader.Name = "pnlEditHeader";
            pnlEditHeader.ShadowDecoration.CustomizableEdges = customizableEdges30;
            pnlEditHeader.Size = new Size(1046, 50);
            pnlEditHeader.TabIndex = 0;
            // 
            // lblEditTitle
            // 
            lblEditTitle.AutoSize = true;
            lblEditTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblEditTitle.ForeColor = Color.White;
            lblEditTitle.Location = new Point(20, 7);
            lblEditTitle.Name = "lblEditTitle";
            lblEditTitle.Size = new Size(258, 37);
            lblEditTitle.TabIndex = 0;
            lblEditTitle.Text = "Chỉnh Sửa Lớp Học";
            // 
            // lblEditDays
            // 
            lblEditDays.AutoSize = true;
            lblEditDays.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditDays.Location = new Point(530, 489);
            lblEditDays.Name = "lblEditDays";
            lblEditDays.Size = new Size(161, 25);
            lblEditDays.TabIndex = 30;
            lblEditDays.Text = "Ngày trong tuần";
            // 
            // pnlDaysContainer
            // 
            pnlDaysContainer.Controls.Add(btnMon);
            pnlDaysContainer.Controls.Add(btnTue);
            pnlDaysContainer.Controls.Add(btnWed);
            pnlDaysContainer.Controls.Add(btnThu);
            pnlDaysContainer.Controls.Add(btnFri);
            pnlDaysContainer.Controls.Add(btnSat);
            pnlDaysContainer.Controls.Add(btnSun);
            pnlDaysContainer.Location = new Point(531, 519);
            pnlDaysContainer.Name = "pnlDaysContainer";
            pnlDaysContainer.Size = new Size(490, 61);
            pnlDaysContainer.TabIndex = 31;
            // 
            // btnMon
            // 
            btnMon.BorderRadius = 15;
            btnMon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnMon.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnMon.CheckedState.ForeColor = Color.White;
            btnMon.CustomizableEdges = customizableEdges31;
            btnMon.FillColor = Color.WhiteSmoke;
            btnMon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMon.ForeColor = Color.Black;
            btnMon.Location = new Point(10, 10);
            btnMon.Margin = new Padding(10);
            btnMon.Name = "btnMon";
            btnMon.ShadowDecoration.CustomizableEdges = customizableEdges32;
            btnMon.Size = new Size(50, 40);
            btnMon.TabIndex = 0;
            btnMon.Tag = "Monday";
            btnMon.Text = "T2";
            // 
            // btnTue
            // 
            btnTue.BorderRadius = 15;
            btnTue.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnTue.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnTue.CheckedState.ForeColor = Color.White;
            btnTue.CustomizableEdges = customizableEdges33;
            btnTue.FillColor = Color.WhiteSmoke;
            btnTue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTue.ForeColor = Color.Black;
            btnTue.Location = new Point(80, 10);
            btnTue.Margin = new Padding(10);
            btnTue.Name = "btnTue";
            btnTue.ShadowDecoration.CustomizableEdges = customizableEdges34;
            btnTue.Size = new Size(50, 40);
            btnTue.TabIndex = 1;
            btnTue.Tag = "Tuesday";
            btnTue.Text = "T3";
            // 
            // btnWed
            // 
            btnWed.BorderRadius = 15;
            btnWed.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnWed.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnWed.CheckedState.ForeColor = Color.White;
            btnWed.CustomizableEdges = customizableEdges35;
            btnWed.FillColor = Color.WhiteSmoke;
            btnWed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnWed.ForeColor = Color.Black;
            btnWed.Location = new Point(150, 10);
            btnWed.Margin = new Padding(10);
            btnWed.Name = "btnWed";
            btnWed.ShadowDecoration.CustomizableEdges = customizableEdges36;
            btnWed.Size = new Size(50, 40);
            btnWed.TabIndex = 2;
            btnWed.Tag = "Wednesday";
            btnWed.Text = "T4";
            // 
            // btnThu
            // 
            btnThu.BorderRadius = 15;
            btnThu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnThu.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnThu.CheckedState.ForeColor = Color.White;
            btnThu.CustomizableEdges = customizableEdges37;
            btnThu.FillColor = Color.WhiteSmoke;
            btnThu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThu.ForeColor = Color.Black;
            btnThu.Location = new Point(220, 10);
            btnThu.Margin = new Padding(10);
            btnThu.Name = "btnThu";
            btnThu.ShadowDecoration.CustomizableEdges = customizableEdges38;
            btnThu.Size = new Size(50, 40);
            btnThu.TabIndex = 3;
            btnThu.Tag = "Thursday";
            btnThu.Text = "T5";
            // 
            // btnFri
            // 
            btnFri.BorderRadius = 15;
            btnFri.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnFri.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnFri.CheckedState.ForeColor = Color.White;
            btnFri.CustomizableEdges = customizableEdges39;
            btnFri.FillColor = Color.WhiteSmoke;
            btnFri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFri.ForeColor = Color.Black;
            btnFri.Location = new Point(290, 10);
            btnFri.Margin = new Padding(10);
            btnFri.Name = "btnFri";
            btnFri.ShadowDecoration.CustomizableEdges = customizableEdges40;
            btnFri.Size = new Size(50, 40);
            btnFri.TabIndex = 4;
            btnFri.Tag = "Friday";
            btnFri.Text = "T6";
            // 
            // btnSat
            // 
            btnSat.BorderRadius = 15;
            btnSat.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnSat.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnSat.CheckedState.ForeColor = Color.White;
            btnSat.CustomizableEdges = customizableEdges41;
            btnSat.FillColor = Color.WhiteSmoke;
            btnSat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSat.ForeColor = Color.Black;
            btnSat.Location = new Point(360, 10);
            btnSat.Margin = new Padding(10);
            btnSat.Name = "btnSat";
            btnSat.ShadowDecoration.CustomizableEdges = customizableEdges42;
            btnSat.Size = new Size(50, 40);
            btnSat.TabIndex = 5;
            btnSat.Tag = "Saturday";
            btnSat.Text = "T7";
            // 
            // btnSun
            // 
            btnSun.BorderRadius = 15;
            btnSun.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            btnSun.CheckedState.FillColor = Color.FromArgb(46, 204, 113);
            btnSun.CheckedState.ForeColor = Color.White;
            btnSun.CustomizableEdges = customizableEdges43;
            btnSun.FillColor = Color.WhiteSmoke;
            btnSun.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSun.ForeColor = Color.Black;
            btnSun.Location = new Point(430, 10);
            btnSun.Margin = new Padding(10);
            btnSun.Name = "btnSun";
            btnSun.ShadowDecoration.CustomizableEdges = customizableEdges44;
            btnSun.Size = new Size(50, 40);
            btnSun.TabIndex = 6;
            btnSun.Tag = "Sunday";
            btnSun.Text = "CN";
            // 
            // ClassDetailControl
            // 
            BackColor = Color.FromArgb(245, 247, 251);
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Name = "ClassDetailControl";
            Size = new Size(1480, 850);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            grpGeneral.ResumeLayout(false);
            grpGeneral.PerformLayout();
            grpTeacher.ResumeLayout(false);
            grpTeacher.PerformLayout();
            grpStats.ResumeLayout(false);
            pnlProgressBg.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            TabControls.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            pnlEditContainer.ResumeLayout(false);
            pnlEditContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxStudent).EndInit();
            pnlEditHeader.ResumeLayout(false);
            pnlEditHeader.PerformLayout();
            pnlDaysContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupLabelPair(Control parent, Label lblTitle, string titleText, Label lblValue, string valueText, int yPos)
        {
            lblTitle.Text = titleText;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.Location = new Point(20, yPos);
            lblTitle.AutoSize = true;

            lblValue.Text = valueText;
            lblValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValue.ForeColor = Color.Black;
            lblValue.Location = new Point(110, yPos);
            lblValue.AutoSize = true;

            parent.Controls.Add(lblTitle);
            parent.Controls.Add(lblValue);
        }

        private Label label3;
        private Label label2;
        private Label lblPhoneNumber;
        private Label lblNote;
        private Label label4;
        private Label label1;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblShift;
        private Label label5;
        private DataGridView dgvStudents;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDob;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnAddStudent;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label6;
        private Guna.UI2.WinForms.Guna2TabControl TabControls;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lblErrorEndDate;
        private Label lblErrorStartDate;
        private Label lblErrorClassName;
        private Label lblErrorDayofWeek;
        private Label lblEstimate;
    }
}