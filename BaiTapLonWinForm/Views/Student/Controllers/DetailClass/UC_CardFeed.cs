using BaiTapLonWinForm.MongooModels;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_CardFeed : UserControl
    {

        public UC_CardFeed(Newsfeed data)
        {
            InitializeComponent();
            LoadNewsFeed(data);
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
            btnAddComment.Visible = true ;
        }
    }
}
