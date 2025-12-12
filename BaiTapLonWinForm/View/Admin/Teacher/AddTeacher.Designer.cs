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
            lblErrorExperience = new Label();
            lblErrorSalary = new Label();
            nudExperienceYear = new NumericUpDown();
            nudSalary = new NumericUpDown();
            lblExperienceYear = new Label();
            lblSalary = new Label();
            grpUserInfo = new GroupBox();
            lblErrorDob = new Label();
            lblErrorGender = new Label();
            lblErrorPhoneNumber = new Label();
            lblErrorEmail = new Label();
            lblErrorLastName = new Label();
            lblErrorFirstName = new Label();
            cboGender = new ComboBox();
            lblGender = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblDateOfBirth = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhoneNumber = new TextBox();
            lblPhone = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblLastName = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
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
            grpTeacherInfo.Controls.Add(lblErrorExperience);
            grpTeacherInfo.Controls.Add(lblErrorSalary);
            grpTeacherInfo.Controls.Add(nudExperienceYear);
            grpTeacherInfo.Controls.Add(nudSalary);
            grpTeacherInfo.Controls.Add(lblExperienceYear);
            grpTeacherInfo.Controls.Add(lblSalary);
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
            // lblErrorExperience
            // 
            lblErrorExperience.AutoSize = true;
            lblErrorExperience.Font = new Font("Segoe UI", 9F);
            lblErrorExperience.Location = new Point(35, 205);
            lblErrorExperience.Name = "lblErrorExperience";
            lblErrorExperience.Size = new Size(0, 20);
            lblErrorExperience.TabIndex = 20;
            // 
            // lblErrorSalary
            // 
            lblErrorSalary.AutoSize = true;
            lblErrorSalary.Font = new Font("Segoe UI", 9F);
            lblErrorSalary.Location = new Point(35, 111);
            lblErrorSalary.Name = "lblErrorSalary";
            lblErrorSalary.Size = new Size(0, 20);
            lblErrorSalary.TabIndex = 19;
            // 
            // nudExperienceYear
            // 
            nudExperienceYear.Font = new Font("Segoe UI", 10F);
            nudExperienceYear.Location = new Point(35, 171);
            nudExperienceYear.Margin = new Padding(3, 4, 3, 4);
            nudExperienceYear.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudExperienceYear.Name = "nudExperienceYear";
            nudExperienceYear.Size = new Size(411, 30);
            nudExperienceYear.TabIndex = 5;
            // 
            // nudSalary
            // 
            nudSalary.Font = new Font("Segoe UI", 10F);
            nudSalary.Location = new Point(35, 77);
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
            lblExperienceYear.Location = new Point(35, 145);
            lblExperienceYear.Name = "lblExperienceYear";
            lblExperienceYear.Size = new Size(157, 20);
            lblExperienceYear.TabIndex = 4;
            lblExperienceYear.Text = "Số năm kinh nghiệm: *";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 9F);
            lblSalary.Location = new Point(35, 51);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(109, 20);
            lblSalary.TabIndex = 2;
            lblSalary.Text = "Lương (VNĐ): *";
            // 
            // grpUserInfo
            // 
            grpUserInfo.BackColor = Color.White;
            grpUserInfo.Controls.Add(lblErrorDob);
            grpUserInfo.Controls.Add(lblErrorGender);
            grpUserInfo.Controls.Add(lblErrorPhoneNumber);
            grpUserInfo.Controls.Add(lblErrorEmail);
            grpUserInfo.Controls.Add(lblErrorLastName);
            grpUserInfo.Controls.Add(lblErrorFirstName);
            grpUserInfo.Controls.Add(cboGender);
            grpUserInfo.Controls.Add(lblGender);
            grpUserInfo.Controls.Add(dtpDateOfBirth);
            grpUserInfo.Controls.Add(lblDateOfBirth);
            grpUserInfo.Controls.Add(txtAddress);
            grpUserInfo.Controls.Add(lblAddress);
            grpUserInfo.Controls.Add(txtPhoneNumber);
            grpUserInfo.Controls.Add(lblPhone);
            grpUserInfo.Controls.Add(txtEmail);
            grpUserInfo.Controls.Add(lblEmail);
            grpUserInfo.Controls.Add(lblLastName);
            grpUserInfo.Controls.Add(txtLastName);
            grpUserInfo.Controls.Add(txtFirstName);
            grpUserInfo.Controls.Add(lblFirstName);
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
            // lblErrorDob
            // 
            lblErrorDob.AutoSize = true;
            lblErrorDob.Font = new Font("Segoe UI", 9F);
            lblErrorDob.Location = new Point(479, 246);
            lblErrorDob.Name = "lblErrorDob";
            lblErrorDob.Size = new Size(0, 20);
            lblErrorDob.TabIndex = 23;
            // 
            // lblErrorGender
            // 
            lblErrorGender.AutoSize = true;
            lblErrorGender.Font = new Font("Segoe UI", 9F);
            lblErrorGender.Location = new Point(479, 339);
            lblErrorGender.Name = "lblErrorGender";
            lblErrorGender.Size = new Size(0, 20);
            lblErrorGender.TabIndex = 22;
            // 
            // lblErrorPhoneNumber
            // 
            lblErrorPhoneNumber.AutoSize = true;
            lblErrorPhoneNumber.Font = new Font("Segoe UI", 9F);
            lblErrorPhoneNumber.Location = new Point(44, 382);
            lblErrorPhoneNumber.Name = "lblErrorPhoneNumber";
            lblErrorPhoneNumber.Size = new Size(0, 20);
            lblErrorPhoneNumber.TabIndex = 21;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.Font = new Font("Segoe UI", 9F);
            lblErrorEmail.Location = new Point(44, 296);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(0, 20);
            lblErrorEmail.TabIndex = 20;
            // 
            // lblErrorLastName
            // 
            lblErrorLastName.AutoSize = true;
            lblErrorLastName.Font = new Font("Segoe UI", 9F);
            lblErrorLastName.Location = new Point(44, 206);
            lblErrorLastName.Name = "lblErrorLastName";
            lblErrorLastName.Size = new Size(0, 20);
            lblErrorLastName.TabIndex = 19;
            // 
            // lblErrorFirstName
            // 
            lblErrorFirstName.AutoSize = true;
            lblErrorFirstName.Font = new Font("Segoe UI", 9F);
            lblErrorFirstName.Location = new Point(44, 111);
            lblErrorFirstName.Name = "lblErrorFirstName";
            lblErrorFirstName.Size = new Size(0, 20);
            lblErrorFirstName.TabIndex = 18;
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(479, 304);
            cboGender.Margin = new Padding(3, 4, 3, 4);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(411, 31);
            cboGender.TabIndex = 17;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9F);
            lblGender.Location = new Point(479, 277);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 16;
            lblGender.Text = "Giới tính:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(479, 212);
            dtpDateOfBirth.Margin = new Padding(3, 4, 3, 4);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(411, 30);
            dtpDateOfBirth.TabIndex = 15;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 9F);
            lblDateOfBirth.Location = new Point(479, 185);
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
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 10F);
            txtPhoneNumber.Location = new Point(44, 348);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(411, 30);
            txtPhoneNumber.TabIndex = 11;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.Location = new Point(44, 323);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(114, 20);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Số điện thoại : *";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(44, 258);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(411, 30);
            txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(44, 231);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email: *";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F);
            lblLastName.Location = new Point(44, 140);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(35, 20);
            lblLastName.TabIndex = 6;
            lblLastName.Text = "Tên:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(44, 167);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(411, 30);
            txtLastName.TabIndex = 7;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(44, 77);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(411, 30);
            txtFirstName.TabIndex = 5;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F);
            lblFirstName.Location = new Point(44, 50);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(42, 20);
            lblFirstName.TabIndex = 4;
            lblFirstName.Text = "Họ: *";
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


        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelContent;
        private GroupBox grpUserInfo;
        private TextBox txtFirstName;
        private Label lblPassword;
        private TextBox txtLastName;
        private Label lblFullName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPhoneNumber;
        private Label lblPhone;
        private TextBox txtAddress;
        private Label lblAddress;
        private DateTimePicker dtpDateOfBirth;
        private Label lblDateOfBirth;
        private ComboBox cboGender;
        private Label lblGender;
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
        private Label lblErrorDob;
        private Label lblErrorGender;
        private Label lblErrorPhoneNumber;
        private Label lblErrorEmail;
        private Label lblErrorLastName;
        private Label lblErrorFirstName;
        private Label lblErrorExperience;
        private Label lblErrorSalary;
        private Label lblLastName;
        private Label lblFirstName;

    }

    #endregion
}

