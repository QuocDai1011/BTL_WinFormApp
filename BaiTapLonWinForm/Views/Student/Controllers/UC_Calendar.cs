namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Calendar : UserControl
    {
        public UC_Calendar()
        {
            InitializeComponent();
            LoadDetailCalendar();
        }

        public void LoadDetailCalendar()
        {
            UC_CardCalendar control = new UC_CardCalendar();
            control.Dock = DockStyle.Fill;

            tbCalendar.Controls.Add(control, 1, 1);
        }
    }
}
