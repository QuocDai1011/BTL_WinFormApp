using BaiTapLonWinForm.Models;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTapLonWinForm.View.Admin.Course
{
    public partial class CourseCard : UserControl
    {
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler<Models.Course> OnCardClicked;
        private Models.Course course;

        private Color _themeColor = Color.FromArgb(46, 204, 113);
        private Color _hoverBackColor;

        public CourseCard()
        {
            InitializeComponent();
            InitializeEvents();
        }

        #region initialize 
        private void InitializeEvents()
        {
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

            this.Click += (s, e) => InvokeCardClick();

            cardPanel.Click += (s, e) => InvokeCardClick();

            this.AttachHoverEvents(this);
            this.AttachHoverEvents(cardPanel);
            foreach (Control c in cardPanel.Controls)
            {
                if (!(c is Guna2Button))
                    this.AttachHoverEvents(c);
                    c.Click += (s, e) => InvokeCardClick();
            }
        }

        private void InvokeCardClick()
        {
            if (course != null)
            {
                OnCardClicked?.Invoke(this, course);
            }
        }

        private void AttachHoverEvents(Control control)
        {
            control.MouseEnter += (s, e) => OnHoverEnter();
            control.MouseLeave += (s, e) => OnHoverLeave();
        }

        #endregion

        #region helper method
        private void OnHoverEnter()
        {

            cardPanel.FillColor = _hoverBackColor;

            cardPanel.ShadowColor = Color.FromArgb(100, _themeColor);
            cardPanel.ShadowDepth = 80; 

            this.Cursor = Cursors.Hand;
        }

        private void OnHoverLeave()
        {
            cardPanel.FillColor = Color.White;
            cardPanel.ShadowColor = Color.Black;
            cardPanel.ShadowDepth = 40;

            this.Cursor = Cursors.Default;
        }

        public void SetCourseData(Models.Course courseData)
        {
            course = courseData;

            lblCourseCode.Text = $"#{course.CourseCode}";
            lblCourseName.Text = course.CourseName;
            lblSessions.Text = $"{course.NumberSessions} buổi";
            lblPrice.Text = $"{course.Tuition:N0} đ";

            ConfigureLevelStyle(course.Level);
        }

        private void ConfigureLevelStyle(string level)
        {
            badgeLevel.Text = level;

            Color bgLevel, foreLevel;

            switch (level?.ToLower())
            {
                case "beginner":
                case "a1":
                case "starters":
                    _themeColor = Color.FromArgb(46, 204, 113);
                    break;

                case "intermediate":
                case "a2":
                case "movers":
                case "flyers":
                    _themeColor = Color.FromArgb(52, 152, 219); 
                    break;

                case "advanced":
                case "b1":
                case "b2":
                case "ielts":
                    _themeColor = Color.FromArgb(231, 76, 60); 
                    break;

                default:
                    _themeColor = Color.Gray;
                    break;
            }

            _hoverBackColor = ControlPaint.Light(_themeColor, 1.8f);
            
            _hoverBackColor = Color.FromArgb(245, 250, 255); 
            if (_themeColor.R > 200) _hoverBackColor = Color.FromArgb(255, 245, 245); 

            lblPrice.ForeColor = _themeColor;

            badgeLevel.FillColor = Color.FromArgb(30, _themeColor);
            badgeLevel.ForeColor = _themeColor;
        }

        #endregion
    }
}