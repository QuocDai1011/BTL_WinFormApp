using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.SystemAcess.Pages.ForgetForm;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.Profile
{
    /// <summary>
    /// MyProfile - Quản lý thông tin cá nhân giáo viên
    /// </summary>
    public partial class MyProfile : UserControl
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        private bool _isLoading = false;

        public MyProfile(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _serviceHub = serviceHub;
        }

        #region Load Profile
        private async void MyProfile_LoadAsync(object sender, EventArgs e)
        {
            await LoadProfileAsync();
        }

        private async Task LoadProfileAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                var result = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
                
                if (!result.Success || result.Data == null)
                {
                    MessageHelper.ShowError($"Không tải được thông tin giáo viên! {result.Message}");
                    return;
                }

                UpdateUI(result.Data.User);
                lblExperienceYear.Text = result.Data.ExperienceYear.ToString();
                lblClassCount.Text = (result.Data.Classes?.Count() ?? 0).ToString();
            }
            finally
            {
                _isLoading = false;
            }
        }
        #endregion

        #region Update Profile
        private async void btnSaveInfo_ClickAsync(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (_isLoading) return;
            
            _isLoading = true;

            try
            {
                var teacherResult = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
                if (!teacherResult.Success || teacherResult.Data == null)
                {
                    MessageHelper.ShowError("Không tìm thấy thông tin giáo viên!");
                    return;
                }

                var updatedUser = BuildUserFromInput(teacherResult.Data.User);
                var updateResult = await _serviceHub.UserService.UpdateAsync(updatedUser);

                if (updateResult.Success)
                {
                    MessageHelper.ShowSuccess("Cập nhật thông tin thành công!");
                    
                    // Reload profile
                    await LoadProfileAsync();
                }
                else
                {
                    MessageHelper.ShowError($"Cập nhật thất bại! {updateResult.Message}");
                }
            }
            finally
            {
                _isLoading = false;
            }
        }
        #endregion

        #region Validation
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txbFirstName.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền họ đầy đủ");
                txbFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbLastName.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền tên đầy đủ");
                txbLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbGmail.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền email đầy đủ");
                txbGmail.Focus();
                return false;
            }

            if (!Validator.IsValidEmail(txbGmail.Text))
            {
                MessageHelper.ShowValidationErrors("Email không hợp lệ!");
                txbGmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbPhoneNumber.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền số điện thoại");
                txbPhoneNumber.Focus();
                return false;
            }

            if (!Validator.IsValidPhone(txbPhoneNumber.Text))
            {
                MessageHelper.ShowValidationErrors("Số điện thoại không hợp lệ!");
                txbPhoneNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbxGender.Text))
            {
                MessageHelper.ShowWarning("Vui lòng chọn giới tính");
                cbxGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbAddress.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền địa chỉ");
                txbAddress.Focus();
                return false;
            }

            int age = DateTime.Now.Year - dtpkBirthday.Value.Year;
            if (!Validator.IsValidAgeForTeacher(age))
            {
                MessageHelper.ShowValidationErrors("Giáo viên phải từ 18 tuổi!");
                dtpkBirthday.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region Helper Methods
        private User BuildUserFromInput(User existingUser)
        {
            return new User
            {
                UserId = existingUser.UserId,
                Email = txbGmail.Text.Trim(),
                FirstName = txbFirstName.Text.Trim(),
                LastName = txbLastName.Text.Trim(),
                Address = txbAddress.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpkBirthday.Value),
                Gender = cbxGender.Text.Trim() == "Nam",
                PhoneNumber = txbPhoneNumber.Text.Trim(),
                RoleId = existingUser.RoleId,
                PasswordHashing = existingUser.PasswordHashing,
                IsActive = existingUser.IsActive
            };
        }

        private void UpdateUI(User user)
        {
            if (user == null) return;

            // Display labels
            lblAddress.Text = user.Address ?? "";
            lblBirthday.Text = user.DateOfBirth.ToString() ?? "";
            lblEmail.Text = user.Email ?? "";
            lblFixEmail.Text = user.Email ?? "";
            lblFixName.Text = $"{user.FirstName} {user.LastName}";
            lblCurrentName.Text = $"{user.FirstName} {user.LastName}";

            // Input fields
            txbAddress.Text = user.Address ?? "";
            txbFirstName.Text = user.FirstName ?? "";
            txbLastName.Text = user.LastName ?? "";
            txbGmail.Text = user.Email ?? "";
            txbPhoneNumber.Text = user.PhoneNumber ?? "";
            dtpkBirthday.Value = user.DateOfBirth.ToDateTime(TimeOnly.MinValue);
            cbxGender.Text = (user.Gender ?? false) ? "Nam" : "Nữ";
        }
        #endregion

        #region Change Password
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                using (var forgetForm = new ForgetForm(_serviceHub))
                {
                    forgetForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi mở form đổi mật khẩu: {ex.Message}");
            }
        }
        #endregion
    }
}
