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
        public ClassItem(long classId)
        {
            InitializeComponent();
            _classId = classId;
        }
        //Nhận dữ liệu lớp học từ prop
        public void SetData(Class classData, Course courseData, User currentUser, List<string> daysOfWeek)
        {
            lblCourseName.Text = courseData.CourseCode;
            lblClassName.Text = classData.ClassName;
            lblNote.Text = classData.Note;
            switch (classData.Shift)
            {
                case 1:
                    lblShift.Text = "8:00 - 9:30";
                    break;
                case 2:
                    lblShift.Text = "9:30 - 11:00";
                    break;
                case 3:
                    lblShift.Text = "14:00 - 15:30";
                    break;
                case 4:
                    lblShift.Text = "15:30 - 17:00";
                    break;
                case 5:
                    lblShift.Text = "17:30 - 19:00";
                    break;
                case 6:
                    lblShift.Text = "19:30 - 21:00";
                    break;
                default:
                    lblShift.Text = "Không tìm thấy ca học";
                    break;
            }
            lblSchoolDay.Text = string.Join(" - ", daysOfWeek);
            lblTeacherName.Text = currentUser.FirstName + " " + currentUser.LastName;
        }
        
        private void btnClassDetail_Click(object sender, EventArgs e)
        {
            //Chuyển đến trang chi tiết lớp học
            OnOpenDetail?.Invoke(_classId);

        }
    }
}
