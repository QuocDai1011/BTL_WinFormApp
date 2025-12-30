using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Teacher.Controls;
using BaiTapLonWinForm.Views.Teacher.MyCalenda;
using BaiTapLonWinForm.Views.Teacher.MyClass;
using BaiTapLonWinForm.Views.Teacher.Profile;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher
{
    /// <summary>
    /// TeacherPage - Main form với control caching để tránh reload không cần thiết
    /// </summary>
    public partial class TeacherPage : Form
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        
        // Cache controls để tránh tạo lại
        private ClassList _classList;
        private Calenda _calenda;
        private MyProfile _profile;
        
        private bool isDarkMode = false;

        public TeacherPage(ServiceHub serviceHub, int teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;

            // Enable double buffering
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint, 
                true
            );
            this.UpdateStyles();

            LoadLabelName();
            LoadClassList();
        }

        private void LoadLabelName()
        {
            var teacher = _serviceHub.UserService.GetUserByTeacherId(_teacherId);
            lblMenuUserName.Text = $"{teacher.FirstName} {teacher.LastName}";
        }

        #region Class List Management
        private void LoadClassList()
        {
            // Cache ClassList - chỉ tạo MỘT LẦN
            if (_classList == null)
            {
                _classList = new ClassList(_teacherId, _serviceHub)
                {
                    Dock = DockStyle.Fill
                };
                _classList.OnOpenClassDetail += OpenClassDetail;
            }

            // Chỉ add nếu chưa có trong panel
            if (!pnMain.Controls.Contains(_classList))
            {
                pnMain.SuspendLayout();
                pnMain.Controls.Clear();
                pnMain.Controls.Add(_classList);
                pnMain.ResumeLayout(false);

                // Async load data
                _ = _classList.LoadClassesAsync();
            }
        }

        public void RefreshClassList()
        {
            _classList?.LoadClassesAsync();
        }

        public void ClearClassListCache()
        {
            // ClassList will handle its own cache disposal
            if (_classList != null)
            {
                _classList = null;
            }
        }
        #endregion

        #region Navigation
        private void MenuClass_Click(object sender, EventArgs e)
        {
            string title = (sender as Guna2GradientButton)?.Text ?? "Lớp học của tôi";
            UpdateMainTitleAndClearMenuLabels(title);

            // Skip nếu đã hiển thị
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _classList)
                return;

            LoadClassList();
        }

        private void MenuCalenda_Click(object sender, EventArgs e)
        {
            string title = (sender as Guna2GradientButton)?.Text ?? "Lịch làm việc";
            UpdateMainTitleAndClearMenuLabels(title);

            // Cache calendar
            if (_calenda == null)
            {
                _calenda = new Calenda(_serviceHub, _teacherId)
                {
                    Dock = DockStyle.Fill
                };
            }

            // Skip nếu đã hiển thị
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _calenda)
                return;

            pnMain.SuspendLayout();
            pnMain.Controls.Clear();
            pnMain.Controls.Add(_calenda);
            pnMain.ResumeLayout(false);
        }

        private void pnProfileTeacher_Click(object sender, EventArgs e)
        {
            UpdateMainTitleAndClearMenuLabels("Hồ sơ cá nhân");

            // Cache profile
            if (_profile == null)
            {
                _profile = new MyProfile(_teacherId, _serviceHub);
            }

            // Skip nếu đã hiển thị
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _profile)
                return;

            pnMain.SuspendLayout();
            pnMain.Controls.Clear();
            pnMain.AutoScroll = true;
            pnMain.Controls.Add(_profile);
            pnMain.ResumeLayout(false);
        }

        private void OpenClassDetail(long classId)
        {
            pnMain.SuspendLayout();
            pnMain.Controls.Clear();

            // Add breadcrumb label
            try
            {
                var cls = _serviceHub.ClassService.GetClassById(classId);
                string className = cls?.ClassName ?? "Lớp học";

                var target = this.Controls.Find("pnMainMenuTitle", true).FirstOrDefault() as FlowLayoutPanel
                    ?? this.Controls.Find("pnFlowTitle", true).FirstOrDefault() as FlowLayoutPanel;

                if (target != null)
                {
                    // Remove existing breadcrumb
                    var existing = target.Controls.Cast<Control>()
                        .OfType<Guna2HtmlLabel>()
                        .FirstOrDefault(c => c.Text.StartsWith("/ "));
                    
                    if (existing != null)
                        target.Controls.Remove(existing);

                    var lbl = new Guna2HtmlLabel
                    {
                        BackColor = Color.Transparent,
                        Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                        ForeColor = Color.Teal,
                        AutoSize = false,
                        Size = new Size(500, 34),
                        TextAlignment = ContentAlignment.MiddleLeft,
                        Text = $"/ {className}",
                        Margin = new Padding(8, 6, 8, 6)
                    };

                    target.Controls.Add(lbl);
                }
            }
            catch { }

            var classDetail = new ClassDetail(classId, _serviceHub)
            {
                Dock = DockStyle.Fill
            };

            pnMain.Controls.Add(classDetail);
            pnMain.ResumeLayout(false);
        }
        #endregion

        #region Helper Methods
        private void UpdateMainTitleAndClearMenuLabels(string newTitle)
        {
            if (!string.IsNullOrEmpty(newTitle))
                lblMainTitle.Text = newTitle;

            var target = this.Controls.Find("pnMainMenuTitle", true).FirstOrDefault() as FlowLayoutPanel
                ?? this.Controls.Find("pnFlowTitle", true).FirstOrDefault() as FlowLayoutPanel;

            if (target == null) return;

            var toRemove = target.Controls.Cast<Control>()
                .Where(c => c != lblMainTitle && (c is Label || c.GetType().Name.Contains("HtmlLabel")))
                .ToList();

            foreach (var c in toRemove)
            {
                target.Controls.Remove(c);
                c.Dispose();
            }
        }

        private void lblMainTitle_Click(object sender, EventArgs e)
        {
            if (lblMainTitle.Text == "Lớp học của tôi")
            {
                MenuClass_Click(sender, e);
            }
            else if (lblMainTitle.Text == "Lịch làm việc")
            {
                MenuCalenda_Click(sender, e);
            }
        }
        #endregion

        #region Map Navigation
        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Việc truy cập và chia sẻ vị trí hiện tại của bạn sẽ cho phép chúng tôi theo dõi lộ trình. Bạn có chắc chắn mở?",
                "Cảnh báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.OK) return;

            string destination = "96/9 Chung cư Kim Sơn 1, Đặng Thùy Trâm, P13, Bình Thạnh, HCM, Việt Nam";
            string destEncoded = Uri.EscapeDataString(destination);
            string url = $"https://www.google.com/maps/dir/?api=1&destination={destEncoded}&travelmode=driving";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở trình duyệt: {ex.Message}");
            }
        }
        #endregion

        #region Dark/Light Mode
        private void ptbxToggleMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;

            if (isDarkMode)
                ApplyDarkMode();
            else
                ApplyLightMode();
        }

        private void ApplyDarkMode()
        {
            // SideBar
            pnSideBar.FillColor = Color.FromArgb(0, 27, 51);
            pnSideBar.FillColor2 = Color.FromArgb(0, 0, 0);
            pnSideBar.FillColor3 = Color.FromArgb(0, 27, 51);
            pnSideBar.FillColor4 = Color.FromArgb(4, 59, 59);

            // Header
            lblMenuUserName.ForeColor = Color.White;
            pnHeaderTeacher.FillColor = Color.FromArgb(4, 59, 59);
            pnHeaderTeacher.FillColor2 = Color.Black;
            pnHeaderTeacher.FillColor3 = Color.FromArgb(0, 27, 51);
            pnHeaderTeacher.FillColor4 = Color.FromArgb(0, 27, 51);

            foreach (Control label in pnHeaderTeacher.Controls)
            {
                if (label is Guna2HtmlLabel)
                    label.ForeColor = Color.White;
            }

            // Border & Main Panel
            pnBorderMain.FillColor = Color.FromArgb(72, 181, 183);
            pnBorderMain.FillColor2 = Color.FromArgb(61, 104, 201);
            pnBorderMain.FillColor3 = Color.FromArgb(72, 181, 183);
            pnBorderMain.FillColor4 = Color.FromArgb(61, 104, 201);

            pnParentPanelMain.FillColor = Color.FromArgb(4, 59, 59);
            pnParentPanelMain.FillColor2 = Color.Black;
            pnParentPanelMain.FillColor3 = Color.Black;
            pnParentPanelMain.FillColor4 = Color.FromArgb(0, 27, 51);

            // Menu buttons
            foreach (Control ctrl in fpnBtnMenu.Controls)
            {
                if (ctrl is Guna2GradientButton btn)
                {
                    btn.CheckedState.FillColor = Color.FromArgb(61, 104, 201);
                    btn.CheckedState.FillColor2 = Color.FromArgb(72, 181, 183);
                    btn.ForeColor = Color.White;
                }
            }
        }

        private void ApplyLightMode()
        {
            // SideBar
            pnSideBar.FillColor = Color.FromArgb(72, 181, 183);
            pnSideBar.FillColor2 = Color.White;
            pnSideBar.FillColor3 = Color.MediumSpringGreen;
            pnSideBar.FillColor4 = Color.FromArgb(61, 104, 201);

            // Header
            lblMenuUserName.ForeColor = Color.Black;
            pnHeaderTeacher.FillColor = Color.White;
            pnHeaderTeacher.FillColor2 = Color.White;
            pnHeaderTeacher.FillColor3 = Color.White;
            pnHeaderTeacher.FillColor4 = Color.White;

            foreach (Control label in pnHeaderTeacher.Controls)
            {
                if (label is Guna2HtmlLabel)
                    label.ForeColor = Color.Black;
            }

            // Border & Main Panel
            pnBorderMain.FillColor = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor2 = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor3 = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor4 = Color.FromArgb(213, 245, 232);

            pnParentPanelMain.FillColor = Color.White;
            pnParentPanelMain.FillColor2 = Color.White;
            pnParentPanelMain.FillColor3 = Color.White;
            pnParentPanelMain.FillColor4 = Color.White;

            // Menu buttons
            foreach (Control ctrl in fpnBtnMenu.Controls)
            {
                if (ctrl is Guna2GradientButton btn)
                {
                    btn.CheckedState.FillColor = Color.White;
                    btn.CheckedState.FillColor2 = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _classList?.Dispose();
                _calenda?.Dispose();
                _profile?.Dispose();
                
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}