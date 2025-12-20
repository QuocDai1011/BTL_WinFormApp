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

namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    public partial class MemberItem : UserControl
    {
        private readonly User _currentMember;
        public MemberItem(User member)
        {
            InitializeComponent();
            _currentMember = member;
        }
        //Tạo hàm gán giá trị lên giao diện
        private void MemberItem_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "";
            lblUserName.Text = _currentMember.FirstName + " " + _currentMember.LastName;
        }
    }
}
