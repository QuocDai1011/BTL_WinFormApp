using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _repo;
        public AssignmentService(IAssignmentRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAssignmentAsync(Assignment assignment)
        {
            bool result = await _repo.CreateAssignmentAsync(assignment);
            if (!result)
            {
                MessageHelper.ShowError("Không thể tạo bài tập mới.");
            }
            MessageHelper.ShowSuccess("Tạo bài tập mới thành công.");
        }

        public async Task<Assignment> GetAllAssignmentsByNewsfeedId(string NewsfeedId)
        {
            var result = await _repo.GetAllAssignmentsByNewsfeedId(NewsfeedId);
            if(result == null)
            {
                return new Assignment();
            }
            return result;
        }


        public async Task<Assignment> GetAssignmentById(string _assignmentId)
        {
            return await _repo.GetAssignmentById(_assignmentId);
        }

        public async Task<List<Assignment>> GetAssignmentsByClassId(int _classId)
        {
            return await _repo.GetAssignmentsByClassId(_classId);
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            bool result = await _repo.UpdateAssignmentAsync(assignment);
            if (result == false) MessageHelper.ShowError("Không thể cập nhật bài đăng.");
            MessageHelper.ShowSuccess("Cập nhật thành công bài đăng.");
            return;
        }
    }
}
