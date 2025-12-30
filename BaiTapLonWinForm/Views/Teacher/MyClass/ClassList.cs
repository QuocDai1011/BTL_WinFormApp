using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using Guna.UI2.WinForms;
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

        public event Action<long>? OnOpenClassDetail;

        // Cache ClassItem + Card
        private readonly Dictionary<long, (ClassItem item, Guna2CustomGradientPanel card)>
            _cachedClassItems = new();

        // PRE-LOADED DATA CACHE - Load một lần, dùng nhiều lần
        private Dictionary<long, Course> _allCourses = new();
        private Dictionary<long, List<string>> _allSchoolDays = new();
        private User _currentTeacher;
        private bool _dataPreloaded = false;

        private const int COLUMNS = 4;
        private const int BATCH_SIZE = 4; // Render 4 items mỗi batch (1 row)
        private int _currentPage = 0;
        private List<Class> _allClasses = new List<Class>();
        private bool _isLoadingMore = false;

        // Scrolling detection to suppress hover changes during scroll
        private bool _isScrolling = false;
        private readonly WinFormsTimer _scrollTimer;

        // ✅ Freeze layout khi scroll để tránh re-render
        private bool _layoutFrozen = false;

        // Track last loaded class IDs để tránh reload không cần thiết
        private HashSet<long> _lastLoadedClassIds = new HashSet<long>();

        // Search functionality
        private readonly WinFormsTimer _searchTimer;
        private string _currentSearchKeyword = string.Empty;

        public ClassList(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _serviceHub = serviceHub;

            // Double buffer cho UserControl
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();

            EnableDoubleBuffering(tfpClassList);
            EnableDoubleBuffering(flowMain);
            EnableDoubleBuffering(panel1);

            // Scroll detection timer (debounce)
            _scrollTimer = new WinFormsTimer { Interval = 150 };
            _scrollTimer.Tick += (s, e) =>
            {
                _isScrolling = false;
                _scrollTimer.Stop();
                
                // ✅ Unfreeze layout sau khi scroll xong
                if (_layoutFrozen)
                {
                    _layoutFrozen = false;
                    tfpClassList.ResumeLayout(false);
                    tfpClassList.PerformLayout();
                }
            };

            // Search timer (debounce)
            _searchTimer = new WinFormsTimer { Interval = 300 };
            _searchTimer.Tick += SearchTimer_Tick;

            // TableLayoutPanel Scroll event - Virtual scrolling
            flowMain.AutoScroll = true;
            flowMain.Scroll += FlowMain_Scroll;

            // Search textbox event
            guna2TextBox1.TextChanged += SearchTextBox_TextChanged;

            // Configure TableLayoutPanel for auto-sizing
            tfpClassList.AutoSize = true;
            tfpClassList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tfpClassList.Dock = DockStyle.Top;
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
            _currentSearchKeyword = guna2TextBox1.Text.Trim().ToLower();
            
            // Reset and reload with search filter (data đã preload rồi, chỉ filter local)
            _currentPage = 0;
            tfpClassList.SuspendLayout();
            tfpClassList.Controls.Clear();
            tfpClassList.RowCount = 0;
            tfpClassList.RowStyles.Clear();
            tfpClassList.ResumeLayout(false);
            
            _ = LoadNextPageAsync();
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

        // Backward-compatible synchronous wrapper (fire-and-forget)
        public void LoadClasses()
        {
            _ = LoadClassesAsync();
        }

        // Async: PRE-LOAD TẤT CẢ DATA một lần
        public async Task LoadClassesAsync()
        {
            // Show loading state
            guna2TextBox1.PlaceholderText = "Đang tải dữ liệu...";
            guna2TextBox1.Enabled = false;

            try
            {
                // Step 1: Fetch classes
                var classes = await Task.Run(() =>
                {
                    var c = _serviceHub.ClassService.GetAllClass(_teacherId);
                    return _serviceHub.ClassService.UpdateClassesStatusList(c);
                });

                var newClassIds = new HashSet<long>(classes.Select(c => (long)c.ClassId));

                // If no change in class ids and we already have controls, do a light update
                if (_lastLoadedClassIds.SetEquals(newClassIds) && tfpClassList.Controls.Count > 0 && _dataPreloaded)
                {
                    await UpdateExistingItemsAsync(classes);
                    return;
                }

                _lastLoadedClassIds = newClassIds;
                _allClasses = classes;
                _currentPage = 0;

                // Step 2: PRE-LOAD TẤT CẢ related data MỘT LẦN (bulk fetch)
                if (!_dataPreloaded || _allCourses.Count == 0)
                {
                    guna2TextBox1.PlaceholderText = $"Đang tải {classes.Count} lớp học...";
                    await PreloadAllDataAsync(classes);
                }

                // Step 3: Clear và render batch đầu tiên
                guna2TextBox1.PlaceholderText = "Đang render...";
                tfpClassList.SuspendLayout();
                tfpClassList.Controls.Clear();
                tfpClassList.RowCount = 0;
                tfpClassList.RowStyles.Clear();
                tfpClassList.ResumeLayout(false);

                await LoadNextPageAsync();
            }
            finally
            {
                // Reset loading state
                guna2TextBox1.PlaceholderText = "Lớp học cần tìm kiếm...";
                guna2TextBox1.Enabled = true;
            }
        }

        // PRE-LOAD TẤT CẢ courses và school days MỘT LẦN
        private async Task PreloadAllDataAsync(List<Class> classes)
        {
            await Task.Run(() =>
            {
                // Get current teacher một lần
                _currentTeacher = _serviceHub.UserService.GetUserByTeacherId(_teacherId);

                // Bulk load tất cả courses và school days
                _allCourses.Clear();
                _allSchoolDays.Clear();

                foreach (var cls in classes)
                {
                    // Cache course
                    if (!_allCourses.ContainsKey(cls.ClassId))
                    {
                        var course = _serviceHub.CourseService.GetCourseByClassId(cls.ClassId);
                        if (course != null)
                            _allCourses[cls.ClassId] = course;
                    }

                    // Cache school days
                    if (!_allSchoolDays.ContainsKey(cls.ClassId))
                    {
                        var days = _serviceHub.SchoolDayService.GetListSchoolDaysByClassId(cls.ClassId);
                        _allSchoolDays[cls.ClassId] = days ?? new List<string>();
                    }
                }

                _dataPreloaded = true;
            });
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

        // Method mới: Chỉ update data cho items đã tồn tại
        private async Task UpdateExistingItemsAsync(List<Class> classes)
        {
            // Data đã preload rồi, chỉ update UI
            await Task.Run(() =>
            {
                foreach (var cls in classes)
                {
                    if (_cachedClassItems.TryGetValue(cls.ClassId, out var cached))
                    {
                        if (_allCourses.TryGetValue(cls.ClassId, out var course) &&
                            _allSchoolDays.TryGetValue(cls.ClassId, out var days))
                        {
                            // Update on UI thread
                            this.InvokeIfRequired(() =>
                            {
                                cached.item.SetData(cls, course, _currentTeacher, days);
                            });
                        }
                    }
                }
            });
        }

        // Virtual scrolling - Load next page với BATCH RENDERING
        private async Task LoadNextPageAsync()
        {
            if (_isLoadingMore) return;

            // Apply search filter
            var filteredClasses = FilterClasses(_allClasses);
            
            int startIdx = _currentPage * BATCH_SIZE * 3; // 3 rows mỗi page
            if (startIdx >= filteredClasses.Count) return; // No more items

            _isLoadingMore = true;

            var pageClasses = filteredClasses
                .Skip(startIdx)
                .Take(BATCH_SIZE * 3) // Load 12 items (3 rows)
                .ToList();

            // ✅ CHỈ RENDER items mới nếu chưa có trong TableLayoutPanel
            var existingClassIds = _cachedClassItems.Keys.ToHashSet();
            var newClasses = pageClasses.Where(c => 
                !tfpClassList.Controls.Cast<Control>()
                    .Any(ctrl => ctrl is Guna2CustomGradientPanel card && 
                         _cachedClassItems.Any(kvp => kvp.Value.card == card && kvp.Key == c.ClassId))
            ).ToList();

            if (newClasses.Count > 0)
            {
                // Render từng batch nhỏ (4 items = 1 row mỗi lần)
                await RenderBatchesAsync(newClasses);
            }

            _currentPage++;
            _isLoadingMore = false;
        }

        // RENDER THEO BATCH: 4 items mỗi lần, suspend/resume giữa mỗi batch
        private async Task RenderBatchesAsync(List<Class> classes)
        {
            int batchCount = (int)Math.Ceiling(classes.Count / (double)BATCH_SIZE);
            
            // ✅ Tính row bắt đầu dựa trên số controls hiện có
            int startRow = tfpClassList.RowCount;

            for (int batchIdx = 0; batchIdx < batchCount; batchIdx++)
            {
                var batch = classes
                    .Skip(batchIdx * BATCH_SIZE)
                    .Take(BATCH_SIZE)
                    .ToList();

                // ✅ Chỉ suspend nếu chưa frozen
                bool needSuspend = !_layoutFrozen;
                if (needSuspend)
                {
                    tfpClassList.SuspendLayout();
                }

                // Add row cho batch này
                int currentRow = startRow + batchIdx;
                
                // ✅ Chỉ add row nếu chưa có đủ
                if (tfpClassList.RowCount <= currentRow)
                {
                    tfpClassList.RowCount = currentRow + 1;
                    tfpClassList.RowStyles.Add(new RowStyle(SizeType.Absolute, 287F));
                }

                // Render batch items
                for (int i = 0; i < batch.Count; i++)
                {
                    var cls = batch[i];
                    
                    // ✅ Skip nếu item đã được render
                    int col = i % COLUMNS;
                    if (tfpClassList.GetControlFromPosition(col, currentRow) != null)
                        continue;
                    
                    // Lấy data từ cache (đã preload)
                    if (!_allCourses.TryGetValue(cls.ClassId, out var course)) continue;
                    if (!_allSchoolDays.TryGetValue(cls.ClassId, out var days)) continue;

                    var (_, card) = GetOrCreateClassItem(cls, course, _currentTeacher, days);
                    card.Margin = new Padding(0, 0, 20, 20);

                    // ✅ Set Visible = false trước khi add để tránh flash
                    card.Visible = false;
                    tfpClassList.Controls.Add(card, col, currentRow);
                    
                    // ✅ Set Visible = true sau khi add
                    card.Visible = true;
                }

                // ✅ Chỉ resume nếu đã suspend
                if (needSuspend)
                {
                    tfpClassList.ResumeLayout(false);
                    
                    // ✅ Chỉ perform layout nếu là batch cuối cùng VÀ không đang scroll
                    if (batchIdx == batchCount - 1 && !_isScrolling)
                    {
                        tfpClassList.PerformLayout();
                    }
                }

                // Cho UI thread nghỉ giữa các batch để tránh freeze
                await Task.Delay(1);
            }
        }
        #endregion

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
            uc.OnOpenDetail += id => OnOpenClassDetail?.Invoke(id);

            return uc;
        }

        private Guna2CustomGradientPanel CreateCard(ClassItem uc)
        {
            var card = new Guna2CustomGradientPanel
            {
                Width = 338,
                Height = 267,
                Padding = new Padding(1),
                Margin = new Padding(0, 0, 20, 20),

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

            // Put uc inside card
            card.Controls.Add(uc);

            // Attach hover to the card (reduces noisy events from inner children)
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
                // Update data if changed (có dirty checking trong SetData)
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
            if (_isScrolling) return; // ignore hover while scrolling

            if (sender is Guna2CustomGradientPanel card)
            {
                // Update visual WITHOUT SuspendLayout (tránh flicker)
                // Chỉ thay đổi visual properties, không thay đổi layout
                card.BorderColor = Color.FromArgb(94, 148, 255);
                card.BorderThickness = 2;
                card.ShadowDecoration.Depth = 8;
                card.ShadowDecoration.Color = Color.FromArgb(90, Color.Black);
            }
        }

        private void Card_MouseLeave(object? sender, EventArgs e)
        {
            if (_isScrolling) return; // ignore hover while scrolling

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
            // Mark as scrolling and debounce
            _isScrolling = true;
            _scrollTimer.Stop();
            _scrollTimer.Start();

            // ✅ Freeze layout ngay lập tức để controls không bị re-render
            if (!_layoutFrozen)
            {
                _layoutFrozen = true;
                tfpClassList.SuspendLayout();
            }

            // Virtual scrolling: Load more when near bottom
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                var maxScroll = flowMain.VerticalScroll.Maximum - flowMain.ClientSize.Height;
                var currentScroll = flowMain.VerticalScroll.Value;

                // Load more when 80% scrolled
                if (currentScroll >= maxScroll * 0.8 && !_isLoadingMore)
                {
                    _ = LoadNextPageAsync();
                }
            }
        }
        #endregion

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

    // Helper extension for thread-safe UI updates
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

