namespace BaiTapLonWinForm.View.Admin.Students
{
    partial class EditStudent
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
            panelBottom = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelTop = new Panel();
            lblTitle = new Label();
            panelStep1.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            panelBottom.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelStep1
            // 
            panelStep1.BackColor = Color.White;
            panelStep1.Controls.Add(groupBoxInfo);
            panelStep1.Dock = DockStyle.Fill;
            panelStep1.Location = new Point(0, 0);
            panelStep1.Name = "panelStep1";
            panelStep1.Padding = new Padding(150, 150, 150, 20);
            panelStep1.Size = new Size(1480, 850);
            panelStep1.TabIndex = 1;
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
            groupBoxInfo.Location = new Point(147, 76);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(20);
            groupBoxInfo.Size = new Size(1180, 674);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "📝 THÔNG TIN CÁ NHÂN";
            // 
            // lblErrFirstName
            // 
            lblErrFirstName.AutoSize = true;
            lblErrFirstName.Font = new Font("Segoe UI", 9F);
            lblErrFirstName.ForeColor = Color.Red;
            lblErrFirstName.Location = new Point(80, 108);
            lblErrFirstName.Name = "lblErrFirstName";
            lblErrFirstName.Size = new Size(0, 20);
            lblErrFirstName.TabIndex = 20;
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
            lblErrLastName.TabIndex = 21;
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
            lblErrEmail.TabIndex = 22;
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
            lblErrPhone.TabIndex = 23;
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
            lblErrParentPhone.TabIndex = 24;
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
            lblErrGender.TabIndex = 25;
            lblErrGender.Visible = false;
            // 
            // txtPhoneNumberOfParent
            // 
            txtPhoneNumberOfParent.Font = new Font("Segoe UI", 10F);
            txtPhoneNumberOfParent.Location = new Point(630, 75);
            txtPhoneNumberOfParent.Name = "txtPhoneNumberOfParent";
            txtPhoneNumberOfParent.Size = new Size(450, 30);
            txtPhoneNumberOfParent.TabIndex = 0;
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
            cboGender.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(80, 175);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(450, 30);
            txtLastName.TabIndex = 3;
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
            txtAddress.TabIndex = 5;
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
            dtpDateOfBirth.TabIndex = 7;
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
            txtPhone.TabIndex = 10;
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
            txtEmail.TabIndex = 12;
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
            txtFirstName.TabIndex = 14;
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(80, 47);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 23);
            lblFirstName.TabIndex = 15;
            lblFirstName.Text = "Họ: *";
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
            btnSave.Location = new Point(1104, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 50);
            btnSave.TabIndex = 4;
            btnSave.Text = "💾 LƯU DỮ LIỆU";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 73, 94);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1480, 70);
            panelTop.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(21, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(565, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✏️ CHỈNH SỬA THÔNG TIN HỌC VIÊN";
            // 
            // EditStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Controls.Add(panelStep1);
            Name = "EditStudent";
            Size = new Size(1480, 850);
            panelStep1.ResumeLayout(false);
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelStep1;
        private GroupBox groupBoxInfo;
        public TextBox txtPhoneNumberOfParent;
        private Label lblPhoneNumberOfParent;
        public ComboBox cboGender;
        public TextBox txtLastName;
        private Label lblLastName;
        public TextBox txtAddress;
        private Label lblAddress;
        public DateTimePicker dtpDateOfBirth;
        private Label lblDateOfBirth;
        private Label lblGender;
        public TextBox txtPhone;
        private Label lblPhone;
        public TextBox txtEmail;
        private Label lblEmail;
        public TextBox txtFirstName;
        private Label lblFirstName;
        private Panel panelBottom;
        private Button btnCancel;
        public Button btnSave;
        private Panel panelTop;
        private Label lblTitle;

        // Khai báo các Label lỗi mới
        private Label lblErrFirstName;
        private Label lblErrLastName;
        private Label lblErrEmail;
        private Label lblErrPhone;
        private Label lblErrParentPhone;
        private Label lblErrGender;
    }
}