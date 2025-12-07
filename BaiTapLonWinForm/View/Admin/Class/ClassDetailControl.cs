using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Class
{
    public partial class ClassDetailControl : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _classId;

        // Danh sách ca học cố định (Hardcoded helper)
        private readonly List<(int, string)> mapShift = new List<(int, string)>()
        {
            (1, "Sáng (8:00 - 9:30)"),
            (2, "Sáng (9:30 - 11:00)"),
            (3, "Chiều (14:00 - 15:30)"),
            (4, "Chiều (15:30 - 17:00)"),
            (5, "Tối (18:00 - 19:30)"),
            (6, "Tối (19:30 - 21:00)")
        };

        public ClassDetailControl(ServiceHub serviceHub, int classId)
        {
            _serviceHub = serviceHub;
            _classId = classId;
            InitializeComponent();
            initialDetailClass();
        }

        private async void initialDetailClass()
        {
            try
            {
                // 1. GỌI SERVICE LẤY DỮ LIỆU
                // Lưu ý quan trọng: Trong ClassRepository.GetByIdAsync, 
                // bạn cần đảm bảo đã .Include(c => c.Course) và .Include(c => c.Teacher).ThenInclude(t => t.User)
                var (success, message, data) = await _serviceHub.ClassService.GetClassByIdAsync(_classId);

                if (!success || data == null)
                {
                    MessageHelper.ShowError(message);
                    return;
                }

                // 2. HIỂN THỊ THÔNG TIN CHUNG (HEADER & SIDEBAR)
                lblClassName.Text = data.ClassName;

                // --- Xử lý trạng thái (Badge) ---
                if (data.Status == -1)
                {
                    lblStatusBadge.Text = "Sắp mở";
                    lblStatusBadge.BackColor = Color.Orange;
                }
                else if (data.Status == 0)
                {
                    lblStatusBadge.Text = "Đang học";
                    lblStatusBadge.BackColor = Color.SeaGreen;
                }
                else
                {
                    lblStatusBadge.Text = "Đã kết thúc";
                    lblStatusBadge.BackColor = Color.Gray;
                }

                // --- Thông tin Giáo viên ---
                if (data.Teacher != null && data.Teacher.User != null)
                {
                    lblTeacherName.Text = $"{data.Teacher.User.LastName} {data.Teacher.User.FirstName}";
                    lblPhoneNumber.Text = data.Teacher.User.PhoneNumber;
                    lblTeacherEmail.Text = data.Teacher.User.Email;
                }
                else
                {
                    lblTeacherName.Text = "Chưa phân công";
                    lblPhoneNumber.Text = "---";
                    lblTeacherEmail.Text = "---";
                }

                lnkOnlineLink.Text = !string.IsNullOrEmpty(data.OnlineMeetingLink) ? data.OnlineMeetingLink : "---";
                lblNote.Text = !string.IsNullOrEmpty(data.Note) ? data.Note : "Không có ghi chú";

                // --- Sĩ số lớp ---
                int current = data.CurrentStudent ?? 0;
                int max = data.MaxStudent ?? 0;
                lblStudentCount.Text = $"{current}/{max} Học viên";

                // Thanh progress bar hiển thị sĩ số
                if (max > 0)
                {
                    double percent = (double)current / max;
                    if (percent > 1) percent = 1;

                    pnlProgressVal.Width = (int)(pnlProgressBg.Width * percent);
                    pnlProgressVal.BackColor = percent >= 0.9 ? Color.OrangeRed : Color.SeaGreen;
                }
                else
                {
                    pnlProgressVal.Width = 0;
                }

                // --- Ca học và Thời gian ---
                var shiftInfo = mapShift.FirstOrDefault(s => s.Item1 == data.Shift);
                lblShift.Text = shiftInfo != default ? shiftInfo.Item2 : "Ca khác";

                lblStartDate.Text = data.StartDate.ToString("dd/MM/yyyy");
                lblEndDate.Text = data.EndDate.ToString("dd/MM/yyyy");

                // 3. XỬ LÝ TÊN KHÓA HỌC (QUAN TRỌNG: N-1 Relationship)
                // Vì Class N - 1 Course, ta truy cập property Course (số ít)
                string courseName = "Chưa gán khóa học";

                if (data.Course != null)
                {
                    courseName = data.Course.CourseName;
                }

                // (Tùy chọn) Nếu bạn muốn hiển thị tên khóa học ở Header, hãy gán vào label tương ứng
                // lblCourseName.Text = courseName; 

                // 4. ĐỔ DỮ LIỆU VÀO DATA GRID VIEW (DANH SÁCH HỌC VIÊN)
                dgvStudents.Rows.Clear();

                if (data.StudentClasses != null && data.StudentClasses.Any())
                {
                    foreach (var sc in data.StudentClasses)
                    {
                        // Kiểm tra null an toàn
                        if (sc.Student != null && sc.Student.User != null)
                        {
                            var user = sc.Student.User;

                            // Thêm dòng mới vào bảng
                            dgvStudents.Rows.Add(
                                $"{user.LastName} {user.FirstName}",       // Cột 1: Họ tên
                                user.DateOfBirth.ToString("dd/MM/yyyy") ?? "N/A",  // Cột 2: Ngày sinh
                                user.PhoneNumber,                           // Cột 3: SĐT
                                user.Email,                                 // Cột 4: Email
                                courseName                                  // Cột 5: Tên khóa học (Dùng chung cho cả lớp)
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải dữ liệu lớp học: {ex.Message}");
            }
        }

        // --- Sự kiện thêm học viên vào lớp học ---
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Hiển thị UserControl chọn học viên (AddStudentToClass)
            pnlMain.Controls.Clear();
            var addView = new AddStudentToClass(_serviceHub, _classId)
            {
                Dock = DockStyle.Fill
            };

            // Khi đóng form thêm, tải lại danh sách
            addView.OnCloseRequired += (s, args) =>
            {
                ShowStudentList();
            };

            // Khi thêm thành công, tải lại danh sách
            addView.OnStudentsAdded += (s, args) =>
            {
                ShowStudentList();
            };

            pnlMain.Controls.Add(addView);
        }

        // --- Helper hiển thị lại danh sách ---
        private void ShowStudentList()
        {
            pnlMain.Controls.Clear();
            // Add lại các control gốc của UserControl này
            pnlMain.Controls.Add(this.dgvStudents);
            pnlMain.Controls.Add(this.lblListTitle);

            // Tải lại dữ liệu mới nhất
            this.initialDetailClass();
        }
    }
}