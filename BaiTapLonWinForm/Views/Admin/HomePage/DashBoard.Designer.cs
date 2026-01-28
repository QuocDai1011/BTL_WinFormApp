namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    partial class DashBoard
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            mainPanel = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pnTongHocVien = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconCustom1 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            label1 = new Label();
            lblTongHocVien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconCustom2 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            label2 = new Label();
            lblTongLopHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconCustom3 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            label3 = new Label();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconCustom4 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            label4 = new Label();
            lblTongKhoaHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flpnChart = new FlowLayoutPanel();
            pnChart = new Panel();
            pnChartHV = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnPieChart = new Panel();
            panel1 = new Panel();
            iconCustom8 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            iconCustom7 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            iconCustom6 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            btnCreateTeacher = new Guna.UI2.WinForms.Guna2Button();
            btnCreateClass = new Guna.UI2.WinForms.Guna2Button();
            iconCustom5 = new BaiTapLonWinForm.Views.Teacher.Controls.IconCustom();
            btnCreateStudent = new Guna.UI2.WinForms.Guna2Button();
            mainPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            pnTongHocVien.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            guna2ShadowPanel3.SuspendLayout();
            flpnChart.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(flowLayoutPanel2);
            mainPanel.Controls.Add(flpnChart);
            mainPanel.Controls.Add(flowLayoutPanel1);
            mainPanel.Dock = DockStyle.Top;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(1906, 1080);
            mainPanel.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(pnTongHocVien);
            flowLayoutPanel2.Controls.Add(guna2ShadowPanel1);
            flowLayoutPanel2.Controls.Add(guna2ShadowPanel2);
            flowLayoutPanel2.Controls.Add(guna2ShadowPanel3);
            flowLayoutPanel2.Location = new Point(23, 23);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1900, 279);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // pnTongHocVien
            // 
            pnTongHocVien.BackColor = Color.Transparent;
            pnTongHocVien.Controls.Add(iconCustom1);
            pnTongHocVien.Controls.Add(label1);
            pnTongHocVien.Controls.Add(lblTongHocVien);
            pnTongHocVien.Controls.Add(guna2HtmlLabel1);
            pnTongHocVien.FillColor = Color.White;
            pnTongHocVien.Location = new Point(120, 3);
            pnTongHocVien.Margin = new Padding(120, 3, 3, 3);
            pnTongHocVien.Name = "pnTongHocVien";
            pnTongHocVien.Radius = 10;
            pnTongHocVien.ShadowColor = Color.Black;
            pnTongHocVien.Size = new Size(339, 270);
            pnTongHocVien.TabIndex = 0;
            // 
            // iconCustom1
            // 
            iconCustom1.BackColor = Color.DodgerBlue;
            iconCustom1.Icon = FontAwesome.Sharp.IconChar.User;
            iconCustom1.IconColor = Color.White;
            iconCustom1.IconSize = 76;
            iconCustom1.Location = new Point(219, 79);
            iconCustom1.Name = "iconCustom1";
            iconCustom1.Padding = new Padding(4);
            iconCustom1.Size = new Size(84, 91);
            iconCustom1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(20, 204);
            label1.Name = "label1";
            label1.Size = new Size(246, 24);
            label1.TabIndex = 2;
            label1.Text = "+12% so với tháng trước";
            // 
            // lblTongHocVien
            // 
            lblTongHocVien.BackColor = Color.Transparent;
            lblTongHocVien.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongHocVien.Location = new Point(20, 101);
            lblTongHocVien.Name = "lblTongHocVien";
            lblTongHocVien.Size = new Size(47, 48);
            lblTongHocVien.TabIndex = 1;
            lblTongHocVien.Text = "45";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(20, 21);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(201, 35);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Tổng Học Viên";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(iconCustom2);
            guna2ShadowPanel1.Controls.Add(label2);
            guna2ShadowPanel1.Controls.Add(lblTongLopHoc);
            guna2ShadowPanel1.Controls.Add(guna2HtmlLabel3);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(572, 3);
            guna2ShadowPanel1.Margin = new Padding(110, 3, 3, 3);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 10;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(339, 270);
            guna2ShadowPanel1.TabIndex = 3;
            // 
            // iconCustom2
            // 
            iconCustom2.BackColor = Color.Chartreuse;
            iconCustom2.Icon = FontAwesome.Sharp.IconChar.BookQuran;
            iconCustom2.IconColor = Color.White;
            iconCustom2.IconSize = 84;
            iconCustom2.Location = new Point(237, 79);
            iconCustom2.Name = "iconCustom2";
            iconCustom2.Size = new Size(84, 91);
            iconCustom2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(20, 204);
            label2.Name = "label2";
            label2.Size = new Size(235, 24);
            label2.TabIndex = 2;
            label2.Text = "+3% so với tháng trước";
            // 
            // lblTongLopHoc
            // 
            lblTongLopHoc.BackColor = Color.Transparent;
            lblTongLopHoc.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongLopHoc.Location = new Point(20, 101);
            lblTongLopHoc.Name = "lblTongLopHoc";
            lblTongLopHoc.Size = new Size(47, 48);
            lblTongLopHoc.TabIndex = 1;
            lblTongLopHoc.Text = "38";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(20, 21);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(200, 35);
            guna2HtmlLabel3.TabIndex = 0;
            guna2HtmlLabel3.Text = "Lớp hoạt động";
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(iconCustom3);
            guna2ShadowPanel2.Controls.Add(label3);
            guna2ShadowPanel2.Controls.Add(guna2HtmlLabel4);
            guna2ShadowPanel2.Controls.Add(guna2HtmlLabel5);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(1024, 3);
            guna2ShadowPanel2.Margin = new Padding(110, 3, 3, 3);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.Size = new Size(339, 270);
            guna2ShadowPanel2.TabIndex = 4;
            // 
            // iconCustom3
            // 
            iconCustom3.BackColor = Color.DarkViolet;
            iconCustom3.Icon = FontAwesome.Sharp.IconChar.ArrowTrendUp;
            iconCustom3.IconColor = Color.White;
            iconCustom3.IconSize = 84;
            iconCustom3.Location = new Point(230, 79);
            iconCustom3.Name = "iconCustom3";
            iconCustom3.Size = new Size(84, 91);
            iconCustom3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Green;
            label3.Location = new Point(20, 204);
            label3.Name = "label3";
            label3.Size = new Size(246, 24);
            label3.TabIndex = 2;
            label3.Text = "+20% so với tháng trước";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.Location = new Point(20, 101);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(102, 48);
            guna2HtmlLabel4.TabIndex = 1;
            guna2HtmlLabel4.Text = "145M";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel5.Location = new Point(20, 21);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(243, 35);
            guna2HtmlLabel5.TabIndex = 0;
            guna2HtmlLabel5.Text = "Doanh Thu Tháng";
            // 
            // guna2ShadowPanel3
            // 
            guna2ShadowPanel3.BackColor = Color.Transparent;
            guna2ShadowPanel3.Controls.Add(iconCustom4);
            guna2ShadowPanel3.Controls.Add(label4);
            guna2ShadowPanel3.Controls.Add(lblTongKhoaHoc);
            guna2ShadowPanel3.Controls.Add(guna2HtmlLabel7);
            guna2ShadowPanel3.FillColor = Color.White;
            guna2ShadowPanel3.Location = new Point(1476, 3);
            guna2ShadowPanel3.Margin = new Padding(110, 3, 3, 3);
            guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            guna2ShadowPanel3.Radius = 10;
            guna2ShadowPanel3.ShadowColor = Color.Black;
            guna2ShadowPanel3.Size = new Size(339, 270);
            guna2ShadowPanel3.TabIndex = 4;
            // 
            // iconCustom4
            // 
            iconCustom4.BackColor = Color.FromArgb(255, 128, 0);
            iconCustom4.Icon = FontAwesome.Sharp.IconChar.Stairs;
            iconCustom4.IconColor = Color.White;
            iconCustom4.IconSize = 84;
            iconCustom4.Location = new Point(228, 79);
            iconCustom4.Name = "iconCustom4";
            iconCustom4.Size = new Size(84, 91);
            iconCustom4.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(20, 204);
            label4.Name = "label4";
            label4.Size = new Size(235, 24);
            label4.TabIndex = 2;
            label4.Text = "+2% so với tháng trước";
            // 
            // lblTongKhoaHoc
            // 
            lblTongKhoaHoc.BackColor = Color.Transparent;
            lblTongKhoaHoc.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongKhoaHoc.Location = new Point(20, 101);
            lblTongKhoaHoc.Name = "lblTongKhoaHoc";
            lblTongKhoaHoc.Size = new Size(47, 48);
            lblTongKhoaHoc.TabIndex = 1;
            lblTongKhoaHoc.Text = "25";
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.Location = new Point(20, 21);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(131, 35);
            guna2HtmlLabel7.TabIndex = 0;
            guna2HtmlLabel7.Text = "Khóa học";
            // 
            // flpnChart
            // 
            flpnChart.Controls.Add(pnChart);
            flpnChart.Controls.Add(pnChartHV);
            flpnChart.Location = new Point(23, 335);
            flpnChart.Margin = new Padding(3, 30, 3, 3);
            flpnChart.Name = "flpnChart";
            flpnChart.Size = new Size(1873, 339);
            flpnChart.TabIndex = 1;
            // 
            // pnChart
            // 
            pnChart.BorderStyle = BorderStyle.Fixed3D;
            pnChart.Location = new Point(120, 3);
            pnChart.Margin = new Padding(120, 3, 3, 3);
            pnChart.Name = "pnChart";
            pnChart.Size = new Size(791, 336);
            pnChart.TabIndex = 0;
            // 
            // pnChartHV
            // 
            pnChartHV.BorderStyle = BorderStyle.Fixed3D;
            pnChartHV.Location = new Point(1034, 3);
            pnChartHV.Margin = new Padding(120, 3, 3, 3);
            pnChartHV.Name = "pnChartHV";
            pnChartHV.Size = new Size(791, 336);
            pnChartHV.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pnPieChart);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(23, 697);
            flowLayoutPanel1.Margin = new Padding(3, 20, 3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1873, 339);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // pnPieChart
            // 
            pnPieChart.BorderStyle = BorderStyle.Fixed3D;
            pnPieChart.Location = new Point(120, 3);
            pnPieChart.Margin = new Padding(120, 3, 3, 3);
            pnPieChart.Name = "pnPieChart";
            pnPieChart.Size = new Size(791, 336);
            pnPieChart.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(iconCustom8);
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(iconCustom7);
            panel1.Controls.Add(iconCustom6);
            panel1.Controls.Add(btnCreateTeacher);
            panel1.Controls.Add(btnCreateClass);
            panel1.Controls.Add(iconCustom5);
            panel1.Controls.Add(btnCreateStudent);
            panel1.Location = new Point(1034, 3);
            panel1.Margin = new Padding(120, 3, 3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(791, 336);
            panel1.TabIndex = 2;
            // 
            // iconCustom8
            // 
            iconCustom8.BackColor = Color.Red;
            iconCustom8.ForeColor = Color.Transparent;
            iconCustom8.Icon = FontAwesome.Sharp.IconChar.CirclePlus;
            iconCustom8.IconColor = Color.White;
            iconCustom8.IconSize = 50;
            iconCustom8.Location = new Point(462, 228);
            iconCustom8.Name = "iconCustom8";
            iconCustom8.Size = new Size(50, 50);
            iconCustom8.TabIndex = 13;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 25;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Red;
            guna2Button1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(408, 199);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(373, 98);
            guna2Button1.TabIndex = 12;
            guna2Button1.Text = "Xuất Báo Cáo";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // iconCustom7
            // 
            iconCustom7.BackColor = Color.FromArgb(192, 0, 192);
            iconCustom7.ForeColor = Color.Transparent;
            iconCustom7.Icon = FontAwesome.Sharp.IconChar.CirclePlus;
            iconCustom7.IconColor = Color.White;
            iconCustom7.IconSize = 50;
            iconCustom7.Location = new Point(62, 228);
            iconCustom7.Name = "iconCustom7";
            iconCustom7.Size = new Size(50, 50);
            iconCustom7.TabIndex = 11;
            iconCustom7.Load += iconCustom7_Load;
            // 
            // iconCustom6
            // 
            iconCustom6.BackColor = Color.DeepSkyBlue;
            iconCustom6.ForeColor = Color.Transparent;
            iconCustom6.Icon = FontAwesome.Sharp.IconChar.CirclePlus;
            iconCustom6.IconColor = Color.White;
            iconCustom6.IconSize = 50;
            iconCustom6.Location = new Point(419, 56);
            iconCustom6.Name = "iconCustom6";
            iconCustom6.Size = new Size(50, 50);
            iconCustom6.TabIndex = 9;
            // 
            // btnCreateTeacher
            // 
            btnCreateTeacher.BorderRadius = 25;
            btnCreateTeacher.Cursor = Cursors.Hand;
            btnCreateTeacher.CustomizableEdges = customizableEdges3;
            btnCreateTeacher.DisabledState.BorderColor = Color.DarkGray;
            btnCreateTeacher.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateTeacher.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateTeacher.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateTeacher.FillColor = Color.DeepSkyBlue;
            btnCreateTeacher.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateTeacher.ForeColor = Color.White;
            btnCreateTeacher.Location = new Point(408, 28);
            btnCreateTeacher.Name = "btnCreateTeacher";
            btnCreateTeacher.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCreateTeacher.Size = new Size(373, 98);
            btnCreateTeacher.TabIndex = 8;
            btnCreateTeacher.Text = "Thêm Giảng Viên Mới";
            btnCreateTeacher.Click += btnCreateTeacher_Click;
            // 
            // btnCreateClass
            // 
            btnCreateClass.BorderRadius = 25;
            btnCreateClass.Cursor = Cursors.Hand;
            btnCreateClass.CustomizableEdges = customizableEdges5;
            btnCreateClass.DisabledState.BorderColor = Color.DarkGray;
            btnCreateClass.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateClass.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateClass.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateClass.FillColor = Color.FromArgb(192, 0, 192);
            btnCreateClass.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateClass.ForeColor = Color.White;
            btnCreateClass.Location = new Point(3, 199);
            btnCreateClass.Name = "btnCreateClass";
            btnCreateClass.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCreateClass.Size = new Size(373, 98);
            btnCreateClass.TabIndex = 10;
            btnCreateClass.Text = "Tạo Lớp Học";
            btnCreateClass.Click += btnCreateClass_Click;
            // 
            // iconCustom5
            // 
            iconCustom5.BackColor = Color.FromArgb(0, 192, 0);
            iconCustom5.ForeColor = Color.Transparent;
            iconCustom5.Icon = FontAwesome.Sharp.IconChar.CirclePlus;
            iconCustom5.IconColor = Color.White;
            iconCustom5.IconSize = 50;
            iconCustom5.Location = new Point(26, 56);
            iconCustom5.Name = "iconCustom5";
            iconCustom5.Size = new Size(50, 50);
            iconCustom5.TabIndex = 7;
            iconCustom5.Load += iconCustom5_Load;
            // 
            // btnCreateStudent
            // 
            btnCreateStudent.BorderRadius = 25;
            btnCreateStudent.Cursor = Cursors.Hand;
            btnCreateStudent.CustomizableEdges = customizableEdges7;
            btnCreateStudent.DisabledState.BorderColor = Color.DarkGray;
            btnCreateStudent.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCreateStudent.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCreateStudent.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCreateStudent.FillColor = Color.FromArgb(0, 192, 0);
            btnCreateStudent.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateStudent.ForeColor = Color.White;
            btnCreateStudent.Location = new Point(3, 28);
            btnCreateStudent.Name = "btnCreateStudent";
            btnCreateStudent.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCreateStudent.Size = new Size(373, 98);
            btnCreateStudent.TabIndex = 4;
            btnCreateStudent.Text = "Thêm Học Viên Mới";
            btnCreateStudent.Click += btnCreateStudent_Click;
            // 
            // DashBoard
            // 
            Controls.Add(mainPanel);
            Name = "DashBoard";
            Size = new Size(1906, 1310);
            mainPanel.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            pnTongHocVien.ResumeLayout(false);
            pnTongHocVien.PerformLayout();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            guna2ShadowPanel3.ResumeLayout(false);
            guna2ShadowPanel3.PerformLayout();
            flpnChart.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private FlowLayoutPanel mainPanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnTongHocVien;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongHocVien;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom2;
        private Label label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongLopHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom3;
        private Label label3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom4;
        private Label label4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongKhoaHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private FlowLayoutPanel flpnChart;
        private Panel pnChart;
        private Panel pnChartHV;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnPieChart;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnCreateStudent;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom5;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom7;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom6;
        private Guna.UI2.WinForms.Guna2Button btnCreateTeacher;
        private Guna.UI2.WinForms.Guna2Button btnCreateClass;
        private BaiTapLonWinForm.Views.Teacher.Controls.IconCustom iconCustom8;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
