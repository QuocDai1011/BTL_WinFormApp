using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using Guna.UI2.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyCalenda
{
    public partial class Calenda : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly long _teacherId;
        private DateTime _startOfWeek;
        private DateTime _currentWeek;
        private bool _isLoaded = false;
        private Dictionary<DayOfWeek, FlowLayoutPanel> dayMap;

        private List<FlowLayoutPanel> dayColumns = new List<FlowLayoutPanel>();
        public Calenda(ServiceHub serviceHub, long teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;
        }
        private void Calenda_Load(object sender, EventArgs e)
        {
            LoadClassCombo();
            dayColumns = new FlowLayoutPanel[]
            {
                pnMon,
                pnTue,
                pnWed,
                pnThu,
                pnFri,
                pnSat,
                pnSun
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
            LoadSchedule();
        }
        private string timeStartClass(int shift)
        {
            switch (shift)
            {
                case 1:
                    return "8:00 - 9:30";
                    break;
                case 2:
                    return "9:30 - 11:00";
                    break;
                case 3:
                    return "14:00 - 15:30";
                    break;
                case 4:
                    return "15:30 - 17:00";
                    break;
                case 5:
                    return "17:30 - 19:00";
                    break;
                case 6:
                    return "19:30 - 21:00";
                    break;
                default:
                    return "Không tìm thấy ca học";
                    break;
            }
        }
        private void LoadSchedule()
        {
            foreach (var col in dayMap.Values)
                col.Controls.Clear();

            long selectedClassId = Convert.ToInt64(cbbClassList.SelectedValue);

            var classes = _serviceHub.ClassService.GetAllClass(_teacherId);

            if (selectedClassId != 0)
            {
                classes = classes
                    .Where(c => c.ClassId == selectedClassId)
                    .ToList();
            }

            for (int i = 0; i < 7; i++)
            {
                DateTime date = _startOfWeek.AddDays(i);
                DayOfWeek dow = date.DayOfWeek;

                // 🔥 LẤY DANH SÁCH LỚP HỌC CỦA NGÀY NÀY
                var classesOfDay = classes
                    .Where(cls =>
                        date >= cls.StartDate.ToDateTime(TimeOnly.MinValue) &&
                        date <= cls.EndDate.ToDateTime(TimeOnly.MinValue) &&
                        _serviceHub.SchoolDayService
                            .GetListSchoolDaysByClassId(cls.ClassId)
                            .Any(day => MatchDayOfWeek(day) == dow)
                    )
                    // 🔥 SORT THEO GIỜ BẮT ĐẦU
                    .OrderBy(cls => cls.Shift)
                    .ToList();

                foreach (var cls in classesOfDay)
                {
                    var item = CreateScheduleItem(cls);
                    dayMap[dow].Controls.Add(item);
                }
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
        private Control CreateScheduleItem(Class cls)
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
                Text = $"{timeStartClass(cls.Shift)} - {cls.ClassName}",
                Font = new Font("Segoe UI Semibold", 11F),
                AutoSize = true,
                MaximumSize = new Size(200, 0)
            };

            p.Controls.Add(lb);

            void Layout()
            {
                lb.Location = new Point(
                    (p.Width - lb.PreferredWidth) / 2,
                    p.Padding.Top
                );

                p.Height = lb.PreferredHeight + p.Padding.Vertical;
            }

            p.Resize += (s, e) => Layout();
            lb.SizeChanged += (s, e) => Layout();

            Layout();
            return p;
        }


        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = date.DayOfWeek == DayOfWeek.Sunday
                ? 6
                : ((int)date.DayOfWeek - 1);

            return date.AddDays(-diff).Date;
        }
        private void LoadWeek(DateTime date)
        {
            _startOfWeek = GetStartOfWeek(date);

            // Gom label ngày vào mảng
            Guna2HtmlLabel[] dateLabels =
            {
                lblDateOfMon,
                lblDateOfTue,
                lblDateOfWed,
                lblDateOfThu,
                lblDateOfFri,
                lblDateOfSat,
                lblDateOfSun
            };

            // Gom panel header vào mảng (Guna2Panel)
            Guna.UI2.WinForms.Guna2CustomGradientPanel[] headerPanels =
            {
                pnLabelMon,
                pnLabelTue,
                pnLabelWed,
                pnLabelThu,
                pnLabelFri,
                pnLabelSat,
                pnLabelSun
            };

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
            LoadSchedule();
        }

        private void iptbNext_Click(object sender, EventArgs e)
        {
            _currentWeek = _currentWeek.AddDays(7);
            LoadWeek(_currentWeek);
            LoadSchedule();

        }
        private void LoadClassCombo()
        {
            var classes = _serviceHub.ClassService.GetAllClass(_teacherId);
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
            if (!_isLoaded) return;
            if (cbbClassList.SelectedIndex < 0)
                return;

            LoadSchedule();
        }
    }
}
