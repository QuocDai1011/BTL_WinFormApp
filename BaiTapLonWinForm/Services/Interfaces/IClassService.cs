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
        Task<List<Class>> GetAllClassAsync(int teacherId);
        Class GetClassById(int classId);
        List<Class> UpdateClassesStatusList(List<Class> updatedClasses);
    }
}
