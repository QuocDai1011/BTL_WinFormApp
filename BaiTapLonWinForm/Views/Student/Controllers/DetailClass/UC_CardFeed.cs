using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services.Interfaces;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_CardFeed : UserControl
    {
        private readonly IAssignmentService _assignmentService;
        private int _studentId;
        private string _newsfeedId;
        public UC_CardFeed(Newsfeed data, IAssignmentService assignmentService, string type, string newsfeedId, int studentId)
        {
            InitializeComponent();
            _newsfeedId = newsfeedId;
            _assignmentService = assignmentService;
            _studentId = studentId;
            LoadNewsFeed(data);
            //LoadColoLabel();
        }

        private void LoadNewsFeed(Newsfeed data)
        {
            lbName.Text = data.Author ?? "Không rõ";
            lbCreatedAt.Text = data.PostingAt
                .ToLocalTime().ToString("dd/MM/yyyy HH:mm");
            lbContent.Text = data.ContentHtml;
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            tbinput.Visible = true;
            btnSend.Visible = true;
            btnAddComment.Visible = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            tbinput.Visible = false;
            btnSend.Visible = false;
            btnAddComment.Visible = true;
        }
    }
}
