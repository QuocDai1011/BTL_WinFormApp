using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IClassSessionRepository
    {
        Task<ClassSession> AddAsync(ClassSession session);
        Task<ClassSession> GetByIdAsync(int sessionId);
        Task<List<ClassSession>> GetByClassIdAsync(int classId);

        Task DeleteByClassIdAsync(int classId);

        Task AddRangeAsync(List<ClassSession> sessions);

    }
}
