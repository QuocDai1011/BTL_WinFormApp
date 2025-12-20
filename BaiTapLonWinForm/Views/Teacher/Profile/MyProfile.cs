using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.SystemAcess.Pages.ForgetForm;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BaiTapLonWinForm.Views.Teacher.Profile
{
    public partial class MyProfile : UserControl
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        public MyProfile(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _serviceHub = serviceHub;
        }
        private async void MyProfile_LoadAsync(object sender, EventArgs e)
        {
            var teacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
            if (teacher.Success)
            {
                updateUserToUI(teacher.Data.User);
                lblExperienceYear.Text = teacher.Data.ExperienceYear.ToString();
                lblClassCount.Text = teacher.Data.Classes.Count().ToString();
            }
            else
            {
                MessageHelper.ShowError("Không tải được thông tin giáo viên! " + teacher.Message);
            }
        }
        private bool checkInfoInput()
        {
            if (string.IsNullOrWhiteSpace(txbFirstName.Text)){
                MessageHelper.ShowWarning("Vui lòng điền họ đầy đủ");
                txbFirstName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txbLastName.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền tên đầy đủ");
                txbLastName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txbGmail.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền email đầy đủ");
                txbGmail.Focus();
                return false;
            }
            else if (Validator.IsValidEmail(txbGmail.Text) == false)
            {
                MessageHelper.ShowValidationErrors("Email không hợp lệ, phải đúng định dạng example@domain.com!");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txbPhoneNumber.Text))
            {
                MessageHelper.ShowWarning("Vui lòng điền số điện thoại đầy đủ");
                txbPhoneNumber.Focus();
                return false;
            }
            else if (Validator.IsValidPhone(txbPhoneNumber.Text) == false)
            {
                MessageHelper.ShowValidationErrors("Số điện thoại không hợp lệ! Vui lòng nhập đúng định dạng số điện thoại Việt Nam.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(cbxGender.Text))
            {
                MessageHelper.ShowWarning("Vui lòng chọn giới tính");
                cbxGender.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txbAddress.Text)) {
                MessageHelper.ShowWarning("Vui lòng điền địa chỉ đầy đủ");
                txbAddress.Focus();
                return false;
            }
            //int age = DateOnly.FromDateTime(DateTime.Now).Year - dtpkBirthday.Value.Year;
            else if (Validator.IsValidAgeForTeacher(DateOnly.FromDateTime(DateTime.Now).Year - dtpkBirthday.Value.Year) == false)
            {
                int age = DateOnly.FromDateTime(DateTime.Now).Year - dtpkBirthday.Value.Year;
                MessageHelper.ShowValidationErrors("Giáo viên phải từ 18 tuổi!");
                return false;
            }
            return true;
        }
      
        private User generateUserFromUI(User existUser)
        {
            User user = new User();
            user.UserId = existUser.UserId;
            user.Email = txbGmail.Text.Trim();
            user.FirstName = txbFirstName.Text.Trim();
            user.LastName = txbLastName.Text.Trim();
            user.Address = txbAddress.Text.Trim();
            user.DateOfBirth = DateOnly.FromDateTime(dtpkBirthday.Value);
            if (cbxGender.Text.Trim() == "Nam") user.Gender = true;
            else user.Gender = false;
            user.PhoneNumber = txbPhoneNumber.Text.Trim();
            user.RoleId = existUser.RoleId;
            user.PasswordHashing = existUser.PasswordHashing;
            user.IsActive = existUser.IsActive;
            return user;
        }
        private void clearInputFields()
        {
            txbFirstName.Text = "";
            txbLastName.Text = "";
            txbGmail.Text = "";
            txbPhoneNumber.Text = "";
            txbAddress.Text = "";
            cbxGender.SelectedIndex = -1;
            dtpkBirthday.Value = DateTime.Now;
        }
        private void updateUserToUI(User existUser)
        {
            lblAddress.Text = existUser.Address;
            lblBirthday.Text = existUser.DateOfBirth.Value.ToString();
            lblEmail.Text = existUser.Email;
            lblFixEmail.Text = existUser.Email;
            lblFixName.Text = existUser.FirstName + " " + existUser.LastName;
            lblCurrentName.Text = existUser.FirstName + " " + existUser.LastName;
            txbAddress.Text = existUser.Address;
            txbFirstName.Text = existUser.FirstName;
            txbLastName.Text = existUser.LastName;
            txbGmail.Text = existUser.Email;
            txbPhoneNumber.Text = existUser.PhoneNumber;
            dtpkBirthday.Value = existUser.DateOfBirth.HasValue ? existUser.DateOfBirth.Value.ToDateTime(new TimeOnly(0, 0)) : DateTime.Now;
            cbxGender.Text = existUser.Gender == true ? "Nam" : "Nữ";
        }
        private async void btnSaveInfo_ClickAsync(object sender, EventArgs e)
        {
            //viết hàm kiểm tra các trường thông tin rỗng => bắt buộc nhập
            //check điều kiện nhập hợp lệ
            if(checkInfoInput() != false)
            {
                //Lấy userId từ biến toàn cục _teacherId
                var teacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
                //lấy thông tin từ các textbox
                User updateUser = generateUserFromUI(teacher.Data.User);
                //Lưu thông tin vào database
                if (updateUser != null)
                {
                    var result =  await _serviceHub.UserService.UpdateAsync(updateUser);
                    if (result.Success)
                    {
                        MessageHelper.ShowSuccess("Cập nhật thông tin thành công!");
                    }
                    else
                    {
                        MessageHelper.ShowError("Cập nhật thông tin thất bại! " + result.Message);
                    }
                }
                //Lấy lại thông tin user mới nhất từ database
                var updatedTeacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
                //Tạo hàm cập nhật lên giao diện chính
                clearInputFields();
                updateUserToUI(updatedTeacher.Data.User);
            }
            return;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            //Gọi lại Form ForgetPassword để đổi mật khẩu
            try
            {
                var forgetForm = new ForgetForm(_serviceHub);
                forgetForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Đã xảy ra lỗi khi mở form quên mật khẩu: ");
            }
        }
    }
}
