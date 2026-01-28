using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ITeacherAttendanceService
    {
        Task<TeacherCheckInResult> CheckInAsync(byte[] capturedImage);
        Task<Class?> FindActiveTeachingClass(int teacherId, DateTime time);

    }

    public class TeacherCheckInResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public string teacherCode { get; set; }
        public string ClassName { get; set; }
        public string ShiftName { get; set; }
        public DateTime? CheckInTime { get; set; }
        public byte[] Avatar { get; set; }
        public bool isLate { get; set; }
        public double confidence { get; set; }
    }
}
