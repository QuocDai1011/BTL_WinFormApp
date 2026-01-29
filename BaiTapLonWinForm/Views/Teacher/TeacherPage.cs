using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Teacher.Controls;
using BaiTapLonWinForm.Views.Teacher.ListToDo;
using BaiTapLonWinForm.Views.Teacher.MyCalenda;
using BaiTapLonWinForm.Views.Teacher.MyClass;
using BaiTapLonWinForm.Views.Teacher.MyClass.MyExercise;
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
        private UserControl _currentPage;
        //private UserControl _previousPage;
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
            isInitialized = true;
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            MenuClass_Click(null, null);
        }
        private void LoadPage(UserControl page)
        {
            pnMain.Controls.Clear();   // 🔥 dọn sạch
            _currentPage = page;

            page.Dock = DockStyle.Fill;
            pnMain.Controls.Add(page);
        }

        #region Class List Management

        public void RefreshClassList()
        {
            _classList?.LoadClassesAsync(false);
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

        private void OpenClassDetail(int classId)
        {
            var cls = _serviceHub.ClassService.GetClassById(classId);
            string className = cls?.ClassName ?? "Lớp học";

            var target = this.Controls.Find("pnMainMenuTitle", true)
                          .FirstOrDefault() as FlowLayoutPanel;

            if (target != null)
            {
                var oldLabels = target.Controls
                    .OfType<Guna2HtmlLabel>()
                    .Where(c => c.Text.StartsWith("/ "))
                    .ToList();

                foreach (var old in oldLabels)
                {
                    target.Controls.Remove(old);
                    old.Dispose();
                }

                target.Controls.Add(new Guna2HtmlLabel
                {
                    Text = $"/ {className}",
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                    ForeColor = isDarkMode ? Color.FromArgb(72, 181, 183) : Color.Teal,
                    BackColor = Color.Transparent,
                    AutoSize = false,
                    Size = new Size(500, 34),
                    Margin = new Padding(8, 6, 8, 6)
                });
            }

            var classDetail = new ClassDetail((int)classId, _serviceHub)
            {
                Dock = DockStyle.Fill
            };
            classDetail.OnEditExercise += OpenEditExercise;
            classDetail.OnAddExercise += OpenAddExercise;
            classDetail.OnOpenScoreDetail += OpenScoreDetail;

            LoadPage(classDetail);
        }

        private void OpenEditExercise(Assignment assignment)
        {
            var lastPage = _currentPage;
            var addExercise = new AddExercise(
                _serviceHub,
                assignment.ClassId,
                _teacherId
            );

            addExercise.LoadAssignmentForEdit(assignment);

            addExercise.OnBack += () =>
            {
                LoadPage(lastPage); // quay lại danh sách
            };

            LoadPage(addExercise);
        }

        private void OpenAddExercise(int classId)
        {
            var lastPage = _currentPage; // để quay lại

            var addExercise = new AddExercise(_serviceHub, classId, _teacherId);
            addExercise.OnBack += () =>
            {
                LoadPage(lastPage);
            };

            LoadPage(addExercise);
        }

        #endregion
        private void OpenScoreDetail(string assignmentId)
        {
            var lastPage = _currentPage; // 👈 chụp lại

            var scoreDetail = new ScoreDetail(_serviceHub, assignmentId);
            scoreDetail.OnBack += () =>
            {
                LoadPage(lastPage);
            };

            LoadPage(scoreDetail);
        }
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
                if (isDarkMode)
                {
                    _classList.ApplyThemeToAllItems(true);
                }
            }
            if (pnMain.Controls.Count > 0 && pnMain.Controls[0] == _classList)
            {
                await _classList.LoadClassesAsync(false);
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
            _currentPage = null;
            //_previousPage = null;

            pnMain.Controls.Add(_classList);
            pnMain.ResumeLayout(false);

            pnMain.Visible = true;

            await _classList.LoadClassesAsync(false);
        }

        private void MenuCalenda_Click(object sender, EventArgs e)
        {
            string title = (sender as Guna2GradientButton)?.Text ?? "Lịch làm việc";
            UpdateMainTitleAndClearMenuLabels(title);

            if (_calenda == null)
            {
                _calenda = new Calenda(_serviceHub, _teacherId, isDarkMode)
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
            _currentPage = null;
            //_previousPage = null;

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
                // Chưa tạo darkmode cho profile, nào có thì mở
                // if (isDarkMode) _profile.ApplyTheme(true);
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
            _currentPage = null;
            //_previousPage = null;

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
                    if (_calenda != null) _calenda.ApplyThemeToAllItems(true);
                }
                else
                {
                    ApplyLightMode();
                    _classList?.ApplyThemeToAllItems(false);
                    if (_calenda != null) _calenda.ApplyThemeToAllItems(false);
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
            if (isDarkMode)
            {
                _classList.ApplyThemeToAllItems(true);
            }
            pnMain.Controls.Add(_classList);
            pnMain.ResumeLayout(false);
            pnMain.Visible = true;
            await _classList.LoadClassesAsync(true);
        }
        private async void btnMyScore_Click(object sender, EventArgs e)
        {
            UpdateMainTitleAndClearMenuLabels("Việc cần làm");
            //Lấy thông tin teacher hiện tại
            var currentTeacher = await _serviceHub.TeacherService.GetTeacherByIdAsync(_teacherId);
            var toDoView = new ToDoDetail(_serviceHub, currentTeacher.Data.UserId)
            {
                Dock = DockStyle.Fill
            };

            toDoView.OnOpenScoreDetail += (assignmentId) =>
            {
                LoadPage(new ScoreDetail(_serviceHub, assignmentId));
            };
            toDoView.OnEditExercise += (assignment) =>
            {
                OpenEditExercise(assignment); // dùng lại logic có sẵn
            };
            LoadPage(toDoView);
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            pnProfileTeacher_Click(sender, e);
        }
    }
}