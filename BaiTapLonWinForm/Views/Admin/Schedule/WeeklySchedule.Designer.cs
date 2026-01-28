namespace BaiTapLonWinForm.View.Admin.Schedule
{
    partial class WeeklySchedule
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderTop;
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilterBy;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilterTeacher;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilterClass;
        private Guna.UI2.WinForms.Guna2Button btnPrevWeek;
        private Guna.UI2.WinForms.Guna2Button btnNextWeek;
        private Guna.UI2.WinForms.Guna2Button btnToday;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.TableLayoutPanel tblSchedule;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            tblSchedule = new TableLayoutPanel();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            pnlHeaderBottom = new Guna.UI2.WinForms.Guna2Panel();
            btnNextWeek = new Guna.UI2.WinForms.Guna2Button();
            lblDateRange = new Label();
            btnPrevWeek = new Guna.UI2.WinForms.Guna2Button();
            btnToday = new Guna.UI2.WinForms.Guna2Button();
            cboFilterClass = new Guna.UI2.WinForms.Guna2ComboBox();
            cboFilterTeacher = new Guna.UI2.WinForms.Guna2ComboBox();
            lblFilterBy = new Label();
            pnlHeaderTop = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlHeaderBottom.SuspendLayout();
            pnlHeaderTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.Transparent;
            pnlMain.Controls.Add(tblSchedule);
            pnlMain.Controls.Add(pnlHeader);
            pnlMain.CustomizableEdges = customizableEdges17;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = Color.FromArgb(240, 244, 248);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlMain.Size = new Size(1480, 850);
            pnlMain.TabIndex = 0;
            // 
            // tblSchedule
            // 
            tblSchedule.AutoScroll = true;
            tblSchedule.BackColor = Color.White;
            tblSchedule.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tblSchedule.ColumnCount = 8;
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tblSchedule.Dock = DockStyle.Fill;
            tblSchedule.Location = new Point(10, 126);
            tblSchedule.Name = "tblSchedule";
            tblSchedule.RowCount = 7;
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tblSchedule.Size = new Size(1460, 714);
            tblSchedule.TabIndex = 1;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.BorderRadius = 10;
            pnlHeader.Controls.Add(pnlHeaderBottom);
            pnlHeader.Controls.Add(pnlHeaderTop);
            pnlHeader.CustomizableEdges = customizableEdges15;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.FillColor = Color.White;
            pnlHeader.Location = new Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.BorderRadius = 10;
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlHeader.ShadowDecoration.Depth = 8;
            pnlHeader.ShadowDecoration.Enabled = true;
            pnlHeader.ShadowDecoration.Shadow = new Padding(2, 2, 4, 4);
            pnlHeader.Size = new Size(1460, 116);
            pnlHeader.TabIndex = 0;
            // 
            // pnlHeaderBottom
            // 
            pnlHeaderBottom.Controls.Add(btnNextWeek);
            pnlHeaderBottom.Controls.Add(lblDateRange);
            pnlHeaderBottom.Controls.Add(btnPrevWeek);
            pnlHeaderBottom.Controls.Add(btnToday);
            pnlHeaderBottom.Controls.Add(cboFilterClass);
            pnlHeaderBottom.Controls.Add(cboFilterTeacher);
            pnlHeaderBottom.Controls.Add(lblFilterBy);
            pnlHeaderBottom.CustomizableEdges = customizableEdges11;
            pnlHeaderBottom.Dock = DockStyle.Fill;
            pnlHeaderBottom.FillColor = Color.White;
            pnlHeaderBottom.Location = new Point(0, 50);
            pnlHeaderBottom.Name = "pnlHeaderBottom";
            pnlHeaderBottom.Padding = new Padding(15, 8, 15, 8);
            pnlHeaderBottom.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlHeaderBottom.Size = new Size(1460, 66);
            pnlHeaderBottom.TabIndex = 1;
            // 
            // btnNextWeek
            // 
            btnNextWeek.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextWeek.BorderRadius = 25;
            btnNextWeek.CustomizableEdges = customizableEdges1;
            btnNextWeek.DisabledState.BorderColor = Color.DarkGray;
            btnNextWeek.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNextWeek.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNextWeek.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNextWeek.FillColor = Color.FromArgb(224, 224, 224);
            btnNextWeek.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnNextWeek.ForeColor = Color.Black;
            btnNextWeek.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            btnNextWeek.Location = new Point(1394, 8);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Padding = new Padding(5);
            btnNextWeek.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnNextWeek.Size = new Size(50, 50);
            btnNextWeek.TabIndex = 6;
            btnNextWeek.Text = ">";
            btnNextWeek.Click += btnNextWeek_Click;
            // 
            // lblDateRange
            // 
            lblDateRange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateRange.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblDateRange.ForeColor = Color.FromArgb(94, 148, 255);
            lblDateRange.Location = new Point(676, 20);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(341, 28);
            lblDateRange.TabIndex = 5;
            lblDateRange.Text = "Tuần: 23/12 - 29/12/2024";
            lblDateRange.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrevWeek
            // 
            btnPrevWeek.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevWeek.BorderRadius = 25;
            btnPrevWeek.CustomizableEdges = customizableEdges3;
            btnPrevWeek.DisabledState.BorderColor = Color.DarkGray;
            btnPrevWeek.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrevWeek.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrevWeek.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrevWeek.FillColor = Color.FromArgb(224, 224, 224);
            btnPrevWeek.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnPrevWeek.ForeColor = Color.Black;
            btnPrevWeek.HoverState.FillColor = Color.FromArgb(94, 148, 255);
            btnPrevWeek.Location = new Point(1318, 8);
            btnPrevWeek.Name = "btnPrevWeek";
            btnPrevWeek.Padding = new Padding(5);
            btnPrevWeek.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPrevWeek.Size = new Size(50, 50);
            btnPrevWeek.TabIndex = 4;
            btnPrevWeek.Text = "<";
            btnPrevWeek.Click += btnPrevWeek_Click;
            // 
            // btnToday
            // 
            btnToday.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToday.BorderRadius = 6;
            btnToday.CustomizableEdges = customizableEdges5;
            btnToday.DisabledState.BorderColor = Color.DarkGray;
            btnToday.DisabledState.CustomBorderColor = Color.DarkGray;
            btnToday.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnToday.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnToday.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToday.ForeColor = Color.White;
            btnToday.Location = new Point(1173, 17);
            btnToday.Name = "btnToday";
            btnToday.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnToday.Size = new Size(129, 34);
            btnToday.TabIndex = 3;
            btnToday.Text = "Hôm nay";
            btnToday.Click += btnToday_Click;
            // 
            // cboFilterClass
            // 
            cboFilterClass.BackColor = Color.Transparent;
            cboFilterClass.BorderRadius = 6;
            cboFilterClass.CustomizableEdges = customizableEdges7;
            cboFilterClass.DrawMode = DrawMode.OwnerDrawFixed;
            cboFilterClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterClass.FocusedColor = Color.FromArgb(94, 148, 255);
            cboFilterClass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboFilterClass.Font = new Font("Segoe UI", 9F);
            cboFilterClass.ForeColor = Color.FromArgb(68, 88, 112);
            cboFilterClass.ItemHeight = 28;
            cboFilterClass.Location = new Point(370, 18);
            cboFilterClass.Name = "cboFilterClass";
            cboFilterClass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cboFilterClass.Size = new Size(260, 34);
            cboFilterClass.TabIndex = 2;
            cboFilterClass.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // cboFilterTeacher
            // 
            cboFilterTeacher.BackColor = Color.Transparent;
            cboFilterTeacher.BorderRadius = 6;
            cboFilterTeacher.CustomizableEdges = customizableEdges9;
            cboFilterTeacher.DrawMode = DrawMode.OwnerDrawFixed;
            cboFilterTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterTeacher.FocusedColor = Color.FromArgb(94, 148, 255);
            cboFilterTeacher.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboFilterTeacher.Font = new Font("Segoe UI", 9F);
            cboFilterTeacher.ForeColor = Color.FromArgb(68, 88, 112);
            cboFilterTeacher.ItemHeight = 28;
            cboFilterTeacher.Location = new Point(110, 18);
            cboFilterTeacher.Name = "cboFilterTeacher";
            cboFilterTeacher.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cboFilterTeacher.Size = new Size(254, 34);
            cboFilterTeacher.TabIndex = 1;
            cboFilterTeacher.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterBy
            // 
            lblFilterBy.AutoSize = true;
            lblFilterBy.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblFilterBy.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterBy.Location = new Point(18, 24);
            lblFilterBy.Name = "lblFilterBy";
            lblFilterBy.Size = new Size(83, 23);
            lblFilterBy.TabIndex = 0;
            lblFilterBy.Text = "Lọc theo:";
            // 
            // pnlHeaderTop
            // 
            pnlHeaderTop.BackColor = Color.Transparent;
            pnlHeaderTop.Controls.Add(lblTitle);
            pnlHeaderTop.CustomizableEdges = customizableEdges13;
            pnlHeaderTop.Dock = DockStyle.Top;
            pnlHeaderTop.FillColor = Color.FromArgb(94, 148, 255);
            pnlHeaderTop.Location = new Point(0, 0);
            pnlHeaderTop.Name = "pnlHeaderTop";
            pnlHeaderTop.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlHeaderTop.Size = new Size(1460, 50);
            pnlHeaderTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1460, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📅 THỜI KHÓA BIỂU GIẢNG VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WeeklySchedule
            // 
            BackColor = Color.FromArgb(240, 244, 248);
            Controls.Add(pnlMain);
            Name = "WeeklySchedule";
            Size = new Size(1480, 850);
            pnlMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeaderBottom.ResumeLayout(false);
            pnlHeaderBottom.PerformLayout();
            pnlHeaderTop.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
