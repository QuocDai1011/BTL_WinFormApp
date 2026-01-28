namespace BaiTapLonWinForm.View.Admin.Students
{
    partial class StudentManagement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            dgvStudents = new DataGridView();
            clmStudentName = new DataGridViewTextBoxColumn();
            clmClassName = new DataGridViewTextBoxColumn();
            clmPromotionName = new DataGridViewTextBoxColumn();
            clmTotalAmount = new DataGridViewTextBoxColumn();
            clmPaidAmount = new DataGridViewTextBoxColumn();
            clmStatusPaid = new DataGridViewTextBoxColumn();
            clmCreateAt = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            panelTop = new Panel();
            panel4 = new Panel();
            button6 = new Button();
            panel5 = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            UserId = new DataGridViewTextBoxColumn();
            StudentId = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            PhoneNumberOfParent = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            FaceImageCount = new DataGridViewTextBoxColumn();
            btnImport = new Button();
            btnExport = new Button();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            panelStats = new Panel();
            lblTotalStudents = new Label();
            lblStatsTitle = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelButtons = new Panel();
            btnAddPhoto = new Button();
            cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            pnlContent = new Panel();
            btnRestore = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            panelTop.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelStats.SuspendLayout();
            panelSearch.SuspendLayout();
            panelButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(31, 19);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📚 QUẢN LÝ BIÊN LAI";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AllowUserToResizeRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStudents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.ColumnHeadersHeight = 45;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { clmStudentName, clmClassName, clmPromotionName, clmTotalAmount, clmPaidAmount, clmStatusPaid, clmCreateAt });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.GridColor = Color.FromArgb(236, 240, 241);
            dgvStudents.Location = new Point(31, 206);
            dgvStudents.Margin = new Padding(4);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvStudents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 40;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1781, 712);
            dgvStudents.TabIndex = 3;
            dgvStudents.DoubleClick += dgvStudents_DoubleClick;
            // 
            // clmStudentName
            // 
            clmStudentName.HeaderText = "Tên học viên";
            clmStudentName.MinimumWidth = 8;
            clmStudentName.Name = "clmStudentName";
            clmStudentName.ReadOnly = true;
            // 
            // clmClassName
            // 
            clmClassName.HeaderText = "Tên lớp học";
            clmClassName.MinimumWidth = 8;
            clmClassName.Name = "clmClassName";
            clmClassName.ReadOnly = true;
            // 
            // clmPromotionName
            // 
            clmPromotionName.HeaderText = "Loại khuyến mãi";
            clmPromotionName.MinimumWidth = 8;
            clmPromotionName.Name = "clmPromotionName";
            clmPromotionName.ReadOnly = true;
            // 
            // clmTotalAmount
            // 
            clmTotalAmount.HeaderText = "Tổng học phí";
            clmTotalAmount.MinimumWidth = 8;
            clmTotalAmount.Name = "clmTotalAmount";
            clmTotalAmount.ReadOnly = true;
            // 
            // clmPaidAmount
            // 
            clmPaidAmount.HeaderText = "Đã thanh toán";
            clmPaidAmount.MinimumWidth = 8;
            clmPaidAmount.Name = "clmPaidAmount";
            clmPaidAmount.ReadOnly = true;
            // 
            // clmStatusPaid
            // 
            clmStatusPaid.HeaderText = "Trạng thái";
            clmStatusPaid.MinimumWidth = 8;
            clmStatusPaid.Name = "clmStatusPaid";
            clmStatusPaid.ReadOnly = true;
            // 
            // clmCreateAt
            // 
            clmCreateAt.HeaderText = "Được tạo ngày";
            clmCreateAt.MinimumWidth = 8;
            clmCreateAt.Name = "clmCreateAt";
            clmCreateAt.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(35, 11);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(12, 0, 12, 0);
            btnAdd.Size = new Size(251, 50);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Thêm học viên";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(294, 11);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(175, 50);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(476, 11);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(634, 11);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(162, 50);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(panel4);
            panelTop.Controls.Add(panelStats);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1850, 88);
            panelTop.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(button6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(dataGridView1);
            panel4.Controls.Add(btnImport);
            panel4.Controls.Add(btnExport);
            panel4.Controls.Add(guna2ComboBox1);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1850, 88);
            panel4.TabIndex = 11;
            // 
            // button6
            // 
            button6.BackColor = Color.DeepSkyBlue;
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(1152, 944);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(194, 56);
            button6.TabIndex = 8;
            button6.Text = "🔄 Khôi phục";
            button6.UseVisualStyleBackColor = false;
            button6.Visible = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(panel3);
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1850, 88);
            panel5.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(52, 152, 219);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(1568, 6);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(245, 75);
            panel3.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(184, 18);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(33, 38);
            label5.TabIndex = 1;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 25);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(148, 30);
            label6.TabIndex = 0;
            label6.Text = "Tổng biên lai:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(31, 19);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(413, 48);
            label4.TabIndex = 0;
            label4.Text = "📚 QUẢN LÝ HỌC VIÊN";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(236, 240, 241);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(30, 106);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(700, 75);
            panel2.TabIndex = 1;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(52, 152, 219);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(546, 11);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(125, 50);
            button5.TabIndex = 2;
            button5.Text = "Tìm";
            button5.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Location = new Point(176, 20);
            textBox1.Margin = new Padding(4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên sinh viên...";
            textBox1.Size = new Size(362, 34);
            textBox1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(19, 22);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(139, 28);
            label3.TabIndex = 0;
            label3.Text = "🔍 Tìm kiếm:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(236, 240, 241);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Location = new Point(784, 106);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1029, 75);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(149, 165, 166);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(783, 11);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(215, 50);
            button1.TabIndex = 3;
            button1.Text = "🔄 Làm mới";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(231, 76, 60);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(556, 11);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(203, 50);
            button2.TabIndex = 2;
            button2.Text = "🗑️ Xóa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(52, 152, 219);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(308, 12);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(228, 50);
            button3.TabIndex = 1;
            button3.Text = "✏️ Chỉnh sửa";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(46, 204, 113);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(35, 11);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Padding = new Padding(12, 0, 12, 0);
            button4.Size = new Size(251, 50);
            button4.TabIndex = 0;
            button4.Text = "➕ Thêm biên lai";
            button4.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { UserId, StudentId, StudentName, Email, Phone, PhoneNumberOfParent, DateOfBirth, FaceImageCount });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(236, 240, 241);
            dataGridView1.Location = new Point(31, 206);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1781, 712);
            dataGridView1.TabIndex = 3;
            // 
            // UserId
            // 
            UserId.HeaderText = "UserId";
            UserId.MinimumWidth = 6;
            UserId.Name = "UserId";
            UserId.ReadOnly = true;
            UserId.Visible = false;
            // 
            // StudentId
            // 
            StudentId.HeaderText = "StudentId";
            StudentId.MinimumWidth = 6;
            StudentId.Name = "StudentId";
            StudentId.ReadOnly = true;
            StudentId.Visible = false;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Họ và tên";
            StudentName.MinimumWidth = 6;
            StudentName.Name = "StudentName";
            StudentName.ReadOnly = true;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Phone
            // 
            Phone.HeaderText = "Số điện thoại";
            Phone.MinimumWidth = 6;
            Phone.Name = "Phone";
            Phone.ReadOnly = true;
            // 
            // PhoneNumberOfParent
            // 
            PhoneNumberOfParent.HeaderText = "Số điện thoại phụ huynh";
            PhoneNumberOfParent.MinimumWidth = 6;
            PhoneNumberOfParent.Name = "PhoneNumberOfParent";
            PhoneNumberOfParent.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Ngày sinh";
            DateOfBirth.MinimumWidth = 6;
            DateOfBirth.Name = "DateOfBirth";
            DateOfBirth.ReadOnly = true;
            // 
            // FaceImageCount
            // 
            FaceImageCount.HeaderText = "Số ảnh";
            FaceImageCount.MinimumWidth = 6;
            FaceImageCount.Name = "FaceImageCount";
            FaceImageCount.ReadOnly = true;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(155, 89, 182);
            btnImport.Cursor = Cursors.Hand;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(1386, 944);
            btnImport.Margin = new Padding(4);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(194, 56);
            btnImport.TabIndex = 4;
            btnImport.Text = "📥 Import Excel";
            btnImport.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(243, 156, 18);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1619, 944);
            btnExport.Margin = new Padding(4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(194, 56);
            btnExport.TabIndex = 5;
            btnExport.Text = "📄 Tải mẫu Excel";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.CustomizableEdges = customizableEdges1;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Segoe UI", 10F);
            guna2ComboBox1.ForeColor = Color.FromArgb(68, 88, 112);
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ", "Đang hoạt động", "Ngừng hoạt động", "Chưa có ảnh", "Có ảnh" });
            guna2ComboBox1.Location = new Point(192, 955);
            guna2ComboBox1.Margin = new Padding(4);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.BorderRadius = 10;
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ComboBox1.Size = new Size(276, 36);
            guna2ComboBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(32, 964);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 28);
            label2.TabIndex = 7;
            label2.Text = "Lọc dữ liệu :";
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(52, 152, 219);
            panelStats.Controls.Add(lblTotalStudents);
            panelStats.Controls.Add(lblStatsTitle);
            panelStats.Location = new Point(1568, 6);
            panelStats.Margin = new Padding(4);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(245, 75);
            panelStats.TabIndex = 1;
            // 
            // lblTotalStudents
            // 
            lblTotalStudents.AutoSize = true;
            lblTotalStudents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalStudents.ForeColor = Color.White;
            lblTotalStudents.Location = new Point(184, 18);
            lblTotalStudents.Margin = new Padding(4, 0, 4, 0);
            lblTotalStudents.Name = "lblTotalStudents";
            lblTotalStudents.Size = new Size(33, 38);
            lblTotalStudents.TabIndex = 1;
            lblTotalStudents.Text = "0";
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblStatsTitle.ForeColor = Color.White;
            lblStatsTitle.Location = new Point(12, 25);
            lblStatsTitle.Margin = new Padding(4, 0, 4, 0);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(164, 30);
            lblStatsTitle.TabIndex = 0;
            lblStatsTitle.Text = "Tổng sinh viên:";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(236, 240, 241);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Location = new Point(30, 106);
            panelSearch.Margin = new Padding(4);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(700, 75);
            panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(546, 11);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 50);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(176, 20);
            txtSearch.Margin = new Padding(4);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên sinh viên...";
            txtSearch.Size = new Size(362, 34);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(19, 22);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(139, 28);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "🔍 Tìm kiếm:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(236, 240, 241);
            panelButtons.Controls.Add(btnAddPhoto);
            panelButtons.Controls.Add(btnRefresh);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(784, 106);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1029, 75);
            panelButtons.TabIndex = 2;
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.BackColor = Color.MediumPurple;
            btnAddPhoto.Cursor = Cursors.Hand;
            btnAddPhoto.FlatAppearance.BorderSize = 0;
            btnAddPhoto.FlatStyle = FlatStyle.Flat;
            btnAddPhoto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddPhoto.ForeColor = Color.White;
            btnAddPhoto.Location = new Point(804, 12);
            btnAddPhoto.Margin = new Padding(4);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(175, 50);
            btnAddPhoto.TabIndex = 4;
            btnAddPhoto.Text = "✏️ Bổ sung ảnh";
            btnAddPhoto.UseVisualStyleBackColor = false;
            btnAddPhoto.Click += BtnAddPhoto_Click;
            // 
            // cboFilter
            // 
            cboFilter.BackColor = Color.Transparent;
            cboFilter.CustomizableEdges = customizableEdges3;
            cboFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.FocusedColor = Color.FromArgb(94, 148, 255);
            cboFilter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboFilter.Font = new Font("Segoe UI", 10F);
            cboFilter.ForeColor = Color.FromArgb(68, 88, 112);
            cboFilter.ItemHeight = 30;
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ", "Đang hoạt động", "Ngừng hoạt động", "Chưa có ảnh", "Có ảnh" });
            cboFilter.Location = new Point(192, 955);
            cboFilter.Margin = new Padding(4);
            cboFilter.Name = "cboFilter";
            cboFilter.ShadowDecoration.BorderRadius = 10;
            cboFilter.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboFilter.Size = new Size(276, 36);
            cboFilter.TabIndex = 6;
            cboFilter.SelectedIndexChanged += CboGender_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(48, 958);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 7;
            label1.Text = "Lọc dữ liệu :";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(btnRestore);
            pnlContent.Controls.Add(panelTop);
            pnlContent.Controls.Add(panelSearch);
            pnlContent.Controls.Add(panelButtons);
            pnlContent.Controls.Add(dgvStudents);
            pnlContent.Controls.Add(cboFilter);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1850, 1062);
            pnlContent.TabIndex = 8;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.DeepSkyBlue;
            btnRestore.Cursor = Cursors.Hand;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRestore.ForeColor = Color.White;
            btnRestore.Location = new Point(1588, 945);
            btnRestore.Margin = new Padding(4);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(194, 56);
            btnRestore.TabIndex = 8;
            btnRestore.Text = "🔄 Khôi phục";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Visible = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // StudentManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 251, 252);
            Controls.Add(pnlContent);
            Margin = new Padding(4);
            Name = "StudentManagement";
            Size = new Size(1850, 1062);
            Load += StudentManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvStudents;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Panel panelTop;
        private Panel panelSearch;
        private Panel panelButtons;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnSearch;
        private Panel panelStats;
        private Label lblTotalStudents;
        private Label lblStatsTitle;
        private Button btnAddPhoto;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private Label label1;
        private Panel pnlContent;
        private Button btnRestore;
        private DataGridViewTextBoxColumn clmStudentName;
        private DataGridViewTextBoxColumn clmClassName;
        private DataGridViewTextBoxColumn clmPromotionName;
        private DataGridViewTextBoxColumn clmTotalAmount;
        private DataGridViewTextBoxColumn clmPaidAmount;
        private DataGridViewTextBoxColumn clmStatusPaid;
        private DataGridViewTextBoxColumn clmCreateAt;
        private Panel panel4;
        private Button button6;
        private Panel panel5;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private Label label4;
        private Panel panel2;
        private Button button5;
        private TextBox textBox1;
        private Label label3;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn UserId;
        private DataGridViewTextBoxColumn StudentId;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn PhoneNumberOfParent;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn FaceImageCount;
        private Button btnImport;
        private Button btnExport;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Label label2;
    }
}