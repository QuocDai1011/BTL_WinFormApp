using Guna.UI2.WinForms;
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
    public partial class NewDetail : UserControl
    {
        public NewDetail()
        {
            InitializeComponent();
            this.AutoScroll = false;
            fpnNewContainer.AutoScroll = true;
            fpnNewContainer.WrapContents = false;
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Guna2Panel overlay = new Guna2Panel();
            overlay.Dock = DockStyle.Fill;
            overlay.BackColor = Color.FromArgb(100, 0, 0, 0); // semi-transparent black
            var addNew = new MyNews.AddNew();
            addNew.Size = new Size(700, 450);
            addNew.Anchor = AnchorStyles.None;
            addNew.Dock = DockStyle.Fill;

            overlay.Controls.Add(addNew);
            pnNewMain.Controls.Add(overlay);

            overlay.BringToFront();

            // center AddNew
            addNew.Location = new Point(
                (overlay.Width - addNew.Width) / 2,
                (overlay.Height - addNew.Height) / 2
            );

            overlay.Resize += (s, ev) =>
            {
                addNew.Location = new Point(
                    (overlay.Width - addNew.Width) / 2,
                    (overlay.Height - addNew.Height) / 2
                );
            };
        }
    }
}
