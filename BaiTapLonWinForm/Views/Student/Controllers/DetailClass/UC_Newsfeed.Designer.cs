namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    partial class UC_Newsfeed
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Newsfeed));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnQuitAction = new Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lbTitle = new Label();
            btnAddComment = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            pnFeed = new Panel();
            pnQuitAction.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnQuitAction
            // 
            pnQuitAction.Controls.Add(guna2Panel1);
            pnQuitAction.Dock = DockStyle.Left;
            pnQuitAction.Location = new Point(5, 5);
            pnQuitAction.Name = "pnQuitAction";
            pnQuitAction.Size = new Size(327, 604);
            pnQuitAction.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.Black;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(lbTitle);
            guna2Panel1.Controls.Add(btnAddComment);
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(60, 19);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(200, 100);
            guna2Panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.BackColor = Color.Transparent;
            lbTitle.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.Black;
            lbTitle.Location = new Point(60, 12);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(129, 22);
            lbTitle.TabIndex = 29;
            lbTitle.Text = "Study Online";
            // 
            // btnAddComment
            // 
            btnAddComment.BorderColor = Color.Teal;
            btnAddComment.BorderRadius = 20;
            btnAddComment.BorderThickness = 1;
            btnAddComment.CustomizableEdges = customizableEdges1;
            btnAddComment.DisabledState.BorderColor = Color.DarkGray;
            btnAddComment.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddComment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddComment.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnAddComment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddComment.FillColor = Color.White;
            btnAddComment.FillColor2 = Color.White;
            btnAddComment.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddComment.ForeColor = Color.Teal;
            btnAddComment.HoverState.BorderColor = Color.Teal;
            btnAddComment.HoverState.CustomBorderColor = Color.Teal;
            btnAddComment.HoverState.FillColor = Color.Teal;
            btnAddComment.HoverState.FillColor2 = Color.Teal;
            btnAddComment.HoverState.ForeColor = Color.White;
            btnAddComment.Location = new Point(25, 49);
            btnAddComment.Name = "btnAddComment";
            btnAddComment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddComment.Size = new Size(151, 38);
            btnAddComment.TabIndex = 28;
            btnAddComment.Text = "Tham gia";
            btnAddComment.Click += btnAddComment_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(25, 8);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(34, 34);
            guna2PictureBox1.TabIndex = 0;
            guna2PictureBox1.TabStop = false;
            // 
            // pnFeed
            // 
            pnFeed.AutoScroll = true;
            pnFeed.Dock = DockStyle.Fill;
            pnFeed.Location = new Point(332, 5);
            pnFeed.Name = "pnFeed";
            pnFeed.Padding = new Padding(5);
            pnFeed.Size = new Size(802, 604);
            pnFeed.TabIndex = 1;
            // 
            // UC_Newsfeed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(pnFeed);
            Controls.Add(pnQuitAction);
            Name = "UC_Newsfeed";
            Padding = new Padding(5);
            Size = new Size(1139, 614);
            Load += UC_Newsfeed_Load;
            pnQuitAction.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnQuitAction;
        private Panel pnFeed;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddComment;
        private Label lbTitle;
    }
}
