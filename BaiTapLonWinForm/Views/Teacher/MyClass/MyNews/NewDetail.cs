using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Views.Teacher.MyClass.MyNews;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    public partial class NewDetail : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private Panel pnOverlayNewItems;
        private AddNew addNew;
        private int _classId;
        public NewDetail(ServiceHub serviceHub, int classId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            this.AutoScroll = false;
            fpnNewContainer.AutoScroll = true;
            fpnNewContainer.WrapContents = false;
            fpnNewContainer.FlowDirection = FlowDirection.TopDown;
            _classId = classId;
        }
        private void NewDetail_Load(object sender, EventArgs e)
        {
            InitOverlay();
        }
        private void InitOverlay()
        {
            pnOverlayNewItems = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(120, 0, 0, 0), // mờ
                Visible = false
            };

            addNew = new AddNew(_serviceHub, _classId)
            {
                Dock = DockStyle.Fill
            };
            pnOverlayNewItems.Controls.Add(addNew);
            pnNewMain.Controls.Add(pnOverlayNewItems);
            pnOverlayNewItems.BringToFront();

            addNew.CloseRequested += HideOverlay;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            addNew.ResetForm();
            pnOverlayNewItems.Visible = true;
            pnOverlayNewItems.BringToFront();
        }
        public async Task LoadNewsFeedList(List<Newsfeed> newsFeedList)
        {// Xóa tất cả các control mẫu hoặc cũ trong fpnNewContainer
            fpnNewContainer.SuspendLayout();
            fpnNewContainer.Controls.Clear();

            if (newsFeedList == null || newsFeedList.Count == 0)
            {
                Label noNewsLabel = new Label();
                noNewsLabel.Text = "Hiện chưa có bài đăng nào.";
                noNewsLabel.Font = new Font("Arial", 14, FontStyle.Italic);
                noNewsLabel.ForeColor = Color.Gray;
                noNewsLabel.AutoSize = true;
                noNewsLabel.Dock = DockStyle.Top;
                noNewsLabel.TextAlign = ContentAlignment.MiddleCenter;
                fpnNewContainer.Controls.Add(noNewsLabel);
                fpnNewContainer.ResumeLayout();
                return;
            }
            foreach (var newsFeed in newsFeedList)
            {
                NewItem newItem = new NewItem(_serviceHub);
                newItem.AddInfoNewItem(newsFeed);
                await newItem.BindDataAsync(newsFeed);
                newItem.EditRequested += OnEditNewItem;
                fpnNewContainer.Controls.Add(newItem);
            }

            fpnNewContainer.ResumeLayout();
            fpnNewContainer.PerformLayout();

            // Force refresh
            fpnNewContainer.Refresh();
            this.Refresh();
        }
        private void OnEditNewItem(Newsfeed newsfeed)
        {
            // Load dữ liệu từ NewItem sang AddNew
            addNew.LoadFrom(newsfeed);
            pnOverlayNewItems.Visible = true;
            pnOverlayNewItems.BringToFront();
        }
        private async Task HideOverlay()
        {
            pnOverlayNewItems.Visible = false;

            var newsFeedList =
                await _serviceHub.NewsfeedService
                                 .GetNewsfeedsByClassIdAsync(_classId);

            await LoadNewsFeedList(newsFeedList);
        }
    }
}
