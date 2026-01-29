using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetAllAssignmentsByNewsfeedId(string NewsfeedId);
        Task<List<Assignment>> GetAssignmentsByClassId(int _classId);
        Task<Assignment> GetAssignmentById(string _assignmentId);
        Task<bool> CreateAssignmentAsync(Assignment assignment);
        Task<bool> UpdateAssignmentAsync(Assignment assignment);

        List<Newsfeed> GetAssignmentByNewsfeedIdAndClassId(int classId);
        string GetStatusAssignmentByAssignmentId(string assignmentId);
        Assignment GetByNewsfeedAndStudent(string newsfeedId);
        void SubmitAssignment(string newsfeedId, int studentId);
    }
}
