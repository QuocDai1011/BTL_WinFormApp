using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;

namespace BaiTapLonWinForm.View.Admin.Class
{
    public partial class ClassManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly Image _cachedLogo;
        private readonly Image _cachedBranchIcon;
        private readonly Image _cachedStudentIcon;

        public ClassManagement(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            _cachedLogo = Properties.Resources.logo2019_png_1;
            _cachedBranchIcon = Properties.Resources.Ảnh_chụp_màn_hình_2025_12_01_204527;
            _cachedStudentIcon = Properties.Resources.Ảnh_chụp_màn_hình_2025_12_01_204702;
            InitializeComponent();
            this.Load += async (s, e) => await LoadClassData();
        }

        private async Task LoadClassData()
        {
            var classes = await _serviceHub.ClassService.GetAllClassesAsync();

            if (!classes.Success)
            {
                MessageHelper.ShowError("Lỗi: " + classes.Message);
                return;
            }

            var data = classes.Data.ToList();

            tableLayoutPanel1.SuspendLayout();

            try
            {

                foreach (Control ctrl in tableLayoutPanel1.Controls)
                {
                    ctrl.Dispose();
                }
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowStyles.Clear();

                int columns = 3;
                int rows = (int)Math.Ceiling(data.Count / (double)columns);

                tableLayoutPanel1.RowCount = rows;

                for (int i = 0; i < rows; i++)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 237F));
                }

                for (int i = 0; i < data.Count; i++)
                {
                    int row = i / columns;
                    int col = i % columns;

                    var classPanel = CreateClassPanel(data[i]);
                    tableLayoutPanel1.Controls.Add(classPanel, col, row);
                }
            }
            finally
            {
                tableLayoutPanel1.ResumeLayout();
            }
        }

        // Hàm tạo một panel cho mỗi lớp học
        private Guna2ShadowPanel CreateClassPanel(Models.Class classInfo)
        {
            var panel = new Guna2ShadowPanel
            {
                BackColor = Color.Transparent,
                FillColor = Color.White,
                Margin = new Padding(10),
                Size = new Size(449, 225),
                ShadowColor = Color.Black,
                ShadowDepth = 50,
                ShadowShift = 3,
                Radius = 10,
                Cursor = Cursors.Hand
            };

            // Logo Image
            var logoBox = new Guna2PictureBox
            {
                Image = Properties.Resources.logo2019_png_1,
                Location = new Point(3, 3),
                Size = new Size(180, 150),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Class Name Label
            var lblClassName = new Guna2HtmlLabel
            {
                Text = classInfo.ClassName,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(190, 55),
                AutoSize = false,
                Size = new Size(240, 55),
                BackColor = Color.Transparent,
                IsSelectionEnabled = false
            };

            // Start Date Label
            var lblStartDate = new Guna2HtmlLabel
            {
                Text = classInfo.StartDate.ToString("dd/MM/yyyy"),
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(195, 110),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Branch Icon
            var branchIcon = new Guna2PictureBox
            {
                Image = _cachedBranchIcon,
                Location = new Point(13, 172),
                Size = new Size(35, 33),
                SizeMode = PictureBoxSizeMode.Zoom 
            };

            // Branch Label
            var lblBranch = new Guna2HtmlLabel
            {
                Text = "Trung Tâm Anh Ngữ Tre Xanh",
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(50, 175),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Student Icon
            var studentIcon = new Guna2PictureBox
            {
                Image = _cachedStudentIcon,
                Location = new Point(372, 172),
                Size = new Size(35, 33),
                SizeMode = PictureBoxSizeMode.Zoom

            };

            // Current Students Label
            var lblStudents = new Guna2HtmlLabel
            {
                Text = classInfo.CurrentStudent.ToString(),
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(413, 175),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Thêm controls vào panel
            panel.Controls.AddRange(new Control[]
            {
                logoBox, lblClassName, lblStartDate,
                branchIcon, lblBranch,
                studentIcon, lblStudents
            });

            panel.Click += OnClick;
            logoBox.Click += OnClick;
            lblClassName.Click += OnClick;

            // Thêm event click
            void OnClick(object s, EventArgs e) => OnClassPanelClick(classInfo.ClassId);

            return panel;
        }

        // Event handler khi click vào một lớp học
        private void OnClassPanelClick(int classInfoId)
        {
            this.Controls.Clear();
            this.Controls.Add(new ClassDetailControl(_serviceHub, classInfoId)
            {
                Dock = DockStyle.Fill
            });
        }

        // Hàm refresh dữ liệu (gọi khi có thay đổi)
        public void RefreshData()
        {
            LoadClassData();
        }
    }
}

