using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ITeacherService
    {
        Teacher getAllTeacherByClassId(long classId);
        Task<(bool Success, string Message, Teacher Data)> GetTeacherByIdAsync(int id);
        Task<(bool Success, string Message, Teacher Data)> UpdateTeacherAsync(Teacher teacher);
        int GetTeacherByUserId(long userId);
    }
}
