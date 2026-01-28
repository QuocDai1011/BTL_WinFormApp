using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface INewsfeedService
    {
        //Task<List<Newsfeed>> GetNewsfeedsAsync();
        Task<List<Newsfeed>> GetNewsfeedsByClassIdAsync(int classId);
        Task<bool> CreateNewsfeedAsync(Newsfeed news);
        Task<bool> UpdateNewsfeedAsync(Newsfeed news);
        Task<Newsfeed> GetNewsfeedByIdAsync(string _newsfeedId);
        Task<bool> DeleteNewsfeedByIdAsync(string _newsfeedId);
        Task<List<Newsfeed>> GetAllNewsfeedsByUserId(long _userId);
        Task<Newsfeed> GetLatestNewsfeedByClassIdAsync(int _classId);
    }
}
