using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Class
{
    public partial class ClassDetailControl : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _classId;
        private bool _isAddFeature;
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

        #region Init data 
        private async void initialDetailClass()
        {
            try
            {

                var (success, message, data) = await _serviceHub.ClassService.GetClassByIdAsync(_classId);

                if (!success || data == null)
                {
                    MessageHelper.ShowError(message);
                    return;
                }
                // thông tin chung của lớp học
                initGeneralInformation(data);

                // load dữ liệu vào dataGridView
                initDataGridView(data);

                // load dữ liệu cho tab chỉnh sửa
                initDataForTabUpdate(data);

                // load dữ liệu cho ca học
                initCboShift(data);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải dữ liệu lớp học: {ex.Message}");
            }
        }

        private void initGeneralInformation(Models.Class data)
        {
            lblClassAndCouse.Text = $" {data.ClassName} -  {data.Course?.CourseName}";


            if (data.Teacher != null && data.Teacher.User != null)
            {
                lblTeacherName.Text = $"{data.Teacher.User.FirstName} {data.Teacher.User.LastName}";
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

            var shiftItem = mapShift.FirstOrDefault(s => s.Item1 == data.Shift);
            string shiftDesc = shiftItem.Item2 ?? "Chưa xếp lịch"; 


            string shiftInfo = string.Join("\n", data.SchoolDays.Select(sd => $"{sd.DayOfWeek}: {shiftDesc}"));

 
            lblShift.Text = string.IsNullOrEmpty(shiftInfo) ? "Chưa có lịch học" : shiftInfo;

            lblStartDate.Text = data.StartDate.ToString("dd/MM/yyyy");
            lblEndDate.Text = data.EndDate.ToString("dd/MM/yyyy");

            string courseName = "Chưa gán khóa học";

            if (data.Course != null)
            {
                courseName = data.Course.CourseName;
            }
        }


        private void initDataGridView(Models.Class data)
        {
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
                        int rowIndex = dgvStudents.Rows.Add(
                            $"{user.FirstName} {user.LastName}",
                            user.DateOfBirth.ToString("dd/MM/yyyy") ?? "N/A",
                            user.PhoneNumber,
                            user.Email
                            );

                        dgvStudents.Rows[rowIndex].Tag = sc.Student.StudentId;
                    }
                }
            }
        }

        private async void initDataForTabUpdate(Models.Class data)
        {
            txtClassName.Text = data.ClassName;
            txtNote.Text = data.Note ?? "Không có ghi chú";
            txtOnlineLink.Text = data.OnlineMeetingLink ?? "";
            dtpStartDate.Text = data.StartDate.ToString("dd/MM/yyyy");
            dtpEndDate.Text = data.EndDate.ToString("dd/MM/yyyy");
            numMaxStudent.Value = data.MaxStudent != null ? (int)data.MaxStudent : 30;

            // load dữ liệu cho combobox
            await initCboTeachers(data);

            // load dữ liệu cho combobox
            await initCboCourses(data);
        }

        private async Task initCboTeachers(Models.Class data)
        {
            var result = await _serviceHub.TeacherService.GetAllTeachersAsync();
            if (!result.Success)
            {
                MessageHelper.ShowError("Đã xảy ra lỗi khi khởi tạo combobox teacher: \n" + result.Message);
                return;
            }

            var teacherList = result.Data.Select(t => new
            {
                Id = t.TeacherId,
                FullName = $"{t.User.FirstName} {t.User.LastName}"
            }).ToList();

            cmbTeacher.DisplayMember = "FullName"; 
            cmbTeacher.ValueMember = "Id";         

            cmbTeacher.DataSource = teacherList;

            if (data != null && data.TeacherId > 0)
            {
                cmbTeacher.SelectedValue = data.TeacherId;
            }
        }


        private async Task initCboCourses(Models.Class data)
        {
            var result = await _serviceHub.CourseService.GetAllCoursesAsync();
            if (!result.Success)
            {
                MessageHelper.ShowError("Đã xảy ra lỗi khi khởi tạo combobox courses: \n" + result.Message);
                return;
            }

            var courseList = result.Data.Select(c => new
            {
                Id = c.CourseId,
                Name = c.CourseName
            }).ToList();

            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";

            cmbCourse.DataSource = courseList;

            if (data != null && data.CourseId.HasValue)
            {
                cmbCourse.SelectedValue = data.CourseId.Value;
            }
        }

        private void initCboShift(Models.Class data)
        {
            var shiftDataSource = mapShift.Select(x => new
            {
                Id = x.Item1,     
                Name = x.Item2     
            }).ToList();

            cmbShift.DataSource = shiftDataSource;
            cmbShift.DisplayMember = "Name";
            cmbShift.ValueMember = "Id";     

            if (data != null)
            {
                cmbShift.SelectedValue = (int)data.Shift;
            }

        }

        #endregion

        #region handle button envent 

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            var addView = new AddStudentToClass(_serviceHub, _classId)
            {
                Dock = DockStyle.Fill
            };

            _isAddFeature = true;

            // Khi đóng form thêm, tải lại danh sách
            addView.OnCloseRequired += (s, args) =>
            {
                _isAddFeature = false;
                ShowStudentList();
            };

            // Khi thêm thành công, tải lại danh sách
            addView.OnStudentsAdded += (s, args) =>
            {
                _isAddFeature = false;
                ShowStudentList();
            };

            pnlMain.Controls.Add(addView);
        }



        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_isAddFeature)
            {
                MessageHelper.ShowWarning("Bạn đang thêm học viên nên không thể thực hiện chức năng này! \n" +
                    "Vui lòng thêm học viên");
                return;
            }

            if (dgvStudents.SelectedRows.Count <= 0)
            {
                MessageHelper.ShowInfo("Vui lòng chọn 1 học viên để xóa!");
                return;
            }
            var selectedRow = dgvStudents.SelectedRows[0];
            if (selectedRow.Tag == null)
            {
                MessageHelper.ShowError("Không tìm thấy thông tin học viên!");
                return;
            }

            if (!MessageHelper.ShowConfirmation("Bạn có chắc muốn xóa học viên này khỏi lớp học không?"))
            {
                return;
            }

            int studentId = (int)selectedRow.Tag;

            var (success, message) = await _serviceHub.ClassService.RemoveStudentFromClassAsync(_classId, studentId);

            if (success)
            {
                MessageHelper.ShowInfo("Xóa học viên khỏi lớp học thành công!");
                initialDetailClass();
            }
            else
            {
                MessageHelper.ShowError($"Xóa học viên thất bại! Lỗi: {message}");
            }

        }


        #endregion

        private void ShowStudentList()
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(this.dgvStudents);

            this.initialDetailClass();
        }

        
    }
}