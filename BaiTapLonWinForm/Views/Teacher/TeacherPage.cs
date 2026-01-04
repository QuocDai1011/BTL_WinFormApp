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
    public partial class TeacherPage : Form
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;

        private ClassList _classList;
        private Calenda _calenda;
        private MyProfile _profile;
        private Guna2Panel loadingOverlay;
        private Guna2WinProgressIndicator progressLoader;
        private bool isDarkMode = false;
        private bool isInitialized = false;

        public TeacherPage(ServiceHub serviceHub, int teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;

            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true
            );
            this.UpdateStyles();
            LoadLabelName();
            isInitialized = true;
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            MenuClass_Click(null, null);
        }
        private void LoadLabelName()
        {
            var teacher = _serviceHub.UserService.GetUserByTeacherId(_teacherId);
            lblMenuUserName.Text = $"{teacher.FirstName} {teacher.LastName}";
        }

        #region Class List Management

        public void RefreshClassList()
        {
            _classList?.LoadClassesAsync();
        }

        public void ClearClassListCache()
        {
            if (_classList != null)
            {
                _classList = null;
            }
        }
        #endregion

        #region Navigation
        private void OpenClassDetail(long classId)
        {
            pnMain.Visible = false;
            SuspendDrawing();
            pnMain.SuspendLayout();

            try
            {
                for (int i = pnMain.Controls.Count - 1; i >= 0; i--)
                {
                    var ctrl = pnMain.Controls[i];
                    if (ctrl == _classList || ctrl == _calenda || ctrl == _profile)
                        pnMain.Controls.Remove(ctrl);
                    else
                        ctrl.Dispose();
                }
                pnMain.Controls.Clear();

                var cls = _serviceHub.ClassService.GetClassById(classId);
                string className = cls?.ClassName ?? "Lớp học";

                var target = this.Controls.Find("pnMainMenuTitle", true).FirstOrDefault() as FlowLayoutPanel
                            ?? this.Controls.Find("pnFlowTitle", true).FirstOrDefault() as FlowLayoutPanel;

                if (target != null)
                {
                    var oldLabels = target.Controls.OfType<Guna2HtmlLabel>()
                                          .Where(c => c.Text.StartsWith("/ "))
                                          .ToList();
                    foreach (var old in oldLabels)
                    {
                        target.Controls.Remove(old);
                        old.Dispose();
                    }

                    var lbl = new Guna2HtmlLabel
                    {
                        BackColor = Color.Transparent,
                        Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                        ForeColor = isDarkMode ? Color.FromArgb(72, 181, 183) : Color.Teal,
                        AutoSize = false,
                        Size = new Size(500, 34),
                        TextAlignment = ContentAlignment.MiddleLeft,
                        Text = $"/ {className}",
                        Margin = new Padding(8, 6, 8, 6)
                    };
                    target.Controls.Add(lbl);
                }

                var classDetail = new ClassDetail(classId, _serviceHub) { Dock = DockStyle.Fill };
                pnMain.Controls.Add(classDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Error opening class detail: " + ex.Message);
            }
            finally
            {
                pnMain.ResumeLayout(true);
                ResumeDrawing();
                pnMain.Visible = true;
            }
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

            for (int i = target.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = target.Controls[i];
                if (ctrl is Guna2HtmlLabel lbl && lbl != lblMainTitle && lbl.Text.StartsWith("/ "))
                {
                    target.Controls.Remove(lbl);
                    lbl.Dispose();
                }
            }
        }
        #endregion
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public void SuspendDrawing() => SendMessage(this.Handle, WM_SETREDRAW, false, 0);

        public void ResumeDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Refresh();
        }

        #region Theme Management
        private void ApplyDarkMode()
        {
            pnMain.Visible = false;
            pnMain.Refresh();
            Color darkBg = Color.FromArgb(0, 27, 51);
            Color darkAccent = Color.FromArgb(4, 59, 59);

            SetPanelGradient(pnSideBar, darkBg, Color.Black, darkBg, darkAccent);
            SetPanelGradient(pnHeaderTeacher, darkAccent, Color.Black, darkBg, darkBg);

            lblMenuUserName.ForeColor = Color.White;
            SetPanelGradient(pnParentPanelMain, darkAccent, Color.Black, Color.Black, darkBg);

            foreach (var btn in fpnBtnMenu.Controls.OfType<Guna2GradientButton>())
            {
                btn.CheckedState.FillColor = Color.FromArgb(61, 104, 201);
                btn.CheckedState.FillColor2 = Color.FromArgb(72, 181, 183);
                btn.ForeColor = Color.White;
            }
        }

        private void SetPanelGradient(Guna2CustomGradientPanel p, Color c1, Color c2, Color c3, Color c4)
        {
            p.FillColor = c1;
            p.FillColor2 = c2;
            p.FillColor3 = c3;
            p.FillColor4 = c4;
        }

        private void ApplyLightMode()
        {
            pnMain.Visible = false;
            pnMain.Refresh();

            pnSideBar.FillColor = Color.FromArgb(72, 181, 183);
            pnSideBar.FillColor2 = Color.White;
            pnSideBar.FillColor3 = Color.MediumSpringGreen;
            pnSideBar.FillColor4 = Color.FromArgb(61, 104, 201);

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

            pnBorderMain.FillColor = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor2 = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor3 = Color.FromArgb(213, 245, 232);
            pnBorderMain.FillColor4 = Color.FromArgb(213, 245, 232);

            pnParentPanelMain.FillColor = Color.White;
            pnParentPanelMain.FillColor2 = Color.White;
            pnParentPanelMain.FillColor3 = Color.White;
            pnParentPanelMain.FillColor4 = Color.White;

            foreach (Control ctrl in fpnBtnMenu.Controls)
            {
                if (ctrl is Guna2GradientButton btn)
                {
                    btn.CheckedState.FillColor = Color.White;
                    btn.CheckedState.FillColor2 = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }
            
            _classList?.ApplyThemeToAllItems(false);
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
        private async void MenuClass_Click(object sender, EventArgs e)
        {
            string title = (sender as Guna2GradientButton)?.Text ?? "Lớp học của tôi";
            UpdateMainTitleAndClearMenuLabels(title);

            if (_classList == null)
            {
                _classList = new ClassList(_teacherId, _serviceHub) { Dock = DockStyle.Fill };
                _classList.OnOpenClassDetail += OpenClassDetail;
            }
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _classList)
            {
                pnMain.Visible = false;
                await _classList.LoadClassesAsync();
                pnMain.Visible = true;
                return;
            }

            pnMain.Visible = false;
            pnMain.SuspendLayout();

            for (int i = pnMain.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = pnMain.Controls[i];
                if (ctrl == _classList || ctrl == _calenda || ctrl == _profile)
                    pnMain.Controls.Remove(ctrl);
                else
                    ctrl.Dispose();
            }
            pnMain.Controls.Clear();

            pnMain.Controls.Add(_classList);
            pnMain.ResumeLayout(false);
            await _classList.LoadClassesAsync();
            pnMain.Visible = true;
        }

        private void MenuCalenda_Click(object sender, EventArgs e)
        {
            string title = (sender as Guna2GradientButton)?.Text ?? "Lịch làm việc";
            UpdateMainTitleAndClearMenuLabels(title);

            if (_calenda == null)
            {
                _calenda = new Calenda(_serviceHub, _teacherId)
                {
                    Dock = DockStyle.Fill
                };
            }
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _calenda)
                return;

            pnMain.Visible = false;
            pnMain.SuspendLayout();
            for (int i = pnMain.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = pnMain.Controls[i];
                if (ctrl == _classList || ctrl == _calenda || ctrl == _profile)
                    pnMain.Controls.Remove(ctrl);
                else
                    ctrl.Dispose();
            }
            pnMain.Controls.Clear();
            
            pnMain.Controls.Add(_calenda);
            pnMain.ResumeLayout(false);
            pnMain.Visible = true;
        }

        private void pnProfileTeacher_Click(object sender, EventArgs e)
        {
            UpdateMainTitleAndClearMenuLabels("Hồ sơ cá nhân");

            if (_profile == null)
            {
                _profile = new MyProfile(_teacherId, _serviceHub) { Dock = DockStyle.Fill };
            }
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _profile)
                return;

            pnMain.Visible = false;
            pnMain.SuspendLayout();
            for (int i = pnMain.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = pnMain.Controls[i];
                if (ctrl == _classList || ctrl == _calenda || ctrl == _profile)
                    pnMain.Controls.Remove(ctrl);
                else
                    ctrl.Dispose();
            }
            pnMain.Controls.Clear();
            
            pnMain.AutoScroll = true;
            pnMain.Controls.Add(_profile);
            pnMain.ResumeLayout(false);
            pnMain.Visible = true;
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
        private async void ptbxToggleMode_Click(object sender, EventArgs e)
        {
            await Task.Delay(100);

            SuspendDrawing();
            this.SuspendLayout();

            try
            {
                isDarkMode = !isDarkMode;
                if (isDarkMode) 
                {
                    ApplyDarkMode();
                    _classList?.ApplyThemeToAllItems(true);
                }
                else 
                {
                    ApplyLightMode();
                    _classList?.ApplyThemeToAllItems(false);
                }

                await Task.Yield();
            }
            finally
            {
                this.ResumeLayout(true);
                ResumeDrawing();
                pnMain.Visible = true;
                pnMain.Refresh();
            }
        }

        private async void btnStoredClass_Click(object sender, EventArgs e)
        {
            UpdateMainTitleAndClearMenuLabels("Lớp học lưu trữ");
            pnMain.Visible = false;
            pnMain.SuspendLayout();
            for (int i = pnMain.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = pnMain.Controls[i];
                if (ctrl == _classList || ctrl == _calenda || ctrl == _profile)
                    pnMain.Controls.Remove(ctrl);
                else
                    ctrl.Dispose();
            }
            pnMain.Controls.Clear();

            _classList = new ClassList(_teacherId, _serviceHub)
            {
                Dock = DockStyle.Fill
            };
            _classList.OnOpenClassDetail += OpenClassDetail;

            pnMain.Controls.Add(_classList);
            pnMain.ResumeLayout(false);
            
            await _classList.LoadClassesAsync();
            pnMain.Visible = true;
        }
    }
}