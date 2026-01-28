using BaiTapLonWinForm.MongooModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IAssignmentService
    {
        List<Newsfeed> GetAssignmentByNewsfeedIdAndClassId(int classId);

        string GetStatusAssignmentByAssignmentId(string assignmentId);

        Assignment GetByNewsfeedAndStudent(string newsfeedId, int studentId);

        void SubmitAssignment(string newsfeedId, int studentId, string link);
    }
}
