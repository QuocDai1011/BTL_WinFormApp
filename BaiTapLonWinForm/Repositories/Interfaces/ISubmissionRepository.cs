using BaiTapLonWinForm.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<List<Submission>> GetSubmissionsByAssignmentId(string _assignmentId);
        Task<bool> CreateSubmissionAsync(Submission submission);
    }
}
