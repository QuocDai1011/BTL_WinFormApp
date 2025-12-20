using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
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
    public partial class ClassDetail : UserControl
    {
        private readonly long _classId;
        private readonly ServiceHub _serviceHub;
        public ClassDetail(long classId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _classId = classId;
            _serviceHub = serviceHub;
            btnDefaultLoad();
            icMeet.IconClicked += IconCustom_Clicked;
        }
        //private void btnDefaultLoad()
        //{
        //    pnMainClass.AutoScroll = true;
        //    pnMainClass.Controls.Clear();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        var newItem = new NewItem();
        //        pnMainClass.Controls.Add(newItem);
        //    }
        //}
        private void btnDefaultLoad()
        {
            pnMainClass.Controls.Clear();

            var newDetail = new NewDetail
            {
                //Dock = DockStyle.Fill  // ← THÊM Dock = Fill
            };

            pnMainClass.Controls.Add(newDetail);
        }
        private void btnMainAction1_Click(object sender, EventArgs e)
        {
            btnDefaultLoad();
        }
        private void btnMainAction3_Click(object sender, EventArgs e)
        {
            pnMainClass.Controls.Clear();
            pnMainClass.AutoScroll = false;
            var classMember = new ClassMember(_classId, _serviceHub);
            pnMainClass.Controls.Add(classMember);
        }

        private void pnMeet_Click(object sender, EventArgs e)
        {
            //Lấy đường link từ db
            Class currentClass = _serviceHub.ClassService.GetClassById(_classId);
            if (currentClass.OnlineMeetingLink != null)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = currentClass.OnlineMeetingLink,
                    UseShellExecute = true
                });
                return;
            }
            else
            {
                MessageHelper.ShowInfo("Lớp học chưa có link họp trực tuyến!");
            }
        }
        private void IconCustom_Clicked(object sender, EventArgs e)
        {
            pnMeet_Click(sender, e);
        }
        
    }
}
