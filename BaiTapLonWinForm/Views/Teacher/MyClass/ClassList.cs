using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using Guna.UI2.WinForms;
using Nest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTimer = System.Windows.Forms.Timer;

namespace BaiTapLonWinForm.Views.Teacher.Controls
{
    public partial class ClassList : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _teacherId;

        public event Action<int>? OnOpenClassDetail;

        private readonly Dictionary<long, (ClassItem item, Guna2CustomGradientPanel card)>
            _cachedClassItems = new();
        private Dictionary<long, Course> _allCourses = new();
        private Dictionary<long, List<string>> _allSchoolDays = new();
        private User _currentTeacher;
        private bool _dataPreloaded = false;
        private const int COLUMNS = 4;
        private const int BATCH_SIZE = 4;
        private int _currentPage = 0;
        private List<Class> _allClasses = new List<Class>();
        private bool _isLoadingMore = false;
        private bool _isScrolling = false;
        private readonly WinFormsTimer _scrollTimer;
        private bool _layoutFrozen = false;
        private HashSet<long> _lastLoadedClassIds = new HashSet<long>();
        private readonly WinFormsTimer _searchTimer;
        private string _currentSearchKeyword = string.Empty;

        // Layout constants
        private const float CARD_HEIGHT = 267F;
        private const float VERTICAL_GAP = 20F;

