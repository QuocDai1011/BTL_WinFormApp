using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var existUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (existUser != null)
            {
                return existUser;
            }
            return null;
        }

        public string GetRoleNameByRoleId(long roleId)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
            return role != null ? role.RoleName : null;
        }
        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
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
            if(rows != 0) return true;
            return false;
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
            if (rows != 0) return true;
            return false;
        }

        public async Task UpdateExistUserAsync(User existUser)
        {
            _context.Users.Update(existUser);
            await _context.SaveChangesAsync();
        }

        public User GetUserByUserId(long userId)
        {
            var existUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (existUser != null)
            {
                return existUser;
            }
            return null;
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
