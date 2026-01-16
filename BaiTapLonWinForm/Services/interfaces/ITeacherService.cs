using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.interfaces
{
    public interface ITeacherService
    {
        Teacher getAllTeacherByClassId(long classId);
        Task<(bool Success, string Message, Teacher Data)> GetTeacherByIdAsync(int id);
        Task<(bool Success, string Message, Teacher Data)> UpdateTeacherAsync(Teacher teacher);
        int GetTeacherByUserId(long userId);
        Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetAllTeachersAsync();
        
        Task<(bool Success, string Message, Teacher Data)> GetTeacherByUserIdAsync(long userId);
        Task<(bool Success, string Message)> CreateTeacherAsync(Models.User user, Teacher teacher, List<byte[]> faceImages);
        
        Task<(bool Success, string Message)> DeleteTeacherAsync(int id);
        Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetTeachersWithClassesAsync();
        Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetTeachersByExperienceAsync(int minYears, int maxYears);
        Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetAvailableTeachersAsync();
        Task<(bool Success, string Message)> CanAssignClassAsync(int teacherId);
        Task<(bool Success, string Message, int Data)> GetClassCountAsync(int teacherId);

        Task<(bool IsValid, string Message)> ValidateTeacherUserRelationshipAsync(int teacherId, long userId);
    }
}
