using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Views.Teacher.MyClass.MyExercise;
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
    public partial class ToDoDetail : UserControl
    {
        public event Action<string> OnOpenScoreDetail;
        public event Action<Assignment> OnEditExercise;
        private readonly ServiceHub _serviceHub;
        private readonly long _userId;
        public ToDoDetail(ServiceHub serviceHub, long userId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _userId = userId;
            LoadExerciseItems();
        }
        private async void LoadExerciseItems()
        {
            //var item = new ExerciseItem();

            //item.OnOpenScoreDetail += () =>
            //{
            //    OnOpenScoreDetail?.Invoke();
            //};

            //flpnExerciseList.Controls.Add(item);

            //Hiển thị các Assignment tất cả các lớp học vào flpnExerciseList
            //Tìm các Newsfeed của user hiện tại
            var newsfeedList = await _serviceHub.NewsfeedService.GetAllNewsfeedsByUserId(_userId);
            newsfeedList.ForEach(async newsfeed =>
            {
                //Lấy Assignment từ Newsfeed
                var assignment = await _serviceHub.AssignmentService.GetAllAssignmentsByNewsfeedId(newsfeed.Id);
                var exerciseItem = new ExerciseItem(_serviceHub, assignment);
                exerciseItem.EditRequested += (assignment) =>
                {
                    OnEditExercise?.Invoke(assignment);
                };
                exerciseItem.OnOpenScoreDetail += (assignmentId) =>
                {
                    OnOpenScoreDetail?.Invoke(assignmentId);
                };
                flpnExerciseList.Controls.Add(exerciseItem);
            });

            //Lấy tất cả các Assignment từ các Newsfeed đó
            //var assignmentList = await _serviceHub.AssignmentService.GetAllAssignmentsByUserId(_userId);

        }

        private void btnMainAction1_Click(object sender, EventArgs e)
        {

        }
    }
}
