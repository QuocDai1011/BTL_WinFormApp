using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Mongo;
using BaiTapLonWinForm.Repositories.Interfaces;
using MongoDB.Driver;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IMongoCollection<Assignment> _collection;
        private readonly IMongoCollection<Newsfeed> _newsfeedCollection;
        public AssignmentRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Assignment>("Assignments");
            _newsfeedCollection = context.Database.GetCollection<Newsfeed>("Newsfeed");
        }

        public async Task<bool> CreateAssignmentAsync(Assignment assignment)
        {
            try
            {
                await _collection.InsertOneAsync(assignment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Assignment> GetAllAssignmentsByNewsfeedId(string NewsfeedId)
        {
            var filter = Builders<Assignment>.Filter.Eq(x => x.NewsfeedId, NewsfeedId);

            return await _collection
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public List<Newsfeed> GetAssignmentByNewsfeedIdAndClassId(int classId)
        {
            return _newsfeedCollection.Find(a => a.ClassId == classId && a.Type == "assignment").ToList();
        }
        public async Task<Assignment> GetAssignmentById(string _assignmentId)
        {
            return await _collection.Find(a => a.Id == _assignmentId).FirstOrDefaultAsync();
        }

        public Assignment GetByNewsfeedAndStudent(string newsfeedId)
        {
            return _collection.Find(s => s.NewsfeedId == newsfeedId).FirstOrDefault();
        }

        public async Task<List<Assignment>> GetAssignmentsByClassId(int _classId)
        {
            var filter = Builders<Assignment>.Filter.Eq(a => a.ClassId, _classId);
            return await _collection.Find(filter).ToListAsync();
        }

        public string GetStatusAssignmentByAssignmentId(string assignmentId)
        {
            var assignment = _collection.Find(a => a.Id == assignmentId).FirstOrDefault();

            if (assignment == null) throw new MongoClientException("Không tìm thấy bài tập phù hợp");

            return assignment.Status;
        }

        public void SubmitAssignment(string newsfeedId, int studentId)
        {
            var filter = Builders<Assignment>.Filter.And(
                    Builders<Assignment>.Filter.Eq(x => x.NewsfeedId, newsfeedId));

            var content = _collection.Find(x => x.NewsfeedId == newsfeedId).FirstOrDefault();
            var update = Builders<Assignment>.Update
                .Set(x => x.Status, "Đã nộp");

            _collection.UpdateOne(filter, update);
        }

        public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
        {
            //if (assignment == null || string.IsNullOrEmpty(assignment.Id))
            //    return false;

            //var filter = Builders<Assignment>.Filter.Eq(x => x.Id, assignment.Id);

            //var update = Builders<Newsfeed>.Update
            //    .Set(x => x.ContentHtml, assignment.ContentHtml)
            //    .Set(x => x.UpdateAt, DateTime.Now);

            //var result = await _collection.UpdateOneAsync(filter, update);

            //return result.ModifiedCount > 0;
            if(assignment == null || string.IsNullOrEmpty(assignment.Id))
                return false;

            var filter = Builders<Assignment>.Filter
                .Eq(x => x.Id, assignment.Id);

            var update = Builders<Assignment>.Update
                .Set(x => x.Title, assignment.Title)
                .Set(x => x.DueTime, assignment.DueTime)
                .Set(x => x.MaxScore, assignment.MaxScore)
                .Set(x => x.AllowLateSubmission, assignment.AllowLateSubmission)
                .Set(x => x.AllowMultipleLinks, assignment.AllowMultipleLinks);
                //.Set(x => x.UpdatedAt, DateTime.Now);

            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }
    }
}
