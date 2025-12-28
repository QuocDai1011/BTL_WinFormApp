using BaiTapLonWinForm.Models;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Teacher
{
    public partial class AddTeacher : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private Models.Teacher _teacher;
        private bool _isEditMode;
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer frameTimer;
        private List<byte[]> capturedImages = new List<byte[]>();
        public List<byte[]> FaceImages => capturedImages;

        public event EventHandler CloseRequested;
        public AddTeacher(ServiceHub serviceHub, Models.Teacher teacher = null)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            _teacher = teacher;
            _isEditMode = _teacher != null;
            LoadData();
            InitializeValidationEvents();
            this.Load += AddTeacher_Load;
            InitializeTimer();
        }

        private async void AddTeacher_Load(object? sender, EventArgs e)
        {
            await InitializeCameraAsync();
        }


        #region validate input
        private void InitializeValidationEvents()
        {
            // TextChanged cho TextBox
            txtFirstName.TextChanged += (s, e) => ValidateFirstName();
            txtLastName.TextChanged += (s, e) => ValidateLastName();
            txtEmail.TextChanged += (s, e) => ValidateEmail();
            txtPhoneNumber.TextChanged += (s, e) => ValidatePhone();

            // ValueChanged cho số và ngày tháng
            nudSalary.ValueChanged += (s, e) => ValidateSalary();
            nudExperienceYear.ValueChanged += (s, e) => ValidateExperience();
            dtpDateOfBirth.ValueChanged += (s, e) => ValidateDob();

            // SelectedIndexChanged cho ComboBox
            cboGender.SelectedIndexChanged += (s, e) => ValidateGender();
        }
        private void SetError(Label label, string message)
        {
            label.Text = message;
            label.ForeColor = Color.Red;
            label.Visible = true;
        }

        private void ClearError(Label label)
        {
            label.Text = "";
            label.Visible = false;
        }

        private bool ValidateFirstName()
        {
            string input = txtFirstName.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                SetError(lblErrorFirstName, "Họ không được để trống");
                return false;
            }
            if (!Regex.IsMatch(input, @"^[\p{L}\s]+$"))
            {
                SetError(lblErrorFirstName, "Họ không được chứa số hoặc ký tự đặc biệt");
                return false;
            }
            ClearError(lblErrorFirstName);
            return true;
        }

        private bool ValidateLastName()
        {
            string input = txtLastName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                SetError(lblErrorLastName, "Tên không được để trống");
                return false;
            }
            if (!Regex.IsMatch(input, @"^[\p{L}\s]+$"))
            {
                SetError(lblErrorLastName, "Tên không được chứa số hoặc ký tự đặc biệt");
                return false;
            }
            ClearError(lblErrorLastName);
            return true;
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                SetError(lblErrorEmail, "Email không được để trống");
                return false;
            }
            // Regex check email chuẩn
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                SetError(lblErrorEmail, "Email không đúng định dạng");
                return false;
            }
            ClearError(lblErrorEmail);
            return true;
        }

        private bool ValidatePhone()
        {
            string phone = txtPhoneNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                SetError(lblErrorPhoneNumber, "Số điện thoại không được để trống");
                return false;
            }
            // Regex check số điện thoại (10-11 số)
            if (!Regex.IsMatch(phone, @"^0\d{9,10}$"))
            {
                SetError(lblErrorPhoneNumber, "SĐT phải bắt đầu bằng 0 và có 10-11 số");
                return false;
            }
            ClearError(lblErrorPhoneNumber);
            return true;
        }

        private bool ValidateDob()
        {

            var age = DateTime.Now.Year - dtpDateOfBirth.Value.Year;
            if (dtpDateOfBirth.Value.Date > DateTime.Now.AddYears(-age)) age--;

            if (age < 18)
            {
                SetError(lblErrorDob, "Giáo viên phải từ 18 tuổi trở lên");
                return false;
            }
            ClearError(lblErrorDob);
            return true;
        }

        private bool ValidateGender()
        {
            if (cboGender.SelectedIndex == -1)
            {
                SetError(lblErrorGender, "Vui lòng chọn giới tính");
                return false;
            }
            ClearError(lblErrorGender);
            return true;
        }

        private bool ValidateSalary()
        {
            if (nudSalary.Value >= 0 && nudSalary.Value <= 100000000)
            {
                ClearError(lblErrorSalary);
                return true;
            }
            SetError(lblErrorSalary, "Lương phải lớn hơn 0 và nhỏ hơn 100.000.000VNĐ");
            return false;
        }

        private bool ValidateExperience()
        {
            if (nudExperienceYear.Value >= 0 && nudExperienceYear.Value <= 50)
            {
                ClearError(lblErrorExperience);
                return true;
            }
            SetError(lblExperienceYear, "Số năm kinh nghiệm không thể quá 50 năm");
            return false;
        }

        // Hàm kiểm tra tổng hợp tất cả
        private bool ValidateAll()
        {
            bool isValid = true;
            // Dùng toán tử & (không phải &&) để chạy hết các hàm validate 
            // nhằm hiển thị lỗi cho TẤT CẢ các trường sai cùng lúc
            isValid &= ValidateFirstName();
            isValid &= ValidateLastName();
            isValid &= ValidateEmail();
            isValid &= ValidatePhone();
            isValid &= ValidateDob();
            isValid &= ValidateGender();
            isValid &= ValidateSalary();
            isValid &= ValidateExperience();
            return isValid;
        }

        #endregion

        #region load, clear, builder data
        private void LoadData()
        {
            ClearError(lblErrorFirstName);
            ClearError(lblErrorLastName); // LastName error
            ClearError(lblErrorEmail);
            ClearError(lblErrorPhoneNumber);
            ClearError(lblErrorDob);
            ClearError(lblErrorGender);
            ClearError(lblErrorSalary);
            ClearError(lblErrorExperience);

            if (_isEditMode)
            {
                txtFirstName.Text = _teacher.User.FirstName;
                txtLastName.Text = _teacher.User.LastName;
                txtEmail.Text = _teacher.User.Email;
                txtPhoneNumber.Text = _teacher.User.PhoneNumber;
                txtAddress.Text = _teacher.User.Address ?? "N/A";
                dtpDateOfBirth.Value = _teacher.User.DateOfBirth.ToDateTime(new TimeOnly(0, 0));
                nudSalary.Text = _teacher.Salary.HasValue ? _teacher.Salary.Value.ToString() : string.Empty;
                nudExperienceYear.Text = _teacher.ExperienceYear.HasValue ? _teacher.ExperienceYear.Value.ToString() : string.Empty;
                cboGender.Text = _teacher.User.Gender == true ? "Nam" : "Nữ";

                lblTitle.Text = "✨ CẬP NHẬT THÔNG TIN GIẢNG VIÊN";
                panelInfoBox.Visible = false;

                btnSave.Visible = true;
                btnNext.Visible = false;
            }
            else
            { 
                panelInfoBox.Visible = true;
                lblTitle.Text = "✨ THÊM MỚI GIẢNG VIÊN";

                cboGender.SelectedIndex = 0;
                btnSave.Visible = false;
                btnNext.Visible = true;
            }
        }

        private void clearData()
        {
            txtAddress.Clear();
            txtEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            nudExperienceYear.Value = 1;
            nudSalary.Value = 10000000;
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-18); // Reset về tuổi hợp lệ
            // Xóa sạch thông báo lỗi
            ClearError(lblErrorFirstName);
            ClearError(lblErrorLastName);
            ClearError(lblErrorEmail);
            ClearError(lblErrorPhoneNumber);
            ClearError(lblErrorDob);
            ClearError(lblErrorGender);
            ClearError(lblErrorSalary);
        }


        private (Models.Teacher, User) builderData()
        {
            if (_isEditMode)
            {
                _teacher.Salary = (int)nudSalary.Value;
                _teacher.ExperienceYear = (int)nudExperienceYear.Value;
                _teacher.User.FirstName = txtFirstName.Text.Trim();
                _teacher.User.LastName = txtLastName.Text.Trim();
                _teacher.User.Email = txtEmail.Text.Trim();
                _teacher.User.PhoneNumber = txtPhoneNumber.Text.Trim();
                _teacher.User.Address = txtAddress.Text.Trim();
                _teacher.User.DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);

                return (_teacher, null);
            }
            else
            {
                string passwordHasshing = BCrypt.Net.BCrypt.HashPassword("12345678");
                User user = new Models.User
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                    PasswordHashing = passwordHasshing,
                    IsActive = true,
                    RoleId = 2
                };

                Models.Teacher teacher = new Models.Teacher
                {
                    Salary = (int)nudSalary.Value,
                    ExperienceYear = (int)nudExperienceYear.Value,
                    
                };
                return (teacher, user);
            }
        }

        #endregion

        #region handle event button

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageHelper.ShowWarning("Vui lòng kiểm tra lại thông tin nhập liệu.");
                return;
            }

            (Models.Teacher teacher, User user) = builderData();

            if (teacher == null)
            {
                MessageHelper.ShowWarning("Không có dữ liệu để lưu");
                return;
            }

            // chỉnh sửa giảng viên
            if (_isEditMode)
            {
                var result = await _serviceHub.TeacherService.UpdateTeacherAsync(_teacher);
                if (result.Success)
                {
                    MessageHelper.ShowSuccess("Cập nhật giảng viên thành công.");
                    CloseRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageHelper.ShowError($"Cập nhật giảng viên thất bại. Lỗi: {result.Message}");
                    return;
                }
            }
            // thêm giảng viên
            else
            {
                var result = await _serviceHub.TeacherService.CreateTeacherAsync(user, teacher, capturedImages);


                if (result.Success)
                {
                    MessageHelper.ShowSuccess("Thêm giáo viên thành công.");
                }
                else
                {
                    MessageHelper.ShowError($"Thêm giáo viên thất bại. Lỗi: {result.Message}");
                    return;
                }
            }
            clearData();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageHelper.ShowWarning("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!_isEditMode)
            {
                panelStep1.Visible = false;
                panelStep2.Visible = true;
                btnNext.Visible = false;
                btnSave.Visible = true;
                btnBack.Visible = true;
            }
            btnSave.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                btnBack.Visible = false;
                panelStep1.Visible = true;
                panelStep2.Visible = false;
                btnSave.Visible = false;
                btnNext.Visible = true;
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

        

        #endregion


        #region initial camera
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
        #endregion

        #region function utils

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
