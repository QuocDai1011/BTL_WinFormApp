using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;


namespace BaiTapLonWinForm.View.Admin.Teacher
{
    public partial class TeacherManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private List<Models.Teacher> teachers;
        public TeacherManagement(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            refreshDataGridView();
        }


        private async void refreshDataGridView()
        {
            var teacher = await _serviceHub.TeacherService.GetAllTeachersAsync();
            if (!teacher.Success)
            {
                MessageHelper.ShowError(teacher.Message);
            }
            teachers = teacher.Data.ToList();

            LoadDataGridView(teachers);
        }

        private void LoadDataGridView(List<Models.Teacher> teachers)
        {
            dgvTeachers.Rows.Clear();

            foreach (var t in teachers)
            {
                dgvTeachers.Rows.Add(
                    $"{t.User.FirstName} {t.User.LastName}",
                    t.User.Email,
                    t.User.PhoneNumber,
                    t.User.DateOfBirth,
                    t.User.Gender == true ? "Nam" : "Nữ",
                    t.User.Address == null ? "N/A" : t.User.Address,
                    t.User.FirstName,
                    t.User.LastName,
                    t.ExperienceYear,
                    t.Salary,
                    t.TeacherId,
                    t.User.UserId
                    );
            }

        }

        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataGridView(teachers);
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn giảng viên để xóa.");
                return;
            }

            int teacherId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["ColTeacherId"].Value);

            var confirm = MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn xóa giảng viên này?");
            if (!confirm)
                return;
            var deleteResult = await _serviceHub.TeacherService.DeleteTeacherAsync(teacherId);

            if (!deleteResult.Success)
            {
                MessageHelper.ShowError(deleteResult.Message);
                return;
            }
            MessageHelper.ShowSuccess(deleteResult.Message);
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(new AddTeacher(_serviceHub));
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dgvTeachers.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn giáo viên để cập nhật.");
                return;
            }

            Controls.Clear();
            
            int teacherId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["ColTeacherId"].Value);
            
            var teacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(teacherId);

            if(!teacher.Success)
            {
                MessageHelper.ShowError(teacher.Message);
                return;
            }

            Controls.Add(new AddTeacher(_serviceHub, teacher.Data) { Dock = DockStyle.Fill});
        }
    }
}
