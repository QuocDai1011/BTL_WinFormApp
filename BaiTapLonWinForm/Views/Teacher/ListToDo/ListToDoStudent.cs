using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.ListToDo
{
    public partial class ListToDoStudent : UserControl
    {
        public ListToDoStudent(Submission data)
        {
            InitializeComponent();
            LoadData(data);
        }
        private void LoadData(Submission data)
        {
            ckbxName.Text = data.StudentName;
            lblScore.Text = data.Score.HasValue ? data.Score.Value.ToString() : " - ";
            lblStatus.Text = data.Status;
            lblFeedback.Text = string.IsNullOrEmpty(data.Feedback) ? "Chưa có phản hồi" : data.Feedback;
        }
    }
}
