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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            pnTextBox = new Guna.UI2.WinForms.Guna2Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            iconCustom1 = new IconCustom();
            flowMain = new Guna.UI2.WinForms.Guna2GradientPanel();
            tfpClassList = new TableLayoutPanel();
            panel1.SuspendLayout();
            pnTextBox.SuspendLayout();
            flowMain.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(flowMain);
            panel1.Controls.Add(pnTextBox);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1459, 849);
            panel1.TabIndex = 7;
            // 
            // pnTextBox
            // 
            pnTextBox.BackColor = Color.White;
            pnTextBox.BorderColor = Color.Gray;
            pnTextBox.BorderRadius = 8;
            pnTextBox.BorderThickness = 1;
            pnTextBox.Controls.Add(guna2TextBox1);
            pnTextBox.Controls.Add(iconCustom1);
            pnTextBox.CustomizableEdges = customizableEdges5;
            pnTextBox.Location = new Point(3, 3);
            pnTextBox.Name = "pnTextBox";
            pnTextBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnTextBox.Size = new Size(496, 43);
            pnTextBox.TabIndex = 11;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.Transparent;
            guna2TextBox1.BorderColor = Color.White;
            guna2TextBox1.BorderThickness = 0;
            guna2TextBox1.CustomizableEdges = customizableEdges3;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(38, 3);
            guna2TextBox1.Margin = new Padding(4, 4, 6, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderForeColor = Color.Gray;
            guna2TextBox1.PlaceholderText = "Lớp học cần tìm kiếm...";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2TextBox1.Size = new Size(452, 36);
            guna2TextBox1.TabIndex = 12;
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
            // flowMain
            // 
            flowMain.Controls.Add(tfpClassList);
            flowMain.CustomizableEdges = customizableEdges1;
            flowMain.Location = new Point(3, 73);
            flowMain.Margin = new Padding(0);
            flowMain.Name = "flowMain";
            flowMain.ShadowDecoration.CustomizableEdges = customizableEdges2;
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
            tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, 278F));
            tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, 278F));
            tfpClassList.Size = new Size(1422, 552);
            tfpClassList.TabIndex = 13;
            // 
            // ClassList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel1);
            ForeColor = Color.ForestGreen;
            Name = "ClassList";
            Size = new Size(1459, 849);
            panel1.ResumeLayout(false);
            pnTextBox.ResumeLayout(false);
            flowMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Panel pnTextBox;
        private IconCustom iconCustom1;
        private Guna.UI2.WinForms.Guna2GradientPanel flowMain;
        private TableLayoutPanel tfpClassList;
    }
}
