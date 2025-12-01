using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public bool Login(string email, string password, out string role)
        {
            role = null;
            var getUser = _authRepository.GetUserByEmail(email);
            string hash = getUser?.PasswordHashing;
            if (hash == null)
            {
                return false;
            }

            if (BCrypt.Net.BCrypt.Verify(password, hash))
            {
                //tìm role từ bảng role, xem user chứa role nào
                role = _authRepository.GetRoleNameByRoleId(getUser.RoleId);
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
            if (_authRepository.EmailExists(email))
            {
                MessageHelper.ShowInfo("Email đã tồn tại trong hệ thống!");
                return false;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            bool isAddUser = _authRepository.AddNewUser(firstName, lastName, email, hashedPassword,
                                address, dob, gender, phone, parentPhone);
            if(isAddUser == false)
            {
                MessageHelper.ShowError("Đăng ký người dùng thất bại!");
                return false;
            }
            else
            {
                //tìm userId vừa tạo
                var createdUser = _authRepository.GetUserByEmail(email);
                if(createdUser == null)
                {
                    MessageHelper.ShowInfo("Không tìm thấy người dùng vừa tạo!");
                    return false;
                }
                else
                {
                    //tạo student với userId vừa tìm được
                    bool isAddStudent = _authRepository.AddNewStudent(createdUser.UserId, parentPhone);
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
            var existUser = _authRepository.GetUserByEmail(email);
            if (existUser != null)
            {
                existUser.PasswordHashing = hashed;
                _authRepository.UpdateExistUserAsync(existUser);
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
            return _authRepository.GetUserByEmail(username);
        }

        public string GetRoleNameByRoleId(long roleId)
        {
            return _authRepository.GetRoleNameByRoleId(roleId);
        }
    }
}
