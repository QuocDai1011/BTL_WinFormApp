using BaiTapLonWinForm.MongooModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface INewsfeedService
    {
        List<Newsfeed> GetAllNewsfeedByClassId(int classId);
    }
}
