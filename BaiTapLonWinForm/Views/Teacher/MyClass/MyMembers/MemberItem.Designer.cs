namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    partial class MemberItem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BackColor = Color.White;
            guna2CustomGradientPanel1.BorderColor = Color.Gray;
            guna2CustomGradientPanel1.Controls.Add(lblUserName);
            guna2CustomGradientPanel1.Controls.Add(guna2CirclePictureBox1);
            guna2CustomGradientPanel1.CustomBorderThickness = new Padding(0, 1, 0, 1);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel1.Size = new Size(491, 51);
            guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Left;
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(75, 13);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(133, 23);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Nguyễn Khánh Hà";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox1.FillColor = Color.Teal;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(13, 0);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(51, 51);
            guna2CirclePictureBox1.TabIndex = 0;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // MemberItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2CustomGradientPanel1);
            Margin = new Padding(0, 0, 0, 16);
            Name = "MemberItem";
            Size = new Size(491, 51);
            Load += MemberItem_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
    }
}
