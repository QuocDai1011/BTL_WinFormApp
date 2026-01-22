using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public List<ClassDto>? GetClassesByStudentId(int studentId)
        {
            return _repo.GetClassesByStudenId(studentId) ?? new List<ClassDto>();
        }

        public Student? GetStudentByStudentId(int studentId)
        {
            var student = _repo.GetStudentByStudentId(studentId);
            if (student == null) return null;
            return student;
        }

        public bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data)
        {
            var student = _repo.GetStudentByStudentId(studentId);
            if (student == null)
                throw new Exception("Không tìm thấy sinh viên");

            // Validate chung
            ValidateString(data.FirstName, "FirstName");
            ValidateString(data.LastName, "LastName");
            ValidateString(data.Email, "Email");
            ValidateString(data.Address, "Address");
            ValidateString(data.PhoneNumber, "PhoneNumber");
            ValidateString(data.PhoneNumberOfParents, "PhoneNumberOfParents");

            if (data.Gender == null)
                throw new Exception("Gender không được để trống");

            // Trim toàn bộ string
            data.FirstName = data.FirstName.Trim();
            data.LastName = data.LastName.Trim();
            data.Email = data.Email.Trim();
            data.Address = data.Address.Trim();
            data.PhoneNumber = data.PhoneNumber.Trim();
            data.PhoneNumberOfParents = data.PhoneNumberOfParents.Trim();

            if (!RegexUtilities.IsValidEmail(data.Email))
                throw new Exception("Email không hợp lệ");

            if (!RegexUtilities.IsValidPhone(data.PhoneNumber))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!RegexUtilities.IsValidPhone(data.PhoneNumberOfParents))
                throw new Exception("Số điện thoại phụ huynh không hợp lệ");

            if (data.PhoneNumber == data.PhoneNumberOfParents) return false;

            if (data.DateOfBirth == default)
                throw new Exception("DateOfBirth không được để trống");

            return _repo.UpdateStudentByStudentId(studentId, data);
        }

        private void ValidateString(string? str, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new Exception($"{fieldName} không được để trống");
        }
    }
}
