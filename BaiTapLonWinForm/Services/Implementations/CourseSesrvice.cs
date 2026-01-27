using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System.Globalization;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class CourseSesrvice : ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseSesrvice(ICourseRepository repo)
        {
            _repo = repo;
        }

        public List<CourseClassDto>? GetAllClassByCourseId(int courseId)
        {
            var classes = _repo.GetClassByCourseId(courseId);

            if (classes == null) return null;

            DateTime dt = DateTime.Now;
            DateOnly d = DateOnly.FromDateTime(dt);

            var culture = new CultureInfo("vi-VN");
            culture.NumberFormat.CurrencySymbol = "VNĐ";

            var item = classes.Select(c => new CourseClassDto
            {
                ClassID = c.ClassId,
                ClassName = c.ClassName,
                CurrentStudent = c.CurrentStudent,
                MaxStudent = c.MaxStudent,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                SchoolDay = c.SchoolDays != null && c.SchoolDays.Any()
                    ? string.Join(", ",
                        c.SchoolDays
                            .OrderBy(sd => sd.SchoolDayId)
                            .Select(sd => sd.SchoolDayId == 8
                                ? "Chủ nhật"
                                : $"Thứ {sd.SchoolDayId}")
                    )
                    : "Chưa có lịch học",
                Shift = c.Shift,
                Status = d < c.StartDate ? "Chưa khai giảng"
               : d > c.EndDate ? "Đã kết thúc"
               : "Đang học",
                TeacherName = c.Teacher.User.FirstName + " " + c.Teacher.User.LastName,
                Tuition = c.Course?.Tuition.ToString("c", culture),
            }).ToList();

            return item;
        }

        public List<CourseDto>? GetAllCourse()
        {
            var course = _repo.GetAllCourse();

            if (course == null) return null;

            return course;
        }

        public decimal GetAmount(int courseId)
        {
            return _repo.Getamount(courseId);
        }

        public void CreateReceipt(int studentId, int classId, decimal amount)
        {
            var receipt = new Receipt
            {
                StudentId = studentId,
                ClassId = classId,
                PromotionId = 1,
                TotalAmount = amount,
                PaidAmount = amount,
                Status = "Pending",
                CreateAt = DateTime.Now,
                UpdateAt = null
            };

            var receiptPayment = new ReceiptPayment
            {
                StudentId = studentId,
                ClassId = classId,
                PromotionId = receipt.PromotionId,
                PayAmount = amount,
                PaymentDate = DateOnly.FromDateTime(DateTime.Now),
                PaymentMethod = "VNPay",
                Receipt = receipt
            };

            receipt.ReceiptPayments.Add(receiptPayment);

            _repo.Add(receipt);
        }

        public bool ExistReceipt(int studentId, int classId)
        {
            return _repo.ExistReceipt(studentId, classId);
        }
    }
}
