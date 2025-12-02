using BaiTapLonWinForm.Service.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services
{
    public class ServiceHub
    {
        public IClassService ClassService { get; }
        public IUserService UserService { get; }

        public ITeacherService TeacherService { get; }

        public ICourseService CourseService { get; }

        public IStudentService StudentService { get; }
        public ServiceHub(
                IClassService classService,
                IUserService userService,
                ITeacherService teacherService,
                ICourseService courseService,
                IStudentService studentService
            ) {
            ClassService = classService;
            UserService = userService;
            TeacherService = teacherService;
            CourseService = courseService;
            StudentService = studentService;

        }
    }
}
