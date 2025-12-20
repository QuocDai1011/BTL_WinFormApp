using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Course? GetCourseByClassId(long classId);
    }
}
