using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface IStudentFaceService
    {
        Task<(bool success, int savedCount, string message)> SaveFaceImagesAsync(int studentId, List<byte[]> faceImages);
        Task<int> GetImageCountAsync(int studentId);
        Task<List<StudentFaceImage>> GetImagesAsync(int studentId);
        Task<(bool success, string message)> DeleteAllImagesAsync(int studentId);

        Task<(bool success, int savedCount, string message, List<string>? createdFilePaths)> SaveFaceImagesAndGetPathsAsync(int studentId, List<byte[]> faceImages);
    }
}
