using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.interfaces;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class FaceAttendance : UserControl
    {
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer frameTimer;
        private bool isRecognizing = false;

        private readonly ServiceHub _serviceHub;


        private ClassSession _currentSession;
        private List<AttendanceRecord> _attendanceRecords = new List<AttendanceRecord>();
        private HashSet<int> _checkedInStudentIds = new HashSet<int>();

        public FaceAttendance(
            ServiceHub serviceHub
            )
        {
            InitializeComponent();
            _serviceHub = serviceHub;

            //LoadSessionData(sessionId);
            InitializeCamera();
            InitializeTimer();
        }

        private async void LoadSessionData(int sessionId)
        {
            try
            {
                _currentSession = await _serviceHub.ClassSessionService.GetSessionAsync(sessionId);

                if (_currentSession != null)
                {
                    lblSessionInfo.Text = $"Buổi {_currentSession.SessionNumber} - {_currentSession.SessionDate:dd/MM/yyyy} - {_currentSession.Class}";

                    // Load existing attendance records
                    var existingRecords = await _serviceHub.AttendanceService.GetSessionAttendanceAsync(sessionId);
                    foreach (var record in existingRecords)
                    {
                        _checkedInStudentIds.Add(record.StudentId);
                    }

                    UpdateAttendanceStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin buổi học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeCamera()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        using (VideoCapture testCapture = new VideoCapture(i))
                        {
                            if (testCapture.IsOpened)
                            {
                                cboCamera.Items.Add($"Camera {i}");
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (cboCamera.Items.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy camera nào!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnStartCamera.Enabled = false;
                    return;
                }

                cboCamera.SelectedIndex = 0;
                frame = new Mat();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo camera: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Bitmap bitmap = frame.ToImage<Bgr, byte>().ToBitmap();

                        if (picCamera.Image != null)
                            picCamera.Image.Dispose();

                        picCamera.Image = bitmap;

                        // Auto recognize if enabled
                        if (chkAutoRecognize.Checked && !isRecognizing)
                        {
                            await RecognizeFaceAsync();
                        }
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

                capture.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);

                frameTimer.Start();
                isCameraRunning = true;

                btnStartCamera.Text = "⏸️ Dừng Camera";
                btnStartCamera.BackColor = Color.FromArgb(231, 76, 60);
                btnRecognize.Enabled = true;
                chkAutoRecognize.Enabled = true;
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
            btnRecognize.Enabled = false;
            chkAutoRecognize.Enabled = false;
            chkAutoRecognize.Checked = false;
            lblCameraStatus.Text = "⏹️ Camera đã dừng";
            lblCameraStatus.ForeColor = Color.FromArgb(149, 165, 166);
        }

        private async void BtnRecognize_Click(object sender, EventArgs e)
        {
            await RecognizeFaceAsync();
        }

        private async Task RecognizeFaceAsync()
        {
            if (isRecognizing || picCamera.Image == null)
                return;

            isRecognizing = true;
            lblRecognitionStatus.Text = "🔍 Đang nhận diện...";
            lblRecognitionStatus.ForeColor = Color.FromArgb(243, 156, 18);

            try
            {
                Bitmap currentFrame = new Bitmap(picCamera.Image);
                byte[] imageBytes = BitmapToByteArray(currentFrame);

                var (success, studentId, confidence, message) =
                    await _serviceHub.CompreFaceApiService.RecognizeFaceAsync(imageBytes);

                if (success && studentId.HasValue)
                {
                    await ProcessRecognitionResultAsync(studentId.Value, confidence, imageBytes);
                }
                else
                {
                    lblRecognitionStatus.Text = $"❌ {message}";
                    lblRecognitionStatus.ForeColor = Color.FromArgb(231, 76, 60);

                    // Show temporary notification
                    ShowNotification("Không nhận diện được", message, false);
                }
            }
            catch (Exception ex)
            {
                lblRecognitionStatus.Text = $"❌ Lỗi: {ex.Message}";
                lblRecognitionStatus.ForeColor = Color.FromArgb(231, 76, 60);
            }
            finally
            {
                isRecognizing = false;

                // Delay before next recognition in auto mode
                if (chkAutoRecognize.Checked)
                {
                    await Task.Delay(2000); // 2 seconds delay
                }
            }
        }

        private async Task ProcessRecognitionResultAsync(int studentId, double confidence, byte[] imageBytes)
        {
            try
            {
                // Check if already checked in
                if (_checkedInStudentIds.Contains(studentId))
                {
                    lblRecognitionStatus.Text = "⚠️ Sinh viên đã điểm danh";
                    lblRecognitionStatus.ForeColor = Color.FromArgb(243, 156, 18);

                    var student = await _serviceHub.StudentService.GetStudentByIdAsync(studentId);
                    ShowNotification("Đã điểm danh", $"{student.Data.User.FirstName + student.Data.User.LastName} đã điểm danh rồi!", false);
                    return;
                }

                // Get student info
                var recognizedStudent = await _serviceHub.StudentService.GetStudentByIdAsync(studentId);
               
                string fullName = recognizedStudent.Data != null
                    ? recognizedStudent.Data.User.FirstName + " " + recognizedStudent.Data.User.LastName
                    : "Không xác định";

                if (recognizedStudent.Data == null)
                {
                    lblRecognitionStatus.Text = "❌ Không tìm thấy sinh viên";
                    lblRecognitionStatus.ForeColor = Color.FromArgb(231, 76, 60);
                    return;
                }

                // Save recognition image
                string imagePath = await SaveRecognitionImageAsync(studentId, imageBytes);

                var result = await _serviceHub.AttendanceService.TakeManualAttendanceAsync(studentId, _currentSession.SessionId, true);

                if (result.success)
                {
                    _checkedInStudentIds.Add(studentId);

                    // Add to list
                    AddAttendanceToList(recognizedStudent.Data, confidence, DateTime.Now);

                    // Update stats
                    UpdateAttendanceStats();

                    // Show success notification
                    lblRecognitionStatus.Text = $"✅ Điểm danh thành công: {fullName}";
                    lblRecognitionStatus.ForeColor = Color.FromArgb(46, 204, 113);

                    ShowNotification("Điểm danh thành công",
                        $"{fullName}\nĐộ tin cậy: {confidence:P0}", true);

                    // Play success sound (optional)
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý điểm danh: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> SaveRecognitionImageAsync(int studentId, byte[] imageBytes)
        {
            try
            {
                string folder = Path.Combine("AttendanceImages", _currentSession.SessionId.ToString());
                Directory.CreateDirectory(folder);

                string fileName = $"{studentId}_{DateTime.Now:yyyyMMddHHmmss}.jpg";
                string filePath = Path.Combine(folder, fileName);

                await File.WriteAllBytesAsync(filePath, imageBytes);

                return filePath;
            }
            catch
            {
                return null;
            }
        }

        private void AddAttendanceToList(Student student, double confidence, DateTime checkInTime)
        {
            string fullName = student.User.FirstName + " " + student.User.LastName;
            var item = new ListViewItem(new[]
            {
                checkInTime.ToString("HH:mm:ss"),
                $"{confidence:P0}",
                "Có mặt"
            });

            item.BackColor = Color.FromArgb(230, 247, 235);
            item.Tag = student.StudentId;

            lvAttendance.Items.Insert(0, item); // Add to top
        }

        private void UpdateAttendanceStats()
        {
            int totalPresent = _checkedInStudentIds.Count;
            lblTotalPresent.Text = totalPresent.ToString();

            // You can calculate total students in class here
            // lblAttendanceRate.Text = $"{(totalPresent * 100.0 / totalStudents):F1}%";
        }

        private void ShowNotification(string title, string message, bool success)
        {
            panelNotification.Visible = true;
            lblNotificationTitle.Text = title;
            lblNotificationMessage.Text = message;
            panelNotification.BackColor = success
                ? Color.FromArgb(46, 204, 113)
                : Color.FromArgb(231, 76, 60);

            // Auto hide after 3 seconds
            Timer hideTimer = new Timer { Interval = 3000 };
            hideTimer.Tick += (s, e) =>
            {
                panelNotification.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        //private async void BtnManualAttendance_Click(object sender, EventArgs e)
        //{
        //    // Open manual attendance form
        //    using (ManualAttendanceForm form = new ManualAttendanceForm(
        //        _studentService, _attendanceService, _currentSession.SessionId))
        //    {
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            // Reload attendance list
        //            await RefreshAttendanceListAsync();
        //        }
        //    }
        //}

        //private async Task RefreshAttendanceListAsync()
        //{
        //    try
        //    {
        //        lvAttendance.Items.Clear();
        //        _checkedInStudentIds.Clear();

        //        var records = await _attendanceService.GetBySessionIdAsync(_currentSession.Id);

        //        foreach (var record in records)
        //        {
        //            var student = await _studentService.GetByIdAsync(record.StudentId);

        //            if (student != null)
        //            {
        //                _checkedInStudentIds.Add(student.Id);
        //                AddAttendanceToList(student, record.Confidence ?? 0, record.CheckInTime ?? DateTime.Now);
        //            }
        //        }

        //        UpdateAttendanceStats();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi tải danh sách: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private  void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"DiemDanh_{_currentSession.SessionDate:yyyyMMdd}_Buoi{_currentSession.SessionNumber}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implement Excel export
                    MessageBox.Show("Chức năng export đang được phát triển!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi export: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChkAutoRecognize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRecognize.Checked)
            {
                lblRecognitionStatus.Text = "🔄 Chế độ nhận diện tự động";
                lblRecognitionStatus.ForeColor = Color.FromArgb(52, 152, 219);
            }
            else
            {
                lblRecognitionStatus.Text = "⏸️ Chế độ thủ công";
                lblRecognitionStatus.ForeColor = Color.FromArgb(149, 165, 166);
            }
        }
    }

    // Helper class for attendance record
    public class AttendanceRecord
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public DateTime CheckInTime { get; set; }
        public double Confidence { get; set; }
    }
}
