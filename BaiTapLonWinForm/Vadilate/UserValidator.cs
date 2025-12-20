using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Vadilate
{
    public static class UserValidator
    {
        public static (bool IsValid, string Message) ValidateUser(User user, bool isUpdate = false)
        {
            if (user == null)
                return (false, "Thông tin người dùng không hợp lệ");

            if (string.IsNullOrWhiteSpace(user.FirstName))
                return (false, "Tên không được để trống");

            if (string.IsNullOrWhiteSpace(user.LastName))
                return (false, "Họ không được để trống");

            if (string.IsNullOrWhiteSpace(user.Email))
                return (false, "Email không được để trống");

            if (!Validator.IsValidEmail(user.Email))
                return (false, "Email không hợp lệ");

            if (!isUpdate && string.IsNullOrWhiteSpace(user.PasswordHashing))
                return (false, "Mật khẩu không được để trống");

            if (user.PhoneNumber != null && !string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                if (user.PhoneNumber.Length != 10 || !user.PhoneNumber.All(char.IsDigit))
                    return (false, "Số điện thoại phải có đúng 10 chữ số");
            }

            if (user.RoleId == 0)
                return (false, "Vai trò không được để trống");

            return (true, string.Empty);
        }
    }
}
