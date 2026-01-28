using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass.MyNews
{
    public partial class AddNew : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private int _classId;
        public event Func<Task> CloseRequested;
        private bool _editorReady = false;
        private Newsfeed _editingNewsfeed = null;
        private Newsfeed _pendingNewsfeed;

        private User _teacherUser;
        public AddNew(ServiceHub serviceHub, int classId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            this.Load += AddNew_Load;
            _classId = classId;
            var teacher = _serviceHub.TeacherService.getAllTeacherByClassId(_classId);
            //Tìm user giáo viên từ ServiceHub
            _teacherUser = _serviceHub.UserService.GetUserByTeacherId(teacher.TeacherId);
        }
        private async void AddNew_Load(object sender, EventArgs e)
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
        public void ResetForm()
        {
            _editingNewsfeed = null;

            btnPostNew.Visible = true;
            btnUpdateNew.Visible = false;

            currentWebView.ExecuteScriptAsync("setEditorHtml('');");
        }
        private async Task<string> GetEditorContentAsync()
        {
            string result = await currentWebView.ExecuteScriptAsync("getEditorHtml();");
            return System.Text.Json.JsonSerializer.Deserialize<string>(result);
        }
        public async void LoadFrom(Newsfeed data)
        {
            _editingNewsfeed = data;

            if (!_editorReady)
            {
                _pendingNewsfeed = data;
                return;
            }

            await SetEditorContentAsync(data.ContentHtml);
            SwitchToEditMode();
        }
        private async Task SetEditorContentAsync(string html)
        {
            string escapedHtml = System.Text.Json.JsonSerializer.Serialize(html);
            await currentWebView.ExecuteScriptAsync($"setEditorHtml({escapedHtml});");
        }

        private void SwitchToEditMode()
        {
            btnPostNew.Visible = false;
            btnUpdateNew.Visible = true;
        }

        private async void btnCloseNew_Click(object sender, EventArgs e)
        {
            if (CloseRequested != null)
                await CloseRequested();
        }

        private async void btnPostNew_Click(object sender, EventArgs e)
        {
            string html = await GetEditorContentAsync();
            if (string.IsNullOrWhiteSpace(html))
            {
                MessageBox.Show("Nội dung không được trống");
                return;
            }
            //Tổng hợp dữ liệu từ WebView2 và các input khác vào 1 biến Newsfeed
            var news = new Newsfeed
            {
                UserId = (int)_teacherUser.UserId,
                Author = _teacherUser.LastName + " " + _teacherUser.FirstName,
                Email = _teacherUser.Email,
                ClassId = _classId,
                UpdateAt = DateTime.Now,
                ContentHtml = html,
                PostingAt = DateTime.Now,
                Type = "newsfeed",
                IsPublished = true
            };
            //Gửi dữ liệu Newsfeed lên server thông qua NewsfeedService(check điều kiện ở service)
            bool result = await _serviceHub.NewsfeedService.CreateNewsfeedAsync(news);
            if (!result)
            {
                MessageHelper.ShowError("Không thể tạo bài đăng mới.");
            }
            MessageHelper.ShowSuccess("Tạo bài đăng mới thành công.");
            //Load lại giao diện các list newItem trong NewDetail thông qua sự kiện CloseRequested
            CloseRequested?.Invoke();
        }
        private async void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (_editingNewsfeed == null)
                return;

            string html = await GetEditorContentAsync();
            if (string.IsNullOrWhiteSpace(html))
            {
                MessageBox.Show("Nội dung không được trống");
                return;
            }

            _editingNewsfeed.ContentHtml = html;
            _editingNewsfeed.UpdateAt = DateTime.Now;

            bool result = await _serviceHub.NewsfeedService.UpdateNewsfeedAsync(_editingNewsfeed);
            if (result == false) MessageHelper.ShowError("Không thể cập nhật bài đăng.");
            MessageHelper.ShowSuccess("Cập nhật thành công bài đăng.");
            CloseRequested?.Invoke();
        }

    }
}
