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
        public IReceiptService ReceiptService { get; set; }
        public IClassSessionService ClassSessionService { get; }
        public IAttendanceService AttendanceService { get; }
        public ICompreFaceApiService CompreFaceApiService { get; }
        public ITeacherAttendanceService TeacherAttendanceService { get; }
        public ITeacherFaceService TeacherFaceService { get; }
        public IStudentFaceService StudentFaceService { get; }
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
            IReceiptService receiptService,
            IClassSessionService classSessionService,
            IAttendanceService attendanceService,
            ICompreFaceApiService compreFaceApiService,
            IStudentFaceService studentFaceService,
            ITeacherAttendanceService teacherAttendanceService,
            ITeacherFaceService teacherFaceService,
            INewsfeedService newsfeedService,
            IAssignmentService assignmentService,
            ISubmissionService submissionService
        )        
        {
            UserService = userService;
            ClassService = classService;
            CourseService = courseService;
            StudentService = studentService;
            TeacherService = teacherService;
            SchoolDayService = schoolDayService;
            ClassSessionService = classSessionService;
            AttendanceService = attendanceService;
            CompreFaceApiService = compreFaceApiService;
            StudentFaceService = studentFaceService;
            TeacherFaceService = teacherFaceService;
            TeacherAttendanceService = teacherAttendanceService;
            ReceiptService = receiptService;
            NewsfeedService = newsfeedService;
            AssignmentService =  assignmentService;
            SubmissionService = submissionService;
        }
    }
}

