using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//[Table("user", Schema = "dbo")]
namespace BaiTapLonWinForm.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public List<Class> GetAllClass(long teacherId)
        {
            return _classRepository.getAllClasses(teacherId);
        }

        public Class GetClassById(long classId)
        {
            return _classRepository.GetClassById(classId);
        }

        public List<Class> UpdateClassesStatusList(List<Class> classes)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            foreach (var cls in classes)
            {
                cls.Status =
                    today < cls.StartDate ? -1 :
                    today > cls.EndDate ? 1 : 0;
            }

            _classRepository.UpdateClassesStatus(classes);
            return classes;
        }
    }
}
