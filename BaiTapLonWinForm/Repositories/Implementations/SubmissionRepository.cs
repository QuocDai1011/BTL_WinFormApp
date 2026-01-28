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
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly IMongoCollection<Submission> _collection;
        public SubmissionRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Submission>("Submissions");
        }

        public async Task<bool> CreateSubmissionAsync(Submission submission)
        {
            try
            {
                await _collection.InsertOneAsync(submission);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Submission>> GetSubmissionsByAssignmentId(string _assignmentId)
        {
            var filter = Builders<Submission>.Filter.Eq(a => a.AssignmentId, _assignmentId);
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
