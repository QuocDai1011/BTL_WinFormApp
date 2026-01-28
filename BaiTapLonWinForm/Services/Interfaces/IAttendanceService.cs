using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<(bool success, string studentName, DateTime? checkInTime, string message)> TakeAttendanceByFaceAsync(int sessionId, byte[] capturedImage);
        Task<(bool success, string message)> TakeManualAttendanceAsync(int studentId, int sessionId, bool isPresent, string note = null);
        Task<List<Attendance>> GetSessionAttendanceAsync(int sessionId);
        Task<(int present, int absent, double rate)> GetAttendanceStatsAsync(int sessionId);

        Task<ReceptionCheckInResult> CheckInAtReceptionAsync(byte[] capturedImage);

    }    
}
