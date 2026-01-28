using BaiTapLonWinForm.MongooModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_CardAssignment : UserControl
    {
        private string _newsfeedId;
        public event Action<string, string>? OnSubmitClicked;
        public UC_CardAssignment(Newsfeed data, Assignment assignment)
        {
            InitializeComponent();
            _newsfeedId = data.Id;

            LoadCardAssignment(data, assignment);
        }

        private void LoadCardAssignment(Newsfeed data, Assignment submission)
        {
            lbName.Text = data.Author ?? "Ẩn danh";
            lbCreatedAt.Text = data.PostingAt.ToString("dd/MM/yyyy HH:mm");
            lbContent.Text = data.ContentHtml ?? "Không có nội dung";

            if (submission == null)
            {
                lbStatus.Text = "Chưa nộp";
                lbStatus.ForeColor = Color.Gray;
                return;
            }

            if (submission.IsLate)
            {
                lbStatus.Text = "Nộp muộn";
                lbStatus.ForeColor = Color.Red;
            }
            else
            {
                lbStatus.Text = "Đã nộp";
                lbStatus.ForeColor = Color.Green;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            tbLink.Visible = true;
            panel2.Visible = true;
            if (string.IsNullOrEmpty(_newsfeedId))
            {
                MessageBox.Show("Không lấy được ID bài tập");
                return;
            }
            OnSubmitClicked?.Invoke(_newsfeedId, tbLink.Text);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OnSubmitClicked?.Invoke(_newsfeedId, tbLink.Text);

            // Reset UI
            panel1.Visible = true;
            tbLink.Visible = false;
            panel2.Visible = false;
        }
    }
}
