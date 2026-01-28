using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.View.Admin.Receipt.DTO;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Receipt
{
    public partial class ReceiptManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private List<ReceiptDTO> _allReceipts = new();


        public ReceiptManagement(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dgvReceipt.CellFormatting += dgvReceipt_CellFormatting;
            dgvReceipt.CellContentClick += dgvReceipt_CellContentClick;

            await LoadReceiptsAsync();
        }

        private async Task LoadReceiptsAsync()
        {
            _allReceipts = await _serviceHub.ReceiptService.GetAllReceiptsAsync();

            InitReceiptGrid();
            dgvReceipt.DataSource = _allReceipts;
            lblTotalReceipt.Text = _allReceipts.Count.ToString();

            cboFilter.SelectedIndexChanged -= CboFilter_SelectedIndexChanged;
            cboFilter.SelectedIndexChanged += CboFilter_SelectedIndexChanged;

            cboFilter.SelectedIndex = 0; // Tất cả
        }

        private void CboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ReceiptDTO> filtered;

            switch (cboFilter.SelectedIndex)
            {
                case 0: // Tất cả
                    filtered = _allReceipts;
                    break;

                case 1: // Đã thanh toán
                    filtered = _allReceipts
                        .Where(x => x.Status == "PAID")
                        .ToList();
                    break;

                case 2: // Chờ xác nhận
                    filtered = _allReceipts
                        .Where(x => x.Status == "PENDING")
                        .ToList();
                    break;

                case 3: // Chưa thanh toán
                    filtered = _allReceipts
                        .Where(x => x.Status == "UNPAID")
                        .ToList();
                    break;

                case 4: // Thất bại
                    filtered = _allReceipts
                        .Where(x => x.Status == "FAILED")
                        .ToList();
                    break;

                default:
                    filtered = _allReceipts;
                    break;
            }

            dgvReceipt.DataSource = null;
            dgvReceipt.DataSource = filtered;
            lblTotalReceipt.Text = filtered.Count.ToString();
        }



        private void InitReceiptGrid()
        {
            dgvReceipt.Columns.Clear();
            dgvReceipt.AutoGenerateColumns = false;

            dgvReceipt.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullName",
                HeaderText = "Tên học viên",
                DataPropertyName = "FullName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvReceipt.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colClassName",
                HeaderText = "Tên lớp học",
                DataPropertyName = "ClassName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvReceipt.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPromotion",
                HeaderText = "Loại ưu đãi",
                DataPropertyName = "PromotionName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvReceipt.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTuition",
                HeaderText = "Tổng học phí",
                DataPropertyName = "Tuition",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0"
                }
            });

            dgvReceipt.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status"
            });

            dgvReceipt.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCreateAt",
                HeaderText = "Tạo ngày",
                DataPropertyName = "CreateAt",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

            dgvReceipt.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colConfirm",
                HeaderText = "",
                Text = "Xác nhận",
                UseColumnTextForButtonValue = true,
                Width = 100,
                FlatStyle = FlatStyle.Flat, // QUAN TRỌNG
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Red,      
                    ForeColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            });
        }

        /// <summary>
        /// Ẩn nút xác nhận nếu Status != PENDING
        /// </summary>
        private void dgvReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReceipt.Columns[e.ColumnIndex].Name != "colConfirm" || e.RowIndex < 0)
                return;

            var cell = dgvReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var status = dgvReceipt.Rows[e.RowIndex]
                .Cells["colStatus"].Value?.ToString();

            if (status == "PENDING")
            {
                e.Value = "Xác nhận";
                e.FormattingApplied = true;

                cell.ReadOnly = false;

                cell.Style.BackColor = Color.Red;

                cell.Style.ForeColor = Color.White;

                cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            else
            {
                // ẨN NÚT
                e.Value = "";
                e.FormattingApplied = true;

                cell.ReadOnly = true;
                cell.Style.BackColor = dgvReceipt.BackgroundColor;
            }
        }


        /// <summary>
        /// Click nút xác nhận
        /// </summary>
        private void dgvReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvReceipt.Columns[e.ColumnIndex].Name != "colConfirm")
                return;

            var row = dgvReceipt.Rows[e.RowIndex];

            if (row.DataBoundItem is not ReceiptDTO receipt)
                return;

            if (receipt.Status != "PENDING")
                return;

            var result = MessageBox.Show(
                $"👤 Học viên: {receipt.FullName}\n" +
                $"📘 Lớp học: {receipt.ClassName}\n" +
                $"💰 Học phí: {receipt.Tuition:N0} VNĐ\n\n" +
                $"Bạn có chắc muốn xác nhận thanh toán?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            // ✅ 1. Gọi DB
            _serviceHub.ReceiptService
                .ConfirmReceipt(receipt.StudentId, receipt.ClassId);

            // ✅ 2. Cập nhật trạng thái NGAY LẬP TỨC
            receipt.Status = "PAID";

            // ✅ 3. Ép DataGridView vẽ lại dòng này
            dgvReceipt.InvalidateRow(e.RowIndex);

            MessageBox.Show(
                "✅ Xác nhận thanh toán thành công!",
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


    }
}
