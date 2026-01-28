using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.Interfaces
{
    public interface ICompreFaceApiService
    {
        Task<(bool success, string message)> AddFaceAsync(string subject, byte[] imageBytes);
        Task<(bool success, string subject, double confidence, string message)> RecognizeFaceAsync(byte[] imageBytes);

        Task<byte[]> FindBestAvatarAsync(List<byte[]> images);
    }
}