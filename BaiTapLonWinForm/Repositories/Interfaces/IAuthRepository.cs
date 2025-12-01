using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        User GetUserByEmail(string email);
        string GetRoleNameByRoleId(long roleId);
        bool EmailExists(string email);
        bool AddNewUser(string firstName, string lastName, string email, string password,
                                string address, DateTime dob, bool gender, string phone, string parentPhone);
        bool AddNewStudent(long userId, string parentPhone);
        Task UpdateExistUserAsync(User existUser);
    }
}
