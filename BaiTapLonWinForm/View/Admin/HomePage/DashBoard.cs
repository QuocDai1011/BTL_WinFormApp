using BaiTapLonWinForm.Services;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    public partial class DashBoard : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private int totalStudents = 45;
        private int totalClasses = 30;
        private int totalCourses = 18;
        private int totalTeachers = 12;
        private decimal totalRevenue = 169;
        public DashBoard(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void DashBoard_Load(object sender, EventArgs e)
        {
            var result = await _serviceHub.StudentService.GetAllStudentsAsync();

            if (result.Success)
            {
                lblTongHocVien.Text = result.Data.Count().ToString();
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var result = await _serviceHub.StudentService.GetAllStudentsAsync();
            if (result.Success)
            {
                totalStudents = result.Data.Count();
                lblTongHocVien.Text = totalStudents + "";
            }

            var totalClass = await _serviceHub.ClassService.GetAllClassesAsync();
            if (totalClass.Success)
            {
                totalClasses = totalClass.Data.Count();
                lblTongLopHoc.Text = totalClasses + "";
            }

            var totalCourse = await _serviceHub.CourseService.GetAllCoursesAsync();
            if (totalCourse.Success)
            {
                totalCourses = totalCourse.Data.Count();
                lblTongKhoaHoc.Text = totalCourses + "";
            }


            LoadRevenueChart();
            DrawChartHocVien();
            DrawPieChart();
        }


        private void LoadRevenueChart()
        {
            pnChart.Controls.Clear();

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.BackColor = Color.White;

            // ===== CHART AREA =====
            ChartArea area = new ChartArea("Main");
            area.BackColor = Color.White;

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);

            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.Title = "Triệu VNĐ";
            area.AxisY.TitleFont = new Font("Segoe UI", 9, FontStyle.Bold);

            chart.ChartAreas.Add(area);

            // ===== SERIES =====
            Series s = new Series("Doanh thu");
            s.IsXValueIndexed = true;
            s.ChartType = SeriesChartType.Column;
            s.ChartArea = "Main";

            s.Color = Color.FromArgb(132, 98, 234); // tím

            s["PointWidth"] = "0.5";
            //s["DrawingStyle"] = "Rounded";         // bo tròn cột
            s.IsValueShownAsLabel = true;
            s.LabelForeColor = Color.Black;
            //s.Label = new Font("Segoe UI", 9, FontStyle.Bold);
            s.LabelFormat = "#,##0"; // 170, 220, 285
            s.Label = "#VAL triệu";

            Legend legend = new Legend();
            legend.Docking = Docking.Top;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Segoe UI", 9);
            s.LegendText = "Doanh thu (Triệu VNĐ)";

            chart.Legends.Add(legend);

            // Data
            AddPoint(s, "T7", 189);
            AddPoint(s, "T8", 180);
            AddPoint(s, "T9", 100);
            AddPoint(s, "T10", 111);
            AddPoint(s, "T11", 113); 
            AddPoint(s, "T12", 145);

            chart.Series.Add(s);

            // ===== TITLE =====
            Title title = new Title(
                "Doanh Thu 6 Tháng Gần Nhất (Triệu VNĐ)",
                Docking.Top,
                new Font("Segoe UI", 11, FontStyle.Bold),
                Color.Black
            );
            chart.Titles.Add(title);

            pnChart.Controls.Add(chart);
        }

        private void AddPoint(Series s, string label, double value, bool highlight = false)
        {
            DataPoint p = new DataPoint();
            p.AxisLabel = label;
            p.YValues = new double[] { value };

            // Tooltip khi hover
            p.ToolTip = $"{label}\nDoanh thu: {value:#,##0} triệu VNĐ";

            if (highlight)
            {
                p.Color = Color.FromArgb(110, 110, 110);
                p.BackSecondaryColor = Color.FromArgb(132, 98, 234);
                p.BackGradientStyle = GradientStyle.LeftRight;
                p.BorderWidth = 2;
                p.BorderColor = Color.Black;
            }

            s.Points.Add(p);
        }

        private void DrawChartHocVien()
        {
            pnChartHV.Controls.Clear();

            Chart chartHV = new Chart();
            chartHV.Dock = DockStyle.Fill;
            chartHV.BackColor = Color.White;

            // ===== CHART AREA =====
            ChartArea area = new ChartArea("HVArea");
            area.BackColor = Color.White;

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);

            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 120;
            area.AxisY.Interval = 0;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.Title = "Số lượng học viên";

            chartHV.ChartAreas.Add(area);

            Series series = new Series("Học viên");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.Color = Color.MediumSeaGreen;
            series.ChartArea = "HVArea";
            series.IsXValueIndexed = true;

            // HIỆN GIÁ TRỊ
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#,##0";
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            series.LegendText = "Số lượng học viên";

            series.Points.AddXY("T7", 56);
            series.Points.AddXY("T8", 70);
            series.Points.AddXY("T9", 40);
            series.Points.AddXY("T10", 43);
            series.Points.AddXY("T11", 50);
            series.Points.AddXY("T12", totalStudents);


            chartHV.Series.Add(series);

            // ===== TITLE =====
            Title title = new Title(
                "Tăng Trưởng Học Viên",
                Docking.Top,
                new Font("Segoe UI", 14, FontStyle.Bold),
                Color.Black
            );
            chartHV.Titles.Add(title);

            chartHV.Legends.Clear();

            pnChartHV.Controls.Add(chartHV);
        }

        private async void DrawPieChart()
        {
            pnPieChart.Controls.Clear();

            Chart pieChart = new Chart();
            pieChart.Dock = DockStyle.Fill;
            pieChart.BackColor = Color.White;

            // ===== CHART AREA (KHÔNG AXIS) =====
            ChartArea area = new ChartArea("PieArea");
            area.BackColor = Color.White;
            pieChart.ChartAreas.Add(area);

            // ===== SERIES =====
            Series series = new Series("Học viên");
            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "PieArea";
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ===== GET DATA =====
            var ielts = await _serviceHub.CourseService.GetTotalStudentByClassCodeAsync("IELTS");
            var movers = await _serviceHub.CourseService.GetTotalStudentByClassCodeAsync("MOVERS");
            var flyers = await _serviceHub.CourseService.GetTotalStudentByClassCodeAsync("FLYERS");
            var ket = await _serviceHub.CourseService.GetTotalStudentByClassCodeAsync("KET");
            var other = await _serviceHub.CourseService.GetTotalStudentByOtherClassCodeAsync();

            if (ielts.Success) series.Points.AddXY("IELTS", ielts.Data);
            if (movers.Success) series.Points.AddXY("MOVERS", movers.Data);
            if (flyers.Success) series.Points.AddXY("FLYERS", flyers.Data);
            if (ket.Success) series.Points.AddXY("KET", ket.Data);
            if (other.Success) series.Points.AddXY("Others", other.Data);


            foreach (DataPoint p in series.Points)
            {
                p.LegendText = p.AxisLabel; // IELTS, MOVERS, ...
            }


            // Hiện label trên hình tròn
            series.IsValueShownAsLabel = true;

            // Chỉ hiện phần trăm
            series.Label = "#PERCENT";
            series.LabelFormat = "0%";

            // Không hiện tên khóa học trên lát bánh
            series["PieLabelStyle"] = "Outside"; // hoặc Inside
            series["PieLineColor"] = "Black";


            pieChart.Series.Add(series);

            // ===== TITLE =====
            pieChart.Titles.Add(new Title(
                "Phân Bố Học Viên Theo Khóa",
                Docking.Top,
                new Font("Segoe UI", 14, FontStyle.Bold),
                Color.Black
            ));

            // ===== LEGEND =====
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 9);
            pieChart.Legends.Add(legend);

            pnPieChart.Controls.Add(pieChart);
        }

        private void iconCustom5_Load(object sender, EventArgs e)
        {

        }

        private void iconCustom7_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Báo cáo đang được xuất vui lòng chờ ít phút");
            Thread.Sleep(2000);
            ExportDashboardToPdf();
        }

        private Bitmap CaptureControl(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }

        private void ExportDashboardToPdf()
        {
            // ===== 1. CHỤP DASHBOARD =====
            Bitmap dashboardImage = CaptureControl(this);

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Dashboard Report";

            PdfPage page = document.AddPage();

            // ===== 2. SET SIZE PDF THEO ẢNH (FULL PAGE) =====
            page.Width = dashboardImage.Width;
            page.Height = dashboardImage.Height;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            using (MemoryStream ms = new MemoryStream())
            {
                dashboardImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                using (XImage img = XImage.FromStream(ms))
                {
                    // ===== 3. VẼ ẢNH FULL PAGE =====
                    gfx.DrawImage(
                        img,
                        0,
                        0,
                        page.Width,
                        page.Height
                    );
                }
            }

            // ===== 4. LƯU FILE Ở Ổ D =====
            string folder = @"D:\DashboardReports";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string filePath = Path.Combine(
                folder,
                $"Dashboard_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            );

            document.Save(filePath);

            // ===== 5. TỰ ĐỘNG MỞ FILE =====
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }

    }
}
