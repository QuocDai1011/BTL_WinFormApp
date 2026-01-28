using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Validate;
using Microsoft.EntityFrameworkCore;

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
            IStudentRepository repo)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _faceService = faceService;
            _unitOfWork = unitOfWork;
            _compreFaceApiService = compreFaceApiService;
            _repo = repo;
        }

        #region feature/ha

        public List<Student> GetAllStudentByClassId(long classId)
        {
            var students = _repo.getAllStudentByClassId(classId);
            return students ?? new List<Student>();
        }

        #endregion


        #region feature/nhan

        public List<ClassDto> GetClassesByStudentId(int studentId)
        {
            return _repo.GetClassesByStudenId(studentId) ?? new List<ClassDto>();
        }

        public Student? GetStudentByStudentId(int studentId)
        {
            return _repo.GetStudentByStudentId(studentId);
        }

        public bool UpdateStudentByStudentId(int studentId, UpdateStudentDto data)
        {
            var student = _repo.GetStudentByStudentId(studentId);
            if (student == null)
                throw new Exception("Không tìm thấy sinh viên");

            ValidateString(data.FirstName, "FirstName");
            ValidateString(data.LastName, "LastName");
            ValidateString(data.Email, "Email");
            ValidateString(data.Address, "Address");
            ValidateString(data.PhoneNumber, "PhoneNumber");
            ValidateString(data.PhoneNumberOfParents, "PhoneNumberOfParents");

            if (data.Gender == null)
                throw new Exception("Gender không được để trống");

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

            if (data.PhoneNumber == data.PhoneNumberOfParents)
                return false;

            if (data.DateOfBirth == default)
                throw new Exception("DateOfBirth không được để trống");

            return _repo.UpdateStudentByStudentId(studentId, data);
        }

        private void ValidateString(string? str, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new Exception($"{fieldName} không được để trống");
        }

        #endregion


        #region feature/trung

        public async Task<(bool Success, string Message, IEnumerable<Student> Data)> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();
                return (true, $"Lấy danh sách {students.Count()} học viên thành công", students);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool Success, string Message, Student? Data)> GetStudentByIdAsync(int studentId)
        {
            if (studentId <= 0)
                return (false, "ID học viên không hợp lệ", null);

            var student = await _studentRepository.GetByIdAsync(studentId);
            return student == null
                ? (false, "Không tìm thấy học viên", null)
                : (true, "Lấy thông tin học viên thành công", student);
        }

        public async Task<(bool Success, string Message, Student? Data)> GetStudentByUserIdAsync(long userId)
        {
            if (userId <= 0)
                return (false, "User ID không hợp lệ", null);

            var student = await _studentRepository.GetByUserIdAsync(userId);
            return student == null
                ? (false, "Không tìm thấy học viên với User ID này", null)
                : (true, "Lấy thông tin học viên thành công", student);
        }

        public async Task<(bool Success, string Message)> RegisterStudentFullAsync(
            User user,
            Student student,
            List<byte[]>? faceImages = null)
        {
            var createdFiles = new List<string>();

            try
            {
                if (faceImages != null && faceImages.Any())
                {
                    foreach (var img in faceImages.Take(5))
                    {
                        var result = await _compreFaceApiService.RecognizeFaceAsync(img);
                        if (result.success)
                            return (false, "Khuôn mặt đã tồn tại trong hệ thống");
                    }
                }

                if (await _userRepository.EmailExistsAsync(user.Email))
                    return (false, "Email đã tồn tại");

                _unitOfWork.BeginTransaction();

                var createdUser = await _userRepository.CreateAsync(user);
                await _unitOfWork.SaveChangesAsync();

                student.UserId = createdUser.UserId;
                var createdStudent = await _studentRepository.CreateAsync(student);
                await _unitOfWork.SaveChangesAsync();

                if (faceImages != null)
                {
                    var faceResult = await _faceService.SaveFaceImagesAndGetPathsAsync(
                        createdStudent.StudentId, faceImages);

                    createdFiles.AddRange(faceResult.createdFilePaths);

                    if (!faceResult.success)
                        throw new Exception(faceResult.message);
                }

                await _unitOfWork.CommitAsync();
                return (true, "Thêm học viên thành công");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string Message, Student? Data)> UpdateStudentAsync(Student student)
        {
            try
            {
                var updated = await _studentRepository.UpdateAsync(student);
                return updated == null
                    ? (false, "Không thể cập nhật học viên", null)
                    : (true, "Cập nhật học viên thành công", updated);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool Success, string Message)> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
                return (false, "Không tìm thấy học viên");

            await _studentRepository.DeleteAsync(id);
            await _userRepository.SoftDeleteAsync(student.UserId);
            return (true, "Xóa học viên thành công");
        }

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsWithClassesAsync()
            => (true, "", await _studentRepository.GetStudentsWithClassesAsync());

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsByClassIdAsync(int classId)
            => (true, "", await _studentRepository.GetStudentsByClassIdAsync(classId));

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> SearchStudentsByNameAsync(string keyword)
            => (true, "", await _studentRepository.SearchByNameAsync(keyword));

        public async Task<(bool Success, string Message, int Data)> GetClassCountAsync(int studentId)
            => (true, "", await _studentRepository.GetClassCountAsync(studentId));

        public async Task<(bool Success, string Message, IEnumerable<Student>? Data)> GetStudentsWithoutClassAsync()
            => (true, "", await _studentRepository.GetStudentsWithoutClassAsync());

        public async Task<(bool Success, string Message)> CanEnrollClassAsync(int studentId)
            => (true, "Có thể đăng ký lớp học");

        #endregion
    }
}
