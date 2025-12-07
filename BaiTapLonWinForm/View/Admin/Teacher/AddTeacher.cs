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
    public partial class AddTeacher : UserControl
    {
        private readonly ServiceHub _serviceHub;
        public AddTeacher(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
        }
    }
}
