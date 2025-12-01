using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EnglishCenterDbContext _context;

        public AuthRepository(EnglishCenterDbContext context)
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
    }
}
