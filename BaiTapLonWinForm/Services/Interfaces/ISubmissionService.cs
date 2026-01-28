using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ISubmissionService
    {
        Task<List<Submission>> GetSubmissionsByAssignmentId(string _assignmentId);
        Task<bool> CreateSubmissionAsync(Submission submission);
    }
}
