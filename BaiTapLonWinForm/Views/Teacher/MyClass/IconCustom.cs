using BaiTapLonWinForm.Views.Teacher.MyClass;
using FontAwesome.Sharp;
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
    public partial class IconCustom : UserControl
    {
        private IconPictureBox iconBox;
        public event EventHandler IconClicked;
        // Rename the private InitializeComponent method to avoid ambiguity with the designer-generated method.
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // IconCustom
            // 
            BackColor = Color.Transparent;
            Name = "IconCustom";
            Size = new Size(20, 20);
            ResumeLayout(false);
            this.Click += IconCustom_Click;
        }

        public IconCustom()
        {
            InitializeComponent();

            iconBox = new IconPictureBox();
            iconBox.Dock = DockStyle.Fill;
            iconBox.IconChar = IconChar.User;
            iconBox.IconColor = Color.Gray;
            iconBox.SizeMode = PictureBoxSizeMode.CenterImage;
            iconBox.BackColor = Color.Transparent;

            this.Controls.Add(iconBox);

            this.Padding = new Padding(0);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.None;

            iconBox.Click += IconBox_Click;
            this.Click += IconBox_Click;
        }
        public void ForceUpdateIcon(IconChar newIcon)
        {
            iconBox.SuspendLayout();
            iconBox.IconChar = newIcon;
            iconBox.ResumeLayout();
            iconBox.Refresh();
            this.Refresh();
        }
        private void IconBox_Click(object sender, EventArgs e)
        {
            IconClicked?.Invoke(this, EventArgs.Empty);
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Chọn icon muốn hiển thị")]
        public IconChar Icon
        {
            get => iconBox.IconChar;
            set
            {
                if (iconBox.IconChar != value)
                {
                    iconBox.IconChar = value;
                    iconBox.Invalidate();
                    iconBox.Update();
                    this.Invalidate();
                    this.Update();
                }
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Màu của icon")]
        public Color IconColor
        {
            get => iconBox.IconColor;
            set
            {
                iconBox.IconColor = value;
                iconBox.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Custom")]
        [Description("Kích thước icon")]
        public int IconSize
        {
            get => iconBox.IconSize;
            set
            {
                iconBox.IconSize = value;
                this.Width = value + 10;
                this.Height = value + 10;
                iconBox.Invalidate();
            }
        }
        public event EventHandler MeetClicked;

        private void IconCustom_Click(object sender, EventArgs e)
        {
            MeetClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
