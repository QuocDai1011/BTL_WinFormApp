namespace BaiTapLonWinForm.Views.Student.Controllers
{
    partial class UC_BuyCourse
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
            renderControl = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // renderControl
            // 
            renderControl.CustomizableEdges = customizableEdges1;
            renderControl.Dock = DockStyle.Fill;
            renderControl.Location = new Point(0, 0);
            renderControl.Name = "renderControl";
            renderControl.ShadowDecoration.CustomizableEdges = customizableEdges2;
            renderControl.Size = new Size(1238, 620);
            renderControl.TabIndex = 0;
            // 
            // UC_BuyCourse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 245, 232);
            Controls.Add(renderControl);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UC_BuyCourse";
            Size = new Size(1238, 620);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel renderControl;
    }
}
