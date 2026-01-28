namespace BaiTapLonWinForm.Views.Teacher.Controls
{
    partial class ClassList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            pnFilter = new Guna.UI2.WinForms.Guna2GradientPanel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            dtpkFilter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            cbxActive = new Guna.UI2.WinForms.Guna2ComboBox();
            cbxCourseName = new Guna.UI2.WinForms.Guna2ComboBox();
            flowMain = new Guna.UI2.WinForms.Guna2GradientPanel();
            tfpClassList = new TableLayoutPanel();
            pnTextBox = new Guna.UI2.WinForms.Guna2Panel();
            txbSearchClass = new Guna.UI2.WinForms.Guna2TextBox();
            iconCustom1 = new IconCustom();
            panel1.SuspendLayout();
            pnFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            flowMain.SuspendLayout();
            pnTextBox.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pnFilter);
            panel1.Controls.Add(flowMain);
            panel1.Controls.Add(pnTextBox);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1459, 849);
            panel1.TabIndex = 7;
            // 
            // pnFilter
            // 
            pnFilter.Controls.Add(iconPictureBox1);
            pnFilter.Controls.Add(dtpkFilter);
            pnFilter.Controls.Add(cbxActive);
            pnFilter.Controls.Add(cbxCourseName);
            pnFilter.CustomizableEdges = customizableEdges7;
            pnFilter.Location = new Point(554, 3);
            pnFilter.Name = "pnFilter";
            pnFilter.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnFilter.Size = new Size(874, 43);
            pnFilter.TabIndex = 14;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Transparent;
            iconPictureBox1.ForeColor = Color.Teal;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bars;
            iconPictureBox1.IconColor = Color.Teal;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconPictureBox1.IconSize = 36;
            iconPictureBox1.Location = new Point(830, 0);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(38, 36);
            iconPictureBox1.TabIndex = 5;
            iconPictureBox1.TabStop = false;
            // 
            // dtpkFilter
            // 
            dtpkFilter.Checked = true;
            dtpkFilter.CheckedState.FillColor = Color.Teal;
            dtpkFilter.CheckedState.ForeColor = Color.White;
            dtpkFilter.CustomizableEdges = customizableEdges1;
            dtpkFilter.FillColor = Color.White;
            dtpkFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpkFilter.ForeColor = Color.FromArgb(64, 64, 64);
            dtpkFilter.Format = DateTimePickerFormat.Short;
            dtpkFilter.HoverState.FillColor = Color.Teal;
            dtpkFilter.HoverState.ForeColor = Color.White;
            dtpkFilter.Location = new Point(655, 0);
            dtpkFilter.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpkFilter.MinDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            dtpkFilter.Name = "dtpkFilter";
            dtpkFilter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpkFilter.Size = new Size(131, 36);
            dtpkFilter.TabIndex = 3;
            dtpkFilter.Value = new DateTime(2026, 1, 9, 22, 41, 46, 5);
            dtpkFilter.ValueChanged += u;
            // 
            // cbxActive
            // 
            cbxActive.BackColor = Color.Transparent;
            cbxActive.CustomizableEdges = customizableEdges3;
            cbxActive.DrawMode = DrawMode.OwnerDrawFixed;
            cbxActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxActive.FocusedColor = Color.Teal;
            cbxActive.FocusedState.BorderColor = Color.Teal;
            cbxActive.FocusedState.ForeColor = Color.White;
            cbxActive.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxActive.ForeColor = Color.FromArgb(64, 64, 64);
            cbxActive.HoverState.FillColor = Color.Teal;
            cbxActive.HoverState.ForeColor = Color.White;
            cbxActive.ItemHeight = 30;
            cbxActive.Items.AddRange(new object[] { "Đang Học", "Chưa Bắt Đầu" });
            cbxActive.ItemsAppearance.BackColor = Color.Teal;
            cbxActive.ItemsAppearance.SelectedForeColor = Color.White;
            cbxActive.Location = new Point(490, 0);
            cbxActive.Name = "cbxActive";
            cbxActive.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbxActive.Size = new Size(157, 36);
            cbxActive.StartIndex = 0;
            cbxActive.TabIndex = 2;
            cbxActive.SelectedIndexChanged += cbxActive_SelectedIndexChanged;
            // 
            // cbxCourseName
            // 
            cbxCourseName.BackColor = Color.Transparent;
            cbxCourseName.CustomizableEdges = customizableEdges5;
            cbxCourseName.DrawMode = DrawMode.OwnerDrawFixed;
            cbxCourseName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCourseName.FocusedColor = Color.Teal;
            cbxCourseName.FocusedState.BorderColor = Color.Teal;
            cbxCourseName.FocusedState.FillColor = Color.Transparent;
            cbxCourseName.FocusedState.ForeColor = Color.White;
            cbxCourseName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxCourseName.ForeColor = Color.FromArgb(64, 64, 64);
            cbxCourseName.HoverState.FillColor = Color.Teal;
            cbxCourseName.HoverState.ForeColor = Color.White;
            cbxCourseName.ItemHeight = 30;
            cbxCourseName.Items.AddRange(new object[] { "Tên Khóa Học", "STARTS" });
            cbxCourseName.ItemsAppearance.SelectedBackColor = Color.Teal;
            cbxCourseName.ItemsAppearance.SelectedForeColor = Color.White;
            cbxCourseName.Location = new Point(193, 0);
            cbxCourseName.Name = "cbxCourseName";
            cbxCourseName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbxCourseName.Size = new Size(288, 36);
            cbxCourseName.StartIndex = 0;
            cbxCourseName.TabIndex = 11;
            cbxCourseName.SelectedIndexChanged += cbxCourseName_SelectedIndexChanged;
            // 
            // flowMain
            // 
            flowMain.Controls.Add(tfpClassList);
            flowMain.CustomizableEdges = customizableEdges9;
            flowMain.Location = new Point(3, 73);
            flowMain.Margin = new Padding(0);
            flowMain.Name = "flowMain";
            flowMain.ShadowDecoration.CustomizableEdges = customizableEdges10;
            flowMain.Size = new Size(1453, 773);
            flowMain.TabIndex = 13;
            // 
            // tfpClassList
            // 
            tfpClassList.ColumnCount = 4;
            tfpClassList.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tfpClassList.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tfpClassList.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tfpClassList.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tfpClassList.Location = new Point(3, 3);
            tfpClassList.Name = "tfpClassList";
            tfpClassList.RowCount = 2;
            tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, 251F));
            tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, 249F));
            tfpClassList.Size = new Size(1422, 500);
            tfpClassList.TabIndex = 13;
            // 
            // pnTextBox
            // 
            pnTextBox.BackColor = Color.Transparent;
            pnTextBox.BorderColor = Color.Gray;
            pnTextBox.BorderRadius = 8;
            pnTextBox.BorderThickness = 1;
            pnTextBox.Controls.Add(txbSearchClass);
            pnTextBox.Controls.Add(iconCustom1);
            pnTextBox.CustomizableEdges = customizableEdges13;
            pnTextBox.FillColor = Color.White;
            pnTextBox.Location = new Point(3, 3);
            pnTextBox.Name = "pnTextBox";
            pnTextBox.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnTextBox.Size = new Size(377, 43);
            pnTextBox.TabIndex = 11;
            // 
            // txbSearchClass
            // 
            txbSearchClass.BackColor = Color.Transparent;
            txbSearchClass.BorderColor = Color.White;
            txbSearchClass.BorderThickness = 0;
            txbSearchClass.CustomizableEdges = customizableEdges11;
            txbSearchClass.DefaultText = "";
            txbSearchClass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txbSearchClass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txbSearchClass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txbSearchClass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txbSearchClass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txbSearchClass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbSearchClass.ForeColor = Color.Black;
            txbSearchClass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txbSearchClass.Location = new Point(38, 3);
            txbSearchClass.Margin = new Padding(4, 4, 6, 4);
            txbSearchClass.Name = "txbSearchClass";
            txbSearchClass.PlaceholderForeColor = Color.Gray;
            txbSearchClass.PlaceholderText = "Lớp học cần tìm kiếm...";
            txbSearchClass.SelectedText = "";
            txbSearchClass.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txbSearchClass.Size = new Size(332, 36);
            txbSearchClass.TabIndex = 12;
            txbSearchClass.TextChanged += txbSearchClass_TextChanged;
            // 
            // iconCustom1
            // 
            iconCustom1.BackColor = Color.Transparent;
            iconCustom1.Dock = DockStyle.Left;
            iconCustom1.Icon = FontAwesome.Sharp.IconChar.Search;
            iconCustom1.IconColor = Color.Gray;
            iconCustom1.IconSize = 28;
            iconCustom1.Location = new Point(0, 0);
            iconCustom1.Margin = new Padding(10, 3, 3, 3);
            iconCustom1.Name = "iconCustom1";
            iconCustom1.Padding = new Padding(10, 0, 0, 0);
            iconCustom1.Size = new Size(38, 43);
            iconCustom1.TabIndex = 10;
            // 
            // ClassList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            ForeColor = Color.ForestGreen;
            Name = "ClassList";
            Size = new Size(1459, 849);
            panel1.ResumeLayout(false);
            pnFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            flowMain.ResumeLayout(false);
            pnTextBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txbSearchClass;
        private Guna.UI2.WinForms.Guna2Panel pnTextBox;
        private IconCustom iconCustom1;
        private Guna.UI2.WinForms.Guna2GradientPanel flowMain;
        private TableLayoutPanel tfpClassList;
        private Guna.UI2.WinForms.Guna2GradientPanel pnFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbxCourseName;
        private Guna.UI2.WinForms.Guna2ComboBox cbxActive;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkFilter;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}
