namespace BaiTapLonWinForm.View.Admin.Class
{
    partial class ClassManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPageUpcoming = new System.Windows.Forms.TabPage();
            this.tabPageOngoing = new System.Windows.Forms.TabPage();
            this.tabPageFinished = new System.Windows.Forms.TabPage();
            this.guna2TabControl1.SuspendLayout();
            this.SuspendLayout();

            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Top;
            this.guna2TabControl1.Controls.Add(this.tabPageUpcoming);
            this.guna2TabControl1.Controls.Add(this.tabPageOngoing);
            this.guna2TabControl1.Controls.Add(this.tabPageFinished);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 50);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.Padding = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(1532, 850);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 50);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;

            // 
            // tabPageUpcoming
            // 
            this.tabPageUpcoming.BackColor = System.Drawing.Color.White;
            this.tabPageUpcoming.Location = new System.Drawing.Point(4, 54);
            this.tabPageUpcoming.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageUpcoming.Name = "tabPageUpcoming";
            this.tabPageUpcoming.Padding = new System.Windows.Forms.Padding(0);
            this.tabPageUpcoming.Size = new System.Drawing.Size(1524, 792);
            this.tabPageUpcoming.TabIndex = 0;
            this.tabPageUpcoming.Text = "Sắp diễn ra";

            // 
            // tabPageOngoing
            // 
            this.tabPageOngoing.BackColor = System.Drawing.Color.White;
            this.tabPageOngoing.Location = new System.Drawing.Point(4, 54);
            this.tabPageOngoing.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageOngoing.Name = "tabPageOngoing";
            this.tabPageOngoing.Padding = new System.Windows.Forms.Padding(0);
            this.tabPageOngoing.Size = new System.Drawing.Size(1524, 792);
            this.tabPageOngoing.TabIndex = 1;
            this.tabPageOngoing.Text = "Đang diễn ra";

            // 
            // tabPageFinished
            // 
            this.tabPageFinished.BackColor = System.Drawing.Color.White;
            this.tabPageFinished.Location = new System.Drawing.Point(4, 54);
            this.tabPageFinished.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageFinished.Name = "tabPageFinished";
            this.tabPageFinished.Padding = new System.Windows.Forms.Padding(0);
            this.tabPageFinished.Size = new System.Drawing.Size(1524, 792);
            this.tabPageFinished.TabIndex = 2;
            this.tabPageFinished.Text = "Đã kết thúc";

            // 
            // ClassManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2TabControl1);
            this.Name = "ClassManagement";
            this.Size = new System.Drawing.Size(1532, 850);
            this.guna2TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPageUpcoming;
        private System.Windows.Forms.TabPage tabPageOngoing;
        private System.Windows.Forms.TabPage tabPageFinished;
    }
}