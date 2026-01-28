using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Students
{
    public partial class StudentDetailForm : Form
    {
        private readonly int _studentId;
        private readonly ServiceHub _serviceHub;
        private Dictionary<int, (string Text, Color Color)> statusMap = new Dictionary<int, (string Text, Color Color)>
        {
            { 1, ("Đã kết thúc", Color.Gray) },
            { 0, ("Đang học", Color.SeaGreen) },
            { -1, ("Sắp mở", Color.Orange) }
        };

        // Constructor
        public StudentDetailForm(int studentId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _studentId = studentId;
            _serviceHub = serviceHub;

            // Bo tròn Avatar
            MakeCircular(picAvatar);

            // Thêm bóng đổ (Shadow) cho Form nếu muốn đẹp hơn (tùy chọn)
            this.Padding = new Padding(2);
            this.BackColor = Color.FromArgb(52, 152, 219); // Viền mỏng màu xanh

            this.Load += StudentDetailForm_Load;
        }
        

        #region load data
        private async void StudentDetailForm_Load(object sender, EventArgs e)
        {
            await LoadData();
            await LoadBestAvatarAsync();
        }


        private async Task LoadData()
        {
            try
            {
                var result = await _serviceHub.StudentService.GetStudentByIdAsync(_studentId);
                if (!result.Success || result.Data == null)
                {
                    MessageBox.Show("Không tìm thấy học viên!");
                    this.Close();
                    return;
                }

                var st = result.Data;
                var u = st.User;

                // --- 1. Fill thông tin ---
                lblFullName.Text = $"{u.FirstName} {u.LastName}".ToUpper();
                lblStudentId.Text = $"Mã HV: {st.StudentId}";
                lblEmail.Text = u.Email;
                lblDob.Text = Convert.ToDateTime(u.DateOfBirth)
                      .ToString("dd/MM/yyyy");

                lblGender.Text = (u.Gender == true) ? "Nam" : "Nữ";
                lblPhone.Text = string.IsNullOrEmpty(u.PhoneNumber) ? "Chưa cập nhật" : u.PhoneNumber;
                lblAddress.Text = string.IsNullOrEmpty(u.Address) ? "Chưa cập nhật" : u.Address;
                lblParentPhone.Text = string.IsNullOrEmpty(st.PhoneNumberOfParents) ? "Chưa cập nhật" : st.PhoneNumberOfParents;
                lblJoinDate.Text = string.IsNullOrEmpty(u.CreateAt.ToString()) ? "chưa cập nhật" : DateOnly.FromDateTime(u.CreateAt.Value).ToString();
                // Status
                if (u.IsActive == true)
                {
                    lblStatusUser.Text = "Đang học";
                    lblStatusUser.BackColor = Color.FromArgb(46, 204, 113); // Green
                }
                else
                {
                    lblStatusUser.Text = "Đã nghỉ";
                    lblStatusUser.BackColor = Color.FromArgb(231, 76, 60); // Red
                }

                flowLayoutPanelClasses.Controls.Clear();

                if (st.StudentClasses != null && st.StudentClasses.Count > 0)
                {
                    foreach (var sc in st.StudentClasses)
                    {
                        if (sc.Class == null) continue;
                        AddClassCard(sc.Class);
                    }
                }
                else
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Học viên chưa đăng ký lớp nào.";
                    lblEmpty.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                    lblEmpty.ForeColor = Color.Gray;
                    lblEmpty.AutoSize = true;
                    flowLayoutPanelClasses.Controls.Add(lblEmpty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            }
        }


        private void AddClassCard(Models.Class classInfo)
        {
            Panel pnlCard = new Panel();
            pnlCard.Size = new Size(800, 80);
            pnlCard.BackColor = Color.FromArgb(248, 249, 249);
            pnlCard.Margin = new Padding(0, 0, 0, 15);

            Panel pnlAccent = new Panel();
            pnlAccent.Dock = DockStyle.Left;
            pnlAccent.Width = 5;
            pnlAccent.BackColor = Color.FromArgb(52, 152, 219);
            pnlCard.Controls.Add(pnlAccent);

            // Tên lớp
            Label lblClassName = new Label();
            lblClassName.Text = classInfo.ClassName;
            lblClassName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblClassName.ForeColor = Color.FromArgb(44, 62, 80);
            lblClassName.Location = new Point(20, 10);
            lblClassName.AutoSize = true;
            pnlCard.Controls.Add(lblClassName);

            Label lblCourse = new Label();
            lblCourse.Text = classInfo.Course?.CourseName ?? "Khóa học không xác định";
            lblCourse.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblCourse.ForeColor = Color.DimGray;
            lblCourse.Location = new Point(20, 40);
            lblCourse.AutoSize = true;
            pnlCard.Controls.Add(lblCourse);

            Label lblStatus = new Label();
            int key = classInfo.Status ?? -1;

            var status = statusMap.ContainsKey(key)
                        ? statusMap[key]
                        : statusMap[-1];
            lblStatus.Text = status.Text;
            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.ForeColor = status.Color;
            lblStatus.Location = new Point(700, 25);
            lblStatus.AutoSize = true;
            pnlCard.Controls.Add(lblStatus);

            flowLayoutPanelClasses.Controls.Add(pnlCard);
        }

        private async Task LoadBestAvatarAsync()
        {
            try
            {

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                // Tạo đường dẫn đến thư mục ảnh của học viên: FaceImages/{StudentId}
                // Ví dụ: .../FaceImages/4004
                string studentFolder = Path.Combine(baseDir, "FaceImages", _studentId.ToString());

                // Đường dẫn file Cache
                string cachedAvatarPath = Path.Combine(studentFolder, "best_avatar_cached.jpg");


                if (File.Exists(cachedAvatarPath))
                {
                    using (var stream = new FileStream(cachedAvatarPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        picAvatar.Image = Image.FromStream(stream);
                    }
                    return;
                }

                if (!Directory.Exists(studentFolder))
                {
                    picAvatar.Image = Properties.Resources.default_user;
                    return;
                }

                var files = Directory.GetFiles(studentFolder, "*.jpg");

                if (files.Length == 0)
                {
                    picAvatar.Image = Properties.Resources.default_user;
                    return;
                }

                List<byte[]> rawImages = new List<byte[]>();

                foreach (var filePath in files.Take(10))
                {
                    if (filePath.Contains("best_avatar_cached")) continue;

                    byte[] bytes = await File.ReadAllBytesAsync(filePath);
                    rawImages.Add(bytes);
                }

                var bestAvatarBytes = await _serviceHub.CompreFaceApiService.FindBestAvatarAsync(rawImages);

                if (bestAvatarBytes != null)
                {
                    using (var ms = new MemoryStream(bestAvatarBytes))
                    {
                        picAvatar.Image = Image.FromStream(ms);
                        picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    await File.WriteAllBytesAsync(cachedAvatarPath, bestAvatarBytes);
                }
                else
                {
                    // Nếu AI không tìm ra ảnh nào ra hồn
                    picAvatar.Image = Properties.Resources.default_user;
                }
            }
            catch (Exception ex)
            {
                picAvatar.Image = Properties.Resources.default_user;
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region helper method
        private void MakeCircular(PictureBox box)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, box.Width, box.Height);
            Region rg = new Region(gp);
            box.Region = rg;
        }
        #endregion

    }
}
