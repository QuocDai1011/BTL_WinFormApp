namespace BaiTapLonWinForm.Views.Teacher.MyClass.MyNews
{
    partial class ExpiredExam
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
            guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            lblTimeAndContent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblDeadline = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel4.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel4
            // 
            guna2Panel4.Controls.Add(lblTimeAndContent);
            guna2Panel4.Controls.Add(lblDeadline);
            guna2Panel4.CustomizableEdges = customizableEdges1;
            guna2Panel4.Dock = DockStyle.Fill;
            guna2Panel4.ForeColor = SystemColors.ControlDarkDark;
            guna2Panel4.Location = new Point(0, 0);
            guna2Panel4.Margin = new Padding(0);
            guna2Panel4.Name = "guna2Panel4";
            guna2Panel4.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel4.Size = new Size(300, 67);
            guna2Panel4.TabIndex = 1;
            // 
            // lblTimeAndContent
            // 
            lblTimeAndContent.BackColor = Color.Transparent;
            lblTimeAndContent.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimeAndContent.ForeColor = SystemColors.WindowFrame;
            lblTimeAndContent.Location = new Point(15, 32);
            lblTimeAndContent.Name = "lblTimeAndContent";
            lblTimeAndContent.Size = new Size(117, 23);
            lblTimeAndContent.TabIndex = 2;
            lblTimeAndContent.Text = "23:59 - Bài tập 1";
            // 
            // lblDeadline
            // 
            lblDeadline.BackColor = Color.Transparent;
            lblDeadline.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeadline.ForeColor = SystemColors.GrayText;
            lblDeadline.Location = new Point(15, 11);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(105, 19);
            lblDeadline.TabIndex = 1;
            lblDeadline.Text = "Đến hạn hôm nay";
            // 
            // ExpiredExam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2Panel4);
            Margin = new Padding(0);
            Name = "ExpiredExam";
            Size = new Size(300, 67);
            guna2Panel4.ResumeLayout(false);
            guna2Panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTimeAndContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDeadline;
    }
}
