using BaiTapLonWinForm.Models;
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

            ApplyCurrentFilter();

        }

        #region filter and load data

        private void ApplyCurrentFilter()
        {
            if (teachers == null || !teachers.Any()) return;

            string selectedFilter = cboFilter.SelectedItem?.ToString() ?? "Tất cả";
            List<Models.Teacher> filteredList = new List<Models.Teacher>();

            switch (selectedFilter)
            {
                case "Nam":
                    filteredList = teachers
                        .Where(s => s.User.Gender == true)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    btnRestore.Visible = false;

                    break;
                case "Nữ":
                    filteredList = teachers
                        .Where(s => s.User.Gender == false)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    btnRestore.Visible = false;

                    break;
                case "Đang hoạt động":
                    filteredList = teachers
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    btnRestore.Visible = false;

                    break;
                case "Ngừng hoạt động":
                    filteredList = teachers
                        .Where(s => s.User.IsActive == false)
                        .ToList();
                    btnRestore.Visible = true;
                    break;
                case "Chưa có ảnh":
                    filteredList = teachers
                        .Where(t => t.TeacherFaceImages == null || t.TeacherFaceImages.Count == 0)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    btnRestore.Visible = false;

                    break;
                case "Có ảnh":
                    filteredList = teachers
                        .Where(t => t.TeacherFaceImages != null && t.TeacherFaceImages.Count > 0)
                        .Where(s => s.User.IsActive == true)
                        .ToList();
                    btnRestore.Visible = false;

                    break;
                case "Tất cả":
                default:
                    filteredList = teachers.Where(s => s.User.IsActive == true).ToList();
                    btnRestore.Visible = false;

                    break;
            }

            LoadDataGridView(filteredList);
        }

        private void LoadDataGridView(List<Models.Teacher> teachers)
        {
            dgvTeachers.Rows.Clear();

            foreach (var t in teachers)
            {
                int imageCount = t.TeacherFaceImages?.Count ?? 0;
                int rowIndex = dgvTeachers.Rows.Add(
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
                    t.User.UserId,
                    imageCount > 0 ? $"✓ {imageCount} ảnh" : "✗ Chưa có"
                    );
                var row = dgvTeachers.Rows[rowIndex];
                string status = row.Cells[12].Value.ToString();
                if (status.StartsWith("✗"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                }
            }


        }

        #endregion

        #region handle events
        private void CboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyCurrentFilter();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilter.SelectedIndex = 0;
            refreshDataGridView();
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn giảng viên để xóa.");
                return;
            }

            int userId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["ColUserId"].Value);

            var confirm = MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn xóa giảng viên này?");

            if (!confirm)
                return;

            // chỉ cập nhật isActive chứ không xóa hẳn (Xóa mềm)
            var deleteResult = await _serviceHub.UserService.DeactivateUserAsync(userId);

            if (!deleteResult.Success)
            {
                MessageHelper.ShowError(deleteResult.Message);
                return;
            }
            MessageHelper.ShowSuccess(deleteResult.Message);
            refreshDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAddTeacherControl(null);

        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn giáo viên để cập nhật.");
                return;
            }

            int teacherId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["ColTeacherId"].Value);

            var teacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(teacherId);


            if (!teacher.Success)
            {
                MessageHelper.ShowError(teacher.Message);
                return;
            }

            OpenAddTeacherControl(teacher.Data);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower().Trim();
            Console.WriteLine("Key word: " + search);
            if (!string.IsNullOrEmpty(search))
            {
                return;
            }

            var filteredTeacher = teachers.Where(t => (t.User.FirstName + " " + t.User.LastName).ToLower().Contains(search) ||
                                                t.User.Email.ToLower().Contains(search)
                                                ).ToList();

            LoadDataGridView(filteredTeacher);

        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn giảng viên bạn muốn khôi phục.");
                return;
            }

            int userId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["ColUserId"].Value);

            var result = await _serviceHub.UserService.ActivateUserAsync((long)userId);

            if (!result.Success)
            {
                MessageHelper.ShowError("Lỗi: " + result.Message);
            }
            MessageHelper.ShowSuccess("Đã khôi phục người dùng thành công");
            refreshDataGridView();
        }

        private void btnAddImages_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn sinh viên cần thêm ảnh!");
                return;
            }

            int studentId = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["ColTeacherId"].Value);

            panelGrid.Visible = false;
            var addPhotoControl = new AddPhoto(_serviceHub, studentId) { Dock = DockStyle.Fill };

            addPhotoControl.CloseRequested += (s, args) =>
            {
                this.Controls.Remove(addPhotoControl);

                panelGrid.Visible = true;

                refreshDataGridView();
            };

            this.Controls.Add(addPhotoControl);
            addPhotoControl.BringToFront();
        }

        #endregion

        #region helper method
        private void OpenAddTeacherControl(Models.Teacher teacher)
        {
            panelGrid.Visible = false;

            var addView = new AddTeacher(_serviceHub, teacher)
            {
                Dock = DockStyle.Fill
            };

            addView.CloseRequested += (s, args) =>
            {
                this.Controls.Remove(addView);

                panelGrid.Visible = true;

                refreshDataGridView();
            };

            this.Controls.Add(addView);
            addView.BringToFront();
        }
        #endregion
    }
}
