using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Course? GetCourseByClassId(long classId)
        {
            var course = _courseRepository.GetCourseByClassId(classId);
            if (course == null)
            {
                throw new Exception("Course not found for the given class ID.");
            }
            return course;
        }

        public List<CourseClassDto>? GetAllClassByCourseId(int courseId)
        {
            var classes = _courseRepository.GetClassByCourseId(courseId);

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
            var course = _courseRepository.GetAllCourse();

            if (course == null) return null;

            return course;
        }

        public decimal GetAmount(int courseId)
        {
            return _courseRepository.Getamount(courseId);
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
                PaymentMethod = "VietQR Transfer",
                Receipt = receipt
            };

            receipt.ReceiptPayments.Add(receiptPayment);

            _courseRepository.Add(receipt);
        }

        public bool ExistReceipt(int studentId, int classId)
        {
            if (_courseRepository.ExistReceipt(studentId, classId))
            {
                return false;
            }

            return true;
        }
    }
}
