using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace BaiTapLonWinForm.Views.Teacher.MyClass.MyNews
{
    public partial class AddNew : UserControl
    {
        public AddNew()
        {
            InitializeComponent();
            this.Load += AddNew_Load;
        }

        private async void AddNew_Load(object sender, EventArgs e)
        {
            await webView.EnsureCoreWebView2Async();

            string htmlPath = Path.Combine(
                Application.StartupPath,
                "Views",
                "Teacher",
                "MyClass",
                "MyNews",
                "editor.html"
            );
            webView.Source = new Uri(htmlPath);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseNew_Click(object sender, EventArgs e)
        {
            var overlay = this.Parent;
            if (overlay != null)
            {
                overlay.Parent.Controls.Remove(overlay);
                overlay.Dispose();
            }
        }
    }
}
