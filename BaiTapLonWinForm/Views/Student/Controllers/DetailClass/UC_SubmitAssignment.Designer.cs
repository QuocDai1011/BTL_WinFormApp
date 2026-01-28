namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    partial class UC_SubmitAssignment
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gunaLink = new Guna.UI2.WinForms.Guna2TextBox();
            btnSubmit = new Guna.UI2.WinForms.Guna2GradientButton();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // gunaLink
            // 
            gunaLink.BorderColor = Color.Teal;
            gunaLink.BorderRadius = 6;
            gunaLink.CustomizableEdges = customizableEdges1;
            gunaLink.DefaultText = "Dán đường dẫn google drive vào đây";
            gunaLink.DisabledState.BorderColor = Color.FromArgb(234, 153, 149);
            gunaLink.DisabledState.FillColor = Color.FromArgb(241, 240, 236);
            gunaLink.DisabledState.ForeColor = Color.FromArgb(125, 137, 149);
            gunaLink.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            gunaLink.Dock = DockStyle.Fill;
            gunaLink.FillColor = Color.FromArgb(241, 240, 236);
            gunaLink.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            gunaLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gunaLink.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            gunaLink.Location = new Point(0, 0);
            gunaLink.Margin = new Padding(4);
            gunaLink.Name = "gunaLink";
            gunaLink.PlaceholderText = "";
            gunaLink.SelectedText = "";
            gunaLink.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gunaLink.Size = new Size(465, 46);
            gunaLink.TabIndex = 4;
            // 
            // btnSubmit
            // 
            btnSubmit.BorderColor = Color.Teal;
            btnSubmit.BorderRadius = 20;
            btnSubmit.BorderThickness = 1;
            btnSubmit.CustomizableEdges = customizableEdges3;
            btnSubmit.DisabledState.BorderColor = Color.DarkGray;
            btnSubmit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSubmit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSubmit.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnSubmit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSubmit.Dock = DockStyle.Right;
            btnSubmit.FillColor = Color.White;
            btnSubmit.FillColor2 = Color.White;
            btnSubmit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.Teal;
            btnSubmit.HoverState.BorderColor = Color.Teal;
            btnSubmit.HoverState.CustomBorderColor = Color.Teal;
            btnSubmit.HoverState.FillColor = Color.Teal;
            btnSubmit.HoverState.FillColor2 = Color.Teal;
            btnSubmit.HoverState.ForeColor = Color.White;
            btnSubmit.Location = new Point(18, 0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSubmit.Size = new Size(95, 46);
            btnSubmit.TabIndex = 29;
            btnSubmit.Text = "Nộp bài";
            // 
            // panel1
            // 
            panel1.Controls.Add(gunaLink);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 46);
            panel1.TabIndex = 30;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSubmit);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(470, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(113, 46);
            panel2.TabIndex = 31;
            // 
            // UC_SubmitAssignment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_SubmitAssignment";
            Padding = new Padding(5);
            Size = new Size(588, 56);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox gunaLink;
        private Guna.UI2.WinForms.Guna2GradientButton btnSubmit;
        private Panel panel1;
        private Panel panel2;
    }
}
