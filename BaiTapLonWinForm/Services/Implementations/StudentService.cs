using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;

using BaiTapLonWinForm.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStudentFaceService _faceService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompreFaceApiService _compreFaceApiService;
        private readonly IStudentRepository _repo;

        public StudentService(
            IStudentRepository studentRepository,
            IUserRepository userRepository,
            IStudentFaceService faceService,
            IUnitOfWork unitOfWork,
            ICompreFaceApiService compreFaceApiService,
            IStudentRepository repo
            )
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _faceService = faceService;
            _unitOfWork = unitOfWork;
            _compreFaceApiService = compreFaceApiService;
            _repo = repo;

        }

        #region feature/nhan branch
        public List<ClassDto>? GetClassesByStudentId(int studentId)
        {
            var classes = _studentRepository.GetClassesByStudenId(studentId) ?? null;

            return classes.Select(c => new ClassDto
            {
                ClassId = c.ClassId,
                CourseName = c.CourseName,
                ClassName = c.ClassName,
                Node = c.Node ?? "Không có ghi chú",
                Shift = c.Shift,
                SchoolDay = c.SchoolDay,
                TeacherName = c.TeacherName
            }).ToList();
        }

        public List<ScheduleDto>? GetScheduleClass(int studentId)
        {
            var schedule = _studentRepository.GetScheduleClass(studentId);

            if (schedule == null) return [];

            return schedule;
        }

        public Student? GetStudentByStudentId(int studentId)
        {
            var student = _studentRepository.GetStudentByStudentId(studentId);
            if (student == null) return null;
            return student;
        }

        public bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data)
        {
            var student = _studentRepository.GetStudentByStudentId(studentId);
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

            return _studentRepository.UpdateStudentByStudentId(studentId, data);
        } 

        #endregion

        #region feature/ha branch
        public List<Student> getAllStudentByClassId(long classId)
        {
            List<Student> students = new List<Student>();
            students = _repo.getAllStudentByClassId(classId);
            if (students != null && students.Count > 0)
            {
                return students;
            }
            return null;
        }
        #endregion

        private void ValidateString(string? str, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new Exception($"{fieldName} không được để trống");
        }

        //#endregion

        #region feaute/trung branch
        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();
                return (true, $"Lấy danh sách {students.Count()} học viên thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Student? Data)> GetStudentByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID học viên không hợp lệ", null);

                var student = await _studentRepository.GetByIdAsync(id);

                if (student == null)
                    return (false, "Không tìm thấy học viên", null);

                return (true, "Lấy thông tin học viên thành công", student);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Student? Data)> GetStudentByUserIdAsync(long userId)
        {
            try
            {
                if (userId <= 0)
                    return (false, "User ID không hợp lệ", null);

                var student = await _studentRepository.GetByUserIdAsync(userId);

                if (student == null)
                    return (false, "Không tìm thấy học viên với User ID này", null);

                return (true, "Lấy thông tin học viên thành công", student);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> RegisterStudentFullAsync(User user, Student student, List<byte[]> faceImages)
        {
            List<string> createdFiles = new List<string>();

            try
            {
                if (faceImages != null && faceImages.Count > 0)
                {
                    int checkLimit = Math.Min(faceImages.Count, 5);

                    for (int i = 0; i < checkLimit; i++)
                    {
                        var recognizeResult = await _compreFaceApiService.RecognizeFaceAsync(faceImages[i]);

                        if (recognizeResult.success)
                        {
                            var existingStudent = await _studentRepository.GetByIdAsync(int.Parse(recognizeResult.subject));
                            string existingName = "Không xác định";

                            if (existingStudent != null && existingStudent.User != null)
                            {
                                existingName = $"{existingStudent.User.LastName} {existingStudent.User.FirstName}";
                            }

                            return (false, $"Khuôn mặt này đã tồn tại trong hệ thống!\n" +
                                           $"Trùng khớp với học viên: {existingName}\n" +
                                           $"Độ chính xác: {recognizeResult.confidence:P1}");
                        }
                    }
                }


                if (await _userRepository.EmailExistsAsync(user.Email))
                {
                    return (false, "Email đã tồn tại.");
                }

                if (!_unitOfWork.HasActiveTransaction)
                {
                    _unitOfWork.BeginTransaction();
                }
                var createdUser = await _userRepository.CreateAsync(user);

                // Lưu tạm để Database viên ra UserId 
                await _unitOfWork.SaveChangesAsync();

                student.UserId = createdUser.UserId; // Lấy ID từ user vừa tạo
                var createdStudent = await _studentRepository.CreateAsync(student);

                // Lưu tạm Student
                await _unitOfWork.SaveChangesAsync();

                if(faceImages != null)
                {
                    var faceResult = await _faceService.SaveFaceImagesAndGetPathsAsync(createdStudent.StudentId, faceImages);

                    // Ghi nhận các file đã tạo để xóa nếu lỗi
                    createdFiles.AddRange(faceResult.createdFilePaths);

                    if (!faceResult.success)
                    {
                        throw new Exception($"Lỗi lưu ảnh: {faceResult.message}");
                    }
                }

                // dữ liệu mới chính thức được lưu vĩnh viễn vào DB
                await _unitOfWork.CommitAsync();

                return (true, "Thêm viên viên thành công!");
            }
            catch (Exception ex)
            {

                await _unitOfWork.RollbackAsync();

                foreach (var path in createdFiles)
                {
                    if (File.Exists(path))
                    {
                        try { File.Delete(path); } catch { }
                    }
                }


                if (createdFiles.Count > 0)
                {
                    try
                    {
                        string folder = Path.GetDirectoryName(createdFiles[0]);
                        if (Directory.Exists(folder)) Directory.Delete(folder, true);
                    }
                    catch { }
                }

                string realErrorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    realErrorMessage += $"\nChi tiết: {ex.InnerException.Message}";

                    if (ex.InnerException.InnerException != null)
                    {
                        realErrorMessage += $"\nSQL Error: {ex.InnerException.InnerException.Message}";
                    }
                }

                return (false, $"Lỗi hệ thống: {realErrorMessage}");

            }
        }

        public async Task<(bool Success, string Message, Student? Data)> UpdateStudentAsync(Student student)
        {
            try
            {
                if (string.IsNullOrEmpty(student.User?.Email))
                    return (false, "Email không được để trống", null);

                if(await _userRepository.EmailExistsAsync(student.User.Email, student.UserId))
                    return (false, "Email đã tồn tại", null);

                // Check user exists (exclude current student)
                var updatedStudent = await _studentRepository.UpdateAsync(student);

                if (updatedStudent == null)
                    return (false, "Không thể cập nhật học viên", null);

                return (true, "Cập nhật học viên thành công", updatedStudent);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_student_user") == true)
                    return (false, "User ID không tồn tại trong hệ thống", null);

                if (ex.InnerException?.Message.Contains("UQ_") == true || ex.InnerException?.Message.Contains("Unique") == true)
                    return (false, "Email hoặc số điện thoại đã tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteStudentAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID học viên không hợp lệ");

                var student = await _studentRepository.GetByIdAsync(id);
                if (student == null)
                    return (false, "Không tìm thấy học viên");

                var (canDelete, message) = StudentValidator.CanDeleteStudent(student);
                if (!canDelete)
                    return (false, message);

                var result = await _studentRepository.DeleteAsync(id);

                if (!result)
                    return (false, "Không thể xóa học viên");


                // sau khi xóa học viên thì thực hiện xóa mềm user (vô hiệu hóa tài khoản)
                await _userRepository.SoftDeleteAsync(student.UserId);

                return (true, "Xóa học viên thành công");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                    return (false, "Không thể xóa học viên vì có dữ liệu liên quan (lớp học)");

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsWithClassesAsync()
        {
            try
            {
                var students = await _studentRepository.GetStudentsWithClassesAsync();
                return (true, $"Lấy danh sách {students.Count()} học viên đang có lớp học thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsByClassIdAsync(int classId)
        {
            try
            {
                if (classId <= 0)
                    return (false, "ID lớp học không hợp lệ", null);

                var students = await _studentRepository.GetStudentsByClassIdAsync(classId);
                return (true, $"Lấy danh sách {students.Count()} học viên của lớp thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> SearchStudentsByNameAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return (false, "Từ khóa tìm kiếm không được để trống", null);

                if (keyword.Length < 2)
                    return (false, "Từ khóa tìm kiếm phải có ít nhất 2 ký tự", null);

                var students = await _studentRepository.SearchByNameAsync(keyword);
                return (true, $"Tìm thấy {students.Count()} học viên", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, int Data)> GetClassCountAsync(int studentId)
        {
            try
            {
                if (studentId <= 0)
                    return (false, "ID học viên không hợp lệ", 0);

                var count = await _studentRepository.GetClassCountAsync(studentId);
                return (true, $"Học viên đang học {count} lớp", count);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsWithoutClassAsync()
        {
            try
            {
                var students = await _studentRepository.GetStudentsWithoutClassAsync();
                return (true, $"Lấy danh sách {students.Count()} học viên chưa có lớp thành công", students);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> CanEnrollClassAsync(int studentId)
        {
            try
            {
                if (studentId <= 0)
                    return (false, "ID học viên không hợp lệ");

                var student = await _studentRepository.GetByIdAsync(studentId);
                if (student == null)
                    return (false, "Không tìm thấy học viên");

                var (canEnroll, message) = StudentValidator.CanEnrollClass(student);

                if (!canEnroll)
                    return (false, message);

                return (true, "Học viên có thể đăng ký thêm lớp học");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, Student? Data)> getStudentById(int studentId)
        {
            try
            {
                if (studentId <= 0) return (false, "Mã học viên không hợp lệ!", null);
                var student = await _studentRepository.GetByIdAsync(studentId);
                if (student == null)
                    return (false, "Không tìm thấy học viên", null);
                else
                    return (true, "", student);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }

        }
        #endregion
    }
}
