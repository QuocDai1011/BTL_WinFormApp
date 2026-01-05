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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            dgvStudents = new DataGridView();
            UserId = new DataGridViewTextBoxColumn();
            StudentId = new DataGridViewTextBoxColumn();
            StudentName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            PhoneNumberOfParent = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            FaceImageCount = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            panelTop = new Panel();
            panelStats = new Panel();
            lblTotalStudents = new Label();
            lblStatsTitle = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelButtons = new Panel();
            btnAddPhoto = new Button();
            btnExport = new Button();
            btnImport = new Button();
            cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            pnlContent = new Panel();
            btnRestore = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            panelTop.SuspendLayout();
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
            lblTitle.Location = new Point(25, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(349, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📚 QUẢN LÝ HỌC VIÊN";
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
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { UserId, StudentId, StudentName, Email, Phone, PhoneNumberOfParent, DateOfBirth, FaceImageCount });
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
            dgvStudents.Location = new Point(25, 165);
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
            dgvStudents.Size = new Size(1425, 570);
            dgvStudents.TabIndex = 3;
            dgvStudents.DoubleClick += dgvStudents_DoubleClick;
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
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(28, 9);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(10, 0, 10, 0);
            btnAdd.Size = new Size(201, 40);
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
            btnEdit.Location = new Point(235, 9);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(140, 40);
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
            btnDelete.Location = new Point(381, 9);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
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
            btnRefresh.Location = new Point(507, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 40);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(panelStats);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1480, 70);
            panelTop.TabIndex = 0;
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(52, 152, 219);
            panelStats.Controls.Add(lblTotalStudents);
            panelStats.Controls.Add(lblStatsTitle);
            panelStats.Location = new Point(1254, 5);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(196, 60);
            panelStats.TabIndex = 1;
            // 
            // lblTotalStudents
            // 
            lblTotalStudents.AutoSize = true;
            lblTotalStudents.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalStudents.ForeColor = Color.White;
            lblTotalStudents.Location = new Point(147, 14);
            lblTotalStudents.Name = "lblTotalStudents";
            lblTotalStudents.Size = new Size(28, 32);
            lblTotalStudents.TabIndex = 1;
            lblTotalStudents.Text = "0";
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblStatsTitle.ForeColor = Color.White;
            lblStatsTitle.Location = new Point(10, 20);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(131, 23);
            lblStatsTitle.TabIndex = 0;
            lblStatsTitle.Text = "Tổng sinh viên:";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(236, 240, 241);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Location = new Point(24, 85);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(560, 60);
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
            btnSearch.Location = new Point(437, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 40);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(141, 16);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên sinh viên...";
            txtSearch.Size = new Size(290, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(15, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(120, 23);
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
            panelButtons.Location = new Point(627, 85);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(823, 60);
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
            btnAddPhoto.Location = new Point(643, 10);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(140, 40);
            btnAddPhoto.TabIndex = 4;
            btnAddPhoto.Text = "✏️ Bổ sung ảnh";
            btnAddPhoto.UseVisualStyleBackColor = false;
            btnAddPhoto.Click += BtnAddPhoto_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(243, 156, 18);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1295, 755);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(155, 45);
            btnExport.TabIndex = 5;
            btnExport.Text = "📄 Tải mẫu Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(155, 89, 182);
            btnImport.Cursor = Cursors.Hand;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnImport.ForeColor = Color.White;
            btnImport.Location = new Point(1109, 755);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(155, 45);
            btnImport.TabIndex = 4;
            btnImport.Text = "📥 Import Excel";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += BtnImport_Click;
            // 
            // cboFilter
            // 
            cboFilter.BackColor = Color.Transparent;
            cboFilter.CustomizableEdges = customizableEdges1;
            cboFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.FocusedColor = Color.FromArgb(94, 148, 255);
            cboFilter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboFilter.Font = new Font("Segoe UI", 10F);
            cboFilter.ForeColor = Color.FromArgb(68, 88, 112);
            cboFilter.ItemHeight = 30;
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ", "Đang hoạt động", "Ngừng hoạt động", "Chưa có ảnh", "Có ảnh" });
            cboFilter.Location = new Point(154, 764);
            cboFilter.Name = "cboFilter";
            cboFilter.ShadowDecoration.BorderRadius = 10;
            cboFilter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboFilter.Size = new Size(222, 36);
            cboFilter.TabIndex = 6;
            cboFilter.SelectedIndexChanged += CboGender_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(26, 771);
            label1.Name = "label1";
            label1.Size = new Size(108, 23);
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
            pnlContent.Controls.Add(btnImport);
            pnlContent.Controls.Add(btnExport);
            pnlContent.Controls.Add(cboFilter);
            pnlContent.Controls.Add(label1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1480, 850);
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
            btnRestore.Location = new Point(922, 755);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(155, 45);
            btnRestore.TabIndex = 8;
            btnRestore.Text = "🔄 Khôi phục";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Visible = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // StudentManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 251, 252);
            Controls.Add(pnlContent);
            Name = "StudentManagement";
            Size = new Size(1480, 850);
            Load += StudentManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
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
        private Button btnExport;
        private Button btnImport;
        private Panel panelStats;
        private Label lblTotalStudents;
        private Label lblStatsTitle;
        private Button btnAddPhoto;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private Label label1;
        private DataGridViewTextBoxColumn UserId;
        private DataGridViewTextBoxColumn StudentId;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn PhoneNumberOfParent;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn FaceImageCount;
        private Panel pnlContent;
        private Button btnRestore;
    }
}