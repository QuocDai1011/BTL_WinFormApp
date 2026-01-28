namespace BaiTapLonWinForm.View.Admin.Class
{
    partial class AddStudentToClass
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel pnlBottom;
        private Button btnSave;
        private Button btnCancel;
        private Label lblSelectedCount;
        private DataGridView dgvAvailableStudents;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            pnlBottom = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            lblSelectedCount = new Label();
            dgvAvailableStudents = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDob = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableStudents).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(20);
            pnlTop.Size = new Size(1050, 70);
            pnlTop.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(20, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(152, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm học viên:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(178, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên, email hoặc số điện thoại...";
            txtSearch.Size = new Size(350, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.WhiteSmoke;
            pnlBottom.Controls.Add(btnSave);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Controls.Add(lblSelectedCount);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 650);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1050, 70);
            pnlBottom.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(817, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "Thêm vào lớp";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(687, 16);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSelectedCount
            // 
            lblSelectedCount.AutoSize = true;
            lblSelectedCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedCount.ForeColor = Color.SeaGreen;
            lblSelectedCount.Location = new Point(20, 25);
            lblSelectedCount.Name = "lblSelectedCount";
            lblSelectedCount.Size = new Size(95, 23);
            lblSelectedCount.TabIndex = 2;
            lblSelectedCount.Text = "Đã chọn: 0";
            // 
            // dgvAvailableStudents
            // 
            dgvAvailableStudents.AllowUserToAddRows = false;
            dgvAvailableStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableStudents.BackgroundColor = Color.White;
            dgvAvailableStudents.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvAvailableStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAvailableStudents.ColumnHeadersHeight = 40;
            dgvAvailableStudents.Columns.AddRange(new DataGridViewColumn[] { colSelect, colId, colName, colDob, ColEmail, colPhone });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAvailableStudents.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAvailableStudents.Dock = DockStyle.Fill;
            dgvAvailableStudents.Location = new Point(0, 70);
            dgvAvailableStudents.Name = "dgvAvailableStudents";
            dgvAvailableStudents.RowHeadersVisible = false;
            dgvAvailableStudents.RowHeadersWidth = 51;
            dgvAvailableStudents.RowTemplate.Height = 35;
            dgvAvailableStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableStudents.Size = new Size(1050, 580);
            dgvAvailableStudents.TabIndex = 0;
            dgvAvailableStudents.CellContentClick += Dgv_CellContentClick;
            // 
            // colSelect
            // 
            colSelect.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colSelect.HeaderText = "";
            colSelect.MinimumWidth = 6;
            colSelect.Name = "colSelect";
            colSelect.Width = 50;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.Visible = false;
            // 
            // colName
            // 
            colName.HeaderText = "Họ và Tên";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            // 
            // colDob
            // 
            colDob.HeaderText = "Ngày Sinh";
            colDob.MinimumWidth = 6;
            colDob.Name = "colDob";
            // 
            // ColEmail
            // 
            ColEmail.HeaderText = "Email";
            ColEmail.MinimumWidth = 6;
            ColEmail.Name = "ColEmail";
            // 
            // colPhone
            // 
            colPhone.HeaderText = "SĐT";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            // 
            // AddStudentToClass
            // 
            BackColor = Color.White;
            Controls.Add(dgvAvailableStudents);
            Controls.Add(pnlTop);
            Controls.Add(pnlBottom);
            Name = "AddStudentToClass";
            Size = new Size(1050, 720);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableStudents).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDob;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn colPhone;
    }
}
