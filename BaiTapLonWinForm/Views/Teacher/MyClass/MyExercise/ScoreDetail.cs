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

namespace BaiTapLonWinForm.Views.Teacher.MyClass.MyExercise
{
    public partial class ScoreDetail : UserControl
    {
        public Action OnBack;
        private string _assignmentId;
        private readonly ServiceHub _serviceHub;
        public ScoreDetail(ServiceHub serviceHub, string assignmentId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _assignmentId = assignmentId;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke();
        }

        private void btnAction1_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            var scoreNew = new ScoreNew(_serviceHub, _assignmentId)
            {
                Dock = DockStyle.Fill
            };
            pnContainer.Controls.Add(scoreNew);
        }

        private void btnAction2_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            var scoreStudent = new ScoreStudent(_serviceHub, _assignmentId)
            {
                Dock = DockStyle.Fill
            };
            pnContainer.Controls.Add(scoreStudent);
        }

        private void ScoreDetail_Load(object sender, EventArgs e)
        {
            btnAction1_Click(sender, e);
        }
    }
}
