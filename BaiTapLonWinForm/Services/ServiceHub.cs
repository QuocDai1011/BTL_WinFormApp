using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
﻿using BaiTapLonWinForm.Services.interfaces;
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

        public IClassSessionService ClassSessionService { get; }
        public IAttendanceService AttendanceService { get; }

        public ICompreFaceApiService CompreFaceApiService { get; }

        public IStudentFaceService StudentFaceService { get; }
        public ITeacherFaceService TeacherFaceService { get; }
        public ITeacherAttendanceService TeacherAttendanceService { get; }
        public IReceiptService ReceiptService { get; }

        public ServiceHub(
            IUserService userService,
            IClassService classService,
            ICourseService courseService,
            IStudentService studentService,
            ITeacherService teacherService,
            ISchoolDayService schoolDayService,
            IClassSessionService classSessionService,
            IAttendanceService attendanceService,
            ICompreFaceApiService compreFaceApiService,
            IStudentFaceService studentFaceService,
            ITeacherFaceService teacherFaceService,
            ITeacherAttendanceService teacherAttendanceService,
            IReceiptService receiptService

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
        }
    }
}

