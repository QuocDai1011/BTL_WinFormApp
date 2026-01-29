using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Views.Teacher.MyClass;
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
    public partial class ClassItem : UserControl
    {
        private readonly long _classId;
        public event Action<long>? OnOpenDetail;

        private string _cachedCourseName;
        private string _cachedClassName;
        private string _cachedNote;
        private string _cachedShiftText;
        private string _cachedSchoolDay;
        private string _cachedTeacherName;

        public ClassItem(long classId)
        {
            InitializeComponent();
            _classId = classId;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.SetStyle(ControlStyles.ResizeRedraw, false);
        }
        public void SetData(Class classData, Course courseData, User currentUser, List<string> daysOfWeek)
        {
            string newCourseName = courseData.CourseCode;
            string newClassName = classData.ClassName;
            string newNote = classData.Note;
            string newSchoolDay = string.Join(" - ", daysOfWeek);
            string newTeacherName = currentUser.FirstName + " " + currentUser.LastName;

            string newShiftText;
            switch (classData.Shift)
            {
                case 1: newShiftText = "8:00 - 9:30"; break;
                case 2: newShiftText = "9:30 - 11:00"; break;
                case 3: newShiftText = "14:00 - 15:30"; break;
                case 4: newShiftText = "15:30 - 17:00"; break;
                case 5: newShiftText = "17:30 - 19:00"; break;
                case 6: newShiftText = "19:30 - 21:00"; break;
                default: newShiftText = "Không tìm thấy ca học"; break;
            }
            bool hasChanges = false;

            if (_cachedCourseName != newCourseName)
            {
                _cachedCourseName = newCourseName;
                lblCourseName.Text = newCourseName;
                hasChanges = true;
            }

            if (_cachedClassName != newClassName)
            {
                _cachedClassName = newClassName;
                lblClassName.Text = newClassName;
                hasChanges = true;
            }

            if (_cachedNote != newNote)
            {
                _cachedNote = newNote;
                lblNote.Text = newNote;
                hasChanges = true;
            }

            if (_cachedShiftText != newShiftText)
            {
                _cachedShiftText = newShiftText;
                lblShift.Text = newShiftText;
                hasChanges = true;
            }

            if (_cachedSchoolDay != newSchoolDay)
            {
                _cachedSchoolDay = newSchoolDay;
                lblSchoolDay.Text = newSchoolDay;
                hasChanges = true;
            }

            if (_cachedTeacherName != newTeacherName)
            {
                _cachedTeacherName = newTeacherName;
                lblTeacherName.Text = newTeacherName;
                hasChanges = true;
            }
            if (hasChanges)
            {
                this.Invalidate();
            }

        }
        public void ApplyTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                lblClassName.ForeColor = Color.Black;
                lblNote.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                lblTeacherName.ForeColor = Color.Black;
                lblSchoolDay.ForeColor = Color.FromArgb(72, 181, 183);
                lblShift.ForeColor = Color.FromArgb(72, 181, 183);

                btnClassDetail.ForeColor = Color.FromArgb(72, 181, 183);
                btnClassDetail.BorderColor = Color.FromArgb(72, 181, 183);
                btnClassDetail.HoverState.FillColor = Color.Teal;
                btnClassDetail.HoverState.FillColor2 = Color.Teal;
            }
            else
            {
                lblClassName.ForeColor = Color.Black;
                lblNote.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                lblTeacherName.ForeColor = Color.Black;
                lblSchoolDay.ForeColor = Color.SeaGreen;
                lblShift.ForeColor = Color.SeaGreen;

                btnClassDetail.ForeColor = Color.Teal;
                btnClassDetail.BorderColor = Color.Teal;
                btnClassDetail.HoverState.FillColor = Color.Teal;
                btnClassDetail.HoverState.FillColor2 = Color.Teal;
            }
        }

        private void btnClassDetail_Click(object sender, EventArgs e)
        {
            OnOpenDetail?.Invoke(_classId);
        }

        private void ClassItem_Load(object sender, EventArgs e)
        {

        }
    }
}
