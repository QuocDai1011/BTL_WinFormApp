using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;
using System;
using System.Linq;
using System.Text.RegularExpressions; // Cần thêm namespace này để dùng Regex
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class EditStudent : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _userId;

        public EventHandler CloseRequested { get; set; }
        public EditStudent(ServiceHub serviceHub, int userId)
        {
            _serviceHub = serviceHub;
            _userId = userId;
            InitializeComponent();

            SetupValidationEvents();

            initStudent();
        }

        #region initialize 
        private async void initStudent()
        {
            var student = await _serviceHub.StudentService.GetStudentByUserIdAsync(_userId);

            if (!student.Success)
            {
                MessageHelper.ShowError(student.Message);
            }
            else
            {
                var data = student.Data;
                txtFirstName.Text = data.User.FirstName;
                txtLastName.Text = data.User.LastName;
                txtEmail.Text = data.User.Email;
                txtPhoneNumberOfParent.Text = data.PhoneNumberOfParents;
                dtpDateOfBirth.Value = data.User.DateOfBirth.ToDateTime(TimeOnly.MinValue); // Fix lỗi convert DateOnly
                txtAddress.Text = data.User.Address;
                txtPhone.Text = data.User.PhoneNumber;
                cboGender.Text = data.User.Gender == true ? "Nam" : "Nữ";
            }
        }

        #endregion

        #region validation input
        private void SetupValidationEvents()
        {
            // Khi text thay đổi -> Gọi hàm check tương ứng ngay lập tức
            txtFirstName.TextChanged += (s, e) => CheckFirstName();
            txtLastName.TextChanged += (s, e) => CheckLastName();
            txtEmail.TextChanged += (s, e) => CheckEmail();
            txtPhone.TextChanged += (s, e) => CheckPhone();
            txtPhoneNumberOfParent.TextChanged += (s, e) => CheckParentPhone();
            cboGender.SelectedIndexChanged += (s, e) => CheckGender();
        }

        private bool CheckFirstName()
        {
            return ValidateInput(txtFirstName, lblErrFirstName,
                t => !string.IsNullOrWhiteSpace(t),
                "Vui lòng nhập họ.");
        }

        private bool CheckLastName()
        {
            return ValidateInput(txtLastName, lblErrLastName,
                t => !string.IsNullOrWhiteSpace(t),
                "Vui lòng nhập tên.");
        }

        private bool CheckEmail()
        {
            return ValidateInput(txtEmail, lblErrEmail,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
                "Email không hợp lệ.");
        }

        private bool CheckPhone()
        {
            return ValidateInput(txtPhone, lblErrPhone,
                t => !string.IsNullOrWhiteSpace(t) && t.All(char.IsDigit) && t.Length >= 10,
                "SĐT phải là số (tối thiểu 10 số).");
        }

        private bool CheckParentPhone()
        {
            return ValidateInput(txtPhoneNumberOfParent, lblErrParentPhone,
                t => !string.IsNullOrWhiteSpace(t) && t.All(char.IsDigit) && t.Length >= 10,
                "SĐT phụ huynh không hợp lệ.");
        }

        private bool CheckGender()
        {
            if (cboGender.SelectedItem == null)
            {
                lblErrGender.Text = "Vui lòng chọn giới tính.";
                lblErrGender.Visible = true;
                return false;
            }
            lblErrGender.Visible = false;
            return true;
        }

        private bool ValidateInput(Guna2TextBox txt, Label lbl, Func<string, bool> rule, string errMsg)
        {
            // Nếu input không thỏa mãn rule
            if (!rule(txt.Text.Trim()))
            {
                lbl.Text = errMsg;
                lbl.Visible = true; 
                return false;
            }
            lbl.Visible = false; 
            return true;
        }

        #endregion

        #region handle events
        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool isFirstNameValid = CheckFirstName();
            bool isLastNameValid = CheckLastName();
            bool isEmailValid = CheckEmail();
            bool isPhoneValid = CheckPhone();
            bool isParentPhoneValid = CheckParentPhone();
            bool isGenderValid = CheckGender();

            if (!isFirstNameValid || !isLastNameValid || !isEmailValid ||
                !isPhoneValid || !isParentPhoneValid || !isGenderValid)
            {
                return; 
            }

            var student = await _serviceHub.StudentService.GetStudentByUserIdAsync(_userId);

            if (!student.Success || student.Data == null)
            {
                MessageHelper.ShowError("Không tìm thấy thông tin học viên gốc.");
                return;
            }

            User userPayload = new User
            {
                UserId = _userId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                Address = txtAddress.Text.Trim(),
                Gender = cboGender.SelectedItem?.ToString() == "Nam",
            };

            Student updateStudent = new Student
            {
                UserId = _userId,
                StudentId = student.Data.StudentId,
                PhoneNumberOfParents = txtPhoneNumberOfParent.Text.Trim(),
                User = userPayload
            };

            var result = await _serviceHub.StudentService.UpdateStudentAsync(updateStudent);

            if (!result.Success)
            {
                MessageHelper.ShowError(result.Message);
                return;
            }

            MessageHelper.ShowSuccess("Cập nhật học viên thành công.");

            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}