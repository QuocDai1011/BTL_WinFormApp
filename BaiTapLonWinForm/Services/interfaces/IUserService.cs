using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.interfaces
{
    public interface IUserService
    {
        bool Login(string email, string password, out string role);
        bool RegisterStudent(string firstName, string lastName, string email, string password, string address, DateTime dob, bool gender, string phone, string parentPhone);
        Task<int> ChangePasswordAsync(string email, string newPassword, string confirm);
        User GetUserByEmail(string username);
        string GetRoleNameByRoleId(long roleId);
        User GetUserByUserId(long userId);
        User GetUserByTeacherId(long teacherId);
        Task<(bool Success, string Message, User Data)> UpdateAsync(User user);
        Task<(bool Success, string Message, User Data)> GetByIdAsync(long userId);
        Task<(bool Success, string Message, User Data)> GetByEmailAsync(string email);
        Task<(bool Success, string Message, IEnumerable<User> Data)> GetAllAsync();
        Task<(bool Success, string Message, IEnumerable<User> Data)> GetActiveUsersAsync();
        Task<(bool Success, string Message, IEnumerable<User> Data)> GetUsersByRoleAsync(byte roleId);
        Task<(bool Success, string Message, User Data)> CreateAsync(User user);
        Task<(bool Success, string Message)> DeleteAsync(long userId);
        Task<(bool Success, string Message)> DeactivateUserAsync(long userId);
        Task<(bool Success, string Message)> ActivateUserAsync(long userId);
        Task<(bool Success, string Message)> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
        Task<(bool Success, string Message)> isEmailExists(string email, long? excludeUserId = null);
    }
}
