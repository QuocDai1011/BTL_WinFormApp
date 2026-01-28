namespace BaiTapLonWinForm.Views.Teacher.ListToDo
{
    partial class ListToDoStudent
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GradientPanel9 = new Guna.UI2.WinForms.Guna2GradientPanel();
            menuStrip2 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            mscItem1 = new ToolStripMenuItem();
            mscItem2 = new ToolStripMenuItem();
            lblFeedback = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2GradientPanel10 = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ckbxName = new Guna.UI2.WinForms.Guna2CheckBox();
            guna2GradientPanel9.SuspendLayout();
            menuStrip2.SuspendLayout();
            guna2GradientPanel10.SuspendLayout();
            SuspendLayout();
            // 
            // guna2GradientPanel9
            // 
            guna2GradientPanel9.BorderThickness = 1;
            guna2GradientPanel9.Controls.Add(menuStrip2);
            guna2GradientPanel9.Controls.Add(lblFeedback);
            guna2GradientPanel9.Controls.Add(guna2GradientPanel10);
            guna2GradientPanel9.Controls.Add(ckbxName);
            guna2GradientPanel9.CustomBorderColor = Color.FromArgb(64, 64, 64);
            guna2GradientPanel9.CustomBorderThickness = new Padding(0, 0, 0, 1);
            guna2GradientPanel9.CustomizableEdges = customizableEdges3;
            guna2GradientPanel9.Location = new Point(0, 0);
            guna2GradientPanel9.Margin = new Padding(0, 0, 0, 10);
            guna2GradientPanel9.Name = "guna2GradientPanel9";
            guna2GradientPanel9.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GradientPanel9.Size = new Size(717, 80);
            guna2GradientPanel9.TabIndex = 1;
            // 
            // menuStrip2
            // 
            menuStrip2.BackgroundImageLayout = ImageLayout.Stretch;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(33, 33);
            menuStrip2.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip2.LayoutStyle = ToolStripLayoutStyle.Table;
            menuStrip2.Location = new Point(646, 14);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(59, 41);
            menuStrip2.TabIndex = 7;
            menuStrip2.Text = "menuStrip2";
            menuStrip2.TextDirection = ToolStripTextDirection.Vertical90;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem1.CheckOnClick = true;
            toolStripMenuItem1.CheckState = CheckState.Checked;
            toolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { mscItem1, mscItem2 });
            toolStripMenuItem1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripMenuItem1.Image = Properties.Resources.icon_ellipsis_black;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Padding = new Padding(8, 0, 8, 0);
            toolStripMenuItem1.RightToLeft = RightToLeft.Yes;
            toolStripMenuItem1.Size = new Size(53, 37);
            // 
            // mscItem1
            // 
            mscItem1.BackColor = Color.White;
            mscItem1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mscItem1.Font = new Font("Segoe UI", 11.25F);
            mscItem1.Name = "mscItem1";
            mscItem1.Padding = new Padding(0, 8, 0, 8);
            mscItem1.RightToLeft = RightToLeft.No;
            mscItem1.Size = new Size(220, 38);
            mscItem1.Text = "Trả bài";
            mscItem1.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // mscItem2
            // 
            mscItem2.BackColor = Color.White;
            mscItem2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mscItem2.Font = new Font("Segoe UI", 11.25F);
            mscItem2.Name = "mscItem2";
            mscItem2.Padding = new Padding(0, 8, 0, 8);
            mscItem2.RightToLeft = RightToLeft.No;
            mscItem2.Size = new Size(220, 38);
            mscItem2.Text = "Đánh dấu hoàn thành";
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = false;
            lblFeedback.BackColor = Color.Transparent;
            lblFeedback.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFeedback.Location = new Point(204, 31);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(221, 19);
            lblFeedback.TabIndex = 3;
            lblFeedback.Text = "Nhận xét của cô";
            // 
            // guna2GradientPanel10
            // 
            guna2GradientPanel10.BorderThickness = 1;
            guna2GradientPanel10.Controls.Add(lblScore);
            guna2GradientPanel10.Controls.Add(lblStatus);
            guna2GradientPanel10.CustomBorderColor = Color.FromArgb(64, 64, 64);
            guna2GradientPanel10.CustomBorderThickness = new Padding(1, 0, 0, 0);
            guna2GradientPanel10.CustomizableEdges = customizableEdges1;
            guna2GradientPanel10.Location = new Point(500, 3);
            guna2GradientPanel10.Name = "guna2GradientPanel10";
            guna2GradientPanel10.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientPanel10.Size = new Size(139, 71);
            guna2GradientPanel10.TabIndex = 2;
            // 
            // lblScore
            // 
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(59, 15);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(14, 27);
            lblScore.TabIndex = 1;
            lblScore.Text = "9";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(19, 40);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 19);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Đã chấm điểm";
            // 
            // ckbxName
            // 
            ckbxName.AutoSize = true;
            ckbxName.BackColor = Color.White;
            ckbxName.CheckedState.BorderColor = Color.Teal;
            ckbxName.CheckedState.BorderRadius = 4;
            ckbxName.CheckedState.BorderThickness = 0;
            ckbxName.CheckedState.FillColor = Color.Teal;
            ckbxName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ckbxName.Location = new Point(13, 29);
            ckbxName.Name = "ckbxName";
            ckbxName.Size = new Size(139, 21);
            ckbxName.TabIndex = 1;
            ckbxName.Text = "Nguyễn Khánh Hà";
            ckbxName.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ckbxName.UncheckedState.BorderRadius = 0;
            ckbxName.UncheckedState.BorderThickness = 0;
            ckbxName.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ckbxName.UseVisualStyleBackColor = false;
            // 
            // ListToDoStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2GradientPanel9);
            Name = "ListToDoStudent";
            Size = new Size(717, 80);
            guna2GradientPanel9.ResumeLayout(false);
            guna2GradientPanel9.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            guna2GradientPanel10.ResumeLayout(false);
            guna2GradientPanel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel9;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem mscItem1;
        private ToolStripMenuItem mscItem2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFeedback;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScore;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2CheckBox ckbxName;
    }
}
