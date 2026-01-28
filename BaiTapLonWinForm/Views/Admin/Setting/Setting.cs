using BaiTapLonWinForm.CoreSystem;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Validate;
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
        private long _userId;
        private User _currentUser;
        private bool _suspendValidation = false;

        public Setting(ServiceHub serviceHub, long userId)
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
            LoadCurrentSettings();


            //dtpBirthDate.Value = DateTime.Now.AddYears(-4);
        }

        private void loadData(User user)
        {
            txtLastName.Text = user.LastName;
            txtFirstName.Text = user.FirstName;
            txtPhone.Text = user.PhoneNumber;
            txtAddress.Text = user.Address;
            txtEmail.Text = user.Email;
            dtpBirthDate.Value = user.DateOfBirth.Value.ToDateTime(new TimeOnly(0, 0));
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
            bool isAllValid = ValidateForm();

            if (!isAllValid)
            {
                MessageHelper.ShowWarning("Vui lòng nhập đầy đủ và chính xác thông tin trước khi tiếp tục.");
                return;
            }

            var updateUser = new User
            {
                UserId = _userId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                Gender = cboGender.SelectedItem?.ToString() == "Nam" ? true : false,
                RoleId = 1 // admin

            };


            var result = await _serviceHub.UserService.UpdateAsync(updateUser);

            if (result.Success)
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool isValid = vaidateUpdatePass();
            if (!isValid)
            {
                MessageHelper.ShowWarning("Vui lòng nhập đầy đủ và chính xác thông tin trước khi tiếp tục.");
                return;
            }

            ChangePassword();
        }

        private async void ChangePassword()
        {
            string newPass = txtNewPass.Text.Trim();
            var result = await _serviceHub.UserService.changePasswordAsync(_userId, newPass);

            if (result.Success)
            {
                MessageHelper.ShowSuccess("Đổi mật khẩu thành công.");
                _suspendValidation = true;

                txtOldPass.Clear();
                txtNewPass.Clear();
                txtConfirmPass.Clear();

                lblErrorOldPassword.Visible = false;
                lblErrorNewPassword.Visible = false;
                lblErrorConfirmPassword.Visible = false;

                _suspendValidation = false;
            }
            else
            {
                MessageHelper.ShowError("Đổi mật khẩu thất bại. " + result.Message);
            }


        }

        

        private void SelectComboBoxItem(ComboBox comboBox, string[] possibleValues)
        {
            foreach (string value in possibleValues)
            {
                int index = comboBox.FindStringExact(value);
                if (index != -1)
                {
                    comboBox.SelectedIndex = index;
                    return;
                }
            }

            // Nếu không tìm thấy, chọn item đầu tiên
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        private void btnSaveSystem_Click(object sender, EventArgs e)
        {
            try
            {
                //string language = cboLanguage.SelectedItem?.ToString() ?? "Vietnamese";
                string theme = cboTheme.SelectedItem?.ToString() ?? "Light";

                // Áp dụng language
                //SettingsManager.ApplyLanguage(language);

                // Áp dụng theme
                SettingsManager.ApplyTheme(theme);

                //MessageBox.Show(
                //    SettingsManager.CurrentLanguage == "vi"
                //        ? "Cài đặt đã được áp dụng thành công!"
                //        : "Settings applied successfully!",
                //    SettingsManager.CurrentLanguage == "vi" ? "Thành công" : "Success",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information
                //);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi lưu cài đặt: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadCurrentSettings()
        {
            try
            {
                // Load Language
                //string currentLang = SettingsManager.CurrentLanguage;
                //SelectComboBoxItem(cboLanguage, currentLang == "vi" ?
                //    new[] { "Tiếng Việt", "Vietnamese" } :
                //    new[] { "English" });

                // Load Theme  
                string currentTheme = SettingsManager.CurrentTheme;
                SelectComboBoxItem(cboTheme, currentTheme.ToLower() == "dark" ?
                    new[] { "Tối (Dark)", "Dark" } :
                    new[] { "Sáng (Light)", "Light" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cài đặt: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region validation input
        private bool ValidateControl<T>(
            T control,
            Label errorLabel,
            Func<T, bool> rule,
            string errorMessage
        )
        {
            if (_suspendValidation)
            {
                errorLabel.Visible = false;
                return true;
            }
            if (!rule(control))
            {
                errorLabel.Text = errorMessage;
                errorLabel.Visible = true;
                return false;
            }

            errorLabel.Visible = false;
            return true;
        }

        private void SetupValidationEvents()
        {
            txtFirstName.TextChanged += (s, e) => CheckFirstName();
            txtLastName.TextChanged += (s, e) => CheckLastName();
            txtEmail.TextChanged += (s, e) => CheckEmail();
            txtPhone.TextChanged += (s, e) => CheckPhone();
            cboGender.SelectedIndexChanged += (s, e) => CheckGender();
            dtpBirthDate.ValueChanged += (s, e) => CheckBirthDate();
            txtConfirmPass.TextChanged += (s, e) => CheckConfirmPassword();
            txtNewPass.TextChanged += (s, e) => CheckNewPassword();
            txtOldPass.TextChanged += (s, e) => CheckOldPassword();
        }

        private bool vaidateUpdatePass()
        {
            return CheckOldPassword()
            && CheckNewPassword()
            && CheckConfirmPassword();
        }
        private bool ValidateForm()
        {
            return CheckFirstName()
                & CheckLastName()
                & CheckEmail()
                & CheckPhone()
                & CheckGender()
                & CheckBirthDate();
        }

        private bool CheckOldPassword()
        {
            return ValidateControl(txtOldPass, lblErrorOldPassword,
                    c => !string.IsNullOrWhiteSpace(c.Text),
                    "Mật khẩu cũ không được để trống."
                );
        }

        private bool CheckConfirmPassword()
        {
            return ValidateControl(txtConfirmPass, lblErrorConfirmPassword,
                c =>
                {
                    string confirmPass = c.Text.Trim();
                    string newPass = txtNewPass.Text.Trim();

                    return !string.IsNullOrWhiteSpace(confirmPass)
                           && confirmPass == newPass;
                },
                "Xác nhận mật khẩu không khớp."
            );
        }


        private bool CheckNewPassword()
        {
            string newPass = txtNewPass.Text.Trim();
            return ValidateControl(txtNewPass, lblErrorNewPassword,
                    c => !string.IsNullOrWhiteSpace(c.Text) && newPass != txtOldPass.Text.Trim(),
                    "Mật khẩu mới không được để trống \n và khác mật khẩu cũ."
                );
        }
        private bool CheckFirstName()
        {
            return ValidateControl(txtFirstName, lblErrFirstName,
                c => !string.IsNullOrWhiteSpace(c.Text) &&
                     Regex.IsMatch(c.Text, @"^[\p{L}\s]+$"),
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
            return ValidateControl(txtEmail, lblErrEmail,
                c => Regex.IsMatch(c.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
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
            return ValidateControl(cboGender, lblErrGender,
                c => c.SelectedItem != null,
                "Vui lòng chọn giới tính.");
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
        private bool CheckBirthDate()
        {
            return ValidateControl(dtpBirthDate, label5, picker =>
            {
                DateTime dob = picker.Value.Date;
                DateTime today = DateTime.Today;

                if (dob > today) return false;

                int age = today.Year - dob.Year;
                if (dob > today.AddYears(-age)) age--;

                return age >= 4;
            }, "Ngày sinh không hợp lệ (lớn hơn 4 tuổi).");
        }


        #endregion



        
    }
}
