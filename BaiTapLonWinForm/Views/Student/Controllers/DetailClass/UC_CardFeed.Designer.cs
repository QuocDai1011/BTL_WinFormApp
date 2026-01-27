namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    partial class UC_CardFeed
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CardFeed));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Feed = new Panel();
            pnAction = new Panel();
            btnSend = new Guna.UI2.WinForms.Guna2GradientButton();
            tbinput = new Guna.UI2.WinForms.Guna2TextBox();
            btnAddComment = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            pnContent = new Panel();
            lbContent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnUser = new Panel();
            pnInfoUser = new Panel();
            lbCreatedAt = new Label();
            lbName = new Label();
            pnAvatar = new Panel();
            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            Feed.SuspendLayout();
            pnAction.SuspendLayout();
            pnContent.SuspendLayout();
            pnUser.SuspendLayout();
            pnInfoUser.SuspendLayout();
            pnAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Feed
            // 
            Feed.Controls.Add(pnAction);
            Feed.Controls.Add(pnContent);
            Feed.Controls.Add(pnUser);
            Feed.Dock = DockStyle.Fill;
            Feed.Location = new Point(5, 15);
            Feed.Name = "Feed";
            Feed.Size = new Size(465, 191);
            Feed.TabIndex = 1;
            // 
            // pnAction
            // 
            pnAction.BackColor = Color.Gainsboro;
            pnAction.Controls.Add(btnSend);
            pnAction.Controls.Add(tbinput);
            pnAction.Controls.Add(btnAddComment);
            pnAction.Controls.Add(guna2Panel5);
            pnAction.Dock = DockStyle.Fill;
            pnAction.Location = new Point(0, 137);
            pnAction.Name = "pnAction";
            pnAction.Padding = new Padding(5);
            pnAction.Size = new Size(465, 54);
            pnAction.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BorderColor = Color.DodgerBlue;
            btnSend.BorderRadius = 20;
            btnSend.BorderThickness = 1;
            btnSend.CustomizableEdges = customizableEdges1;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.FillColor = Color.White;
            btnSend.FillColor2 = Color.White;
            btnSend.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.Teal;
            btnSend.HoverState.BorderColor = Color.DarkGray;
            btnSend.HoverState.CustomBorderColor = Color.DarkGray;
            btnSend.HoverState.FillColor = Color.DarkGray;
            btnSend.HoverState.FillColor2 = Color.DarkGray;
            btnSend.HoverState.ForeColor = Color.White;
            btnSend.Image = (Image)resources.GetObject("btnSend.Image");
            btnSend.ImageAlign = HorizontalAlignment.Right;
            btnSend.Location = new Point(417, 10);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSend.Size = new Size(40, 40);
            btnSend.TabIndex = 29;
            btnSend.Visible = false;
            btnSend.Click += btnSend_Click;
            // 
            // tbinput
            // 
            tbinput.BorderRadius = 20;
            tbinput.CustomizableEdges = customizableEdges3;
            tbinput.DefaultText = "";
            tbinput.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbinput.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbinput.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbinput.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbinput.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbinput.Font = new Font("Segoe UI", 9F);
            tbinput.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbinput.Location = new Point(5, 11);
            tbinput.Name = "tbinput";
            tbinput.PlaceholderText = "";
            tbinput.SelectedText = "";
            tbinput.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbinput.Size = new Size(406, 36);
            tbinput.TabIndex = 28;
            tbinput.Visible = false;
            // 
            // btnAddComment
            // 
            btnAddComment.BorderColor = Color.Teal;
            btnAddComment.BorderRadius = 20;
            btnAddComment.BorderThickness = 1;
            btnAddComment.CustomizableEdges = customizableEdges5;
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
            btnAddComment.Location = new Point(8, 11);
            btnAddComment.Name = "btnAddComment";
            btnAddComment.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddComment.Size = new Size(151, 38);
            btnAddComment.TabIndex = 27;
            btnAddComment.Text = "Thêm nhận xét";
            btnAddComment.Click += btnAddComment_Click;
            // 
            // guna2Panel5
            // 
            guna2Panel5.BorderThickness = 2;
            guna2Panel5.CustomizableEdges = customizableEdges7;
            guna2Panel5.Dock = DockStyle.Top;
            guna2Panel5.FillColor = Color.DimGray;
            guna2Panel5.Location = new Point(5, 5);
            guna2Panel5.Name = "guna2Panel5";
            guna2Panel5.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel5.Size = new Size(455, 1);
            guna2Panel5.TabIndex = 26;
            // 
            // pnContent
            // 
            pnContent.BackColor = Color.Gainsboro;
            pnContent.Controls.Add(lbContent);
            pnContent.Dock = DockStyle.Top;
            pnContent.Location = new Point(0, 45);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(20, 0, 20, 0);
            pnContent.Size = new Size(465, 92);
            pnContent.TabIndex = 1;
            // 
            // lbContent
            // 
            lbContent.BackColor = Color.Transparent;
            lbContent.Location = new Point(23, 6);
            lbContent.Name = "lbContent";
            lbContent.Size = new Size(97, 17);
            lbContent.TabIndex = 0;
            lbContent.Text = "guna2HtmlLabel1";
            // 
            // pnUser
            // 
            pnUser.BackColor = Color.Gainsboro;
            pnUser.Controls.Add(pnInfoUser);
            pnUser.Controls.Add(pnAvatar);
            pnUser.Dock = DockStyle.Top;
            pnUser.Location = new Point(0, 0);
            pnUser.Name = "pnUser";
            pnUser.Padding = new Padding(20, 0, 20, 0);
            pnUser.Size = new Size(465, 45);
            pnUser.TabIndex = 0;
            // 
            // pnInfoUser
            // 
            pnInfoUser.Controls.Add(lbCreatedAt);
            pnInfoUser.Controls.Add(lbName);
            pnInfoUser.Dock = DockStyle.Left;
            pnInfoUser.Location = new Point(65, 0);
            pnInfoUser.Name = "pnInfoUser";
            pnInfoUser.Size = new Size(219, 45);
            pnInfoUser.TabIndex = 1;
            // 
            // lbCreatedAt
            // 
            lbCreatedAt.AutoSize = true;
            lbCreatedAt.Dock = DockStyle.Fill;
            lbCreatedAt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCreatedAt.ForeColor = Color.DimGray;
            lbCreatedAt.Location = new Point(0, 19);
            lbCreatedAt.Name = "lbCreatedAt";
            lbCreatedAt.Size = new Size(37, 15);
            lbCreatedAt.TabIndex = 1;
            lbCreatedAt.Text = "label1";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Dock = DockStyle.Top;
            lbName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lbName.ForeColor = Color.Black;
            lbName.Location = new Point(0, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(50, 19);
            lbName.TabIndex = 0;
            lbName.Text = "label1";
            // 
            // pnAvatar
            // 
            pnAvatar.Controls.Add(picAvatar);
            pnAvatar.Dock = DockStyle.Left;
            pnAvatar.Location = new Point(20, 0);
            pnAvatar.Name = "pnAvatar";
            pnAvatar.Size = new Size(45, 45);
            pnAvatar.TabIndex = 0;
            // 
            // picAvatar
            // 
            picAvatar.Dock = DockStyle.Fill;
            picAvatar.FillColor = Color.Teal;
            picAvatar.ImageRotate = 0F;
            picAvatar.Location = new Point(0, 0);
            picAvatar.Name = "picAvatar";
            picAvatar.ShadowDecoration.CustomizableEdges = customizableEdges9;
            picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            picAvatar.Size = new Size(45, 45);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.WhiteSmoke;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(Feed);
            guna2Panel1.CustomizableEdges = customizableEdges10;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.Gainsboro;
            guna2Panel1.Location = new Point(10, 10);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.Padding = new Padding(5, 15, 5, 5);
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges11;
            guna2Panel1.Size = new Size(475, 211);
            guna2Panel1.TabIndex = 2;
            // 
            // UC_CardFeed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 3, 3, 10);
            Name = "UC_CardFeed";
            Padding = new Padding(10);
            Size = new Size(495, 231);
            Feed.ResumeLayout(false);
            pnAction.ResumeLayout(false);
            pnContent.ResumeLayout(false);
            pnContent.PerformLayout();
            pnUser.ResumeLayout(false);
            pnInfoUser.ResumeLayout(false);
            pnInfoUser.PerformLayout();
            pnAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Feed;
        private Panel pnAction;
        private Panel pnContent;
        private Panel pnUser;
        private Panel pnInfoUser;
        private Panel pnAvatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbContent;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label lbCreatedAt;
        private Label lbName;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddComment;
        private Guna.UI2.WinForms.Guna2TextBox tbinput;
        private Guna.UI2.WinForms.Guna2GradientButton btnSend;
    }
}
