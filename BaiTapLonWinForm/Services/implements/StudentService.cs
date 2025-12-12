using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Repository.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using BaiTapLonWinForm.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStudentFaceService _faceService;
        private readonly IUnitOfWork _unitOfWork; 
        public StudentService(
            IStudentRepository studentRepository,
            IUserRepository userRepository,
            IStudentFaceService faceService,
            IUnitOfWork unitOfWork
            )
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _faceService = faceService;
            _unitOfWork = unitOfWork;

        }

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

        public async Task<(bool Success, string Message, Student Data)> GetStudentByIdAsync(int id)
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

        public async Task<(bool Success, string Message, Student Data)> GetStudentByUserIdAsync(long userId)
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
                // 1. BẮT ĐẦU TRANSACTION
                _unitOfWork.BeginTransaction();

                // 2. Validate & Tạo User
                if (await _userRepository.EmailExistsAsync(user.Email))
                {
                    // Chưa làm gì DB -> Không cần rollback -> Return luôn
                    return (false, "Email đã tồn tại.");
                }

                var createdUser = await _userRepository.CreateAsync(user);

                // Lưu tạm để Database viên ra UserId (nhưng chưa Commit Transaction)
                await _unitOfWork.SaveChangesAsync();

                // 3. Tạo Student
                student.UserId = createdUser.UserId; // Lấy ID từ user vừa tạo
                var createdStudent = await _studentRepository.CreateAsync(student);

                // Lưu tạm Student
                await _unitOfWork.SaveChangesAsync();

                if(faceImages != null)
                {
                    // 4. Lưu ảnh (Logic file hệ thống + DB)
                    var faceResult = await _faceService.SaveFaceImagesAndGetPathsAsync(createdStudent.StudentId, faceImages);

                    // Ghi nhận các file đã tạo để xóa nếu lỗi
                    createdFiles.AddRange(faceResult.createdFilePaths);

                    if (!faceResult.success)
                    {
                        throw new Exception($"Lỗi lưu ảnh: {faceResult.message}");
                    }
                }

                // 5. MỌI THỨ OK -> COMMIT (CHỐT SỔ)
                // Lúc này dữ liệu mới chính thức được lưu vĩnh viễn vào DB
                await _unitOfWork.CommitAsync();

                return (true, "Thêm viên viên thành công!");
            }
            catch (Exception ex)
            {
                // 6. CÓ LỖI -> ROLLBACK (HOÀN TÁC DB)
                // User và Student vừa tạo sẽ bị xóa khỏi DB
                await _unitOfWork.RollbackAsync();

                // 7. DỌN DẸP FILE RÁC (HOÀN TÁC FILE)
                foreach (var path in createdFiles)
                {
                    if (File.Exists(path))
                    {
                        try { File.Delete(path); } catch { }
                    }
                }

                // Xóa thư mục rỗng nếu cần
                if (createdFiles.Count > 0)
                {
                    try
                    {
                        string folder = Path.GetDirectoryName(createdFiles[0]);
                        if (Directory.Exists(folder)) Directory.Delete(folder, true);
                    }
                    catch { }
                }
                // 3. LẤY LỖI CHI TIẾT (INNER EXCEPTION)
                // Lỗi thực sự nằm sâu bên trong InnerException
                string realErrorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    realErrorMessage += $"\nChi tiết: {ex.InnerException.Message}";

                    // Đôi khi lỗi nằm sâu hơn nữa (cấp 2)
                    if (ex.InnerException.InnerException != null)
                    {
                        realErrorMessage += $"\nSQL Error: {ex.InnerException.InnerException.Message}";
                    }
                }

                return (false, $"Lỗi hệ thống: {realErrorMessage}");

                //return (false, $"Lỗi hệ thống (Đã hoàn tác dữ liệu): {ex.Message}");
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

                // Validate can delete
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

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsWithClassesAsync()
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

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsByClassIdAsync(int classId)
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

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> SearchStudentsByNameAsync(string keyword)
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

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetStudentsWithoutClassAsync()
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

        
    }
}
