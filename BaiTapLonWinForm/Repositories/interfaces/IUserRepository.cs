using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IUserRepository
    {
        #region feature/trung branch
        Task<User?> GetByIdAsync(long userId);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<IEnumerable<User>> GetUsersByRoleAsync(byte roleId);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(long userId);
        Task<bool> SoftDeleteAsync(long userId);
        Task<bool> ExistsAsync(long userId);
        Task<bool> EmailExistsAsync(string email, long? excludeUserId = null);
        Task<bool> ChangePassword(int userId, string newPasswordHash);
        #endregion

        #region feature/ha branch
        User GetUserByEmail(string email);
        string GetRoleNameByRoleId(long roleId);
        bool EmailExists(string email);
        bool AddNewUser(string firstName, string lastName, string email, string password,
                                string address, DateTime dob, bool gender, string phone, string parentPhone);
        bool AddNewStudent(long userId, string parentPhone);
        Task UpdateExistUserAsync(User existUser);
        User GetUserByUserId(long userId);
        User GetUserByTeacherId(long teacherId);

        #endregion  
    }
}
