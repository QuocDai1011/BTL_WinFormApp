using BaiTapLonWinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.ListToDo
{
    public partial class ListToDoStudentStatus : UserControl
    {
        public ListToDoStudentStatus(Submission data)
        {
            InitializeComponent();
            LoadData(data);
        }
        private void LoadData(Submission data)
        {
            lblName.Text = data.StudentName;
            lblStatus.Text = data.Status;
        }
    }
}
