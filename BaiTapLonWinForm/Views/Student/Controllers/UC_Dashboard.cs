using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Dashboard : UserControl
    {
        private readonly IStudentService _service;
        public UC_Dashboard(IStudentService service)
        {
            _service = service;
            InitializeComponent();
            LoadClasses(35);
        }

        private void LoadClasses(int studentId)
        {
            var classes = _service.GetClassesByStudentId(studentId);
            FlowLayoutPanel flpRender = new FlowLayoutPanel();
            flpRender.Dock = DockStyle.Fill;

            if (classes == null)
            {
                MessageHelper.ShowError("Không tìm thấy khóa học", "Lỗi");
                return;
            }

            foreach (var item in classes)
            {
                var classroom = new UC_Class();

                classroom.LoadClass(item);

                classroom.OnDataSend += HandleClassSelected;

                flpRender.Controls.Add(classroom);

                pnlRender.Controls.Clear();
                pnlRender.Controls.Add(flpRender);
            }
        }

        private void HandleClassSelected(int classId)
        {
            LoadClassDetail(classId);
        }

        private void LoadClassDetail(int classId)
        {
            var ucDetail = new UC_DetailClass();
            ucDetail.LoadDetailClass(classId);

            pnlRender.Controls.Clear();
            ucDetail.Dock = DockStyle.Fill;
            pnlRender.Controls.Add(ucDetail);
        }
    }
}
