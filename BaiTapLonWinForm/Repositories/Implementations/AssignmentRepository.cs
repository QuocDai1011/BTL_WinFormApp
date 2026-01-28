using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IMongoCollection<Assignment> _collection;
        public AssignmentRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Assignment>("Assignments");
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

        public Task<List<Assignment>> GetAllAssignmentsByNewsfeedList(List<Newsfeed> newsfeedList)
        {
            return _collection.Find(a => newsfeedList.Any(nf => nf.Id == a.NewsfeedId)).ToListAsync();
        }

        public async Task<Assignment> GetAssignmentById(string _assignmentId)
        {
            return await _collection.Find(a => a.Id == _assignmentId).FirstOrDefaultAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsByClassId(int _classId)
        {
            var filter = Builders<Assignment>.Filter.Eq(a => a.ClassId, _classId);
            return await _collection.Find(filter).ToListAsync();
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
