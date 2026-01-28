using BaiTapLonWinForm.MongooModels;
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
            ActiveBtnSubmit(type);
            LoadNewsFeed(data);
            LoadColoLabel();
        }

        private void LoadNewsFeed(Newsfeed data)
        {
            lbName.Text = data.Author ?? "Không rõ";
            lbCreatedAt.Text = data.PostingAt
                .ToLocalTime().ToString("dd/MM/yyyy HH:mm");
            lbContent.Text = data.Content;
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

        private void ActiveBtnSubmit(string type)
        {
            if (type != "assignment")
            {
                btnSubmit.Visible = false;
                return;
            }

            btnSubmit.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var control = new UC_SubmitAssignment(_assignmentService , _newsfeedId, _studentId);

            control.OnSubmitted += () =>
            {
                // 1️⃣ Đóng UC_SubmitAssignment
                pnAction.Controls.Clear();

                // 2️⃣ Reload lại giao diện / trạng thái
                ReloadAssignmentStatus();
            };

            control.Dock = DockStyle.Fill;
            pnAction.Controls.Clear();
            pnAction.Controls.Add(control);
        }

        private void LoadColoLabel()
        {
            lbStatus.Text = _assignmentService.GetStatus(_newsfeedId);

            string status = lbStatus.Text;

            if (status == "Nộp muộn") lbStatus.ForeColor = Color.Red;
            if (status == "Đã nộp") lbStatus.ForeColor = Color.Green;
        }

        private void ReloadAssignmentStatus()
        {
            btnAddComment.Visible = true;
            btnSubmit.Visible = true;
        }
    }
}
