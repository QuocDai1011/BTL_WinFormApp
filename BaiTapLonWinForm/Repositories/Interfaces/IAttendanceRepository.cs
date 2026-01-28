using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> AddAsync(Attendance attendance);
        Task<Attendance> GetByStudentAndSessionAsync(int studentId, int sessionId);
        Task<List<Attendance>> GetBySessionIdAsync(int sessionId);
        Task<bool> UpdateAsync(Attendance attendance);
        Task<int> CountPresentBySessionAsync(int sessionId);
        Task<int> CountAbsentBySessionAsync(int sessionId);
    }
}
