using System.ComponentModel;

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
            dgvTeachers = new DataGridView();
            panelTop = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelRight = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            grpTeacherInfo = new GroupBox();
            nudExperienceYear = new NumericUpDown();
            nudSalary = new NumericUpDown();
            cboUser = new ComboBox();
            lblExperienceYear = new Label();
            lblSalary = new Label();
            lblUser = new Label();
            txtTeacherId = new TextBox();
            lblTeacherId = new Label();
            ((ISupportInitialize)dgvTeachers).BeginInit();
            panelTop.SuspendLayout();
            panelRight.SuspendLayout();
            grpTeacherInfo.SuspendLayout();
            ((ISupportInitialize)nudExperienceYear).BeginInit();
            ((ISupportInitialize)nudSalary).BeginInit();
            SuspendLayout();
            // 
            // dgvTeachers
            // 
            dgvTeachers.AllowUserToAddRows = false;
            dgvTeachers.AllowUserToDeleteRows = false;
            dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeachers.BackgroundColor = Color.White;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Dock = DockStyle.Fill;
            dgvTeachers.Location = new Point(0, 60);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.ReadOnly = true;
            dgvTeachers.RowHeadersWidth = 51;
            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.Size = new Size(800, 525);
            dgvTeachers.TabIndex = 0;
            dgvTeachers.SelectionChanged += dgvTeachers_SelectionChanged;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(41, 128, 185);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(lblSearch);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1150, 60);
            panelTop.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(540, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(420, 15);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(170, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(230, 27);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.White;
            lblSearch.Location = new Point(20, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(135, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm (Tên):";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(236, 240, 241);
            panelRight.Controls.Add(btnDelete);
            panelRight.Controls.Add(btnUpdate);
            panelRight.Controls.Add(btnAdd);
            panelRight.Controls.Add(btnClear);
            panelRight.Controls.Add(grpTeacherInfo);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(800, 60);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(350, 525);
            panelRight.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(190, 430);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(243, 156, 18);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(20, 430);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 40);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(190, 375);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(149, 165, 166);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(20, 375);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 40);
            btnClear.TabIndex = 1;
            btnClear.Text = "Làm mới form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // grpTeacherInfo
            // 
            grpTeacherInfo.Controls.Add(nudExperienceYear);
            grpTeacherInfo.Controls.Add(nudSalary);
            grpTeacherInfo.Controls.Add(cboUser);
            grpTeacherInfo.Controls.Add(lblExperienceYear);
            grpTeacherInfo.Controls.Add(lblSalary);
            grpTeacherInfo.Controls.Add(lblUser);
            grpTeacherInfo.Controls.Add(txtTeacherId);
            grpTeacherInfo.Controls.Add(lblTeacherId);
            grpTeacherInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpTeacherInfo.Location = new Point(20, 20);
            grpTeacherInfo.Name = "grpTeacherInfo";
            grpTeacherInfo.Size = new Size(310, 340);
            grpTeacherInfo.TabIndex = 0;
            grpTeacherInfo.TabStop = false;
            grpTeacherInfo.Text = "Thông tin giáo viên";
            // 
            // nudExperienceYear
            // 
            nudExperienceYear.Location = new Point(20, 280);
            nudExperienceYear.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudExperienceYear.Name = "nudExperienceYear";
            nudExperienceYear.Size = new Size(270, 30);
            nudExperienceYear.TabIndex = 7;
            // 
            // nudSalary
            // 
            nudSalary.Location = new Point(20, 210);
            nudSalary.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudSalary.Name = "nudSalary";
            nudSalary.Size = new Size(270, 30);
            nudSalary.TabIndex = 6;
            nudSalary.ThousandsSeparator = true;
            // 
            // cboUser
            // 
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(20, 140);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(270, 31);
            cboUser.TabIndex = 5;
            // 
            // lblExperienceYear
            // 
            lblExperienceYear.AutoSize = true;
            lblExperienceYear.Font = new Font("Segoe UI", 9F);
            lblExperienceYear.Location = new Point(20, 255);
            lblExperienceYear.Name = "lblExperienceYear";
            lblExperienceYear.Size = new Size(147, 20);
            lblExperienceYear.TabIndex = 4;
            lblExperienceYear.Text = "Số năm kinh nghiệm:";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 9F);
            lblSalary.Location = new Point(20, 185);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(54, 20);
            lblSalary.TabIndex = 3;
            lblSalary.Text = "Lương:";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9F);
            lblUser.Location = new Point(20, 115);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(92, 20);
            lblUser.TabIndex = 2;
            lblUser.Text = "Người dùng:";
            // 
            // txtTeacherId
            // 
            txtTeacherId.Enabled = false;
            txtTeacherId.Location = new Point(20, 70);
            txtTeacherId.Name = "txtTeacherId";
            txtTeacherId.Size = new Size(270, 30);
            txtTeacherId.TabIndex = 1;
            // 
            // lblTeacherId
            // 
            lblTeacherId.AutoSize = true;
            lblTeacherId.Font = new Font("Segoe UI", 9F);
            lblTeacherId.Location = new Point(20, 45);
            lblTeacherId.Name = "lblTeacherId";
            lblTeacherId.Size = new Size(93, 20);
            lblTeacherId.TabIndex = 0;
            lblTeacherId.Text = "ID Giáo viên:";
            // 
            // TeacherManagement
            // 
            Controls.Add(dgvTeachers);
            Controls.Add(panelRight);
            Controls.Add(panelTop);
            Name = "TeacherManagement";
            Size = new Size(1150, 585);
            ((ISupportInitialize)dgvTeachers).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelRight.ResumeLayout(false);
            grpTeacherInfo.ResumeLayout(false);
            grpTeacherInfo.PerformLayout();
            ((ISupportInitialize)nudExperienceYear).EndInit();
            ((ISupportInitialize)nudSalary).EndInit();
            ResumeLayout(false);
        }



        private DataGridView dgvTeachers;
        private Panel panelTop;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel panelRight;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnClear;
        private GroupBox grpTeacherInfo;
        private NumericUpDown nudExperienceYear;
        private NumericUpDown nudSalary;
        private ComboBox cboUser;
        private Label lblExperienceYear;
        private Label lblSalary;
        private Label lblUser;
        private TextBox txtTeacherId;
        private Label lblTeacherId;

        #endregion
    }
}
