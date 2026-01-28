using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetAllAssignmentsByNewsfeedId(string NewsfeedId);
        Task<List<Assignment>> GetAssignmentsByClassId(int _classId);
        Task<Assignment> GetAssignmentById(string _assignmentId);
        Task<bool> CreateAssignmentAsync(Assignment assignment);
        Task<bool> UpdateAssignmentAsync(Assignment assignment);
        Task<List<Assignment>> GetAllAssignmentsByNewsfeedList(List<Newsfeed> newsfeedList);
    }
}
