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
        private List<Assignment> _allAssignments = new();
        public event Action<string> OnOpenScoreDetail;
        public event Action<Assignment> OnEditExercise;
        private ServiceHub _serviceHub;
        private long _userId;
        private int _teacherId;
        public ToDoDetail(ServiceHub serviceHub, long userId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _userId = userId;
            LoadExerciseItems();
        }
        private async void LoadExerciseItems()
        {
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
        }
        public async Task LoadCbxCourseNameFromCache()
        {
            cbxClassList.BeginUpdate();
            cbxClassList.Items.Clear();
            cbxClassList.Items.Add("Tất cả lớp học");

            _teacherId = _serviceHub.TeacherService.GetTeacherByUserId(_userId);

            var teacher =
                await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);

            var classes =
                await _serviceHub.ClassService
                    .GetAllClassAsync(teacher.Data.TeacherId);

            foreach (var cl in classes.OrderBy(c => c.ClassName))
            {
                cbxClassList.Items.Add(cl.ClassName);
            }

            cbxClassList.SelectedIndex = 0;
            cbxClassList.EndUpdate();
        }
    }
}
