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
    public partial class ExerciseDetail : UserControl
    {
        public event Action<string> OnOpenScoreDetail;
        public event Action<int> OnAddExercise;
        public event Action<Assignment> OnEditExercise;
        private readonly ServiceHub _serviceHub;
        private readonly int _classId;
        public ExerciseDetail(ServiceHub serviceHub, int classId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _classId = classId;
            LoadExerciseItems();
        }
        private async void LoadExerciseItems()
        {
            var exerciseList = await _serviceHub.AssignmentService
                .GetAssignmentsByClassId(_classId);

            foreach (var exercise in exerciseList)
            {
                var item = new ExerciseItem(_serviceHub, exercise);

                item.EditRequested += (assignment) =>
                {
                    OnEditExercise?.Invoke(assignment);
                };
                item.OnOpenScoreDetail += assignmentId =>
                {
                    OnOpenScoreDetail?.Invoke(assignmentId);
                };

                flpnExerciseList.Controls.Add(item);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            OnAddExercise?.Invoke(_classId);
        }
    }
}
