namespace BaiTapLonWinForm.View.Admin.Students
{
    partial class FaceAttendance
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            panelLeft = new Panel();
            lblRecognitionStatus = new Label();
            groupBoxStats = new GroupBox();
            lblAttendanceRate = new Label();
            lblAttendanceRateTitle = new Label();
            lblTotalPresent = new Label();
            lblTotalPresentTitle = new Label();
            groupBoxCamera = new GroupBox();
            lblCameraStatus = new Label();
            chkAutoRecognize = new CheckBox();
            btnRecognize = new Button();
            panelCamera = new Panel();
            picCamera = new PictureBox();
            lblCamera = new Label();
            cboCamera = new ComboBox();
            lblSelectCamera = new Label();
            btnStartCamera = new Button();
            panelRight = new Panel();
            groupBoxAttendance = new GroupBox();
            panelNotification = new Panel();
            lblNotificationMessage = new Label();
            lblNotificationTitle = new Label();
            dgvStudentAttendance = new Guna.UI2.WinForms.Guna2DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colShift = new DataGridViewTextBoxColumn();
            colConfidence = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            panelBottom = new Panel();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            groupBoxStats.SuspendLayout();
            groupBoxCamera.SuspendLayout();
            panelCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            panelRight.SuspendLayout();
            groupBoxAttendance.SuspendLayout();
            panelNotification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentAttendance).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(41, 128, 185);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1400, 80);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(19, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(531, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👤 ĐIỂM DANH BẰNG KHUÔN MẶT";
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(lblRecognitionStatus);
            panelLeft.Controls.Add(groupBoxStats);
            panelLeft.Controls.Add(groupBoxCamera);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 80);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(15);
            panelLeft.Size = new Size(550, 670);
            panelLeft.TabIndex = 1;
            // 
            // lblRecognitionStatus
            // 
            lblRecognitionStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecognitionStatus.ForeColor = Color.FromArgb(149, 165, 166);
            lblRecognitionStatus.Location = new Point(36, 498);
            lblRecognitionStatus.Name = "lblRecognitionStatus";
            lblRecognitionStatus.Size = new Size(480, 23);
            lblRecognitionStatus.TabIndex = 7;
            lblRecognitionStatus.Text = "⏸️ Chế độ thủ công";
            lblRecognitionStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBoxStats
            // 
            groupBoxStats.Controls.Add(lblAttendanceRate);
            groupBoxStats.Controls.Add(lblAttendanceRateTitle);
            groupBoxStats.Controls.Add(lblTotalPresent);
            groupBoxStats.Controls.Add(lblTotalPresentTitle);
            groupBoxStats.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxStats.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxStats.Location = new Point(15, 524);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Size = new Size(520, 140);
            groupBoxStats.TabIndex = 1;
            groupBoxStats.TabStop = false;
            groupBoxStats.Text = "📊 Thống kê";
            // 
            // lblAttendanceRate
            // 
            lblAttendanceRate.AutoSize = true;
            lblAttendanceRate.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAttendanceRate.ForeColor = Color.FromArgb(52, 152, 219);
            lblAttendanceRate.Location = new Point(300, 65);
            lblAttendanceRate.Name = "lblAttendanceRate";
            lblAttendanceRate.Size = new Size(81, 54);
            lblAttendanceRate.TabIndex = 3;
            lblAttendanceRate.Text = "0%";
            // 
            // lblAttendanceRateTitle
            // 
            lblAttendanceRateTitle.AutoSize = true;
            lblAttendanceRateTitle.Font = new Font("Segoe UI", 10F);
            lblAttendanceRateTitle.Location = new Point(300, 40);
            lblAttendanceRateTitle.Name = "lblAttendanceRateTitle";
            lblAttendanceRateTitle.Size = new Size(107, 23);
            lblAttendanceRateTitle.TabIndex = 2;
            lblAttendanceRateTitle.Text = "Tỷ lệ có mặt:";
            // 
            // lblTotalPresent
            // 
            lblTotalPresent.AutoSize = true;
            lblTotalPresent.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalPresent.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalPresent.Location = new Point(30, 65);
            lblTotalPresent.Name = "lblTotalPresent";
            lblTotalPresent.Size = new Size(46, 54);
            lblTotalPresent.TabIndex = 1;
            lblTotalPresent.Text = "0";
            // 
            // lblTotalPresentTitle
            // 
            lblTotalPresentTitle.AutoSize = true;
            lblTotalPresentTitle.Font = new Font("Segoe UI", 10F);
            lblTotalPresentTitle.Location = new Point(30, 40);
            lblTotalPresentTitle.Name = "lblTotalPresentTitle";
            lblTotalPresentTitle.Size = new Size(160, 23);
            lblTotalPresentTitle.TabIndex = 0;
            lblTotalPresentTitle.Text = "Số học viên có mặt:";
            // 
            // groupBoxCamera
            // 
            groupBoxCamera.Controls.Add(lblCameraStatus);
            groupBoxCamera.Controls.Add(chkAutoRecognize);
            groupBoxCamera.Controls.Add(btnRecognize);
            groupBoxCamera.Controls.Add(panelCamera);
            groupBoxCamera.Controls.Add(cboCamera);
            groupBoxCamera.Controls.Add(lblSelectCamera);
            groupBoxCamera.Controls.Add(btnStartCamera);
            groupBoxCamera.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxCamera.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxCamera.Location = new Point(15, 15);
            groupBoxCamera.Name = "groupBoxCamera";
            groupBoxCamera.Padding = new Padding(15);
            groupBoxCamera.Size = new Size(520, 480);
            groupBoxCamera.TabIndex = 0;
            groupBoxCamera.TabStop = false;
            groupBoxCamera.Text = "📸 Camera nhận diện";
            // 
            // lblCameraStatus
            // 
            lblCameraStatus.AutoSize = true;
            lblCameraStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCameraStatus.ForeColor = Color.FromArgb(149, 165, 166);
            lblCameraStatus.Location = new Point(20, 400);
            lblCameraStatus.Name = "lblCameraStatus";
            lblCameraStatus.Size = new Size(150, 20);
            lblCameraStatus.TabIndex = 6;
            lblCameraStatus.Text = "⏹️ Camera đã dừng";
            // 
            // chkAutoRecognize
            // 
            chkAutoRecognize.AutoSize = true;
            chkAutoRecognize.Enabled = false;
            chkAutoRecognize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkAutoRecognize.Location = new Point(270, 423);
            chkAutoRecognize.Name = "chkAutoRecognize";
            chkAutoRecognize.Size = new Size(213, 27);
            chkAutoRecognize.TabIndex = 5;
            chkAutoRecognize.Text = "🔄 Nhận diện tự động";
            chkAutoRecognize.UseVisualStyleBackColor = true;
            chkAutoRecognize.CheckedChanged += ChkAutoRecognize_CheckedChanged;
            // 
            // btnRecognize
            // 
            btnRecognize.BackColor = Color.FromArgb(46, 204, 113);
            btnRecognize.Cursor = Cursors.Hand;
            btnRecognize.Enabled = false;
            btnRecognize.FlatAppearance.BorderSize = 0;
            btnRecognize.FlatStyle = FlatStyle.Flat;
            btnRecognize.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRecognize.ForeColor = Color.White;
            btnRecognize.Location = new Point(18, 423);
            btnRecognize.Name = "btnRecognize";
            btnRecognize.Size = new Size(230, 50);
            btnRecognize.TabIndex = 4;
            btnRecognize.Text = "🔍 Nhận diện ngay";
            btnRecognize.UseVisualStyleBackColor = false;
            btnRecognize.Click += BtnRecognize_Click;
            // 
            // panelCamera
            // 
            panelCamera.BackColor = Color.FromArgb(236, 240, 241);
            panelCamera.BorderStyle = BorderStyle.FixedSingle;
            panelCamera.Controls.Add(picCamera);
            panelCamera.Controls.Add(lblCamera);
            panelCamera.Location = new Point(20, 115);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(480, 280);
            panelCamera.TabIndex = 3;
            // 
            // picCamera
            // 
            picCamera.BackColor = Color.Black;
            picCamera.Dock = DockStyle.Fill;
            picCamera.Location = new Point(0, 35);
            picCamera.Name = "picCamera";
            picCamera.Size = new Size(478, 243);
            picCamera.SizeMode = PictureBoxSizeMode.Zoom;
            picCamera.TabIndex = 1;
            picCamera.TabStop = false;
            // 
            // lblCamera
            // 
            lblCamera.BackColor = Color.FromArgb(52, 73, 94);
            lblCamera.Dock = DockStyle.Top;
            lblCamera.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCamera.ForeColor = Color.White;
            lblCamera.Location = new Point(0, 0);
            lblCamera.Name = "lblCamera";
            lblCamera.Size = new Size(478, 35);
            lblCamera.TabIndex = 0;
            lblCamera.Text = "🎥 LIVE CAMERA";
            lblCamera.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboCamera
            // 
            cboCamera.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCamera.Font = new Font("Segoe UI", 10F);
            cboCamera.FormattingEnabled = true;
            cboCamera.Location = new Point(20, 68);
            cboCamera.Name = "cboCamera";
            cboCamera.Size = new Size(300, 31);
            cboCamera.TabIndex = 1;
            // 
            // lblSelectCamera
            // 
            lblSelectCamera.AutoSize = true;
            lblSelectCamera.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectCamera.Location = new Point(20, 40);
            lblSelectCamera.Name = "lblSelectCamera";
            lblSelectCamera.Size = new Size(119, 23);
            lblSelectCamera.TabIndex = 0;
            lblSelectCamera.Text = "Chọn camera:";
            // 
            // btnStartCamera
            // 
            btnStartCamera.BackColor = Color.FromArgb(52, 152, 219);
            btnStartCamera.Cursor = Cursors.Hand;
            btnStartCamera.FlatAppearance.BorderSize = 0;
            btnStartCamera.FlatStyle = FlatStyle.Flat;
            btnStartCamera.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStartCamera.ForeColor = Color.White;
            btnStartCamera.Location = new Point(335, 63);
            btnStartCamera.Name = "btnStartCamera";
            btnStartCamera.Size = new Size(165, 40);
            btnStartCamera.TabIndex = 2;
            btnStartCamera.Text = "📷 Bật Camera";
            btnStartCamera.UseVisualStyleBackColor = false;
            btnStartCamera.Click += BtnStartCamera_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(groupBoxAttendance);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(550, 80);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(15);
            panelRight.Size = new Size(850, 670);
            panelRight.TabIndex = 2;
            // 
            // groupBoxAttendance
            // 
            groupBoxAttendance.Controls.Add(panelNotification);
            groupBoxAttendance.Controls.Add(dgvStudentAttendance);
            groupBoxAttendance.Dock = DockStyle.Fill;
            groupBoxAttendance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxAttendance.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxAttendance.Location = new Point(15, 15);
            groupBoxAttendance.Name = "groupBoxAttendance";
            groupBoxAttendance.Padding = new Padding(10);
            groupBoxAttendance.Size = new Size(820, 640);
            groupBoxAttendance.TabIndex = 0;
            groupBoxAttendance.TabStop = false;
            groupBoxAttendance.Text = "📋 Danh sách đã điểm danh";
            // 
            // panelNotification
            // 
            panelNotification.BackColor = Color.FromArgb(46, 204, 113);
            panelNotification.Controls.Add(lblNotificationMessage);
            panelNotification.Controls.Add(lblNotificationTitle);
            panelNotification.Location = new Point(312, 18);
            panelNotification.Name = "panelNotification";
            panelNotification.Size = new Size(450, 120);
            panelNotification.TabIndex = 4;
            panelNotification.Visible = false;
            // 
            // lblNotificationMessage
            // 
            lblNotificationMessage.Font = new Font("Segoe UI", 11F);
            lblNotificationMessage.ForeColor = Color.White;
            lblNotificationMessage.Location = new Point(15, 50);
            lblNotificationMessage.Name = "lblNotificationMessage";
            lblNotificationMessage.Size = new Size(420, 60);
            lblNotificationMessage.TabIndex = 1;
            lblNotificationMessage.Text = "Nguyễn Văn A\nĐộ tin cậy: 95%";
            // 
            // lblNotificationTitle
            // 
            lblNotificationTitle.AutoSize = true;
            lblNotificationTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNotificationTitle.ForeColor = Color.White;
            lblNotificationTitle.Location = new Point(15, 18);
            lblNotificationTitle.Name = "lblNotificationTitle";
            lblNotificationTitle.Size = new Size(274, 32);
            lblNotificationTitle.TabIndex = 0;
            lblNotificationTitle.Text = "Điểm danh thành công";
            // 
            // dgvStudentAttendance
            // 
            dgvStudentAttendance.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvStudentAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudentAttendance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStudentAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStudentAttendance.ColumnHeadersHeight = 40;
            dgvStudentAttendance.Columns.AddRange(new DataGridViewColumn[] { colTime, colStudentName, colShift, colConfidence, colStatus });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvStudentAttendance.DefaultCellStyle = dataGridViewCellStyle5;
            dgvStudentAttendance.Dock = DockStyle.Fill;
            dgvStudentAttendance.Font = new Font("Segoe UI", 9.5F);
            dgvStudentAttendance.GridColor = Color.FromArgb(231, 229, 255);
            dgvStudentAttendance.Location = new Point(10, 35);
            dgvStudentAttendance.Name = "dgvStudentAttendance";
            dgvStudentAttendance.ReadOnly = true;
            dgvStudentAttendance.RowHeadersVisible = false;
            dgvStudentAttendance.RowHeadersWidth = 51;
            dgvStudentAttendance.Size = new Size(800, 595);
            dgvStudentAttendance.TabIndex = 0;
            dgvStudentAttendance.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvStudentAttendance.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvStudentAttendance.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvStudentAttendance.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvStudentAttendance.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvStudentAttendance.ThemeStyle.BackColor = Color.White;
            dgvStudentAttendance.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvStudentAttendance.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvStudentAttendance.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStudentAttendance.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.5F);
            dgvStudentAttendance.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvStudentAttendance.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStudentAttendance.ThemeStyle.HeaderStyle.Height = 40;
            dgvStudentAttendance.ThemeStyle.ReadOnly = true;
            dgvStudentAttendance.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvStudentAttendance.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStudentAttendance.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            dgvStudentAttendance.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvStudentAttendance.ThemeStyle.RowsStyle.Height = 29;
            dgvStudentAttendance.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvStudentAttendance.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // colTime
            // 
            colTime.HeaderText = "Thời gian";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colStudentName
            // 
            colStudentName.HeaderText = "Họ và tên";
            colStudentName.MinimumWidth = 6;
            colStudentName.Name = "colStudentName";
            colStudentName.ReadOnly = true;
            // 
            // colShift
            // 
            colShift.HeaderText = "Lớp học - Ca";
            colShift.MinimumWidth = 6;
            colShift.Name = "colShift";
            colShift.ReadOnly = true;
            // 
            // colConfidence
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colConfidence.DefaultCellStyle = dataGridViewCellStyle3;
            colConfidence.HeaderText = "Độ tin cậy";
            colConfidence.MinimumWidth = 6;
            colConfidence.Name = "colConfidence";
            colConfidence.ReadOnly = true;
            // 
            // colStatus
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.DefaultCellStyle = dataGridViewCellStyle4;
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(236, 240, 241);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 750);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1400, 80);
            panelBottom.TabIndex = 3;
            // 
            // FaceAttendance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "FaceAttendance";
            Size = new Size(1400, 830);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            groupBoxStats.ResumeLayout(false);
            groupBoxStats.PerformLayout();
            groupBoxCamera.ResumeLayout(false);
            groupBoxCamera.PerformLayout();
            panelCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            panelRight.ResumeLayout(false);
            groupBoxAttendance.ResumeLayout(false);
            panelNotification.ResumeLayout(false);
            panelNotification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentAttendance).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Panel panelLeft;
        private GroupBox groupBoxCamera;
        private Label lblRecognitionStatus;
        private Label lblCameraStatus;
        private CheckBox chkAutoRecognize;
        private Button btnRecognize;
        private Panel panelCamera;
        private PictureBox picCamera;
        private Label lblCamera;
        private ComboBox cboCamera;
        private Label lblSelectCamera;
        private Button btnStartCamera;
        private GroupBox groupBoxStats;
        private Label lblAttendanceRate;
        private Label lblAttendanceRateTitle;
        private Label lblTotalPresent;
        private Label lblTotalPresentTitle;
        private Panel panelRight;
        private GroupBox groupBoxAttendance;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStudentAttendance;
        private Panel panelBottom;
        private Panel panelNotification;
        private Label lblNotificationMessage;
        private Label lblNotificationTitle;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colShift;
        private DataGridViewTextBoxColumn colConfidence;
        private DataGridViewTextBoxColumn colStatus;
    }
}