using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Dashboard : UserControl
    {
        private readonly IStudentService _studentService;
        private readonly INewsfeedService _newsfeedService;
        private readonly EnglishCenterDbContext _context;
        private List<ClassDto> _cachedClasses;
        public UC_Dashboard(IStudentService service, INewsfeedService newsfeedService, EnglishCenterDbContext context, int studentId)
        {
            InitializeComponent();
            _studentService = service;
            _cachedClasses = _studentService.GetClassesByStudentId(studentId);
            _context = context;
            _newsfeedService = newsfeedService;
            LoadClasses(studentId);
        }

        private void LoadClasses(int studentId)
        {
            FlowLayoutPanel flpRender = new FlowLayoutPanel();
            flpRender.Dock = DockStyle.Fill;

            if (_cachedClasses == null)
            {
                MessageHelper.ShowError("Không tìm thấy khóa học", "Lỗi");
                return;
            }

            foreach (var item in _cachedClasses)
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
            var ucDetail = new UC_DetailClass(_newsfeedService, _context);
            ucDetail.LoadDetailClass(classId);

            pnlRender.Controls.Clear();
            ucDetail.Dock = DockStyle.Fill;
            pnlRender.Controls.Add(ucDetail);
        }
    }
}
