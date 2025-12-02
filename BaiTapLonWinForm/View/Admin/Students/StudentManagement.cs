using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class StudentManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;

        public StudentManagement(ServiceHub serviceHub)
        {
            InitializeComponent();
            LoadStudents();
            _serviceHub = serviceHub;
        }

        private async void LoadStudents()
        {
            try
            {
                // lấy dữ liệu sinh viên từ dịch vụ
                var result = await _serviceHub.StudentService.GetAllStudentsAsync();

                // kiểm tra trạng thái trả về
                if (!result.Success)
                {
                   MessageHelper.ShowError(result.Message);
                    return;
                }
                MessageHelper.ShowSuccess(result.Message);

                // map dữ liệu để hiển thị trong DataGridView
                var students = result.Data.Select(s =>
                new
                {
                    s.StudentId,
                    s.UserId,
                    HoTen = s.User.LastName + " " + s.User.FirstName,
                    Email = s.User.Email,
                    GioiTinh = s.User.Gender == true ? "Nam" : "Nữ",
                    NgaySinh = s.User.DateOfBirth,
                    DiaChi = s.User.Address,
                    SoDienThoai = s.User.PhoneNumber,
                    SDTPhuHuynh = s.PhoneNumberOfParents,
                    TrangThai = s.User.IsActive == true ? "Hoạt động" : "Không hoạt động",
                }).ToList();

                dgvStudents.DataSource = result.Data;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvStudents.Columns.Count == 0) return;

            dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
            dgvStudents.Columns["StudentId"].Width = 80;
            dgvStudents.Columns["UserId"].Visible = false;
            dgvStudents.Columns["HoTen"].HeaderText = "Họ và Tên";
            dgvStudents.Columns["HoTen"].Width = 150;
            dgvStudents.Columns["Email"].HeaderText = "Email";
            dgvStudents.Columns["Email"].Width = 180;
            dgvStudents.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvStudents.Columns["GioiTinh"].Width = 80;
            dgvStudents.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvStudents.Columns["NgaySinh"].Width = 100;
            dgvStudents.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvStudents.Columns["SoDienThoai"].HeaderText = "SĐT";
            dgvStudents.Columns["SoDienThoai"].Width = 100;
            dgvStudents.Columns["SDTPhuHuynh"].HeaderText = "SĐT Phụ huynh";
            dgvStudents.Columns["SDTPhuHuynh"].Width = 110;
            dgvStudents.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvStudents.Columns["TrangThai"].Width = 110;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var formAdd = new StudentFormDialog(_serviceHub);
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                LoadStudents();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["StudentId"].Value);
            var formEdit = new StudentFormDialog(_serviceHub,studentId);
            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                LoadStudents();
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var isConfirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (isConfirm == DialogResult.Yes)
            {
                try
                {
                    int studentId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["StudentId"].Value);
                    
                    var result = await _serviceHub.StudentService.DeleteStudentAsync(studentId);


                    // kiểm tra trạng thái trả về
                    if (!result.Success)
                    {
                        MessageHelper.ShowError(result.Message);
                        return;
                    }

                    // hiển thị thông báo thành công
                    MessageHelper.ShowSuccess(result.Message);

                    // tải lại danh sách sinh viên
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStudents();
        }

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

                    using (var package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        int imported = 0;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                var user = new User
                                {
                                    FirstName = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                                    LastName = worksheet.Cells[row, 1].Value?.ToString() ?? "",
                                    Email = worksheet.Cells[row, 3].Value?.ToString() ?? "",
                                    PasswordHashing = BCrypt.Net.BCrypt.HashPassword("123456"),
                                    Gender = worksheet.Cells[row, 4].Value?.ToString() == "Nam",
                                    DateOfBirth = DateOnly.FromDateTime(
                                        Convert.ToDateTime(worksheet.Cells[row, 5].Value)),
                                    Address = worksheet.Cells[row, 6].Value?.ToString(),
                                    PhoneNumber = worksheet.Cells[row, 7].Value?.ToString(),
                                    IsActive = true,
                                    CreateAt = DateTime.Now,
                                    RoleId = 3 // Role Student
                                };

                                // tạo user
                                var resultUser = await _serviceHub.UserService.CreateAsync(user);

                                // nếu xảy ra lỗi return ngay lập tức
                                if (!resultUser.Success)
                                {
                                    MessageHelper.ShowError(resultUser.Message);
                                    return;
                                }

                                var student = new Student
                                {
                                    UserId = user.UserId,
                                    PhoneNumberOfParents = worksheet.Cells[row, 8].Value?.ToString()
                                };

                                // tạo student
                                var resultStudent = await _serviceHub.StudentService.CreateStudentAsync(student);

                                // nếu xảy ra lỗi return ngay lập tức
                                if (!resultStudent.Success)
                                {
                                    MessageHelper.ShowError(resultStudent.Message);
                                    return;
                                }

                                imported++;
                            }
                            catch (Exception ex)
                            {
                                MessageHelper.ShowError($"Lỗi tại dòng {row}: {ex.Message}");
                            }
                        }

                        MessageBox.Show($"Import thành công {imported} sinh viên!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi import: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                        var worksheet = package.Workbook.Worksheets.Add("DanhSachSinhVien");

                        // Header
                        worksheet.Cells[1, 1].Value = "Họ";
                        worksheet.Cells[1, 2].Value = "Tên";
                        worksheet.Cells[1, 3].Value = "Email";
                        worksheet.Cells[1, 4].Value = "Giới tính";
                        worksheet.Cells[1, 5].Value = "Ngày sinh";
                        worksheet.Cells[1, 6].Value = "Địa chỉ";
                        worksheet.Cells[1, 7].Value = "Số điện thoại";
                        worksheet.Cells[1, 8].Value = "SĐT Phụ huynh";

                        // Style header
                        using (var range = worksheet.Cells[1, 1, 1, 8])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        // Dữ liệu mẫu
                        worksheet.Cells[2, 1].Value = "Nguyễn Văn";
                        worksheet.Cells[2, 2].Value = "A";
                        worksheet.Cells[2, 3].Value = "nguyenvana@example.com";
                        worksheet.Cells[2, 4].Value = "Nam";
                        worksheet.Cells[2, 5].Value = "01/01/2000";
                        worksheet.Cells[2, 6].Value = "Hà Nội";
                        worksheet.Cells[2, 7].Value = "0123456789";
                        worksheet.Cells[2, 8].Value = "0987654321";

                        worksheet.Cells.AutoFitColumns();
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));
                    }

                    MessageBox.Show("Tải file mẫu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo file: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();
                var result = await _serviceHub.StudentService.GetAllStudentsAsync();

                var students = result.Data
                    .Where(s => s.User.FirstName.ToLower().Contains(searchText) ||
                               s.User.LastName.ToLower().Contains(searchText) ||
                               s.User.Email.ToLower().Contains(searchText) ||
                               s.StudentId.ToString().Contains(searchText))
                    .Select(s => new
                    {
                        s.StudentId,
                        s.UserId,
                        HoTen = s.User.LastName + " " + s.User.FirstName,
                        Email = s.User.Email,
                        GioiTinh = s.User.Gender == true ? "Nam" : "Nữ",
                        NgaySinh = s.User.DateOfBirth,
                        DiaChi = s.User.Address,
                        SoDienThoai = s.User.PhoneNumber,
                        SDTPhuHuynh = s.PhoneNumberOfParents,
                        TrangThai = s.User.IsActive == true ? "Hoạt động" : "Không hoạt động"
                    })
                    .ToList();

                dgvStudents.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
