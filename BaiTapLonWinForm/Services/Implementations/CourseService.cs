using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Course? GetCourseByClassId(long classId)
        {
            var course = _courseRepository.GetCourseByClassId(classId);
            if (course == null)
            {
                throw new Exception("Course not found for the given class ID.");
            }
            return course;
        }
    }
}
