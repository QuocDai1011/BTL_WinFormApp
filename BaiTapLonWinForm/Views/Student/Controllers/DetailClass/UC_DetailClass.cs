using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Views.Student.Controllers.DetailClass;
using System.Diagnostics;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_DetailClass : UserControl
    {
        private string _newsfeedId;
        private int _classId;
        private int _studentId;
        private readonly INewsfeedService _newsfeedService;
        private readonly IAssignmentService _assignmentService;
        private readonly EnglistCenterContext _context;
        public UC_DetailClass(INewsfeedService newsfeedService, IAssignmentService assignmentService, EnglistCenterContext context, int classId, int studentId)
        {
            InitializeComponent();
            _newsfeedService = newsfeedService;
            _assignmentService = assignmentService;
            _context = context;
            _classId = classId;
            _studentId = studentId;
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
            var control = new UC_Newsfeed(_newsfeedService, _assignmentService, _context, _classId, _studentId, _newsfeedId);
            LoadControl(control);
        }

        private void btnAssignment_Click(object sender, EventArgs e)
        {
            var control = new UC_Exercise(_newsfeedService, _assignmentService, _newsfeedId, _studentId);
            LoadControl(control);
        }
    }
}
