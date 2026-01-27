
﻿using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IStudentService
    {
         List<Student> getAllStudentByClassId(long classId);
    
        Student? GetStudentByStudentId(int studentId);
        bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data);
        List<ClassDto>? GetClassesByStudentId(int studentId);
        List<ScheduleDto>? GetScheduleClass(int studentId);
    }
}
