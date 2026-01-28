using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Interfaces;
using Guna.UI2.WinForms;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    public partial class NewItem : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private string _newsfeedId = null;
        public event Action<Newsfeed> EditRequested;
        public NewItem(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            this.AutoSize = false;
            this.Size = new Size(1065, 250);
            this.MinimumSize = new Size(this.Width, 150);
            wvContent.AutoSize = false;
        }
        public async Task BindDataAsync(Newsfeed news)
        {
            _newsfeedId = news.Id.ToString();
            if (news == null) return;

            await InitWebViewAsync();

            string html = $@"
            <html>
            <head>
                <meta charset='utf-8'/>
                <style>
                    html, body {{
                        overflow: hidden;
                    }}
                    body {{
                        font-family: Segoe UI;
                        font-size: 14px;
                        margin: 0 16px 16px 16px;
                        padding: 8px;
                    }}
                    a {{
                        color: #1a73e8;
                        text-decoration: underline;
                        cursor: pointer;
                    }}
                </style>
            </head>
            <body>
                {news.ContentHtml}
            </body>
            <script>
                function getContentHeight() {{
                    return document.body.scrollHeight;
                }}
            </script>
            </html>";

            wvContent.NavigationCompleted -= WvContent_NavigationCompleted;
            wvContent.NavigationCompleted += WvContent_NavigationCompleted;

            wvContent.NavigateToString(html);
        }
        private async void WvContent_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            var heightJson = await wvContent.ExecuteScriptAsync("getContentHeight();");

            int contentHeight = int.Parse(heightJson);

            wvContent.Height = contentHeight;

            this.Height =
                guna2CustomGradientPanel2.Height +
                contentHeight +
                guna2CustomGradientPanel4.Height +
                20;
        }

        private async Task InitWebViewAsync()
        {
            if (wvContent.CoreWebView2 != null)
                return;

            await wvContent.EnsureCoreWebView2Async();

            // Tắt tool
            wvContent.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            wvContent.CoreWebView2.Settings.AreDevToolsEnabled = false;

            // Bắt click link
            wvContent.CoreWebView2.NavigationStarting += WebView_NavigationStarting;
        }
        public void AddInfoNewItem(Newsfeed info)
        {
            if (info == null)
            {
                return;
            }

            lblTeacherName.Text = info.Author ?? "Unknown";
            lblPostingAt.Text = info.PostingAt.ToLocalTime().ToString("g");
            //lblNewsfeedContent.Text = info.Content ?? "";
            //if (info.LinkPathInCloud != null && info.LinkPathInCloud.Count != 0)
            //{
            //    foreach (var link in info.LinkPathInCloud)
            //    {
            //        LinkLabel linkLabel = new LinkLabel();
            //        linkLabel.Text = link;
            //        linkLabel.AutoSize = false;
            //        linkLabel.Margin = new Padding(20, 0, 0, 0);
            //        linkLabel.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            //        linkLabel.LinkClicked += (s, e) =>
            //        {
            //            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            //            {
            //                FileName = link,
            //                UseShellExecute = true
            //            });
            //        };
            //        flpnNewsfeedContent.Controls.Add(linkLabel);
            //    }
            //}
        }
        private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.Uri.StartsWith("http"))
            {
                e.Cancel = true;

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = e.Uri,
                    UseShellExecute = true
                });
            }
        }

        private async void mscItem1_Click(object sender, EventArgs e)
        {
            //Lấy thông tin bài đăng hiện tại từ view
            Newsfeed currentNewsfeed = await _serviceHub.NewsfeedService.GetNewsfeedByIdAsync(_newsfeedId);
            EditRequested?.Invoke(currentNewsfeed);
        }

        private async void mscItem2_Click(object sender, EventArgs e)
        {
            //Lấy id truyền vào xóa
            if (_newsfeedId != null)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài đăng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var deleteResult = await _serviceHub.NewsfeedService.DeleteNewsfeedByIdAsync(_newsfeedId);
                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa bài đăng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Parent?.Controls.Remove(this);
                    }
                    else
                    {
                        MessageBox.Show("Xóa bài đăng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
