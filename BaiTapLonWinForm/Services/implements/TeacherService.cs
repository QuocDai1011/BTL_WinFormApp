using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.implements;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Repository.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using BaiTapLonWinForm.Validate;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICompreFaceApiService _compreFaceApiService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ITeacherFaceService _faceService;
        public TeacherService(ITeacherRepository teacherRepository,
            ICompreFaceApiService compreFaceApiService,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ITeacherFaceService faceService)
        {
            _teacherRepository = teacherRepository;
            _compreFaceApiService = compreFaceApiService;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _faceService = faceService;
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetAllTeachersAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetAllAsync();
                return (true, $"Lấy danh sách {teachers.Count()} giảng viên thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Teacher Data)> GetTeacherByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID giảng viên không hợp lệ", null);

                var teacher = await _teacherRepository.GetByIdAsync(id);

                if (teacher == null)
                    return (false, "Không tìm thấy giảng viên", null);

                return (true, "Lấy thông tin giảng viên thành công", teacher);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, Teacher Data)> GetTeacherByUserIdAsync(long userId)
        {
            try
            {
                if (userId <= 0)
                    return (false, "User ID không hợp lệ", null);

                var teacher = await _teacherRepository.GetByUserIdAsync(userId);

                if (teacher == null)
                    return (false, "Không tìm thấy giảng viên với User ID này", null);

                return (true, "Lấy thông tin giảng viên thành công", teacher);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> CreateTeacherAsync(Models.User user, Teacher teacher, List<byte[]> faceImages)
        {
            List<string> createdFiles = new List<string>();

            try
            {
                //if (faceImages != null && faceImages.Count > 0)
                //{
                //    int checkLimit = Math.Min(faceImages.Count, 5);

                //    for (int i = 0; i < checkLimit; i++)
                //    {
                //        var recognizeResult = await _compreFaceApiService.RecognizeFaceAsync(faceImages[i]);

                //        if (recognizeResult.success)
                //        {
                //            var existingStudent = await _teacherRepository.GetByIdAsync(int.Parse(recognizeResult.subject));
                //            string existingName = "Không xác định";

                //            if (existingStudent != null && existingStudent.User != null)
                //            {
                //                existingName = $"{existingStudent.User.LastName} {existingStudent.User.FirstName}";
                //            }

                //            return (false, $"Khuôn mặt này đã tồn tại trong hệ thống!\n" +
                //                           $"Trùng khớp với giảng viên: {existingName}\n" +
                //                           $"Độ chính xác: {recognizeResult.confidence:P1}");
                //        }
                //    }
                //}

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
                teacher.UserId = createdUser.UserId; // Lấy ID từ user vừa tạo
                var createdStudent = await _teacherRepository.CreateAsync(teacher);

                // Lưu tạm Student
                await _unitOfWork.SaveChangesAsync();

                if (faceImages != null)
                {
                    // 4. Lưu ảnh (Logic file hệ thống + DB)
                    var faceResult = await _faceService.SaveFaceImagesAndGetPathsAsync(createdStudent.TeacherId, faceImages);

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

        public async Task<(bool Success, string Message, Teacher? Data)> UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                // Validation
                var (isValid, message) = TeacherValidator.ValidateForUpdate(teacher);
                if (!isValid)
                    return (false, message, null);

                // Check exists
                if (!await _teacherRepository.ExistsAsync(teacher.TeacherId))
                    return (false, "Không tìm thấy giảng viên", null);

                if (teacher.User != null)
                {
                    var currentDbTeacher = await _teacherRepository.GetByIdAsync(teacher.TeacherId);
                    if (currentDbTeacher == null) return (false, "Không tìm thấy giảng viên", null);

                    long userIdToCheck = currentDbTeacher.UserId; 


                    var checkResult = await ValidateTeacherUserRelationshipAsync(teacher.TeacherId, userIdToCheck);

                    if (!checkResult.IsValid)
                    {
                        return (false, checkResult.Message, null);
                    }
                }

                var updatedTeacher = await _teacherRepository.UpdateAsync(teacher);

                if (updatedTeacher == null)
                    return (false, "Không thể cập nhật giảng viên", null);

                return (true, "Cập nhật giảng viên thành công", updatedTeacher);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_teacher_user") == true)
                    return (false, "User ID không tồn tại trong hệ thống", null);

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteTeacherAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID giảng viên không hợp lệ");

                var teacher = await _teacherRepository.GetByIdAsync(id);
                if (teacher == null)
                    return (false, "Không tìm thấy giảng viên");

                // Validate can delete
                var (canDelete, message) = TeacherValidator.CanDeleteTeacher(teacher);
                if (!canDelete)
                    return (false, message);

                var result = await _teacherRepository.DeleteAsync(id);

                if (!result)
                    return (false, "Không thể xóa giảng viên");

                return (true, "Xóa giảng viên thành công");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
                    return (false, "Không thể xóa giảng viên vì có dữ liệu liên quan (lớp học)");

                return (false, $"Lỗi cơ sở dữ liệu: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetTeachersWithClassesAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetTeachersWithClassesAsync();
                return (true, $"Lấy danh sách {teachers.Count()} giảng viên đang có lớp học thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetTeachersByExperienceAsync(int minYears, int maxYears)
        {
            try
            {
                if (minYears < 0 || maxYears < 0)
                    return (false, "Số năm kinh nghiệm không hợp lệ", null);

                if (minYears > maxYears)
                    return (false, "Số năm tối thiểu không thể lớn hơn số năm tối đa", null);

                var teachers = await _teacherRepository.GetTeachersByExperienceAsync(minYears, maxYears);
                return (true, $"Lấy danh sách {teachers.Count()} giảng viên theo kinh nghiệm thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, IEnumerable<Teacher> Data)> GetAvailableTeachersAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetAvailableTeachersAsync();
                return (true, $"Lấy danh sách {teachers.Count()} giảng viên có thể nhận lớp thành công", teachers);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> CanAssignClassAsync(int teacherId)
        {
            try
            {
                if (teacherId <= 0)
                    return (false, "ID giảng viên không hợp lệ");

                var teacher = await _teacherRepository.GetByIdAsync(teacherId);
                if (teacher == null)
                    return (false, "Không tìm thấy giảng viên");

                var (canAssign, message) = TeacherValidator.CanAssignClass(teacher);

                if (!canAssign)
                    return (false, message);

                return (true, "giảng viên có thể nhận thêm lớp học");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message, int Data)> GetClassCountAsync(int teacherId)
        {
            try
            {
                if (teacherId <= 0)
                    return (false, "ID giảng viên không hợp lệ", 0);

                var count = await _teacherRepository.GetClassCountAsync(teacherId);
                return (true, $"giảng viên đang có {count} lớp học", count);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }
        public async Task<(bool IsValid, string Message)> ValidateTeacherUserRelationshipAsync(int teacherId, long userId)
        {
            try
            {
                bool isAssignedToOther = await _teacherRepository.IsUserIdAssignedToOtherTeacherAsync(userId, teacherId);
                if (isAssignedToOther)
                {
                    return (false, "Lỗi dữ liệu nghiêm trọng: User ID này đang được liên kết với một giảng viên khác. Vui lòng kiểm tra lại database!");
                }


                bool isMatch = await _teacherRepository.IsTeacherUserMatchAsync(teacherId, userId);
                if (!isMatch)
                {

                    return (false, "Dữ liệu không đồng bộ: Giảng viên này không liên kết với User ID được cung cấp.");
                }

                return (true, "Dữ liệu hợp lệ");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi kiểm tra quan hệ Teacher-User: {ex.Message}");
            }
        }
    }
}
