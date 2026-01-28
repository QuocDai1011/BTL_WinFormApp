namespace BaiTapLonWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvNewfeeds = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvNewfeeds).BeginInit();
            SuspendLayout();
            // 
            // dgvNewfeeds
            // 
            dgvNewfeeds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNewfeeds.Location = new Point(12, 12);
            dgvNewfeeds.Name = "dgvNewfeeds";
            dgvNewfeeds.Size = new Size(1291, 470);
            dgvNewfeeds.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 712);
            Controls.Add(dgvNewfeeds);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvNewfeeds).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvNewfeeds;
    }
}
