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
        List<Class>getAllClasses(long teacherId);
        Class GetClassById(long classId);
        void UpdateClassesStatus(List<Class> updatedClasses);
    }
}
