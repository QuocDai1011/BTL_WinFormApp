using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    /// <summary>
    /// ClassMember - Hiển thị danh sách members với search local và control caching
    /// </summary>
    public partial class ClassMember : UserControl
    {
        private readonly int _classId;
        private readonly ServiceHub _serviceHub;
        
        // Data cache
        private List<User> _allStudents = new List<User>();
        private User _teacher;
        
        // Control cache
        private readonly Dictionary<long, MemberItem> _memberItemCache = new Dictionary<long, MemberItem>();
        
        // Search
        private System.Windows.Forms.Timer _searchDebounce;
        private bool _isLoading = false;

        public ClassMember(int classId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _classId = classId;
            _serviceHub = serviceHub;
            
            // Enable double buffering
            EnableDoubleBuffering(flpnClassStudentMenber);
            EnableDoubleBuffering(flpnClassTeacherMenber);
            EnableDoubleBuffering(this);
            
            InitializeSearchTimer();
        }

        private void EnableDoubleBuffering(Control control)
        {
            if (control == null) return;

            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void InitializeSearchTimer()
        {
            _searchDebounce = new System.Windows.Forms.Timer { Interval = 300 };
            _searchDebounce.Tick += OnSearchDebounce;
        }

        #region Load Data
        private void ClassMember_Load(object sender, EventArgs e)
        {
            _ = LoadClassMembersAsync();
        }

        private async Task LoadClassMembersAsync()
        {
            if (_isLoading) return;
            _isLoading = true;

            try
            {
                // Load data off UI thread
                var (students, teacher) = await Task.Run(() =>
                {
                    var studentMembers = _serviceHub.StudentService.getAllStudentByClassId(_classId);
                    var teacherMember = _serviceHub.TeacherService.getAllTeacherByClassId(_classId);

                    var studentUsers = new List<User>();
                    if (studentMembers != null)
                    {
                        foreach (var member in studentMembers)
                        {
                            var user = _serviceHub.UserService.GetUserByUserId(member.UserId);
                            if (user != null)
                                studentUsers.Add(user);
                        }
                    }

                    User teacherUser = null;
                    if (teacherMember != null)
                    {
                        teacherUser = _serviceHub.UserService.GetUserByUserId(teacherMember.UserId);
                    }

                    return (studentUsers, teacherUser);
                });

                // Cache data
                _allStudents = students;
                _teacher = teacher;

                // Render UI
                RenderTeacher(_teacher);
                RenderStudents(_allStudents);
            }
            finally
            {
                _isLoading = false;
            }
        }
        #endregion

        #region Render UI
        private void RenderTeacher(User teacher)
        {
            if (teacher == null) return;

            flpnClassTeacherMenber.SuspendLayout();
            flpnClassTeacherMenber.Controls.Clear();

            var item = GetOrCreateMemberItem(teacher);
            flpnClassTeacherMenber.Controls.Add(item);

            flpnClassTeacherMenber.ResumeLayout(false);
            flpnClassTeacherMenber.PerformLayout();
        }

        private void RenderStudents(List<User> students)
        {
            flpnClassStudentMenber.SuspendLayout();
            flpnClassStudentMenber.Controls.Clear();

            foreach (var student in students)
            {
                var item = GetOrCreateMemberItem(student);
                flpnClassStudentMenber.Controls.Add(item);
            }

            flpnClassStudentMenber.ResumeLayout(false);
            flpnClassStudentMenber.PerformLayout();
        }

        private MemberItem GetOrCreateMemberItem(User user)
        {
            // Return cached item
            if (_memberItemCache.TryGetValue(user.UserId, out var cached))
                return cached;

            // Create new item
            var item = new MemberItem(user);
            _memberItemCache[user.UserId] = item;
            return item;
        }
        #endregion

        #region Search
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            _searchDebounce.Stop();
            _searchDebounce.Start();
        }

        private void OnSearchDebounce(object? sender, EventArgs e)
        {
            _searchDebounce.Stop();
            
            string keyword = txbSearchStudent.Text.Trim().ToLower();
            var filtered = FilterStudents(keyword);
            
            RenderStudents(filtered);
        }

        private List<User> FilterStudents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _allStudents;

            return _allStudents.Where(s =>
                s.FirstName.ToLower().Contains(keyword) ||
                s.LastName.ToLower().Contains(keyword) ||
                s.Email.ToLower().Contains(keyword)
            ).ToList();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _searchDebounce?.Dispose();
                
                foreach (var item in _memberItemCache.Values)
                    item?.Dispose();
                
                _memberItemCache.Clear();
            }
            base.Dispose(disposing);
        }
    }
}
