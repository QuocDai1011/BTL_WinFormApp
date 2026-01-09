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
    }
}
