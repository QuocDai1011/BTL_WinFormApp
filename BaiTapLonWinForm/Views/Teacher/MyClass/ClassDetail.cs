using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.Teacher.MyClass.MyExercise;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    /// <summary>
    /// ClassDetail - Hiển thị chi tiết lớp học với control caching
    /// </summary>
    public partial class ClassDetail : UserControl
    {
        private readonly int _classId;
        private readonly ServiceHub _serviceHub;
        private bool _loaded = false;
        // Cache controls để tránh tạo lại
        private NewDetail _newDetail;
        private ClassMember _classMember;
        public event Action<string> OnOpenScoreDetail;
        public event Action<int> OnAddExercise;
        public event Action<Assignment> OnEditExercise;

        public ClassDetail(int classId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _classId = classId;
            _serviceHub = serviceHub;

            // Enable double buffering cho panel chính
            EnableDoubleBuffering(pnMainClass);
            EnableDoubleBuffering(this);
            icMeet.IconClicked += IconCustom_Clicked;
            this.Load += ClassDetail_Load;
        }
        private async void ClassDetail_Load(object sender, EventArgs e)
        {
            if (_loaded) return;
            _loaded = true;

            try
            {
                _newDetail = new NewDetail(_serviceHub, _classId);
                _newDetail.Dock = DockStyle.Fill;

                SwitchView(_newDetail);

                List<Newsfeed> newsFeedList =
                    await _serviceHub.NewsfeedService.GetNewsfeedsByClassIdAsync(_classId);

                await _newDetail.LoadNewsFeedList(newsFeedList);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }
        private void EnableDoubleBuffering(Control control)
        {
            if (control == null) return;

            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        #region View Management
        private void btnDefaultLoad()
        {
            SwitchView(_newDetail);
        }

        private void btnMainAction1_Click(object sender, EventArgs e)
        {
            btnDefaultLoad();
        }

        private void btnMainAction3_Click(object sender, EventArgs e)
        {
            // Cache ClassMember - chỉ tạo một lần
            if (_classMember == null)
            {
                _classMember = new ClassMember(_classId, _serviceHub);
            }

            // Skip nếu đã hiển thị
            if (pnMainClass.Controls.Count > 0 && pnMainClass.Controls[0] == _classMember)
                return;

            SwitchView(_classMember);
        }
        private void btnMainAction2_Click(object sender, EventArgs e)
        {
            var exerciseView = new ExerciseDetail(_serviceHub, _classId)
            {
                Dock = DockStyle.Fill
            };
            exerciseView.OnEditExercise += (assignment) =>
            {
                OnEditExercise?.Invoke(assignment);
            };

            exerciseView.OnAddExercise += classId =>
            {
                OnAddExercise?.Invoke(classId);
            };
            exerciseView.OnOpenScoreDetail += assignmentId =>
            {
                OnOpenScoreDetail?.Invoke(assignmentId);
            };
            SwitchView(exerciseView);
        }

        private void SwitchView(Control newView)
        {
            pnMainClass.SuspendLayout();
            pnMainClass.Controls.Clear();
            newView.Dock = DockStyle.Fill;
            pnMainClass.Controls.Add(newView);
            pnMainClass.ResumeLayout(false);
        }
        #endregion

        #region Meeting Link
        private void pnMeet_Click(object sender, EventArgs e)
        {
            var currentClass = _serviceHub.ClassService.GetClassById(_classId);

            if (string.IsNullOrWhiteSpace(currentClass?.OnlineMeetingLink))
            {
                MessageHelper.ShowInfo("Lớp học chưa có link họp trực tuyến!");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = currentClass.OnlineMeetingLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Không thể mở link họp: {ex.Message}");
            }
        }

        private void IconCustom_Clicked(object sender, EventArgs e)
        {
            pnMeet_Click(sender, e);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _newDetail?.Dispose();
                _classMember?.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
