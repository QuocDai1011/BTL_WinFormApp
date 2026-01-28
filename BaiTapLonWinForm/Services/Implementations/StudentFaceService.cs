using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Implementations
{
    public class StudentFaceService : IStudentFaceService
    {
        private readonly IStudentFaceImageRepository _imageRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly ICompreFaceApiService _faceApi;
        private const string FACE_IMAGES_FOLDER = "FaceImages";

        public StudentFaceService(
            IStudentFaceImageRepository imageRepo,
            IStudentRepository studentRepo,
            ICompreFaceApiService faceApi)
        {
            _imageRepo = imageRepo;
            _studentRepo = studentRepo;
            _faceApi = faceApi;

            if (!Directory.Exists(FACE_IMAGES_FOLDER))
                Directory.CreateDirectory(FACE_IMAGES_FOLDER);
        }

        public async Task<(bool success, int savedCount, string message)> SaveFaceImagesAsync(
            int studentId, List<byte[]> faceImages)
        {
            try
            {
                if (faceImages != null && faceImages.Count > 0)
                {
                    int checkLimit = Math.Min(faceImages.Count, 5);

                    for (int i = 0; i < checkLimit; i++)
                    {
                        var recognizeResult = await _faceApi.RecognizeFaceAsync(faceImages[i]);

                        if (recognizeResult.success)
                        {
                            if (int.Parse(recognizeResult.subject) == studentId)
                            {
                                continue;
                            }

                            var existingStudent = await _studentRepo.GetByIdAsync(int.Parse(recognizeResult.subject));
                            string existingName = "Không xác định";

                            if (existingStudent != null && existingStudent.User != null)
                            {
                                existingName = $"{existingStudent.User.LastName} {existingStudent.User.FirstName}";
                            }

                            return (false, 0, $"Khuôn mặt này đã thuộc về người khác!\n" +
                                               $"Trùng khớp với học viên: {existingName}\n" +
                                               $"Độ chính xác: {recognizeResult.confidence:P1}");
                        }       
                    }
                }

                var student = await _studentRepo.GetByIdAsync(studentId);
                if (student == null)
                {
                    return (false, 0, "Sinh viên không tồn tại!");
                }

                string studentFolder = Path.Combine(FACE_IMAGES_FOLDER, studentId.ToString());
                Directory.CreateDirectory(studentFolder);

                int successCount = 0;

                foreach (var imageBytes in faceImages)
                {
                    try
                    {
                        var (success, message) = await _faceApi.AddFaceAsync(studentId.ToString(), imageBytes);

                        if (success)
                        {
                            string fileName = $"{Guid.NewGuid()}.jpg";
                            string filePath = Path.Combine(studentFolder, fileName);
                            await File.WriteAllBytesAsync(filePath, imageBytes);

                            var faceImage = new StudentFaceImage
                            {
                                StudentId = studentId,
                                ImagePath = filePath,
                                UploadedDate = DateTime.Now
                            };

                            await _imageRepo.AddAsync(faceImage);
                            successCount++;
                        }
                    }
                    catch { }
                }

                if (successCount >= 10)
                {
                    return (true, successCount, $"Đã lưu {successCount}/{faceImages.Count} ảnh thành công!");
                }
                else
                {
                    return (false, successCount, $"Chỉ lưu được {successCount}/{faceImages.Count} ảnh. Cần ít nhất 10 ảnh!");
                }
            }
            catch (Exception ex)
            {
                return (false, 0, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<int> GetImageCountAsync(int studentId)
        {
            return await _imageRepo.CountByStudentIdAsync(studentId);
        }

        public async Task<List<StudentFaceImage>> GetImagesAsync(int studentId)
        {
            return await _imageRepo.GetByStudentIdAsync(studentId);
        }

        public async Task<(bool success, string message)> DeleteAllImagesAsync(int studentId)
        {
            try
            {
                await _imageRepo.DeleteByStudentIdAsync(studentId);

                string studentFolder = Path.Combine(FACE_IMAGES_FOLDER, studentId.ToString());
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

        public async Task<(bool success, int savedCount,
            string message, List<string>? createdFilePaths)>
            SaveFaceImagesAndGetPathsAsync(
            int studentId, List<byte[]> faceImages)
        {
            var createdPaths = new List<string>();
            try
            {
                var student = await _studentRepo.GetByIdAsync(studentId);
                if (student == null)
                {
                    return (false, 0, "Sinh viên không tồn tại!", null);
                }
                string studentFolder = Path.Combine("FaceImages", studentId.ToString());
                Directory.CreateDirectory(studentFolder);
                int successCount = 0;

                foreach (var imageBytes in faceImages)
                {
                    var (success, message) = await _faceApi.AddFaceAsync(studentId.ToString(), imageBytes);

                    if (success)
                    {
                        string fileName = $"{Guid.NewGuid()}.jpg";
                        string filePath = Path.Combine(studentFolder, fileName);

                        // Lưu file
                        await File.WriteAllBytesAsync(filePath, imageBytes);
                        createdPaths.Add(filePath); // QUAN TRỌNG: Lưu lại đường dẫn

                        // Lưu xuống DB (Thông qua Repository)
                        var faceImage = new StudentFaceImage
                        {
                            StudentId = studentId,
                            ImagePath = filePath,
                            UploadedDate = DateTime.Now
                        };
                        await _imageRepo.AddAsync(faceImage);
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
