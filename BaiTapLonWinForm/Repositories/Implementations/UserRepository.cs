using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly EnglishCenterDbContext _context;

        public UserRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Email == email);
        }

        public string GetRoleNameByRoleId(long roleId)
        {
            var role = _context.Roles
                .AsNoTracking()
                .FirstOrDefault(r => r.RoleId == roleId);
            return role?.RoleName;
        }
        
        public bool EmailExists(string email)
        {
            return _context.Users
                .AsNoTracking()
                .Any(u => u.Email == email);
        }
        
        public bool AddNewUser(string firstName, string lastName, string email, string password,
                                string address, DateTime dob, bool gender, string phone, string parentPhone)
        {
            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHashing = password,
                Address = address ?? "",
                DateOfBirth = DateOnly.FromDateTime(dob),
                Gender = gender,
                PhoneNumber = phone ?? "",
                IsActive = true,
                RoleId = 3
            };
            _context.Users.Add(newUser);
            int rows = _context.SaveChanges();
            return rows != 0;
        }
        
        public bool AddNewStudent(long userId, string parentPhone)
        {
            Student newStudent = new Student
            {
                UserId = userId,
                PhoneNumberOfParents = parentPhone ?? ""
            };
            _context.Students.Add(newStudent);
            int rows = _context.SaveChanges();
            return rows != 0;
        }

        public async Task UpdateExistUserAsync(User existUser)
        {
            _context.Users.Update(existUser);
            await _context.SaveChangesAsync();
        }

        public User GetUserByUserId(long userId)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.UserId == userId);
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
            user.IsActive = user.IsActive ?? true;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if (existingUser == null)
                return null;
            existingUser.Address = user.Address;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Gender = user.Gender;
            existingUser.Email = user.Email;
            existingUser.UpdateAt = DateTime.Now;
            
            user.UpdateAt = DateTime.Now;
            user.CreateAt = existingUser.CreateAt;
            // user.Email = user.Email.ToLower();
            // _context.Entry(existingUser).CurrentValues.SetValues(user);

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
            return await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.UserId == userId);
        }

        public async Task<bool> EmailExistsAsync(string email, long? excludeUserId = null)
        {
            var query = _context.Users
                .AsNoTracking()
                .Where(u => u.Email == email.ToLower());

            if (excludeUserId.HasValue)
                query = query.Where(u => u.UserId != excludeUserId.Value);

            return await query.AnyAsync();
        }

        public User GetUserByTeacherId(long teacherId)
        {
            return _context.Teachers
                .AsNoTracking()
                .Where(t => t.TeacherId == teacherId)
                .Select(t => t.User)
                .FirstOrDefault();
        }

        public async Task<bool> ChangePassword(long userId, string newPasswordHash)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if(existingUser == null)
                return false;
            
            existingUser.PasswordHashing = newPasswordHash;
            existingUser.UpdateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
