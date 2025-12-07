using System.ComponentModel;

namespace BaiTapLonWinForm.View.Admin.Teacher
{
    partial class AddTeacher
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
            panelMain = new Panel();
            panelContent = new Panel();
            grpTeacherInfo = new GroupBox();
            nudExperienceYear = new NumericUpDown();
            nudSalary = new NumericUpDown();
            lblExperienceYear = new Label();
            lblSalary = new Label();
            txtTeacherId = new TextBox();
            lblTeacherId = new Label();
            grpUserInfo = new GroupBox();
            cboRole = new ComboBox();
            lblRole = new Label();
            cboGender = new ComboBox();
            lblGender = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblDateOfBirth = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtUserId = new TextBox();
            lblUserId = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader = new Panel();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            grpTeacherInfo.SuspendLayout();
            ((ISupportInitialize)nudExperienceYear).BeginInit();
            ((ISupportInitialize)nudSalary).BeginInit();
            grpUserInfo.SuspendLayout();
            panelButtons.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 241);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelButtons);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1480, 850);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.Controls.Add(grpTeacherInfo);
            panelContent.Controls.Add(grpUserInfo);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 80);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(23, 27, 23, 27);
            panelContent.Size = new Size(1480, 651);
            panelContent.TabIndex = 1;
            // 
            // grpTeacherInfo
            // 
            grpTeacherInfo.BackColor = Color.White;
            grpTeacherInfo.Controls.Add(nudExperienceYear);
            grpTeacherInfo.Controls.Add(nudSalary);
            grpTeacherInfo.Controls.Add(lblExperienceYear);
            grpTeacherInfo.Controls.Add(lblSalary);
            grpTeacherInfo.Controls.Add(txtTeacherId);
            grpTeacherInfo.Controls.Add(lblTeacherId);
            grpTeacherInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpTeacherInfo.Location = new Point(959, 27);
            grpTeacherInfo.Margin = new Padding(3, 4, 3, 4);
            grpTeacherInfo.Name = "grpTeacherInfo";
            grpTeacherInfo.Padding = new Padding(3, 4, 3, 4);
            grpTeacherInfo.Size = new Size(492, 600);
            grpTeacherInfo.TabIndex = 1;
            grpTeacherInfo.TabStop = false;
            grpTeacherInfo.Text = "Thông tin giáo viên";
            // 
            // nudExperienceYear
            // 
            nudExperienceYear.Font = new Font("Segoe UI", 10F);
            nudExperienceYear.Location = new Point(42, 267);
            nudExperienceYear.Margin = new Padding(3, 4, 3, 4);
            nudExperienceYear.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudExperienceYear.Name = "nudExperienceYear";
            nudExperienceYear.Size = new Size(411, 30);
            nudExperienceYear.TabIndex = 5;
            // 
            // nudSalary
            // 
            nudSalary.Font = new Font("Segoe UI", 10F);
            nudSalary.Location = new Point(42, 173);
            nudSalary.Margin = new Padding(3, 4, 3, 4);
            nudSalary.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudSalary.Name = "nudSalary";
            nudSalary.Size = new Size(411, 30);
            nudSalary.TabIndex = 3;
            nudSalary.ThousandsSeparator = true;
            // 
            // lblExperienceYear
            // 
            lblExperienceYear.AutoSize = true;
            lblExperienceYear.Font = new Font("Segoe UI", 9F);
            lblExperienceYear.Location = new Point(42, 241);
            lblExperienceYear.Name = "lblExperienceYear";
            lblExperienceYear.Size = new Size(147, 20);
            lblExperienceYear.TabIndex = 4;
            lblExperienceYear.Text = "Số năm kinh nghiệm:";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 9F);
            lblSalary.Location = new Point(42, 147);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(99, 20);
            lblSalary.TabIndex = 2;
            lblSalary.Text = "Lương (VNĐ):";
            // 
            // txtTeacherId
            // 
            txtTeacherId.Enabled = false;
            txtTeacherId.Font = new Font("Segoe UI", 10F);
            txtTeacherId.Location = new Point(42, 80);
            txtTeacherId.Margin = new Padding(3, 4, 3, 4);
            txtTeacherId.Name = "txtTeacherId";
            txtTeacherId.Size = new Size(411, 30);
            txtTeacherId.TabIndex = 1;
            // 
            // lblTeacherId
            // 
            lblTeacherId.AutoSize = true;
            lblTeacherId.Font = new Font("Segoe UI", 9F);
            lblTeacherId.Location = new Point(42, 53);
            lblTeacherId.Name = "lblTeacherId";
            lblTeacherId.Size = new Size(93, 20);
            lblTeacherId.TabIndex = 0;
            lblTeacherId.Text = "ID Giáo viên:";
            // 
            // grpUserInfo
            // 
            grpUserInfo.BackColor = Color.White;
            grpUserInfo.Controls.Add(cboRole);
            grpUserInfo.Controls.Add(lblRole);
            grpUserInfo.Controls.Add(cboGender);
            grpUserInfo.Controls.Add(lblGender);
            grpUserInfo.Controls.Add(dtpDateOfBirth);
            grpUserInfo.Controls.Add(lblDateOfBirth);
            grpUserInfo.Controls.Add(txtAddress);
            grpUserInfo.Controls.Add(lblAddress);
            grpUserInfo.Controls.Add(txtPhone);
            grpUserInfo.Controls.Add(lblPhone);
            grpUserInfo.Controls.Add(txtEmail);
            grpUserInfo.Controls.Add(lblEmail);
            grpUserInfo.Controls.Add(txtFullName);
            grpUserInfo.Controls.Add(lblFullName);
            grpUserInfo.Controls.Add(txtPassword);
            grpUserInfo.Controls.Add(lblPassword);
            grpUserInfo.Controls.Add(txtUsername);
            grpUserInfo.Controls.Add(lblUsername);
            grpUserInfo.Controls.Add(txtUserId);
            grpUserInfo.Controls.Add(lblUserId);
            grpUserInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpUserInfo.Location = new Point(6, 27);
            grpUserInfo.Margin = new Padding(3, 4, 3, 4);
            grpUserInfo.Name = "grpUserInfo";
            grpUserInfo.Padding = new Padding(3, 4, 3, 4);
            grpUserInfo.Size = new Size(927, 600);
            grpUserInfo.TabIndex = 0;
            grpUserInfo.TabStop = false;
            grpUserInfo.Text = "Thông tin người dùng";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(479, 362);
            cboRole.Margin = new Padding(3, 4, 3, 4);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(411, 31);
            cboRole.TabIndex = 19;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.Location = new Point(479, 335);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(55, 20);
            lblRole.TabIndex = 18;
            lblRole.Text = "Vai trò:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(479, 282);
            cboGender.Margin = new Padding(3, 4, 3, 4);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(411, 31);
            cboGender.TabIndex = 17;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9F);
            lblGender.Location = new Point(479, 255);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 16;
            lblGender.Text = "Giới tính:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(479, 202);
            dtpDateOfBirth.Margin = new Padding(3, 4, 3, 4);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(411, 30);
            dtpDateOfBirth.TabIndex = 15;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 9F);
            lblDateOfBirth.Location = new Point(479, 175);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(77, 20);
            lblDateOfBirth.TabIndex = 14;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(479, 77);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(411, 79);
            txtAddress.TabIndex = 13;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F);
            lblAddress.Location = new Point(476, 53);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(58, 20);
            lblAddress.TabIndex = 12;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(34, 480);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(411, 30);
            txtPhone.TabIndex = 11;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.Location = new Point(34, 453);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(34, 400);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(411, 30);
            txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(34, 373);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email: *";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(34, 320);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(411, 30);
            txtFullName.TabIndex = 7;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F);
            lblFullName.Location = new Point(34, 293);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 6;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(34, 240);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(411, 30);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.Location = new Point(34, 213);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(83, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu: *";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(34, 160);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(411, 30);
            txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.Location = new Point(34, 133);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(120, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Tên đăng nhập: *";
            // 
            // txtUserId
            // 
            txtUserId.Enabled = false;
            txtUserId.Font = new Font("Segoe UI", 10F);
            txtUserId.Location = new Point(34, 80);
            txtUserId.Margin = new Padding(3, 4, 3, 4);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(411, 30);
            txtUserId.TabIndex = 1;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Font = new Font("Segoe UI", 9F);
            lblUserId.Location = new Point(34, 53);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(111, 20);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "ID Người dùng:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 731);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1480, 119);
            panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1275, 18);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(171, 53);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1081, 18);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(171, 53);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1480, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1480, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÊM GIÁO VIÊN MỚI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddTeacher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddTeacher";
            Size = new Size(1480, 850);
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            grpTeacherInfo.ResumeLayout(false);
            grpTeacherInfo.PerformLayout();
            ((ISupportInitialize)nudExperienceYear).EndInit();
            ((ISupportInitialize)nudSalary).EndInit();
            grpUserInfo.ResumeLayout(false);
            grpUserInfo.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //private void TeacherAddUpdateUserControl_Load(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelContent;
        private GroupBox grpUserInfo;
        private TextBox txtUserId;
        private Label lblUserId;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtFullName;
        private Label lblFullName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtAddress;
        private Label lblAddress;
        private DateTimePicker dtpDateOfBirth;
        private Label lblDateOfBirth;
        private ComboBox cboGender;
        private Label lblGender;
        private ComboBox cboRole;
        private Label lblRole;
        private GroupBox grpTeacherInfo;
        private TextBox txtTeacherId;
        private Label lblTeacherId;
        private NumericUpDown nudSalary;
        private Label lblSalary;
        private NumericUpDown nudExperienceYear;
        private Label lblExperienceYear;
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
    }

        #endregion
    }

