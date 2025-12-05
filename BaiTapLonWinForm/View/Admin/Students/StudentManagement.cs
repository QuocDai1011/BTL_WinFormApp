using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BCrypt.Net;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            _serviceHub = serviceHub;
            SetupModernUI();
        }

        private void SetupModernUI()
        {
            // Apply rounded corners to panels
            ApplyRoundedCorners(panelSearch, 10);
            ApplyRoundedCorners(panelButtons, 10);
            ApplyRoundedCorners(panelStats, 10);

            // Apply rounded corners to buttons
            foreach (Control control in panelButtons.Controls)
            {
                if (control is Button btn)
                {
                    ApplyRoundedCorners(btn, 8);
                }
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
            await LoadStudentDataAsync();
            UpdateStudentCount();
        }

        private async Task LoadStudentDataAsync()
        {
            try
            {
                dgvStudents.Columns.Clear();

                // Setup columns
                dgvStudents.Columns.Add("StudentId", "MSSV");
                dgvStudents.Columns.Add("StudentName", "Họ và tên");
                dgvStudents.Columns.Add("Email", "Email");
                dgvStudents.Columns.Add("Phone", "Số điện thoại");
                dgvStudents.Columns.Add("PhoneNumberOfParent", "Số điện thoại phụ huynh");
                dgvStudents.Columns.Add("DateOfBirth", "Ngày sinh");
                dgvStudents.Columns.Add("FaceImageCount", "Số ảnh khuôn mặt");
                dgvStudents.Columns.Add("Id", "Id");

                // Hide Id column
                dgvStudents.Columns["Id"].Visible = false;
                dgvStudents.Columns["StudentId"].Visible = false;

                // Set column widths
                dgvStudents.Columns["StudentId"].Width = 120;
                dgvStudents.Columns["StudentName"].Width = 180;
                dgvStudents.Columns["Email"].Width = 180;
                dgvStudents.Columns["Phone"].Width = 130;
                dgvStudents.Columns["PhoneNumberOfParent"].Width = 150;
                dgvStudents.Columns["DateOfBirth"].Width = 120;
                dgvStudents.Columns["FaceImageCount"].Width = 150;

                // Load data from service
                var students = await _serviceHub.StudentService.GetAllStudentsAsync();

                dgvStudents.Rows.Clear();

                foreach (var student in students.Data)
                {
                    int imageCount = await _serviceHub.StudentFaceService.GetImageCountAsync(student.StudentId);

                    dgvStudents.Rows.Add(
                        student.StudentId,
                        student.User.FirstName + " " + student.User.LastName,
                        student.User.Email,
                        student.User.PhoneNumber,
                        student.PhoneNumberOfParents, // You might want to load class name instead
                        student.User.DateOfBirth.ToString("dd/MM/yyyy"),
                        imageCount > 0 ? $"✓ {imageCount} ảnh" : "✗ Chưa có",
                        student.User.UserId
                    );
                }

                // Apply row colors based on face image status
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    string imageStatus = row.Cells["FaceImageCount"].Value?.ToString();
                    if (imageStatus != null && imageStatus.StartsWith("✗"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 243);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentCount()
        {
            lblTotalStudents.Text = dgvStudents.Rows.Count.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new AddStudentControl(_serviceHub)
            {
                Dock = DockStyle.Fill
            });
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);
                var result = await _serviceHub.StudentService.GetStudentByIdAsync(studentId);

                if (result.Data != null)
                {
                    // TODO: Open edit form with student data
                    MessageBox.Show("Chức năng sửa đang được phát triển!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên này?\n" +
                "Tất cả ảnh khuôn mặt cũng sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int studentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);

                    // Delete face images first
                    await _serviceHub.StudentFaceService.DeleteAllImagesAsync(studentId);

                    // Delete student
                    var deleteResult = await _serviceHub.StudentService.DeleteStudentAsync(studentId);

                    if (!deleteResult.Success)
                    {
                        MessageHelper.ShowError(deleteResult.Message);

                        await LoadStudentDataAsync();
                        UpdateStudentCount();
                    }
                    else
                    {
                       MessageHelper.ShowSuccess(deleteResult.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadStudentDataAsync();
            UpdateStudentCount();
            txtSearch.Clear();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                bool visible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null &&
                        cell.OwningColumn.Name != "Id" &&
                        cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        visible = true;
                        break;
                    }
                }

                row.Visible = visible;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TxtSearch_TextChanged(sender, e);
        }

        private  void BtnImport_Click(object sender, EventArgs e)
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
                    // TODO: Implement Excel import functionality
                    MessageBox.Show("Chức năng import đang được phát triển!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi import: {ex.Message}", "Lỗi",
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
                FileName = "Student_Template.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // TODO: Implement Excel export functionality
                    MessageBox.Show("Chức năng export đang được phát triển!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi export: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEdit_Click(sender, e);
            }
        }      
    }
}
