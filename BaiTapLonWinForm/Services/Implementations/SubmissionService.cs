using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _repo;
        public SubmissionService(ISubmissionRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateSubmissionAsync(Submission submission)
        {
            bool result = await _repo.CreateSubmissionAsync(submission);
            return result;
        }

        public async Task<List<Submission>> GetSubmissionsByAssignmentId(string _assignmentId)
        {
            return await _repo.GetSubmissionsByAssignmentId(_assignmentId);
        }
    }
}
