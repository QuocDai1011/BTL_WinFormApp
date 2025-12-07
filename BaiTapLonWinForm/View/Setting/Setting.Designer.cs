using System.ComponentModel;

namespace BaiTapLonWinForm.View.Setting
{
    partial class Setting
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
            tabControl = new TabControl();
            tabProfile = new TabPage();
            grpChangePassword = new GroupBox();
            lblOldPassword = new Label();
            txtOldPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnChangePassword = new Button();
            grpProfileInfo = new GroupBox();
            picAvatar = new PictureBox();
            btnChangeAvatar = new Button();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblGender = new Label();
            cboGender = new ComboBox();
            btnUpdateProfile = new Button();
            tabAppearance = new TabPage();
            grpPresetColors = new GroupBox();
            flowPresetColors = new FlowLayoutPanel();
            grpTheme = new GroupBox();
            lblBackgroundColor = new Label();
            panelColorPreview = new Panel();
            btnChooseColor = new Button();
            btnResetTheme = new Button();
            tabLanguage = new TabPage();
            grpLanguage = new GroupBox();
            rbVietnamese = new RadioButton();
            rbEnglish = new RadioButton();
            btnApplyLanguage = new Button();
            lblLanguageNote = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabProfile.SuspendLayout();
            grpChangePassword.SuspendLayout();
            grpProfileInfo.SuspendLayout();
            ((ISupportInitialize)picAvatar).BeginInit();
            tabAppearance.SuspendLayout();
            grpPresetColors.SuspendLayout();
            grpTheme.SuspendLayout();
            tabLanguage.SuspendLayout();
            grpLanguage.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 241);
            panelMain.Controls.Add(tabControl);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1450, 850);
            panelMain.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabProfile);
            tabControl.Controls.Add(tabAppearance);
            tabControl.Controls.Add(tabLanguage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(0, 80);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1450, 770);
            tabControl.TabIndex = 1;
            // 
            // tabProfile
            // 
            tabProfile.BackColor = Color.White;
            tabProfile.Controls.Add(grpChangePassword);
            tabProfile.Controls.Add(grpProfileInfo);
            tabProfile.Location = new Point(4, 32);
            tabProfile.Margin = new Padding(3, 4, 3, 4);
            tabProfile.Name = "tabProfile";
            tabProfile.Padding = new Padding(23, 27, 23, 27);
            tabProfile.Size = new Size(1442, 734);
            tabProfile.TabIndex = 0;
            tabProfile.Text = "Thông tin cá nhân";
            // 
            // grpChangePassword
            // 
            grpChangePassword.Controls.Add(lblOldPassword);
            grpChangePassword.Controls.Add(txtOldPassword);
            grpChangePassword.Controls.Add(lblNewPassword);
            grpChangePassword.Controls.Add(txtNewPassword);
            grpChangePassword.Controls.Add(lblConfirmPassword);
            grpChangePassword.Controls.Add(txtConfirmPassword);
            grpChangePassword.Controls.Add(btnChangePassword);
            grpChangePassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpChangePassword.Location = new Point(23, 463);
            grpChangePassword.Margin = new Padding(3, 4, 3, 4);
            grpChangePassword.Name = "grpChangePassword";
            grpChangePassword.Padding = new Padding(3, 4, 3, 4);
            grpChangePassword.Size = new Size(1393, 240);
            grpChangePassword.TabIndex = 1;
            grpChangePassword.TabStop = false;
            grpChangePassword.Text = "Đổi mật khẩu";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI", 9F);
            lblOldPassword.Location = new Point(34, 67);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(92, 20);
            lblOldPassword.TabIndex = 0;
            lblOldPassword.Text = "Mật khẩu cũ:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Font = new Font("Segoe UI", 10F);
            txtOldPassword.Location = new Point(34, 93);
            txtOldPassword.Margin = new Padding(3, 4, 3, 4);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(285, 30);
            txtOldPassword.TabIndex = 1;
            txtOldPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9F);
            lblNewPassword.Location = new Point(366, 67);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(103, 20);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "Mật khẩu mới:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.Location = new Point(366, 93);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(285, 30);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F);
            lblConfirmPassword.Location = new Point(697, 67);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(137, 20);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(697, 93);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(285, 30);
            txtConfirmPassword.TabIndex = 5;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(243, 156, 18);
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(811, 160);
            btnChangePassword.Margin = new Padding(3, 4, 3, 4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(171, 47);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = false;
            // 
            // grpProfileInfo
            // 
            grpProfileInfo.Controls.Add(picAvatar);
            grpProfileInfo.Controls.Add(btnChangeAvatar);
            grpProfileInfo.Controls.Add(lblUsername);
            grpProfileInfo.Controls.Add(txtUsername);
            grpProfileInfo.Controls.Add(lblFullName);
            grpProfileInfo.Controls.Add(txtFullName);
            grpProfileInfo.Controls.Add(lblEmail);
            grpProfileInfo.Controls.Add(txtEmail);
            grpProfileInfo.Controls.Add(lblPhone);
            grpProfileInfo.Controls.Add(txtPhone);
            grpProfileInfo.Controls.Add(lblAddress);
            grpProfileInfo.Controls.Add(txtAddress);
            grpProfileInfo.Controls.Add(lblDateOfBirth);
            grpProfileInfo.Controls.Add(dtpDateOfBirth);
            grpProfileInfo.Controls.Add(lblGender);
            grpProfileInfo.Controls.Add(cboGender);
            grpProfileInfo.Controls.Add(btnUpdateProfile);
            grpProfileInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpProfileInfo.Location = new Point(23, 27);
            grpProfileInfo.Margin = new Padding(3, 4, 3, 4);
            grpProfileInfo.Name = "grpProfileInfo";
            grpProfileInfo.Padding = new Padding(3, 4, 3, 4);
            grpProfileInfo.Size = new Size(1393, 420);
            grpProfileInfo.TabIndex = 0;
            grpProfileInfo.TabStop = false;
            grpProfileInfo.Text = "Thông tin người dùng";
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(34, 53);
            picAvatar.Margin = new Padding(3, 4, 3, 4);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(171, 199);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // btnChangeAvatar
            // 
            btnChangeAvatar.BackColor = Color.FromArgb(52, 152, 219);
            btnChangeAvatar.FlatStyle = FlatStyle.Flat;
            btnChangeAvatar.Font = new Font("Segoe UI", 9F);
            btnChangeAvatar.ForeColor = Color.White;
            btnChangeAvatar.Location = new Point(34, 267);
            btnChangeAvatar.Margin = new Padding(3, 4, 3, 4);
            btnChangeAvatar.Name = "btnChangeAvatar";
            btnChangeAvatar.Size = new Size(171, 47);
            btnChangeAvatar.TabIndex = 1;
            btnChangeAvatar.Text = "Đổi ảnh đại diện";
            btnChangeAvatar.UseVisualStyleBackColor = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.Location = new Point(250, 40);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(110, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Enabled = false;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(250, 67);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(342, 30);
            txtUsername.TabIndex = 5;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F);
            lblFullName.Location = new Point(250, 120);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 6;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(250, 147);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(342, 30);
            txtFullName.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(250, 200);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(250, 227);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(342, 30);
            txtEmail.TabIndex = 9;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.Location = new Point(250, 280);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(250, 307);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(342, 30);
            txtPhone.TabIndex = 11;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F);
            lblAddress.Location = new Point(651, 40);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(58, 20);
            lblAddress.TabIndex = 12;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(651, 67);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(399, 79);
            txtAddress.TabIndex = 13;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 9F);
            lblDateOfBirth.Location = new Point(651, 160);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(77, 20);
            lblDateOfBirth.TabIndex = 14;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(651, 187);
            dtpDateOfBirth.Margin = new Padding(3, 4, 3, 4);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(399, 30);
            dtpDateOfBirth.TabIndex = 15;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9F);
            lblGender.Location = new Point(651, 240);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 16;
            lblGender.Text = "Giới tính:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(651, 267);
            cboGender.Margin = new Padding(3, 4, 3, 4);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(399, 31);
            cboGender.TabIndex = 17;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.BackColor = Color.FromArgb(46, 204, 113);
            btnUpdateProfile.FlatStyle = FlatStyle.Flat;
            btnUpdateProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile.Location = new Point(879, 348);
            btnUpdateProfile.Margin = new Padding(3, 4, 3, 4);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.Size = new Size(171, 47);
            btnUpdateProfile.TabIndex = 20;
            btnUpdateProfile.Text = "Cập nhật";
            btnUpdateProfile.UseVisualStyleBackColor = false;
            // 
            // tabAppearance
            // 
            tabAppearance.BackColor = Color.White;
            tabAppearance.Controls.Add(grpPresetColors);
            tabAppearance.Controls.Add(grpTheme);
            tabAppearance.Location = new Point(4, 32);
            tabAppearance.Margin = new Padding(3, 4, 3, 4);
            tabAppearance.Name = "tabAppearance";
            tabAppearance.Padding = new Padding(23, 27, 23, 27);
            tabAppearance.Size = new Size(1442, 734);
            tabAppearance.TabIndex = 1;
            tabAppearance.Text = "Giao diện";
            // 
            // grpPresetColors
            // 
            grpPresetColors.Controls.Add(flowPresetColors);
            grpPresetColors.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpPresetColors.Location = new Point(23, 253);
            grpPresetColors.Margin = new Padding(3, 4, 3, 4);
            grpPresetColors.Name = "grpPresetColors";
            grpPresetColors.Padding = new Padding(3, 4, 3, 4);
            grpPresetColors.Size = new Size(1393, 415);
            grpPresetColors.TabIndex = 1;
            grpPresetColors.TabStop = false;
            grpPresetColors.Text = "Màu có sẵn";
            // 
            // flowPresetColors
            // 
            flowPresetColors.AutoScroll = true;
            flowPresetColors.Dock = DockStyle.Fill;
            flowPresetColors.Location = new Point(3, 29);
            flowPresetColors.Margin = new Padding(3, 4, 3, 4);
            flowPresetColors.Name = "flowPresetColors";
            flowPresetColors.Padding = new Padding(23, 27, 23, 27);
            flowPresetColors.Size = new Size(1387, 382);
            flowPresetColors.TabIndex = 0;
            // 
            // grpTheme
            // 
            grpTheme.Controls.Add(lblBackgroundColor);
            grpTheme.Controls.Add(panelColorPreview);
            grpTheme.Controls.Add(btnChooseColor);
            grpTheme.Controls.Add(btnResetTheme);
            grpTheme.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpTheme.Location = new Point(23, 27);
            grpTheme.Margin = new Padding(3, 4, 3, 4);
            grpTheme.Name = "grpTheme";
            grpTheme.Padding = new Padding(3, 4, 3, 4);
            grpTheme.Size = new Size(1393, 200);
            grpTheme.TabIndex = 0;
            grpTheme.TabStop = false;
            grpTheme.Text = "Màu nền ứng dụng";
            // 
            // lblBackgroundColor
            // 
            lblBackgroundColor.AutoSize = true;
            lblBackgroundColor.Font = new Font("Segoe UI", 9F);
            lblBackgroundColor.Location = new Point(34, 53);
            lblBackgroundColor.Name = "lblBackgroundColor";
            lblBackgroundColor.Size = new Size(122, 20);
            lblBackgroundColor.TabIndex = 0;
            lblBackgroundColor.Text = "Màu nền hiện tại:";
            // 
            // panelColorPreview
            // 
            panelColorPreview.BorderStyle = BorderStyle.FixedSingle;
            panelColorPreview.Location = new Point(34, 93);
            panelColorPreview.Margin = new Padding(3, 4, 3, 4);
            panelColorPreview.Name = "panelColorPreview";
            panelColorPreview.Size = new Size(228, 66);
            panelColorPreview.TabIndex = 1;
            // 
            // btnChooseColor
            // 
            btnChooseColor.BackColor = Color.FromArgb(52, 152, 219);
            btnChooseColor.FlatStyle = FlatStyle.Flat;
            btnChooseColor.Font = new Font("Segoe UI", 10F);
            btnChooseColor.ForeColor = Color.White;
            btnChooseColor.Location = new Point(286, 93);
            btnChooseColor.Margin = new Padding(3, 4, 3, 4);
            btnChooseColor.Name = "btnChooseColor";
            btnChooseColor.Size = new Size(171, 67);
            btnChooseColor.TabIndex = 2;
            btnChooseColor.Text = "Chọn màu";
            btnChooseColor.UseVisualStyleBackColor = false;
            // 
            // btnResetTheme
            // 
            btnResetTheme.BackColor = Color.FromArgb(149, 165, 166);
            btnResetTheme.FlatStyle = FlatStyle.Flat;
            btnResetTheme.Font = new Font("Segoe UI", 10F);
            btnResetTheme.ForeColor = Color.White;
            btnResetTheme.Location = new Point(480, 93);
            btnResetTheme.Margin = new Padding(3, 4, 3, 4);
            btnResetTheme.Name = "btnResetTheme";
            btnResetTheme.Size = new Size(171, 67);
            btnResetTheme.TabIndex = 3;
            btnResetTheme.Text = "Đặt lại mặc định";
            btnResetTheme.UseVisualStyleBackColor = false;
            // 
            // tabLanguage
            // 
            tabLanguage.BackColor = Color.White;
            tabLanguage.Controls.Add(grpLanguage);
            tabLanguage.Location = new Point(4, 32);
            tabLanguage.Margin = new Padding(3, 4, 3, 4);
            tabLanguage.Name = "tabLanguage";
            tabLanguage.Padding = new Padding(23, 27, 23, 27);
            tabLanguage.Size = new Size(1442, 734);
            tabLanguage.TabIndex = 2;
            tabLanguage.Text = "Ngôn ngữ";
            // 
            // grpLanguage
            // 
            grpLanguage.Controls.Add(rbVietnamese);
            grpLanguage.Controls.Add(rbEnglish);
            grpLanguage.Controls.Add(btnApplyLanguage);
            grpLanguage.Controls.Add(lblLanguageNote);
            grpLanguage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpLanguage.Location = new Point(23, 27);
            grpLanguage.Margin = new Padding(3, 4, 3, 4);
            grpLanguage.Name = "grpLanguage";
            grpLanguage.Padding = new Padding(3, 4, 3, 4);
            grpLanguage.Size = new Size(1393, 333);
            grpLanguage.TabIndex = 0;
            grpLanguage.TabStop = false;
            grpLanguage.Text = "Chọn ngôn ngữ";
            // 
            // rbVietnamese
            // 
            rbVietnamese.AutoSize = true;
            rbVietnamese.Checked = true;
            rbVietnamese.Font = new Font("Segoe UI", 10F);
            rbVietnamese.Location = new Point(34, 67);
            rbVietnamese.Margin = new Padding(3, 4, 3, 4);
            rbVietnamese.Name = "rbVietnamese";
            rbVietnamese.Size = new Size(131, 27);
            rbVietnamese.TabIndex = 0;
            rbVietnamese.TabStop = true;
            rbVietnamese.Text = "🇻🇳 Tiếng Việt";
            rbVietnamese.UseVisualStyleBackColor = true;
            // 
            // rbEnglish
            // 
            rbEnglish.AutoSize = true;
            rbEnglish.Font = new Font("Segoe UI", 10F);
            rbEnglish.Location = new Point(34, 120);
            rbEnglish.Margin = new Padding(3, 4, 3, 4);
            rbEnglish.Name = "rbEnglish";
            rbEnglish.Size = new Size(107, 27);
            rbEnglish.TabIndex = 1;
            rbEnglish.Text = "🇬🇧 English";
            rbEnglish.UseVisualStyleBackColor = true;
            // 
            // btnApplyLanguage
            // 
            btnApplyLanguage.BackColor = Color.FromArgb(46, 204, 113);
            btnApplyLanguage.FlatStyle = FlatStyle.Flat;
            btnApplyLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApplyLanguage.ForeColor = Color.White;
            btnApplyLanguage.Location = new Point(34, 240);
            btnApplyLanguage.Margin = new Padding(3, 4, 3, 4);
            btnApplyLanguage.Name = "btnApplyLanguage";
            btnApplyLanguage.Size = new Size(171, 53);
            btnApplyLanguage.TabIndex = 3;
            btnApplyLanguage.Text = "Áp dụng";
            btnApplyLanguage.UseVisualStyleBackColor = false;
            // 
            // lblLanguageNote
            // 
            lblLanguageNote.AutoSize = true;
            lblLanguageNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblLanguageNote.ForeColor = Color.FromArgb(127, 140, 141);
            lblLanguageNote.Location = new Point(34, 187);
            lblLanguageNote.Name = "lblLanguageNote";
            lblLanguageNote.Size = new Size(417, 20);
            lblLanguageNote.TabIndex = 2;
            lblLanguageNote.Text = "Lưu ý: Ứng dụng sẽ khởi động lại để áp dụng thay đổi ngôn ngữ.";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1450, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1450, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CÀI ĐẶT HỆ THỐNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Setting";
            Size = new Size(1450, 850);
            panelMain.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabProfile.ResumeLayout(false);
            grpChangePassword.ResumeLayout(false);
            grpChangePassword.PerformLayout();
            grpProfileInfo.ResumeLayout(false);
            grpProfileInfo.PerformLayout();
            ((ISupportInitialize)picAvatar).EndInit();
            tabAppearance.ResumeLayout(false);
            grpPresetColors.ResumeLayout(false);
            grpTheme.ResumeLayout(false);
            grpTheme.PerformLayout();
            tabLanguage.ResumeLayout(false);
            grpLanguage.ResumeLayout(false);
            grpLanguage.PerformLayout();
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabProfile;
        private TabPage tabAppearance;
        private TabPage tabLanguage;

        // Profile Tab
        private GroupBox grpProfileInfo;
        private PictureBox picAvatar;
        private Button btnChangeAvatar;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Label lblGender;
        private ComboBox cboGender;
        private Button btnUpdateProfile;
        private GroupBox grpChangePassword;
        private Label lblOldPassword;
        private TextBox txtOldPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnChangePassword;

        // Appearance Tab
        private GroupBox grpTheme;
        private Label lblBackgroundColor;
        private Panel panelColorPreview;
        private Button btnChooseColor;
        private Button btnResetTheme;
        private GroupBox grpPresetColors;
        private FlowLayoutPanel flowPresetColors;

        // Language Tab
        private GroupBox grpLanguage;
        private RadioButton rbVietnamese;
        private RadioButton rbEnglish;
        private Button btnApplyLanguage;
        private Label lblLanguageNote;
    }

        #endregion
    }

