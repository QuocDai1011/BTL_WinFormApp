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

namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    public partial class DashBoard : UserControl
    {
        private readonly ServiceHub _serviceHub;
        public DashBoard(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
        }
    }
}
