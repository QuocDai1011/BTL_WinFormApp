using BaiTapLonWinForm.Services.Interfaces;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_SubmitAssignment : UserControl
    {
        public event Action OnSubmitted;
        private readonly IAssignmentService _assignmentService;
        private string _newsfeedId;
        private int _studentId;
        public UC_SubmitAssignment(IAssignmentService assignmentService , string newsfeedId, int studentId)
        {
            InitializeComponent();
            _assignmentService = assignmentService;
            _newsfeedId = newsfeedId;
        }
    }
}
