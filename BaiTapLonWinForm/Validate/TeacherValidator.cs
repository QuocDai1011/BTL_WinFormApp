using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Validate
{
    public static class TeacherValidator
    {
        public static (bool IsValid, string Message) Validate(Teacher teacher)
        {
            if (teacher == null)
                return (false, "Đối tượng giáo viên không được null");

            var result = ValidateSalary(teacher.Salary);
            if (!result.IsValid) return result;

            result = ValidateExperienceYear(teacher.ExperienceYear);
            if (!result.IsValid) return result;

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateUserId(long userId)
        {
            if (userId <= 0)
                return (false, "User ID phải lớn hơn 0");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateSalary(int? salary)
        {
            if (salary.HasValue && salary.Value < 0)
                return (false, "Lương không thể nhỏ hơn 0");

            if (salary.HasValue && salary.Value > 1000000000)
                return (false, "Lương không được vượt quá 1,000,000,000");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateExperienceYear(int? experienceYear)
        {
            if (experienceYear.HasValue && experienceYear.Value < 0)
                return (false, "Số năm kinh nghiệm không thể nhỏ hơn 0");

            if (experienceYear.HasValue && experienceYear.Value > 100)
                return (false, "Số năm kinh nghiệm không hợp lệ (tối đa 100 năm)");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateForCreate(Teacher teacher)
        {
            if (teacher.TeacherId < 0)
                return (false, "TeacherId không hợp lệ");

            return Validate(teacher);
        }

        public static (bool IsValid, string Message) ValidateForUpdate(Teacher teacher)
        {
            if (teacher.TeacherId <= 0)
                return (false, "TeacherId phải lớn hơn 0 khi cập nhật");

            return Validate(teacher);
        }

        public static (bool CanDelete, string Message) CanDeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
                return (false, "Đối tượng giáo viên không tồn tại");

            if (teacher.Classes != null && teacher.Classes.Any())
                return (false, "Không thể xóa giáo viên đang có lớp học");

            return (true, string.Empty);
        }

        public static (bool CanAssignClass, string Message) CanAssignClass(Teacher teacher, int maxClassesPerTeacher = 10)
        {
            if (teacher == null)
                return (false, "Đối tượng giáo viên không tồn tại");

            var currentClassCount = teacher.Classes?.Count ?? 0;
            if (currentClassCount >= maxClassesPerTeacher)
                return (false, $"Giáo viên đã đạt giới hạn số lớp ({currentClassCount}/{maxClassesPerTeacher})");

            return (true, string.Empty);
        }
    }
}
