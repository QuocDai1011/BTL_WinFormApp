using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IAuthService
    {
        bool Login(string email, string password, out string role);
        bool RegisterStudent(string firstName, string lastName, string email, string password, string address, DateTime dob, bool gender, string phone, string parentPhone);
        Task<int> ChangePasswordAsync(string email, string newPassword, string confirm);
        User GetUserByEmail(string username);
        string GetRoleNameByRoleId(long roleId);
    }
}
