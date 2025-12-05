using BaiTapLonWinForm.Services.interfaces;
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
        private const string BASE_URL = "http://localhost:8000/api/v1";
        private const string API_KEY = "42dc0240-765a-426d-89dd-30e290ad636f"; // TODO: Thay bằng API key thực tế

        public CompreFaceApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", API_KEY);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<(bool success, string message)> AddFaceAsync(int studentId, byte[] imageBytes)
        {
            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageBytes), "file", "face.jpg");
                content.Add(new StringContent(studentId.ToString()), "subject");

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

        public async Task<(bool success, int? studentId, double confidence, string message)> RecognizeFaceAsync(byte[] imageBytes)
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
                                int studentId = int.Parse(bestMatch.subject);
                                return (true, studentId, bestMatch.similarity, "Nhận diện thành công");
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
