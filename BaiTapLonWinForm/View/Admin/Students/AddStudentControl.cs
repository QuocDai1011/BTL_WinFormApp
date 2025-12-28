using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.interfaces;
using BaiTapLonWinForm.Utils;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class AddStudentControl : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer frameTimer;
        private List<byte[]> capturedImages = new List<byte[]>();



        public List<byte[]> FaceImages => capturedImages;
        public event EventHandler CloseRequested;
        public AddStudentControl(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            this.Load += AddStudentControl_Load;
            InitializeTimer();
            SetupValidationEvents();
        }

        private async void AddStudentControl_Load(object? sender, EventArgs e)
        {
            await InitializeCameraAsync();

        }

        private void SetupValidationEvents()
        {
            // Validate ngay khi gõ phím
            txtFirstName.TextChanged += (s, e) => CheckFirstName();
            txtLastName.TextChanged += (s, e) => CheckLastName();
            txtEmail.TextChanged += (s, e) => CheckEmail();
            txtPhone.TextChanged += (s, e) => CheckPhone();
            txtPhoneNumberOfParent.TextChanged += (s, e) => CheckParentPhone();
            cboGender.SelectedIndexChanged += (s, e) => CheckGender();
        }

        private bool CheckFirstName()
        {
            return ValidateInput(txtFirstName, lblErrFirstName,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[\p{L}\s]+$"),
                "Họ không được để trống và không chứa số.");
        }

        private bool CheckLastName()
        {
            return ValidateInput(txtLastName, lblErrLastName,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[\p{L}\s]+$"),
                "Tên không được để trống và không chứa số.");
        }

        private bool CheckEmail()
        {
            // Check regex email
            return ValidateInput(txtEmail, lblErrEmail,
                t => !string.IsNullOrWhiteSpace(t) && Regex.IsMatch(t, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
                "Email không đúng định dạng.");
        }

        private bool CheckPhone()
        {
            // Check số và độ dài >= 10
            return ValidateInput(txtPhone, lblErrPhone,
                t => !string.IsNullOrWhiteSpace(t) && t.All(char.IsDigit) && t.Length >= 10,
                "SĐT phải là số và đủ 10 ký tự.");
        }

        private bool CheckParentPhone()
        {
            return ValidateInput(txtPhoneNumberOfParent, lblErrParentPhone,
                t => !string.IsNullOrWhiteSpace(t) && t.All(char.IsDigit) && t.Length >= 10,
                "SĐT phụ huynh không hợp lệ.");
        }

        private bool CheckGender()
        {
            if (cboGender.SelectedItem == null)
            {
                lblErrGender.Text = "Vui lòng chọn giới tính.";
                lblErrGender.Visible = true;
                return false;
            }
            lblErrGender.Visible = false;
            return true;
        }

        // Hàm Helper: Check điều kiện -> Hiện/Ẩn Label
        private bool ValidateInput(TextBox txt, Label lbl, Func<string, bool> rule, string errMsg)
        {
            if (!rule(txt.Text.Trim()))
            {
                lbl.Text = errMsg;
                lbl.Visible = true;
                return false;
            }
            lbl.Visible = false;
            return true;
        }

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

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (capturedImages.Count < 10)
            {
                var confirm = MessageBox.Show(
                    $"Bạn chỉ có {capturedImages.Count} ảnh. Cần ít nhất 10 ảnh để nhận diện chính xác!\n\n" +
                    "Bạn có muốn tiếp tục không?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                    return;
            }

            string passwordHassing = BCrypt.Net.BCrypt.HashPassword("12345678");

            var newUser = new User
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                Address = txtAddress.Text.Trim(),
                Gender = cboGender.SelectedIndex == 0 ? true : false,
                PhoneNumber = txtPhone.Text.Trim(),
                PasswordHashing = passwordHassing,
                IsActive = true,
                RoleId = 3
            };

            var newStudent = new Student
            {
                PhoneNumberOfParents = txtPhoneNumberOfParent.Text.Trim()
            };

            var result = await _serviceHub.StudentService.RegisterStudentFullAsync(newUser, newStudent, capturedImages);

            if (!result.Success)
            {
                MessageHelper.ShowError(result.Message);
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

            MessageHelper.ShowSuccess("Thêm học viên thành công!");
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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            bool isAllValid = CheckFirstName() & CheckLastName() & CheckEmail() &
                              CheckPhone() & CheckParentPhone() & CheckGender();

            if (!isAllValid)
            {
                MessageHelper.ShowWarning("Vui lòng nhập đầy đủ và chính xác thông tin trước khi tiếp tục.");
                return;
            }

            panelStep1.Visible = false;
            panelStep2.Visible = true;


            btnNext.Visible = false;
            btnBack.Visible = true;
            btnSave.Visible = true;

            lblInstruction.Text = "💡 Bước 2: Chụp ảnh khuôn mặt để hệ thống nhận diện (Tối thiểu 10 ảnh).";


        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // 1. Chuyển về Step 1
            panelStep2.Visible = false;
            panelStep1.Visible = true;

            // 2. Đổi nút bấm
            btnNext.Visible = true;
            btnBack.Visible = false;
            btnSave.Visible = false;

            // 3. Update hướng dẫn
            lblInstruction.Text = "💡 Bước 1: Vui lòng điền đầy đủ thông tin sinh viên trước khi chụp ảnh.";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            StopCamera(); 
            if (frame != null) frame.Dispose(); 
        }
    }
}
