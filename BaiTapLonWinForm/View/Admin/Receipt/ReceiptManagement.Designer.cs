namespace BaiTapLonWinForm.View.Admin.Receipt
{
    partial class ReceiptManagement
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            panelTop = new Panel();
            panelStats = new Panel();
            lblTotalReceipt = new Label();
            lblStatsTitle = new Label();
            lblTitle = new Label();
            btnDelete = new Button();
            panelButtons = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelSearch = new Panel();
            dgvReceipt = new DataGridView();
            clmStudentName = new DataGridViewTextBoxColumn();
            clmClassName = new DataGridViewTextBoxColumn();
            clmPromotion = new DataGridViewTextBoxColumn();
            clmTotalAmount = new DataGridViewTextBoxColumn();
            clmStatus = new DataGridViewTextBoxColumn();
            clmCreateAt = new DataGridViewTextBoxColumn();
            cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            pnlContent = new Panel();
            panelTop.SuspendLayout();
            panelStats.SuspendLayout();
            panelButtons.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceipt).BeginInit();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(110, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 7;
            label1.Text = "Lọc dữ liệu :";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(panelStats);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2088, 88);
            panelTop.TabIndex = 0;
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(52, 152, 219);
            panelStats.Controls.Add(lblTotalReceipt);
            panelStats.Controls.Add(lblStatsTitle);
            panelStats.Location = new Point(1568, 6);
            panelStats.Margin = new Padding(4);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(245, 75);
            panelStats.TabIndex = 1;
            // 
            // lblTotalReceipt
            // 
            lblTotalReceipt.AutoSize = true;
            lblTotalReceipt.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalReceipt.ForeColor = Color.White;
            lblTotalReceipt.Location = new Point(184, 18);
            lblTotalReceipt.Margin = new Padding(4, 0, 4, 0);
            lblTotalReceipt.Name = "lblTotalReceipt";
            lblTotalReceipt.Size = new Size(33, 38);
            lblTotalReceipt.TabIndex = 1;
            lblTotalReceipt.Text = "0";
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblStatsTitle.ForeColor = Color.White;
            lblStatsTitle.Location = new Point(12, 25);
            lblStatsTitle.Margin = new Padding(4, 0, 4, 0);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(148, 30);
            lblStatsTitle.TabIndex = 0;
            lblStatsTitle.Text = "Tổng biên lai:";
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
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(659, 10);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(279, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(236, 240, 241);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(cboFilter);
            panelButtons.Controls.Add(label1);
            panelButtons.Location = new Point(784, 106);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1029, 75);
            panelButtons.TabIndex = 2;
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
            // dgvReceipt
            // 
            dgvReceipt.AllowUserToAddRows = false;
            dgvReceipt.AllowUserToDeleteRows = false;
            dgvReceipt.AllowUserToResizeRows = false;
            dgvReceipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceipt.BackgroundColor = Color.White;
            dgvReceipt.BorderStyle = BorderStyle.None;
            dgvReceipt.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReceipt.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReceipt.ColumnHeadersHeight = 45;
            dgvReceipt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReceipt.Columns.AddRange(new DataGridViewColumn[] { clmStudentName, clmClassName, clmPromotion, clmTotalAmount, clmStatus, clmCreateAt });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReceipt.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReceipt.EnableHeadersVisualStyles = false;
            dgvReceipt.GridColor = Color.FromArgb(236, 240, 241);
            dgvReceipt.Location = new Point(31, 206);
            dgvReceipt.Margin = new Padding(4);
            dgvReceipt.MultiSelect = false;
            dgvReceipt.Name = "dgvReceipt";
            dgvReceipt.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(189, 195, 199);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvReceipt.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvReceipt.RowHeadersVisible = false;
            dgvReceipt.RowHeadersWidth = 51;
            dgvReceipt.RowTemplate.Height = 40;
            dgvReceipt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceipt.Size = new Size(1781, 712);
            dgvReceipt.TabIndex = 3;
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
            // clmPromotion
            // 
            clmPromotion.HeaderText = "Loại ưu đãi";
            clmPromotion.MinimumWidth = 8;
            clmPromotion.Name = "clmPromotion";
            clmPromotion.ReadOnly = true;
            // 
            // clmTotalAmount
            // 
            clmTotalAmount.HeaderText = "Tổng học phí";
            clmTotalAmount.MinimumWidth = 8;
            clmTotalAmount.Name = "clmTotalAmount";
            clmTotalAmount.ReadOnly = true;
            // 
            // clmStatus
            // 
            clmStatus.HeaderText = "Trạng thái";
            clmStatus.MinimumWidth = 8;
            clmStatus.Name = "clmStatus";
            clmStatus.ReadOnly = true;
            // 
            // clmCreateAt
            // 
            clmCreateAt.HeaderText = "Tạo ngày";
            clmCreateAt.MinimumWidth = 8;
            clmCreateAt.Name = "clmCreateAt";
            clmCreateAt.ReadOnly = true;
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
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Đã thanh toán", "Chờ xác nhận", "Chưa thanh toán", "Thất bại" });
            cboFilter.Location = new Point(265, 18);
            cboFilter.Margin = new Padding(4);
            cboFilter.Name = "cboFilter";
            cboFilter.ShadowDecoration.BorderRadius = 10;
            cboFilter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboFilter.Size = new Size(276, 36);
            cboFilter.TabIndex = 6;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(panelTop);
            pnlContent.Controls.Add(panelSearch);
            pnlContent.Controls.Add(panelButtons);
            pnlContent.Controls.Add(dgvReceipt);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(2088, 1123);
            pnlContent.TabIndex = 11;
            // 
            // ReceiptManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContent);
            Name = "ReceiptManagement";
            Size = new Size(2088, 1123);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceipt).EndInit();
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panelTop;
        private Panel panelStats;
        private Label lblTotalReceipt;
        private Label lblStatsTitle;
        private Label lblTitle;
        private Button btnDelete;
        private Panel panelButtons;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel panelSearch;
        private DataGridView dgvReceipt;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private Panel pnlContent;
        private DataGridViewTextBoxColumn clmStudentName;
        private DataGridViewTextBoxColumn clmClassName;
        private DataGridViewTextBoxColumn clmPromotion;
        private DataGridViewTextBoxColumn clmTotalAmount;
        private DataGridViewTextBoxColumn clmStatus;
        private DataGridViewTextBoxColumn clmCreateAt;
    }
}
