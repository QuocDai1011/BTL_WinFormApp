using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Schedule
{
    public partial class DateRangePickerForm : Form
    {
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEnd;
        private Guna.UI2.WinForms.Guna2Button btnOK;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Label lblTitle;
        private Label lblStart;
        private Label lblEnd;
        private Label lblInfo;

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public DateRangePickerForm(DateTime defaultStart, DateTime defaultEnd)
        {
            InitializeForm();
            dtpStart.Value = defaultStart;
            dtpEnd.Value = defaultEnd;
            StartDate = defaultStart;
            EndDate = defaultEnd;
        }

        #region initialize
        private void InitializeForm()
        {
            this.Size = new Size(450, 320);
            this.Text = "Chọn khoảng thời gian";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            lblTitle = new Label
            {
                Text = "📅 Chọn Khoảng Thời Gian",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(94, 148, 255),
                Location = new Point(20, 20),
                Size = new Size(400, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblInfo = new Label
            {
                Text = "Lưu ý: Khoảng thời gian tối đa là 7 ngày",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(20, 55),
                Size = new Size(400, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblStart = new Label
            {
                Text = "Từ ngày:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(30, 95),
                Size = new Size(100, 25)
            };

            dtpStart = new Guna.UI2.WinForms.Guna2DateTimePicker
            {
                Location = new Point(140, 90),
                Size = new Size(270, 36),
                BorderRadius = 8,
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10)
            };
            dtpStart.ValueChanged += DatePicker_ValueChanged;

            lblEnd = new Label
            {
                Text = "Đến ngày:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(30, 145),
                Size = new Size(100, 25)
            };

            dtpEnd = new Guna.UI2.WinForms.Guna2DateTimePicker
            {
                Location = new Point(140, 140),
                Size = new Size(270, 36),
                BorderRadius = 8,
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10)
            };
            dtpEnd.ValueChanged += DatePicker_ValueChanged;

            btnOK = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "✓ Xác nhận",
                Location = new Point(140, 220),
                Size = new Size(130, 40),
                BorderRadius = 8,
                FillColor = Color.FromArgb(94, 148, 255),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            btnOK.Click += BtnOK_Click;

            btnCancel = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "✕ Hủy",
                Location = new Point(280, 220),
                Size = new Size(130, 40),
                BorderRadius = 8,
                FillColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblInfo, lblStart, dtpStart, lblEnd, dtpEnd, btnOK, btnCancel
            });
        }
        #endregion

        #region handle events
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Validate range
            if (dtpEnd.Value < dtpStart.Value)
            {
                lblInfo.Text = "⚠️ Ngày kết thúc phải sau ngày bắt đầu!";
                lblInfo.ForeColor = Color.Red;
                btnOK.Enabled = false;
                return;
            }

            TimeSpan diff = dtpEnd.Value.Date - dtpStart.Value.Date;
            if (diff.Days > 6)
            {
                lblInfo.Text = $"⚠️ Khoảng thời gian quá dài ({diff.Days + 1} ngày). Tối đa 7 ngày!";
                lblInfo.ForeColor = Color.Red;
                btnOK.Enabled = false;
                return;
            }

            lblInfo.Text = $"✓ Đã chọn {diff.Days + 1} ngày";
            lblInfo.ForeColor = Color.FromArgb(102, 187, 106);
            btnOK.Enabled = true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            StartDate = dtpStart.Value.Date;
            EndDate = dtpEnd.Value.Date;

            TimeSpan diff = EndDate - StartDate;
            if (diff.Days < 0 || diff.Days > 6)
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ!\nVui lòng chọn từ 1 đến 7 ngày.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
