using BaiTapLonWinForm.Models.CompreFace;
using BaiTapLonWinForm.Services.interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Services.implements
{
    public class CompreFaceApiService : ICompreFaceApiService
    {
        private readonly HttpClient _httpClient;
        private string BASE_URL;
        private string API_KEY;

        public CompreFaceApiService(IConfiguration configuration)
        {
            BASE_URL = configuration["CompreFace:BaseUrl"];
            API_KEY = configuration["CompreFace:ApiKey"];

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", API_KEY);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<(bool success, string message)> AddFaceAsync(string subject, byte[] imageBytes)
        {
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageBytes), "file", "face.jpg");
                content.Add(new StringContent(subject), "subject");

                var response = await _httpClient.PostAsync($"{BASE_URL}/recognition/faces", content);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Thêm khuôn mặt thành công");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return (false, $"Lỗi API: {error}");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi kết nối: {ex.Message}");
            }
        }

        public async Task<(bool success, string subject, double confidence, string message)> RecognizeFaceAsync(byte[] imageBytes)
        {
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageBytes), "file", "face.jpg");

                var response = await _httpClient.PostAsync($"{BASE_URL}/recognition/recognize", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CompreFaceResponse>(jsonResponse);

                    if (result?.result != null && result.result.Count > 0)
                    {
                        var face = result.result[0];
                        if (face.subjects != null && face.subjects.Count > 0)
                        {
                            var bestMatch = face.subjects.OrderByDescending(s => s.similarity).First();

                            if (bestMatch.similarity >= 0.75)
                            {
                                return (true, bestMatch.subject, bestMatch.similarity, "Nhận diện thành công");
                            }
                            else
                            {
                                return (false, null, bestMatch.similarity, $"Độ tin cậy thấp ({bestMatch.similarity:P0})");
                            }
                        }
                    }

                    return (false, null, 0, "Không tìm thấy khuôn mặt khớp");
                }
                else
                {
                    return (false, null, 0, "Lỗi nhận diện");
                }
            }
            catch (Exception ex)
            {
                return (false, null, 0, $"Lỗi: {ex.Message}");
            }
        }


        public async Task<byte[]> FindBestAvatarAsync(List<byte[]> images)
        {
            if (images == null || images.Count == 0) return null;

            var tasks = new Dictionary<byte[], Task<FaceDetectionResponse>>();

            foreach (var img in images)
            {
                tasks.Add(img, DetectFaceAsync(img));
            }

            await Task.WhenAll(tasks.Values);

            byte[] bestImage = null;
            double bestScore = double.MaxValue; 

            foreach (var item in tasks)
            {
                var originalImage = item.Key;
                var response = await item.Value;

                if (response?.result != null && response.result.Count > 0)
                {
                    var face = response.result.OrderByDescending(f => f.probability).First();

                    if (face.probability < 0.9) continue;

                    if (face.pose.Deviation < bestScore)
                    {
                        bestScore = face.pose.Deviation;
                        bestImage = originalImage;
                    }
                }
            }

            return bestImage ?? images.FirstOrDefault();
        }

        private async Task<FaceDetectionResponse> DetectFaceAsync(byte[] imageBytes)
        {
            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new ByteArrayContent(imageBytes), "file", "check.jpg");
                    // Quan trọng: face_plugins=pose để lấy góc mặt
                    var response = await _httpClient.PostAsync($"{BASE_URL}/detection/detect?face_plugins=pose", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<FaceDetectionResponse>(json);
                    }
                }
            }
            catch { }
            return null;
        }

        // Response models
        private class CompreFaceResponse
        {
            public List<FaceResult> result { get; set; }
        }

        private class FaceResult
        {
            public List<Subject> subjects { get; set; }
        }

        private class Subject
        {
            public string subject { get; set; }
            public double similarity { get; set; }
        }
    }
}
