using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.implements; 
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
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer frameTimer;
        private bool isRecognizing = false;

        private readonly ServiceHub _serviceHub;

        // Key: StudentId, Value: Thời điểm check-in
        private Dictionary<int, DateTime> _checkedInCache = new Dictionary<int, DateTime>();

        public FaceAttendance(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            InitializeListView();
            this.Load += FaceAttendance_Load; 
            InitializeTimer();
        }

        private async void FaceAttendance_Load(object? sender, EventArgs e)
        {
            await InitializeCameraAsync();
        }

        #region initialize 

        private void InitializeListView()
        {
            //lvAttendance.View = System.Windows.Forms.View.Details;
            //lvAttendance.GridLines = true;
            //lvAttendance.FullRowSelect = true;

            //lvAttendance.Columns.Clear();
            //lvAttendance.Columns.Add("Thời gian", 100);
            //lvAttendance.Columns.Add("Họ và tên", 200);
            //lvAttendance.Columns.Add("Lớp học - Ca", 250);
            //lvAttendance.Columns.Add("Trạng thái", 150);
            //lvAttendance.Columns.Add("Ghi chú", 100);

        }

        private async Task InitializeCameraAsync()
        {
            cboCamera.Items.Clear();
            cboCamera.Enabled = false;
            btnStartCamera.Enabled = false;
            lblCameraStatus.Text = "⏳ Đang tìm camera...";

            try
            {
                var cameras = await Task.Run(() =>
                {
                    var list = new List<string>();
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            using (var temp = new VideoCapture(i))
                            {
                                if (temp.IsOpened) list.Add($"Camera {i}");
                            }
                        }
                        catch {  }
                    }
                    return list;
                });

                if (cameras.Count > 0)
                {
                    foreach (var cam in cameras) cboCamera.Items.Add(cam);
                    cboCamera.SelectedIndex = 0;
                    btnStartCamera.Enabled = true;
                    lblCameraStatus.Text = "⚫ Camera sẵn sàng";
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

        #region recognize face and result

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

        private async void ProcessCheckInResult(ReceptionCheckInResult result)
        {
            // Cập nhật trạng thái text
            lblRecognitionStatus.Text = result.Success ? "✅ " + result.Message : "❌ " + result.Message;
            lblRecognitionStatus.ForeColor = result.Success ? Color.Green : Color.Red;

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
                AddRecordToDataGridView(result);

                // Cập nhật số lượng
                lblTotalPresent.Text = _checkedInCache.Count.ToString();
                var studentResult = await _serviceHub.StudentService.GetAllStudentsAsync();

                if (studentResult.Success && studentResult.Data != null)
                {
                    int totalStudent = studentResult.Data.Count();

                    if (totalStudent > 0)
                    {
                        double rate = (double)_checkedInCache.Count / totalStudent;

                        lblAttendanceRate.Text = rate.ToString("P0");
                    }
                    else
                    {
                        lblAttendanceRate.Text = "0%";
                    }
                }
                else
                {
                    lblAttendanceRate.Text = "N/A";
                    MessageBox.Show(studentResult.Message);
                }
            }
        }

        private void AddRecordToDataGridView(ReceptionCheckInResult result)
        {
            // Đảm bảo thao tác trên UI Thread
            if (dgvStudentAttendance.InvokeRequired)
            {
                dgvStudentAttendance.Invoke(new Action(() => AddRecordToDataGridView(result)));
                return;
            }

            string time = result.CheckInTime?.ToString("HH:mm:ss") ?? DateTime.Now.ToString("HH:mm:ss");
            string studentName = result.StudentName;
            string classAndShift = $"{result.ClassName} ({result.ShiftName})";
            string note = result.isLate ? "Đi muộn" : "";
            string status = $"Có mặt";
            string confidence = result.confidence.ToString("P0");
            dgvStudentAttendance.Rows.Insert(0,
                time,
                studentName,
                classAndShift,
                confidence,
                status + $"({note})"
            );

            DataGridViewRow row = dgvStudentAttendance.Rows[0];

            row.DefaultCellStyle.Font = new Font(dgvStudentAttendance.Font, FontStyle.Bold);

            if (result.isLate)
            {
                row.DefaultCellStyle.ForeColor = Color.OrangeRed;
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
            }

            dgvStudentAttendance.FirstDisplayedScrollingRowIndex = 0;
        }



        private void ShowNotification(string title, string message, bool success)
        {
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

        #endregion

        #region handle events
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

                        var oldImg = picCamera.Image;
                        picCamera.Image = bitmap;
                        if (oldImg != null) oldImg.Dispose();

                        if (chkAutoRecognize.Checked && !isRecognizing)
                        {
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

        private async void BtnRecognize_Click(object sender, EventArgs e)
        {
            await RecognizeFaceAsync();
        }

        private void ChkAutoRecognize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRecognize.Checked)
            {
                lblRecognitionStatus.Text = "🔄 Chế độ tự động đang chạy...";
                btnRecognize.Enabled = false;
            }
            else
            {
                lblRecognitionStatus.Text = "⏸️ Chế độ thủ công";
                btnRecognize.Enabled = true;
            }
        }
        #endregion

        #region helper method
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
        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        #endregion

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            StopCamera(); // Tắt camera
            if (frame != null) frame.Dispose(); // Xóa bộ nhớ đệm
        }
    }
}