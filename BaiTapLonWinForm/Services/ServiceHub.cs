using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services
{
    public class ServiceHub
    {
        //public IStudentService StudentService { get; }
        public IUserService UserService { get; }
        public IClassService ClassService { get; }
        public ICourseService CourseService { get; }
        public IStudentService StudentService { get; }
        public ITeacherService TeacherService { get; }
        public ISchoolDayService SchoolDayService { get; }
        public ServiceHub(
            //IStudentService studentService,
            IUserService userService,
            IClassService classService,
            ICourseService courseService,
            IStudentService studentService,
            ITeacherService teacherService,
            ISchoolDayService schoolDayService
            )
        {
            //StudentService = studentService;
            UserService = userService;
            ClassService = classService;
            StudentService = studentService;
            TeacherService = teacherService;
            CourseService = courseService;
            SchoolDayService = schoolDayService;
        }
    }
}