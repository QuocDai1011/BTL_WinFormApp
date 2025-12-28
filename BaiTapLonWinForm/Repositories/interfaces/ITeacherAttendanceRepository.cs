using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.interfaces
{
    public interface ITeacherAttendanceRepository
    {
        Task<TeacherAttendance> AddAsync(TeacherAttendance attendance);
        Task<TeacherAttendance> GetByTeacherAndSessionAsync(int teacherId, int sessionId);
        Task<List<TeacherAttendance>> GetBySessionIdAsync(int sessionId);
        Task<bool> UpdateAsync(TeacherAttendance attendance);
    }
}
