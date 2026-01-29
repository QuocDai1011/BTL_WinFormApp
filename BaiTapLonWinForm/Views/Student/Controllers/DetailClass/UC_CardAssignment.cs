using BaiTapLonWinForm.Models;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_CardAssignment : UserControl
    {
        private string _newsfeedId;
        public event Action<string>? OnSubmitClicked;
        public UC_CardAssignment(Newsfeed data, Assignment assignment)
        {
            InitializeComponent();
            _newsfeedId = data.Id;

            LoadCardAssignment(data, assignment);
        }

        private void LoadCardAssignment(Newsfeed data, Assignment assignment)
        {
            lbName.Text = data.Author ?? "Ẩn danh";
            lbCreatedAt.Text = data.PostingAt.ToString("dd/MM/yyyy HH:mm");
            lbContent.Text = data.ContentHtml ?? "Không có nội dung";

            // Nếu đã Done thì disable nút
            if (assignment.Status == "Đã nộp")
            {
                btnSubmit.Text = "✔️Done";
                btnSubmit.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_newsfeedId))
            {
                MessageBox.Show("Không lấy được ID bài tập");
                return;
            }
            OnSubmitClicked?.Invoke(_newsfeedId);
            btnSubmit.Text = "✔️Done";
            btnSubmit.Enabled = false;
        }
    }
}
