using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Teacher
{
    public partial class AddTeacher : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private Models.Teacher _teacher;
        private bool _isEditMode;

        public event EventHandler CloseRequested;
        public AddTeacher(ServiceHub serviceHub, Models.Teacher teacher = null)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            _teacher = teacher;
            _isEditMode = _teacher != null;
            LoadData();
            InitializeValidationEvents();
        }

        private void InitializeValidationEvents()
        {
            // TextChanged cho TextBox
            txtFirstName.TextChanged += (s, e) => ValidateFirstName();
            txtLastName.TextChanged += (s, e) => ValidateLastName();
            txtEmail.TextChanged += (s, e) => ValidateEmail();
            txtPhoneNumber.TextChanged += (s, e) => ValidatePhone();

            // ValueChanged cho số và ngày tháng
            nudSalary.ValueChanged += (s, e) => ValidateSalary();
            nudExperienceYear.ValueChanged += (s, e) => ValidateExperience();
            dtpDateOfBirth.ValueChanged += (s, e) => ValidateDob();

            // SelectedIndexChanged cho ComboBox
            cboGender.SelectedIndexChanged += (s, e) => ValidateGender();
        }
        private void SetError(Label label, string message)
        {
            label.Text = message;
            label.ForeColor = Color.Red;
            label.Visible = true;
        }

        private void ClearError(Label label)
        {
            label.Text = "";
            label.Visible = false;
        }

        private bool ValidateFirstName()
        {
            string input = txtFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                SetError(lblErrorFirstName, "Họ không được để trống");
                return false;
            }
            if (!Regex.IsMatch(input, @"^[\p{L}\s]+$"))
            {
                SetError(lblErrorFirstName, "Họ không được chứa số hoặc ký tự đặc biệt");
                return false;
            }
            ClearError(lblErrorFirstName);
            return true;
        }

        private bool ValidateLastName()
        {
            string input = txtLastName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                SetError(lblErrorLastName, "Tên không được để trống");
                return false;
            }
            if (!Regex.IsMatch(input, @"^[\p{L}\s]+$"))
            {
                SetError(lblErrorLastName, "Tên không được chứa số hoặc ký tự đặc biệt");
                return false;
            }
            ClearError(lblErrorLastName);
            return true;
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                SetError(lblErrorEmail, "Email không được để trống");
                return false;
            }
            // Regex check email chuẩn
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                SetError(lblErrorEmail, "Email không đúng định dạng");
                return false;
            }
            ClearError(lblErrorEmail);
            return true;
        }

        private bool ValidatePhone()
        {
            string phone = txtPhoneNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                SetError(lblErrorPhoneNumber, "Số điện thoại không được để trống");
                return false;
            }
            // Regex check số điện thoại (10-11 số)
            if (!Regex.IsMatch(phone, @"^0\d{9,10}$"))
            {
                SetError(lblErrorPhoneNumber, "SĐT phải bắt đầu bằng 0 và có 10-11 số");
                return false;
            }
            ClearError(lblErrorPhoneNumber);
            return true;
        }

        private bool ValidateDob()
        {

            var age = DateTime.Now.Year - dtpDateOfBirth.Value.Year;
            if (dtpDateOfBirth.Value.Date > DateTime.Now.AddYears(-age)) age--;

            if (age < 18)
            {
                SetError(lblErrorDob, "Giáo viên phải từ 18 tuổi trở lên");
                return false;
            }
            ClearError(lblErrorDob);
            return true;
        }

        private bool ValidateGender()
        {
            if (cboGender.SelectedIndex == -1)
            {
                SetError(lblErrorGender, "Vui lòng chọn giới tính");
                return false;
            }
            ClearError(lblErrorGender);
            return true;
        }

        private bool ValidateSalary()
        {
            if (nudSalary.Value >= 0 && nudSalary.Value <= 100000000)
            {
                ClearError(lblErrorSalary);
                return true;
            }
            SetError(lblErrorSalary, "Lương phải lớn hơn 0 và nhỏ hơn 100.000.000VNĐ");
            return false;
        }

        private bool ValidateExperience()
        {
            if(nudExperienceYear.Value >= 0 && nudExperienceYear.Value <= 50)
            {
                ClearError(lblErrorExperience);
                return true;
            }
            SetError(lblExperienceYear, "Số năm kinh nghiệm không thể quá 50 năm");
            return false;
        }

        // Hàm kiểm tra tổng hợp tất cả
        private bool ValidateAll()
        {
            bool isValid = true;
            // Dùng toán tử & (không phải &&) để chạy hết các hàm validate 
            // nhằm hiển thị lỗi cho TẤT CẢ các trường sai cùng lúc
            isValid &= ValidateFirstName();
            isValid &= ValidateLastName();
            isValid &= ValidateEmail();
            isValid &= ValidatePhone();
            isValid &= ValidateDob();
            isValid &= ValidateGender();
            isValid &= ValidateSalary();
            isValid &= ValidateExperience();
            return isValid;
        }
        private void LoadData()
        {
            ClearError(lblErrorFirstName);
            ClearError(lblErrorLastName); // LastName error
            ClearError(lblErrorEmail);
            ClearError(lblErrorPhoneNumber);
            ClearError(lblErrorDob);
            ClearError(lblErrorGender);
            ClearError(lblErrorSalary);
            ClearError(lblErrorExperience);

            if (_isEditMode)
            {
                txtFirstName.Text = _teacher.User.FirstName;
                txtLastName.Text = _teacher.User.LastName;
                txtEmail.Text = _teacher.User.Email;
                txtPhoneNumber.Text = _teacher.User.PhoneNumber;
                txtAddress.Text = _teacher.User.Address ?? "N/A";
                dtpDateOfBirth.Value = _teacher.User.DateOfBirth.ToDateTime(new TimeOnly(0, 0));
                nudSalary.Text = _teacher.Salary.HasValue ? _teacher.Salary.Value.ToString() : string.Empty;
                nudExperienceYear.Text = _teacher.ExperienceYear.HasValue ? _teacher.ExperienceYear.Value.ToString() : string.Empty;
                cboGender.Text = _teacher.User.Gender == true ? "Nam" : "Nữ";

                lblTitle.Text = "CẬP NHẬT THÔNG TIN GIẢNG VIÊN";
                btnSave.Text = "Cập nhật";
            }
            else
            {
                lblTitle.Text = "THÊM MỚI GIẢNG VIÊN";
                btnSave.Text = "thêm";

                cboGender.SelectedIndex = 0;
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageHelper.ShowWarning("Vui lòng kiểm tra lại thông tin nhập liệu.");
                return;
            }

            Models.Teacher teacher = builderData();

            if(teacher == null)
            {
                MessageHelper.ShowWarning("Không có dữ liệu để lưu");
                return;
            }


            if (_isEditMode)
            {
                var result = await _serviceHub.TeacherService.UpdateTeacherAsync(_teacher);
                if (result.Success)
                {
                    MessageHelper.ShowSuccess("Cập nhật giảng viên thành công.");
                    CloseRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageHelper.ShowError($"Cập nhật giảng viên thất bại. Lỗi: {result.Message}");
                    return;
                }
            }
            else
            {
                var result = await _serviceHub.TeacherService.CreateTeacherAsync(teacher);
                if (result.Success)
                {
                    MessageHelper.ShowSuccess("Thêm giáo viên thành công.");
                }
                else
                {
                    MessageHelper.ShowError($"Thêm giáo viên thất bại. Lỗi: {result.Message}");
                    return;
                }
            }
            clearData();

        }

        private void clearData()
        {
            txtAddress.Clear();
            txtEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            nudExperienceYear.Value = 1;
            nudSalary.Value = 100000;
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18); // Reset về tuổi hợp lệ
            // Xóa sạch thông báo lỗi
            ClearError(lblErrorFirstName);
            ClearError(lblErrorLastName);
            ClearError(lblErrorEmail);
            ClearError(lblErrorPhoneNumber);
            ClearError(lblErrorDob);
            ClearError(lblErrorGender);
            ClearError(lblErrorSalary);
        }


        private Models.Teacher builderData()
        {
            if (_isEditMode)
            {
                _teacher.Salary = (int)nudSalary.Value;
                _teacher.ExperienceYear = (int)nudExperienceYear.Value;
                _teacher.User.FirstName = txtFirstName.Text.Trim();
                _teacher.User.LastName = txtLastName.Text.Trim();
                _teacher.User.Email = txtEmail.Text.Trim();
                _teacher.User.PhoneNumber = txtPhoneNumber.Text.Trim();
                _teacher.User.Address = txtAddress.Text.Trim();
                _teacher.User.DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);

                return _teacher;
            }
            else
            {
                string passwordHasshing = BCrypt.Net.BCrypt.HashPassword("12345678");
                Models.Teacher teacher = new Models.Teacher
                {
                    Salary = (int)nudSalary.Value,
                    ExperienceYear = (int)nudExperienceYear.Value,
                    User = new Models.User
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PhoneNumber = txtPhoneNumber.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                        PasswordHashing = passwordHasshing,
                        IsActive = true,
                        RoleId = 2
                    }
                };
                return teacher;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
