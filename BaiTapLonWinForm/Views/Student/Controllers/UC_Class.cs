using BaiTapLonWinForm.DTOs;
using System;
namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_Class : UserControl
    {
        public event Action<int> OnDataSend;
        private int _id;

        public UC_Class()
        {
            InitializeComponent();
        }

        public void LoadClass(ClassDto data)
        {
            _id = data.ClassId;
            lbCourseName.Text = data.CourseName;
            lbClassName.Text = data.ClassName;
            lbNote.Text = data.Node;

            if (data.Shift == 1)
                lbShift.Text = "8:00 - 9:30";
            else if (data.Shift == 2)
                lbShift.Text = "9:30 - 11:00";
            else if (data.Shift == 3)
                lbShift.Text = "14:00 - 15:30";
            else if (data.Shift == 4)
                lbShift.Text = "15:30 - 17:00";
            else if (data.Shift == 5)
                lbShift.Text = "18:00 - 19:30";
            else if (data.Shift == 6)
                lbShift.Text = "19:30 - 21:00";
            else
                lbShift.Text = "Lỗi";

            //lbSchoolDay.Text = data.SchoolDay;
            lbNameTeacher.Text = data.TeacherName;
        }

        private void btnClassDetail_Click(object sender, EventArgs e)
        {
            OnDataSend?.Invoke(_id);
        }
    }
}
