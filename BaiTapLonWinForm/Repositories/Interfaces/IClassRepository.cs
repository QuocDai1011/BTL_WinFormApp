using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClassesAsync(int teacherId);
        Class GetClassById(int classId);
        void UpdateClassesStatus(List<Class> updatedClasses);
    }
}
