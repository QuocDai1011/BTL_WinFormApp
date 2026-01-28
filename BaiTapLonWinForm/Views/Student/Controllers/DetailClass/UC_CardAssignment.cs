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
        public UC_CardAssignment(Newsfeed data)
        {
            InitializeComponent();
            _newsfeedId = data.Id;

            LoadCardAssignment(data);
        }

        private void LoadCardAssignment(Newsfeed data)
        {
            lbName.Text = data.Author ?? "Ẩn danh";
            lbCreatedAt.Text = data.PostingAt.ToString("dd/MM/yyyy HH:mm") ?? "Không rõ";
            lbContent.Text = data.ContentHtml ?? "Không có nội dung trong đoạn thông báo này";
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
