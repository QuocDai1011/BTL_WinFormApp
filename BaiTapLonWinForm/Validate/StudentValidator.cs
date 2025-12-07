using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Validate
{
    public static class StudentValidator
    {
        public static (bool IsValid, string Message) Validate(Student student)
        {
            if (student == null)
                return (false, "Đối tượng học sinh không được null");

            var result = ValidateUserId(student.UserId);
            if (!result.IsValid) return result;

            result = ValidatePhoneNumberOfParents(student.PhoneNumberOfParents);
            if (!result.IsValid) return result;

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateUserId(long userId)
        {
            if (userId <= 0)
                return (false, "User ID phải lớn hơn 0");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidatePhoneNumberOfParents(string? phoneNumber)
        {
            // Phone number is optional
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return (true, string.Empty);

            if (phoneNumber.Length != 10)
                return (false, "Số điện thoại phụ huynh phải có 10 số");

            // Check if all characters are digits
            if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
                return (false, "Số điện thoại phụ huynh chỉ được chứa số");

            // Vietnam phone numbers typically start with 0
            if (!phoneNumber.StartsWith("0"))
                return (false, "Số điện thoại phụ huynh phải bắt đầu bằng số 0");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateForCreate(Student student)
        {
            if (student.StudentId != 0)
                return (false, "StudentId phải bằng 0 khi tạo mới");

            return Validate(student);
        }

        public static (bool IsValid, string Message) ValidateForUpdate(Student student)
        {
            if (student.StudentId <= 0)
                return (false, "StudentId phải lớn hơn 0 khi cập nhật");

            return Validate(student);
        }

        public static (bool CanDelete, string Message) CanDeleteStudent(Student student)
        {
            if (student == null)
                return (false, "Đối tượng học sinh không tồn tại");

            if (student.StudentClasses != null && student.StudentClasses.Any())
                return (false, "Không thể xóa học sinh đang có lớp học");

            return (true, string.Empty);
        }

        public static (bool CanEnroll, string Message) CanEnrollClass(Student student, int maxClassesPerStudent = 5)
        {
            if (student == null)
                return (false, "Đối tượng học sinh không tồn tại");

            var currentClassCount = student.StudentClasses?.Count ?? 0;
            if (currentClassCount >= maxClassesPerStudent)
                return (false, $"Học sinh đã đạt giới hạn số lớp ({currentClassCount}/{maxClassesPerStudent})");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateClassEnrollment(Student student, Class classToEnroll)
        {
            if (student == null)
                return (false, "Đối tượng học sinh không tồn tại");

            if (classToEnroll == null)
                return (false, "Đối tượng lớp học không tồn tại");

            // Check if student is already enrolled in this class
            if (student.StudentClasses != null &&
                student.StudentClasses.Any(sc => sc.ClassId == classToEnroll.ClassId))
                return (false, "Học sinh đã đăng ký lớp học này");

            return (true, string.Empty);
        }
    }
}