        public ClassList(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _serviceHub = serviceHub;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();

            EnableDoubleBuffering(tfpClassList);
            EnableDoubleBuffering(flowMain);
            EnableDoubleBuffering(panel1);
            _scrollTimer = new WinFormsTimer { Interval = 150 };
            _scrollTimer.Tick += (s, e) =>
            {
                _isScrolling = false;
                _scrollTimer.Stop();
                if (_layoutFrozen)
                {
                    _layoutFrozen = false;
                    tfpClassList.ResumeLayout(false);
                    tfpClassList.PerformLayout();
                }
            };
            _searchTimer = new WinFormsTimer { Interval = 300 };
            _searchTimer.Tick += SearchTimer_Tick;
            flowMain.AutoScroll = true;
            flowMain.Scroll += FlowMain_Scroll;
            txbSearchClass.TextChanged += SearchTextBox_TextChanged;

            tfpClassList.AutoSize = true;
            tfpClassList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tfpClassList.Dock = DockStyle.Top;
            this.DoubleBuffered = true;
            typeof(TableLayoutPanel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(tfpClassList, true, null);
            LoadFilteredClasses();
        }
        public void LoadFilteredClasses()
        {
            LoadCbxCourseName();
            LoadCbxActive();
            LoadCbxDayOfWeek();
            LoadDtpkFilter();
        }
        private async void LoadCbxCourseName()
        {
            var courses = await _serviceHub.CourseService.GetAllCoursesAsync();
            cbxCourseName.Items.Clear();
            cbxCourseName.Items.Add("Tất cả khóa học");
            foreach (var course in courses.Data)
            {
                cbxCourseName.Items.Add(course.CourseName);
            }
            cbxCourseName.SelectedIndex = 0;
        }
        private void LoadCbxActive()
        {
            //cbxActive.Items.Clear();
            //cbxActive.Items.Add("All");
            //cbxActive.Items.Add("Active");
            //cbxActive.Items.Add("Expired");
            //cbxActive.SelectedIndex = 0;
        }
        private void LoadCbxDayOfWeek()
        {
            //cbxDayOfWeek.Items.Clear();
            //cbxDayOfWeek.Items.Add("All");
            //cbxDayOfWeek.Items.Add("Monday");
            //cbxDayOfWeek.Items.Add("Tuesday");
            //cbxDayOfWeek.Items.Add("Wednesday");
            //cbxDayOfWeek.Items.Add("Thursday");
            //cbxDayOfWeek.Items.Add("Friday");
            //cbxDayOfWeek.Items.Add("Saturday");
            //cbxDayOfWeek.Items.Add("Sunday");
            //cbxDayOfWeek.SelectedIndex = 0;
        }
        private void LoadDtpkFilter()
        {
            dtpkFilter.Value = DateTime.Now;
        }
        #region Double Buffer Helper
        private void EnableDoubleBuffering(Control control)
        {
            if (control == null) return;

            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        #endregion

        #region Search
        private void SearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            string newKeyword = txbSearchClass.Text.Trim().ToLower();
            if (_currentSearchKeyword != newKeyword)
            {
                _currentSearchKeyword = newKeyword;
                _currentPage = 0;
                _isLoadingMore = false;
                _ = LoadClassesAsync(false);
            }
        }

        private List<Class> FilterClasses(List<Class> classes)
        {
            if (string.IsNullOrWhiteSpace(_currentSearchKeyword))
                return classes;

            return classes.Where(c => 
                c.ClassName.ToLower().Contains(_currentSearchKeyword) ||
                c.Note?.ToLower().Contains(_currentSearchKeyword) == true
            ).ToList();
        }
        #endregion

        #region Public API
        public void LoadClasses()
        {
            _ = LoadClassesAsync(false);
        }
        public async Task LoadClassesAsync(bool showExpired)
        {
            tfpClassList.Visible = false;
            tfpClassList.SuspendLayout();

            try
            {
                var today = DateOnly.FromDateTime(DateTime.Now);

                // ❌ BỎ Task.Run - gọi trực tiếp
                var classes = await _serviceHub.ClassService.GetAllClassAsync(_teacherId);
                classes = _serviceHub.ClassService.UpdateClassesStatusList(classes);

                _allClasses = showExpired
                    ? classes.Where(x => x.EndDate < today).ToList()
                    : classes.Where(x => x.EndDate >= today).ToList();

                _currentPage = 0;
                _isLoadingMore = false;

                await PreloadAllDataAsync(_allClasses);

                tfpClassList.Controls.Clear();
                _cachedClassItems.Clear();

                RenderAllAtOnce(_allClasses);
            }
            finally
            {
                tfpClassList.ResumeLayout(true);
                tfpClassList.Visible = true;
            }
        }



        public void ApplyThemeToAllItems(bool isDarkMode)
        {
            if(isDarkMode == true)  this.BackColor = Color.Black;
            else this.BackColor = Color.White;
            foreach (var cached in _cachedClassItems.Values)
            {
                cached.item.ApplyTheme(isDarkMode);
            }
        }

        private async Task PreloadAllDataAsync(List<Class> classes)
        {
            //await Task.Run(() =>
            //{
            //    _currentTeacher = _serviceHub.UserService.GetUserByTeacherId(_teacherId);

            //    _allCourses.Clear();
            //    _allSchoolDays.Clear();

            //    foreach (var cls in classes)
            //    {
            //        if (!_allCourses.ContainsKey(cls.ClassId))
            //        {
            //            var course = _serviceHub.CourseService.GetCourseByClassId(cls.ClassId);
            //            if (course != null)
            //                _allCourses[cls.ClassId] = course;
            //        }

            //        if (!_allSchoolDays.ContainsKey(cls.ClassId))
            //        {
            //            var days = _serviceHub.SchoolDayService.GetListSchoolDaysByClassId(cls.ClassId);
            //            _allSchoolDays[cls.ClassId] = days ?? new List<string>();
            //        }
            //    }

            //    _dataPreloaded = true;
            //});
            _currentTeacher = _serviceHub.UserService.GetUserByTeacherId(_teacherId);

            _allCourses.Clear();
            _allSchoolDays.Clear();

            // ❌ BỎ Task.Run() - đây là nguyên nhân threading issue
            foreach (var cls in classes)
            {
                if (!_allCourses.ContainsKey(cls.ClassId))
                {
                    var course = _serviceHub.CourseService.GetCourseByClassId(cls.ClassId);
                    if (course != null)
                        _allCourses[cls.ClassId] = course;
                }

                if (!_allSchoolDays.ContainsKey(cls.ClassId))
                {
                    var days = _serviceHub.SchoolDayService.GetListSchoolDaysByClassId(cls.ClassId);
                    _allSchoolDays[cls.ClassId] = days ?? new List<string>();
                }
            }

            _dataPreloaded = true;
            await Task.CompletedTask; // Giữ method signature là async
        }

        public void ClearCache()
        {
            foreach (var c in _cachedClassItems.Values)
            {
                c.item.Dispose();
                c.card.Dispose();
            }
            _cachedClassItems.Clear();
            _lastLoadedClassIds.Clear();
            _allClasses.Clear();
            _allCourses.Clear();
            _allSchoolDays.Clear();
            _dataPreloaded = false;
        }

        private async Task UpdateExistingItemsAsync(List<Class> classes)
        {
            await Task.Run(() =>
            {
                foreach (var cls in classes)
                {
                    if (_cachedClassItems.TryGetValue(cls.ClassId, out var cached))
                    {
                        if (_allCourses.TryGetValue(cls.ClassId, out var course) &&
                            _allSchoolDays.TryGetValue(cls.ClassId, out var days))
                        {
                            this.InvokeIfRequired(() =>
                            {
                                cached.item.SetData(cls, course, _currentTeacher, days);
                            });
                        }
                    }
                }
            });
        }

        private async Task LoadNextPageAsync()
        {
            if (_isLoadingMore) return;
            var filteredClasses = FilterClasses(_allClasses);

            int startIdx = _currentPage * BATCH_SIZE * 3; 
            if (startIdx >= filteredClasses.Count) return; 

            _isLoadingMore = true;

            var pageClasses = filteredClasses
                .Skip(startIdx)
                .Take(BATCH_SIZE * 3) 
                .ToList();
            var existingClassIds = _cachedClassItems.Keys.ToHashSet();
            var newClasses = pageClasses.Where(c => 
                !tfpClassList.Controls.Cast<Control>()
                    .Any(ctrl => ctrl is Guna2CustomGradientPanel card && 
                         _cachedClassItems.Any(kvp => kvp.Value.card == card && kvp.Key == c.ClassId))
            ).ToList();

            if (newClasses.Count > 0)
            {
                await RenderBatchesAsync(newClasses);
            }

            _currentPage++;
            _isLoadingMore = false;
        }

        private void RenderAllAtOnce(List<Class> classes)
        {
            int totalItems = classes.Count;
            int rowsNeeded = (int)Math.Ceiling(totalItems / (double)COLUMNS);

            tfpClassList.RowCount = rowsNeeded;

            float rowHeight = CARD_HEIGHT + VERTICAL_GAP;

            for (int row = 0; row < rowsNeeded; row++)
            {
                if (tfpClassList.RowStyles.Count <= row)
                    tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
            }

            for (int i = 0; i < totalItems; i++)
            {
                var cls = classes[i];
                int row = i / COLUMNS;
                int col = i % COLUMNS;

                if (_allCourses.TryGetValue(cls.ClassId, out var course) &&
                    _allSchoolDays.TryGetValue(cls.ClassId, out var days))
                {
                    var (_, card) = GetOrCreateClassItem(cls, course, _currentTeacher, days);

                    card.Margin = new Padding(card.Margin.Left, card.Margin.Top, card.Margin.Right, (int)VERTICAL_GAP);

                    card.Visible = false;
                    tfpClassList.Controls.Add(card, col, row);
                }
            }

            foreach (Control ctrl in tfpClassList.Controls)
            {
                ctrl.Visible = true;
            }
        }
        private async Task RenderBatchesAsync(List<Class> classes)
        {
            int batchCount = (int)Math.Ceiling(classes.Count / (double)BATCH_SIZE);

            int startRow = tfpClassList.RowCount;

            float rowHeight = CARD_HEIGHT + VERTICAL_GAP;

            for (int batchIdx = 0; batchIdx < batchCount; batchIdx++)
            {
                var batch = classes
                    .Skip(batchIdx * BATCH_SIZE)
                    .Take(BATCH_SIZE)
                    .ToList();

                bool needSuspend = !_layoutFrozen;
                if (needSuspend)
                {
                    tfpClassList.SuspendLayout();
                }

                int currentRow = startRow + batchIdx;

                if (tfpClassList.RowCount <= currentRow)
                {
                    tfpClassList.RowCount = currentRow + 1;
                    tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                }

                for (int i = 0; i < batch.Count; i++)
                {
                    var cls = batch[i];
                    int col = i % COLUMNS;
                    if (tfpClassList.GetControlFromPosition(col, currentRow) != null)
                        continue;
                    if (!_allCourses.TryGetValue(cls.ClassId, out var course)) continue;
                    if (!_allSchoolDays.TryGetValue(cls.ClassId, out var days)) continue;

                    var (_, card) = GetOrCreateClassItem(cls, course, _currentTeacher, days);
                    card.Margin = new Padding(0, 0, 20, (int)VERTICAL_GAP);
                    card.Visible = false;
                    tfpClassList.Controls.Add(card, col, currentRow);

                    card.Visible = true;
                }

                if (needSuspend)
                {
                    tfpClassList.ResumeLayout(false);

                    if (batchIdx == batchCount - 1 && !_isScrolling)
                    {
                        tfpClassList.PerformLayout();
                    }
                }
                await Task.Delay(1);
            }
        }
        #endregion

        private async Task loadCombobox()
        {
            var courses = await _serviceHub.CourseService.GetAllCoursesAsync();
            
            var result = courses.Data.Select(c => c.CourseName).ToList();

            cbxCourseName.SelectedItem = result;
        }

        private List<Class> filter()
        {
            string courseNames = cbxCourseName.SelectedItem.ToString() ?? "";
            var result = _allClasses.Where( c => c.Equals(courseNames)).ToList();  
            return result;

        }

        #region Create UI
        private ClassItem CreateClassItem(
            Class classData,
            Course courseData,
            User currentUser,
            List<string> daysOfWeek)
        {
            var uc = new ClassItem(classData.ClassId);
            uc.Dock = DockStyle.Fill;

            uc.SetData(classData, courseData, currentUser, daysOfWeek);
            uc.OnOpenDetail += id => OnOpenClassDetail?.Invoke((int)id);

            return uc;
        }

        private Guna2CustomGradientPanel CreateCard(ClassItem uc)
        {
            var card = new Guna2CustomGradientPanel
            {
                Width = 338,
                Height = (int)CARD_HEIGHT,
                Padding = new Padding(1),
                Margin = new Padding(1, 1, 20, (int)VERTICAL_GAP),

                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(224, 224, 224),

                FillColor = Color.FromArgb(200, 255, 255, 255),
                FillColor2 = Color.FromArgb(200, 255, 255, 255),
                FillColor3 = Color.FromArgb(200, 255, 255, 255),
                FillColor4 = Color.FromArgb(200, 255, 255, 255),

                ShadowDecoration =
                {
                    Enabled = true,
                    Depth = 0,
                    Color = Color.FromArgb(0, Color.Black),
                    BorderRadius = 12,
                    Shadow = new Padding(4, 4, 8, 8)
                }
            };

            EnableDoubleBuffering(card);

            card.Controls.Add(uc);
            card.MouseEnter += Card_MouseEnter;
            card.MouseLeave += Card_MouseLeave;

            return card;
        }

        private (ClassItem, Guna2CustomGradientPanel) GetOrCreateClassItem(
            Class classData,
            Course courseData,
            User currentUser,
            List<string> daysOfWeek)
        {
            if (_cachedClassItems.TryGetValue(classData.ClassId, out var cached))
            {
                cached.item.SetData(classData, courseData, currentUser, daysOfWeek);
                return cached;
            }

            var uc = CreateClassItem(classData, courseData, currentUser, daysOfWeek);
            var card = CreateCard(uc);

            _cachedClassItems[classData.ClassId] = (uc, card);
            return (uc, card);
        }
        #endregion

        #region Hover Effect (KHÔNG GÂY LAYOUT)
        private void Card_MouseEnter(object? sender, EventArgs e)
        {
            if (_isScrolling) return;
            if (sender is Guna2CustomGradientPanel card)
            {
                card.BorderColor = Color.FromArgb(94, 148, 255);
                card.BorderThickness = 2;
                card.ShadowDecoration.Depth = 8;
                card.ShadowDecoration.Color = Color.FromArgb(90, Color.Black);
            }
        }

        private void Card_MouseLeave(object? sender, EventArgs e)
        {
            if (_isScrolling) return;

            if (sender is Guna2CustomGradientPanel card)
            {
                card.BorderColor = Color.FromArgb(224, 224, 224);
                card.BorderThickness = 1;
                card.ShadowDecoration.Depth = 0;
                card.ShadowDecoration.Color = Color.FromArgb(0, Color.Black);
            }
        }
        #endregion

        #region Scroll Handling
        private void FlowMain_Scroll(object? sender, ScrollEventArgs e)
        {
            _isScrolling = true;
            _scrollTimer.Stop();
            _scrollTimer.Start();

            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                var currentScroll = flowMain.VerticalScroll.Value;
                var maxScroll = flowMain.VerticalScroll.Maximum;

                if (currentScroll > maxScroll * 0.5 && !_isLoadingMore)
                {
                    _ = LoadNextPageAsync();
                }
            }
        }
        #endregion
        private void txbSearchClass_TextChanged(object? sender, EventArgs e)
        {
            SearchTextBox_TextChanged(sender, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _scrollTimer?.Dispose();
                _searchTimer?.Dispose();
                ClearCache();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}

