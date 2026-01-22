namespace BaiTapLonWinForm.Views.Student.Controllers
{
    partial class UC_Dashboard
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
            pnlRender = new Panel();
            SuspendLayout();
            // 
            // pnlRender
            // 
            pnlRender.Dock = DockStyle.Fill;
            pnlRender.Location = new Point(0, 0);
            pnlRender.Name = "pnlRender";
            pnlRender.Size = new Size(1225, 616);
            pnlRender.TabIndex = 0;
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 245, 232);
            Controls.Add(pnlRender);
            Name = "UC_Dashboard";
            Size = new Size(1225, 616);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlRender;
    }
}
