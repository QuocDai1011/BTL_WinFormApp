using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Mongo;
using BaiTapLonWinForm.Services.Interfaces;
using MongoDB.Driver;
using System.Diagnostics;

namespace BaiTapLonWinForm
{
    public partial class Form1 : Form
    {
        private readonly INewsfeedService _newsfeedService;

        public Form1(INewsfeedService newfeedService)
        {
            InitializeComponent();
            _newsfeedService = newfeedService;
            Load += Form1_Load;
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    var data = await _newsfeedService.GetNewsfeedsAsync();
            //    dgvNewfeeds.AutoGenerateColumns = true;
            //    dgvNewfeeds.DataSource = data;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(
            //        "Lỗi tải dữ liệu MongoDB:\n" + ex.Message,
            //        "MongoDB Error",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );
            //}
        }
        private void dgvNewfeeds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvNewfeeds.Rows[e.RowIndex].DataBoundItem as Newsfeed;

            var link = item?.LinkPathInCloud?.FirstOrDefault(x => !string.IsNullOrEmpty(x));

            if (link != null)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true
                });
            }
        }

    }
}
