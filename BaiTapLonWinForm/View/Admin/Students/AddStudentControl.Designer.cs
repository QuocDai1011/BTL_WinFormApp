namespace BaiTapLonWinForm.View.Admin.Students
{
    partial class AddStudentControl
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
            panelTop = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
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
            lblInstruction = new Label();
            btnCancel = new Button();
            btnBack = new Button();
            btnNext = new Button();
            btnSave = new Button();
            panelStep1 = new Panel();
            groupBoxInfo = new GroupBox();
            lblErrFirstName = new Label();
            lblErrLastName = new Label();
            lblErrEmail = new Label();
            lblErrPhone = new Label();
            lblErrParentPhone = new Label();
            lblErrGender = new Label();
            txtPhoneNumberOfParent = new TextBox();
            lblPhoneNumberOfParent = new Label();
            cboGender = new ComboBox();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblDateOfBirth = new Label();
            lblGender = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            panelStep2.SuspendLayout();
            groupBoxCamera.SuspendLayout();
            groupBoxGallery.SuspendLayout();
            panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            panelCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            panelBottom.SuspendLayout();
            panelStep1.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 73, 94);
            panelTop.Controls.Add(lblTitle);
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1480, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(21, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(384, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "➕ THÊM SINH VIÊN MỚI";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(panelStep2);
            panelContent.Controls.Add(panelBottom);
            panelContent.Controls.Add(panelStep1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1480, 850);
            panelContent.TabIndex = 1;
            // 
            // panelStep2
            // 
            panelStep2.BackColor = Color.White;
            panelStep2.Controls.Add(groupBoxCamera);
            panelStep2.Location = new Point(0, 0);
            panelStep2.Name = "panelStep2";
            panelStep2.Padding = new Padding(15);
            panelStep2.Size = new Size(1480, 770);
            panelStep2.TabIndex = 1;
            panelStep2.Visible = false;
            // 
            // groupBoxCamera
            // 
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
            lblImageStatus.Location = new Point(1099, 684);
            lblImageStatus.Name = "lblImageStatus";
            lblImageStatus.Size = new Size(335, 25);
            lblImageStatus.TabIndex = 0;
            lblImageStatus.Text = "⚠️ Đã có 0/10 ảnh (Tối thiểu 10 ảnh)";
            // 
            // lblCameraStatus
            // 
            lblCameraStatus.AutoSize = true;
            lblCameraStatus.ForeColor = Color.FromArgb(149, 165, 166);
            lblCameraStatus.Location = new Point(690, 680);
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
            cboCamera.Location = new Point(138, 78);
            cboCamera.Name = "cboCamera";
            cboCamera.Size = new Size(500, 31);
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
            btnStartCamera.Location = new Point(658, 76);
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
            panelBottom.Controls.Add(lblInstruction);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Controls.Add(btnBack);
            panelBottom.Controls.Add(btnNext);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Location = new Point(0, 756);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1480, 94);
            panelBottom.TabIndex = 3;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblInstruction.ForeColor = Color.FromArgb(52, 73, 94);
            lblInstruction.Location = new Point(200, 30);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(536, 23);
            lblInstruction.TabIndex = 0;
            lblInstruction.Text = "💡 Bước 1: Vui lòng điền đầy đủ thông tin sinh viên trước khi chụp ảnh.";
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
            // btnBack
            // 
            btnBack.BackColor = Color.Gray;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(988, 15);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(180, 50);
            btnBack.TabIndex = 2;
            btnBack.Text = "⬅ QUAY LẠI";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Visible = false;
            btnBack.Click += BtnBack_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(52, 152, 219);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(1198, 15);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(220, 50);
            btnNext.TabIndex = 3;
            btnNext.Text = "TIẾP TỤC ➡";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += BtnNext_Click;
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
            btnSave.Visible = false;
            btnSave.Click += BtnSave_Click;
            // 
            // panelStep1
            // 
            panelStep1.BackColor = Color.White;
            panelStep1.Controls.Add(groupBoxInfo);
            panelStep1.Location = new Point(0, 70);
            panelStep1.Name = "panelStep1";
            panelStep1.Padding = new Padding(150, 20, 150, 20);
            panelStep1.Size = new Size(1480, 780);
            panelStep1.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.Controls.Add(lblErrFirstName);
            groupBoxInfo.Controls.Add(lblErrLastName);
            groupBoxInfo.Controls.Add(lblErrEmail);
            groupBoxInfo.Controls.Add(lblErrPhone);
            groupBoxInfo.Controls.Add(lblErrParentPhone);
            groupBoxInfo.Controls.Add(lblErrGender);
            groupBoxInfo.Controls.Add(txtPhoneNumberOfParent);
            groupBoxInfo.Controls.Add(lblPhoneNumberOfParent);
            groupBoxInfo.Controls.Add(cboGender);
            groupBoxInfo.Controls.Add(txtLastName);
            groupBoxInfo.Controls.Add(lblLastName);
            groupBoxInfo.Controls.Add(txtAddress);
            groupBoxInfo.Controls.Add(lblAddress);
            groupBoxInfo.Controls.Add(dtpDateOfBirth);
            groupBoxInfo.Controls.Add(lblDateOfBirth);
            groupBoxInfo.Controls.Add(lblGender);
            groupBoxInfo.Controls.Add(txtPhone);
            groupBoxInfo.Controls.Add(lblPhone);
            groupBoxInfo.Controls.Add(txtEmail);
            groupBoxInfo.Controls.Add(lblEmail);
            groupBoxInfo.Controls.Add(txtFirstName);
            groupBoxInfo.Controls.Add(lblFirstName);
            groupBoxInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxInfo.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxInfo.Location = new Point(147, 6);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(20);
            groupBoxInfo.Size = new Size(1180, 774);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "📝 BƯỚC 1: NHẬP THÔNG TIN CÁ NHÂN";
            // 
            // lblErrFirstName
            // 
            lblErrFirstName.AutoSize = true;
            lblErrFirstName.Font = new Font("Segoe UI", 9F);
            lblErrFirstName.ForeColor = Color.Red;
            lblErrFirstName.Location = new Point(80, 108);
            lblErrFirstName.Name = "lblErrFirstName";
            lblErrFirstName.Size = new Size(0, 20);
            lblErrFirstName.TabIndex = 0;
            lblErrFirstName.Visible = false;
            // 
            // lblErrLastName
            // 
            lblErrLastName.AutoSize = true;
            lblErrLastName.Font = new Font("Segoe UI", 9F);
            lblErrLastName.ForeColor = Color.Red;
            lblErrLastName.Location = new Point(80, 208);
            lblErrLastName.Name = "lblErrLastName";
            lblErrLastName.Size = new Size(0, 20);
            lblErrLastName.TabIndex = 1;
            lblErrLastName.Visible = false;
            // 
            // lblErrEmail
            // 
            lblErrEmail.AutoSize = true;
            lblErrEmail.Font = new Font("Segoe UI", 9F);
            lblErrEmail.ForeColor = Color.Red;
            lblErrEmail.Location = new Point(80, 308);
            lblErrEmail.Name = "lblErrEmail";
            lblErrEmail.Size = new Size(0, 20);
            lblErrEmail.TabIndex = 2;
            lblErrEmail.Visible = false;
            // 
            // lblErrPhone
            // 
            lblErrPhone.AutoSize = true;
            lblErrPhone.Font = new Font("Segoe UI", 9F);
            lblErrPhone.ForeColor = Color.Red;
            lblErrPhone.Location = new Point(80, 408);
            lblErrPhone.Name = "lblErrPhone";
            lblErrPhone.Size = new Size(0, 20);
            lblErrPhone.TabIndex = 3;
            lblErrPhone.Visible = false;
            // 
            // lblErrParentPhone
            // 
            lblErrParentPhone.AutoSize = true;
            lblErrParentPhone.Font = new Font("Segoe UI", 9F);
            lblErrParentPhone.ForeColor = Color.Red;
            lblErrParentPhone.Location = new Point(630, 108);
            lblErrParentPhone.Name = "lblErrParentPhone";
            lblErrParentPhone.Size = new Size(0, 20);
            lblErrParentPhone.TabIndex = 4;
            lblErrParentPhone.Visible = false;
            // 
            // lblErrGender
            // 
            lblErrGender.AutoSize = true;
            lblErrGender.Font = new Font("Segoe UI", 9F);
            lblErrGender.ForeColor = Color.Red;
            lblErrGender.Location = new Point(630, 211);
            lblErrGender.Name = "lblErrGender";
            lblErrGender.Size = new Size(0, 20);
            lblErrGender.TabIndex = 5;
            lblErrGender.Visible = false;
            // 
            // txtPhoneNumberOfParent
            // 
            txtPhoneNumberOfParent.Font = new Font("Segoe UI", 10F);
            txtPhoneNumberOfParent.Location = new Point(630, 75);
            txtPhoneNumberOfParent.Name = "txtPhoneNumberOfParent";
            txtPhoneNumberOfParent.Size = new Size(450, 30);
            txtPhoneNumberOfParent.TabIndex = 1;
            // 
            // lblPhoneNumberOfParent
            // 
            lblPhoneNumberOfParent.Location = new Point(630, 47);
            lblPhoneNumberOfParent.Name = "lblPhoneNumberOfParent";
            lblPhoneNumberOfParent.Size = new Size(275, 23);
            lblPhoneNumberOfParent.TabIndex = 1;
            lblPhoneNumberOfParent.Text = "Số điện thoại phụ huynh: *";
            // 
            // cboGender
            // 
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(630, 175);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(450, 33);
            cboGender.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(80, 175);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(450, 30);
            txtLastName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.Location = new Point(80, 147);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(100, 23);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Tên: *";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(630, 375);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(450, 130);
            txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(630, 347);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Địa chỉ:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(630, 275);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(450, 30);
            dtpDateOfBirth.TabIndex = 5;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.Location = new Point(630, 247);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(169, 23);
            lblDateOfBirth.TabIndex = 8;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // lblGender
            // 
            lblGender.Location = new Point(630, 147);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 23);
            lblGender.TabIndex = 9;
            lblGender.Text = "Giới tính:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(80, 375);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(450, 30);
            txtPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(80, 347);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(189, 23);
            lblPhone.TabIndex = 11;
            lblPhone.Text = "Số điện thoại: *";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(80, 275);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(450, 30);
            txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(80, 247);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email: *";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(80, 75);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(450, 30);
            txtFirstName.TabIndex = 0;
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(80, 47);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 23);
            lblFirstName.TabIndex = 15;
            lblFirstName.Text = "Họ: *";
            // 
            // AddStudentControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelTop);
            Controls.Add(panelContent);
            Name = "AddStudentControl";
            Size = new Size(1480, 850);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            panelStep2.ResumeLayout(false);
            groupBoxCamera.ResumeLayout(false);
            groupBoxCamera.PerformLayout();
            groupBoxGallery.ResumeLayout(false);
            panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            panelCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelStep1.ResumeLayout(false);
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        // Khai báo biến
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnCancel;

        // Navigation Buttons
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.Button btnSave;

        // Step 1
        private System.Windows.Forms.Panel panelStep1;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        public System.Windows.Forms.TextBox txtPhoneNumberOfParent;
        private System.Windows.Forms.Label lblPhoneNumberOfParent;
        public System.Windows.Forms.ComboBox cboGender;
        public System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        public System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        public System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        public System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;

        // Step 2
        private System.Windows.Forms.Panel panelStep2;
        private System.Windows.Forms.GroupBox groupBoxCamera;
        public System.Windows.Forms.Label lblImageStatus;
        private System.Windows.Forms.Label lblCameraStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Button btnClearAll;
        public System.Windows.Forms.Button btnAutoCapture;
        private System.Windows.Forms.GroupBox groupBoxGallery;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutImages;
        private System.Windows.Forms.Panel panelPreview;
        public System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblPreview;
        public System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Panel panelCamera;
        public System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.Label lblCamera;
        public System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Label lblSelectCamera;
        public System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Label lblErrFirstName;
        private System.Windows.Forms.Label lblErrLastName;
        private System.Windows.Forms.Label lblErrEmail;
        private System.Windows.Forms.Label lblErrPhone;
        private System.Windows.Forms.Label lblErrParentPhone;
        private System.Windows.Forms.Label lblErrGender;
    }
}