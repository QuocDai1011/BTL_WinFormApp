using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ITeacherFaceService
    {
        Task<(bool success, int savedCount, string message)> SaveFaceImagesAsync(int teacherId, List<byte[]> faceImages);
        Task<int> GetImageCountAsync(int teacherId);
        Task<List<TeacherFaceImage>> GetImagesAsync(int teacherId);
        Task<(bool success, string message)> DeleteAllImagesAsync(int teacherId);

        Task<(bool success, int savedCount, string message, List<string>? createdFilePaths)> SaveFaceImagesAndGetPathsAsync(int teacherId, List<byte[]> faceImages);
    }
}