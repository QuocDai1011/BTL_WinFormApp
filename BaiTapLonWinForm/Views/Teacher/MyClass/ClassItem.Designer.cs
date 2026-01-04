
namespace BaiTapLonWinForm.Views.Teacher.Controls
{
    partial class ClassItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AutoScaleMode AutoScaleMode { get; private set; }

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblClassName = new Label();
            lblNote = new Label();
            lblCourseName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnClassDetail = new Guna.UI2.WinForms.Guna2GradientButton();
            label4 = new Label();
            lblTeacherName = new Label();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            lblSchoolDay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblShift = new Guna.UI2.WinForms.Guna2HtmlLabel();
            addNew1 = new BaiTapLonWinForm.Views.Teacher.MyClass.MyNews.AddNew();
            guna2CustomGradientPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            guna2CustomGradientPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblClassName
            // 
            lblClassName.AutoEllipsis = true;
            lblClassName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClassName.ForeColor = Color.Black;
            lblClassName.Location = new Point(18, 77);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(294, 23);
            lblClassName.TabIndex = 1;
            lblClassName.Text = "Lớp học Staters dành cho trẻ em";
            // 
            // lblNote
            // 
            lblNote.AutoEllipsis = true;
            lblNote.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNote.ForeColor = Color.Black;
            lblNote.Location = new Point(18, 107);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(284, 17);
            lblNote.TabIndex = 2;
            lblNote.Text = "Khóa học dành cho trẻ em lớp 1, 2, 3";
            // 
            // lblCourseName
            // 
            lblCourseName.BackColor = Color.Transparent;
            lblCourseName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCourseName.ForeColor = Color.White;
            lblCourseName.Location = new Point(7, 7);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(62, 17);
            lblCourseName.TabIndex = 3;
            lblCourseName.Text = "TOEIC_500";
            lblCourseName.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.AutoRoundedCorners = true;
            guna2CustomGradientPanel1.AutoSize = true;
            guna2CustomGradientPanel1.Controls.Add(lblCourseName);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.FillColor = Color.Teal;
            guna2CustomGradientPanel1.FillColor2 = Color.Teal;
            guna2CustomGradientPanel1.FillColor3 = Color.Teal;
            guna2CustomGradientPanel1.FillColor4 = Color.Teal;
            guna2CustomGradientPanel1.Location = new Point(20, 27);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(72, 30);
            guna2CustomGradientPanel1.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(btnClassDetail);
            guna2Panel1.Controls.Add(label4);
            guna2Panel1.Controls.Add(lblTeacherName);
            guna2Panel1.Controls.Add(guna2CirclePictureBox1);
            guna2Panel1.CustomBorderColor = Color.FromArgb(224, 224, 224);
            guna2Panel1.CustomBorderThickness = new Padding(0, 1, 0, 0);
            guna2Panel1.CustomizableEdges = customizableEdges6;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.Location = new Point(0, 181);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2Panel1.Size = new Size(330, 77);
            guna2Panel1.TabIndex = 11;
            // 
            // btnClassDetail
            // 
            btnClassDetail.BorderColor = Color.Teal;
            btnClassDetail.BorderRadius = 4;
            btnClassDetail.BorderThickness = 1;
            btnClassDetail.CustomizableEdges = customizableEdges3;
            btnClassDetail.DisabledState.BorderColor = Color.DarkGray;
            btnClassDetail.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClassDetail.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClassDetail.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnClassDetail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClassDetail.FillColor = Color.Transparent;
            btnClassDetail.FillColor2 = Color.Transparent;
            btnClassDetail.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClassDetail.ForeColor = Color.Teal;
            btnClassDetail.HoverState.BorderColor = Color.Teal;
            btnClassDetail.HoverState.CustomBorderColor = Color.Teal;
            btnClassDetail.HoverState.FillColor = Color.Teal;
            btnClassDetail.HoverState.FillColor2 = Color.Teal;
            btnClassDetail.HoverState.ForeColor = Color.White;
            btnClassDetail.Location = new Point(200, 15);
            btnClassDetail.Name = "btnClassDetail";
            btnClassDetail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClassDetail.Size = new Size(112, 38);
            btnClassDetail.TabIndex = 14;
            btnClassDetail.Text = "Chi tiết";
            btnClassDetail.Click += btnClassDetail_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(64, 15);
            label4.Name = "label4";
            label4.Size = new Size(62, 17);
            label4.TabIndex = 13;
            label4.Text = "Giáo viên";
            // 
            // lblTeacherName
            // 
            lblTeacherName.AutoSize = true;
            lblTeacherName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTeacherName.ForeColor = Color.Black;
            lblTeacherName.Location = new Point(64, 36);
            lblTeacherName.Name = "lblTeacherName";
            lblTeacherName.Size = new Size(76, 17);
            lblTeacherName.TabIndex = 12;
            lblTeacherName.Text = "John Smith";
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.FillColor = Color.Teal;
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(18, 15);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(40, 40);
            guna2CirclePictureBox1.TabIndex = 11;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2CustomGradientPanel2
            // 
            guna2CustomGradientPanel2.Controls.Add(lblSchoolDay);
            guna2CustomGradientPanel2.Controls.Add(lblShift);
            guna2CustomGradientPanel2.CustomizableEdges = customizableEdges8;
            guna2CustomGradientPanel2.FillColor = Color.Transparent;
            guna2CustomGradientPanel2.FillColor2 = Color.Transparent;
            guna2CustomGradientPanel2.FillColor3 = Color.Transparent;
            guna2CustomGradientPanel2.FillColor4 = Color.Transparent;
            guna2CustomGradientPanel2.Location = new Point(18, 142);
            guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            guna2CustomGradientPanel2.ShadowDecoration.CustomizableEdges = customizableEdges9;
            guna2CustomGradientPanel2.Size = new Size(294, 26);
            guna2CustomGradientPanel2.TabIndex = 12;
            // 
            // lblSchoolDay
            // 
            lblSchoolDay.BackColor = Color.Transparent;
            lblSchoolDay.Dock = DockStyle.Left;
            lblSchoolDay.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSchoolDay.ForeColor = Color.SeaGreen;
            lblSchoolDay.Location = new Point(0, 0);
            lblSchoolDay.Name = "lblSchoolDay";
            lblSchoolDay.Size = new Size(154, 23);
            lblSchoolDay.TabIndex = 12;
            lblSchoolDay.Text = "Thứ 2 - Thứ 4 - Thứ 6";
            // 
            // lblShift
            // 
            lblShift.BackColor = Color.Transparent;
            lblShift.Dock = DockStyle.Right;
            lblShift.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblShift.ForeColor = Color.SeaGreen;
            lblShift.Location = new Point(254, 0);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(40, 23);
            lblShift.TabIndex = 13;
            lblShift.Text = "19:00 ";
            // 
            // addNew1
            // 
            addNew1.BackColor = Color.White;
            addNew1.Location = new Point(226, 52);
            addNew1.Name = "addNew1";
            addNew1.Size = new Size(8, 8);
            addNew1.TabIndex = 13;
            // 
            // ClassItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(addNew1);
            Controls.Add(guna2CustomGradientPanel2);
            Controls.Add(guna2Panel1);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(lblNote);
            Controls.Add(lblClassName);
            Margin = new Padding(3, 3, 3, 12);
            Name = "ClassItem";
            Size = new Size(330, 258);
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            guna2CustomGradientPanel2.ResumeLayout(false);
            guna2CustomGradientPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClassName;
        private Label lblNote;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCourseName;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnClassDetail;
        private Label label4;
        private Label lblTeacherName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSchoolDay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblShift;
        private MyClass.MyNews.AddNew addNew1;
    }
}
