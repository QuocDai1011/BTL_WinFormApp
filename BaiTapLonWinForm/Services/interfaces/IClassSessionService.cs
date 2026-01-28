using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IClassSessionService
    {
        Task<(bool success, int sessionCount, string message)> CreateSessionsAsync(int classId);
        
    }
}
