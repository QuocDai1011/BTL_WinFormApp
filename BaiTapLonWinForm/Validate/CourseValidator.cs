using BaiTapLonWinForm.Models;
using CloudinaryDotNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Validate
{
    public static class CourseValidator
    {
        public static (bool IsValid, string Message) Validate(Course course)
        {
            if (course == null)
                return (false, "Đối tượng khóa học không được null");

            var result = ValidateCourseCode(course.CourseCode);
            if (!result.IsValid) return result;

            result = ValidateCourseName(course.CourseName);
            if (!result.IsValid) return result;

            result = ValidateNumberSessions(course.NumberSessions);
            if (!result.IsValid) return result;

            result = ValidateTuition(course.Tuition);
            if (!result.IsValid) return result;

            result = ValidateLevel(course.Level);
            if (!result.IsValid) return result;

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateCourseCode(string? courseCode)
        {
            if (string.IsNullOrWhiteSpace(courseCode))
                return (false, "Mã khóa học không được để trống");

            if (courseCode.Length > 20)
                return (false, "Mã khóa học không được vượt quá 20 ký tự");

            // Mã khóa học nên chỉ chứa chữ cái, số và dấu gạch ngang/gạch dưới
            if (!Regex.IsMatch(courseCode, @"^[A-Za-z0-9_-]+$"))
                return (false, "Mã khóa học chỉ được chứa chữ cái, số, dấu gạch ngang và gạch dưới");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateCourseName(string? courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                return (false, "Tên khóa học không được để trống");

            if (courseName.Length > 255)
                return (false, "Tên khóa học không được vượt quá 255 ký tự");

            if (courseName.Length < 3)
                return (false, "Tên khóa học phải có ít nhất 3 ký tự");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateNumberSessions(int numberSessions)
        {
            if (numberSessions <= 0)
                return (false, "Số buổi học phải lớn hơn 0");

            if (numberSessions > 500)
                return (false, "Số buổi học không được vượt quá 500");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateTuition(decimal tuition)
        {
            if (tuition < 0)
                return (false, "Học phí không thể nhỏ hơn 0");

            if (tuition > 999999999.999m)
                return (false, "Học phí không hợp lệ (quá giới hạn cho phép)");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateLevel(string? level)
        {
            if (string.IsNullOrWhiteSpace(level))
                return (false, "Cấp độ không được để trống");

            if (level.Length > 5)
                return (false, "Cấp độ không được vượt quá 5 ký tự");

            // Giả sử các cấp độ hợp lệ: A1, A2, B1, B2, C1, C2
            var validLevels = new[] { "A1", "A2", "B1", "B2", "C1", "C2" };
            if (!validLevels.Contains(level.ToUpper()))
                return (false, "Cấp độ không hợp lệ. Các cấp độ hợp lệ: A1, A2, B1, B2, C1, C2");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateForCreate(Course course)
        {
            if (course.CourseId != 0)
                return (false, "CourseId phải bằng 0 khi tạo mới");

            return Validate(course);
        }

        public static (bool IsValid, string Message) ValidateForUpdate(Course course)
        {
            if (course.CourseId <= 0)
                return (false, "CourseId phải lớn hơn 0 khi cập nhật");

            return Validate(course);
        }

        public static (bool CanDelete, string Message) CanDeleteCourse(Course course)
        {
            if (course == null)
                return (false, "Đối tượng khóa học không tồn tại");
            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateTuitionUpdate(decimal oldTuition, decimal newTuition)
        {
            if (newTuition < oldTuition * 0.5m)
                return (false, "Học phí mới không nên giảm quá 50% so với học phí cũ");

            if (newTuition > oldTuition * 2)
                return (false, "Học phí mới không nên tăng quá 200% so với học phí cũ");

            return (true, string.Empty);
        }
    }
}
