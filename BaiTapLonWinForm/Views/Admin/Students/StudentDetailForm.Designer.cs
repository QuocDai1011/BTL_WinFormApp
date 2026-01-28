namespace BaiTapLonWinForm.View.Admin.Students
{
    partial class StudentDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblStatusUser = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanelClasses = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeaderClasses = new System.Windows.Forms.Label();
            this.panelInfoContainer = new System.Windows.Forms.Panel();

            // Khai báo các Label chi tiết
            this.labelEmailTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.panelLine1 = new System.Windows.Forms.Panel();

            this.labelDobTitle = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.panelLine2 = new System.Windows.Forms.Panel();

            this.labelGenderTitle = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.panelLine3 = new System.Windows.Forms.Panel();

            this.labelPhoneTitle = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.panelLine4 = new System.Windows.Forms.Panel();

            this.labelAddressTitle = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.panelLine5 = new System.Windows.Forms.Panel();

            this.labelParentPhoneTitle = new System.Windows.Forms.Label();
            this.lblParentPhone = new System.Windows.Forms.Label();
            this.panelLine6 = new System.Windows.Forms.Panel();

            this.labelJoinDateTitle = new System.Windows.Forms.Label();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.panelLine7 = new System.Windows.Forms.Panel();

            this.lblHeaderInfo = new System.Windows.Forms.Label();

            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelInfoContainer.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelLeft.Controls.Add(this.lblStatusUser);
            this.panelLeft.Controls.Add(this.lblStudentId);
            this.panelLeft.Controls.Add(this.lblFullName);
            this.panelLeft.Controls.Add(this.picAvatar);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 750);
            this.panelLeft.TabIndex = 0;

            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAvatar.Location = new System.Drawing.Point(75, 50);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(150, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;

            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.White;
            this.lblFullName.Location = new System.Drawing.Point(10, 220);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(280, 80);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "HỌ VÀ TÊN";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // lblStudentId
            // 
            this.lblStudentId.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblStudentId.ForeColor = System.Drawing.Color.Silver;
            this.lblStudentId.Location = new System.Drawing.Point(10, 300);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(280, 30);
            this.lblStudentId.TabIndex = 2;
            this.lblStudentId.Text = "Mã HV: ---";
            this.lblStudentId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblStatusUser
            // 
            this.lblStatusUser.AutoSize = true;
            this.lblStatusUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatusUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusUser.ForeColor = System.Drawing.Color.White;
            this.lblStatusUser.Location = new System.Drawing.Point(100, 340);
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblStatusUser.Size = new System.Drawing.Size(80, 33);
            this.lblStatusUser.TabIndex = 3;
            this.lblStatusUser.Text = "Active";

            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.flowLayoutPanelClasses);
            this.panelRight.Controls.Add(this.lblHeaderClasses);
            this.panelRight.Controls.Add(this.panelInfoContainer);
            this.panelRight.Controls.Add(this.lblHeaderInfo);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(300, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(30);
            this.panelRight.Size = new System.Drawing.Size(900, 750);
            this.panelRight.TabIndex = 1;

            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.AutoSize = true;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblHeaderInfo.Location = new System.Drawing.Point(30, 30);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(221, 32);
            this.lblHeaderInfo.TabIndex = 0;
            this.lblHeaderInfo.Text = "Thông tin cá nhân";

            // 
            // panelInfoContainer
            // 
            this.panelInfoContainer.Location = new System.Drawing.Point(30, 80);
            this.panelInfoContainer.Name = "panelInfoContainer";
            this.panelInfoContainer.Size = new System.Drawing.Size(845, 280);
            this.panelInfoContainer.TabIndex = 1;

            // --- CẤU HÌNH CÁC LABEL THỦ CÔNG ĐỂ HIỂN THỊ TRONG DESIGNER ---

            // 1. Email (Left)
            ConfigureLabelTitle(this.labelEmailTitle, "Email:", 0, 0);
            ConfigureLabelValue(this.lblEmail, "---", 0, 25);
            ConfigureLine(this.panelLine1, 0, 55);

            // 2. Ngày sinh (Right)
            ConfigureLabelTitle(this.labelDobTitle, "Ngày sinh:", 320, 0);
            ConfigureLabelValue(this.lblDob, "---", 320, 25);
            ConfigureLine(this.panelLine2, 320, 55);

            // 3. Giới tính (Left, Row 2)
            ConfigureLabelTitle(this.labelGenderTitle, "Giới tính:", 0, 70);
            ConfigureLabelValue(this.lblGender, "---", 0, 95);
            ConfigureLine(this.panelLine3, 0, 125);

            // 4. SĐT Cá nhân (Right, Row 2)
            ConfigureLabelTitle(this.labelPhoneTitle, "SĐT cá nhân:", 320, 70);
            ConfigureLabelValue(this.lblPhone, "---", 320, 95);
            ConfigureLine(this.panelLine4, 320, 125);

            // 5. Địa chỉ (Full Width, Row 3)
            ConfigureLabelTitle(this.labelAddressTitle, "Địa chỉ:", 0, 140);
            ConfigureLabelValue(this.lblAddress, "---", 0, 165, 600);
            ConfigureLine(this.panelLine5, 0, 195, 600);

            // 6. SĐT Phụ huynh (Left, Row 4)
            ConfigureLabelTitle(this.labelParentPhoneTitle, "SĐT Phụ huynh:", 0, 210);
            ConfigureLabelValue(this.lblParentPhone, "---", 0, 235);
            ConfigureLine(this.panelLine6, 0, 265);

            // 7. Ngày tham gia (Right, Row 4)
            ConfigureLabelTitle(this.labelJoinDateTitle, "Ngày tham gia:", 320, 210);
            ConfigureLabelValue(this.lblJoinDate, "---", 320, 235);
            ConfigureLine(this.panelLine7, 320, 265);

            // Add controls to panel
            this.panelInfoContainer.Controls.Add(this.labelEmailTitle);
            this.panelInfoContainer.Controls.Add(this.lblEmail);
            this.panelInfoContainer.Controls.Add(this.panelLine1);

            this.panelInfoContainer.Controls.Add(this.labelDobTitle);
            this.panelInfoContainer.Controls.Add(this.lblDob);
            this.panelInfoContainer.Controls.Add(this.panelLine2);

            this.panelInfoContainer.Controls.Add(this.labelGenderTitle);
            this.panelInfoContainer.Controls.Add(this.lblGender);
            this.panelInfoContainer.Controls.Add(this.panelLine3);

            this.panelInfoContainer.Controls.Add(this.labelPhoneTitle);
            this.panelInfoContainer.Controls.Add(this.lblPhone);
            this.panelInfoContainer.Controls.Add(this.panelLine4);

            this.panelInfoContainer.Controls.Add(this.labelAddressTitle);
            this.panelInfoContainer.Controls.Add(this.lblAddress);
            this.panelInfoContainer.Controls.Add(this.panelLine5);

            this.panelInfoContainer.Controls.Add(this.labelParentPhoneTitle);
            this.panelInfoContainer.Controls.Add(this.lblParentPhone);
            this.panelInfoContainer.Controls.Add(this.panelLine6);

            this.panelInfoContainer.Controls.Add(this.labelJoinDateTitle);
            this.panelInfoContainer.Controls.Add(this.lblJoinDate);
            this.panelInfoContainer.Controls.Add(this.panelLine7);

            // 
            // lblHeaderClasses
            // 
            this.lblHeaderClasses.AutoSize = true;
            this.lblHeaderClasses.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderClasses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblHeaderClasses.Location = new System.Drawing.Point(30, 380);
            this.lblHeaderClasses.Name = "lblHeaderClasses";
            this.lblHeaderClasses.Size = new System.Drawing.Size(227, 32);
            this.lblHeaderClasses.TabIndex = 2;
            this.lblHeaderClasses.Text = "Lớp đang theo học";

            // 
            // flowLayoutPanelClasses
            // 
            this.flowLayoutPanelClasses.AutoScroll = true;
            this.flowLayoutPanelClasses.Location = new System.Drawing.Point(30, 430);
            this.flowLayoutPanelClasses.Name = "flowLayoutPanelClasses";
            this.flowLayoutPanelClasses.Size = new System.Drawing.Size(845, 290);
            this.flowLayoutPanelClasses.TabIndex = 3;

            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(820, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // StudentDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "StudentDetailForm";
            this.Text = "StudentDetailForm";

            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelInfoContainer.ResumeLayout(false);
            this.panelInfoContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        // Các hàm Helper để set thuộc tính cho gọn code trong InitializeComponent
        private void ConfigureLabelTitle(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            lbl.ForeColor = System.Drawing.Color.Gray;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = text;
        }

        private void ConfigureLabelValue(System.Windows.Forms.Label lbl, string text, int x, int y, int width = 280)
        {
            lbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            lbl.ForeColor = System.Drawing.Color.Black;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Size = new System.Drawing.Size(width, 30);
            lbl.Text = text;
        }

        private void ConfigureLine(System.Windows.Forms.Panel pnl, int x, int y, int width = 280)
        {
            pnl.BackColor = System.Drawing.Color.LightGray;
            pnl.Location = new System.Drawing.Point(x, y);
            pnl.Size = new System.Drawing.Size(width, 1);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblStatusUser;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Panel panelInfoContainer;
        private System.Windows.Forms.Label lblHeaderClasses;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelClasses;
        private System.Windows.Forms.Button btnClose;

        // Khai báo Label rõ ràng
        private System.Windows.Forms.Label labelEmailTitle, lblEmail;
        private System.Windows.Forms.Panel panelLine1;

        private System.Windows.Forms.Label labelDobTitle, lblDob;
        private System.Windows.Forms.Panel panelLine2;

        private System.Windows.Forms.Label labelGenderTitle, lblGender;
        private System.Windows.Forms.Panel panelLine3;

        private System.Windows.Forms.Label labelPhoneTitle, lblPhone;
        private System.Windows.Forms.Panel panelLine4;

        private System.Windows.Forms.Label labelAddressTitle, lblAddress;
        private System.Windows.Forms.Panel panelLine5;

        private System.Windows.Forms.Label labelParentPhoneTitle, lblParentPhone;
        private System.Windows.Forms.Panel panelLine6;

        private System.Windows.Forms.Label labelJoinDateTitle, lblJoinDate;
        private System.Windows.Forms.Panel panelLine7;
    }
}