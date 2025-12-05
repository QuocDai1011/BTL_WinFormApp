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
            lvAttendance = new ListView();
            colTime = new ColumnHeader();
            colStudentId = new ColumnHeader();
            colStudentName = new ColumnHeader();
            colEmail = new ColumnHeader();
            colConfidence = new ColumnHeader();
            colStatus = new ColumnHeader();
            panelBottom = new Panel();
            btnClose = new Button();
            btnExport = new Button();
            panelNotification = new Panel();
            lblNotificationMessage = new Label();
            lblNotificationTitle = new Label();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            groupBoxStats.SuspendLayout();
            groupBoxCamera.SuspendLayout();
            panelCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            panelRight.SuspendLayout();
            groupBoxAttendance.SuspendLayout();
            panelBottom.SuspendLayout();
            panelNotification.SuspendLayout();
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
            lblTotalPresentTitle.Size = new Size(163, 23);
            lblTotalPresentTitle.TabIndex = 0;
            lblTotalPresentTitle.Text = "Số sinh viên có mặt:";
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
            groupBoxAttendance.Controls.Add(lvAttendance);
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
            // lvAttendance
            // 
            lvAttendance.Columns.AddRange(new ColumnHeader[] { colTime, colStudentId, colStudentName, colEmail, colConfidence, colStatus });
            lvAttendance.Dock = DockStyle.Fill;
            lvAttendance.Font = new Font("Segoe UI", 9.5F);
            lvAttendance.FullRowSelect = true;
            lvAttendance.GridLines = true;
            lvAttendance.Location = new Point(10, 35);
            lvAttendance.Name = "lvAttendance";
            lvAttendance.Size = new Size(800, 595);
            lvAttendance.TabIndex = 0;
            lvAttendance.UseCompatibleStateImageBehavior = false;
            lvAttendance.View = System.Windows.Forms.View.Details;
            // 
            // colTime
            // 
            colTime.Text = "Thời gian";
            colTime.Width = 100;
            // 
            // colStudentId
            // 
            colStudentId.Text = "MSSV";
            colStudentId.Width = 100;
            // 
            // colStudentName
            // 
            colStudentName.Text = "Họ và tên";
            colStudentName.Width = 200;
            // 
            // colEmail
            // 
            colEmail.Text = "Email";
            colEmail.Width = 200;
            // 
            // colConfidence
            // 
            colConfidence.Text = "Độ tin cậy";
            colConfidence.Width = 100;
            // 
            // colStatus
            // 
            colStatus.Text = "Trạng thái";
            colStatus.Width = 100;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(236, 240, 241);
            panelBottom.Controls.Add(btnClose);
            panelBottom.Controls.Add(btnExport);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 750);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1400, 80);
            panelBottom.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(149, 165, 166);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1210, 17);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(170, 50);
            btnClose.TabIndex = 2;
            btnClose.Text = "❌ Đóng";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(243, 156, 18);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1015, 17);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(180, 50);
            btnExport.TabIndex = 1;
            btnExport.Text = "📄 Xuất Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // panelNotification
            // 
            panelNotification.BackColor = Color.FromArgb(46, 204, 113);
            panelNotification.Controls.Add(lblNotificationMessage);
            panelNotification.Controls.Add(lblNotificationTitle);
            panelNotification.Location = new Point(900, 100);
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
            // FaceAttendance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelNotification);
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
            panelBottom.ResumeLayout(false);
            panelNotification.ResumeLayout(false);
            panelNotification.PerformLayout();
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
        private ListView lvAttendance;
        private ColumnHeader colTime;
        private ColumnHeader colStudentId;
        private ColumnHeader colStudentName;
        private ColumnHeader colEmail;
        private ColumnHeader colConfidence;
        private ColumnHeader colStatus;
        private Panel panelBottom;
        private Button btnClose;
        private Button btnExport;
        private Panel panelNotification;
        private Label lblNotificationMessage;
        private Label lblNotificationTitle;
    }
}