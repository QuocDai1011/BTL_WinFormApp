using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Implementations
{
    public class NewsfeedRepository : INewsfeedRepository
    {
        private readonly IMongoCollection<Newsfeed> _collection;

        public NewsfeedRepository(BaiTapLonWinForm.Mongo.MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Newsfeed>("Newsfeed");
        }

        public async Task<bool> CreateNewsFeedAsync(Newsfeed news)
        {
            try
            {
                await _collection.InsertOneAsync(news);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Newsfeed> LoadAssignmentByNewsfeedId(string newsfeedId)
        {
            return _collection.Find(a => a.Id == newsfeedId)
                .ToList();
        }

        public List<Newsfeed> GetAllNewsfeedByClassId(int classId)
        {
            return _collection
                .Find(n => n.ClassId == classId && n.IsPublished)
                .SortBy(n => n.PostingAt)
                .ToList();
        }

        public async Task<bool> DeleteNewsfeedByIdAsync(string _newsfeedId)
        {
            return await _collection.DeleteOneAsync(nf => nf.Id.ToString() == _newsfeedId)
                .ContinueWith(task => task.Result.DeletedCount > 0);
        }

        public async Task<List<Newsfeed>> GetAllAsync()
        {
            var filter = Builders<Newsfeed>.Filter.And(
            Builders<Newsfeed>.Filter.Eq(x => x.IsPublished, true)
    );

            return await _collection
                .Find(filter)
                .SortByDescending(x => x.PostingAt)
                .ToListAsync();
        }

        public async Task<List<Newsfeed>> GetAllByUserIdAsync(long userId)
        {
            var filter = Builders<Newsfeed>.Filter.Eq(x => x.UserId, userId);

            return await _collection
                .Find(filter)
                .SortByDescending(x => x.PostingAt)
                .ToListAsync();
        }

        public async Task<Newsfeed> GetLatestNewsfeedByClassIdAsync(int _classId)
        {
            return await _collection
                .Find(nf => nf.ClassId == _classId)
                .SortByDescending(nf => nf.PostingAt)
                .FirstOrDefaultAsync();
        }

        public async Task<Newsfeed> GetNewsfeedByIdAsync(string _newsfeedId)
        {
            return await _collection
                .Find(nf => nf.Id.ToString() == _newsfeedId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateNewsfeedAsync(Newsfeed news)
        {
            if (news == null || string.IsNullOrEmpty(news.Id))
                return false;

            var filter = Builders<Newsfeed>.Filter.Eq(x => x.Id, news.Id);

            var update = Builders<Newsfeed>.Update
                .Set(x => x.ContentHtml, news.ContentHtml)
                .Set(x => x.UpdateAt, DateTime.Now);

            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }
    }
}
