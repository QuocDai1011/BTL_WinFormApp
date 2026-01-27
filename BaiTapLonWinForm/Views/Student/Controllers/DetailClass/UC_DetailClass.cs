using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Views.Student.Controllers.DetailClass;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_DetailClass : UserControl
    {
        private int _classId;
        private readonly INewsfeedService _newsfeedService;
        private readonly EnglistCenterContext _context;
        public UC_DetailClass(INewsfeedService newsfeedService, EnglistCenterContext context)
        {
            InitializeComponent();
            _newsfeedService = newsfeedService;
            _context = context;
        }

        private void LoadControl(UserControl control)
        {
            pnLoad.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnLoad.Controls.Add(control);
        }

        public void LoadDetailClass(int classId)
        {
            _classId = classId;
        }

        private void btnNewsFeed_Click_1(object sender, EventArgs e)
        {
            var control = new UC_Newsfeed(_newsfeedService, _context, _classId);
            LoadControl(control);
        }

        private void btnAssignment_Click(object sender, EventArgs e)
        {
            var control = new UC_Exercise();
            LoadControl(control);
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            var control = new UC_People();
            LoadControl(control);
        }
    }
}
