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
    public enum ClassFilterStatus
    {
        Upcoming, // Sắp diễn ra (Status = -1)
        Ongoing,  // Đang diễn ra (Status = 0)
        Finished  // Đã kết thúc (Status = 1)
    }

    public partial class ClassManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly Image _cachedLogo;
        private readonly Image _cachedUserIcon;
        private readonly Image _cachedStudentIcon;
        private List<Models.Class> _allClassesCache;
        private List<Guna.UI2.WinForms.Guna2Button> _dayButtons;
        private bool _isLoaded = false;
        private readonly List<(int Id, string Name)> mapShift = new List<(int, string)>()
        {
            (1, "Sáng (8:00 - 9:30)"),
            (2, "Sáng (9:30 - 11:00)"),
            (3, "Chiều (14:00 - 15:30)"),
            (4, "Chiều (15:30 - 17:00)"),
            (5, "Tối (18:00 - 19:30)"),
            (6, "Tối (19:30 - 21:00)")
        };

        // 3 TableLayoutPanel riêng biệt cho mỗi tab
        private TableLayoutPanel _tableUpcoming;
        private TableLayoutPanel _tableOngoing;
        private TableLayoutPanel _tableFinished;

        public ClassManagement(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;

            // Pre-load resources
            _cachedLogo = Properties.Resources.logo2019_png_1;
            _cachedUserIcon = Properties.Resources.user;
            _cachedStudentIcon = Properties.Resources.Ảnh_chụp_màn_hình_2025_12_01_204702;

            InitializeComponent();
            SetupCustomUI();

            this.Load += async (s, e) => await LoadClassData();


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
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                _isLoaded = true;
            }
        }

        #region setup UI and create layout
        private void SetupCustomUI()
        {
            // Tạo 3 TableLayoutPanel cho 3 tab
            _tableUpcoming = CreateTableLayoutPanel();
            _tableOngoing = CreateTableLayoutPanel();
            _tableFinished = CreateTableLayoutPanel();

            // Add vào từng tab page
            tabPageUpcoming.Controls.Add(_tableUpcoming);
            tabPageOngoing.Controls.Add(_tableOngoing);
            tabPageFinished.Controls.Add(_tableFinished);

            // Thiết lập tab mặc định
            tabControl.SelectedIndex = 0;
        }

        private TableLayoutPanel CreateTableLayoutPanel()
        {
            var table = new TableLayoutPanel
            {
                AutoScroll = true,
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(10, 10, SystemInformation.VerticalScrollBarWidth + 10, 10)
            };

            // Cấu hình 3 cột đều nhau
            table.ColumnStyles.Clear();
            float percent = 100f / 3;
            for (int i = 0; i < 3; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
            }

            // Row mặc định
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 245F));

            return table;
        }

        #endregion

        #region load data
        private async Task LoadClassData()
        {
            this.Cursor = Cursors.WaitCursor;

            var result = await _serviceHub.ClassService.GetAllClassesAsync();


            this.Cursor = Cursors.Default;

            if (!result.Success)
            {
                MessageHelper.ShowError("Lỗi: " + result.Message);
                return;
            }

            // Lưu cache
            _allClassesCache = result.Data?.ToList() ?? new List<Models.Class>();


            // Render dữ liệu cho cả 3 tab
            RenderTable(_tableUpcoming, ClassFilterStatus.Upcoming);
            RenderTable(_tableOngoing, ClassFilterStatus.Ongoing);
            RenderTable(_tableFinished, ClassFilterStatus.Finished);

            await initCboCourses();
            await initCboTeachers();
            initCboShift();
            initDateTimePicker();
        }

        private List<Models.Class> FilterData(ClassFilterStatus status)
        {
            if (_allClassesCache == null) return new List<Models.Class>();

            switch (status)
            {
                case ClassFilterStatus.Upcoming:
                    return _allClassesCache.Where(c => c.Status == -1).ToList();
                case ClassFilterStatus.Ongoing:
                    return _allClassesCache.Where(c => c.Status == 0).ToList();
                case ClassFilterStatus.Finished:
                    return _allClassesCache.Where(c => c.Status == 1).ToList();
                default:
                    return new List<Models.Class>();
            }
        }

        private void RenderTable(TableLayoutPanel table, ClassFilterStatus status)
        {
            if (table == null) return;

            var filteredList = FilterData(status);

            table.SuspendLayout();
            try
            {
                while (table.Controls.Count > 0)
                {
                    var control = table.Controls[0];
                    table.Controls.RemoveAt(0);
                    control.Dispose();
                }

                table.RowStyles.Clear();

                int columns = 3;
                int rows = filteredList.Count > 0
                    ? (int)Math.Ceiling((double)filteredList.Count / columns)
                    : 1;

                table.RowCount = rows;

                float rowHeight = 245F;
                for (int i = 0; i < rows; i++)
                {
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                }

                if (filteredList == null || filteredList.Count == 0)
                {
                    table.RowCount = 1;
                    table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                    Guna2HtmlLabel lblEmpty = new Guna2HtmlLabel
                    {
                        Text = "<div style='text-align:center; padding-top: 20px; color: gray; font-size: 18px'>" +
                               "<b style='font-size: 18px'>Không tìm thấy lớp học nào</b><br/>" +
                               "Hiện tại chưa có lớp học ở trạng thái này." +
                               "</div>",
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlignment = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };

                    table.Controls.Add(lblEmpty, 0, 0);

                    table.SetColumnSpan(lblEmpty, columns);
                }

                // Thêm các card
                for (int i = 0; i < filteredList.Count; i++)
                {
                    int row = i / columns;
                    int col = i % columns;

                    var classPanel = CreateClassPanel(filteredList[i]);
                    table.Controls.Add(classPanel, col, row);
                }
            }
            finally
            {
                table.ResumeLayout(true);
            }
        }

        private Guna2ShadowPanel CreateClassPanel(Models.Class classInfo)
        {
            var panel = new Guna2ShadowPanel
            {
                BackColor = Color.Transparent,
                FillColor = Color.White,
                Margin = new Padding(10),
                Size = new Size(449, 225),
                ShadowColor = Color.Black,
                ShadowDepth = 50,
                ShadowShift = 3,
                Radius = 10,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.None
            };

            // Logo
            var logoBox = new Guna2PictureBox
            {
                Image = _cachedLogo,
                Location = new Point(3, 3),
                Size = new Size(180, 150),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Tên lớp
            var lblClassName = new Guna2HtmlLabel
            {
                Text = classInfo.ClassName,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(190, 55),
                AutoSize = false,
                Size = new Size(240, 55),
                BackColor = Color.Transparent,
                IsSelectionEnabled = false
            };

            // Ngày khai giảng
            var lblStartDate = new Guna2HtmlLabel
            {
                Text = "Khai giảng: " + classInfo.StartDate.ToString("dd/MM/yyyy"),
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(195, 110),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Icon & Text Chi nhánh
            var branchIcon = new Guna2PictureBox
            {
                Image = _cachedUserIcon,
                Location = new Point(13, 172),
                Size = new Size(35, 33),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            string teacherName = $"{classInfo.Teacher.User.FirstName} {classInfo.Teacher.User.LastName}";


            var lblTeacherName = new Guna2HtmlLabel
            {
                Text = teacherName != null ? $"Giảng viên: {teacherName}" : "Chưa phân công",
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(50, 175),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Icon & Text Số lượng học viên
            var studentIcon = new Guna2PictureBox
            {
                Image = _cachedStudentIcon,
                Location = new Point(372, 172),
                Size = new Size(35, 33),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            var lblStudents = new Guna2HtmlLabel
            {
                Text = (classInfo.CurrentStudent ?? 0).ToString(),
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(413, 175),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Add controls vào panel
            panel.Controls.AddRange(new Control[] {
                logoBox, lblClassName, lblStartDate,
                branchIcon, lblTeacherName, studentIcon, lblStudents
            });

            // Sự kiện Click
            void OnClick(object s, EventArgs e) => OnClassPanelClick(classInfo.ClassId);

            panel.Click += OnClick;
            foreach (Control c in panel.Controls)
            {
                c.Click += OnClick;
            }

            return panel;
        }

        private async Task initCboTeachers()
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


        }

        private async Task initCboCourses()
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


        }

        private void initCboShift()
        {
            cmbShift.DataSource = mapShift.Select(x => new { Id = x.Id, Name = x.Name }).ToList();
            cmbShift.DisplayMember = "Name";
            cmbShift.ValueMember = "Id";


        }


        private void initDateTimePicker()
        {
            dtpStartDate.Value = DateTime.Now.Date.AddDays(7); // lớp học bắt đầu sau 7 ngày
            dtpEndDate.Value = dtpStartDate.Value.AddMonths(4); 
        }

        private void clearData()
        {
            txtClassName.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtOnlineLink.Text = string.Empty;
            
            foreach(var btn in _dayButtons)
            {
                btn.Checked = false;
            }
        }

        #endregion

        #region handle event click

        private void OnClassPanelClick(int classId)
        {
            this.Controls.Clear();
            var detailControl = new ClassDetailControl(_serviceHub, classId)
            {
                Dock = DockStyle.Fill
            };

            detailControl.OnDataChanged = async () =>
            {
                await LoadClassData();
            };


            this.Controls.Add(detailControl);


        }


        private void OnDayButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            int count = _dayButtons.Count(b => b.Checked);

            if (count > 3)
            {
                // Revert: Trả lại trạng thái chưa chọn cho nút vừa bấm
                btn.Checked = false;

                // Hiển thị cảnh báo
                SetError(lblErrorDayOWeek, "Chỉ được phép chọn tối đa 3 buổi học trong tuần!");
            }
            else
            {
                ClearError(lblErrorDayOWeek);
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            ValidateForm();
            if (!btnAdd.Enabled) return;

            btnAdd.Enabled = false;
            btnAdd.Text = "Đang lưu...";
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
                    ClassId = 0,
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
                    Status = -1,
                    CreateAt = DateTime.Now,
                    CurrentStudent = 0 // lớp mới nên khởi tạo current student = 0 
                };

                var (success, message, data) = await _serviceHub.ClassService.CreateClassAsync(updateModel);

                if (success)
                {
                    MessageHelper.ShowInfo("Thêm mới lớp học thành công!");
                    clearData();
                    tabControl.SelectedTab = tabPageUpcoming;
                    await LoadClassData();
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

                btnAdd.Enabled = true;
                btnAdd.Text = "💾 Lưu Thay Đổi";
                this.Cursor = Cursors.Default;

                ValidateForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageUpcoming;

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

            btnAdd.Enabled = isNameValid && isDateValid;
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

            if (start < today.AddDays(7))
            {
                SetError(lblErrorStartDate, "Ngày bắt đầu mới phải sau hôm nay ít nhất 7 ngày.");
                isValid = false;
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


       
    }
}