using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface INewsfeedRepository
    {
        Task<List<Newsfeed>> GetAllAsync();
        Task<List<Newsfeed>> GetAllByUserIdAsync(long id);
        Task<bool> CreateNewsFeedAsync(Newsfeed news);
        Task<Newsfeed> GetNewsfeedByIdAsync(string _newsfeedId);
        Task<bool> UpdateNewsfeedAsync(Newsfeed news);
        Task<bool> DeleteNewsfeedByIdAsync(string _newsfeedId);
        Task<Newsfeed> GetLatestNewsfeedByClassIdAsync(int _classId);
    }
}
