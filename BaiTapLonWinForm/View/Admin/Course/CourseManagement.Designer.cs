namespace BaiTapLonWinForm.View.Admin.Course
{
    partial class CourseManagement
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutPanelCourses = new FlowLayoutPanel();
            headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            btnAddCourse = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(240, 244, 247);
            mainPanel.Controls.Add(flowLayoutPanelCourses);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.CustomizableEdges = customizableEdges7;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            mainPanel.Size = new Size(1450, 1062);
            mainPanel.TabIndex = 0;
            // 
            // flowLayoutPanelCourses
            // 
            flowLayoutPanelCourses.AutoScroll = true;
            flowLayoutPanelCourses.BackColor = Color.White;
            flowLayoutPanelCourses.Dock = DockStyle.Fill;
            flowLayoutPanelCourses.Location = new Point(0, 125);
            flowLayoutPanelCourses.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelCourses.Name = "flowLayoutPanelCourses";
            flowLayoutPanelCourses.Padding = new Padding(20, 12, 20, 12);
            flowLayoutPanelCourses.Size = new Size(1450, 937);
            flowLayoutPanelCourses.TabIndex = 1;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(btnAddCourse);
            headerPanel.Controls.Add(txtSearch);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.CustomBorderColor = Color.FromArgb(224, 224, 224);
            headerPanel.CustomBorderThickness = new Padding(0, 0, 0, 1);
            headerPanel.CustomizableEdges = customizableEdges5;
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            headerPanel.Size = new Size(1450, 125);
            headerPanel.TabIndex = 0;
            // 
            // btnAddCourse
            // 
            btnAddCourse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddCourse.BorderRadius = 8;
            btnAddCourse.CustomizableEdges = customizableEdges1;
            btnAddCourse.DisabledState.BorderColor = Color.DarkGray;
            btnAddCourse.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddCourse.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddCourse.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddCourse.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAddCourse.ForeColor = Color.White;
            btnAddCourse.Location = new Point(1280, 38);
            btnAddCourse.Margin = new Padding(3, 4, 3, 4);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddCourse.Size = new Size(140, 56);
            btnAddCourse.TabIndex = 2;
            btnAddCourse.Text = "+ Thêm khóa học";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BorderRadius = 8;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconLeftOffset = new Point(10, 0);
            txtSearch.Location = new Point(940, 38);
            txtSearch.Margin = new Padding(3, 6, 3, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm khóa học...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(320, 56);
            txtSearch.TabIndex = 1;
            txtSearch.TextOffset = new Point(10, 0);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(30, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(261, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý khóa học";
            // 
            // CourseManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CourseManagement";
            Size = new Size(1450, 1062);
            mainPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnAddCourse;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCourses;
    }
}
