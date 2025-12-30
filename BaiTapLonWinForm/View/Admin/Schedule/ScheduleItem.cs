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
        public ScheduleItem()
        {
            InitializeComponent();
            SetupEvents();
        }

        public void SetData(string className, string teacher, string course, string time, Color stripColor)
        {
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
        }
    }
}
