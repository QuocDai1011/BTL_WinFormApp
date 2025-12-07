using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Test // Hoặc namespace Test tùy bạn chọn
{
    public class TestDataSeeder
    {
        private readonly ServiceHub _serviceHub;
        private readonly AppDbContext _context;

        public TestDataSeeder(ServiceHub serviceHub, AppDbContext context)
        {
            _serviceHub = serviceHub;
            _context = context;
        }

        public async Task SeedAsync()
        {
            try
            {
                // =========================================================================
                // BƯỚC 1: TẠO USER & STUDENT (Logic kiểm tra tồn tại)
                // =========================================================================
                string email = "test.student@example.com";
                int studentId = 0;

                var userCheck = await _serviceHub.UserService.GetByEmailAsync(email);

                if (!userCheck.Success)
                {
                    // Tạo User mới (Vẫn dùng Service để tận dụng hàm Hash Password)
                    var newUser = new User
                    {
                        FirstName = "Test",
                        LastName = "Student",
                        Email = email,
                        PasswordHashing = "123456",
                        PhoneNumber = "0909000999",
                        Gender = true,
                        DateOfBirth = new DateOnly(2000, 1, 1),
                        RoleId = 3, // Role Student
                        IsActive = true,
                        Address = "Test Address"
                    };
                    var userRes = await _serviceHub.UserService.CreateAsync(newUser);

                    // Tạo Student mới (Dùng Repo hoặc Service)
                    var newStudent = new Student { UserId = userRes.Data.UserId, PhoneNumberOfParents = "0912345678" };
                    // Dùng SQL Raw hoặc Repo để tạo nhanh Student, tránh logic phức tạp
                    _context.Students.Add(newStudent);
                    await _context.SaveChangesAsync();

                    studentId = newStudent.StudentId;
                }
                else
                {
                    var s = await _serviceHub.StudentService.GetStudentByUserIdAsync(userCheck.Data.UserId);
                    studentId = s.Data.StudentId;
                }

                // =========================================================================
                // BƯỚC 2: NẠP ẢNH MẪU (SỬ DỤNG SQL RAW + API)
                // =========================================================================
                await SeedFaceImagesRawAsync(studentId);

                // =========================================================================
                // BƯỚC 3: TẠO GIÁO VIÊN MẪU (SQL RAW)
                // =========================================================================
                int teacherId = await EnsureTestTeacherExist();

                // =========================================================================
                // BƯỚC 4: TẠO 6 LỚP + BUỔI HỌC HÔM NAY (SQL RAW + NOCHECK CONSTRAINT)
                // =========================================================================
                var today = DateTime.Now.ToString("yyyy-MM-dd");

                for (int shift = 1; shift <= 6; shift++)
                {
                    await CreateClassSessionRawSql(studentId, teacherId, shift, today);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi Seed Data: {ex.Message}");
            }
        }

        // --- HÀM MỚI: Nạp ảnh dùng SQL Raw ---
        private async Task SeedFaceImagesRawAsync(int studentId)
        {
            // 1. Kiểm tra thư mục ảnh mẫu
            string samplePath = Path.Combine(Application.StartupPath, "SampleFaces");
            if (!Directory.Exists(samplePath))
            {
                // Log ra để biết là không tìm thấy thư mục
                Console.WriteLine($"[WARNING] Không tìm thấy thư mục ảnh mẫu tại: {samplePath}");
                return;
            }

            // 2. Kiểm tra trong DB xem sinh viên này đã có ảnh chưa (Dùng SQL đếm cho nhanh)
            // Lưu ý: Kết nối EF Core có thể đang bận, nên dùng context riêng hoặc await cẩn thận
            // Ở đây ta dùng LINQ đơn giản vì nó cũng dịch ra SQL
            int count = await _context.StudentFaceImages.CountAsync(f => f.StudentId == studentId);

            if (count < 5) // Nếu chưa đủ 5 ảnh thì nạp thêm
            {
                var files = Directory.GetFiles(samplePath, "*.*")
                                     .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".jpeg"))
                                     .Take(10) // Lấy tối đa 10 ảnh
                                     .ToList();

                if (files.Count == 0) return;

                // Tạo thư mục lưu trữ thật: bin/Debug/.../FaceImages/{StudentId}
                string targetFolder = Path.Combine("FaceImages", studentId.ToString());
                if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);

                foreach (var file in files)
                {
                    byte[] imageBytes = await File.ReadAllBytesAsync(file);

                    // A. GỌI API COMPREFACE (BẮT BUỘC)
                    // Nếu không gọi cái này, AI sẽ không nhận diện được dù DB có dữ liệu
                    var apiResult = await _serviceHub.CompreFaceApiService.AddFaceAsync(studentId, imageBytes);

                    if (apiResult.success)
                    {
                        // B. LƯU FILE XUỐNG Ổ CỨNG
                        string fileName = $"{Guid.NewGuid()}.jpg";
                        string destPath = Path.Combine(targetFolder, fileName);
                        await File.WriteAllBytesAsync(destPath, imageBytes);

                        // C. INSERT VÀO DB BẰNG ENTITY FRAMEWORK (AN TOÀN HƠN)
                        // EF sẽ tự động map đúng tên bảng và xử lý ngày tháng
                        var newFaceImage = new StudentFaceImage
                        {
                            StudentId = studentId,
                            ImagePath = destPath, // Lưu đường dẫn tuyệt đối hoặc tương đối tùy logic app
                            UploadedDate = DateTime.Now
                        };

                        _context.StudentFaceImages.Add(newFaceImage);

                        // Lưu ngay lập tức để đảm bảo dữ liệu vào DB
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        Console.WriteLine($"[ERROR] API từ chối ảnh {Path.GetFileName(file)}: {apiResult.message}");
                    }
                }
            }
        }

        // --- SQL RAW: Tạo giáo viên ---
        private async Task<int> EnsureTestTeacherExist()
        {
            string sql = @"
                DECLARE @TeacherId INT;
                DECLARE @UserId BIGINT = (SELECT TOP 1 user_id FROM [user] WHERE email = 'test.teacher@example.com');
                
                IF @UserId IS NULL
                BEGIN
                    INSERT INTO [user] (first_name, last_name, email, password_hashing, gender, date_of_birth, phone_number, is_active, role_id)
                    VALUES (N'Teacher', N'Test', 'test.teacher@example.com', '123456', 1, '1990-01-01', '0900000000', 1, 2);
                    SET @UserId = SCOPE_IDENTITY();
                END

                SELECT @TeacherId = teacher_id FROM teacher WHERE user_id = @UserId;
                
                IF @TeacherId IS NULL
                BEGIN
                    INSERT INTO teacher (user_id, salary, experience_year) VALUES (@UserId, 10000000, 5);
                    SET @TeacherId = SCOPE_IDENTITY();
                END
                
                SELECT @TeacherId;
            ";

            await _context.Database.ExecuteSqlRawAsync(sql);

            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == "test.teacher@example.com");
            var teacher = await _context.Teachers.AsNoTracking().FirstOrDefaultAsync(t => t.UserId == user.UserId);
            return teacher.TeacherId;
        }

        // --- SQL RAW: Tạo Lớp & Session (Đã fix lỗi Constraint) ---
        private async Task CreateClassSessionRawSql(int studentId, int teacherId, int shift, string dateStr)
        {
            string sql = $@"
                DECLARE @ClassId INT;
                DECLARE @ClassName NVARCHAR(50) = 'TEST_AUTO_SHIFT_{shift}';

                SELECT TOP 1 @ClassId = class_id FROM class WHERE class_name = @ClassName;

                IF @ClassId IS NULL
                BEGIN
                    -- [QUAN TRỌNG] Tắt kiểm tra ngày bắt đầu để tạo được lớp học đang diễn ra
                    ALTER TABLE class NOCHECK CONSTRAINT chk_start_date;

                    INSERT INTO class (teacher_id, class_name, current_student, max_student, start_date, end_date, shift, status)
                    VALUES ({teacherId}, @ClassName, 0, 30, DATEADD(week, -1, GETDATE()), DATEADD(month, 3, GETDATE()), {shift}, 1);
                    
                    SET @ClassId = SCOPE_IDENTITY();

                    -- Bật lại kiểm tra
                    ALTER TABLE class CHECK CONSTRAINT chk_start_date;

                    INSERT INTO class_day (class_id, school_day_id) VALUES (@ClassId, 2), (@ClassId, 3), (@ClassId, 4), (@ClassId, 5), (@ClassId, 6), (@ClassId, 7), (@ClassId, 8);
                END

                -- Thêm Học Viên vào Lớp
                IF NOT EXISTS (SELECT 1 FROM student_class WHERE student_id = {studentId} AND class_id = @ClassId)
                BEGIN
                    INSERT INTO student_class (student_id, class_id) VALUES ({studentId}, @ClassId);
                    UPDATE class SET current_student = current_student + 1 WHERE class_id = @ClassId;
                END

                -- Tạo Session HÔM NAY
                IF NOT EXISTS (SELECT 1 FROM class_session WHERE class_id = @ClassId AND session_date = '{dateStr}')
                BEGIN
                    -- Tự động tăng Session Number
                    DECLARE @NextSessionNum INT = ISNULL((SELECT MAX(session_number) FROM class_session WHERE class_id = @ClassId), 0) + 1;
                    
                    INSERT INTO class_session (class_id, session_date, session_number)
                    VALUES (@ClassId, '{dateStr}', @NextSessionNum);
                END
            ";

            await _context.Database.ExecuteSqlRawAsync(sql);
        }
    }
}