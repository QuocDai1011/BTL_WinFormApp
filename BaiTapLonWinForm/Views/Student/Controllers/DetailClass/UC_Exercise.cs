using BaiTapLonWinForm.Services.Interfaces;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_Exercise : UserControl
    {
        private readonly IAssignmentService _assignmentCollection;
        private int _classId;
        private int _studentId;
        private string _newsfeedId;
        public UC_Exercise(IAssignmentService assignmentCollection, int studentId)
        {
            InitializeComponent();
            _assignmentCollection = assignmentCollection;
            _studentId = studentId;
        }

        public void BindData(int classId)
        {
            _classId = classId;
            LoadCardAssignment();
        }

        private void LoadCardAssignment()
        {
            var assignment = _assignmentCollection
                .GetAssignmentByNewsfeedIdAndClassId(_classId);

            if (assignment.Count == 0)
            {
                MessageBox.Show("Không có bài tập nào được giao", "Thông báo");
                return;
            }

            foreach (var item in assignment)
            {
                var submission = _assignmentCollection
                    .GetByNewsfeedAndStudent(item.Id, _studentId);
                var control = new UC_CardAssignment(item, submission);
                control.OnSubmitClicked += HandleSubmitAssignment;
                control.Dock = DockStyle.Top;
                this.Controls.Add(control);
            }
        }

        private void HandleSubmitAssignment(string newsfeedId)
        {
            _assignmentCollection.SubmitAssignment(newsfeedId, _studentId);
        }
    }
}
