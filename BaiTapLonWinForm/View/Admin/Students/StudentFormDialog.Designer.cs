namespace BaiTapLonWinForm.View.Admin.Students
{
    partial class StudentFormDialog
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblParentPhone = new System.Windows.Forms.Label();
            this.txtParentPhone = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelForm.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLastName.Location = new System.Drawing.Point(20, 20);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(35, 19);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Họ:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.Location = new System.Drawing.Point(150, 17);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(300, 25);
            this.txtLastName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFirstName.Location = new System.Drawing.Point(20, 60);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(36, 19);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Tên:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(150, 57);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(300, 25);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(20, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 19);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(150, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 25);
            this.txtEmail.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGender.Location = new System.Drawing.Point(20, 140);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(70, 19);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Giới tính:";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGender.Location = new System.Drawing.Point(150, 137);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(300, 25);
            this.cboGender.TabIndex = 7;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateOfBirth.Location = new System.Drawing.Point(20, 180);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(77, 19);
            this.lblDateOfBirth.TabIndex = 8;
            this.lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(150, 177);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(300, 25);
            this.dtpDateOfBirth.TabIndex = 9;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(20, 220);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(57, 19);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(150, 217);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 50);
            this.txtAddress.TabIndex = 11;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhoneNumber.Location = new System.Drawing.Point(20, 285);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(96, 19);
            this.lblPhoneNumber.TabIndex = 12;
            this.lblPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(150, 282);
            this.txtPhoneNumber.MaxLength = 10;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(300, 25);
            this.txtPhoneNumber.TabIndex = 13;
            // 
            // lblParentPhone
            // 
            this.lblParentPhone.AutoSize = true;
            this.lblParentPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParentPhone.Location = new System.Drawing.Point(20, 325);
            this.lblParentPhone.Name = "lblParentPhone";
            this.lblParentPhone.Size = new System.Drawing.Size(115, 19);
            this.lblParentPhone.TabIndex = 14;
            this.lblParentPhone.Text = "SĐT Phụ huynh:";
            // 
            // txtParentPhone
            // 
            this.txtParentPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtParentPhone.Location = new System.Drawing.Point(150, 322);
            this.txtParentPhone.MaxLength = 10;
            this.txtParentPhone.Name = "txtParentPhone";
            this.txtParentPhone.Size = new System.Drawing.Size(300, 25);
            this.txtParentPhone.TabIndex = 15;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsActive.Location = new System.Drawing.Point(150, 365);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(99, 23);
            this.chkIsActive.TabIndex = 16;
            this.chkIsActive.Text = "Hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.lblLastName);
            this.panelForm.Controls.Add(this.chkIsActive);
            this.panelForm.Controls.Add(this.txtLastName);
            this.panelForm.Controls.Add(this.txtParentPhone);
            this.panelForm.Controls.Add(this.lblFirstName);
            this.panelForm.Controls.Add(this.lblParentPhone);
            this.panelForm.Controls.Add(this.txtFirstName);
            this.panelForm.Controls.Add(this.txtPhoneNumber);
            this.panelForm.Controls.Add(this.lblEmail);
            this.panelForm.Controls.Add(this.lblPhoneNumber);
            this.panelForm.Controls.Add(this.txtEmail);
            this.panelForm.Controls.Add(this.txtAddress);
            this.panelForm.Controls.Add(this.lblGender);
            this.panelForm.Controls.Add(this.lblAddress);
            this.panelForm.Controls.Add(this.cboGender);
            this.panelForm.Controls.Add(this.dtpDateOfBirth);
            this.panelForm.Controls.Add(this.lblDateOfBirth);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(484, 410);
            this.panelForm.TabIndex = 17;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 410);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(484, 70);
            this.panelButtons.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // StudentFormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 480);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentFormDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin sinh viên";
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblParentPhone;
        private System.Windows.Forms.TextBox txtParentPhone;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel panelButtons;
    }
}