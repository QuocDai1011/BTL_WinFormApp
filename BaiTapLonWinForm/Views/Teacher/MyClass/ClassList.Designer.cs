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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            flowMain = new FlowLayoutPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            iconCustom1 = new IconCustom();
            panel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(flowMain);
            panel1.Controls.Add(guna2Panel1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1459, 849);
            panel1.TabIndex = 7;
            // 
            // flowMain
            // 
            flowMain.AutoScroll = true;
            flowMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowMain.Location = new Point(3, 72);
            flowMain.Margin = new Padding(10);
            flowMain.Name = "flowMain";
            flowMain.Size = new Size(1456, 774);
            flowMain.TabIndex = 12;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderColor = Color.Gray;
            guna2Panel1.BorderRadius = 8;
            guna2Panel1.BorderThickness = 1;
            guna2Panel1.Controls.Add(guna2TextBox1);
            guna2Panel1.Controls.Add(iconCustom1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(3, 3);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(496, 43);
            guna2Panel1.TabIndex = 11;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.Transparent;
            guna2TextBox1.BorderColor = Color.White;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(39, 4);
            guna2TextBox1.Margin = new Padding(4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderForeColor = Color.Gray;
            guna2TextBox1.PlaceholderText = "Lớp học cần tìm kiếm...";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(453, 35);
            guna2TextBox1.TabIndex = 12;
            // 
            // iconCustom1
            // 
            iconCustom1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            iconCustom1.BackColor = Color.Transparent;
            iconCustom1.Icon = FontAwesome.Sharp.IconChar.Search;
            iconCustom1.IconColor = Color.Gray;
            iconCustom1.IconSize = 28;
            iconCustom1.Location = new Point(7, 9);
            iconCustom1.Name = "iconCustom1";
            iconCustom1.Size = new Size(28, 28);
            iconCustom1.TabIndex = 10;
            // 
            // ClassList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            ForeColor = Color.ForestGreen;
            Name = "ClassList";
            Size = new Size(1459, 849);
            panel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private IconCustom iconCustom1;
        private FlowLayoutPanel flowMain;
    }
}
