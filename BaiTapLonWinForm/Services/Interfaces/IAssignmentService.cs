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
        void SubmitAssignment(
            string newsfeedId,
            int studentId,
            string link);
        string GetNewsfeedIdByClassId(int classId);
        string GetStatus(string newsfeedId);
    }
}
