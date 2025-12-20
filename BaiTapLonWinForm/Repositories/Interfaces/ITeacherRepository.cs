using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Teacher GetAllTeacherByClassId(long classId);
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> UpdateAsync(Teacher entity);
        Task<bool> ExistsAsync(int id);
        Task<bool> UserIdExistsAsync(long userId, int? excludeTeacherId = null);
    }
}
