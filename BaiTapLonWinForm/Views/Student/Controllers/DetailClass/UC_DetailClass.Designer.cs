namespace BaiTapLonWinForm.Views.Student.Controllers
{
    partial class UC_DetailClass
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pnlAssignment = new Guna.UI2.WinForms.Guna2Panel();
            btnAssignment = new Guna.UI2.WinForms.Guna2Button();
            pnlNewsFeed = new Guna.UI2.WinForms.Guna2Panel();
            btnNewsFeed = new Guna.UI2.WinForms.Guna2Button();
            pnLoad = new Panel();
            pnlHeader.SuspendLayout();
            guna2Panel1.SuspendLayout();
            pnlAssignment.SuspendLayout();
            pnlNewsFeed.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(guna2Panel1);
            pnlHeader.CustomizableEdges = customizableEdges11;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlHeader.Size = new Size(1093, 77);
            pnlHeader.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(pnlAssignment);
            guna2Panel1.Controls.Add(pnlNewsFeed);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(1093, 77);
            guna2Panel1.TabIndex = 0;
            // 
            // pnlAssignment
            // 
            pnlAssignment.Controls.Add(btnAssignment);
            pnlAssignment.CustomizableEdges = customizableEdges3;
            pnlAssignment.Dock = DockStyle.Left;
            pnlAssignment.Location = new Point(194, 0);
            pnlAssignment.Name = "pnlAssignment";
            pnlAssignment.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlAssignment.Size = new Size(207, 77);
            pnlAssignment.TabIndex = 4;
            // 
            // btnAssignment
            // 
            btnAssignment.BorderRadius = 20;
            btnAssignment.CustomizableEdges = customizableEdges1;
            btnAssignment.DisabledState.BorderColor = Color.DarkGray;
            btnAssignment.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAssignment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAssignment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAssignment.FillColor = Color.Teal;
            btnAssignment.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            btnAssignment.ForeColor = Color.White;
            btnAssignment.Location = new Point(12, 14);
            btnAssignment.Name = "btnAssignment";
            btnAssignment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAssignment.Size = new Size(180, 45);
            btnAssignment.TabIndex = 1;
            btnAssignment.Text = "Bài tập";
            btnAssignment.Click += btnAssignment_Click;
            // 
            // pnlNewsFeed
            // 
            pnlNewsFeed.Controls.Add(btnNewsFeed);
            pnlNewsFeed.CustomizableEdges = customizableEdges7;
            pnlNewsFeed.Dock = DockStyle.Left;
            pnlNewsFeed.Location = new Point(0, 0);
            pnlNewsFeed.Name = "pnlNewsFeed";
            pnlNewsFeed.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlNewsFeed.Size = new Size(194, 77);
            pnlNewsFeed.TabIndex = 3;
            // 
            // btnNewsFeed
            // 
            btnNewsFeed.BorderRadius = 20;
            btnNewsFeed.CustomizableEdges = customizableEdges5;
            btnNewsFeed.DisabledState.BorderColor = Color.DarkGray;
            btnNewsFeed.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNewsFeed.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNewsFeed.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNewsFeed.FillColor = Color.Teal;
            btnNewsFeed.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            btnNewsFeed.ForeColor = Color.White;
            btnNewsFeed.Location = new Point(6, 14);
            btnNewsFeed.Name = "btnNewsFeed";
            btnNewsFeed.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnNewsFeed.Size = new Size(180, 45);
            btnNewsFeed.TabIndex = 0;
            btnNewsFeed.Text = "Bảng tin";
            btnNewsFeed.Click += btnNewsFeed_Click_1;
            // 
            // pnLoad
            // 
            pnLoad.BackColor = Color.WhiteSmoke;
            pnLoad.Dock = DockStyle.Fill;
            pnLoad.Location = new Point(0, 77);
            pnLoad.Name = "pnLoad";
            pnLoad.Size = new Size(1093, 521);
            pnLoad.TabIndex = 1;
            // 
            // UC_DetailClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 245, 232);
            Controls.Add(pnLoad);
            Controls.Add(pnlHeader);
            ForeColor = Color.White;
            Name = "UC_DetailClass";
            Size = new Size(1093, 598);
            pnlHeader.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            pnlAssignment.ResumeLayout(false);
            pnlNewsFeed.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnNewsFeed;
        private Guna.UI2.WinForms.Guna2Button btnAssignment;
        private Guna.UI2.WinForms.Guna2Panel pnlNewsFeed;
        private Guna.UI2.WinForms.Guna2Panel pnlAssignment;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Panel pnLoad;
    }
}
