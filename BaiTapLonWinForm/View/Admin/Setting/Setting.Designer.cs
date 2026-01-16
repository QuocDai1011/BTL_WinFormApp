using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Setting
{
    partial class Setting
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelMain = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            panelLeft = new Panel();
            grpProfile = new Guna2GroupBox();
            lblErrGender = new Label();
            label5 = new Label();
            lblErrEmail = new Label();
            lblErrPhone = new Label();
            lblErrFirstName = new Label();
            lblErrLastName = new Label();
            txtLastName = new Guna2TextBox();
            txtFirstName = new Guna2TextBox();
            txtPhone = new Guna2TextBox();
            txtEmail = new Guna2TextBox();
            labelBirthDate = new Label();
            dtpBirthDate = new Guna2DateTimePicker();
            txtAddress = new Guna2TextBox();
            labelGender = new Label();
            cboGender = new Guna2ComboBox();
            btnUpdateProfile = new Guna2Button();
            panelRight = new Panel();
            grpSecurity = new Guna2GroupBox();
            txtOldPass = new Guna2TextBox();
            txtNewPass = new Guna2TextBox();
            txtConfirmPass = new Guna2TextBox();
            btnChangePassword = new Guna2Button();
            grpSystem = new Guna2GroupBox();
            labelLanguage = new Label();
            cboLanguage = new Guna2ComboBox();
            labelTheme = new Label();
            cboTheme = new Guna2ComboBox();
            btnSaveSystem = new Guna2Button();
            grpLogout = new Guna2GroupBox();
            lblLogoutDesc = new Label();
            btnLogout = new Guna2Button();
            panelHeader = new Guna2Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            picHeaderIcon = new PictureBox();
            panelMain.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelLeft.SuspendLayout();
            grpProfile.SuspendLayout();
            panelRight.SuspendLayout();
            grpSecurity.SuspendLayout();
            grpSystem.SuspendLayout();
            grpLogout.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderIcon).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(tableLayoutPanel);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1450, 900);
            panelMain.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableLayoutPanel.Controls.Add(panelLeft, 0, 0);
            tableLayoutPanel.Controls.Add(panelRight, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 140);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(25, 10, 25, 30);
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(1450, 760);
            tableLayoutPanel.TabIndex = 1;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(grpProfile);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(28, 13);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(0, 0, 15, 0);
            panelLeft.Size = new Size(722, 714);
            panelLeft.TabIndex = 0;
            // 
            // grpProfile
            // 
            grpProfile.BackColor = Color.Transparent;
            grpProfile.BorderColor = Color.Transparent;
            grpProfile.BorderRadius = 20;
            grpProfile.Controls.Add(lblErrGender);
            grpProfile.Controls.Add(label5);
            grpProfile.Controls.Add(lblErrEmail);
            grpProfile.Controls.Add(lblErrPhone);
            grpProfile.Controls.Add(lblErrFirstName);
            grpProfile.Controls.Add(lblErrLastName);
            grpProfile.Controls.Add(txtLastName);
            grpProfile.Controls.Add(txtFirstName);
            grpProfile.Controls.Add(txtPhone);
            grpProfile.Controls.Add(txtEmail);
            grpProfile.Controls.Add(labelBirthDate);
            grpProfile.Controls.Add(dtpBirthDate);
            grpProfile.Controls.Add(txtAddress);
            grpProfile.Controls.Add(labelGender);
            grpProfile.Controls.Add(cboGender);
            grpProfile.Controls.Add(btnUpdateProfile);
            grpProfile.CustomBorderColor = Color.FromArgb(41, 128, 185);
            grpProfile.CustomizableEdges = customizableEdges7;
            grpProfile.Dock = DockStyle.Fill;
            grpProfile.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            grpProfile.ForeColor = Color.White;
            grpProfile.Location = new Point(0, 0);
            grpProfile.Name = "grpProfile";
            grpProfile.Padding = new Padding(0, 60, 0, 20);
            grpProfile.ShadowDecoration.BorderRadius = 20;
            grpProfile.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpProfile.ShadowDecoration.CustomizableEdges = customizableEdges8;
            grpProfile.ShadowDecoration.Depth = 15;
            grpProfile.ShadowDecoration.Enabled = true;
            grpProfile.Size = new Size(707, 714);
            grpProfile.TabIndex = 0;
            grpProfile.Text = "THÔNG TIN CÁ NHÂN";
            grpProfile.TextOffset = new Point(0, 5);
            // 
            // lblErrGender
            // 
            lblErrGender.AutoSize = true;
            lblErrGender.Font = new Font("Segoe UI", 10.2F);
            lblErrGender.ForeColor = Color.Red;
            lblErrGender.Location = new Point(358, 403);
            lblErrGender.Name = "lblErrGender";
            lblErrGender.Size = new Size(55, 23);
            lblErrGender.TabIndex = 16;
            lblErrGender.Text = "label6";
            lblErrGender.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(30, 403);
            label5.Name = "label5";
            label5.Size = new Size(55, 23);
            label5.TabIndex = 15;
            label5.Text = "label5";
            label5.Visible = false;
            // 
            // lblErrEmail
            // 
            lblErrEmail.AutoSize = true;
            lblErrEmail.Font = new Font("Segoe UI", 10.2F);
            lblErrEmail.ForeColor = Color.Red;
            lblErrEmail.Location = new Point(30, 216);
            lblErrEmail.Name = "lblErrEmail";
            lblErrEmail.Size = new Size(55, 23);
            lblErrEmail.TabIndex = 14;
            lblErrEmail.Text = "label4";
            lblErrEmail.Visible = false;
            // 
            // lblErrPhone
            // 
            lblErrPhone.AutoSize = true;
            lblErrPhone.Font = new Font("Segoe UI", 10.2F);
            lblErrPhone.ForeColor = Color.Red;
            lblErrPhone.Location = new Point(358, 211);
            lblErrPhone.Name = "lblErrPhone";
            lblErrPhone.Size = new Size(55, 23);
            lblErrPhone.TabIndex = 13;
            lblErrPhone.Text = "label3";
            lblErrPhone.Visible = false;
            // 
            // lblErrFirstName
            // 
            lblErrFirstName.AutoSize = true;
            lblErrFirstName.Font = new Font("Segoe UI", 10.2F);
            lblErrFirstName.ForeColor = Color.Red;
            lblErrFirstName.Location = new Point(30, 136);
            lblErrFirstName.Name = "lblErrFirstName";
            lblErrFirstName.Size = new Size(55, 23);
            lblErrFirstName.TabIndex = 12;
            lblErrFirstName.Text = "label2";
            lblErrFirstName.Visible = false;
            // 
            // lblErrLastName
            // 
            lblErrLastName.AutoSize = true;
            lblErrLastName.Font = new Font("Segoe UI", 10.2F);
            lblErrLastName.ForeColor = Color.Red;
            lblErrLastName.Location = new Point(358, 131);
            lblErrLastName.Name = "lblErrLastName";
            lblErrLastName.Size = new Size(55, 23);
            lblErrLastName.TabIndex = 11;
            lblErrLastName.Text = "label1";
            lblErrLastName.Visible = false;
            // 
            // txtLastName
            // 
            txtLastName.BorderRadius = 10;
            txtLastName.CustomizableEdges = customizableEdges1;
            txtLastName.DefaultText = "";
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.ForeColor = Color.FromArgb(52, 73, 94);
            txtLastName.Location = new Point(370, 80);
            txtLastName.Margin = new Padding(4, 6, 4, 6);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtLastName.PlaceholderText = "Tên";
            txtLastName.SelectedText = "";
            txtLastName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtLastName.Size = new Size(300, 50);
            txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderRadius = 10;
            txtFirstName.CustomizableEdges = customizableEdges3;
            txtFirstName.DefaultText = "";
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.ForeColor = Color.FromArgb(52, 73, 94);
            txtFirstName.Location = new Point(30, 80);
            txtFirstName.Margin = new Padding(4, 6, 4, 6);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtFirstName.PlaceholderText = "Họ đệm";
            txtFirstName.SelectedText = "";
            txtFirstName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFirstName.Size = new Size(300, 50);
            txtFirstName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.BorderRadius = 10;
            txtPhone.CustomizableEdges = customizableEdges5;
            txtPhone.DefaultText = "";
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.ForeColor = Color.FromArgb(52, 73, 94);
            txtPhone.Location = new Point(370, 160);
            txtPhone.Margin = new Padding(4, 6, 4, 6);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtPhone.PlaceholderText = "Số điện thoại";
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPhone.Size = new Size(300, 50);
            txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges5;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.FromArgb(52, 73, 94);
            txtEmail.Location = new Point(30, 160);
            txtEmail.Margin = new Padding(4, 6, 4, 6);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtEmail.PlaceholderText = "Email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEmail.Size = new Size(300, 50);
            txtEmail.TabIndex = 4;
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.BackColor = Color.White;
            labelBirthDate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            labelBirthDate.ForeColor = Color.FromArgb(52, 73, 94);
            labelBirthDate.Location = new Point(30, 320);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(81, 21);
            labelBirthDate.TabIndex = 6;
            labelBirthDate.Text = "Ngày sinh";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.BackColor = Color.White;
            dtpBirthDate.BorderRadius = 10;
            dtpBirthDate.Checked = true;
            dtpBirthDate.CustomizableEdges = customizableEdges5;
            dtpBirthDate.FillColor = Color.White;
            dtpBirthDate.Font = new Font("Segoe UI", 10F);
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(30, 350);
            dtpBirthDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpBirthDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpBirthDate.Size = new Size(300, 50);
            dtpBirthDate.TabIndex = 7;
            dtpBirthDate.Value = new DateTime(2025, 1, 5, 0, 0, 0, 0);
            // 
            // txtAddress
            // 
            txtAddress.BorderRadius = 10;
            txtAddress.CustomizableEdges = customizableEdges5;
            txtAddress.DefaultText = "";
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.ForeColor = Color.FromArgb(52, 73, 94);
            txtAddress.Location = new Point(30, 245);
            txtAddress.Margin = new Padding(4, 6, 4, 6);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtAddress.PlaceholderText = "Địa chỉ liên hệ";
            txtAddress.SelectedText = "";
            txtAddress.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtAddress.Size = new Size(640, 50);
            txtAddress.TabIndex = 5;
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.BackColor = Color.White;
            labelGender.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            labelGender.ForeColor = Color.FromArgb(52, 73, 94);
            labelGender.Location = new Point(370, 320);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(71, 21);
            labelGender.TabIndex = 8;
            labelGender.Text = "Giới tính";
            // 
            // cboGender
            // 
            cboGender.BackColor = Color.Transparent;
            cboGender.BorderRadius = 10;
            cboGender.CustomizableEdges = customizableEdges5;
            cboGender.DrawMode = DrawMode.OwnerDrawFixed;
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FocusedColor = Color.FromArgb(41, 128, 185);
            cboGender.FocusedState.BorderColor = Color.FromArgb(41, 128, 185);
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.ForeColor = Color.FromArgb(68, 88, 112);
            cboGender.ItemHeight = 30;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(370, 350);
            cboGender.Name = "cboGender";
            cboGender.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboGender.Size = new Size(300, 36);
            cboGender.TabIndex = 9;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.Animated = true;
            btnUpdateProfile.BackColor = Color.Transparent;
            btnUpdateProfile.BorderRadius = 12;
            btnUpdateProfile.CustomizableEdges = customizableEdges5;
            btnUpdateProfile.DisabledState.BorderColor = Color.DarkGray;
            btnUpdateProfile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdateProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdateProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdateProfile.FillColor = Color.FromArgb(39, 174, 96);
            btnUpdateProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile.HoverState.FillColor = Color.FromArgb(46, 204, 113);
            btnUpdateProfile.Location = new Point(142, 507);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.ShadowDecoration.BorderRadius = 12;
            btnUpdateProfile.ShadowDecoration.Color = Color.FromArgb(39, 174, 96);
            btnUpdateProfile.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUpdateProfile.ShadowDecoration.Depth = 10;
            btnUpdateProfile.ShadowDecoration.Enabled = true;
            btnUpdateProfile.Size = new Size(350, 58);
            btnUpdateProfile.TabIndex = 10;
            btnUpdateProfile.Text = "💾  CẬP NHẬT HỒ SƠ";
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(grpSecurity);
            panelRight.Controls.Add(grpSystem);
            panelRight.Controls.Add(grpLogout);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(756, 13);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(15, 0, 0, 0);
            panelRight.Size = new Size(666, 714);
            panelRight.TabIndex = 1;
            // 
            // grpSecurity
            // 
            grpSecurity.BackColor = Color.Transparent;
            grpSecurity.BorderColor = Color.Transparent;
            grpSecurity.BorderRadius = 20;
            grpSecurity.Controls.Add(txtOldPass);
            grpSecurity.Controls.Add(txtNewPass);
            grpSecurity.Controls.Add(txtConfirmPass);
            grpSecurity.Controls.Add(btnChangePassword);
            grpSecurity.CustomBorderColor = Color.FromArgb(52, 152, 219);
            grpSecurity.CustomizableEdges = customizableEdges5;
            grpSecurity.Dock = DockStyle.Top;
            grpSecurity.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            grpSecurity.ForeColor = Color.White;
            grpSecurity.Location = new Point(15, 160);
            grpSecurity.Margin = new Padding(3, 3, 3, 20);
            grpSecurity.Name = "grpSecurity";
            grpSecurity.Padding = new Padding(0, 60, 0, 15);
            grpSecurity.ShadowDecoration.BorderRadius = 20;
            grpSecurity.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpSecurity.ShadowDecoration.CustomizableEdges = customizableEdges6;
            grpSecurity.ShadowDecoration.Depth = 15;
            grpSecurity.ShadowDecoration.Enabled = true;
            grpSecurity.Size = new Size(651, 315);
            grpSecurity.TabIndex = 0;
            grpSecurity.Text = "BẢO MẬT";
            grpSecurity.TextOffset = new Point(0, 5);
            // 
            // txtOldPass
            // 
            txtOldPass.BorderRadius = 10;
            txtOldPass.CustomizableEdges = customizableEdges5;
            txtOldPass.DefaultText = "";
            txtOldPass.Font = new Font("Segoe UI", 10F);
            txtOldPass.ForeColor = Color.FromArgb(52, 73, 94);
            txtOldPass.Location = new Point(30, 63);
            txtOldPass.Margin = new Padding(4, 6, 4, 6);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.PasswordChar = '●';
            txtOldPass.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtOldPass.PlaceholderText = "Mật khẩu hiện tại";
            txtOldPass.SelectedText = "";
            txtOldPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtOldPass.Size = new Size(585, 50);
            txtOldPass.TabIndex = 0;
            txtOldPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderRadius = 10;
            txtNewPass.CustomizableEdges = customizableEdges5;
            txtNewPass.DefaultText = "";
            txtNewPass.Font = new Font("Segoe UI", 10F);
            txtNewPass.ForeColor = Color.FromArgb(52, 73, 94);
            txtNewPass.Location = new Point(30, 143);
            txtNewPass.Margin = new Padding(4, 6, 4, 6);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtNewPass.PlaceholderText = "Mật khẩu mới";
            txtNewPass.SelectedText = "";
            txtNewPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNewPass.Size = new Size(280, 50);
            txtNewPass.TabIndex = 1;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BorderRadius = 10;
            txtConfirmPass.CustomizableEdges = customizableEdges5;
            txtConfirmPass.DefaultText = "";
            txtConfirmPass.Font = new Font("Segoe UI", 10F);
            txtConfirmPass.ForeColor = Color.FromArgb(52, 73, 94);
            txtConfirmPass.Location = new Point(335, 143);
            txtConfirmPass.Margin = new Padding(4, 6, 4, 6);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PasswordChar = '●';
            txtConfirmPass.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtConfirmPass.PlaceholderText = "Xác nhận mật khẩu mới";
            txtConfirmPass.SelectedText = "";
            txtConfirmPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtConfirmPass.Size = new Size(280, 50);
            txtConfirmPass.TabIndex = 2;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Animated = true;
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.BorderRadius = 12;
            btnChangePassword.CustomizableEdges = customizableEdges5;
            btnChangePassword.FillColor = Color.FromArgb(52, 152, 219);
            btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.HoverState.FillColor = Color.FromArgb(41, 128, 185);
            btnChangePassword.Location = new Point(142, 222);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.ShadowDecoration.BorderRadius = 12;
            btnChangePassword.ShadowDecoration.Color = Color.FromArgb(52, 152, 219);
            btnChangePassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnChangePassword.ShadowDecoration.Depth = 10;
            btnChangePassword.ShadowDecoration.Enabled = true;
            btnChangePassword.Size = new Size(365, 58);
            btnChangePassword.TabIndex = 3;
            btnChangePassword.Text = "🔒  ĐỔI MẬT KHẨU";
            // 
            // grpSystem
            // 
            grpSystem.BackColor = Color.Transparent;
            grpSystem.BorderColor = Color.Transparent;
            grpSystem.BorderRadius = 20;
            grpSystem.Controls.Add(labelLanguage);
            grpSystem.Controls.Add(cboLanguage);
            grpSystem.Controls.Add(labelTheme);
            grpSystem.Controls.Add(cboTheme);
            grpSystem.Controls.Add(btnSaveSystem);
            grpSystem.CustomBorderColor = Color.FromArgb(155, 89, 182);
            grpSystem.CustomizableEdges = customizableEdges5;
            grpSystem.Dock = DockStyle.Top;
            grpSystem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            grpSystem.ForeColor = Color.White;
            grpSystem.Location = new Point(15, 0);
            grpSystem.Margin = new Padding(0, 15, 0, 0);
            grpSystem.Name = "grpSystem";
            grpSystem.Padding = new Padding(0, 60, 0, 15);
            grpSystem.ShadowDecoration.BorderRadius = 20;
            grpSystem.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpSystem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            grpSystem.ShadowDecoration.Depth = 15;
            grpSystem.ShadowDecoration.Enabled = true;
            grpSystem.Size = new Size(651, 160);
            grpSystem.TabIndex = 1;
            grpSystem.Text = "CÀI ĐẶT HỆ THỐNG";
            grpSystem.TextOffset = new Point(0, 5);
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.BackColor = Color.White;
            labelLanguage.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            labelLanguage.ForeColor = Color.FromArgb(52, 73, 94);
            labelLanguage.Location = new Point(30, 68);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(84, 21);
            labelLanguage.TabIndex = 0;
            labelLanguage.Text = "Ngôn ngữ";
            // 
            // cboLanguage
            // 
            cboLanguage.BackColor = Color.Transparent;
            cboLanguage.BorderRadius = 10;
            cboLanguage.CustomizableEdges = customizableEdges5;
            cboLanguage.DrawMode = DrawMode.OwnerDrawFixed;
            cboLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLanguage.FocusedColor = Color.FromArgb(155, 89, 182);
            cboLanguage.FocusedState.BorderColor = Color.FromArgb(155, 89, 182);
            cboLanguage.Font = new Font("Segoe UI", 10F);
            cboLanguage.ForeColor = Color.FromArgb(68, 88, 112);
            cboLanguage.ItemHeight = 30;
            cboLanguage.Items.AddRange(new object[] { "Tiếng Việt", "English" });
            cboLanguage.Location = new Point(30, 95);
            cboLanguage.Name = "cboLanguage";
            cboLanguage.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboLanguage.Size = new Size(200, 36);
            cboLanguage.TabIndex = 1;
            // 
            // labelTheme
            // 
            labelTheme.AutoSize = true;
            labelTheme.BackColor = Color.White;
            labelTheme.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            labelTheme.ForeColor = Color.FromArgb(52, 73, 94);
            labelTheme.Location = new Point(260, 68);
            labelTheme.Name = "labelTheme";
            labelTheme.Size = new Size(79, 21);
            labelTheme.TabIndex = 2;
            labelTheme.Text = "Giao diện";
            // 
            // cboTheme
            // 
            cboTheme.BackColor = Color.Transparent;
            cboTheme.BorderRadius = 10;
            cboTheme.CustomizableEdges = customizableEdges5;
            cboTheme.DrawMode = DrawMode.OwnerDrawFixed;
            cboTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTheme.FocusedColor = Color.FromArgb(155, 89, 182);
            cboTheme.FocusedState.BorderColor = Color.FromArgb(155, 89, 182);
            cboTheme.Font = new Font("Segoe UI", 10F);
            cboTheme.ForeColor = Color.FromArgb(68, 88, 112);
            cboTheme.ItemHeight = 30;
            cboTheme.Items.AddRange(new object[] { "Sáng (Light)", "Xanh (Tre Xanh)", "Tối (Dark)" });
            cboTheme.Location = new Point(260, 95);
            cboTheme.Name = "cboTheme";
            cboTheme.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboTheme.Size = new Size(200, 36);
            cboTheme.TabIndex = 3;
            // 
            // btnSaveSystem
            // 
            btnSaveSystem.Animated = true;
            btnSaveSystem.BackColor = Color.Transparent;
            btnSaveSystem.BorderRadius = 10;
            btnSaveSystem.CustomizableEdges = customizableEdges5;
            btnSaveSystem.FillColor = Color.FromArgb(142, 68, 173);
            btnSaveSystem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveSystem.ForeColor = Color.White;
            btnSaveSystem.HoverState.FillColor = Color.FromArgb(155, 89, 182);
            btnSaveSystem.Location = new Point(490, 85);
            btnSaveSystem.Name = "btnSaveSystem";
            btnSaveSystem.ShadowDecoration.BorderRadius = 10;
            btnSaveSystem.ShadowDecoration.Color = Color.FromArgb(142, 68, 173);
            btnSaveSystem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSaveSystem.ShadowDecoration.Depth = 8;
            btnSaveSystem.ShadowDecoration.Enabled = true;
            btnSaveSystem.Size = new Size(158, 46);
            btnSaveSystem.TabIndex = 4;
            btnSaveSystem.Text = "⚙️  ÁP DỤNG";
            // 
            // grpLogout
            // 
            grpLogout.BackColor = Color.Transparent;
            grpLogout.BorderColor = Color.Transparent;
            grpLogout.BorderRadius = 20;
            grpLogout.Controls.Add(lblLogoutDesc);
            grpLogout.Controls.Add(btnLogout);
            grpLogout.CustomBorderColor = Color.FromArgb(231, 76, 60);
            grpLogout.CustomizableEdges = customizableEdges9;
            grpLogout.Dock = DockStyle.Bottom;
            grpLogout.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            grpLogout.ForeColor = Color.White;
            grpLogout.Location = new Point(15, 581);
            grpLogout.Margin = new Padding(0, 10, 0, 0);
            grpLogout.Name = "grpLogout";
            grpLogout.Padding = new Padding(0, 60, 0, 15);
            grpLogout.ShadowDecoration.BorderRadius = 20;
            grpLogout.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpLogout.ShadowDecoration.CustomizableEdges = customizableEdges10;
            grpLogout.ShadowDecoration.Depth = 15;
            grpLogout.ShadowDecoration.Enabled = true;
            grpLogout.Size = new Size(651, 133);
            grpLogout.TabIndex = 2;
            grpLogout.Text = "ĐĂNG XUẤT";
            grpLogout.TextOffset = new Point(0, 5);
            // 
            // lblLogoutDesc
            // 
            lblLogoutDesc.BackColor = Color.White;
            lblLogoutDesc.Font = new Font("Segoe UI", 10F);
            lblLogoutDesc.ForeColor = Color.FromArgb(127, 140, 141);
            lblLogoutDesc.Location = new Point(30, 70);
            lblLogoutDesc.Name = "lblLogoutDesc";
            lblLogoutDesc.Size = new Size(585, 40);
            lblLogoutDesc.TabIndex = 0;
            lblLogoutDesc.Text = "Đăng xuất khỏi hệ thống. Bạn sẽ cần đăng nhập lại để tiếp tục sử dụng.";
            lblLogoutDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.Animated = true;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BorderRadius = 12;
            btnLogout.CustomizableEdges = customizableEdges5;
            btnLogout.FillColor = Color.FromArgb(231, 76, 60);
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.HoverState.FillColor = Color.FromArgb(192, 57, 43);
            btnLogout.Location = new Point(180, 120);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.BorderRadius = 12;
            btnLogout.ShadowDecoration.Color = Color.FromArgb(231, 76, 60);
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogout.ShadowDecoration.Depth = 12;
            btnLogout.ShadowDecoration.Enabled = true;
            btnLogout.Size = new Size(285, 54);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "🚪  ĐĂNG XUẤT NGAY";
            btnLogout.Click += Logout_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picHeaderIcon);
            panelHeader.CustomizableEdges = customizableEdges11;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.FillColor = Color.White;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 20, 30, 20);
            panelHeader.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges12;
            panelHeader.ShadowDecoration.Depth = 10;
            panelHeader.ShadowDecoration.Enabled = true;
            panelHeader.ShadowDecoration.Shadow = new Padding(0, 2, 0, 8);
            panelHeader.Size = new Size(1450, 140);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Location = new Point(123, 85);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(397, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý thông tin cá nhân và cài đặt hệ thống";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(120, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(449, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THIẾT LẬP TÀI KHOẢN";
            // 
            // picHeaderIcon
            // 
            picHeaderIcon.BackColor = Color.Transparent;
            picHeaderIcon.Image = Properties.Resources.logo2019_png_1;
            picHeaderIcon.Location = new Point(30, 35);
            picHeaderIcon.Name = "picHeaderIcon";
            picHeaderIcon.Size = new Size(70, 70);
            picHeaderIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picHeaderIcon.TabIndex = 2;
            picHeaderIcon.TabStop = false;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panelMain);
            Name = "Setting";
            Size = new Size(1450, 900);
            panelMain.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            grpProfile.ResumeLayout(false);
            grpProfile.PerformLayout();
            panelRight.ResumeLayout(false);
            grpSecurity.ResumeLayout(false);
            grpSystem.ResumeLayout(false);
            grpSystem.PerformLayout();
            grpLogout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private Guna2Panel panelHeader;
        private PictureBox picHeaderIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;

        // Profile Controls
        private Guna2GroupBox grpProfile;
        private Guna2TextBox txtFirstName;
        private Guna2TextBox txtLastName;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPhone;
        private Guna2TextBox txtAddress;
        private System.Windows.Forms.Label labelBirthDate;
        private Guna2DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label labelGender;
        private Guna2ComboBox cboGender;
        private Guna2Button btnUpdateProfile;

        // Security Controls
        private Guna2GroupBox grpSecurity;
        private Guna2TextBox txtOldPass;
        private Guna2TextBox txtNewPass;
        private Guna2TextBox txtConfirmPass;
        private Guna2Button btnChangePassword;

        // System Controls
        private Guna2GroupBox grpSystem;
        private System.Windows.Forms.Label labelLanguage;
        private Guna2ComboBox cboLanguage;
        private System.Windows.Forms.Label labelTheme;
        private Guna2ComboBox cboTheme;
        private Guna2Button btnSaveSystem;

        // Logout Controls
        private Guna2GroupBox grpLogout;
        private System.Windows.Forms.Label lblLogoutDesc;
        private Guna2Button btnLogout;
        private Label lblErrGender;
        private Label label5;
        private Label lblErrEmail;
        private Label lblErrPhone;
        private Label lblErrFirstName;
        private Label lblErrLastName;
    }
}