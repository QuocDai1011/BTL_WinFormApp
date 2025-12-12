using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.View.Admin.Students; // Đảm bảo namespace đúng để gọi Add/Edit
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class StudentManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;

        // Biến toàn cục chứa dữ liệu gốc (Master List)
        private List<Student> _masterStudentList = new List<Student>();

        public StudentManagement(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            SetupModernUI();
        }

        #region 1. UI Setup & Initialization

        private void SetupModernUI()
        {
            // Bo tròn các panel và button
            ApplyRoundedCorners(panelSearch, 10);
            ApplyRoundedCorners(panelButtons, 10);
            ApplyRoundedCorners(panelStats, 10);

            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button btn) ApplyRoundedCorners(btn, 8);
            }

            ApplyRoundedCorners(btnImport, 8);
            ApplyRoundedCorners(btnExport, 8);
            ApplyRoundedCorners(btnSearch, 8);
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private async void StudentManagement_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho Combobox lọc
            if (cboFilter.Items.Count > 0 && cboFilter.SelectedIndex == -1)
            {
                cboFilter.SelectedIndex = 0; // Chọn "Tất cả"
            }

            // Tải dữ liệu lần đầu
            await RefreshDataAsync();
        }

        #endregion

        #region 2. Core Data Handling (Logic quan trọng nhất)

        /// <summary>
        /// Hàm trung tâm: Lấy dữ liệu mới nhất từ DB -> Cập nhật Master List -> Áp dụng bộ lọc -> Vẽ lại Grid
        /// Gọi hàm này sau bất kỳ hành động nào làm thay đổi dữ liệu (Thêm, Sửa, Xóa, Import)
        /// </summary>
        private async Task RefreshDataAsync()
        {
            try
            {
                // 1. Gọi Service lấy dữ liệu mới nhất
                var result = await _serviceHub.StudentService.GetAllStudentsAsync();

                if (result.Success)
                {
                    // 2. Cập nhật biến toàn cục
                    _masterStudentList = result.Data.ToList();

                    // 3. Áp dụng bộ lọc hiện tại (để giữ nguyên ngữ cảnh người dùng đang xem)
                    ApplyCurrentFilter();
                }
                else
                {
                    MessageHelper.ShowError($"Không thể tải dữ liệu: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi hệ thống khi tải dữ liệu: {ex.Message}");
            }
        }

        /// <summary>
        /// Logic lọc dữ liệu dựa trên MasterList và Combobox
        /// </summary>
        private void ApplyCurrentFilter()
        {
            if (_masterStudentList == null || !_masterStudentList.Any()) return;

            string selectedFilter = cboFilter.SelectedItem?.ToString() ?? "Tất cả";
            List<Student> filteredList = new List<Student>();

            switch (selectedFilter)
            {
                case "Nam":
                    filteredList = _masterStudentList
                        .Where(s => s.User.Gender == true)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    break;
                case "Nữ":
                    filteredList = _masterStudentList
                        .Where(s => s.User.Gender == false)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    break;
                case "Đang hoạt động":
                    filteredList = _masterStudentList
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    break;
                case "Ngừng hoạt động":
                    filteredList = _masterStudentList
                        .Where(s => s.User.IsActive == false)
                        .ToList();
                    break;
                case "Chưa có ảnh":
                    filteredList = _masterStudentList
                        .Where(s => s.StudentFaceImages == null || s.StudentFaceImages.Count == 0)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    break;
                case "Có ảnh":
                    filteredList = _masterStudentList
                        .Where(s => s.StudentFaceImages != null && s.StudentFaceImages.Count > 0)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    break;
                case "Tất cả":
                default:
                    filteredList = _masterStudentList.Where(s=> s.User.IsActive == true).ToList();
                    break;
            }
        
            _ = RenderGridAsync(filteredList);
        }

        private async Task RenderGridAsync(List<Student> dataToRender)
        {
            try
            {
                dgvStudents.Rows.Clear();

                foreach (var student in dataToRender)
                {
                   
                    int imageCount = await _serviceHub.StudentFaceService.GetImageCountAsync(student.StudentId);

                    int rowIndex = dgvStudents.Rows.Add(
                        student.UserId,
                        student.StudentId,
                        $"{student.User.FirstName} {student.User.LastName}",
                        student.User.Email,
                        student.User.PhoneNumber,
                        student.PhoneNumberOfParents,
                        student.User.DateOfBirth.ToString("dd/MM/yyyy"),
                        imageCount > 0 ? $"✓ {imageCount} ảnh" : "✗ Chưa có"
                    );

                    var row = dgvStudents.Rows[rowIndex];
                    string status = row.Cells[7].Value.ToString(); 
                    if (status.StartsWith("✗"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238); 
                    }
                }

                lblTotalStudents.Text = dataToRender.Count.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void CboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyCurrentFilter();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu xóa hết ô tìm kiếm -> Hiện lại theo bộ lọc Combobox
                ApplyCurrentFilter();
                return;
            }

            // Tìm kiếm trên MasterList (tìm theo Tên, Email, SĐT)
            var searchResult = _masterStudentList.Where(s =>
                (s.User.FirstName + " " + s.User.LastName).ToLower().Contains(keyword) ||
                s.User.Email.ToLower().Contains(keyword) ||
                (s.User.PhoneNumber != null && s.User.PhoneNumber.Contains(keyword))
            ).Where(s => s.User.IsActive == true).ToList();

            _ = RenderGridAsync(searchResult);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TxtSearch_TextChanged(sender, e);
        }

        // --- REFRESH ---
        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilter.SelectedIndex = 0; // Reset về tất cả
            await RefreshDataAsync(); // Tải lại từ Server
        }

        // --- DELETE ---
        // không thật sự xóa student mà chỉ deactivate user
        // đồng thời kiểm tra ràng buộc lớp học trước khi xóa
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên này?\nDữ liệu khuôn mặt và thông tin sẽ bị xóa vĩnh viễn.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int userId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["UserId"].Value);
                    int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentId"].Value);

                    // 1. Kiểm tra ràng buộc lớp học
                    var classes = _serviceHub.ClassService.getClassesByStudentId(studentId);
                    if (classes.Data != null && classes.Data.Any())
                    {
                        string classNames = string.Join(", ", classes.Data.Select(c => c.ClassName));
                        MessageHelper.ShowWarning($"Học viên đang học tại lớp: {classNames}.\nVui lòng gỡ học viên khỏi lớp trước.");
                        return;
                    }

                    // 3. Xóa học viên
                    var result = await _serviceHub.UserService.DeactivateUserAsync(userId);

                    if (result.Success)
                    {
                        MessageHelper.ShowSuccess(result.Message);

                        // 4. QUAN TRỌNG: Gọi hàm Refresh để đồng bộ lại danh sách
                        await RefreshDataAsync();
                    }
                    else
                    {
                        MessageHelper.ShowError(result.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError($"Lỗi: {ex.Message}");
                }
            }
        }

        // --- IMPORT EXCEL ---
        private async void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel để import"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int successCount = 0;
                    int errorCount = 0;

                    using (var package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        // Giả sử row 1 là header, data từ row 2
                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                // Đọc dữ liệu (Cần validate kỹ hơn ở dự án thực tế)
                                string lastName = worksheet.Cells[row, 1].Value?.ToString() ?? "";
                                string firstName = worksheet.Cells[row, 2].Value?.ToString() ?? "";
                                string email = worksheet.Cells[row, 3].Value?.ToString();

                                if (string.IsNullOrEmpty(email)) continue; // Bỏ qua dòng lỗi

                                var user = new User
                                {
                                    LastName = lastName,
                                    FirstName = firstName,
                                    Email = email,
                                    Gender = worksheet.Cells[row, 4].Value?.ToString() == "Nam",
                                    DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(worksheet.Cells[row, 5].Value)),
                                    Address = worksheet.Cells[row, 6].Value?.ToString(),
                                    PhoneNumber = worksheet.Cells[row, 7].Value?.ToString(),
                                    PasswordHashing = BCrypt.Net.BCrypt.HashPassword("123456"), // Pass mặc định
                                    IsActive = true,
                                    RoleId = 3,
                                    CreateAt = DateTime.Now
                                };

                                var student = new Student
                                {
                                    PhoneNumberOfParents = worksheet.Cells[row, 8].Value?.ToString()
                                };

                                // Gọi Service tạo User & Student
                                // Lưu ý: Cần xử lý logic tạo User trước lấy ID rồi tạo Student như code cũ của bạn
                                // Hoặc dùng hàm RegisterStudentFullAsync nếu có support transaction
                                var result = await _serviceHub.StudentService.RegisterStudentFullAsync(user, student);
                                if (result.Success)
                                { 
                                    successCount++;
                                }
                                else
                                {
                                    errorCount++;
                                }
                            }
                            catch
                            {
                                errorCount++;
                            }
                        }
                    }

                    MessageBox.Show($"Import hoàn tất!\nThành công: {successCount}\nLỗi: {errorCount}",
                        "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. QUAN TRỌNG: Load lại dữ liệu sau khi import
                    await RefreshDataAsync();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError($"Lỗi Import: {ex.Message}");
                }
            }
        }

        // --- EXPORT EXCEL ---
        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file mẫu Excel",
                FileName = "MauImportSinhVien.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Template");

                        // Header
                        string[] headers = { "Họ", "Tên", "Email", "Giới tính (Nam/Nữ)", "Ngày sinh", "Địa chỉ", "SĐT", "SĐT Phụ huynh" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = headers[i];
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // Sample Data
                        worksheet.Cells[2, 1].Value = "Nguyễn";
                        worksheet.Cells[2, 2].Value = "Văn A";
                        worksheet.Cells[2, 3].Value = "nguyenvana@example.com";
                        worksheet.Cells[2, 4].Value = "Nam";
                        worksheet.Cells[2, 5].Value = "2000-01-01";
                        worksheet.Cells[2, 6].Value = "Hà Nội";
                        worksheet.Cells[2, 7].Value = "0909123456";
                        worksheet.Cells[2, 8].Value = "0909999999";

                        worksheet.Cells.AutoFitColumns();
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));
                    }
                    MessageHelper.ShowSuccess("Tải file mẫu thành công!");
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError($"Lỗi export: {ex.Message}");
                }
            }
        }

        // --- NAVIGATION (Thêm/Sửa/Ảnh) ---

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Chuyển sang View Add
            // Lưu ý: Khi UserControl Add thực hiện xong (Back hoặc Save), nó cần cách nào đó để báo cho Parent
            // Ở mô hình hiện tại của bạn là replace controls -> new lại. 
            // Nếu bạn dùng cách new lại StudentManagement thì logic RefreshDataAsync ở Load sẽ tự chạy.

            this.Controls.Clear();
            var addControl = new AddStudentControl(_serviceHub) { Dock = DockStyle.Fill };
            this.Controls.Add(addControl);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            int userId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["UserId"].Value); // Đảm bảo cột UserId tồn tại và đúng Name

            this.Controls.Clear();
            var editControl = new EditStudent(_serviceHub, userId) { Dock = DockStyle.Fill };
            this.Controls.Add(editControl);
        }

        private void BtnAddPhoto_Click(object sender, EventArgs e) // Sự kiện cho nút Thêm ảnh/Update Face
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn sinh viên cần thêm ảnh!");
                return;
            }

            int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentId"].Value);

            this.Controls.Clear();
            // Giả sử bạn có UserControl UpdateStudentFaceControl hoặc dùng lại AddPhoto
            var addPhotoControl = new AddPhoto(_serviceHub, studentId) { Dock = DockStyle.Fill };
            this.Controls.Add(addPhotoControl);
        }

        #endregion
    }
}