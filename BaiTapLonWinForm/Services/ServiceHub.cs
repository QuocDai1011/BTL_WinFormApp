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
        public IClassSessionService ClassSessionService { get; }
        public IAttendanceService AttendanceService { get; }
        public ICompreFaceApiService CompreFaceApiService { get; }

        public ITeacherAttendanceService TeacherAttendanceService { get; }

        public ITeacherFaceService TeacherFaceService { get; }

        public IStudentFaceService StudentFaceService { get; set; }
        public ServiceHub(
                IClassService classService,
                IUserService userService,
                ITeacherService teacherService,
                ICourseService courseService,
                IStudentService studentService,
                IClassSessionService classSessionService,
                IAttendanceService attendanceService,
                ICompreFaceApiService compreFaceApiService,
                IStudentFaceService studentFaceService,
                ITeacherAttendanceService teacherAttendanceService,
                ITeacherFaceService teacherFaceService
            ) {
            ClassService = classService;
            UserService = userService;
            TeacherService = teacherService;
            CourseService = courseService;
            StudentService = studentService;
            ClassSessionService = classSessionService;
            AttendanceService = attendanceService;
            CompreFaceApiService = compreFaceApiService;
            StudentFaceService = studentFaceService;
            TeacherFaceService = teacherFaceService;
            TeacherAttendanceService = teacherAttendanceService;
        }
    }
}
