using BaiTapLonWinForm.MongooModels;
using BaiTapLonWinForm.Services.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IMongoCollection<Newsfeed> _newsfeedCollection;
        private readonly IMongoCollection<Assignment> _assignmentCollection;
        public AssignmentService()
        {
            var contextNewsfeed = new MongoDbContext();
            var contextAssignment = new MongoDbContext();
            _newsfeedCollection = contextNewsfeed.Newsfeeds;
            _assignmentCollection = contextAssignment.Assignment;
        }
        public List<Newsfeed> GetAssignmentByNewsfeedIdAndClassId(int classId)
        {
            return _newsfeedCollection.Find(a => a.ClassId == classId && a.Type == "assignment").ToList();
        }

        public Assignment GetByNewsfeedAndStudent(string newsfeedId, int studentId)
        {
            return _assignmentCollection.Find(s => s.NewsfeedId == newsfeedId && s.StudentId == studentId).FirstOrDefault();
        }

        public string GetStatusAssignmentByAssignmentId(string assignmentId)
        {
            var assignment = _assignmentCollection.Find(a => a.Id == assignmentId).FirstOrDefault();

            if (assignment == null) throw new MongoClientException("Không tìm thấy bài tập phù hợp");

            return assignment.Status;
        }

        public void SubmitAssignment(string newsfeedId, int studentId, string link)
        {
            var filter = Builders<Assignment>.Filter.And(
                    Builders<Assignment>.Filter.Eq(x => x.NewsfeedId, newsfeedId),
                    Builders<Assignment>.Filter.Eq(x => x.StudentId, studentId));

            var content = _assignmentCollection.Find(x => x.NewsfeedId == newsfeedId && x.StudentId == studentId).FirstOrDefault();
            var update = Builders<Assignment>.Update
                .Set(x => x.Link, link)
                .Set(x => x.SubmittedAt, DateTime.UtcNow)
                .Set(x => x.Status, "Đã nộp")
                .Set(x => x.IsCompleted, true)
                .Set(x => x.IsLate, DateTime.UtcNow > content.DueTime);

            _assignmentCollection.UpdateOne(filter, update);
        }
    }
}
