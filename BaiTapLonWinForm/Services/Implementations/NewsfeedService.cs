using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class NewsfeedService : INewsfeedService
    {
        private readonly INewsfeedRepository _repo;

        public NewsfeedService(INewsfeedRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateNewsfeedAsync(Newsfeed news)
        {
            //Kiểm tra điều kiện ở đây nếu cần
            bool result = await _repo.CreateNewsFeedAsync(news);
            return result;
        }

        public Task<bool> DeleteNewsfeedByIdAsync(string _newsfeedId)
        {
            return _repo.DeleteNewsfeedByIdAsync(_newsfeedId);
        }

        public Task<List<Newsfeed>> GetAllNewsfeedsByUserId(long _userId)
        {
            var result = _repo.GetAllByUserIdAsync(_userId);
            return result;
        }

        public Task<Newsfeed> GetLatestNewsfeedByClassIdAsync(int _classId)
        {
            return _repo.GetLatestNewsfeedByClassIdAsync(_classId);
        }

        public Task<Newsfeed> GetNewsfeedByIdAsync(string _newsfeedId)
        {
            //Check đủ thông tin
            var result = _repo.GetNewsfeedByIdAsync(_newsfeedId);
            if (result == null)
            {
                MessageHelper.ShowError("Không tìm thấy bài đăng theo id.");
                return null;
            }
            return result;
        }

        //public Task<List<Newsfeed>> GetNewsfeedsAsync()
        //{
        //    return _repo.GetAllAsync();
        //}

        public async Task<List<Newsfeed>> GetNewsfeedsByClassIdAsync(int classId)
        {
            var allNewsfeeds = await _repo.GetAllAsync();
            var result = allNewsfeeds
                        .Where(nf => nf.ClassId == classId)
                        .ToList();
            return result;
        }

        public async Task<bool> UpdateNewsfeedAsync(Newsfeed news)
        {
            bool result = await _repo.UpdateNewsfeedAsync(news);
            return result;
        }
    }
}
