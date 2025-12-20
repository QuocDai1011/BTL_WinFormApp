using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Teacher.Controls;
using BaiTapLonWinForm.Views.Teacher.MyCalenda;
using BaiTapLonWinForm.Views.Teacher.MyClass;
using BaiTapLonWinForm.Views.Teacher.Profile;
using Nest;
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

namespace BaiTapLonWinForm.Views.Teacher
{
    public partial class TeacherPage : Form
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        public TeacherPage(ServiceHub serviceHub, int teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;
            LoadClassList();
            LoadLabelName();
        }
        private void LoadLabelName()
        {
            //var teacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
            var teacher = _serviceHub.UserService.GetUserByUserId(_teacherId);
            lblMenuUserName.Text = teacher.FirstName + " " + teacher.LastName;
        }
        private void LoadClassList()
        {
            ClassList classList = new ClassList(_teacherId, _serviceHub);
            classList.Dock = DockStyle.Fill;
            classList.OnOpenClassDetail += OpenClassDetail;
            pnMain.Controls.Clear();
            pnMain.Controls.Add(classList);
            classList.LoadClasses();
        }
        private void OpenClassDetail(long classId)
        {
            pnMain.Controls.Clear();

            ClassDetail classDetail = new ClassDetail(classId, _serviceHub);
            classDetail.Dock = DockStyle.Fill;

            pnMain.Controls.Add(classDetail);
        }
        private void MenuClass_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();

            var classList = new ClassList(_teacherId, _serviceHub)
            {
                Dock = DockStyle.Fill
            };
            classList.OnOpenClassDetail += OpenClassDetail;
            pnMain.Controls.Add(classList);
            classList.LoadClasses();
        }

        private void MenuCalenda_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();

            var schedule = new Calenda(_serviceHub,_teacherId)
            {
                Dock = DockStyle.Fill
            };

            pnMain.Controls.Add(schedule);
        }

        private void pnProfileTeacher_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.AutoScroll = true;
            var profile = new MyProfile(_teacherId, _serviceHub);
            pnMain.Controls.Add(profile);
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Việc truy cập và chia sẻ vị trí hiện tại của bạn sẽ cho phép chúng tôi theo dõi lộ trình. Bạn có chắc chắn mở ?","Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result != DialogResult.OK)
            {
                return;
            }
            string destination = "96/9 Chung cư Kim Sơn 1, Đặng Thùy Trâm, P13, Bình Thạnh, HCM, Việt Nam";

            if (string.IsNullOrWhiteSpace(destination))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ hoặc tọa độ đích!");
                return;
            }

            string destEncoded = Uri.EscapeDataString(destination);
            string url = $"https://www.google.com/maps/dir/?api=1&destination={destEncoded}&travelmode=driving";

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở trình duyệt: " + ex.Message);
            }
        }
    }
}
