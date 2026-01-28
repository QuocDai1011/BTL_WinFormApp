using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Admin.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Schedule
{
    public partial class ScheduleItem : UserControl
    {
        private readonly ServiceHub _serviceHub;

        public ScheduleItem(ServiceHub service)
        {
            InitializeComponent();
            SetupEvents();
            _serviceHub = service;
        }

        public void SetData(int classId, string className, string teacher, string course, string time, Color stripColor)
        {
            pnlMain.Tag = classId;
            lblClassName.Text = className;
            lblTeacher.Text = "👤 " + teacher;
            lblCourse.Text = "📚 " + course;
            lblTime.Text = "⏰ " + time;
            pnlStrip.FillColor = stripColor;
        }

        private void SetupEvents()
        {

            this.MouseEnter += (s, e) =>
            {
                pnlMain.ShadowDecoration.Depth = 15;
                pnlMain.BorderThickness = 2;
            };
            this.MouseLeave += (s, e) =>
            {
                pnlMain.ShadowDecoration.Depth = 10;
                pnlMain.BorderThickness = 1;
            };
            this.Click += ScheduleItem_Click;
            lblClassName.Click += ScheduleItem_Click;
            lblTeacher.Click += ScheduleItem_Click;
            lblCourse.Click += ScheduleItem_Click;
            lblTime.Click += ScheduleItem_Click;
            pnlStrip.Click += ScheduleItem_Click;
        }

        private async void ScheduleItem_Click(object? sender, EventArgs e)
        {
            int classId = (int)pnlMain.Tag;
            if(classId <= 0) return;
            var classItem = await _serviceHub.ClassService.GetClassByIdAsync(classId);

            if (!classItem.Success)
            {
                MessageHelper.ShowError("Lỗi", classItem.Message);
            }
            var handler = this.FindForm() as INavigationHandler;

            if (handler != null)
            {
                handler.NavigateToClassDetail(classId);
            }

        }
    }
 }
