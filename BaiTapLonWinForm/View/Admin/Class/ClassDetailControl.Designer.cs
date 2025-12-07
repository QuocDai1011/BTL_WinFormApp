namespace BaiTapLonWinForm.View.Admin.Class
{
    partial class ClassDetailControl
    {
        private System.ComponentModel.IContainer components = null;

        // --- CONTROLS ---

        // 1. Header Container
        private Panel pnlHeader;
        private Label lblClassName;
        private Label lblStatusBadge;
        private Button btnAddStudent; // Nút thêm nhanh học viên

        // 2. Sidebar (Left)
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

        // 3. Main Content (Right)
        private Panel pnlMain;
        private Label lblListTitle;
        private DataGridView dgvStudents; // Bảng danh sách học viên
        private Panel pnlStatsHeader; // Chứa các thẻ thống kê nhỏ (nếu cần)

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblCourseName = new Label();
            lblClassName = new Label();
            lblStatusBadge = new Label();
            btnDelete = new Button();
            btnAddStudent = new Button();
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
            lblProportion = new Label();
            dgvStudents = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colDob = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            lblListTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            grpGeneral.SuspendLayout();
            grpTeacher.SuspendLayout();
            grpStats.SuspendLayout();
            pnlProgressBg.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblCourseName);
            pnlHeader.Controls.Add(lblClassName);
            pnlHeader.Controls.Add(lblStatusBadge);
            pnlHeader.Controls.Add(btnDelete);
            pnlHeader.Controls.Add(btnAddStudent);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(30, 10, 30, 10);
            pnlHeader.Size = new Size(1480, 100);
            pnlHeader.TabIndex = 2;
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblCourseName.ForeColor = Color.FromArgb(40, 40, 40);
            lblCourseName.Location = new Point(33, 66);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(155, 31);
            lblCourseName.TabIndex = 6;
            lblCourseName.Text = "Tên khóa học";
            // 
            // lblClassName
            // 
            lblClassName.AutoSize = true;
            lblClassName.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblClassName.ForeColor = Color.FromArgb(40, 40, 40);
            lblClassName.Location = new Point(25, 7);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(254, 54);
            lblClassName.TabIndex = 0;
            lblClassName.Text = "Tên Lớp Học";
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.BackColor = Color.SeaGreen;
            lblStatusBadge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusBadge.ForeColor = Color.White;
            lblStatusBadge.Location = new Point(280, 67);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Size = new Size(120, 30);
            lblStatusBadge.TabIndex = 2;
            lblStatusBadge.Text = "Active";
            lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1311, 30);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xóa Học Viên";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.SeaGreen;
            btnAddStudent.Cursor = Cursors.Hand;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(1145, 30);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(150, 40);
            btnAddStudent.TabIndex = 5;
            btnAddStudent.Text = "+ Thêm Học Viên";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.Controls.Add(grpGeneral);
            pnlSidebar.Controls.Add(grpTeacher);
            pnlSidebar.Controls.Add(grpStats);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 100);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(20);
            pnlSidebar.Size = new Size(400, 750);
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
            grpGeneral.Location = new Point(20, 20);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new Size(360, 251);
            grpGeneral.TabIndex = 0;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "Thông Tin Vận Hành";
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
            lblRoomTitle.Size = new Size(101, 23);
            lblRoomTitle.TabIndex = 0;
            lblRoomTitle.Text = "Phòng/Link:";
            // 
            // lnkOnlineLink
            // 
            lnkOnlineLink.AutoSize = true;
            lnkOnlineLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lnkOnlineLink.Location = new Point(115, 199);
            lnkOnlineLink.Name = "lnkOnlineLink";
            lnkOnlineLink.Size = new Size(31, 23);
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
            grpTeacher.Text = "Giáo Viên Phụ Trách";
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
            grpStats.Text = "Sĩ Số & Ghi Chú";
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
            pnlMain.Controls.Add(lblProportion);
            pnlMain.Controls.Add(dgvStudents);
            pnlMain.Controls.Add(lblListTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(400, 100);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(1080, 750);
            pnlMain.TabIndex = 0;
            // 
            // lblProportion
            // 
            lblProportion.AutoSize = true;
            lblProportion.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblProportion.ForeColor = Color.Black;
            lblProportion.Location = new Point(945, 27);
            lblProportion.Name = "lblProportion";
            lblProportion.Size = new Size(31, 23);
            lblProportion.TabIndex = 2;
            lblProportion.Text = "---";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
            dgvStudents.Location = new Point(20, 70);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 40;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1040, 660);
            dgvStudents.TabIndex = 0;
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
            // lblListTitle
            // 
            lblListTitle.Dock = DockStyle.Top;
            lblListTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblListTitle.Location = new Point(20, 20);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(1040, 50);
            lblListTitle.TabIndex = 1;
            lblListTitle.Text = "Danh Sách Học Viên";
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
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        // Helper để tạo label nhanh
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
        private Label lblCourseName;
        private Button btnDelete;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDob;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private Label lblProportion;
    }
}
