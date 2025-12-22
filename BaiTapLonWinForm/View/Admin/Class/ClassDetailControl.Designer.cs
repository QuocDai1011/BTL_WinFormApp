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
        private Guna.UI2.WinForms.Guna2Button btnResetForm;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges33 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges34 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
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
            btnResetForm = new Guna.UI2.WinForms.Guna2Button();
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
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            grpGeneral.SuspendLayout();
            grpTeacher.SuspendLayout();
            grpStats.SuspendLayout();
            pnlProgressBg.SuspendLayout();
            pnlMain.SuspendLayout();
            guna2TabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            guna2Panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlEditContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxStudent).BeginInit();
            pnlEditHeader.SuspendLayout();
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
            lblClassAndCouse.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblClassAndCouse.ForeColor = Color.White;
            lblClassAndCouse.Location = new Point(20, 10);
            lblClassAndCouse.Name = "lblClassAndCouse";
            lblClassAndCouse.Size = new Size(191, 41);
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
            grpGeneral.Location = new Point(20, 6);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new Size(360, 285);
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
            lblShift.Location = new Point(95, 49);
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
            label5.Location = new Point(13, 49);
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
            lblRoomTitle.Location = new Point(13, 199);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(44, 23);
            lblRoomTitle.TabIndex = 0;
            lblRoomTitle.Text = "Link:";
            // 
            // lnkOnlineLink
            // 
            lnkOnlineLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lnkOnlineLink.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkOnlineLink.Location = new Point(63, 199);
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
            grpTeacher.Location = new Point(20, 297);
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
            grpStats.Location = new Point(20, 481);
            grpStats.Name = "grpStats";
            grpStats.Size = new Size(360, 229);
            grpStats.TabIndex = 2;
            grpStats.TabStop = false;
            grpStats.Text = "Sĩ Số Ghi Chú";
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Segoe UI", 10F);
            lblNote.Location = new Point(20, 155);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(31, 23);
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
            pnlMain.Controls.Add(guna2TabControl1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(400, 61);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.Size = new Size(1080, 789);
            pnlMain.TabIndex = 0;
            // 
            // guna2TabControl1
            // 
            guna2TabControl1.Controls.Add(tabPage1);
            guna2TabControl1.Controls.Add(tabPage2);
            guna2TabControl1.Dock = DockStyle.Fill;
            guna2TabControl1.ItemSize = new Size(180, 50);
            guna2TabControl1.Location = new Point(10, 10);
            guna2TabControl1.Margin = new Padding(0);
            guna2TabControl1.Name = "guna2TabControl1";
            guna2TabControl1.Padding = new Point(0, 0);
            guna2TabControl1.SelectedIndex = 0;
            guna2TabControl1.Size = new Size(1060, 769);
            guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(240, 240, 240);
            guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonHoverState.ForeColor = Color.Black;
            guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(240, 240, 240);
            guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonIdleState.FillColor = Color.Transparent;
            guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            guna2TabControl1.TabButtonIdleState.InnerColor = Color.Transparent;
            guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            guna2TabControl1.TabButtonSelectedState.FillColor = Color.Transparent;
            guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            guna2TabControl1.TabButtonSelectedState.ForeColor = Color.FromArgb(53, 41, 123);
            guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            guna2TabControl1.TabButtonSize = new Size(180, 50);
            guna2TabControl1.TabIndex = 0;
            guna2TabControl1.TabMenuBackColor = Color.White;
            guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
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
            btnAddStudent.Location = new Point(667, 619);
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
            btnDelete.Location = new Point(865, 619);
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
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(3, 59);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 40;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1046, 649);
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
            guna2Panel1.Size = new Size(1046, 56);
            guna2Panel1.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(20, 9);
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
            pnlEditContainer.Controls.Add(btnResetForm);
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
            pnlEditContainer.CustomizableEdges = customizableEdges33;
            pnlEditContainer.Dock = DockStyle.Fill;
            pnlEditContainer.Location = new Point(3, 3);
            pnlEditContainer.Name = "pnlEditContainer";
            pnlEditContainer.ShadowDecoration.CustomizableEdges = customizableEdges34;
            pnlEditContainer.Size = new Size(1046, 705);
            pnlEditContainer.TabIndex = 0;
            // 
            // btnResetForm
            // 
            btnResetForm.BorderColor = Color.FromArgb(94, 148, 255);
            btnResetForm.BorderRadius = 8;
            btnResetForm.BorderThickness = 2;
            btnResetForm.CustomizableEdges = customizableEdges7;
            btnResetForm.DisabledState.BorderColor = Color.DarkGray;
            btnResetForm.DisabledState.CustomBorderColor = Color.DarkGray;
            btnResetForm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnResetForm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnResetForm.FillColor = Color.White;
            btnResetForm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnResetForm.ForeColor = Color.FromArgb(94, 148, 255);
            btnResetForm.Location = new Point(540, 630);
            btnResetForm.Name = "btnResetForm";
            btnResetForm.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnResetForm.Size = new Size(150, 50);
            btnResetForm.TabIndex = 23;
            btnResetForm.Text = "🔄 Khôi Phục";
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.BorderRadius = 8;
            btnCancelEdit.CustomizableEdges = customizableEdges9;
            btnCancelEdit.DisabledState.BorderColor = Color.DarkGray;
            btnCancelEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancelEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancelEdit.FillColor = Color.FromArgb(231, 76, 60);
            btnCancelEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelEdit.ForeColor = Color.White;
            btnCancelEdit.Location = new Point(890, 630);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnCancelEdit.Size = new Size(130, 50);
            btnCancelEdit.TabIndex = 22;
            btnCancelEdit.Text = "✖ Hủy";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BorderRadius = 8;
            btnSaveChanges.CustomizableEdges = customizableEdges11;
            btnSaveChanges.DisabledState.BorderColor = Color.DarkGray;
            btnSaveChanges.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSaveChanges.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSaveChanges.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSaveChanges.FillColor = Color.FromArgb(46, 204, 113);
            btnSaveChanges.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(700, 630);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSaveChanges.Size = new Size(180, 50);
            btnSaveChanges.TabIndex = 21;
            btnSaveChanges.Text = "💾 Lưu Thay Đổi";
            // 
            // txtNote
            // 
            txtNote.BorderRadius = 8;
            txtNote.Cursor = Cursors.IBeam;
            txtNote.CustomizableEdges = customizableEdges13;
            txtNote.DefaultText = "";
            txtNote.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNote.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNote.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNote.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNote.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNote.Font = new Font("Segoe UI", 10.2F);
            txtNote.ForeColor = Color.Black;
            txtNote.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNote.Location = new Point(40, 520);
            txtNote.Margin = new Padding(3, 4, 3, 4);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Nhập ghi chú về lớp học...";
            txtNote.SelectedText = "";
            txtNote.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtNote.Size = new Size(450, 100);
            txtNote.TabIndex = 18;
            // 
            // lblEditNote
            // 
            lblEditNote.AutoSize = true;
            lblEditNote.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditNote.Location = new Point(40, 490);
            lblEditNote.Name = "lblEditNote";
            lblEditNote.Size = new Size(142, 25);
            lblEditNote.TabIndex = 17;
            lblEditNote.Text = "Ghi chú nội bộ";
            // 
            // txtOnlineLink
            // 
            txtOnlineLink.BorderRadius = 8;
            txtOnlineLink.Cursor = Cursors.IBeam;
            txtOnlineLink.CustomizableEdges = customizableEdges15;
            txtOnlineLink.DefaultText = "";
            txtOnlineLink.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtOnlineLink.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtOnlineLink.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtOnlineLink.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtOnlineLink.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOnlineLink.Font = new Font("Segoe UI", 10.2F);
            txtOnlineLink.ForeColor = Color.Black;
            txtOnlineLink.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtOnlineLink.Location = new Point(530, 420);
            txtOnlineLink.Margin = new Padding(3, 4, 3, 4);
            txtOnlineLink.Name = "txtOnlineLink";
            txtOnlineLink.PlaceholderText = "https://meet.google.com/...";
            txtOnlineLink.SelectedText = "";
            txtOnlineLink.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtOnlineLink.Size = new Size(450, 45);
            txtOnlineLink.TabIndex = 16;
            // 
            // lblEditOnlineLink
            // 
            lblEditOnlineLink.AutoSize = true;
            lblEditOnlineLink.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditOnlineLink.Location = new Point(530, 390);
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
            numMaxStudent.CustomizableEdges = customizableEdges17;
            numMaxStudent.Font = new Font("Segoe UI", 10.2F);
            numMaxStudent.Location = new Point(40, 420);
            numMaxStudent.Margin = new Padding(3, 4, 3, 4);
            numMaxStudent.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numMaxStudent.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxStudent.Name = "numMaxStudent";
            numMaxStudent.ShadowDecoration.CustomizableEdges = customizableEdges18;
            numMaxStudent.Size = new Size(450, 45);
            numMaxStudent.TabIndex = 14;
            numMaxStudent.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblEditMaxStudent
            // 
            lblEditMaxStudent.AutoSize = true;
            lblEditMaxStudent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditMaxStudent.Location = new Point(40, 390);
            lblEditMaxStudent.Name = "lblEditMaxStudent";
            lblEditMaxStudent.Size = new Size(109, 25);
            lblEditMaxStudent.TabIndex = 13;
            lblEditMaxStudent.Text = "Sĩ số tối đa";
            // 
            // dtpEndDate
            // 
            dtpEndDate.BorderRadius = 8;
            dtpEndDate.Checked = true;
            dtpEndDate.CustomizableEdges = customizableEdges19;
            dtpEndDate.FillColor = Color.White;
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(530, 320);
            dtpEndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpEndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.ShadowDecoration.CustomizableEdges = customizableEdges20;
            dtpEndDate.Size = new Size(450, 45);
            dtpEndDate.TabIndex = 12;
            dtpEndDate.Value = new DateTime(2025, 12, 22, 21, 8, 8, 845);
            // 
            // lblEditEndDate
            // 
            lblEditEndDate.AutoSize = true;
            lblEditEndDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditEndDate.Location = new Point(530, 290);
            lblEditEndDate.Name = "lblEditEndDate";
            lblEditEndDate.Size = new Size(136, 25);
            lblEditEndDate.TabIndex = 11;
            lblEditEndDate.Text = "Ngày kết thúc";
            // 
            // dtpStartDate
            // 
            dtpStartDate.BorderRadius = 8;
            dtpStartDate.Checked = true;
            dtpStartDate.CustomizableEdges = customizableEdges21;
            dtpStartDate.FillColor = Color.White;
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(40, 320);
            dtpStartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpStartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.ShadowDecoration.CustomizableEdges = customizableEdges22;
            dtpStartDate.Size = new Size(450, 45);
            dtpStartDate.TabIndex = 10;
            dtpStartDate.Value = new DateTime(2025, 12, 22, 21, 8, 8, 875);
            // 
            // lblEditStartDate
            // 
            lblEditStartDate.AutoSize = true;
            lblEditStartDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditStartDate.Location = new Point(40, 290);
            lblEditStartDate.Name = "lblEditStartDate";
            lblEditStartDate.Size = new Size(132, 25);
            lblEditStartDate.TabIndex = 9;
            lblEditStartDate.Text = "Ngày bắt đầu";
            // 
            // cmbShift
            // 
            cmbShift.BackColor = Color.Transparent;
            cmbShift.BorderRadius = 8;
            cmbShift.CustomizableEdges = customizableEdges23;
            cmbShift.DrawMode = DrawMode.OwnerDrawFixed;
            cmbShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShift.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbShift.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbShift.Font = new Font("Segoe UI", 10.2F);
            cmbShift.ForeColor = Color.Black;
            cmbShift.ItemHeight = 39;
            cmbShift.Location = new Point(530, 220);
            cmbShift.Name = "cmbShift";
            cmbShift.ShadowDecoration.CustomizableEdges = customizableEdges24;
            cmbShift.Size = new Size(450, 45);
            cmbShift.TabIndex = 8;
            // 
            // lblEditShift
            // 
            lblEditShift.AutoSize = true;
            lblEditShift.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditShift.Location = new Point(530, 190);
            lblEditShift.Name = "lblEditShift";
            lblEditShift.Size = new Size(71, 25);
            lblEditShift.TabIndex = 7;
            lblEditShift.Text = "Ca học";
            // 
            // cmbTeacher
            // 
            cmbTeacher.BackColor = Color.Transparent;
            cmbTeacher.BorderRadius = 8;
            cmbTeacher.CustomizableEdges = customizableEdges25;
            cmbTeacher.DrawMode = DrawMode.OwnerDrawFixed;
            cmbTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeacher.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbTeacher.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbTeacher.Font = new Font("Segoe UI", 10.2F);
            cmbTeacher.ForeColor = Color.Black;
            cmbTeacher.ItemHeight = 39;
            cmbTeacher.Location = new Point(40, 220);
            cmbTeacher.Name = "cmbTeacher";
            cmbTeacher.ShadowDecoration.CustomizableEdges = customizableEdges26;
            cmbTeacher.Size = new Size(450, 45);
            cmbTeacher.TabIndex = 6;
            // 
            // lblEditTeacher
            // 
            lblEditTeacher.AutoSize = true;
            lblEditTeacher.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditTeacher.Location = new Point(40, 190);
            lblEditTeacher.Name = "lblEditTeacher";
            lblEditTeacher.Size = new Size(107, 25);
            lblEditTeacher.TabIndex = 5;
            lblEditTeacher.Text = "Giảng viên";
            // 
            // cmbCourse
            // 
            cmbCourse.BackColor = Color.Transparent;
            cmbCourse.BorderRadius = 8;
            cmbCourse.CustomizableEdges = customizableEdges27;
            cmbCourse.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCourse.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCourse.Font = new Font("Segoe UI", 10.2F);
            cmbCourse.ForeColor = Color.Black;
            cmbCourse.ItemHeight = 39;
            cmbCourse.Location = new Point(530, 120);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.ShadowDecoration.CustomizableEdges = customizableEdges28;
            cmbCourse.Size = new Size(450, 45);
            cmbCourse.TabIndex = 4;
            // 
            // lblEditCourse
            // 
            lblEditCourse.AutoSize = true;
            lblEditCourse.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditCourse.Location = new Point(530, 90);
            lblEditCourse.Name = "lblEditCourse";
            lblEditCourse.Size = new Size(94, 25);
            lblEditCourse.TabIndex = 3;
            lblEditCourse.Text = "Khóa học";
            // 
            // txtClassName
            // 
            txtClassName.BorderRadius = 8;
            txtClassName.Cursor = Cursors.IBeam;
            txtClassName.CustomizableEdges = customizableEdges29;
            txtClassName.DefaultText = "";
            txtClassName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtClassName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtClassName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtClassName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtClassName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtClassName.Font = new Font("Segoe UI", 10.2F);
            txtClassName.ForeColor = Color.Black;
            txtClassName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtClassName.Location = new Point(40, 120);
            txtClassName.Margin = new Padding(3, 4, 3, 4);
            txtClassName.Name = "txtClassName";
            txtClassName.PlaceholderText = "Nhập tên lớp học";
            txtClassName.SelectedText = "";
            txtClassName.ShadowDecoration.CustomizableEdges = customizableEdges30;
            txtClassName.Size = new Size(450, 45);
            txtClassName.TabIndex = 2;
            // 
            // lblEditClassName
            // 
            lblEditClassName.AutoSize = true;
            lblEditClassName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditClassName.Location = new Point(40, 90);
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
            pnlEditHeader.CustomizableEdges = customizableEdges31;
            pnlEditHeader.Dock = DockStyle.Top;
            pnlEditHeader.Location = new Point(0, 0);
            pnlEditHeader.Name = "pnlEditHeader";
            pnlEditHeader.ShadowDecoration.CustomizableEdges = customizableEdges32;
            pnlEditHeader.Size = new Size(1046, 60);
            pnlEditHeader.TabIndex = 0;
            // 
            // lblEditTitle
            // 
            lblEditTitle.AutoSize = true;
            lblEditTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblEditTitle.ForeColor = Color.White;
            lblEditTitle.Location = new Point(20, 14);
            lblEditTitle.Name = "lblEditTitle";
            lblEditTitle.Size = new Size(258, 37);
            lblEditTitle.TabIndex = 0;
            lblEditTitle.Text = "Chỉnh Sửa Lớp Học";
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
            grpStats.PerformLayout();
            pnlProgressBg.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            guna2TabControl1.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}