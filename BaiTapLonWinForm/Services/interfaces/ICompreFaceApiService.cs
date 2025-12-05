using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.interfaces
{
    public interface ICompreFaceApiService
    {
        Task<(bool success, string message)> AddFaceAsync(int studentId, byte[] imageBytes);
        Task<(bool success, int? studentId, double confidence, string message)> RecognizeFaceAsync(byte[] imageBytes);
    }
}
