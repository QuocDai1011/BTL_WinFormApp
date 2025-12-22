namespace BaiTapLonWinForm.View.Admin.Course
{
    partial class CourseDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblCourseCode = new System.Windows.Forms.Label();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();

            this.pnlContainer = new System.Windows.Forms.FlowLayoutPanel();

            // Stats Cards
            this.cardClasses = CreateStatCard("Số lớp đang mở", "05", System.Drawing.Color.FromArgb(52, 152, 219));
            this.cardStudents = CreateStatCard("Tổng học viên", "120", System.Drawing.Color.FromArgb(46, 204, 113));
            this.cardTuition = CreateStatCard("Học phí", "5.000.000đ", System.Drawing.Color.FromArgb(241, 196, 15));

            this.dgvClasses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.btnAddClass = new Guna.UI2.WinForms.Guna2Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();

            // 
            // CourseDetail (Main)
            // 
            this.Size = new System.Drawing.Size(1450, 850);
            this.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);

            // --- HEADER ---
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1450, 80);
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(btnBack);
            this.pnlHeader.Controls.Add(lblCourseName);
            this.pnlHeader.Controls.Add(lblCourseCode);
            this.pnlHeader.Controls.Add(btnEdit);

            // Button Back
            this.btnBack.Text = "← Quay lại";
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.ForeColor = System.Drawing.Color.Gray;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(20, 20);
            this.btnBack.Size = new System.Drawing.Size(120, 40);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;

            // Course Name
            this.lblCourseName.Text = "Tên Khóa Học";
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCourseName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblCourseName.Location = new System.Drawing.Point(160, 15);
            this.lblCourseName.AutoSize = true;

            // Course Code badge
            this.lblCourseCode.Text = "#CODE";
            this.lblCourseCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseCode.ForeColor = System.Drawing.Color.Gray;
            this.lblCourseCode.Location = new System.Drawing.Point(165, 50);
            this.lblCourseCode.AutoSize = true;

            // Edit Button (Top Right)
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.BorderRadius = 5;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.Location = new System.Drawing.Point(1300, 20);
            this.btnEdit.Size = new System.Drawing.Size(120, 40);

            // --- STATS CONTAINER ---
            this.pnlContainer.Location = new System.Drawing.Point(20, 100);
            this.pnlContainer.Size = new System.Drawing.Size(1410, 130);
            this.pnlContainer.Controls.Add(cardClasses);
            this.pnlContainer.Controls.Add(cardStudents);
            this.pnlContainer.Controls.Add(cardTuition);

            // --- CLASS LIST SECTION ---
            this.lblListTitle.Text = "Danh sách lớp học thuộc khóa này";
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(25, 250);
            this.lblListTitle.AutoSize = true;

            this.btnAddClass.Text = "+ Tạo lớp học mới";
            this.btnAddClass.FillColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddClass.BorderRadius = 5;
            this.btnAddClass.Location = new System.Drawing.Point(1250, 240);
            this.btnAddClass.Size = new System.Drawing.Size(170, 35);

            // DataGridView Classes
            this.dgvClasses.Location = new System.Drawing.Point(20, 290);
            this.dgvClasses.Size = new System.Drawing.Size(1400, 500);
            this.dgvClasses.BackgroundColor = System.Drawing.Color.White;
            this.dgvClasses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClasses.RowHeadersVisible = false;
            this.dgvClasses.AllowUserToAddRows = false;

            // Header Style
            headerStyle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            //headerStyle.Height = 40;
            this.dgvClasses.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvClasses.ColumnHeadersHeight = 40;
            this.dgvClasses.EnableHeadersVisualStyles = false;

            // Row Style
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.ForeColor = System.Drawing.Color.Black;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            rowStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvClasses.DefaultCellStyle = rowStyle;
            this.dgvClasses.RowTemplate.Height = 35;
            this.dgvClasses.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            // Add Controls
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlContainer);
            this.Controls.Add(lblListTitle);
            this.Controls.Add(btnAddClass);
            this.Controls.Add(dgvClasses);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);
        }

        // Helper tạo Card thống kê nhỏ
        private Guna.UI2.WinForms.Guna2ShadowPanel CreateStatCard(string title, string value, System.Drawing.Color color)
        {
            var panel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            panel.Size = new System.Drawing.Size(300, 100);
            panel.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            panel.FillColor = System.Drawing.Color.White;
            panel.Radius = 10;
            panel.ShadowDepth = 20;

            var lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = System.Drawing.Color.Gray;
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.AutoSize = true;

            var lblValue = new System.Windows.Forms.Label();
            lblValue.Text = value;
            lblValue.ForeColor = color;
            lblValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblValue.Location = new System.Drawing.Point(20, 45);
            lblValue.AutoSize = true;

            var strip = new Guna.UI2.WinForms.Guna2Panel();
            strip.FillColor = color;
            strip.Size = new System.Drawing.Size(5, 60);
            strip.Location = new System.Drawing.Point(0, 20);

            panel.Controls.Add(strip);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            return panel;
        }

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblCourseCode;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private System.Windows.Forms.FlowLayoutPanel pnlContainer;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardClasses;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardStudents;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardTuition;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClasses;
        private System.Windows.Forms.Label lblListTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddClass;
    }
}