using BaiTapLonWinForm.Models;
using ServiceStack.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<Assignment> GetAllAssignmentsByNewsfeedId(string NewsfeedId);
        Task<List<Assignment>> GetAssignmentsByClassId(int _classId);
        Task<Assignment> GetAssignmentById(string _assignmentId);
        Task CreateAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task<List<Assignment>> GetAllAssignmentsByNewsfeedList(List<Newsfeed> newsfeedList);
    }
}
