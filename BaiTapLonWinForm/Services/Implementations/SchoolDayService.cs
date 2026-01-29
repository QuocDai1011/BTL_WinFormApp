using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class SchoolDayService : ISchoolDayService
    {
        private readonly ISchoolDayRepository _schoolDayRepository;
        public SchoolDayService(ISchoolDayRepository schoolDayRepository)
        {
            _schoolDayRepository = schoolDayRepository;
        }
        public List<string> GetListSchoolDaysByClassId(int classId)
        {
            var schoolDays = _schoolDayRepository.GetListSchoolDaysByClassId(classId);
            return schoolDays;
        }
    }
}
