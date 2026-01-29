using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
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
    public partial class ExerciseItem : UserControl
    {
        public event Action<string> OnOpenScoreDetail;
        private readonly ServiceHub _serviceHub;
        private string _assignmentId;
        public event Action<Assignment> EditRequested;
        public ExerciseItem(ServiceHub serviceHub, Assignment data)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            LoadData(data);
        }
        private async void LoadData(Assignment data)
        {
            _assignmentId = data.Id;
            lblTitle.Text = data.Title;
            lblDeadline.Text = "Đến hạn " + data.DueTime.ToString("dd/MM/yyyy HH:mm");
            var submisstions = await _serviceHub.SubmissionService.GetSubmissionsByAssignmentId(data.Id);
            var countSubmission = submisstions.Where(s => s.IsCompleted == true).ToList();
            var countCompleted = submisstions.Where(s => s.Score != null).ToList();
            lblSubmisstion.Text = countSubmission.Count.ToString();
            //lblgraded.Text = data.GradedCount.ToString();
            lblcompleted.Text = countCompleted.Count.ToString();
        }
        private void mnsc3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_assignmentId)) return;

            OnOpenScoreDetail?.Invoke(_assignmentId);
            //Thêm link label ở header để quay về danh sách bài tập
        }

        private async void mscItem1_Click(object sender, EventArgs e)
        {
            var assignment = await _serviceHub.AssignmentService.GetAssignmentById(_assignmentId);

            if (assignment == null) return;

            EditRequested?.Invoke(assignment);
        }
    }
}
