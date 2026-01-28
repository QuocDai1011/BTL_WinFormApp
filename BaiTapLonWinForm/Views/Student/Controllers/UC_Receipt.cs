using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using System.Diagnostics;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Receipt : UserControl
    {
        private readonly IReceiptService _receiptService;
        public UC_Receipt(IReceiptService receiptService, int studentId)
        {
            InitializeComponent();
            _receiptService = receiptService;
            LoadReceipt(studentId);
        }

        private void LoadReceipt(int studentId)
        {
            if (_receiptService == null)
                throw new Exception("_receiptService IS NULL");
            var data = _receiptService.GetAllReceiptByStudentId(studentId);

            if (data == null)
            {
                MessageHelper.ShowInfo("Bạn chưa mua khóa học nào", "Thông báo");
                return;
            }

            listReceipt.AutoGenerateColumns = true;
            listReceipt.DataSource = data;

            listReceipt.Columns["NameStudent"].Visible = false;
            listReceipt.Columns["SChoolDay"].Visible = false;
            listReceipt.Columns["StartDate"].Visible = false;
            listReceipt.Columns["EndDate"].Visible = false;

            listReceipt.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            listReceipt.Columns["TotalAmount"].DefaultCellStyle.Format = "#,##0 VNĐ";
            listReceipt.Columns["PaidAmount"].DefaultCellStyle.Format = "#,##0 VNĐ";

            listReceipt.Columns["CreateAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void listReceipt_DoubleClick(object sender, EventArgs e)
        {
            if (listReceipt.CurrentRow == null) return;

            string status = listReceipt.CurrentRow
                .Cells["Status"]
                .Value?
                .ToString() ?? "";

            Debug.WriteLine(status);

            if (status == "UNPAID")
            {
                MessageHelper.ShowInfo(
                    "Thanh toán thất bại, hãy liên hệ với bên trung tâm để được xử lý",
                    "Thông báo"
                );
                return;
            }

            if (status == "PENDING")
            {
                MessageHelper.ShowInfo(
                    "Đơn đang chờ xử lý, chưa thể xuất hóa đơn",
                    "Thông báo"
                );
                return;
            }

            var kq = MessageBox.Show(
                "Xác nhận xuất hóa đơn",
                "Xuất hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (kq == DialogResult.No) return;

            // 1️⃣ Thư mục Downloads
            string downloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads"
            );

            if (!Directory.Exists(downloadsPath))
                Directory.CreateDirectory(downloadsPath);

            // 2️⃣ Lấy dữ liệu
            DataGridViewRow row = listReceipt.CurrentRow;

            string hocVien = row.Cells["NameStudent"].Value?.ToString() ?? "HocVien";
            string lop = row.Cells["NameCourse"].Value?.ToString() ?? "Lop";
            decimal soTien = Convert.ToDecimal(row.Cells["TotalAmount"].Value ?? 0);
            decimal giamGia = Convert.ToDecimal(row.Cells["PaidAmount"].Value ?? 0);

            string noiDung = "";
            string lichHoc = RegexUtilities.ToVietnameseDay(
                row.Cells["SchoolDay"].Value?.ToString() ?? ""
            );

            string khaiGiang = row.Cells["StartDate"].Value?.ToString() ?? "";
            string ketThuc = row.Cells["EndDate"].Value?.ToString() ?? "";

            // 3️⃣ Tên file
            string fileName = $"HoaDon_{hocVien}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            fileName = string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));

            string fullPath = Path.Combine(downloadsPath, fileName);

            // 4️⃣ Tạo PDF
            PdfHelper.CreateReceiptPdf(
                fullPath,
                hocVien,
                lop,
                soTien,
                giamGia,
                noiDung,
                lichHoc,
                khaiGiang,
                ketThuc
            );

            // 5️⃣ Mở PDF
            Process.Start(new ProcessStartInfo
            {
                FileName = fullPath,
                UseShellExecute = true
            });
        }

        private void listReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (listReceipt.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "PAID")
                {
                    e.Value = "Đã thanh toán";
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (status == "PENDING")
                {
                    e.Value = "Đang chờ xử lý";
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    e.Value = "Thanh toán thất bại";
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
