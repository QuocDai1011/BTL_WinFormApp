using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
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
    public partial class StudentFormDialog : Form
    {
        private ServiceHub _serviceHub;
        private int? _studentId;
        private Student _student;

        public StudentFormDialog(ServiceHub serviceHub, int? studentId = null)
        {
            InitializeComponent();
            _studentId = studentId;
            _serviceHub = serviceHub;

            if (_studentId.HasValue)
            {
                this.Text = "Sửa thông tin sinh viên";
                btnSave.Text = "Cập nhật";
                LoadStudentData();
            }
            else
            {
                this.Text = "Thêm sinh viên mới";
                btnSave.Text = "Thêm mới";
            }
        }

        private async void LoadStudentData()
        {
            try
            {
                // Lấy dữ liệu sinh viên từ dịch vụ
                var result = await _serviceHub.StudentService.GetStudentByIdAsync(_studentId);

                // Xử lý lỗi nếu có
                if (!result.Success)
                {
                    MessageHelper.ShowError(result.Message);
                }

                // Hiển thị dữ liệu lên form
                _student = result.Data;

                if (_student != null)
                {
                    txtLastName.Text = _student.User.LastName;
                    txtFirstName.Text = _student.User.FirstName;
                    txtEmail.Text = _student.User.Email;
                    cboGender.SelectedIndex = _student.User.Gender == true ? 0 : 1;
                    dtpDateOfBirth.Value = _student.User.DateOfBirth.HasValue
                        ? _student.User.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
                        : DateTime.Now;
                    txtAddress.Text = _student.User.Address;
                    txtPhoneNumber.Text = _student.User.PhoneNumber;
                    txtParentPhone.Text = _student.PhoneNumberOfParents;
                    chkIsActive.Checked = _student.User.IsActive ?? true;

                    // Disable email khi sửa
                    txtEmail.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput().Result) return;

            try
            {
                if (_studentId.HasValue)
                {
                    // Cập nhật
                    _student.User.FirstName = txtFirstName.Text.Trim();
                    _student.User.LastName = txtLastName.Text.Trim();
                    _student.User.Gender = cboGender.SelectedIndex == 0;
                    _student.User.DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);
                    _student.User.Address = txtAddress.Text.Trim();
                    _student.User.PhoneNumber = txtPhoneNumber.Text.Trim();
                    _student.User.IsActive = chkIsActive.Checked;
                    _student.User.UpdateAt = DateTime.Now;
                    _student.PhoneNumberOfParents = txtParentPhone.Text.Trim();

                    var result = await _serviceHub.StudentService.UpdateStudentAsync(_student);
                    if(!result.Success)
                    {
                        MessageHelper.ShowError(result.Message);
                        return;
                    }
                    MessageHelper.ShowSuccess(result.Message);
                }
                else
                {
                    // Thêm mới
                    var user = new User
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PasswordHashing = BCrypt.Net.BCrypt.HashPassword("123456"), // Mật khẩu mặc định
                        Gender = cboGender.SelectedIndex == 0,
                        DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                        Address = txtAddress.Text.Trim(),
                        PhoneNumber = txtPhoneNumber.Text.Trim(),
                        IsActive = chkIsActive.Checked,
                        CreateAt = DateTime.Now,
                        RoleId = 3 // Role Student
                    };

                    var result = await _serviceHub.UserService.CreateAsync(user);

                    if(!result.Success)
                    {
                        MessageHelper.ShowError(result.Message);
                        return;
                    }

                    var student = new Student
                    {
                        UserId = user.UserId,
                        PhoneNumberOfParents = txtParentPhone.Text.Trim()
                    };

                    var result1 = await _serviceHub.StudentService.CreateStudentAsync(student);
                    if (!result1.Success)
                    {
                        MessageHelper.ShowError(result1.Message);
                        return;
                    }
                    MessageBox.Show("Thêm sinh viên mới thành công!\nMật khẩu mặc định: 123456",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra email đã tồn tại (chỉ khi thêm mới)
            if (!_studentId.HasValue)
            {
                var result = await _serviceHub.UserService.isEmailExists(txtEmail.Text.Trim(), _studentId);
                if (result.Success)
                {
                    MessageHelper.ShowError(result.Message);
                    txtEmail.Focus();
                    return false;
                }
            }

            if (cboGender.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Vui lòng chọn giới tính");
                cboGender.Focus();
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
