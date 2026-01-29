using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Models.CompreFace
{
    public class FaceDetectionResponse
    {
        public List<FaceResult> result { get; set; }
    }

    /// <summary>
    /// Thông tin chi tiết của từng khuôn mặt tìm thấy trong ảnh
    /// </summary>
    public class FaceResult
    {
        // Tọa độ khung hình chữ nhật bao quanh khuôn mặt
        public Box box { get; set; }

        // Góc nghiêng của khuôn mặt (quan trọng để chọn ảnh thẻ đẹp)
        public Pose pose { get; set; }

        // Độ tin cậy (0.0 -> 1.0). Ví dụ 0.99 nghĩa là máy chắc chắn 99% đây là mặt người
        public double probability { get; set; }
    }

    /// <summary>
    /// Tọa độ khuôn mặt
    /// </summary>
    public class Box
    {
        public int x_max { get; set; }
        public int x_min { get; set; }
        public int y_max { get; set; }
        public int y_min { get; set; }

        // Thuộc tính tính toán thêm: Diện tích khuôn mặt (càng to = ảnh càng nét)
        public int Area => (x_max - x_min) * (y_max - y_min);
    }

    /// <summary>
    /// Các góc nghiêng của đầu
    /// </summary>
    public class Pose
    {
        // Gật đầu lên/xuống
        public double pitch { get; set; }

        // Nghiêng đầu trái/phải (kiểu áp tai vào vai)
        public double roll { get; set; }

        // Quay mặt trái/phải (lắc đầu)
        public double yaw { get; set; }

        // Thuộc tính tính toán thêm: Tổng độ lệch so với phương thẳng đứng
        // Giá trị càng gần 0 thì mặt càng nhìn thẳng (ảnh thẻ chuẩn)
        public double Deviation => Math.Abs(pitch) + Math.Abs(roll) + Math.Abs(yaw);
    }
}
