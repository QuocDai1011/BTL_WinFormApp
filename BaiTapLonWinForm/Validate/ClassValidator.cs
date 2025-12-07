using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Validate
{
    public static class ClassValidator
    {
        public static (bool IsValid, string Message) Validate(Class classEntity)
        {
            if (classEntity == null)
                return (false, "Đối tượng lớp học không được null");

            var result = ValidateClassName(classEntity.ClassName);
            if (!result.IsValid) return result;

            result = ValidateTeacherId(classEntity.TeacherId);
            if (!result.IsValid) return result;

            result = ValidateStudentCapacity(classEntity.CurrentStudent, classEntity.MaxStudent);
            if (!result.IsValid) return result;

            result = ValidateDates(classEntity.StartDate, classEntity.EndDate);
            if (!result.IsValid) return result;

            result = ValidateShift(classEntity.Shift);
            if (!result.IsValid) return result;

            result = ValidateStatus(classEntity.Status);
            if (!result.IsValid) return result;

            result = ValidateOnlineMeetingLink(classEntity.OnlineMeetingLink);
            if (!result.IsValid) return result;

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateClassName(string? className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return (false, "Tên lớp học không được để trống");

            if (className.Length > 255)
                return (false, "Tên lớp học không được vượt quá 255 ký tự");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateTeacherId(int teacherId)
        {
            if (teacherId <= 0)
                return (false, "Teacher ID phải lớn hơn 0");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateStudentCapacity(int? currentStudent, int? maxStudent)
        {
            if (maxStudent.HasValue && maxStudent.Value <= 0)
                return (false, "Số học sinh tối đa phải lớn hơn 0");

            if (currentStudent.HasValue && currentStudent.Value < 0)
                return (false, "Số học sinh hiện tại không thể nhỏ hơn 0");

            if (currentStudent.HasValue && maxStudent.HasValue && currentStudent.Value > maxStudent.Value)
                return (false, "Số học sinh hiện tại không thể vượt quá số học sinh tối đa");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateDates(DateOnly startDate, DateOnly endDate)
        {
            if (startDate == default)
                return (false, "Ngày bắt đầu không hợp lệ");

            if (endDate == default)
                return (false, "Ngày kết thúc không hợp lệ");

            if (endDate <= startDate)
                return (false, "Ngày kết thúc phải sau ngày bắt đầu");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateShift(byte shift)
        {
            // Giả sử shift từ 1-3 (sáng, chiều, tối)
            if (shift < 1 || shift > 3)
                return (false, "Ca học phải từ 1 đến 3");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateStatus(int? status)
        {
            if (status.HasValue && (status.Value < 0 || status.Value > 2))
                return (false, "Trạng thái không hợp lệ (0: Chưa bắt đầu, 1: Đang diễn ra, 2: Đã kết thúc)");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateOnlineMeetingLink(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
                return (true, string.Empty);

            if (link.Length > 255)
                return (false, "Link họp online không được vượt quá 255 ký tự");

            if (!Uri.TryCreate(link, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                return (false, "Link họp online không đúng định dạng URL");

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateForCreate(Class classEntity)
        {
            if (classEntity.ClassId != 0)
                return (false, "ClassId phải bằng 0 khi tạo mới");

            return Validate(classEntity);
        }

        public static (bool IsValid, string Message) ValidateForUpdate(Class classEntity)
        {
            if (classEntity.ClassId <= 0)
                return (false, "ClassId phải lớn hơn 0 khi cập nhật");

            return Validate(classEntity);
        }

        public static (bool CanDelete, string Message) CanDeleteClass(Class classEntity)
        {
            if (classEntity == null)
                return (false, "Đối tượng lớp học không tồn tại");

            if (classEntity.CurrentStudent > 0)
                return (false, "Không thể xóa lớp học đang có học sinh");

            if (classEntity.StudentClasses != null && classEntity.StudentClasses.Any())
                return (false, "Không thể xóa lớp học có liên kết với học sinh");

            return (true, string.Empty);
        }

        public static (bool CanAdd, string Message) CanAddStudent(Class classEntity)
        {
            if (classEntity == null)
                return (false, "Đối tượng lớp học không tồn tại");

            if (!classEntity.MaxStudent.HasValue)
                return (false, "Lớp học chưa thiết lập số lượng tối đa");

            var currentCount = classEntity.CurrentStudent ?? 0;
            if (currentCount >= classEntity.MaxStudent.Value)
                return (false, $"Lớp học đã đầy ({currentCount}/{classEntity.MaxStudent.Value})");

            // Kiểm tra ngày học
            var today = DateOnly.FromDateTime(DateTime.Now);
            if (today < classEntity.StartDate)
                return (false, "Lớp học chưa bắt đầu");

            if (today > classEntity.EndDate)
                return (false, "Lớp học đã kết thúc");

            return (true, string.Empty);
        }
    }
}
