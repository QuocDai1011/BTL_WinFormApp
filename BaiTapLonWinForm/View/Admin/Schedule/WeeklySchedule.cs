using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Schedule
{
    public partial class WeeklySchedule : UserControl
    {
        #region Properties & Fields

        public class ScheduleData
        {
            public string ClassName { get; set; }
            public string Teacher { get; set; }
            public string Course { get; set; }
            public string Room { get; set; }
            public DayOfWeek Day { get; set; }
            public string TimeSlot { get; set; }
            public Color Color { get; set; }
        }

        private readonly ServiceHub _serviceHub;
        private List<ScheduleData> allSchedules = new List<ScheduleData>();
        private List<ScheduleData> filteredSchedules = new List<ScheduleData>();
        private DateTime currentMonday;
        private bool isLoading = false;

        // Mapping khung giờ: Key = "8:00-9:30", Value = (Row trong table, Display text)
        private readonly Dictionary<string, (int Row, string Display)> timeSlots = new Dictionary<string, (int, string)>
        {
            { "8:00-9:30", (1, "8:00 - 9:30") },
            { "9:30-11:00", (2, "9:30 - 11:00") },
            { "14:00-15:30", (3, "14:00 - 15:30") },
            { "15:30-17:00", (4, "15:30 - 17:00") },
            { "18:00-19:30", (5, "18:00 - 19:30") },
            { "19:30-21:00", (6, "19:30 - 21:00") }
        };

        private readonly string[] sessionNames = { "Sáng", "Chiều", "Tối" };
        private readonly string[] dayNames = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "CN" };

        #endregion

        #region Constructor & Initialization

        public WeeklySchedule(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub ?? throw new ArgumentNullException(nameof(serviceHub));

            // Bật DoubleBuffered cho TableLayoutPanel để giảm flickering
            EnableDoubleBuffering();

            SetCurrentWeek(DateTime.Now);

            // Thêm event cho label date range
            lblDateRange.Cursor = Cursors.Hand;
            lblDateRange.Click += lblDateRange_Click;

            this.Load += WeeklySchedule_Load;
        }

        private void EnableDoubleBuffering()
        {
            try
            {
                typeof(TableLayoutPanel).InvokeMember(
                    "DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null,
                    tblSchedule,
                    new object[] { true });
            }
            catch (Exception ex)
            {
                // Ignore nếu không set được double buffering
                System.Diagnostics.Debug.WriteLine($"Cannot enable double buffering: {ex.Message}");
            }
        }

        private async void WeeklySchedule_Load(object sender, EventArgs e)
        {
            try
            {
                SetupTableHeaders();
                await InitializeFiltersAsync();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khởi tạo: {ex.Message}");
            }
        }

        #endregion

        #region Filter Initialization

        private async Task InitializeFiltersAsync()
        {
            try
            {
                // Khởi tạo ComboBox Giảng viên
                await InitializeTeacherFilterAsync();

                // Khởi tạo ComboBox Lớp học
                await InitializeClassFilterAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khởi tạo bộ lọc: {ex.Message}");
            }
        }

        private async Task InitializeTeacherFilterAsync()
        {
            var result = await _serviceHub.TeacherService.GetTeachersWithClassesAsync();

            if (!result.Success)
            {
                MessageHelper.ShowError("Không thể tải danh sách giảng viên!");
                return;
            }

            var teacherList = result.Data
                .Where(t => t.Classes != null && t.Classes.Count > 0 && t.User != null)
                .Select(t => new
                {
                    Id = t.TeacherId,
                    FullName = $"{t.User.FirstName} {t.User.LastName}".Trim()
                })
                .OrderBy(t => t.FullName)
                .ToList();

            teacherList.Insert(0, new { Id = 0, FullName = "Tất cả Giảng viên" });

            cboFilterTeacher.DataSource = teacherList;
            cboFilterTeacher.DisplayMember = "FullName";
            cboFilterTeacher.ValueMember = "FullName";
            cboFilterTeacher.SelectedIndex = 0;
        }

        private async Task InitializeClassFilterAsync()
        {
            var result = await _serviceHub.ClassService.GetAllClassesAsync();

            if (!result.Success)
            {
                MessageHelper.ShowError("Không thể tải danh sách lớp học!");
                return;
            }

            var classList = result.Data?
                .Where(c => c.Status == 0) // Chỉ lấy lớp đang hoạt động
                .Select(c => new
                {
                    Id = c.ClassId,
                    ClassName = c.ClassName
                })
                .OrderBy(c => c.ClassName)
                .ToList();

            classList?.Insert(0, new { Id = 0, ClassName = "Tất cả Lớp học" });

            cboFilterClass.DataSource = classList;
            cboFilterClass.DisplayMember = "ClassName";
            cboFilterClass.ValueMember = "ClassName";
            cboFilterClass.SelectedIndex = 0;
        }

        #endregion

        #region Week Navigation

        private void SetCurrentWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            currentMonday = date.AddDays(-1 * diff).Date;
            DateTime sunday = currentMonday.AddDays(6);

            lblDateRange.Text = $"📆 Tuần: {currentMonday:dd/MM} - {sunday:dd/MM/yyyy}";
        }

        private void lblDateRange_Click(object sender, EventArgs e)
        {
            using (var rangeForm = new DateRangePickerForm(currentMonday, currentMonday.AddDays(6)))
            {
                if (rangeForm.ShowDialog() == DialogResult.OK)
                {
                    DateTime startDate = rangeForm.StartDate;
                    DateTime endDate = rangeForm.EndDate;

                    TimeSpan diff = endDate - startDate;
                    if (diff.Days < 0 || diff.Days > 6)
                    {
                        MessageHelper.ShowWarning("Khoảng thời gian phải từ 1 đến 7 ngày!");
                        return;
                    }

                    currentMonday = startDate;
                    lblDateRange.Text = $"📆 Tùy chọn: {startDate:dd/MM} - {endDate:dd/MM/yyyy}";
                    SetupTableHeaders(startDate, endDate);
                    LoadDataAsync().ConfigureAwait(false);
                }
            }
        }

        private async void btnPrevWeek_Click(object sender, EventArgs e)
        {
            if (isLoading) return;

            SetCurrentWeek(currentMonday.AddDays(-7));
            SetupTableHeaders();
            await LoadDataAsync();
        }

        private async void btnNextWeek_Click(object sender, EventArgs e)
        {
            if (isLoading) return;

            SetCurrentWeek(currentMonday.AddDays(7));
            SetupTableHeaders();
            await LoadDataAsync();
        }

        private async void btnToday_Click(object sender, EventArgs e)
        {
            if (isLoading) return;

            SetCurrentWeek(DateTime.Now);
            SetupTableHeaders();
            await LoadDataAsync();
        }

        #endregion

        #region Table Setup & Rendering

        private void SetupTableHeaders()
        {
            SetupTableHeaders(currentMonday, currentMonday.AddDays(6));
        }

        private void SetupTableHeaders(DateTime startDate, DateTime endDate)
        {
            tblSchedule.SuspendLayout();
            tblSchedule.Controls.Clear();

            int dayCount = (endDate - startDate).Days + 1;
            if (dayCount < 1) dayCount = 1;
            if (dayCount > 7) dayCount = 7;

            tblSchedule.ColumnCount = dayCount + 1; // +1 cho cột thời gian
            tblSchedule.ColumnStyles.Clear();
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            for (int i = 0; i < dayCount; i++)
            {
                tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / dayCount));
            }

            AddHeaderLabel("⏱️ Buổi / Thứ", 0, 0, Color.FromArgb(94, 148, 255), Color.White);

            // Header các ngày
            DateTime dateRunner = startDate;
            for (int i = 0; i < dayCount; i++)
            {
                string dayName = GetDayName(dateRunner.DayOfWeek);
                string dateStr = dateRunner.ToString("dd/MM");
                string fullText = $"{dayName}\n{dateStr}";

                bool isToday = dateRunner.Date == DateTime.Now.Date;
                Color bg = isToday ? Color.FromArgb(255, 193, 7) : Color.FromArgb(94, 148, 255);
                Color textCol = Color.White;

                AddHeaderLabel(fullText, i + 1, 0, bg, textCol);
                dateRunner = dateRunner.AddDays(1);
            }

            int row = 1;
            for (int sessionIdx = 0; sessionIdx < 3; sessionIdx++)
            {
                for (int slot = 0; slot < 2; slot++)
                {
                    string timeKey = GetTimeKeyBySessionAndSlot(sessionIdx, slot);

                    if (!timeSlots.ContainsKey(timeKey)) continue;

                    string labelText = slot == 0
                        ? $"【{sessionNames[sessionIdx]}】\n{timeSlots[timeKey].Display}"
                        : timeSlots[timeKey].Display;

                    AddHeaderLabel(labelText, 0, row, Color.FromArgb(245, 247, 250), Color.FromArgb(64, 64, 64));
                    row++;
                }
            }

            tblSchedule.ResumeLayout();
        }

        private string GetDayName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Thứ 2";
                case DayOfWeek.Tuesday: return "Thứ 3";
                case DayOfWeek.Wednesday: return "Thứ 4";
                case DayOfWeek.Thursday: return "Thứ 5";
                case DayOfWeek.Friday: return "Thứ 6";
                case DayOfWeek.Saturday: return "Thứ 7";
                case DayOfWeek.Sunday: return "CN";
                default: return "";
            }
        }

        private void AddHeaderLabel(string text, int col, int row, Color bg, Color? foreColor = null)
        {
            Label lbl = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, row == 0 || col == 0 ? FontStyle.Bold : FontStyle.Regular),
                BackColor = bg,
                ForeColor = foreColor ?? Color.DimGray
            };
            tblSchedule.Controls.Add(lbl, col, row);
        }

        private void RenderSchedule()
        {
            tblSchedule.SuspendLayout();

            var itemsToRemove = tblSchedule.Controls.Cast<Control>()
                .Where(c => c is ScheduleItem)
                .ToList();

            foreach (var item in itemsToRemove)
            {
                tblSchedule.Controls.Remove(item);
                item.Dispose();
            }

            foreach (var schedule in filteredSchedules)
            {
                AddScheduleItem(schedule);
            }

            tblSchedule.ResumeLayout();
        }

        private void AddScheduleItem(ScheduleData data)
        {
            if (!timeSlots.ContainsKey(data.TimeSlot)) return;

            int row = timeSlots[data.TimeSlot].Row;
            int col = data.Day == DayOfWeek.Sunday ? 7 : (int)data.Day;

            // Kiểm tra xem ô đã có item chưa
            var existingControl = tblSchedule.GetControlFromPosition(col, row);
            if (existingControl is ScheduleItem)
            {
                // Nếu đã có item, có thể log warning hoặc xử lý conflict
                System.Diagnostics.Debug.WriteLine($"Conflict: Ô [{col},{row}] đã có lịch học");
                return;
            }

            ScheduleItem item = new ScheduleItem();
            item.SetData(
                data.ClassName,
                data.Teacher,
                data.Course,
                timeSlots[data.TimeSlot].Display,
                data.Color
            );
            item.Dock = DockStyle.Fill;
            item.Margin = new Padding(3);

            tblSchedule.Controls.Add(item, col, row);
        }

        #endregion

        #region Data Loading

        private async Task LoadDataAsync()
        {
            if (isLoading) return;

            try
            {
                isLoading = true;

                // Hiển thị trạng thái loading (có thể thêm spinner)
                this.Cursor = Cursors.WaitCursor;

                DateTime endDate = currentMonday.AddDays(6);

                var sessions = await _serviceHub.ClassService.GetScheduleForWeekFromClassAsync(
                    DateOnly.FromDateTime(currentMonday),
                    DateOnly.FromDateTime(endDate)
                );

                // Clear dữ liệu cũ
                allSchedules.Clear();

                // Parse dữ liệu từ API
                foreach (var session in sessions)
                {
                    if (session.Class == null) continue;

                    // Lấy tên giảng viên
                    string teacherName = "Chưa phân công";
                    if (session.Class.Teacher?.User != null)
                    {
                        teacherName = $"{session.Class.Teacher.User.FirstName} {session.Class.Teacher.User.LastName}".Trim();
                    }

                    // Lấy phòng học (giả sử có property Room)

                    // Map shift sang timeSlot
                    string timeKey = GetTimeSlotKeyByShift(session.Class.Shift);
                    if (string.IsNullOrEmpty(timeKey)) continue;

                    // Thêm vào danh sách
                    allSchedules.Add(new ScheduleData
                    {
                        ClassName = session.Class.ClassName,
                        Teacher = teacherName,
                        Course = session.Class.Course?.CourseName ?? "N/A",
                        Day = session.SessionDate.DayOfWeek,
                        TimeSlot = timeKey,
                        Color = GetColorByCourseId(session.Class.CourseId ?? 0)
                    });
                }

                // Áp dụng filter và render
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi tải lịch: {ex.Message}");
                allSchedules.Clear();
                filteredSchedules.Clear();
                RenderSchedule();
            }
            finally
            {
                isLoading = false;
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Filter Logic

        private void ApplyFilter()
        {
            filteredSchedules = new List<ScheduleData>(allSchedules);

            // Lọc theo giảng viên
            if (cboFilterTeacher.SelectedIndex > 0 && cboFilterTeacher.SelectedValue != null)
            {
                string selectedTeacher = cboFilterTeacher.SelectedValue.ToString();
                filteredSchedules = filteredSchedules
                    .Where(s => s.Teacher.Equals(selectedTeacher, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Lọc theo lớp
            if (cboFilterClass.SelectedIndex > 0 && cboFilterClass.SelectedValue != null)
            {
                string selectedClass = cboFilterClass.SelectedValue.ToString();
                filteredSchedules = filteredSchedules
                    .Where(s => s.ClassName.Equals(selectedClass, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            RenderSchedule();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            ApplyFilter();
        }

        #endregion

        #region Helper Methods
        private string GetTimeSlotKeyByShift(int shift)
        {
            switch (shift)
            {
                case 1: return "8:00-9:30";
                case 2: return "9:30-11:00";
                case 3: return "14:00-15:30";
                case 4: return "15:30-17:00";
                case 5: return "18:00-19:30";
                case 6: return "19:30-21:00";
                default: return string.Empty;
            }
        }
        private string GetTimeKeyBySessionAndSlot(int sessionIdx, int slot)
        {
            if (sessionIdx == 0) return slot == 0 ? "8:00-9:30" : "9:30-11:00";
            if (sessionIdx == 1) return slot == 0 ? "14:00-15:30" : "15:30-17:00";
            if (sessionIdx == 2) return slot == 0 ? "18:00-19:30" : "19:30-21:00";
            return string.Empty;
        }

        private Color GetColorByCourseId(int courseId)
        {
            Color[] palette = {
                Color.FromArgb(66, 165, 245),  
                Color.FromArgb(102, 187, 106), 
                Color.FromArgb(156, 39, 176),  
                Color.FromArgb(233, 30, 99),  
                Color.FromArgb(255, 193, 7),    
                Color.FromArgb(3, 169, 244),    
                Color.FromArgb(255, 87, 34),  
                Color.FromArgb(0, 150, 136)    
            };

            return palette[Math.Abs(courseId) % palette.Length];
        }

        #endregion
    }
}