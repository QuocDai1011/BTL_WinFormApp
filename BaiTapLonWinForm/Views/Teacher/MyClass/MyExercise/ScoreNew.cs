using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
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
    public partial class ScoreNew : UserControl
    {
        private string _assignmentId;
        private readonly ServiceHub _serviceHub;
        public ScoreNew(ServiceHub serviceHub, string assignmentId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _assignmentId = assignmentId;
            LoadData();
            
        }
        private async void  LoadData()
        {
            //Lấy dữ liệu Assignment theo _assignmentId và hiển thị
            var assignment = await _serviceHub.AssignmentService.GetAssignmentById(_assignmentId);
            var newsfeed = await _serviceHub.NewsfeedService.GetNewsfeedByIdAsync(assignment.NewsfeedId);
            if (assignment != null)
            {
                lblTitle.Text = assignment.Title;
                lblCreatedAt.Text = newsfeed.PostingAt.ToString("dd/MM/yyyy HH:mm");
                lblDueTime.Text = assignment.DueTime.ToString("dd/MM/yyyy HH:mm");
                lblMaxScore.Text = assignment.MaxScore.ToString();
                await LoadHtmlToWebView(newsfeed.ContentHtml);
            }
        }
        private async Task LoadHtmlToWebView(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return;

            await wvContent.EnsureCoreWebView2Async();

            string fullHtml = $@"
                <html>
                <head>
                    <meta charset='utf-8'>
                    <style>
                        body {{
                            font-family: 'Segoe UI', sans-serif;
                            font-size: 14px;
                            padding: 12px;
                        }}
                    </style>
                </head>
                <body>
                    {html}
                </body>
                </html>";

            wvContent.CoreWebView2.NavigateToString(fullHtml);
        }

    }
}
