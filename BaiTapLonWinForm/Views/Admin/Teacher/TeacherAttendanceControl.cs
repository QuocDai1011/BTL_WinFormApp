using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BaiTapLonWinForm.View.Admin.Teacher
{
    public partial class TeacherAttendanceControl : UserControl
    {
        private bool isRecognizing = false;
        private readonly ServiceHub _serviceHub;

        // Key: teacherId, Value: Thời điểm check-in để chống spam
        private Dictionary<int, DateTime> _checkedInCache = new Dictionary<int, DateTime>();

        private bool isCameraRunning = false;
        private VideoCapture capture;
        private Mat frame;
        private System.Windows.Forms.Timer frameTimer;

        public TeacherAttendanceControl(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            InitializeListView();
            this.Load += TeacherAttendance_Load;
            InitializeTimer();
        }

        private async void TeacherAttendance_Load(object? sender, EventArgs e)
        {
            await InitializeCameraAsync();
        }

        #region Initialize
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
                        catch { }
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

        #endregion

        #region handle event
        private void ChkAutoRecognize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRecognize.Checked)
            {
                lblRecognitionStatus.Text = "🔄 Chế độ tự động đang chạy...";
                lblRecognitionStatus.ForeColor = Color.Blue;
                btnRecognize.Enabled = false; // Tắt nút thủ công
            }
            else
            {
                lblRecognitionStatus.Text = "⏸️ Chế độ thủ công";
                lblRecognitionStatus.ForeColor = Color.Black;
                btnRecognize.Enabled = true; // Bật nút thủ công
            }
        }


        private async void BtnRecognize_Click(object sender, EventArgs e)
        {
            await RecognizeFaceAsync();
        }


        private void BtnStartCamera_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning) StartCamera();
            else StopCamera();
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

        #endregion

        #region recognize face and result
        private async Task RecognizeFaceAsync()
        {
            if (isRecognizing || picCamera.Image == null) return;

            isRecognizing = true;

            if (!chkAutoRecognize.Checked)
            {
                lblRecognitionStatus.Text = "🔍 Đang nhận diện...";
                lblRecognitionStatus.ForeColor = Color.Orange;
            }

            try
            {
                Bitmap currentFrame = new Bitmap(picCamera.Image);
                byte[] imageBytes = BitmapToByteArray(currentFrame);

                // Gọi Service chấm công Teacher
                var result = await _serviceHub.TeacherAttendanceService.CheckInAsync(imageBytes);

                ProcessCheckInResult(result);
            }
            catch (Exception ex)
            {
                ShowNotification("Lỗi hệ thống", ex.Message, false);
            }
            finally
            {
                // Delay: Auto thì chậm lại chút (2s), Thủ công thì nhanh (0.5s)
                if (chkAutoRecognize.Checked) await Task.Delay(2000);
                else await Task.Delay(500);

                isRecognizing = false;
            }
        }

        private async void ProcessCheckInResult(TeacherCheckInResult result)
        {
            // Hiển thị trạng thái bên dưới camera
            lblRecognitionStatus.Text = result.Success ? "✅ " + result.Message : "❌ " + result.Message;
            lblRecognitionStatus.ForeColor = result.Success ? Color.Green : Color.Red;

            ShowNotification(
                result.Success ? "Thành công" : "Thất bại",
                result.Message,
                result.Success
            );

            if (result.Success)
            {
                // Chống spam: Nếu vừa check-in trong 15 giây thì không add thêm dòng vào bảng
                if (_checkedInCache.ContainsKey(result.teacherId))
                {
                    var lastTime = _checkedInCache[result.teacherId];
                    if ((DateTime.Now - lastTime).TotalSeconds < 15) return;
                }

                _checkedInCache[result.teacherId] = DateTime.Now;
                AddRecordToDataGridView(result);

                lblTotalPresent.Text = _checkedInCache.Count.ToString();
                var teacherResult = await _serviceHub.TeacherService.GetAllTeachersAsync();

                if (teacherResult.Success && teacherResult.Data != null)
                {
                    int totalTeachers = teacherResult.Data.Count();

                    if (totalTeachers > 0)
                    {
                        double rate = (double)_checkedInCache.Count / totalTeachers;

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
                    MessageBox.Show(teacherResult.Message);
                }

            }
        }

        private void AddRecordToDataGridView(TeacherCheckInResult result)
        {
            string time = result.CheckInTime?.ToString("HH:mm:ss") ?? DateTime.Now.ToString("HH:mm:ss");
            string teacherId = result.teacherId.ToString() ?? "N/A";
            string teacherName = result.teacherName;
            string classInfo = $"{result.ClassName} ({result.ShiftName})";
            string confidence = result.confidence.ToString("P0");

            dgvAttendance.Rows.Insert(0,
                time,
                teacherId,
                teacherName,
                classInfo,
                confidence,
                "Có mặt"
            );

            DataGridViewRow row = dgvAttendance.Rows[0];

            if (result.isLate)
            {
                row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                row.Cells["colStatus"].Value = "Có mặt (Muộn)";
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
            }

            row.DefaultCellStyle.Font = new Font(dgvAttendance.Font, FontStyle.Bold);

            dgvAttendance.FirstDisplayedScrollingRowIndex = 0;
        }


        private void ShowNotification(string title, string message, bool success)
        {
            panelNotification.Visible = true;
            panelNotification.BackColor = success ? Color.FromArgb(220, 255, 220) : Color.FromArgb(255, 220, 220);
            lblNotificationTitle.Text = title;
            lblNotificationTitle.ForeColor = success ? Color.Green : Color.Red;
            lblNotificationMessage.Text = message;
            lblNotificationMessage.ForeColor = Color.Black;

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

        #region helper method
        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
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

        #endregion

        

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            StopCamera();
            if (frame != null) frame.Dispose();
        }
    }
}