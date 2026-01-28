using BaiTapLonWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonWinForm.Views.Student.Controllers.DetailClass
{
    public partial class UC_Exercise : UserControl
    {
        private readonly INewsfeedService _newsfeedSerivce;
        private readonly IAssignmentService _assignmentService;
        private int _studentId;
        public UC_Exercise(INewsfeedService newsfeedSerivce, IAssignmentService assignmentService, string newsfeedId, int studentId)
        {
            InitializeComponent();
            _newsfeedSerivce = newsfeedSerivce;
            _assignmentService = assignmentService;
            _studentId = studentId;
            LoadAssignmentByNewsfeedId(newsfeedId);
        }

        private void LoadAssignmentByNewsfeedId(string newsfeedId)
        {
            var assignment = _newsfeedSerivce.LoadAssignmentByNewsfeedId(newsfeedId);

            if (assignment == null || !assignment.Any()) 
                return;

            foreach(var item in assignment)
            {
                var control = new UC_CardFeed(item, _assignmentService, item.type.Trim(), item.Id, _studentId);
                control.Dock = DockStyle.Top;
                this.Controls.Add(control);
            }
        }
    }
}
