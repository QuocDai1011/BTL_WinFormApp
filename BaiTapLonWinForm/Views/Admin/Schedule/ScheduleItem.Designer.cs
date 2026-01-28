namespace BaiTapLonWinForm.View.Admin.Schedule
{
    partial class ScheduleItem
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlStrip;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            lblTime = new Label();
            lblCourse = new Label();
            lblTeacher = new Label();
            lblClassName = new Label();
            pnlStrip = new Guna.UI2.WinForms.Guna2Panel();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.Transparent;
            pnlMain.BorderColor = Color.FromArgb(224, 224, 224);
            pnlMain.BorderRadius = 8;
            pnlMain.BorderThickness = 1;
            pnlMain.Controls.Add(lblTime);
            pnlMain.Controls.Add(lblCourse);
            pnlMain.Controls.Add(lblTeacher);
            pnlMain.Controls.Add(lblClassName);
            pnlMain.Controls.Add(pnlStrip);
            pnlMain.CustomizableEdges = customizableEdges3;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = Color.White;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(5);
            pnlMain.ShadowDecoration.BorderRadius = 8;
            pnlMain.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlMain.ShadowDecoration.Depth = 10;
            pnlMain.ShadowDecoration.Enabled = true;
            pnlMain.ShadowDecoration.Shadow = new Padding(2, 2, 4, 4);
            pnlMain.Size = new Size(170, 110);
            pnlMain.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.Dock = DockStyle.Top;
            lblTime.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic);
            lblTime.ForeColor = Color.FromArgb(0, 120, 215);
            lblTime.Location = new Point(10, 63);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(155, 18);
            lblTime.TabIndex = 4;
            lblTime.Text = "⏰ 08:00 - 09:30";
            // 
            // lblCourse
            // 
            lblCourse.Dock = DockStyle.Top;
            lblCourse.Font = new Font("Segoe UI", 7.8F);
            lblCourse.ForeColor = Color.Gray;
            lblCourse.Location = new Point(10, 45);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(155, 18);
            lblCourse.TabIndex = 3;
            lblCourse.Text = "📚 IELTS 2024";
            // 
            // lblTeacher
            // 
            lblTeacher.Dock = DockStyle.Top;
            lblTeacher.Font = new Font("Segoe UI", 8F);
            lblTeacher.ForeColor = Color.DimGray;
            lblTeacher.Location = new Point(10, 27);
            lblTeacher.Name = "lblTeacher";
            lblTeacher.Size = new Size(155, 18);
            lblTeacher.TabIndex = 2;
            lblTeacher.Text = "👤 Nguyễn Văn A";
            // 
            // lblClassName
            // 
            lblClassName.Dock = DockStyle.Top;
            lblClassName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblClassName.ForeColor = Color.FromArgb(64, 64, 64);
            lblClassName.Location = new Point(10, 5);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(155, 22);
            lblClassName.TabIndex = 1;
            lblClassName.Text = "ENG-BASIC-01";
            // 
            // pnlStrip
            // 
            pnlStrip.BackColor = Color.Transparent;
            pnlStrip.BorderRadius = 4;
            pnlStrip.CustomizableEdges = customizableEdges1;
            pnlStrip.Dock = DockStyle.Left;
            pnlStrip.FillColor = Color.FromArgb(66, 165, 245);
            pnlStrip.Location = new Point(5, 5);
            pnlStrip.Name = "pnlStrip";
            pnlStrip.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlStrip.Size = new Size(5, 100);
            pnlStrip.TabIndex = 0;
            // 
            // ScheduleItem
            // 
            BackColor = Color.Transparent;
            Controls.Add(pnlMain);
            Cursor = Cursors.Hand;
            Margin = new Padding(4);
            Name = "ScheduleItem";
            Size = new Size(170, 110);
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

