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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
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
            lblErrorConfirmPassword = new Label();
            lblErrorNewPassword = new Label();
            lblErrorOldPassword = new Label();
            txtOldPass = new Guna2TextBox();
            txtNewPass = new Guna2TextBox();
            txtConfirmPass = new Guna2TextBox();
            btnChangePassword = new Guna2Button();
            grpSystem = new Guna2GroupBox();
            labelTheme = new Label();
            cboTheme = new Guna2ComboBox();
            btnSaveSystem = new Guna2Button();
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
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderIcon).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(tableLayoutPanel);
            panelMain.Controls.Add(panelHeader);
            resources.ApplyResources(panelMain, "panelMain");
            panelMain.Name = "panelMain";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(panelLeft, 0, 0);
            tableLayoutPanel.Controls.Add(panelRight, 1, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(grpProfile);
            resources.ApplyResources(panelLeft, "panelLeft");
            panelLeft.Name = "panelLeft";
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
            resources.ApplyResources(grpProfile, "grpProfile");
            grpProfile.ForeColor = Color.White;
            grpProfile.Name = "grpProfile";
            grpProfile.ShadowDecoration.BorderRadius = 20;
            grpProfile.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpProfile.ShadowDecoration.CustomizableEdges = customizableEdges8;
            grpProfile.ShadowDecoration.Depth = 15;
            grpProfile.ShadowDecoration.Enabled = true;
            grpProfile.TextOffset = new Point(0, 5);
            // 
            // lblErrGender
            // 
            resources.ApplyResources(lblErrGender, "lblErrGender");
            lblErrGender.ForeColor = Color.Red;
            lblErrGender.Name = "lblErrGender";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = Color.Red;
            label5.Name = "label5";
            // 
            // lblErrEmail
            // 
            resources.ApplyResources(lblErrEmail, "lblErrEmail");
            lblErrEmail.ForeColor = Color.Red;
            lblErrEmail.Name = "lblErrEmail";
            // 
            // lblErrPhone
            // 
            resources.ApplyResources(lblErrPhone, "lblErrPhone");
            lblErrPhone.ForeColor = Color.Red;
            lblErrPhone.Name = "lblErrPhone";
            // 
            // lblErrFirstName
            // 
            resources.ApplyResources(lblErrFirstName, "lblErrFirstName");
            lblErrFirstName.ForeColor = Color.Red;
            lblErrFirstName.Name = "lblErrFirstName";
            // 
            // lblErrLastName
            // 
            resources.ApplyResources(lblErrLastName, "lblErrLastName");
            lblErrLastName.ForeColor = Color.Red;
            lblErrLastName.Name = "lblErrLastName";
            // 
            // txtLastName
            // 
            txtLastName.BorderRadius = 10;
            txtLastName.CustomizableEdges = customizableEdges1;
            txtLastName.DefaultText = "";
            resources.ApplyResources(txtLastName, "txtLastName");
            txtLastName.ForeColor = Color.FromArgb(52, 73, 94);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtLastName.PlaceholderText = "Last name";
            txtLastName.SelectedText = "";
            txtLastName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderRadius = 10;
            txtFirstName.CustomizableEdges = customizableEdges3;
            txtFirstName.DefaultText = "";
            resources.ApplyResources(txtFirstName, "txtFirstName");
            txtFirstName.ForeColor = Color.FromArgb(52, 73, 94);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtFirstName.PlaceholderText = "First name";
            txtFirstName.SelectedText = "";
            txtFirstName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            // 
            // txtPhone
            // 
            txtPhone.BorderRadius = 10;
            txtPhone.CustomizableEdges = customizableEdges5;
            txtPhone.DefaultText = "";
            resources.ApplyResources(txtPhone, "txtPhone");
            txtPhone.ForeColor = Color.FromArgb(52, 73, 94);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtPhone.PlaceholderText = "Phone number";
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges6;
            // 
            // txtEmail
            // 
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges5;
            txtEmail.DefaultText = "";
            resources.ApplyResources(txtEmail, "txtEmail");
            txtEmail.ForeColor = Color.FromArgb(52, 73, 94);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtEmail.PlaceholderText = "Email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            // 
            // labelBirthDate
            // 
            resources.ApplyResources(labelBirthDate, "labelBirthDate");
            labelBirthDate.BackColor = Color.White;
            labelBirthDate.ForeColor = Color.FromArgb(52, 73, 94);
            labelBirthDate.Name = "labelBirthDate";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.BackColor = Color.White;
            dtpBirthDate.BorderRadius = 10;
            dtpBirthDate.Checked = true;
            dtpBirthDate.CustomizableEdges = customizableEdges5;
            dtpBirthDate.FillColor = Color.White;
            resources.ApplyResources(dtpBirthDate, "dtpBirthDate");
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpBirthDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpBirthDate.Value = new DateTime(2025, 1, 5, 0, 0, 0, 0);
            // 
            // txtAddress
            // 
            txtAddress.BorderRadius = 10;
            txtAddress.CustomizableEdges = customizableEdges5;
            txtAddress.DefaultText = "";
            resources.ApplyResources(txtAddress, "txtAddress");
            txtAddress.ForeColor = Color.FromArgb(52, 73, 94);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtAddress.PlaceholderText = "Contact address";
            txtAddress.SelectedText = "";
            txtAddress.ShadowDecoration.CustomizableEdges = customizableEdges6;
            // 
            // labelGender
            // 
            resources.ApplyResources(labelGender, "labelGender");
            labelGender.BackColor = Color.White;
            labelGender.ForeColor = Color.FromArgb(52, 73, 94);
            labelGender.Name = "labelGender";
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
            resources.ApplyResources(cboGender, "cboGender");
            cboGender.ForeColor = Color.FromArgb(68, 88, 112);
            cboGender.Items.AddRange(new object[] { resources.GetString("cboGender.Items"), resources.GetString("cboGender.Items1") });
            cboGender.Name = "cboGender";
            cboGender.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            resources.ApplyResources(btnUpdateProfile, "btnUpdateProfile");
            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile.HoverState.FillColor = Color.FromArgb(46, 204, 113);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.ShadowDecoration.BorderRadius = 12;
            btnUpdateProfile.ShadowDecoration.Color = Color.FromArgb(39, 174, 96);
            btnUpdateProfile.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUpdateProfile.ShadowDecoration.Depth = 10;
            btnUpdateProfile.ShadowDecoration.Enabled = true;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(grpSecurity);
            panelRight.Controls.Add(grpSystem);
            resources.ApplyResources(panelRight, "panelRight");
            panelRight.Name = "panelRight";
            // 
            // grpSecurity
            // 
            grpSecurity.BackColor = Color.Transparent;
            grpSecurity.BorderColor = Color.Transparent;
            grpSecurity.BorderRadius = 20;
            grpSecurity.Controls.Add(lblErrorConfirmPassword);
            grpSecurity.Controls.Add(lblErrorNewPassword);
            grpSecurity.Controls.Add(lblErrorOldPassword);
            grpSecurity.Controls.Add(txtOldPass);
            grpSecurity.Controls.Add(txtNewPass);
            grpSecurity.Controls.Add(txtConfirmPass);
            grpSecurity.Controls.Add(btnChangePassword);
            grpSecurity.CustomBorderColor = Color.FromArgb(52, 152, 219);
            grpSecurity.CustomizableEdges = customizableEdges5;
            resources.ApplyResources(grpSecurity, "grpSecurity");
            grpSecurity.ForeColor = Color.White;
            grpSecurity.Name = "grpSecurity";
            grpSecurity.ShadowDecoration.BorderRadius = 20;
            grpSecurity.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpSecurity.ShadowDecoration.CustomizableEdges = customizableEdges6;
            grpSecurity.ShadowDecoration.Depth = 15;
            grpSecurity.ShadowDecoration.Enabled = true;
            grpSecurity.TextOffset = new Point(0, 5);
            // 
            // lblErrorConfirmPassword
            // 
            resources.ApplyResources(lblErrorConfirmPassword, "lblErrorConfirmPassword");
            lblErrorConfirmPassword.ForeColor = Color.Red;
            lblErrorConfirmPassword.Name = "lblErrorConfirmPassword";
            // 
            // lblErrorNewPassword
            // 
            resources.ApplyResources(lblErrorNewPassword, "lblErrorNewPassword");
            lblErrorNewPassword.ForeColor = Color.Red;
            lblErrorNewPassword.Name = "lblErrorNewPassword";
            // 
            // lblErrorOldPassword
            // 
            resources.ApplyResources(lblErrorOldPassword, "lblErrorOldPassword");
            lblErrorOldPassword.ForeColor = Color.Red;
            lblErrorOldPassword.Name = "lblErrorOldPassword";
            // 
            // txtOldPass
            // 
            txtOldPass.BorderRadius = 10;
            txtOldPass.CustomizableEdges = customizableEdges5;
            txtOldPass.DefaultText = "";
            resources.ApplyResources(txtOldPass, "txtOldPass");
            txtOldPass.ForeColor = Color.FromArgb(52, 73, 94);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.PasswordChar = '●';
            txtOldPass.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtOldPass.PlaceholderText = "Mật khẩu hiện tại";
            txtOldPass.SelectedText = "";
            txtOldPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtOldPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            txtNewPass.BorderRadius = 10;
            txtNewPass.CustomizableEdges = customizableEdges5;
            txtNewPass.DefaultText = "";
            resources.ApplyResources(txtNewPass, "txtNewPass");
            txtNewPass.ForeColor = Color.FromArgb(52, 73, 94);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.PasswordChar = '●';
            txtNewPass.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtNewPass.PlaceholderText = "Mật khẩu mới";
            txtNewPass.SelectedText = "";
            txtNewPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BorderRadius = 10;
            txtConfirmPass.CustomizableEdges = customizableEdges5;
            txtConfirmPass.DefaultText = "";
            resources.ApplyResources(txtConfirmPass, "txtConfirmPass");
            txtConfirmPass.ForeColor = Color.FromArgb(52, 73, 94);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PasswordChar = '●';
            txtConfirmPass.PlaceholderForeColor = Color.FromArgb(149, 165, 166);
            txtConfirmPass.PlaceholderText = "Xác nhận mật khẩu mới";
            txtConfirmPass.SelectedText = "";
            txtConfirmPass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Animated = true;
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.BorderRadius = 12;
            btnChangePassword.CustomizableEdges = customizableEdges5;
            btnChangePassword.FillColor = Color.FromArgb(52, 152, 219);
            resources.ApplyResources(btnChangePassword, "btnChangePassword");
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.HoverState.FillColor = Color.FromArgb(41, 128, 185);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.ShadowDecoration.BorderRadius = 12;
            btnChangePassword.ShadowDecoration.Color = Color.FromArgb(52, 152, 219);
            btnChangePassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnChangePassword.ShadowDecoration.Depth = 10;
            btnChangePassword.ShadowDecoration.Enabled = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // grpSystem
            // 
            grpSystem.BackColor = Color.Transparent;
            grpSystem.BorderColor = Color.Transparent;
            grpSystem.BorderRadius = 20;
            grpSystem.Controls.Add(labelTheme);
            grpSystem.Controls.Add(cboTheme);
            grpSystem.Controls.Add(btnSaveSystem);
            grpSystem.CustomBorderColor = Color.FromArgb(155, 89, 182);
            grpSystem.CustomizableEdges = customizableEdges5;
            resources.ApplyResources(grpSystem, "grpSystem");
            grpSystem.ForeColor = Color.White;
            grpSystem.Name = "grpSystem";
            grpSystem.ShadowDecoration.BorderRadius = 20;
            grpSystem.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            grpSystem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            grpSystem.ShadowDecoration.Depth = 15;
            grpSystem.ShadowDecoration.Enabled = true;
            grpSystem.TextOffset = new Point(0, 5);
            // 
            // labelTheme
            // 
            resources.ApplyResources(labelTheme, "labelTheme");
            labelTheme.BackColor = Color.White;
            labelTheme.ForeColor = Color.FromArgb(52, 73, 94);
            labelTheme.Name = "labelTheme";
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
            resources.ApplyResources(cboTheme, "cboTheme");
            cboTheme.ForeColor = Color.FromArgb(68, 88, 112);
            cboTheme.Items.AddRange(new object[] { resources.GetString("cboTheme.Items"), resources.GetString("cboTheme.Items1") });
            cboTheme.Name = "cboTheme";
            cboTheme.ShadowDecoration.CustomizableEdges = customizableEdges6;
            // 
            // btnSaveSystem
            // 
            btnSaveSystem.Animated = true;
            btnSaveSystem.BackColor = Color.Transparent;
            btnSaveSystem.BorderRadius = 10;
            btnSaveSystem.CustomizableEdges = customizableEdges5;
            btnSaveSystem.FillColor = Color.FromArgb(142, 68, 173);
            resources.ApplyResources(btnSaveSystem, "btnSaveSystem");
            btnSaveSystem.ForeColor = Color.White;
            btnSaveSystem.HoverState.FillColor = Color.FromArgb(155, 89, 182);
            btnSaveSystem.Name = "btnSaveSystem";
            btnSaveSystem.ShadowDecoration.BorderRadius = 10;
            btnSaveSystem.ShadowDecoration.Color = Color.FromArgb(142, 68, 173);
            btnSaveSystem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSaveSystem.ShadowDecoration.Depth = 8;
            btnSaveSystem.ShadowDecoration.Enabled = true;
            btnSaveSystem.Click += btnSaveSystem_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picHeaderIcon);
            panelHeader.CustomizableEdges = customizableEdges9;
            resources.ApplyResources(panelHeader, "panelHeader");
            panelHeader.FillColor = Color.White;
            panelHeader.Name = "panelHeader";
            panelHeader.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges10;
            panelHeader.ShadowDecoration.Depth = 10;
            panelHeader.ShadowDecoration.Enabled = true;
            panelHeader.ShadowDecoration.Shadow = new Padding(0, 2, 0, 8);
            // 
            // lblSubtitle
            // 
            resources.ApplyResources(lblSubtitle, "lblSubtitle");
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Name = "lblSubtitle";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Name = "lblTitle";
            // 
            // picHeaderIcon
            // 
            picHeaderIcon.BackColor = Color.Transparent;
            picHeaderIcon.Image = Properties.Resources.logo2019_png_1;
            resources.ApplyResources(picHeaderIcon, "picHeaderIcon");
            picHeaderIcon.Name = "picHeaderIcon";
            picHeaderIcon.TabStop = false;
            // 
            // Setting
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panelMain);
            Name = "Setting";
            panelMain.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            grpProfile.ResumeLayout(false);
            grpProfile.PerformLayout();
            panelRight.ResumeLayout(false);
            grpSecurity.ResumeLayout(false);
            grpSecurity.PerformLayout();
            grpSystem.ResumeLayout(false);
            grpSystem.PerformLayout();
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
        private System.Windows.Forms.Label labelTheme;
        private Guna2ComboBox cboTheme;
        private Guna2Button btnSaveSystem;
        private Label lblErrGender;
        private Label label5;
        private Label lblErrEmail;
        private Label lblErrPhone;
        private Label lblErrFirstName;
        private Label lblErrLastName;
        private Label lblErrorConfirmPassword;
        private Label lblErrorNewPassword;
        private Label lblErrorOldPassword;
    }
}