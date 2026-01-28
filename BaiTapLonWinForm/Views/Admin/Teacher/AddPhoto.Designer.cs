namespace BaiTapLonWinForm.View.Admin.Teacher
{
    partial class AddPhoto
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelStep2 = new Panel();
            groupBoxCamera = new GroupBox();
            btnCapture = new Button();
            btnClearAll = new Button();
            btnAutoCapture = new Button();
            lblImageStatus = new Label();
            lblCameraStatus = new Label();
            progressBar = new ProgressBar();
            groupBoxGallery = new GroupBox();
            flowLayoutImages = new FlowLayoutPanel();
            panelPreview = new Panel();
            picPreview = new PictureBox();
            lblPreview = new Label();
            panelCamera = new Panel();
            picCamera = new PictureBox();
            lblCamera = new Label();
            cboCamera = new ComboBox();
            lblSelectCamera = new Label();
            btnStartCamera = new Button();
            panelBottom = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelTop = new Panel();
            lblTitle = new Label();
            lblStatusCamera = new Label();
            panelStep2.SuspendLayout();
            groupBoxCamera.SuspendLayout();
            groupBoxGallery.SuspendLayout();
            panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            panelCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            panelBottom.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelStep2
            // 
            panelStep2.BackColor = Color.White;
            panelStep2.Controls.Add(groupBoxCamera);
            panelStep2.Dock = DockStyle.Fill;
            panelStep2.Location = new Point(0, 0);
            panelStep2.Name = "panelStep2";
            panelStep2.Padding = new Padding(15);
            panelStep2.Size = new Size(1480, 850);
            panelStep2.TabIndex = 2;
            // 
            // groupBoxCamera
            // 
            groupBoxCamera.Controls.Add(lblStatusCamera);
            groupBoxCamera.Controls.Add(btnCapture);
            groupBoxCamera.Controls.Add(btnClearAll);
            groupBoxCamera.Controls.Add(btnAutoCapture);
            groupBoxCamera.Controls.Add(lblImageStatus);
            groupBoxCamera.Controls.Add(lblCameraStatus);
            groupBoxCamera.Controls.Add(progressBar);
            groupBoxCamera.Controls.Add(groupBoxGallery);
            groupBoxCamera.Controls.Add(panelPreview);
            groupBoxCamera.Controls.Add(panelCamera);
            groupBoxCamera.Controls.Add(cboCamera);
            groupBoxCamera.Controls.Add(lblSelectCamera);
            groupBoxCamera.Controls.Add(btnStartCamera);
            groupBoxCamera.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxCamera.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxCamera.Location = new Point(0, 0);
            groupBoxCamera.Name = "groupBoxCamera";
            groupBoxCamera.Padding = new Padding(15);
            groupBoxCamera.Size = new Size(1450, 740);
            groupBoxCamera.TabIndex = 0;
            groupBoxCamera.TabStop = false;
            groupBoxCamera.Text = "📸 BƯỚC 2: CHỤP ẢNH KHUÔN MẶT";
            // 
            // btnCapture
            // 
            btnCapture.BackColor = Color.FromArgb(46, 204, 113);
            btnCapture.Cursor = Cursors.Hand;
            btnCapture.FlatAppearance.BorderSize = 0;
            btnCapture.FlatStyle = FlatStyle.Flat;
            btnCapture.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCapture.ForeColor = Color.White;
            btnCapture.Location = new Point(21, 684);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(155, 50);
            btnCapture.TabIndex = 7;
            btnCapture.Text = "📸 Chụp 1 ảnh";
            btnCapture.UseVisualStyleBackColor = false;
            btnCapture.Click += BtnCapture_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = Color.FromArgb(231, 76, 60);
            btnClearAll.Cursor = Cursors.Hand;
            btnClearAll.FlatAppearance.BorderSize = 0;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearAll.ForeColor = Color.White;
            btnClearAll.Location = new Point(395, 684);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(133, 50);
            btnClearAll.TabIndex = 3;
            btnClearAll.Text = "🗑️ Xóa tất cả";
            btnClearAll.UseVisualStyleBackColor = false;
            btnClearAll.Click += BtnClearAll_Click;
            // 
            // btnAutoCapture
            // 
            btnAutoCapture.BackColor = Color.FromArgb(155, 89, 182);
            btnAutoCapture.Cursor = Cursors.Hand;
            btnAutoCapture.FlatAppearance.BorderSize = 0;
            btnAutoCapture.FlatStyle = FlatStyle.Flat;
            btnAutoCapture.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAutoCapture.ForeColor = Color.White;
            btnAutoCapture.Location = new Point(203, 684);
            btnAutoCapture.Name = "btnAutoCapture";
            btnAutoCapture.Size = new Size(160, 50);
            btnAutoCapture.TabIndex = 4;
            btnAutoCapture.Text = "🎬 Chụp tự động";
            btnAutoCapture.UseVisualStyleBackColor = false;
            btnAutoCapture.Click += BtnAutoCapture_Click;
            // 
            // lblImageStatus
            // 
            lblImageStatus.AutoSize = true;
            lblImageStatus.ForeColor = Color.FromArgb(243, 156, 18);
            lblImageStatus.Location = new Point(1111, 696);
            lblImageStatus.Name = "lblImageStatus";
            lblImageStatus.Size = new Size(335, 25);
            lblImageStatus.TabIndex = 0;
            lblImageStatus.Text = "⚠️ Đã có 0/10 ảnh (Tối thiểu 10 ảnh)";
            // 
            // lblCameraStatus
            // 
            lblCameraStatus.AutoSize = true;
            lblCameraStatus.ForeColor = Color.FromArgb(149, 165, 166);
            lblCameraStatus.Location = new Point(690, 681);
            lblCameraStatus.Name = "lblCameraStatus";
            lblCameraStatus.Size = new Size(187, 25);
            lblCameraStatus.TabIndex = 1;
            lblCameraStatus.Text = "⏹️ Camera đã dừng";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(592, 711);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(280, 23);
            progressBar.TabIndex = 2;
            progressBar.Visible = false;
            // 
            // groupBoxGallery
            // 
            groupBoxGallery.Controls.Add(flowLayoutImages);
            groupBoxGallery.Location = new Point(895, 409);
            groupBoxGallery.Name = "groupBoxGallery";
            groupBoxGallery.Size = new Size(555, 268);
            groupBoxGallery.TabIndex = 5;
            groupBoxGallery.TabStop = false;
            groupBoxGallery.Text = "Ảnh đã chụp";
            // 
            // flowLayoutImages
            // 
            flowLayoutImages.AutoScroll = true;
            flowLayoutImages.Dock = DockStyle.Fill;
            flowLayoutImages.Location = new Point(3, 28);
            flowLayoutImages.Name = "flowLayoutImages";
            flowLayoutImages.Size = new Size(549, 237);
            flowLayoutImages.TabIndex = 0;
            // 
            // panelPreview
            // 
            panelPreview.BackColor = Color.FromArgb(236, 240, 241);
            panelPreview.BorderStyle = BorderStyle.FixedSingle;
            panelPreview.Controls.Add(picPreview);
            panelPreview.Controls.Add(lblPreview);
            panelPreview.Location = new Point(895, 134);
            panelPreview.Name = "panelPreview";
            panelPreview.Size = new Size(552, 269);
            panelPreview.TabIndex = 6;
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.White;
            picPreview.Dock = DockStyle.Fill;
            picPreview.Location = new Point(0, 30);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(550, 237);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 0;
            picPreview.TabStop = false;
            // 
            // lblPreview
            // 
            lblPreview.BackColor = Color.FromArgb(52, 73, 94);
            lblPreview.Dock = DockStyle.Top;
            lblPreview.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreview.ForeColor = Color.White;
            lblPreview.Location = new Point(0, 0);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(550, 30);
            lblPreview.TabIndex = 0;
            lblPreview.Text = "🖼️ XEM TRƯỚC";
            lblPreview.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCamera
            // 
            panelCamera.BackColor = Color.FromArgb(236, 240, 241);
            panelCamera.BorderStyle = BorderStyle.FixedSingle;
            panelCamera.Controls.Add(picCamera);
            panelCamera.Controls.Add(lblCamera);
            panelCamera.Location = new Point(20, 134);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(853, 544);
            panelCamera.TabIndex = 8;
            // 
            // picCamera
            // 
            picCamera.BackColor = Color.Black;
            picCamera.Dock = DockStyle.Fill;
            picCamera.Location = new Point(0, 30);
            picCamera.Name = "picCamera";
            picCamera.Size = new Size(851, 512);
            picCamera.SizeMode = PictureBoxSizeMode.Zoom;
            picCamera.TabIndex = 0;
            picCamera.TabStop = false;
            // 
            // lblCamera
            // 
            lblCamera.BackColor = Color.FromArgb(52, 73, 94);
            lblCamera.Dock = DockStyle.Top;
            lblCamera.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCamera.ForeColor = Color.White;
            lblCamera.Location = new Point(0, 0);
            lblCamera.Name = "lblCamera";
            lblCamera.Size = new Size(851, 30);
            lblCamera.TabIndex = 0;
            lblCamera.Text = "🎥 LIVE CAMERA";
            lblCamera.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboCamera
            // 
            cboCamera.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCamera.Font = new Font("Segoe UI", 10F);
            cboCamera.FormattingEnabled = true;
            cboCamera.Location = new Point(138, 80);
            cboCamera.Name = "cboCamera";
            cboCamera.Size = new Size(300, 31);
            cboCamera.TabIndex = 9;
            // 
            // lblSelectCamera
            // 
            lblSelectCamera.AutoSize = true;
            lblSelectCamera.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectCamera.Location = new Point(13, 81);
            lblSelectCamera.Name = "lblSelectCamera";
            lblSelectCamera.Size = new Size(119, 23);
            lblSelectCamera.TabIndex = 10;
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
            btnStartCamera.Location = new Point(457, 76);
            btnStartCamera.Name = "btnStartCamera";
            btnStartCamera.Size = new Size(155, 41);
            btnStartCamera.TabIndex = 11;
            btnStartCamera.Text = "📷 Bật Camera";
            btnStartCamera.UseVisualStyleBackColor = false;
            btnStartCamera.Click += BtnStartCamera_Click;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.White;
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 756);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1480, 94);
            panelBottom.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(20, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1198, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 50);
            btnSave.TabIndex = 4;
            btnSave.Text = "💾 LƯU DỮ LIỆU";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 73, 94);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1480, 70);
            panelTop.TabIndex = 12;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(21, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(649, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "➕ THÊM ẢNH KHUÔN MẶT CHO HỌC VIÊN";
            // 
            // lblStatusCamera
            // 
            lblStatusCamera.AutoSize = true;
            lblStatusCamera.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblStatusCamera.ForeColor = Color.Black;
            lblStatusCamera.Location = new Point(631, 88);
            lblStatusCamera.Name = "lblStatusCamera";
            lblStatusCamera.Size = new Size(55, 23);
            lblStatusCamera.TabIndex = 12;
            lblStatusCamera.Text = "label1";
            // 
            // AddPhoto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Controls.Add(panelStep2);
            Name = "AddPhoto";
            Size = new Size(1480, 850);
            panelStep2.ResumeLayout(false);
            groupBoxCamera.ResumeLayout(false);
            groupBoxCamera.PerformLayout();
            groupBoxGallery.ResumeLayout(false);
            panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            panelCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            panelBottom.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelStep2;
        private GroupBox groupBoxCamera;
        public Button btnCapture;
        public Button btnClearAll;
        public Button btnAutoCapture;
        public Label lblImageStatus;
        private Label lblCameraStatus;
        private ProgressBar progressBar;
        private GroupBox groupBoxGallery;
        public FlowLayoutPanel flowLayoutImages;
        private Panel panelPreview;
        public PictureBox picPreview;
        private Label lblPreview;
        private Panel panelCamera;
        public PictureBox picCamera;
        private Label lblCamera;
        public ComboBox cboCamera;
        private Label lblSelectCamera;
        public Button btnStartCamera;
        private Panel panelBottom;
        private Button btnCancel;
        public Button btnSave;
        private Panel panelTop;
        private Label lblTitle;
        private Label lblStatusCamera;
    }
}
