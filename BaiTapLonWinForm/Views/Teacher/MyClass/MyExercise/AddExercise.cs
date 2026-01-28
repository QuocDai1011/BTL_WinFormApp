using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Teacher.MyClass.MyNews;
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
    public partial class AddExercise : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private int _classId;
        private readonly int _teacherId;
        public Action OnBack;
        private bool _editorReady = false;
        private Newsfeed _editingNewsfeed = null;
        private Newsfeed _pendingNewsfeed;
        private Assignment _editingAssignment;
        public AddExercise(ServiceHub serviceHub, int classId, int teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _classId = classId;
            LoadData();
            _teacherId = teacherId;
        }
        private void LoadData()
        {
            var currentClass = _serviceHub.ClassService.GetClassById(_classId);
            lblClassName.Text = currentClass.ClassName;
            LoadWebView();
            //var addNew = new AddNew(_serviceHub, _classId)
            //{
            //    Dock = DockStyle.Fill
            //};
            //pnAddContent.Controls.Add(addNew);
        }
        public async Task LoadForEditAsync(Newsfeed newsfeed)
        {
            _editingNewsfeed = newsfeed;

            _pendingNewsfeed = newsfeed;

            _editingAssignment = await _serviceHub.AssignmentService
                .GetAllAssignmentsByNewsfeedId(newsfeed.Id);

            if (_editorReady)
            {
                await SetEditorContentAsync(newsfeed.ContentHtml);
                SwitchToEditMode();
            }
        }

        private async void LoadWebView()
        {
            currentWebView.Dock = DockStyle.Fill;
            currentWebView.BringToFront();

            await currentWebView.EnsureCoreWebView2Async();

            string htmlPath = Path.Combine(
                Application.StartupPath,
                "Views",
                "Teacher",
                "MyClass",
                "MyNews",
                "editor.html"
            );

            if (!File.Exists(htmlPath))
            {
                MessageBox.Show("Không tìm thấy editor.html:\n" + htmlPath);
                return;
            }

            currentWebView.CoreWebView2.WebMessageReceived += async (s, ev) =>
            {
                if (ev.TryGetWebMessageAsString() == "EDITOR_READY")
                {
                    _editorReady = true;

                    if (_pendingNewsfeed != null)
                    {
                        await SetEditorContentAsync(_pendingNewsfeed.ContentHtml);
                        SwitchToEditMode();
                        _pendingNewsfeed = null;
                    }
                }
            };

            currentWebView.Source = new Uri(htmlPath);
        }
        private void SwitchToEditMode()
        {
            btnPostExercise.Visible = false;
            btnUpdateExercise.Visible = true;
        }
        private async Task SetEditorContentAsync(string html)
        {
            string escapedHtml = System.Text.Json.JsonSerializer.Serialize(html);
            await currentWebView.ExecuteScriptAsync($"setEditorHtml({escapedHtml});");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke();
        }
        private async Task<string> GetEditorContentAsync()
        {
            string result = await currentWebView.ExecuteScriptAsync("getEditorHtml();");
            return System.Text.Json.JsonSerializer.Deserialize<string>(result);
        }
        private void txbScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số (0–9) và phím điều khiển (Backspace, Delete…)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private async void btnPostExercise_Click(object sender, EventArgs e)
        {
            string html = await GetEditorContentAsync();
            if (string.IsNullOrWhiteSpace(html))
            {
                MessageBox.Show("Nội dung không được trống");
                return;
            }
            //Lấy userId thông qua teacherId
            var _teacherUser = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
            var currentUser = _serviceHub.UserService.GetUserByUserId(_teacherUser.Data.UserId);
            //Tổng hợp dữ liệu từ WebView2 và các input khác vào 1 biến Newsfeed
            var news = new Newsfeed
            {
                UserId = (int)_teacherUser.Data.UserId,
                Author = currentUser.LastName + " " + currentUser.FirstName,
                Email = currentUser.Email,
                ClassId = _classId,
                UpdateAt = DateTime.Now,
                ContentHtml = html,
                PostingAt = DateTime.Now,
                Type = "assignment",
                IsPublished = true
            };
            //Gửi dữ liệu Newsfeed lên server thông qua NewsfeedService(check điều kiện ở service)
            bool result = await _serviceHub.NewsfeedService.CreateNewsfeedAsync(news);
            if (!result)
            {
                MessageHelper.ShowError("Không thể tạo bài tập mới.");
                return;
            }
            //Lấy Id của newsfeed vừa tạo
            var createdNewsfeed = await _serviceHub.NewsfeedService.GetLatestNewsfeedByClassIdAsync(_classId);
            //Tạo assignment liên kết với newsfeed vừa tạo
            var date = dtpkDate.Value.Date;          // chỉ lấy ngày (00:00:00)
            var time = dtpkTime.Value.TimeOfDay;     // chỉ lấy giờ
            var assignment = new Assignment
            {
                Title = txbTitle.Text,
                DueTime = date + time,
                StartTime = DateTime.Now, //Hạn nộp cách 7 ngày
                NewsfeedId = createdNewsfeed.Id,
                ClassId = _classId,
                MaxScore = int.Parse(txbScore.Text),
                AllowLateSubmission = ckbSubmissionAgain.CheckState == CheckState.Checked ? true : false,
                Status = "Đã đăng",
                IsDeleted = false,
                AllowMultipleLinks = true
            };
            //Lưu assignment thông qua AssignmentService
            await _serviceHub.AssignmentService.CreateAssignmentAsync(assignment);
            //Tạo các submisstion cho tất cả học sinh trong lớp
            var students = _serviceHub.StudentService.GetAllStudentByClassId(_classId);
            foreach (var student in students)
            {
                //Lấy user của học sinh thông qua studentId
                var us = _serviceHub.UserService.GetUserByUserId(student.UserId);
                var submission = new Submission
                {
                    AssignmentId = assignment.Id,
                    StudentId = student.StudentId,
                    ClassId = _classId,
                    TeacherId = _teacherId,
                    StudentName = us.LastName + " " + us.FirstName,
                    Links = null,
                    Attempt = 0,
                    Status = "Chưa nộp",
                    SubmittedAt = null,
                    UpdatedAt = null,
                    IsCompleted = false,
                    IsLate = false,
                    Score = null,
                    Feedback = null,
                    CompletedAt = null
                };
                bool isCreate = await _serviceHub.SubmissionService.CreateSubmissionAsync(submission);
                if (!isCreate)
                {
                    MessageHelper.ShowError($"Không thể tạo submission cho học sinh {us.LastName} {us.FirstName}.");
                    return;
                }
            }
            //Load lại giao diện các list newItem trong NewDetail thông qua sự kiện CloseRequested
            this.OnBack?.Invoke();
        }
        public async void LoadAssignmentForEdit(Assignment assignment)
        {
            // lưu assignment
            _editingAssignment = assignment;

            txbTitle.Text = assignment.Title;
            dtpkDate.Value = assignment.DueTime.Date;
            dtpkTime.Value = DateTime.Today + assignment.DueTime.TimeOfDay;
            txbScore.Text = assignment.MaxScore.ToString();
            ckbSubmissionAgain.Checked = assignment.AllowLateSubmission;

            // load Newsfeed
            var news = await _serviceHub.NewsfeedService
                .GetNewsfeedByIdAsync(assignment.NewsfeedId);

            _editingNewsfeed = news;

            if (_editorReady)
                await SetEditorContentAsync(news.ContentHtml);
            else
                _pendingNewsfeed = news;

            SwitchToEditMode();
        }

        private async void btnUpdateExercise_Click(object sender, EventArgs e)
        {
            //if (_editingNewsfeed == null)
            //    return;

            //string html = await GetEditorContentAsync();
            //if (string.IsNullOrWhiteSpace(html))
            //{
            //    MessageBox.Show("Nội dung không được trống");
            //    return;
            //}

            //_editingNewsfeed.ContentHtml = html;
            //_editingNewsfeed.UpdateAt = DateTime.Now;

            //await _serviceHub.NewsfeedService.UpdateNewsfeedAsync(_editingNewsfeed);
            //await _serviceHub.AssignmentService.UpdateAssignmentAsync(_editingNewsfeed);
            if (_editingAssignment == null || _editingNewsfeed == null)
                return;

            string html = await GetEditorContentAsync();

            // update newsfeed
            _editingNewsfeed.ContentHtml = html;
            _editingNewsfeed.UpdateAt = DateTime.Now;
            bool result = await _serviceHub.NewsfeedService.UpdateNewsfeedAsync(_editingNewsfeed);
            if (result)
            {
                _editingAssignment.Title = txbTitle.Text;
                _editingAssignment.DueTime =
                    dtpkDate.Value.Date + dtpkTime.Value.TimeOfDay;
                _editingAssignment.MaxScore = int.Parse(txbScore.Text);
                _editingAssignment.AllowLateSubmission = ckbSubmissionAgain.Checked;

                await _serviceHub.AssignmentService
                    .UpdateAssignmentAsync(_editingAssignment);

                OnBack?.Invoke();
            }
            // update assignment
        }
    }
}
