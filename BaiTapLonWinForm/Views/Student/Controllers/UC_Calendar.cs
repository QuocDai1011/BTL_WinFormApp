using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Calendar : UserControl
    {
        private readonly IStudentService _studentService;
        private readonly int _studentId;
        private DateOnly Monday, Sunday;
        private List<ScheduleDto>? _cachedSchedule;

        public UC_Calendar(IStudentService studentService, int studentId)
        {
            InitializeComponent();
            _studentService = studentService;
            _studentId = studentId;

            Monday = DateOnly.FromDateTime(DaysOfWeek.GetMondayOfWeek(DateTime.Today));
            Sunday = Monday.AddDays(6);

            lbDays.Text = $"{Monday:dd/MM/yyyy} - {Sunday:dd/MM/yyyy}";

            _cachedSchedule = _studentService.GetScheduleClass(_studentId);

            LoadDetailCalendar();
        }

        private void LoadDetailCalendar()
        {
            if (_cachedSchedule == null || !_cachedSchedule.Any())
            {
                MessageHelper.ShowInfo("Lịch học trống, hãy mua khóa học để bắt đầu", "Thông báo");
                return;
            }

            foreach (var item in _cachedSchedule)
            {
                int row = GetRowByShift(item.Shift);
                if (row == -1) continue;

                if (item.SchoolDays == null || !item.SchoolDays.Any())
                    continue;

                DateOnly rangeStart = item.StartDate > Monday ? item.StartDate : Monday;
                DateOnly rangeEnd = item.EndDate < Sunday ? item.EndDate : Sunday;

                if (rangeStart > rangeEnd)
                    continue;

                var schoolDaySet = item.SchoolDays.ToHashSet();

                for (DateOnly date = rangeStart; date <= rangeEnd; date = date.AddDays(1))
                {
                    byte dayOfWeek = ConvertToSchoolDay(date.DayOfWeek);

                    if (!schoolDaySet.Contains(dayOfWeek))
                        continue;

                    int col = GetColumnByDay(dayOfWeek);
                    if (col == -1) continue;

                    UC_CardCalendar control = new UC_CardCalendar(item);
                    control.Dock = DockStyle.Fill;
                    tbCalendar.Controls.Add(control, col, row);
                }
            }
        }


        int GetRowByShift(int shift)
        {
            return shift switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                6 => 6,
                _ => -1
            };
        }

        int GetColumnByDay(byte day)
        {
            return day switch
            {
                2 => 1,
                3 => 2,
                4 => 3,
                5 => 4,
                6 => 5,
                7 => 6,
                8 => 7, // Chủ nhật
                _ => -1
            };
        }

        private byte ConvertToSchoolDay(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday => 2,
                DayOfWeek.Tuesday => 3,
                DayOfWeek.Wednesday => 4,
                DayOfWeek.Thursday => 5,
                DayOfWeek.Friday => 6,
                DayOfWeek.Saturday => 7,
                DayOfWeek.Sunday => 8,
                _ => 0
            };
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Monday = Monday.AddDays(-7);
            Sunday = Monday.AddDays(6);

            UpdateWeekLabel();
            tbCalendar.SuspendLayout();
            ClearCalendarCards();
            LoadDetailCalendar();
            tbCalendar.ResumeLayout();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Monday = Monday.AddDays(7);
            Sunday = Monday.AddDays(6);

            UpdateWeekLabel();
            tbCalendar.SuspendLayout();
            ClearCalendarCards();
            LoadDetailCalendar();
            tbCalendar.ResumeLayout();
        }

        private void UpdateWeekLabel()
        {
            lbDays.Text = $"{Monday:dd/MM/yyyy} - {Sunday:dd/MM/yyyy}";
        }

        private void ClearCalendarCards()
        {
            var toRemove = tbCalendar.Controls
                .OfType<UC_CardCalendar>()
                .ToList();

            foreach (var c in toRemove)
                tbCalendar.Controls.Remove(c);
        }
    }
}
