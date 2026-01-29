using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyCalenda
{
    public partial class Calenda : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _teacherId;
        private DateTime _startOfWeek;
        private DateTime _currentWeek;
        private bool _isLoaded = false;
        private Dictionary<DayOfWeek, FlowLayoutPanel> dayMap;
        private List<FlowLayoutPanel> dayColumns = new List<FlowLayoutPanel>();
        private bool _isLoading = false;
        private List<Class> _cachedClasses;

        // Cache schedule items per day to avoid recreation
        private Dictionary<DayOfWeek, List<Control>> _cachedScheduleItems = new Dictionary<DayOfWeek, List<Control>>();

        public Calenda(ServiceHub serviceHub, int teacherId)
            : this(serviceHub, teacherId, false)
        {
        }

        public Calenda(ServiceHub serviceHub, int teacherId, bool isDarkMode)
        {
            InitializeComponent();
            ApplyThemeToAllItems(isDarkMode);
            _serviceHub = serviceHub;
            _teacherId = teacherId;

            // Enable double buffering
            EnableDoubleBuffering();
        }

        private void EnableDoubleBuffering()
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null, this, new object[] { true });

            // Enable for all day containers
            foreach (var day in new[] { pnMonContainer, pnTueContainer, pnWedContainer, pnThuContainer, pnFriContainer, pnSatContainer, pnSunContainer })
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty |
                    BindingFlags.Instance |
                    BindingFlags.NonPublic,
                    null, day, new object[] { true });
            }
        }

        private async void Calenda_Load(object sender, EventArgs e)
        {
            await LoadClassComboAsync();
            dayColumns = new FlowLayoutPanel[]
            {
                pnMon, pnTue, pnWed, pnThu, pnFri, pnSat, pnSun
            }.ToList();
            dayMap = new Dictionary<DayOfWeek, FlowLayoutPanel>()
            {
                { DayOfWeek.Monday, pnMonContainer },
                { DayOfWeek.Tuesday, pnTueContainer },
                { DayOfWeek.Wednesday, pnWedContainer },
                { DayOfWeek.Thursday, pnThuContainer },
                { DayOfWeek.Friday, pnFriContainer },
                { DayOfWeek.Saturday, pnSatContainer },
                { DayOfWeek.Sunday, pnSunContainer }
            };
            _isLoaded = true;
            _currentWeek = DateTime.Now;
            LoadWeek(DateTime.Now);
            _ = LoadScheduleAsync();
        }

        private string timeStartClass(int shift)
        {
            return shift switch
            {
                1 => "8:00 - 9:30",
                2 => "9:30 - 11:00",
                3 => "14:00 - 15:30",
                4 => "15:30 - 17:00",
                5 => "17:30 - 19:00",
                6 => "19:30 - 21:00",
                _ => "Không tìm thấy ca học"
            };
        }

        //private async Task LoadScheduleAsync()
        //{
        //    if (_isLoading) return;
        //    _isLoading = true;

        //    try
        //    {
        //        long selectedClassId = Convert.ToInt64(cbbClassList.SelectedValue);

        //        //var classes = await Task.Run(() => _serviceHub.ClassService.GetAllClass(_teacherId));
        //        var classes = _serviceHub.ClassService.GetAllClass(_teacherId);
        //        _cachedClasses = classes;

        //        if (selectedClassId != 0)
        //        {
        //            classes = classes.Where(c => c.ClassId == selectedClassId).ToList();
        //        }

        //        var scheduleData = await Task.Run(() => PrepareScheduleData(classes));
        //        UpdateScheduleUI(scheduleData);
        //    }
        //    finally
        //    {
        //        _isLoading = false;
        //    }
        //}
        private async Task LoadScheduleAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                long selectedClassId = Convert.ToInt64(cbbClassList.SelectedValue);

                var classes = await _serviceHub.ClassService
                    .GetAllClassAsync(_teacherId);

                _cachedClasses = classes;

                if (selectedClassId != 0)
                {
                    classes = classes
                        .Where(c => c.ClassId == selectedClassId)
                        .ToList();
                }

                // ❌ BỎ Task.Run
                var scheduleData = PrepareScheduleData(classes);

                UpdateScheduleUI(scheduleData);
            }
            finally
            {
                _isLoading = false;
            }
        }
        private Dictionary<DayOfWeek, List<(Class cls, string timeText)>> PrepareScheduleData(List<Class> classes)
        {
            var result = new Dictionary<DayOfWeek, List<(Class, string)>>();

            for (int i = 0; i < 7; i++)
            {
                DateTime date = _startOfWeek.AddDays(i);
                DayOfWeek dow = date.DayOfWeek;

                var classesOfDay = classes
                    .Where(cls =>
                        date >= cls.StartDate.ToDateTime(TimeOnly.MinValue) &&
                        date <= cls.EndDate.ToDateTime(TimeOnly.MinValue) &&
                        _serviceHub.SchoolDayService
                            .GetListSchoolDaysByClassId(cls.ClassId)
                            .Any(day => MatchDayOfWeek(day) == dow)
                    )
                    .OrderBy(cls => cls.Shift)
                    .Select(cls => (cls, timeStartClass(cls.Shift)))
                    .ToList();

                result[dow] = classesOfDay;
            }

            return result;
        }

        private void UpdateScheduleUI(Dictionary<DayOfWeek, List<(Class cls, string timeText)>> scheduleData)
        {
            // Suspend all layouts at once
            foreach (var col in dayMap.Values)
            {
                col.SuspendLayout();
            }

            // Clear only if data changed
            foreach (var col in dayMap.Values)
            {
                col.Controls.Clear();
            }

            // Add schedule items
            foreach (var kvp in scheduleData)
            {
                foreach (var (cls, timeText) in kvp.Value)
                {
                    var item = CreateScheduleItem(cls, timeText);
                    dayMap[kvp.Key].Controls.Add(item);
                }
            }
            foreach (var col in dayMap.Values)
            {
                col.ResumeLayout(false);
            }
            foreach (var col in dayMap.Values)
            {
                col.PerformLayout();
            }
        }

        private DayOfWeek MatchDayOfWeek(string day)
        {
            return day.Trim() switch
            {
                "Thứ Hai" => DayOfWeek.Monday,
                "Thứ Ba" => DayOfWeek.Tuesday,
                "Thứ Tư" => DayOfWeek.Wednesday,
                "Thứ Năm" => DayOfWeek.Thursday,
                "Thứ Sáu" => DayOfWeek.Friday,
                "Thứ Bảy" => DayOfWeek.Saturday,
                "Chủ Nhật" => DayOfWeek.Sunday,
                _ => DayOfWeek.Monday
            };
        }

        private readonly Color[] BaseBlueGreenColors =
        {
            Color.Teal,
            Color.FromArgb(72, 181, 183),
            Color.FromArgb(61, 104, 201),
            Color.FromArgb(176, 247, 195),
            Color.FromArgb(152, 251, 152),
            Color.FromArgb(173, 216, 230),
            Color.FromArgb(175, 238, 238)
        };

        private Color GetColorByClassId(long classId)
        {
            int index = (int)(classId % BaseBlueGreenColors.Length);
            return BaseBlueGreenColors[index];
        }

        private Control CreateScheduleItem(Class cls, string timeText)
        {
            Panel p = new Panel
            {
                BackColor = GetColorByClassId(cls.ClassId),
                Margin = new Padding(3),
                Padding = new Padding(20),
                Dock = DockStyle.Top
            };

            Label lb = new Label
            {
                Text = $"{timeText} - {cls.ClassName}",
                Font = new Font("Segoe UI Semibold", 11F),
                AutoSize = true,
                MaximumSize = new Size(200, 0)
            };

            p.Controls.Add(lb);

            void Layout()
            {
                lb.Location = new Point((p.Width - lb.PreferredWidth) / 2, p.Padding.Top);
                p.Height = lb.PreferredHeight + p.Padding.Vertical;
            }

            p.Resize += (s, e) => Layout();
            lb.SizeChanged += (s, e) => Layout();

            Layout();
            return p;
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = date.DayOfWeek == DayOfWeek.Sunday ? 6 : ((int)date.DayOfWeek - 1);
            return date.AddDays(-diff).Date;
        }

        private void LoadWeek(DateTime date)
        {
            _startOfWeek = GetStartOfWeek(date);

            Guna2HtmlLabel[] dateLabels = { lblDateOfMon, lblDateOfTue, lblDateOfWed, lblDateOfThu, lblDateOfFri, lblDateOfSat, lblDateOfSun };
            Guna2CustomGradientPanel[] headerPanels = { pnLabelMon, pnLabelTue, pnLabelWed, pnLabelThu, pnLabelFri, pnLabelSat, pnLabelSun };

            DateTime today = DateTime.Today;

            for (int i = 0; i < 7; i++)
            {
                DateTime day = _startOfWeek.AddDays(i);
                dateLabels[i].Text = $"{day:dd}";

                bool isToday = day.Date == today;
                dateLabels[i].ForeColor = isToday ? Color.White : Color.Black;

                headerPanels[i].FillColor = isToday ? Color.Teal : Color.White;
                headerPanels[i].FillColor2 = isToday ? Color.Teal : Color.White;
                headerPanels[i].FillColor3 = isToday ? Color.MediumSpringGreen : Color.White;
                headerPanels[i].FillColor4 = isToday ? Color.Teal : Color.White;
            }
            lblWeekRange.Text = $"{_startOfWeek:dd/MM/yyyy} - {_startOfWeek.AddDays(6):dd/MM/yyyy}";
        }

        private void iptbPre_Click(object sender, EventArgs e)
        {
            _currentWeek = _currentWeek.AddDays(-7);
            LoadWeek(_currentWeek);
            _ = LoadScheduleAsync();
        }

        private void iptbNext_Click(object sender, EventArgs e)
        {
            _currentWeek = _currentWeek.AddDays(7);
            LoadWeek(_currentWeek);
            _ = LoadScheduleAsync();
        }

        private async Task LoadClassComboAsync()
        {
            var classes = await _serviceHub.ClassService
                .GetAllClassAsync(_teacherId);

            classes.Insert(0, new Class
            {
                ClassId = 0,
                ClassName = "Tất cả lớp học"
            });

            cbbClassList.DataSource = classes;
            cbbClassList.DisplayMember = "ClassName";
            cbbClassList.ValueMember = "ClassId";
            cbbClassList.SelectedIndex = 0;
        }


        private void cbbClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || cbbClassList.SelectedIndex < 0) return;
            _ = LoadScheduleAsync();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cachedScheduleItems.Clear();
            }
            base.Dispose(disposing);
        }
        public void ApplyThemeToAllItems(bool isDarkMode)
        {
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(0, 16, 20);
                pnCalendaList.FillColor = Color.FromArgb(80, 255, 255, 255);
                pnCalendaList.FillColor2 = Color.FromArgb(80, 255, 255, 255);
                pnCalendaList.FillColor3 = Color.FromArgb(80, 255, 255, 255);
                pnCalendaList.FillColor4 = Color.FromArgb(80, 255, 255, 255);
                flpCalenda.BackColor = Color.Transparent;
                lblWeekRange.ForeColor = Color.White;
                iptbPre.IconColor = Color.White;
                iptbNext.IconColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Transparent;
                pnCalendaList.FillColor = Color.White;
                pnCalendaList.FillColor2 = Color.White;
                pnCalendaList.FillColor3 = Color.White;
                pnCalendaList.FillColor4 = Color.White;
                flpCalenda.BackColor = Color.White;
                lblWeekRange.ForeColor = Color.Black;
                iptbPre.IconColor = Color.Black;
                iptbNext.IconColor = Color.Black;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}