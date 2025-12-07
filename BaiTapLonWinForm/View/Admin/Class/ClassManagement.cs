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

        public ClassManagement(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
            LoadClassData();
        }


        // Hàm lấy dữ liệu từ database (mock data example)


        // Hàm load và render dữ liệu
        private async void LoadClassData()
        {
            // Xóa các control cũ (trừ header)
            for (int i = tableLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                if (tableLayoutPanel1.Controls[i] is Guna2ShadowPanel)
                {
                    tableLayoutPanel1.Controls[i].Dispose();
                }
            }

            // Lấy dữ liệu từ database
            var classes = await _serviceHub.ClassService.GetAllClassesAsync();

            if (!classes.Success)
            {
                MessageHelper.ShowError("Lỗi khi tải dữ liệu lớp học: \n" + classes.Message);
                return;
            }

            var data = classes.Data.ToList();

            // Tính toán số hàng cần thiết (3 cột mỗi hàng)
            int columns = 3;
            int rows = (int)Math.Ceiling(data.Count / (double)columns);

            // Cấu hình TableLayoutPanel
            tableLayoutPanel1.RowCount = rows;
            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 237F));
            }

            // Render từng item
            for (int i = 0; i < data.Count; i++)
            {
                int row = i / columns;
                int col = i % columns;

                Guna2ShadowPanel classPanel = CreateClassPanel(data[i]);
                tableLayoutPanel1.Controls.Add(classPanel, col, row);
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
                ShadowDepth = 120,
                ShadowShift = 3,
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
                Image = Properties.Resources.Ảnh_chụp_màn_hình_2025_12_01_204527,
                Location = new Point(13, 172),
                Size = new Size(35, 33)
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
                Image = Properties.Resources.Ảnh_chụp_màn_hình_2025_12_01_204702,
                Location = new Point(372, 172),
                Size = new Size(35, 33)
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

            // Thêm event click
            panel.Click += (s, e) => OnClassPanelClick(classInfo.ClassId);
            logoBox.Click += (s, e) => OnClassPanelClick(classInfo.ClassId);
            lblClassName.Click += (s, e) => OnClassPanelClick(classInfo.ClassId);

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

