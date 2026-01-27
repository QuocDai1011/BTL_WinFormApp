using BaiTapLonWinForm.DTOs;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_CardCalendar : UserControl
    {
        private static readonly Random _rand = new Random();

        public UC_CardCalendar(ScheduleDto data)
        {
            InitializeComponent();
            LoadValueClass(data);
        }

        private Color GetRandomWinFormColor()
        {
            Color[] colors =
            {
                Color.LightBlue,
                Color.LightGreen,
                Color.LightPink,
                Color.LightYellow,
                Color.LightCoral,
                Color.LightSalmon,
                Color.LightSkyBlue,
                Color.LightSeaGreen,
                Color.LightSteelBlue,
                Color.PaleTurquoise,
                Color.PeachPuff,
                Color.MistyRose
            };

            return colors[_rand.Next(colors.Length)];
        }

        private void LoadValueClass(ScheduleDto data)
        {
            pnColor.BackColor = GetRandomWinFormColor();
            lbNameClass.Text = data.Course;
            startDate.Text = $"{data.StartDate:dd/MM/yyyy}";
            endDate.Text = $"{data.EndDate:dd/MM/yyyy}";
        }
    }
}
