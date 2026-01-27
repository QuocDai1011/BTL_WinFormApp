namespace BaiTapLonWinForm.Views.Student.Controllers
{
    partial class UC_CardCalendar
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
            lbNameClass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            startDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            endDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnColor = new Guna.UI2.WinForms.Guna2Panel();
            panel1 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbNameClass
            // 
            lbNameClass.AutoSize = false;
            lbNameClass.BackColor = Color.Transparent;
            lbNameClass.Dock = DockStyle.Fill;
            lbNameClass.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNameClass.Location = new Point(0, 0);
            lbNameClass.Name = "lbNameClass";
            lbNameClass.Size = new Size(546, 49);
            lbNameClass.TabIndex = 0;
            lbNameClass.Text = "Chủ nghĩa xã hội khoa học và chiến dịch đạt ";
            // 
            // startDate
            // 
            startDate.BackColor = Color.Transparent;
            startDate.Dock = DockStyle.Left;
            startDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            startDate.Location = new Point(29, 3);
            startDate.Name = "startDate";
            startDate.Size = new Size(69, 17);
            startDate.TabIndex = 3;
            startDate.Text = "31/08/2005";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Dock = DockStyle.Left;
            guna2HtmlLabel1.Location = new Point(3, 3);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(20, 17);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Từ:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(guna2HtmlLabel1);
            flowLayoutPanel1.Controls.Add(startDate);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 49);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(546, 20);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(guna2HtmlLabel2);
            flowLayoutPanel2.Controls.Add(endDate);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 69);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(546, 21);
            flowLayoutPanel2.TabIndex = 6;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Dock = DockStyle.Right;
            guna2HtmlLabel2.Location = new Point(3, 3);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(27, 17);
            guna2HtmlLabel2.TabIndex = 3;
            guna2HtmlLabel2.Text = "Đến:";
            // 
            // endDate
            // 
            endDate.BackColor = Color.Transparent;
            endDate.Dock = DockStyle.Right;
            endDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            endDate.Location = new Point(36, 3);
            endDate.Name = "endDate";
            endDate.Size = new Size(69, 17);
            endDate.TabIndex = 4;
            endDate.Text = "31/08/2005";
            // 
            // pnColor
            // 
            pnColor.BackColor = Color.LightSalmon;
            pnColor.CustomizableEdges = customizableEdges3;
            pnColor.Dock = DockStyle.Left;
            pnColor.Location = new Point(5, 5);
            pnColor.Name = "pnColor";
            pnColor.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnColor.Size = new Size(10, 90);
            pnColor.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbNameClass);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(15, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 90);
            panel1.TabIndex = 8;
            // 
            // UC_CardCalendar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(pnColor);
            Margin = new Padding(0);
            Name = "UC_CardCalendar";
            Padding = new Padding(5);
            Size = new Size(566, 100);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lbNameClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel startDate;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel endDate;
        private Guna.UI2.WinForms.Guna2Panel pnColor;
        private Panel panel1;
    }
}
