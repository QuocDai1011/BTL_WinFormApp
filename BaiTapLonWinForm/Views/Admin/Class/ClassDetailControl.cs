using BaiTapLonWinForm.CoreSystem;
using BaiTapLonWinForm.Models; 
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Class
{
    public partial class ClassDetailControl : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _classId;
        public Func<Task> OnDataChanged;
        private bool _isLoaded = false;
        private DateTime _originalStartDate;
        private int? _currentStatus;
        private bool _isAdjustingDate = false;

        private List<Guna.UI2.WinForms.Guna2Button> _dayButtons;
        private readonly List<(int Id, string Name)> mapShift = new List<(int, string)>()
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
            InitializeComponent();
            _serviceHub = serviceHub;
            _classId = classId;

            _dayButtons = new List<Guna.UI2.WinForms.Guna2Button>
    {
        btnMon, btnTue, btnWed, btnThu, btnFri, btnSat, btnSun
    };

            // Database: 2=Thứ 2, ..., 7=Thứ 7, 8=Chủ nhật
            btnMon.Tag = 2;
            btnTue.Tag = 3;
            btnWed.Tag = 4;
            btnThu.Tag = 5;
            btnFri.Tag = 6;
            btnSat.Tag = 7;
            btnSun.Tag = 8;

            // 3. Gán sự kiện Click (để giới hạn 3 ngày)
            foreach (var btn in _dayButtons)
            {
                btn.Click += OnDayButton_Click;
            }

            AttachValidationEvents();

            ThemeManager.ThemeChanged += (s, e) => ResetDataGridView();
            ResetDataGridView();
        }

        #region Init data 
        private void ResetDataGridView()
        {
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvStudents.RowsDefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvStudents.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvStudents.Refresh();

            lblStudentCount.ForeColor = Color.Black;
            lblNoteTitle.ForeColor = Color.Black;
            lblNote.ForeColor = Color.Black;
        }
        private async Task initialDetailClass()
        {
            try
            {

                var (success, message, data) = await _serviceHub.ClassService.GetClassByIdAsync(_classId);

                if (!success || data == null)
                {
                    MessageHelper.ShowError(message);
                    return;
                }

                initGeneralInformation(data);
                initDataGridView(data);
                initCboShift(data);

                await initDataForTabUpdate(data);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải dữ liệu lớp học: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void initGeneralInformation(Models.Class data)
        {
            lblClassAndCouse.Text = $" {data.ClassName} -  {data.Course?.CourseName}";

            if (data.Teacher?.User != null)
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

            var shiftItem = mapShift.FirstOrDefault(s => s.Id == data.Shift);
            string shiftDesc = shiftItem.Name ?? "Chưa xếp lịch";

            string shiftInfo = (data.SchoolDays != null && data.SchoolDays.Any())
                ? string.Join("\n", data.SchoolDays.Select(sd => $"{sd.DayOfWeek}: {shiftDesc}"))
                : "Chưa có lịch học";

            lblShift.Text = shiftInfo;

            lblStartDate.Text = data.StartDate.ToString("dd/MM/yyyy");
            lblEndDate.Text = data.EndDate.ToString("dd/MM/yyyy");
        }

        private void initDataGridView(Models.Class data)
        {
            dgvStudents.Rows.Clear();

            if (data.StudentClasses != null && data.StudentClasses.Any())
            {
                foreach (var sc in data.StudentClasses)
                {
                    if (sc.Student?.User != null)
                    {
                        var user = sc.Student.User;
                        int rowIndex = dgvStudents.Rows.Add(
                            $"{user.FirstName} {user.LastName}",
                            user.DateOfBirth.Value                               
                                .ToString("dd/MM/yyyy")
                            ?? "N/A",
                            user.PhoneNumber,
                            user.Email
                        );
                        dgvStudents.Rows[rowIndex].Tag = sc.Student.StudentId;
                    }
                }
            }
        }

        private async Task initDataForTabUpdate(Models.Class data)
        {
            _originalStartDate = data.StartDate.ToDateTime(TimeOnly.MinValue).Date;
            _currentStatus = data.Status;

            txtClassName.Text = data.ClassName;
            txtNote.Text = data.Note ?? "Không có ghi chú";
            txtOnlineLink.Text = data.OnlineMeetingLink ?? "";
            dtpStartDate.Value = data.StartDate.ToDateTime(TimeOnly.MinValue);
            dtpEndDate.Value = data.EndDate.ToDateTime(TimeOnly.MinValue);
            numMaxStudent.Value = data.MaxStudent ?? 30;


            await initCboTeachers(data);
            await initCboCourses(data);

            foreach (var btn in _dayButtons) btn.Checked = false;

            if (data.SchoolDays != null)
            {
                foreach (var schoolDay in data.SchoolDays)
                {

                    var targetBtn = _dayButtons.FirstOrDefault(b =>
                                    b.Tag != null &&
                                    Convert.ToInt32(b.Tag) == schoolDay.SchoolDayId
                                );
                    // Nếu tìm thấy thì bật nút đó lên
                    if (targetBtn != null)
                    {
                        targetBtn.Checked = true;
                    }
                }
            }
        }

        private async Task initCboTeachers(Models.Class data)
        {
            var result = await _serviceHub.TeacherService.GetAllTeachersAsync();
            if (!result.Success)
            {
                MessageHelper.ShowError("Lỗi tải DS giáo viên: \n" + result.Message);
                return;
            }

            var teacherList = result.Data.Select(t => new
            {
                Id = t.TeacherId,
                FullName = $"{t.User.FirstName} {t.User.LastName}"
            }).ToList();

            cmbTeacher.DataSource = teacherList;
            cmbTeacher.DisplayMember = "FullName";
            cmbTeacher.ValueMember = "Id";

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
                MessageHelper.ShowError("Lỗi tải DS khóa học: \n" + result.Message);
                return;
            }

            var courseList = result.Data.Select(c => new
            {
                Id = c.CourseId,
                Name = c.CourseName
            }).ToList();

            cmbCourse.DataSource = courseList;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Id";

            if (data != null && data.CourseId.HasValue)
            {
                cmbCourse.SelectedValue = data.CourseId.Value;
            }
        }

        private void initCboShift(Models.Class data)
        {
            cmbShift.DataSource = mapShift.Select(x => new { Id = x.Id, Name = x.Name }).ToList();
            cmbShift.DisplayMember = "Name";
            cmbShift.ValueMember = "Id";

            if (data != null)
            {
                cmbShift.SelectedValue = (int)data.Shift;
            }
        }

        #endregion

        #region handle events 

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            var addView = new AddStudentToClass(_serviceHub, _classId)
            {
                Dock = DockStyle.Fill
            };


            addView.OnCloseRequired += async (s, args) =>
            {
                await ShowStudentList();
            };

            addView.OnStudentsAdded += async (s, args) =>
            {
                await ShowStudentList();

                OnDataChanged?.Invoke();

            };

            pnlMain.Controls.Add(addView);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvStudents.SelectedRows.Count <= 0)
            {
                MessageHelper.ShowInfo("Vui lòng chọn 1 học viên để xóa!");
                return;
            }

            if (!MessageHelper.ShowConfirmation("Bạn có chắc muốn xóa học viên này khỏi lớp học không?"))
                return;

            if (dgvStudents.SelectedRows[0].Tag is int studentId)
            {
                var (success, message) = await _serviceHub.ClassService.RemoveStudentFromClassAsync(_classId, studentId);

                if (success)
                {
                    MessageHelper.ShowInfo("Xóa học viên thành công!");
                    await initialDetailClass();
                    OnDataChanged?.Invoke();
                }
                else
                {
                    MessageHelper.ShowError($"Xóa thất bại: {message}");
                }
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ValidateForm();
            if (!btnSaveChanges.Enabled) return;

            btnSaveChanges.Enabled = false;
            btnSaveChanges.Text = "Đang lưu...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var selectedDays = new List<Models.SchoolDay>();
                foreach (var btn in _dayButtons)
                {
                    if (btn.Checked)
                    {
                        int dayId = Convert.ToInt32(btn.Tag);
                        selectedDays.Add(new Models.SchoolDay
                        {
                            SchoolDayId = (byte)dayId,
                            DayOfWeek = btn.Text
                        });
                    }
                }

                if (selectedDays.Count == 0)
                {
                    MessageHelper.ShowWarning("Vui lòng chọn ít nhất 1 ngày học trong tuần!");
                    return;
                }

                var updateModel = new Models.Class
                {
                    ClassId = _classId,
                    ClassName = txtClassName.Text.Trim(),

                    CourseId = cmbCourse.SelectedValue != null && int.TryParse(cmbCourse.SelectedValue.ToString(), out int courseId)
                    ? courseId
                    : (int?)null,
                    TeacherId = Convert.ToInt32(cmbTeacher.SelectedValue),

                    Shift = (byte)Convert.ToInt32(cmbShift.SelectedValue),

                    StartDate = DateOnly.FromDateTime(dtpStartDate.Value),
                    EndDate = DateOnly.FromDateTime(dtpEndDate.Value),
                    MaxStudent = (int)numMaxStudent.Value,
                    OnlineMeetingLink = txtOnlineLink.Text.Trim(),
                    Note = txtNote.Text.Trim(),

                    SchoolDays = selectedDays,
                    Status = _currentStatus
                };

                // 4. Gọi Service Update
                var (success, message, data) = await _serviceHub.ClassService.UpdateClassAsync(updateModel);

                if (success)
                {
                    MessageHelper.ShowInfo("Cập nhật thông tin lớp học thành công!");

                    if (OnDataChanged != null)
                    {
                        await OnDataChanged.Invoke();
                    }

                    await initialDetailClass();
                }
                else
                {
                    MessageHelper.ShowError($"Cập nhật thất bại: {message}");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi hệ thống: {ex.Message}");
            }
            finally
            {

                btnSaveChanges.Enabled = true;
                btnSaveChanges.Text = "💾 Lưu Thay Đổi";
                this.Cursor = Cursors.Default;

                ValidateForm();
            }
        }

        private void OnDayButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            int count = _dayButtons.Count(b => b.Checked);

            if (count > 3)
            {
                btn.Checked = false;

                SetError(lblErrorDayofWeek, "Chỉ được phép chọn tối đa 3 buổi học trong tuần!");
            }
            else
            {
                ClearError(lblErrorDayofWeek);
            }

        }

        private async void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedValue == null) return;

            if (int.TryParse(cmbCourse.SelectedValue.ToString(), out int courseId))
            {
                var result = await _serviceHub.CourseService.GetCourseByIdAsync(courseId);

                if (!result.Success || result.Data == null) return;

                int totalSessions = result.Data.NumberSessions;
                if (totalSessions <= 0) return;

                DateTime minStartDate = DateTime.Now.AddDays(7);

                int daysUntilMonday = ((int)DayOfWeek.Monday - (int)minStartDate.DayOfWeek + 7) % 7;
                DateTime actualStartDate = minStartDate.AddDays(daysUntilMonday);

                int weeksNeeded = (int)Math.Ceiling(totalSessions / 3.0);


                DateTime actualEndDate = actualStartDate.AddDays((weeksNeeded * 7) - 1);

                dtpStartDate.Value = actualStartDate;
                dtpEndDate.Value = actualEndDate;

                lblEstimate.Text = $"Khóa học: {totalSessions} buổi. \n" +
                                  $"Thời gian: {weeksNeeded} tuần. \n" +
                                  $"(Học từ Thứ 2 ngày {actualStartDate:dd/MM} đến Chủ Nhật ngày {actualEndDate:dd/MM})";
                lblEstimate.Visible = true;
            }
        }

        private async void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isAdjustingDate) return;

            _isAdjustingDate = true;
            try
            {
                DateTime selectedDate = dtpStartDate.Value;
                DateTime minAllowedDate = DateTime.Now.AddDays(7);

                int diff = (7 + (selectedDate.DayOfWeek - DayOfWeek.Monday)) % 7;
                DateTime targetMonday = selectedDate.AddDays(-1 * diff);

                if (targetMonday < minAllowedDate)
                {
                    int daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)minAllowedDate.DayOfWeek + 7) % 7;
                    targetMonday = minAllowedDate.AddDays(daysUntilNextMonday);
                }

                if (dtpStartDate.Value.Date != targetMonday.Date)
                {
                    dtpStartDate.Value = targetMonday;
                }

                await RecalculateEndDate(targetMonday);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán ngày: " + ex.Message);
            }
            finally
            {
                _isAdjustingDate = false;
            }
        }

        #endregion

        #region validate input

        private void AttachValidationEvents()
        {
            txtClassName.TextChanged += (s, e) => { if (_isLoaded) ValidateForm(); };

            dtpStartDate.ValueChanged += (s, e) => { if (_isLoaded) ValidateForm(); };
            dtpEndDate.ValueChanged += (s, e) => { if (_isLoaded) ValidateForm(); };
        }

        private void ValidateForm()
        {
            bool isNameValid = ValidateClassName();
            bool isDateValid = ValidateDates();

            btnSaveChanges.Enabled = isNameValid && isDateValid;
        }

        private bool ValidateClassName()
        {
            string input = txtClassName.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                SetError(lblErrorClassName, "Tên lớp không được để trống.");
                return false;
            }


            string pattern = @"^[\p{L}\p{N}\s_\-\(\)]+$";

            if (!Regex.IsMatch(input, pattern))
            {
                SetError(lblErrorClassName, "Tên lớp chứa ký tự đặc biệt không hợp lệ.");
                return false;
            }

            ClearError(lblErrorClassName);
            return true;
        }

        private bool ValidateDates()
        {
            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date;
            DateTime today = DateTime.Now.Date;
            bool isValid = true;

            if (start != _originalStartDate)
            {
                if (_currentStatus == 0)
                {
                    SetError(lblErrorStartDate, "Lớp đang diễn ra, không thể thay đổi ngày bắt đầu!");
                    isValid = false;
                    start = _originalStartDate;
                }
                else if (start < today.AddDays(7))
                {
                    SetError(lblErrorStartDate, "Ngày bắt đầu mới phải sau hôm nay ít nhất 7 ngày.");
                    isValid = false;
                }
                else
                {
                    ClearError(lblErrorStartDate);
                }
            }
            else
            {
                ClearError(lblErrorStartDate);
            }

            if (isValid)
            {
                if (end <= start)
                {
                    SetError(lblErrorEndDate, "Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                    isValid = false;
                }
                else if (end < start.AddMonths(4))
                {
                    SetError(lblErrorEndDate, "Thời lượng khóa học phải ít nhất 4 tháng.");
                    isValid = false;
                }
                else
                {
                    ClearError(lblErrorEndDate);
                }
            }

            return isValid;
        }

        private void SetError(Label lbl, string msg)
        {
            if (lbl != null)
            {
                lbl.Text = msg;
                lbl.Visible = true;
            }
        }

        private void ClearError(Label lbl)
        {
            if (lbl != null)
            {
                lbl.Visible = false;
                lbl.Text = "";
            }
        }

        #endregion

        #region helper method
        private async Task ShowStudentList()
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(this.TabControls);
            await initialDetailClass();
        }

        private async Task RecalculateEndDate(DateTime startDate)
        {
            if (cmbCourse.SelectedValue == null) return;

            if (int.TryParse(cmbCourse.SelectedValue.ToString(), out int courseId))
            {
                var result = await _serviceHub.CourseService.GetCourseByIdAsync(courseId);

                if (result.Success && result.Data != null)
                {
                    int totalSessions = result.Data.NumberSessions;
                    if (totalSessions <= 0) return;

                    int weeksNeeded = (int)Math.Ceiling(totalSessions / 3.0);

                    DateTime endDate = startDate.AddDays((weeksNeeded * 7) - 1);

                    dtpEndDate.Value = endDate;

                    lblEstimate.Text = $"Lịch dự kiến: {weeksNeeded} tuần ({totalSessions} buổi).";
                }
            }
        }
        #endregion
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                await initialDetailClass();
                _isLoaded = true;
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            TabControls.SelectedTab = tabPage1;
        }
    }
}