using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.implements; // Để dùng DTO ReceptionCheckInResult
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class FaceAttendance : UserControl
    {
        // --- EmguCV Variables ---
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer frameTimer;
        private bool isRecognizing = false;

        // --- Service & Data ---
        private readonly ServiceHub _serviceHub;

        // Cache danh sách sinh viên đã điểm danh trong phiên chạy này để tránh spam
        // Key: StudentId, Value: Thời điểm check-in
        private Dictionary<int, DateTime> _checkedInCache = new Dictionary<int, DateTime>();

        public FaceAttendance(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;

            // Setup giao diện ban đầu
            InitializeListView();
            InitializeCamera();
            InitializeTimer();
        }

        // Cấu hình cột cho ListView hiển thị kết quả
        private void InitializeListView()
        {
            lvAttendance.View = System.Windows.Forms.View.Details;
            lvAttendance.GridLines = true;
            lvAttendance.FullRowSelect = true;

            // Xóa cột cũ (nếu có) và thêm cột mới
            lvAttendance.Columns.Clear();
            lvAttendance.Columns.Add("Thời gian", 100);
            lvAttendance.Columns.Add("Họ và tên", 200);
            lvAttendance.Columns.Add("Lớp học - Ca", 250);
            lvAttendance.Columns.Add("Trạng thái", 150);
            lvAttendance.Columns.Add("Ghi chú", 100);

        }

        // --- CAMERA LOGIC ---
        private void InitializeCamera()
        {
            try
            {
                cboCamera.Items.Clear();
                // Tìm các device camera
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        using (var temp = new VideoCapture(i))
                        {
                            if (temp.IsOpened) cboCamera.Items.Add($"Camera {i}");
                        }
                    }
                    catch { break; }
                }

                if (cboCamera.Items.Count > 0)
                {
                    cboCamera.SelectedIndex = 0;
                    btnStartCamera.Enabled = true;
                }
                else
                {
                    lblCameraStatus.Text = "🚫 Không tìm thấy Camera";
                    btnStartCamera.Enabled = false;
                }

                frame = new Mat();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi init camera: {ex.Message}");
            }
        }

        private void InitializeTimer()
        {
            frameTimer = new System.Windows.Forms.Timer();
            frameTimer.Interval = 33; // ~30 FPS
            frameTimer.Tick += FrameTimer_Tick;
        }

        private async void FrameTimer_Tick(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened)
            {
                try
                {
                    capture.Read(frame);
                    if (!frame.IsEmpty)
                    {
                        // Hiển thị lên PictureBox
                        Bitmap bitmap = frame.ToImage<Bgr, byte>().ToBitmap();

                        // Dispose ảnh cũ để tránh leak memory
                        var oldImg = picCamera.Image;
                        picCamera.Image = bitmap;
                        if (oldImg != null) oldImg.Dispose();

                        // Logic Tự động nhận diện
                        if (chkAutoRecognize.Checked && !isRecognizing)
                        {
                            // Chỉ nhận diện mỗi 2 giây 1 lần để đỡ lag
                            await RecognizeFaceAsync();
                        }
                    }
                }
                catch { }
            }
        }

        private void BtnStartCamera_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning) StartCamera();
            else StopCamera();
        }

        private void StartCamera()
        {
            if (cboCamera.SelectedIndex == -1) return;

            try
            {
                capture = new VideoCapture(cboCamera.SelectedIndex);
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);

                frameTimer.Start();
                isCameraRunning = true;

                btnStartCamera.Text = "🛑 Dừng Camera";
                btnStartCamera.BackColor = Color.IndianRed;
                btnRecognize.Enabled = true;
                chkAutoRecognize.Enabled = true;
                lblCameraStatus.Text = "🟢 Camera đang chạy";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể bật camera: {ex.Message}");
            }
        }

        private void StopCamera()
        {
            frameTimer.Stop();
            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }

            isCameraRunning = false;
            btnStartCamera.Text = "▶ Bật Camera";
            btnStartCamera.BackColor = Color.SeaGreen;
            btnRecognize.Enabled = false;
            chkAutoRecognize.Enabled = false;
            chkAutoRecognize.Checked = false;
            lblCameraStatus.Text = "⚫ Camera đã tắt";
            picCamera.Image = null;
        }

        // --- RECOGNITION LOGIC ---
        private async void BtnRecognize_Click(object sender, EventArgs e)
        {
            await RecognizeFaceAsync();
        }

        private async Task RecognizeFaceAsync()
        {
            if (isRecognizing || picCamera.Image == null) return;

            isRecognizing = true;
            lblRecognitionStatus.Text = "🔍 Đang nhận diện...";
            lblRecognitionStatus.ForeColor = Color.Orange;

            try
            {
                // Chụp ảnh từ stream hiện tại
                Bitmap currentFrame = new Bitmap(picCamera.Image);
                byte[] imageBytes = BitmapToByteArray(currentFrame);

                // Hàm này sẽ tự tìm lớp, tìm ca, và mark attendance
                var result = await _serviceHub.AttendanceService.CheckInAtReceptionAsync(imageBytes);

                //  Xử lý kết quả trả về
                ProcessCheckInResult(result);
            }
            catch (Exception ex)
            {
                ShowNotification("Lỗi hệ thống", ex.Message, false);
            }
            finally
            {
                // Delay nhỏ để tránh spam request liên tục
                if (chkAutoRecognize.Checked) await Task.Delay(2000);
                else await Task.Delay(500);

                isRecognizing = false;
            }
        }

        private void ProcessCheckInResult(ReceptionCheckInResult result)
        {
            // Cập nhật trạng thái text
            lblRecognitionStatus.Text = result.Success ? "✅ " + result.Message : "❌ " + result.Message;
            lblRecognitionStatus.ForeColor = result.Success ? Color.Green : Color.Red;

            // Hiển thị thông báo Popup đẹp
            ShowNotification(
                result.Success ? "Thành công" : "Thất bại",
                result.Message,
                result.Success
            );

            // Nếu thành công, thêm vào danh sách hiển thị
            if (result.Success)
            {
                // Kiểm tra spam log (nếu vừa hiển thị người này trong vòng 10s thì thôi không add list nữa cho đỡ rác)
                if (_checkedInCache.ContainsKey(result.StudentId))
                {
                    var lastTime = _checkedInCache[result.StudentId];
                    if ((DateTime.Now - lastTime).TotalSeconds < 10) return;
                }

                _checkedInCache[result.StudentId] = DateTime.Now;
                AddRecordToListView(result);

                // Cập nhật số lượng
                lblTotalPresent.Text = _checkedInCache.Count.ToString();
            }
        }

        private void AddRecordToListView(ReceptionCheckInResult result)
        {
            // Tạo Item mới
            ListViewItem item = new ListViewItem(result.CheckInTime?.ToString("HH:mm:ss")); // Cột 1: Giờ
            item.SubItems.Add(result.StudentName); // Cột 2: Tên
            item.SubItems.Add($"{result.ClassName} ({result.ShiftName})"); // Cột 3: Lớp
            item.SubItems.Add("Có mặt"); // Cột 4: Trạng thái
            if (result.isLate)
            {
                item.SubItems.Add("Đi muộn");
            }
            // Style
            item.ForeColor = Color.DarkGreen;
            item.Font = new Font(lvAttendance.Font, FontStyle.Bold);

            // Insert lên đầu danh sách
            lvAttendance.Items.Insert(0, item);
        }

        // --- HELPERS ---

        private void ShowNotification(string title, string message, bool success)
        {
            // Hiển thị Panel Notification (Giả sử bạn đã design panel này)
            panelNotification.Visible = true;
            panelNotification.BackColor = success ? Color.FromArgb(220, 255, 220) : Color.FromArgb(255, 220, 220);
            lblNotificationTitle.Text = title;
            lblNotificationTitle.ForeColor = success ? Color.Green : Color.Red;
            lblNotificationMessage.Text = message;
            lblNotificationMessage.ForeColor = Color.Black;
            // Auto hide sau 3s
            Timer t = new Timer();
            t.Interval = 3000;
            t.Tick += (s, e) => {
                panelNotification.Visible = false;
                t.Stop();
                t.Dispose();
            };
            t.Start();
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void ChkAutoRecognize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRecognize.Checked)
            {
                lblRecognitionStatus.Text = "🔄 Chế độ tự động đang chạy...";
                btnRecognize.Enabled = false; // Disable nút thủ công khi đang auto
            }
            else
            {
                lblRecognitionStatus.Text = "⏸️ Chế độ thủ công";
                btnRecognize.Enabled = true;
            }
        }
    }
}