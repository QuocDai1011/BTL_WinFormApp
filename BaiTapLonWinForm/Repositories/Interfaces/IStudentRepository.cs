
﻿using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> getAllStudentByClassId(long classId);
        Student? GetStudentByStudentId(int studentId);

        bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data);

        List<ClassDto> GetClassesByStudenId(int studentId);

    }
}
