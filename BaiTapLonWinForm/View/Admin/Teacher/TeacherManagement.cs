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

namespace BaiTapLonWinForm.View.Admin.Teacher
{
    public partial class TeacherManagement : UserControl
    {
        private readonly ServiceHub serviceHub;
        public TeacherManagement(ServiceHub serviceHub)
        {
            this.serviceHub = serviceHub;
            InitializeComponent();
        }

        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(new AddTeacher(serviceHub));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
