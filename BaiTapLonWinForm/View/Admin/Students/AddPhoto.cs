using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class AddPhoto : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _studentId;
        private List<byte[]> capturedImages = new List<byte[]>();
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer frameTimer;

        public EventHandler CloseRequested { get; set; }
        public AddPhoto(ServiceHub serviceHub, int studentId)
        {
            _serviceHub = serviceHub;
            _studentId = studentId;
            InitializeComponent();
            this.Load += AddPhoto_Load;
            InitializeTimer();
        }

        private async void AddPhoto_Load(object? sender, EventArgs e)
        {
            await InitializeCameraAsync();
        }

        #region initialize

        private async Task InitializeCameraAsync()
        {
            cboCamera.Items.Clear();
            cboCamera.Enabled = false;
            lblSelectCamera.Text = "Đang tìm camera...";
            btnStartCamera.Enabled = false;

            try
            {

                var availableCameras = await Task.Run(() =>
                {
                    var cameras = new List<string>();
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            using (VideoCapture testCapture = new VideoCapture(i))
                            {
                                if (testCapture.IsOpened)
                                {
                                    cameras.Add($"Camera {i}");
                                }
                            }
                        }
                        catch { }
                    }
                    return cameras;
                });

                if (availableCameras.Count > 0)
                {
                    foreach (var cam in availableCameras)
                    {
                        cboCamera.Items.Add(cam);
                    }
                    cboCamera.SelectedIndex = 0;
                    frame = new Mat();
                    btnStartCamera.Enabled = true;
                    lblSelectCamera.Text = "Chọn camera:";
                }
                else
                {
                    lblSelectCamera.Text = "Không tìm thấy camera";
                    lblSelectCamera.ForeColor = Color.Red;
                    btnStartCamera.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo camera: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cboCamera.Enabled = true;
            }
        }

        private void InitializeTimer()
        {
            frameTimer = new System.Windows.Forms.Timer();
            frameTimer.Interval = 33; // ~30 FPS
            frameTimer.Tick += FrameTimer_Tick;
        }

        #endregion

        #region handle events

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened)
            {
                try
                {
                    capture.Read(frame);

                    if (!frame.IsEmpty)
                    {
                        // Convert Mat to Bitmap
                        Bitmap bitmap = frame.ToImage<Bgr, byte>().ToBitmap();

                        // Update PictureBox
                        if (picCamera.Image != null)
                            picCamera.Image.Dispose();

                        picCamera.Image = bitmap;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading frame: {ex.Message}");
                }
            }
        }

        private void BtnStartCamera_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning)
            {
                StartCamera();
            }
            else
            {
                StopCamera();
            }
        }

        private void BtnCapture_Click(object sender, EventArgs e)
        {
            if (picCamera.Image == null)
            {
                MessageBox.Show("Không có hình ảnh để chụp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Capture current frame
                Bitmap capturedBitmap = new Bitmap(picCamera.Image);

                // Convert to byte array
                byte[] imageBytes = BitmapToByteArray(capturedBitmap);

                // Add to collection
                capturedImages.Add(imageBytes);

                // Update preview gallery
                UpdateImageGallery();

                // Update status
                UpdateImageStatus();

                // Show preview of last captured image
                if (picPreview.Image != null)
                    picPreview.Image.Dispose();
                picPreview.Image = new Bitmap(capturedBitmap);

                lblImageStatus.Text = $"✅ Đã chụp {capturedImages.Count}/15 ảnh";
                lblImageStatus.ForeColor = capturedImages.Count >= 10
                    ? Color.FromArgb(46, 204, 113)
                    : Color.FromArgb(243, 156, 18);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chụp ảnh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAutoCapture_Click(object sender, EventArgs e)
        {
            if (capturedImages.Count >= 15)
            {
                MessageBox.Show("Đã đủ 15 ảnh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnAutoCapture.Enabled = false;
            btnCapture.Enabled = false;

            try
            {
                int targetCount = Math.Min(15, capturedImages.Count + 10);
                int captureInterval = 500; // 0.5 second between captures

                progressBar.Visible = true;
                progressBar.Maximum = targetCount - capturedImages.Count;
                progressBar.Value = 0;

                while (capturedImages.Count < targetCount && isCameraRunning)
                {
                    if (picCamera.Image != null)
                    {
                        Bitmap capturedBitmap = new Bitmap(picCamera.Image);
                        byte[] imageBytes = BitmapToByteArray(capturedBitmap);
                        capturedImages.Add(imageBytes);

                        UpdateImageGallery();
                        UpdateImageStatus();

                        progressBar.Value++;

                        lblImageStatus.Text = $"📸 Đang chụp tự động... {capturedImages.Count}/{targetCount}";
                    }

                    await Task.Delay(captureInterval);
                }

                progressBar.Visible = false;

                MessageBox.Show($"Đã chụp {capturedImages.Count} ảnh!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateImageStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chụp tự động: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                btnAutoCapture.Enabled = true;
                btnCapture.Enabled = true;
            }
        }

        private void ImageThumbnail_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int index = (int)pb.Tag;

            if (picPreview.Image != null)
                picPreview.Image.Dispose();

            using (MemoryStream ms = new MemoryStream(capturedImages[index]))
            {
                picPreview.Image = Image.FromStream(ms);
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            if (capturedImages.Count == 0)
                return;

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tất cả ảnh đã chụp?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                capturedImages.Clear();
                UpdateImageGallery();
                UpdateImageStatus();

                if (picPreview.Image != null)
                {
                    picPreview.Image.Dispose();
                    picPreview.Image = null;
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (capturedImages.Count < 10)
            {
                MessageBox.Show("Cần ít nhất 10 ảnh để lưu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine($"Stundent Id: {_studentId}");

            this.Enabled = false;
            btnSave.Text = "Đang lưu...";
            btnSave.Enabled = false;
            try
            {
                var result = await _serviceHub.StudentFaceService.SaveFaceImagesAsync(_studentId, capturedImages);

                if (!result.success)
                {
                    MessageHelper.ShowError($"Lỗi lưu ảnh: {result.message}");
                    // xảy ra lỗi clear toàn bộ ảnh
                    capturedImages.Clear();
                    UpdateImageGallery();
                    UpdateImageStatus();

                    if (picPreview.Image != null)
                    {
                        picPreview.Image.Dispose();
                        picPreview.Image = null;
                    }
                    return;
                }

                MessageHelper.ShowSuccess("Lưu ảnh thành công");

                UpdateImageGallery();
                UpdateImageStatus();

                if (picPreview.Image != null)
                {
                    picPreview.Image.Dispose();
                    picPreview.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi lưu ảnh: {ex.Message}");
            }
            finally
            {
                this.Enabled = true;
                btnSave.Text = "💾 Lưu Ảnh";
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region helper method
        private void StartCamera()
        {
            if (cboCamera.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn camera!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int cameraIndex = cboCamera.SelectedIndex;
                capture = new VideoCapture(cameraIndex);

                if (!capture.IsOpened)
                {
                    MessageBox.Show("Không thể mở camera!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set camera properties for better quality
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);

                frameTimer.Start();
                isCameraRunning = true;

                btnStartCamera.Text = "⏸️ Dừng Camera";
                btnStartCamera.BackColor = Color.FromArgb(231, 76, 60);
                btnCapture.Enabled = true;
                btnAutoCapture.Enabled = true;
                lblCameraStatus.Text = "📹 Camera đang hoạt động";
                lblCameraStatus.ForeColor = Color.FromArgb(46, 204, 113);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể khởi động camera: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (picCamera.Image != null)
            {
                picCamera.Image.Dispose();
                picCamera.Image = null;
            }

            isCameraRunning = false;
            btnStartCamera.Text = "📷 Bật Camera";
            btnStartCamera.BackColor = Color.FromArgb(52, 152, 219);
            btnCapture.Enabled = false;
            btnAutoCapture.Enabled = false;
            lblCameraStatus.Text = "⏹️ Camera đã dừng";
            lblCameraStatus.ForeColor = Color.FromArgb(149, 165, 166);
        }

        private void UpdateImageGallery()
        {
            flowLayoutImages.Controls.Clear();

            for (int i = 0; i < capturedImages.Count; i++)
            {
                PictureBox pb = new PictureBox
                {
                    Width = 80,
                    Height = 80,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand,
                    Tag = i
                };

                using (MemoryStream ms = new MemoryStream(capturedImages[i]))
                {
                    pb.Image = Image.FromStream(ms);
                }

                pb.Click += ImageThumbnail_Click;
                flowLayoutImages.Controls.Add(pb);
            }
        }



        private void UpdateImageStatus()
        {
            int count = capturedImages.Count;

            if (count >= 10)
            {
                lblImageStatus.Text = $"✅ Đã có {count} ảnh (Đủ điều kiện)";
                lblImageStatus.ForeColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                lblImageStatus.Text = $"⚠️ Đã có {count}/10 ảnh (Tối thiểu 10 ảnh)";
                lblImageStatus.ForeColor = Color.FromArgb(243, 156, 18);
            }
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        #endregion




        
    }
}
