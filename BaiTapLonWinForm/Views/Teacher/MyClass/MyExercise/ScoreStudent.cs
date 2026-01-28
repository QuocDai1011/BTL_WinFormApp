using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Views.Teacher.ListToDo;
using ServiceStack.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass.MyExercise
{
    public partial class ScoreStudent : UserControl
    {
        private string _assignmentId;
        private readonly ServiceHub _serviceHub;
        public ScoreStudent(ServiceHub serviceHub, string assignmentId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _assignmentId = assignmentId;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel3.AutoScroll = true;
            LoadData();
        }
        public async void LoadData()
        {
            //Lấy dữ liệu Assignment theo _assignmentId và hiển thị
            var assignment = await _serviceHub.AssignmentService.GetAssignmentById(_assignmentId);
            
            if (assignment != null)
            {
                lblAssignmentTitle.Text = assignment.Title;
                txbMaxScore.Text = assignment.MaxScore.ToString();
                var submisstions = await _serviceHub.SubmissionService.GetSubmissionsByAssignmentId(_assignmentId);
                var countSubmission = submisstions.Where(s => s.IsCompleted == false).ToList();
                var countCompleted = submisstions.Where(s => s.IsCompleted == true).ToList();
                lblSubmission.Text = countSubmission.Count.ToString();
                lblCompleted.Text = countCompleted.Count.ToString();
                //Lấy danh sách submission của assignmentId
                var submissionList = await _serviceHub.SubmissionService.GetSubmissionsByAssignmentId(_assignmentId);
                LoadFlow2(submissionList);
                LoadFlow3(submissionList);
            }
        }
        public async void LoadFlow2(List<Submission> submissionList)
        {
            foreach (var item in submissionList)
            {
                var scoreItem = new ListToDoStudent(item)
                {
                    //Dock = DockStyle.Top
                };
                flowLayoutPanel2.Controls.Add(scoreItem);
            }
        }
        public async void LoadFlow3(List<Submission> submissionList)
        {
            foreach (var item in submissionList)
            {
                var scoreItem = new ListToDoStudentStatus(item)
                {
                    //Dock = DockStyle.Top
                };
                flowLayoutPanel3.Controls.Add(scoreItem);
            }
        }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
