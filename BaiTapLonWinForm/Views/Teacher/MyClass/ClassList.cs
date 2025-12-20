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

namespace BaiTapLonWinForm.Views.Teacher.Controls
{
    public partial class ClassList : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _teacherId;
        public event Action<long>? OnOpenClassDetail;

        public ClassList(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _serviceHub = serviceHub;
        }
        private const int MaxPerRow = 4; 
        private int cardCount = 0;

        public void LoadClasses()
        {
            List<Class> classes = _serviceHub.ClassService.GetAllClass(_teacherId);
            classes = UpdateClassesStatusList(classes);
            LoadData(classes);
        }

        private void AttachHoverEventsToChildren(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.MouseEnter += ClassItem_MouseEnter;
                c.MouseLeave += ClassItem_MouseLeave;

                if (c.Controls.Count > 0)
                    AttachHoverEventsToChildren(c);
            }
        }
        private List<Class> UpdateClassesStatusList(List<Class> updatedClasses)
        {
            return _serviceHub.ClassService.UpdateClassesStatusList(updatedClasses);
        }
        private ClassItem CreateClassItem(Class classData, Course courseData, User currentUser, List<string> daysOfWeek)
        {
            var uc = new ClassItem(classData.ClassId);
            uc.OnOpenDetail += Uc_OnOpenDetail;
            uc.SetData(classData, courseData, currentUser, daysOfWeek);
            uc.Dock = DockStyle.Fill;
            uc.MouseEnter += ClassItem_MouseEnter;
            uc.MouseLeave += ClassItem_MouseLeave;
            AttachHoverEventsToChildren(uc);
            return uc;
        }
        private void Uc_OnOpenDetail(long classId)
        {
            OnOpenClassDetail?.Invoke(classId);
        }
        private Guna.UI2.WinForms.Guna2CustomGradientPanel CreateCard(ClassItem uc)
        {
            var shadow = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            shadow.Width = 338;
            shadow.Height = 267;
            shadow.BorderThickness = 2;
            shadow.BorderRadius = 8;
            shadow.BorderColor = Color.FromArgb(224, 224, 224);
            shadow.FillColor = Color.White;
            shadow.Padding = new Padding(1);
            shadow.Margin = new Padding(0, 0, 20, 2);
            shadow.ShadowDecoration.Enabled = false;
            shadow.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Custom;
            shadow.ShadowDecoration.BorderRadius = 12;
            shadow.ShadowDecoration.Color = Color.Black;
            shadow.ShadowDecoration.Depth = 12;
            shadow.ShadowDecoration.CustomizableEdges =
                new Guna.UI2.WinForms.Suite.CustomizableEdges
                {
                    TopLeft = true,
                    TopRight = true,
                    BottomLeft = true,
                    BottomRight = true
                };

            shadow.ShadowDecoration.Shadow = new Padding(4, 4, 8, 8);
            shadow.Controls.Add(uc);
            return shadow;
        }
        private void ApplyShadow(Guna.UI2.WinForms.Guna2CustomGradientPanel shadow)
        {
            shadow.ShadowDecoration.Enabled = true;
        }

        private void ClassItem_MouseEnter(object sender, EventArgs e)
        {
            var parentPanel = (sender as Control).Parent as Guna.UI2.WinForms.Guna2CustomGradientPanel;

            if (parentPanel != null)
                ApplyShadow(parentPanel);
        }
        private void ClassItem_MouseLeave(object sender, EventArgs e)
        {
            var parentPanel = (sender as Control).Parent as Guna.UI2.WinForms.Guna2CustomGradientPanel;

            if (parentPanel != null)
                parentPanel.ShadowDecoration.Enabled = false;
        }
        private void AddCardToFlow(Guna.UI2.WinForms.Guna2CustomGradientPanel card)
        {
            flowMain.Controls.Add(card);
            cardCount++;
            if (cardCount == MaxPerRow)
            {
                flowMain.SetFlowBreak(card, true);
                cardCount = 0;
            }
        }
        private void LoadData(List<Class> list)
        {
            flowMain.Controls.Clear();
            cardCount = 0;
            // Tìm giáo viên hiện tại
            User currentUser = _serviceHub.UserService.GetUserByUserId(_teacherId);

            foreach (var item in list)
            {
                //Khi nào làm xong thì mở comment dưới ra mới đúng logic
                //if (item.Status == 1 || item.Status == -1)
                //{
                //    continue;
                //}
                Course course = _serviceHub.CourseService.GetCourseByClassId(item.ClassId);
                
                if (course == null)
                {
                    continue;
                }
                List<string> daysOfWeek = _serviceHub.SchoolDayService.GetListSchoolDaysByClassId(item.ClassId);
                ClassItem uc = CreateClassItem(item, course, currentUser, daysOfWeek);
                var card = CreateCard(uc);
                AddCardToFlow(card);
            }
        }
    }
}
