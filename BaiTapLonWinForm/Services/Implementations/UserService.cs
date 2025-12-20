using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Vadilate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Login(string email, string password, out string role)
        {
            role = null;
            var getUser = _userRepository.GetUserByEmail(email);
            string hash = getUser?.PasswordHashing;
            if (hash == null)
            {
                return false;
            }

            if (BCrypt.Net.BCrypt.Verify(password, hash))
            {
                //tìm role từ bảng role, xem user chứa role nào
                role = _userRepository.GetRoleNameByRoleId(getUser.RoleId);
                if(getUser.IsActive == false)
                {
                    MessageHelper.ShowInfo("Tài khoản của bạn đã bị vô hiệu hóa. Vui lòng liên hệ quản trị viên để biết thêm chi tiết.");
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RegisterStudent(string firstName, string lastName, string email, string password,
                                string address, DateTime dob, bool gender, string phone, string parentPhone)
        {
            if (_userRepository.EmailExists(email))
            {
                MessageHelper.ShowInfo("Email đã tồn tại trong hệ thống!");
                return false;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            bool isAddUser = _userRepository.AddNewUser(firstName, lastName, email, hashedPassword,
                                address, dob, gender, phone, parentPhone);
            if(isAddUser == false)
            {
                MessageHelper.ShowError("Đăng ký người dùng thất bại!");
                return false;
            }
            else
            {
                //tìm userId vừa tạo
                var createdUser = _userRepository.GetUserByEmail(email);
                if(createdUser == null)
                {
                    MessageHelper.ShowInfo("Không tìm thấy người dùng vừa tạo!");
                    return false;
                }
                else
                {
                    //tạo student với userId vừa tìm được
                    bool isAddStudent = _userRepository.AddNewStudent(createdUser.UserId, parentPhone);
                    if (isAddStudent == false)
                    {
                        MessageHelper.ShowError("Đăng ký Student thất bại!");
                        return false;
                    }
                    else return true;
                }
            }
        }
        public async Task<int> ChangePasswordAsync(string email, string newPassword, string confirm)
        {
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirm))
            {
                MessageHelper.ShowWarning("Vui lòng nhập mật khẩu mới!");
                return 3;
            }

            if (newPassword != confirm)
            {
                MessageHelper.ShowValidationErrors("Mật khẩu nhập lại không khớp!");
                return 3;
            }

            if (string.IsNullOrEmpty(OtpStorage.CurrentEmail))
            {
                MessageHelper.ShowInfo("Không tìm thấy email đang xác thực.");
                return 1;
            }
            if (Validator.IsStrongPassword(newPassword) == false)
            {
                MessageHelper.ShowValidationErrors("Mật khẩu mới không đủ mạnh! Vui lòng đảm bảo mật khẩu có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");
                return 3;
            }
            string hashed = BCrypt.Net.BCrypt.HashPassword(newPassword);
            var existUser = _userRepository.GetUserByEmail(email);
            if (existUser != null)
            {
                existUser.PasswordHashing = hashed;
                _userRepository.UpdateExistUserAsync(existUser);
                MessageHelper.ShowSuccess("Đổi mật khẩu Student thành công!");
            }
            else
            {
                MessageHelper.ShowError("Không tìm thấy Student.");
                return 1;
            }
            OtpStorage.Clear();
            return 0;
        }

        public User GetUserByEmail(string username)
        {
            return _userRepository.GetUserByEmail(username);
        }

        public string GetRoleNameByRoleId(long roleId)
        {
            return _userRepository.GetRoleNameByRoleId(roleId);
        }

        public User GetUserByUserId(long userId)
        {
            return _userRepository.GetUserByUserId(userId);
        }
        public async Task<(bool Success, string Message, User Data)> UpdateAsync(User user)
        {
            try
            {
                // Validation
                var validationResult = UserValidator.ValidateUser(user, isUpdate: true);
                if (!validationResult.IsValid)
                    return (false, validationResult.Message, null);

                // Check user exists
                if (!await _userRepository.ExistsAsync(user.UserId))
                    return (false, "Không tìm thấy người dùng", null);

                // Check email exists (exclude current user)
                if (await _userRepository.EmailExistsAsync(user.Email, user.UserId))
                    return (false, "Email đã được sử dụng bởi người dùng khác", null);
                var updatedUser = await _userRepository.UpdateAsync(user);

                if (updatedUser == null)
                    return (false, "Không thể cập nhật người dùng", null);

                return (true, "Cập nhật người dùng thành công", updatedUser);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("UQ__user__AB6E6164") == true)
                    return (false, "Email đã được sử dụng bởi người dùng khác", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }
    }
}
