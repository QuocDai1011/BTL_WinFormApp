using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface IUserRepository
    {

        User GetUserByEmail(string email);
        string GetRoleNameByRoleId(long roleId);
        bool EmailExists(string email);
        bool AddNewUser(string firstName, string lastName, string email, string password,
                                string address, DateTime dob, bool gender, string phone, string parentPhone);
        bool AddNewStudent(long userId, string parentPhone);
        Task UpdateExistUserAsync(User existUser);
        User GetUserByUserId(long userId);
        Task<User> UpdateAsync(User user);
        Task<bool> ExistsAsync(long userId);
        Task<bool> EmailExistsAsync(string email, long? excludeUserId = null);
        User GetUserByTeacherId(long teacherId);
        Task<User?> GetByIdAsync(long userId);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<IEnumerable<User>> GetUsersByRoleAsync(byte roleId);
        Task<User> CreateAsync(User user);
        
        Task<bool> DeleteAsync(long userId);
        Task<bool> SoftDeleteAsync(long userId);
    }
}
