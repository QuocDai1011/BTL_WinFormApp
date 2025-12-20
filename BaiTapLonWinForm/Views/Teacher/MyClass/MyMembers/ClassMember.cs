using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass
{
    public partial class ClassMember : UserControl
    {
        private readonly long _classId;
        private readonly ServiceHub _serviceHub;
        private System.Windows.Forms.Timer searchTimer;
        private List<User> currentStudentMembers = new List<User>();
        private Models.User currentTeacherMember = new User();
        //private List<Student> Search(string keyword);
        public ClassMember(long classId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _classId = classId;
            _serviceHub = serviceHub;
        }
        private void InitializeSearchTimer()
        {
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300; // Thời gian chờ 300ms
            searchTimer.Tick += searchTimer_Tick;
        }
        //Tải dữ liệu thành viên lớp học
        private void ClassMember_Load(object sender, EventArgs e)
        {
            InitializeSearchTimer();   // <<< QUAN TRỌNG
            LoadClassMembers();
        }
        private void LoadClassMembers()
        {
            LoadStudentMembers();
            LoadTeacherMembers();
        }
        private void LoadStudentMembers()
        {
            //Lấy danh sách thành viên là sinh viên từ ServiceHub
            var studentMembers = _serviceHub.StudentService.getAllStudentByClassId(_classId);
            if (studentMembers == null || studentMembers.Count == 0)
            {
                return;
            }
            else
            {
                //Tạo vòng lặp để thêm thành viên vào giao diện 
                foreach (var member in studentMembers)
                {
                    var currentUser = _serviceHub.UserService.GetUserByUserId(member.UserId);
                    var memberItem = new MemberItem(currentUser);
                    flpnClassStudentMenber.Controls.Add(memberItem);
                    if(currentUser != null)
                    currentStudentMembers.Add(currentUser);
                }
            }
        }
        private void GenerateStudentMemberItems(List<User> students)
        {
            flpnClassStudentMenber.Controls.Clear();
            foreach (var student in students)
            {
                var memberItem = new MemberItem(student);
                flpnClassStudentMenber.Controls.Add(memberItem);
            }
        }
        private void LoadTeacherMembers()
        {
            //Lấy giảng viên từ classId
            var teacherMember = _serviceHub.TeacherService.getAllTeacherByClassId(_classId);
            if (teacherMember == null)
            {
                return;
            }
            else
            {
                var currentUser = _serviceHub.UserService.GetUserByUserId(teacherMember.UserId);
                var memberItem = new MemberItem(currentUser);
                flpnClassTeacherMenber.Controls.Add(memberItem);
                currentTeacherMember = currentUser;
            }
        }
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();   // reset timer mỗi lần gõ
        }
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();    // tránh lặp vô hạn
            LoadDataStudentMember(txbSearchStudent.Text.Trim());
        }
        private void LoadDataStudentMember(string keyword)
        {
            var data = SearchLocal(keyword);
            flpnClassStudentMenber.Controls.Clear();
            GenerateStudentMemberItems(data);
        }
        private List<User> SearchLocal(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return currentStudentMembers;

            keyword = keyword.ToLower();

            return currentStudentMembers
                .Where(s => s.FirstName.ToLower().Contains(keyword) || s.LastName.ToLower().Contains(keyword))
                .ToList();
        }
    }
}
