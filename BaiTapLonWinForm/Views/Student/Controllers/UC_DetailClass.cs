namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_DetailClass : UserControl
    {
        private int _classId;
        public UC_DetailClass()
        {
            InitializeComponent();
        }

        public void LoadDetailClass(int classId)
        {
            _classId = classId;
        }
    }
}
