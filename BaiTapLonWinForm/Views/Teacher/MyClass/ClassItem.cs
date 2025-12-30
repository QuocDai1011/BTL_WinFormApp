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
        
        // Cache current data để tránh set lại không cần thiết
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
            
            // Enable double buffering để giảm flicker
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                         ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();
            
            // Disable redraw khi resize
            this.SetStyle(ControlStyles.ResizeRedraw, false);
        }
        
        //Nhận dữ liệu lớp học từ prop - WITH DIRTY CHECKING
        public void SetData(Class classData, Course courseData, User currentUser, List<string> daysOfWeek)
        {
            // Tạo các giá trị mới
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
            
            // CHỈ UPDATE NẾU CÓ THAY ĐỔI
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

            // Chỉ refresh layout nếu có thay đổi
            if (hasChanges)
            {
                this.Invalidate(); // nhẹ hơn Refresh
            }

        }

        private void btnClassDetail_Click(object sender, EventArgs e)
        {
            //Chuyển đến trang chi tiết lớp học
            OnOpenDetail?.Invoke(_classId);
        }
    }
}
