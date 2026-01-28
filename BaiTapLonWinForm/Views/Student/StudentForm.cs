using BaiTapLonWinForm.Views.Student.Controllers;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Services;

namespace BaiTapLonWinForm.Views.Student
{
    public partial class StudentForm : Form
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IReceiptService _receiptService;

        private readonly ServiceHub _serviceHub;
        private readonly int _studentId = 2;
        public StudentForm(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            lbTitle.Text = "";
        }

        private async Task LoadControllerAsync(UserControl control)
        {
            pnlLoader.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlLoader.Controls.Add(control);

            if (control is IAsyncLoadable asyncLoadable)
            {
                await asyncLoadable.LoadAsync();
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(241, 240, 236);
        }

        private async void ptrAvatar_Click(object sender, EventArgs e)
        {
            ButtonOff();

            lbTitle.Text = "Thông tin cá nhân";

            var uc = new UC_DetailStudent(_serviceHub.StudentService);
            uc.LoadDetailStudent(_studentId);

            await LoadControllerAsync(uc);
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ButtonOff();
            BtnDashboard.ForeColor = Color.Black;
            BtnDashboard.FillColor = Color.White;
            BtnDashboard.FillColor2 = Color.White;

            lbTitle.Text = "Lớp học";

            LoadControllerAsync(new UC_Dashboard(_serviceHub.StudentService));
        }

        private void BtnCalender_Click(object sender, EventArgs e)
        {
            ButtonOff();
            BtnCalender.ForeColor = Color.Black;
            BtnCalender.FillColor = Color.White;
            BtnCalender.FillColor2 = Color.White;

            lbTitle.Text = "Lịch học";

            LoadControllerAsync(new UC_Calendar());
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            ButtonOff();
            BtnBuy.ForeColor = Color.Black;
            BtnBuy.FillColor = Color.White;
            BtnBuy.FillColor2 = Color.White;

            lbTitle.Text = "Mua khóa học";

            LoadControllerAsync(new UC_BuyCourse(_serviceHub.CourseService, _studentId));
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            ButtonOff();
            BtnReceipt.ForeColor = Color.Black;
            BtnReceipt.FillColor = Color.White;
            BtnReceipt.FillColor2 = Color.White;

            lbTitle.Text = "Hóa đơn";

            LoadControllerAsync(new UC_Receipt(_serviceHub.ReceiptService, _studentId));
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            ButtonOff();
            BtnLogOut.ForeColor = Color.Black;
            BtnLogOut.FillColor = Color.White;
            BtnLogOut.FillColor2 = Color.White;
        }

        private void ButtonOff()
        {
            BtnDashboard.ForeColor = Color.White;
            BtnDashboard.FillColor = Color.Transparent;
            BtnDashboard.FillColor2 = Color.Transparent;

            BtnCalender.ForeColor = Color.White;
            BtnCalender.FillColor = Color.Transparent;
            BtnCalender.FillColor2 = Color.Transparent;

            BtnBuy.ForeColor = Color.White;
            BtnBuy.FillColor = Color.Transparent;
            BtnBuy.FillColor2 = Color.Transparent;

            BtnReceipt.ForeColor = Color.White;
            BtnReceipt.FillColor = Color.Transparent;
            BtnReceipt.FillColor2 = Color.Transparent;

            BtnLogOut.ForeColor = Color.White;
            BtnLogOut.FillColor = Color.Transparent;
            BtnLogOut.FillColor2 = Color.Transparent;
        }
    }
}
