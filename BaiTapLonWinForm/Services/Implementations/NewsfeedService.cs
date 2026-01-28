using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.MongooModels;
using BaiTapLonWinForm.Services.Interfaces;
using MongoDB.Driver;
using System.Drawing.Text;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class NewsfeedService : INewsfeedService
    {
        private readonly IMongoCollection<Newsfeed> _newsfeeds;
        public NewsfeedService()
        {
            var context = new MongoDbContext();
            _newsfeeds = context.Newsfeeds;
        }
        public List<Newsfeed> GetAllNewsfeedByClassId(int classId)
        {
            return _newsfeeds
                .Find(n => n.ClassId == classId && n.IsPublished)
                .SortBy(n => n.PostingAt)
                .ToList();
        }

        public string? GetLinkGoogleMeetByClassId(int classId)
        {
            using var context = new EnglistCenterContext();

            string? link = context.Classes
                .Where(c => c.ClassId == classId)
                .Select(c => c.OnlineMeetingLink)
                .FirstOrDefault();

            return link;
        }
        public List<Newsfeed> LoadAssignmentByNewsfeedId(string newsfeedId)
        {
            return _newsfeeds.Find(a => a.Id == newsfeedId)
                .ToList();
        }

    }
}
