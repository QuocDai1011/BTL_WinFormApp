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

namespace BaiTapLonWinForm.View.Setting
{
    public partial class Setting : UserControl
    {
        private readonly ServiceHub _serviceHub;
        public Setting(ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
