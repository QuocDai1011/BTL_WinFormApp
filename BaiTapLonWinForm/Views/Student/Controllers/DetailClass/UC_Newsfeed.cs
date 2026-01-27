using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using System.Diagnostics;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_Newsfeed : UserControl
    {
        private readonly INewsfeedService _newsfeedService;
        private readonly EnglistCenterContext _context;
        private int _classId;
        public UC_Newsfeed(INewsfeedService newsfeedService, EnglistCenterContext context, int classId)
        {
            InitializeComponent();
            _newsfeedService = newsfeedService;
            _context = context;
            _classId = classId;
        }

        private void LoadControl(UserControl control)
        {
            //pnFeed.Controls.Clear();
            control.Dock = DockStyle.Top;
            pnFeed.Controls.Add(control);
        }

        private void UC_Newsfeed_Load(object sender, EventArgs e)
        {
            pnFeed.Controls.Clear();

            var data = _newsfeedService.GetAllNewsfeedByClassId(_classId);

            if (!data.Any())
            {
                MessageHelper.ShowWarning("Không có thông báo nào", "Thông báo");
                return;
            }

            foreach (var item in data)
            {
                var control = new UC_CardFeed(item);
                LoadControl(control);
            }
        }

        private string? GetLinkMeetByClassId(int classId)
        {
            string? meetLink = _context.Classes
                .Where(c => c.ClassId == classId)
                .Select(c => c.OnlineMeetingLink)
                .FirstOrDefault();

            return meetLink;
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            var meetUrl = GetLinkMeetByClassId(_classId);

            if(meetUrl == null)
            {
                MessageHelper.ShowInfo("Lớp học trực tuyến chưa được mở", "Thông báo");
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = meetUrl,
                UseShellExecute = true
            });
        }
    }
}
