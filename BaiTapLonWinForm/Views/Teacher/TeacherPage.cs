using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Teacher.Controls;
using BaiTapLonWinForm.Views.Teacher.MyCalenda;
using BaiTapLonWinForm.Views.Teacher.MyClass;
using BaiTapLonWinForm.Views.Teacher.Profile;
using Guna.UI2.WinForms;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher
{
    public partial class TeacherPage : Form
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        private bool isDarkMode = false;
        public TeacherPage(ServiceHub serviceHub, int teacherId = 1)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;
            LoadClassList();
            LoadLabelName();
        }
        private void LoadLabelName()
        {
            var teacher = _serviceHub.UserService.GetUserByTeacherId(_teacherId);
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

            var schedule = new Calenda(_serviceHub, _teacherId)
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
            var result = MessageBox.Show("Việc truy cập và chia sẻ vị trí hiện tại của bạn sẽ cho phép chúng tôi theo dõi lộ trình. Bạn có chắc chắn mở ?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result != DialogResult.OK)
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
        private void ApplyDarkMode()
        {
            //parent.BackColor = Color.FromArgb(30, 30, 30);
            //parent.ForeColor = Color.White;

            //foreach (Control ctrl in parent.Controls)
            //{
            //    ApplyDarkMode(ctrl);
            //}
            //SideBar
            pnSideBar.FillColor = Color.FromArgb(0, 27, 51);
            pnSideBar.FillColor2 = Color.FromArgb(0, 0, 0);
            pnSideBar.FillColor3 = Color.FromArgb(0, 27, 51);
            pnSideBar.FillColor4 = Color.FromArgb(4, 59, 59);
            //Menu User Name
            lblMenuUserName.ForeColor = Color.White;
            //Header
            pnHeaderTeacher.FillColor = Color.FromArgb(4, 59, 59);
            pnHeaderTeacher.FillColor2 = Color.Black;
            pnHeaderTeacher.FillColor3 = Color.FromArgb(0, 27, 51);
            pnHeaderTeacher.FillColor4 = Color.FromArgb(0, 27, 51);
            //Các label header
            foreach (Control label in pnHeaderTeacher.Controls)
            {
                if (label is Guna.UI2.WinForms.Guna2HtmlLabel btn)
                {
                    label.ForeColor = Color.White;
                }
            }
            //Border Main
            pnBorderMain.FillColor = Color.FromArgb(72, 181, 183);
            pnBorderMain.FillColor2 = Color.FromArgb(61, 104, 201);
            pnBorderMain.FillColor3 = Color.FromArgb(72, 181, 183);
            pnBorderMain.FillColor4 = Color.FromArgb(61, 104, 201);
            //Các button menu
            foreach (Control ctrl in fpnBtnMenu.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2GradientButton btn)
                {
                    btn.CheckedState.FillColor = Color.FromArgb(61, 104, 201);
                    btn.CheckedState.FillColor2 = Color.FromArgb(72, 181, 183);
                    btn.ForeColor = Color.White;
                }
            }
        }
        private void ApplyLightMode()
        {
            //parent.BackColor = Color.White;
            //parent.ForeColor = Color.Black;

            //foreach (Control ctrl in parent.Controls)
            //{
            //    ApplyLightMode(ctrl);
            //}
            //Menu User Name
            lblMenuUserName.ForeColor = Color.Black;
            //Header
            pnHeaderTeacher.FillColor = Color.White;
            pnHeaderTeacher.FillColor2 = Color.White;
            pnHeaderTeacher.FillColor3 = Color.White;
            pnHeaderTeacher.FillColor4 = Color.White;
            //SideBar
            pnSideBar.FillColor = Color.FromArgb(72, 181, 183);
            pnSideBar.FillColor2 = Color.White;
            pnSideBar.FillColor3 = Color.MediumSpringGreen;
            pnSideBar.FillColor4 = Color.FromArgb(61, 104, 201);
            //Các label header
            foreach (Control label in pnHeaderTeacher.Controls)
            {
                if (label is Guna.UI2.WinForms.Guna2HtmlLabel btn)
                {
                    label.ForeColor = Color.Black;
                }
            }
            //Border Main
            pnBorderMain.FillColor = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor2 = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor3 = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor4 = Color.FromArgb(213, 245, 232);
            //Các button menu
            foreach (Control ctrl in fpnBtnMenu.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2GradientButton btn)
                {
                    btn.CheckedState.FillColor = Color.White;
                    btn.CheckedState.FillColor2 = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }
        }
        private void ptbxToggleMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;

            if (isDarkMode)
            {

                ApplyDarkMode();
            }
            else
            {
                ApplyLightMode();
            }
        }
    }
}
