using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class ClassSessionService : IClassSessionService
    {
        private readonly IClassSessionRepository _sessionRepo;

        public ClassSessionService(IClassSessionRepository sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        public async Task<(bool success, int sessionCount, string message)> CreateSessionsAsync(int classId)
        {
            try
            {
                int count = await _sessionRepo.CreateSessionsForClassAsync(classId);
                return (true, count, $"Đã tạo {count} buổi học thành công!");
            }
            catch (Exception ex)
            {
                return (false, 0, $"Lỗi tạo buổi học: {ex.Message}");
            }
        }

        public async Task<ClassSession> GetSessionAsync(int sessionId)
        {
            return await _sessionRepo.GetByIdAsync(sessionId);
        }

        public async Task<List<ClassSession>> GetSessionsByClassAsync(int classId)
        {
            return await _sessionRepo.GetByClassIdAsync(classId);
        }
    }
}
