using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ISchoolDayService
    {
        List<string> GetListSchoolDaysByClassId(int classId);
    }
}
