using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class TeacherFaceService : ITeacherFaceService
    {
        private readonly ITeacherFaceImageRepository _imageRepo;
        private readonly ITeacherRepository _teacherRepo; 
        private readonly IStudentRepository _studentRepo; 
        private readonly ICompreFaceApiService _faceApi;
        private const string FACE_IMAGES_FOLDER = "TeacherFaceImages";

        public TeacherFaceService(
            ITeacherFaceImageRepository imageRepo,
            ITeacherRepository teacherRepo,
            IStudentRepository studentRepo,
            ICompreFaceApiService faceApi)
        {
            _imageRepo = imageRepo;
            _teacherRepo = teacherRepo;
            _studentRepo = studentRepo;
            _faceApi = faceApi;
            if (!Directory.Exists(FACE_IMAGES_FOLDER)) Directory.CreateDirectory(FACE_IMAGES_FOLDER);
        }

        public async Task<(bool success, int savedCount, string message)> SaveFaceImagesAsync(int teacherId, List<byte[]> faceImages)
        {
            try
            {
                if (faceImages != null && faceImages.Count > 0)
                {
                    int checkLimit = Math.Min(faceImages.Count, 5);
                    for (int i = 0; i < checkLimit; i++)
                    {
                        var result = await _faceApi.RecognizeFaceAsync(faceImages[i]);

                        if (result.success && !string.IsNullOrEmpty(result.subject))
                        {
                            string subject = result.subject;
                            string mySubject = $"TEA_{teacherId}";

                            if (subject == mySubject) continue;

                            string existingName = "Không xác định";
                            string role = "";

                            if (subject.StartsWith("TEA_"))
                            {
                                // Trùng với giáo viên khác
                                int existId = int.Parse(subject.Replace("TEA_", ""));
                                var teacher = await _teacherRepo.GetByIdAsync(existId);
                                if (teacher != null) existingName = $"{teacher.User.LastName} {teacher.User.FirstName}";
                                role = "Giáo viên";
                            }
                            else
                            {
                                // Trùng với học sinh (Subject là số)
                                if (int.TryParse(subject, out int studId))
                                {
                                    var student = await _studentRepo.GetByIdAsync(studId);
                                    if (student != null) existingName = $"{student.User.LastName} {student.User.FirstName}";
                                    role = "Học viên";
                                }
                            }

                            return (false, 0, $"Khuôn mặt này đã thuộc về {role}: {existingName}!\n" +
                                               $"Độ chính xác: {result.confidence:P1}");
                        }
                    }
                }

                var currentTeacher = await _teacherRepo.GetByIdAsync(teacherId);
                if (currentTeacher == null) return (false, 0, "Giáo viên không tồn tại!");

                string teacherFolder = Path.Combine(FACE_IMAGES_FOLDER, teacherId.ToString());
                Directory.CreateDirectory(teacherFolder);
                int successCount = 0;

                foreach (var imageBytes in faceImages)
                {
                    string subjectName = $"TEA_{teacherId}";
                    var (success, msg) = await _faceApi.AddFaceAsync(subjectName, imageBytes);

                    if (success)
                    {
                        string fileName = $"{Guid.NewGuid()}.jpg";
                        string filePath = Path.Combine(teacherFolder, fileName);
                        await File.WriteAllBytesAsync(filePath, imageBytes);

                        await _imageRepo.AddAsync(new TeacherFaceImage
                        {
                            TeacherId = teacherId,
                            ImagePath = filePath,
                            UploadedDate = DateTime.Now
                        });
                        successCount++;
                    }
                }

                if (successCount >= 10) return (true, successCount, $"Đã lưu {successCount} ảnh thành công!");
                return (false, successCount, $"Chỉ lưu được {successCount} ảnh (Yêu cầu >= 10).");
            }
            catch (Exception ex)
            {
                return (false, 0, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<(bool success, string message)> DeleteAllImagesAsync(int teacherId)
        {
            try
            {
                await _imageRepo.DeleteByTeacherIdAsync(teacherId);

                string studentFolder = Path.Combine(FACE_IMAGES_FOLDER, teacherId.ToString());
                if (Directory.Exists(studentFolder))
                {
                    Directory.Delete(studentFolder, true);
                }

                return (true, "Đã xóa tất cả ảnh thành công!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi xóa ảnh: {ex.Message}");
            }
        }

        public async Task<int> GetImageCountAsync(int teacherId)
        {
            return await _imageRepo.CountByTeacherIdAsync(teacherId);
        }

        public async Task<List<TeacherFaceImage>> GetImagesAsync(int teacherId)
        {
            return await _imageRepo.GetByStudentIdAsync(teacherId);
        }

        public async Task<(bool success, int savedCount,
            string message, List<string>? createdFilePaths)>
            SaveFaceImagesAndGetPathsAsync(
            int teacherId, List<byte[]> faceImages)
        {
            var createdPaths = new List<string>();
            try
            {
                var teacher = await _teacherRepo.GetByIdAsync(teacherId);
                if (teacher == null)
                {
                    return (false, 0, "Sinh viên không tồn tại!", null);
                }
                string teacherFolder = Path.Combine(FACE_IMAGES_FOLDER, teacherId.ToString());
                Directory.CreateDirectory(teacherFolder);
                int successCount = 0;

                foreach (var imageBytes in faceImages)
                {
                    string subjectName = $"TEA_{teacherId}";
                    var (success, msg) = await _faceApi.AddFaceAsync(subjectName, imageBytes);

                    if (success)
                    {
                        string fileName = $"{Guid.NewGuid()}.jpg";
                        string filePath = Path.Combine(teacherFolder, fileName);
                        await File.WriteAllBytesAsync(filePath, imageBytes);

                        await _imageRepo.AddAsync(new TeacherFaceImage
                        {
                            TeacherId = teacherId,
                            ImagePath = filePath,
                            UploadedDate = DateTime.Now
                        });
                        successCount++;
                    }
                }

                // Logic kiểm tra số lượng
                if (successCount >= 10) return (true, successCount, "Thành công", createdPaths);
                return (false, successCount, "Không đủ ảnh", createdPaths);
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message, createdPaths);
            }
        }
    }
}
