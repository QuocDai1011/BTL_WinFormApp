using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> getAllStudentByClassId(long classId);
        Task<(bool Success, string Message, Student Data)> GetStudentByUserIdAsync(long userId);
    }
}
