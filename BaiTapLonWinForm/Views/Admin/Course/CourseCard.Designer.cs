namespace BaiTapLonWinForm.View.Admin.Course
{
    partial class CourseCard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cardPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            pnlBorderBottom = new Panel();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            btnEdit = new Guna.UI2.WinForms.Guna2Button();
            lblPrice = new Label();
            lblSessions = new Label();
            badgeLevel = new Guna.UI2.WinForms.Guna2Button();
            lblCourseCode = new Label();
            lblCourseName = new Label();
            cardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.Transparent;
            cardPanel.Controls.Add(pnlBorderBottom);
            cardPanel.Controls.Add(btnDelete);
            cardPanel.Controls.Add(btnEdit);
            cardPanel.Controls.Add(lblPrice);
            cardPanel.Controls.Add(lblSessions);
            cardPanel.Controls.Add(badgeLevel);
            cardPanel.Controls.Add(lblCourseCode);
            cardPanel.Controls.Add(lblCourseName);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.FillColor = Color.White;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Margin = new Padding(3, 4, 3, 4);
            cardPanel.Name = "cardPanel";
            cardPanel.Radius = 12;
            cardPanel.ShadowColor = Color.Black;
            cardPanel.ShadowDepth = 40;
            cardPanel.ShadowShift = 6;
            cardPanel.Size = new Size(440, 250);
            cardPanel.TabIndex = 0;
            // 
            // pnlBorderBottom
            // 
            pnlBorderBottom.BackColor = Color.WhiteSmoke;
            pnlBorderBottom.Location = new Point(10, 175);
            pnlBorderBottom.Name = "pnlBorderBottom";
            pnlBorderBottom.Size = new Size(420, 1);
            pnlBorderBottom.TabIndex = 9;
            // 
            // btnDelete
            // 
            btnDelete.BorderRadius = 8;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.CustomizableEdges = customizableEdges1;
            btnDelete.FillColor = Color.FromArgb(255, 235, 238);
            btnDelete.Font = new Font("Segoe UI", 10F);
            btnDelete.ForeColor = Color.FromArgb(231, 76, 60);
            btnDelete.Location = new Point(373, 186);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDelete.Size = new Size(40, 50);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑️";
            // 
            // btnEdit
            // 
            btnEdit.BorderRadius = 8;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.CustomizableEdges = customizableEdges3;
            btnEdit.FillColor = Color.FromArgb(240, 242, 245);
            btnEdit.Font = new Font("Segoe UI", 10F);
            btnEdit.ForeColor = Color.FromArgb(52, 152, 219);
            btnEdit.Location = new Point(323, 186);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEdit.Size = new Size(40, 50);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "✏️";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(46, 204, 113);
            lblPrice.Location = new Point(26, 191);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(203, 35);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "12.500.000 VNĐ";
            // 
            // lblSessions
            // 
            lblSessions.AutoSize = true;
            lblSessions.Font = new Font("Segoe UI", 9.5F);
            lblSessions.ForeColor = Color.Gray;
            lblSessions.Location = new Point(132, 140);
            lblSessions.Name = "lblSessions";
            lblSessions.Size = new Size(92, 21);
            lblSessions.TabIndex = 5;
            lblSessions.Text = "45 buổi học";
            // 
            // badgeLevel
            // 
            badgeLevel.BorderRadius = 10;
            badgeLevel.CustomizableEdges = customizableEdges5;
            badgeLevel.DisabledState.BorderColor = Color.DarkGray;
            badgeLevel.DisabledState.CustomBorderColor = Color.DarkGray;
            badgeLevel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            badgeLevel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            badgeLevel.FillColor = Color.FromArgb(232, 245, 233);
            badgeLevel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            badgeLevel.ForeColor = Color.FromArgb(46, 204, 113);
            badgeLevel.Location = new Point(30, 136);
            badgeLevel.Margin = new Padding(3, 4, 3, 4);
            badgeLevel.Name = "badgeLevel";
            badgeLevel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            badgeLevel.Size = new Size(90, 32);
            badgeLevel.TabIndex = 3;
            badgeLevel.Text = "Advanced";
            // 
            // lblCourseCode
            // 
            lblCourseCode.AutoSize = true;
            lblCourseCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCourseCode.ForeColor = Color.FromArgb(149, 165, 166);
            lblCourseCode.Location = new Point(28, 25);
            lblCourseCode.Name = "lblCourseCode";
            lblCourseCode.Size = new Size(79, 20);
            lblCourseCode.TabIndex = 2;
            lblCourseCode.Text = "#IELTS_01";
            // 
            // lblCourseName
            // 
            lblCourseName.AutoEllipsis = true;
            lblCourseName.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblCourseName.ForeColor = Color.FromArgb(52, 73, 94);
            lblCourseName.Location = new Point(25, 62);
            lblCourseName.MaximumSize = new Size(400, 70);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(400, 51);
            lblCourseName.TabIndex = 1;
            lblCourseName.Text = "Khóa học Luyện thi IELTS Cấp tốc";
            lblCourseName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CourseCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cardPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CourseCard";
            Size = new Size(440, 250);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel cardPanel;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblCourseCode;
        private Guna.UI2.WinForms.Guna2Button badgeLevel;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.Label lblPrice;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Panel pnlBorderBottom;
    }
}