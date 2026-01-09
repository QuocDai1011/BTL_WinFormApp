using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;
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

namespace BaiTapLonWinForm.View.Setting
{
    public partial class Setting : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private int _userId;
        private User _currentUser;
        public Setting(ServiceHub serviceHub, int userId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _userId = userId;

            this.Load += Setting_Load;

            SetupValidationEvents();

        }

        private async void Setting_Load(object? sender, EventArgs e)
        {
            var data = await _serviceHub.UserService.GetByIdAsync(_userId);

            if (!data.Success) MessageHelper.ShowError("Lỗi", data.Message);

            var currentUser = data.Data;

            _currentUser = currentUser;

            loadData(_currentUser);
        }

        private void loadData(User user)
        {
            txtLastName.Text = user.LastName;
            txtFirstName.Text = user.FirstName;
            txtPhone.Text = user.PhoneNumber;
            txtAddress.Text = user.Address;
            txtEmail.Text = user.Email;
            dtpBirthDate.Value = user.DateOfBirth.ToDateTime(new TimeOnly(0, 0));
            cboGender.Text = user.Gender.Value ? "Nam" : "Nữ";
        }

        #region handle events

        private void Logout_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn đăng xuất không?"))
            {
                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }

        private async void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            bool isAllValid = CheckFirstName() & CheckLastName() & CheckEmail() &
                              CheckPhone() & CheckGender();

            if (!isAllValid)
            {
                MessageHelper.ShowWarning("Vui lòng nhập đầy đủ và chính xác thông tin trước khi tiếp tục.");
                return;
            }


            var updateUser = new BaiTapLonWinForm.Models.User
            {
                UserId = _userId,
                FirstName = txtLastName.Text.Trim(),
                LastName = txtFirstName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                Gender = cboGender.SelectedItem?.ToString() == "Nam" ? true : false
            };


            var result =  await _serviceHub.UserService.UpdateAsync(updateUser);

            if(result.Success)
            {
                MessageHelper.ShowSuccess("Cập nhật thông tin thành công.");
                _currentUser = result.Data;
                loadData(_currentUser);
            }
            else
            {
                MessageHelper.ShowError("Cập nhật thông tin thất bại. " + result.Message);
            }
        }

        #endregion

        #region validation input
        private void SetupValidationEvents()
        {
            // Validate ngay khi gõ phím
            txtFirstName.TextChanged += (s, e) => CheckFirstName();
            txtLastName.TextChanged += (s, e) => CheckLastName();
            txtEmail.TextChanged += (s, e) => CheckEmail();
            txtPhone.TextChanged += (s, e) => CheckPhone();
            cboGender.SelectedIndexChanged += (s, e) => CheckGender();
        }

        private bool CheckFirstName()
        {
            return ValidateInput(txtFirstName, lblErrFirstName,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[\p{L}\s]+$"),
                "Họ không được để trống và không chứa số.");
        }

        private bool CheckLastName()
        {
            return ValidateInput(txtLastName, lblErrLastName,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[\p{L}\s]+$"),
                "Tên không được để trống và không chứa số.");
        }

        private bool CheckEmail()
        {
            // Check regex email
            return ValidateInput(txtEmail, lblErrEmail,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
                "Email không đúng định dạng.");
        }

        private bool CheckPhone()
        {
            // Check số và độ dài >= 10
            return ValidateInput(txtPhone, lblErrPhone,
                t => !string.IsNullOrWhiteSpace(t) && t.All(char.IsDigit) && t.Length >= 10,
                "SĐT phải là số và đủ 10 ký tự.");
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

        // Hàm Helper: Check điều kiện -> Hiện/Ẩn Label
        private bool ValidateInput(Guna2TextBox txt, Label lbl, Func<string, bool> rule, string errMsg)
        {
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
    }
}
