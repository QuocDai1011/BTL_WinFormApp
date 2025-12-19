namespace BaiTapLonWinForm.View.Admin.Teacher
{
    partial class TeacherManagement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelTop = new Panel();
            panelSearchContainer = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblTitle = new Label();
            panelGrid = new Panel();
            dgvTeachers = new DataGridView();
            ColTeacherName = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColPhoneNumber = new DataGridViewTextBoxColumn();
            ColDateOfBirth = new DataGridViewTextBoxColumn();
            ColGender = new DataGridViewTextBoxColumn();
            ColAddress = new DataGridViewTextBoxColumn();
            ColFirstName = new DataGridViewTextBoxColumn();
            ColLastName = new DataGridViewTextBoxColumn();
            ColExperience = new DataGridViewTextBoxColumn();
            ColSalary = new DataGridViewTextBoxColumn();
            ColTeacherId = new DataGridViewTextBoxColumn();
            ColUserId = new DataGridViewTextBoxColumn();
            panelButtons = new Panel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panelTop.SuspendLayout();
            panelSearchContainer.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.AutoSize = true;
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(panelSearchContainer);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(20, 20);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(20, 10, 20, 10);
            panelTop.Size = new Size(1430, 71);
            panelTop.TabIndex = 0;
            // 
            // panelSearchContainer
            // 
            panelSearchContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelSearchContainer.Controls.Add(btnRefresh);
            panelSearchContainer.Controls.Add(btnSearch);
            panelSearchContainer.Controls.Add(txtSearch);
            panelSearchContainer.Location = new Point(840, 18);
            panelSearchContainer.Name = "panelSearchContainer";
            panelSearchContainer.Size = new Size(548, 40);
            panelSearchContainer.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Location = new Point(445, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "↻ Tải lại";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(340, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 34);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Tìm kiếm theo tên hoặc email...";
            txtSearch.Size = new Size(329, 32);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitle.Location = new Point(20, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(331, 41);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "QUẢN LÝ GIẢNG VIÊN";
            // 
            // panelGrid
            // 
            panelGrid.AutoSize = true;
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(panelTop);
            panelGrid.Controls.Add(dgvTeachers);
            panelGrid.Controls.Add(panelButtons);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 0);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1470, 850);
            panelGrid.TabIndex = 0;
            // 
            // dgvTeachers
            // 
            dgvTeachers.AllowUserToAddRows = false;
            dgvTeachers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 249);
            dgvTeachers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeachers.BackgroundColor = Color.White;
            dgvTeachers.BorderStyle = BorderStyle.None;
            dgvTeachers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dgvTeachers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTeachers.ColumnHeadersHeight = 45;
            dgvTeachers.Columns.AddRange(new DataGridViewColumn[] { ColTeacherName, ColEmail, ColPhoneNumber, ColDateOfBirth, ColGender, ColAddress, ColFirstName, ColLastName, ColExperience, ColSalary, ColTeacherId, ColUserId });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(212, 230, 241);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTeachers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTeachers.EnableHeadersVisualStyles = false;
            dgvTeachers.Location = new Point(20, 98);
            dgvTeachers.Margin = new Padding(20);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.ReadOnly = true;
            dgvTeachers.RowHeadersVisible = false;
            dgvTeachers.RowHeadersWidth = 51;
            dgvTeachers.RowTemplate.Height = 40;
            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.Size = new Size(1385, 606);
            dgvTeachers.TabIndex = 0;
            // 
            // ColTeacherName
            // 
            ColTeacherName.HeaderText = "HỌ VÀ TÊN";
            ColTeacherName.MinimumWidth = 6;
            ColTeacherName.Name = "ColTeacherName";
            ColTeacherName.ReadOnly = true;
            // 
            // ColEmail
            // 
            ColEmail.HeaderText = "EMAIL";
            ColEmail.MinimumWidth = 6;
            ColEmail.Name = "ColEmail";
            ColEmail.ReadOnly = true;
            // 
            // ColPhoneNumber
            // 
            ColPhoneNumber.HeaderText = "SỐ ĐIỆN THOẠI";
            ColPhoneNumber.MinimumWidth = 6;
            ColPhoneNumber.Name = "ColPhoneNumber";
            ColPhoneNumber.ReadOnly = true;
            // 
            // ColDateOfBirth
            // 
            ColDateOfBirth.HeaderText = "NGÀY SINH";
            ColDateOfBirth.MinimumWidth = 6;
            ColDateOfBirth.Name = "ColDateOfBirth";
            ColDateOfBirth.ReadOnly = true;
            // 
            // ColGender
            // 
            ColGender.HeaderText = "GIỚI TÍNH";
            ColGender.MinimumWidth = 6;
            ColGender.Name = "ColGender";
            ColGender.ReadOnly = true;
            // 
            // ColAddress
            // 
            ColAddress.HeaderText = "ĐỊA CHỈ";
            ColAddress.MinimumWidth = 6;
            ColAddress.Name = "ColAddress";
            ColAddress.ReadOnly = true;
            // 
            // ColFirstName
            // 
            ColFirstName.HeaderText = "FirstName";
            ColFirstName.MinimumWidth = 6;
            ColFirstName.Name = "ColFirstName";
            ColFirstName.ReadOnly = true;
            ColFirstName.Visible = false;
            // 
            // ColLastName
            // 
            ColLastName.HeaderText = "LastName";
            ColLastName.MinimumWidth = 6;
            ColLastName.Name = "ColLastName";
            ColLastName.ReadOnly = true;
            ColLastName.Visible = false;
            // 
            // ColExperience
            // 
            ColExperience.HeaderText = "Kinh Nghiệm";
            ColExperience.MinimumWidth = 6;
            ColExperience.Name = "ColExperience";
            ColExperience.ReadOnly = true;
            ColExperience.Visible = false;
            // 
            // ColSalary
            // 
            ColSalary.HeaderText = "Lương";
            ColSalary.MinimumWidth = 6;
            ColSalary.Name = "ColSalary";
            ColSalary.ReadOnly = true;
            ColSalary.Visible = false;
            // 
            // ColTeacherId
            // 
            ColTeacherId.HeaderText = "TeacherId";
            ColTeacherId.MinimumWidth = 6;
            ColTeacherId.Name = "ColTeacherId";
            ColTeacherId.ReadOnly = true;
            ColTeacherId.Visible = false;
            // 
            // ColUserId
            // 
            ColUserId.HeaderText = "UserId";
            ColUserId.MinimumWidth = 6;
            ColUserId.Name = "ColUserId";
            ColUserId.ReadOnly = true;
            ColUserId.Visible = false;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(20, 743);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1430, 87);
            panelButtons.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1205, 7);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 45);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(243, 156, 18);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(1019, 7);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(180, 45);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(833, 7);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 45);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // TeacherManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(panelGrid);
            Name = "TeacherManagement";
            Size = new Size(1470, 850);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSearchContainer.ResumeLayout(false);
            panelSearchContainer.PerformLayout();
            panelGrid.ResumeLayout(false);
            panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Controls Declaration
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearchContainer;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        // Grid
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private DataGridViewTextBoxColumn ColTeacherName;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColPhoneNumber;
        private DataGridViewTextBoxColumn ColDateOfBirth;
        private DataGridViewTextBoxColumn ColGender;
        private DataGridViewTextBoxColumn ColAddress;
        private DataGridViewTextBoxColumn ColFirstName;
        private DataGridViewTextBoxColumn ColLastName;
        private DataGridViewTextBoxColumn ColExperience;
        private DataGridViewTextBoxColumn ColSalary;
        private DataGridViewTextBoxColumn ColTeacherId;
        private DataGridViewTextBoxColumn ColUserId;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}