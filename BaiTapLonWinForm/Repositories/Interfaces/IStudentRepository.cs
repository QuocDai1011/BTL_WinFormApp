using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Student? GetStudentByStudentId(int studentId);
        bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data);
        List<ClassDto> GetClassesByStudenId(int studentId);
        List<ScheduleDto> GetScheduleClass(int studentId);
    }
}
