using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Class
{
    public partial class AddStudentToClass : UserControl
    {
        private readonly ServiceHub _serviceHub;

        private readonly int _classId;

        private List<Student> _allStudents = new List<Student>();
        public event EventHandler OnCloseRequired;
        public event EventHandler OnStudentsAdded;
        public AddStudentToClass(ServiceHub serviceHub, int classId)
        {
            _serviceHub = serviceHub;
            _classId = classId;
            InitializeComponent();
            this.Load += AddStudentToClass_Load;
        }
        private async void AddStudentToClass_Load(object sender, EventArgs e)
        {

            await LoadDataAsync();

        }

        #region load data 
        private async Task LoadDataAsync()
        {
            try
            {
                // Lấy tất cả sinh viên
                var resultAll = await _serviceHub.StudentService.GetAllStudentsAsync();
                if (!resultAll.Success)
                {
                    MessageHelper.ShowError("Không thể tải danh sách sinh viên.");
                    return;
                }

                var resultInClass = await _serviceHub.StudentService.GetStudentsByClassIdAsync(_classId);
                var existingStudentIds = new HashSet<int>();

                if (resultInClass.Success && resultInClass.Data != null)
                {
                    existingStudentIds = resultInClass.Data.Select(s => s.StudentId).ToHashSet();
                }

                _allStudents = resultAll.Data
                    .Where(s => !existingStudentIds.Contains(s.StudentId))
                    .OrderBy(s => s.User.LastName) 
                    .ToList();

                BindGrid(_allStudents);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi: {ex.Message}");
            }
        }

        private void BindGrid(List<Student> students)
        {
            dgvAvailableStudents.Rows.Clear();
            foreach (var s in students)
            {
                if (s.User != null)
                {
                    dgvAvailableStudents.Rows.Add(
                        false, // Checkbox mặc định unchecked
                        s.StudentId,
                        $"{s.User.FirstName} {s.User.LastName}",
                        s.User.DateOfBirth.Value.ToString("dd/MM/yyyy"),
                        s.User.Email,
                        s.User.PhoneNumber
                    );
                }
            }
            UpdateSelectionCount();
        }

        #endregion

        #region handle events
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                BindGrid(_allStudents);
            }
            else
            {
                // Filter local list
                var filtered = _allStudents.Where(s =>
                    (s.User.FirstName + " " + s.User.LastName).ToLower().Contains(keyword) ||
                    s.User.Email.ToLower().Contains(keyword) ||
                    s.User.PhoneNumber.Contains(keyword) ||
                    s.User.Email.Contains(keyword)
                ).ToList();
                BindGrid(filtered);
            }
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colSelect.Index)
            {
                dgvAvailableStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                UpdateSelectionCount();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();
            foreach (DataGridViewRow row in dgvAvailableStudents.Rows)
            {
                if (Convert.ToBoolean(row.Cells[colSelect.Index].Value) == true)
                {
                    if (row.Cells[colId.Index].Value != null)
                    {
                        selectedIds.Add((int)row.Cells[colId.Index].Value);
                    }
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn ít nhất 1 học viên.");
                return;
            }

            try
            {

                var result = await _serviceHub.ClassService.AddStudentsToClassAsync(_classId, selectedIds);

                if (result.Success)
                {
                    MessageHelper.ShowInfo($"Đã thêm thành công {selectedIds.Count} học viên vào lớp!");
                    await LoadDataAsync();
                    OnStudentsAdded?.Invoke(this, EventArgs.Empty); 
                }
                else
                {
                    MessageHelper.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Chức năng thêm học viên chưa được cài đặt trong Service: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCloseRequired?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region helper method

        private void UpdateSelectionCount()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvAvailableStudents.Rows)
            {
                if (Convert.ToBoolean(row.Cells[colSelect.Index].Value) == true)
                {
                    count++;
                }
            }
            lblSelectedCount.Text = $"Đã chọn: {count}";
        }

        #endregion
    }
}
