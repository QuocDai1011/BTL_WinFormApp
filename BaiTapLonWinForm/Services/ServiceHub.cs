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
        public IUserService UserService { get; }
        public IClassService ClassService { get; }
        public ICourseService CourseService { get; }
        public IStudentService StudentService { get; }
        public ITeacherService TeacherService { get; }
        public ISchoolDayService SchoolDayService { get; }
        public INewsfeedService NewsfeedService { get; }
        public IAssignmentService AssignmentService { get; }
        public ISubmissionService SubmissionService { get; }
        public ServiceHub(
            IUserService userService,
            IClassService classService,
            ICourseService courseService,
            IStudentService studentService,
            ITeacherService teacherService,
            ISchoolDayService schoolDayService,
            INewsfeedService newsfeedService,
            IAssignmentService assignmentService,
            ISubmissionService submissionService
            )
        {
            UserService = userService;
            ClassService = classService;
            StudentService = studentService;
            TeacherService = teacherService;
            CourseService = courseService;
            SchoolDayService = schoolDayService;
            NewsfeedService = newsfeedService;
            AssignmentService =  assignmentService;
            SubmissionService = submissionService;
        }
    }
}