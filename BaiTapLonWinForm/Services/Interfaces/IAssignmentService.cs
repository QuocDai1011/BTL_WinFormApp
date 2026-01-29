using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IAssignmentService
    {
        //Task<List<Assignment>> GetAllAssignmentsByUserId(long _userId);
        Task<Assignment> GetAllAssignmentsByNewsfeedId(string NewsfeedId);
        Task<List<Assignment>> GetAssignmentsByClassId(int _classId);
        Task<Assignment> GetAssignmentById(string _assignmentId);
        Task CreateAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);

        List<Newsfeed> GetAssignmentByNewsfeedIdAndClassId(int classId);
        string GetStatusAssignmentByAssignmentId(string assignmentId);
        Assignment GetByNewsfeedAndStudent(string newsfeedId, int studentId);
        void SubmitAssignment(string newsfeedId, int studentId);
    }
}
