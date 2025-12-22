using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;

namespace BaiTapLonWinForm.View.Admin.Class
{
    public enum ClassFilterStatus
    {
        Upcoming, // Sắp diễn ra (Status = -1)
        Ongoing,  // Đang diễn ra (Status = 0)
        Finished  // Đã kết thúc (Status = 1)
    }

    public partial class ClassManagement : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly Image _cachedLogo;
        private readonly Image _cachedUserIcon;
        private readonly Image _cachedStudentIcon;
        private List<Models.Class> _allClassesCache;

        // 3 TableLayoutPanel riêng biệt cho mỗi tab
        private TableLayoutPanel _tableUpcoming;
        private TableLayoutPanel _tableOngoing;
        private TableLayoutPanel _tableFinished;

        public ClassManagement(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;

            // Pre-load resources
            _cachedLogo = Properties.Resources.logo2019_png_1;
            _cachedUserIcon = Properties.Resources.user;
            _cachedStudentIcon = Properties.Resources.Ảnh_chụp_màn_hình_2025_12_01_204702;

            InitializeComponent();
            SetupCustomUI();

            this.Load += async (s, e) => await LoadClassData();
        }

        private void SetupCustomUI()
        {
            // Tạo 3 TableLayoutPanel cho 3 tab
            _tableUpcoming = CreateTableLayoutPanel();
            _tableOngoing = CreateTableLayoutPanel();
            _tableFinished = CreateTableLayoutPanel();

            // Add vào từng tab page
            tabPageUpcoming.Controls.Add(_tableUpcoming);
            tabPageOngoing.Controls.Add(_tableOngoing);
            tabPageFinished.Controls.Add(_tableFinished);

            // Thiết lập tab mặc định
            guna2TabControl1.SelectedIndex = 0;
        }

        private TableLayoutPanel CreateTableLayoutPanel()
        {
            var table = new TableLayoutPanel
            {
                AutoScroll = true,
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(10, 10, SystemInformation.VerticalScrollBarWidth + 10, 10)
            };

            // Cấu hình 3 cột đều nhau
            table.ColumnStyles.Clear();
            float percent = 100f / 3;
            for (int i = 0; i < 3; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
            }

            // Row mặc định
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 245F));

            return table;
        }

        private async Task LoadClassData()
        {
            this.Cursor = Cursors.WaitCursor;

            var result = await _serviceHub.ClassService.GetAllClassesAsync();


            this.Cursor = Cursors.Default;

            if (!result.Success)
            {
                MessageHelper.ShowError("Lỗi: " + result.Message);
                return;
            }

            // Lưu cache
            _allClassesCache = result.Data?.ToList() ?? new List<Models.Class>();


            // Render dữ liệu cho cả 3 tab
            RenderTable(_tableUpcoming, ClassFilterStatus.Upcoming);
            RenderTable(_tableOngoing, ClassFilterStatus.Ongoing);
            RenderTable(_tableFinished, ClassFilterStatus.Finished);
        }

        private List<Models.Class> FilterData(ClassFilterStatus status)
        {
            if (_allClassesCache == null) return new List<Models.Class>();

            switch (status)
            {
                case ClassFilterStatus.Upcoming:
                    return _allClassesCache.Where(c => c.Status == -1).ToList();
                case ClassFilterStatus.Ongoing:
                    return _allClassesCache.Where(c => c.Status == 0).ToList();
                case ClassFilterStatus.Finished:
                    return _allClassesCache.Where(c => c.Status == 1).ToList();
                default:
                    return new List<Models.Class>();
            }
        }

        private void RenderTable(TableLayoutPanel table, ClassFilterStatus status)
        {
            if (table == null) return;

            var filteredList = FilterData(status);

            table.SuspendLayout();
            try
            {
                while (table.Controls.Count > 0)
                {
                    var control = table.Controls[0];
                    table.Controls.RemoveAt(0);
                    control.Dispose();
                }

                table.RowStyles.Clear();

                int columns = 3;
                int rows = filteredList.Count > 0
                    ? (int)Math.Ceiling((double)filteredList.Count / columns)
                    : 1;

                table.RowCount = rows;

                float rowHeight = 245F;
                for (int i = 0; i < rows; i++)
                {
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                }

                if (filteredList == null || filteredList.Count == 0)
                {
                    table.RowCount = 1;
                    table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); 
                    Guna2HtmlLabel lblEmpty = new Guna2HtmlLabel
                    {
                        Text = "<div style='text-align:center; padding-top: 20px; color: gray; font-size: 18px'>" +
                               "<b style='font-size: 18px'>Không tìm thấy lớp học nào</b><br/>" +
                               "Hiện tại chưa có lớp học ở trạng thái này." +
                               "</div>",
                        AutoSize = false,            
                        Dock = DockStyle.Fill,       
                        TextAlignment = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };

                    table.Controls.Add(lblEmpty, 0, 0);

                    table.SetColumnSpan(lblEmpty, columns);
                }

                // Thêm các card
                for (int i = 0; i < filteredList.Count; i++)
                {
                    int row = i / columns;
                    int col = i % columns;

                    var classPanel = CreateClassPanel(filteredList[i]);
                    table.Controls.Add(classPanel, col, row);
                }
            }
            finally
            {
                table.ResumeLayout(true);
            }
        }

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
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.None
            };

            // Logo
            var logoBox = new Guna2PictureBox
            {
                Image = _cachedLogo,
                Location = new Point(3, 3),
                Size = new Size(180, 150),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Tên lớp
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

            // Ngày khai giảng
            var lblStartDate = new Guna2HtmlLabel
            {
                Text = "Khai giảng: " + classInfo.StartDate.ToString("dd/MM/yyyy"),
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(195, 110),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Icon & Text Chi nhánh
            var branchIcon = new Guna2PictureBox
            {
                Image = _cachedUserIcon,
                Location = new Point(13, 172),
                Size = new Size(35, 33),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            string teacherName = $"{classInfo.Teacher.User.FirstName} {classInfo.Teacher.User.LastName}";


            var lblTeacherName = new Guna2HtmlLabel
            {
                Text = teacherName != null ? $"Giảng viên: {teacherName}": "Chưa phân công",
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(50, 175),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Icon & Text Số lượng học viên
            var studentIcon = new Guna2PictureBox
            {
                Image = _cachedStudentIcon,
                Location = new Point(372, 172),
                Size = new Size(35, 33),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            var lblStudents = new Guna2HtmlLabel
            {
                Text = (classInfo.CurrentStudent ?? 0).ToString(),
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(413, 175),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Add controls vào panel
            panel.Controls.AddRange(new Control[] {
                logoBox, lblClassName, lblStartDate,
                branchIcon, lblTeacherName, studentIcon, lblStudents
            });

            // Sự kiện Click
            void OnClick(object s, EventArgs e) => OnClassPanelClick(classInfo.ClassId);

            panel.Click += OnClick;
            foreach (Control c in panel.Controls)
            {
                c.Click += OnClick;
            }

            return panel;
        }

        private void OnClassPanelClick(int classId)
        {
            this.Controls.Clear();
            var detailControl = new ClassDetailControl(_serviceHub, classId)
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(detailControl);
        }

        public void RefreshData()
        {
            _ = LoadClassData();
        }
    }
}