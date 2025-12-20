using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IClassService
    {
        List<Class> GetAllClass(long teacherId);
        Class GetClassById(long classId);
        List<Class> UpdateClassesStatusList(List<Class> updatedClasses);
    }
}
