using BaiTapLonWinForm.MongooModels;
using BaiTapLonWinForm.Services.Interfaces;
using MongoDB.Driver;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IMongoCollection<Assignment> _assignmentCollection;
        public AssignmentService()
        {
            var context = new MongoDbContext();
            _assignmentCollection = context.Assignment;
        }
        public string GetNewsfeedIdByClassId(int classId)
        {
            var assignment = _assignmentCollection
                .Find(a => a.ClassId == classId)
                .FirstOrDefault();

            return assignment?.NewsfeedId;
        }

        public string GetStatus(string newsfeedId)
        {
            var assignment = _assignmentCollection
                .Find(a => a.NewsfeedId == newsfeedId)
                .FirstOrDefault();

            return assignment?.Status;
        }

        public void SubmitAssignment(
            string newsfeedId,
            int studentId,
            string link)
        {
            var filter = Builders<Assignment>.Filter.And(
                Builders<Assignment>.Filter.Eq(x => x.NewsfeedId, newsfeedId),
                Builders<Assignment>.Filter.Eq(x => x.StudentId, studentId)
            );

            var assignment = _assignmentCollection.Find(filter).FirstOrDefault();
            if (assignment == null) return;

            var now = DateTime.UtcNow;
            bool isLate = assignment.DueTime < now;
            string status = isLate ? "Nộp muộn" : "Đã nộp";

            var update = Builders<Assignment>.Update
                .Set(x => x.Link, link)
                .Set(x => x.Status, status)
                .Set(x => x.IsCompleted, true)
                .Set(x => x.IsLate, isLate)
                .Set(x => x.SubmittedAt, now)
                .Set(x => x.UpdatedAt, now);

            _assignmentCollection.UpdateOne(filter, update);
        }

    }
}
