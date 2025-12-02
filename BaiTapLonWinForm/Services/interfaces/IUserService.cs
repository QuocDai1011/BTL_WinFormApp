using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Service.interfaces
{
    public interface IUserService
    {
        Task<(bool Success, string Message, User Data)> GetByIdAsync(long userId);
        Task<(bool Success, string Message, User Data)> GetByEmailAsync(string email);
        Task<(bool Success, string Message, IEnumerable<User> Data)> GetAllAsync();
        Task<(bool Success, string Message, IEnumerable<User> Data)> GetActiveUsersAsync();
        Task<(bool Success, string Message, IEnumerable<User> Data)> GetUsersByRoleAsync(byte roleId);
        Task<(bool Success, string Message, User Data)> CreateAsync(User user);
        Task<(bool Success, string Message, User Data)> UpdateAsync(User user);
        Task<(bool Success, string Message)> DeleteAsync(long userId);
        Task<(bool Success, string Message)> DeactivateUserAsync(long userId);
        Task<(bool Success, string Message)> ActivateUserAsync(long userId);
        Task<(bool Success, string Message)> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
    
        Task<(bool Success, string Message)> isEmailExists(string email, long? excludeUserId = null);
    }
}
