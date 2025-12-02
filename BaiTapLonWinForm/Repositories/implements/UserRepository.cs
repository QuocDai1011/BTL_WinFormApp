using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repository.implements
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(long userId)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email.ToLower());
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .OrderByDescending(u => u.CreateAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.IsActive == true)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(byte roleId)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.RoleId == roleId)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            user.CreateAt = DateTime.Now;
            user.UpdateAt = DateTime.Now;
            user.Email = user.Email.ToLower();
            user.IsActive = user.IsActive ?? true;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser == null)
                return null;

            user.UpdateAt = DateTime.Now;
            user.CreateAt = existingUser.CreateAt;
            user.Email = user.Email.ToLower();

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteAsync(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            user.IsActive = false;
            user.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(long userId)
        {
            return await _context.Users.AnyAsync(u => u.UserId == userId);
        }

        public async Task<bool> EmailExistsAsync(string email, long? excludeUserId = null)
        {
            var query = _context.Users.Where(u => u.Email == email.ToLower());

            if (excludeUserId.HasValue)
                query = query.Where(u => u.UserId != excludeUserId.Value);

            return await query.AnyAsync();
        }
    }
}
