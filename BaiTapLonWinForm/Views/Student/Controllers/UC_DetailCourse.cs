using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_DetailCourse : UserControl
    {
        private readonly ICourseService _courseService;
        private readonly int _studentId;
        private readonly int _courseId;

        public UC_DetailCourse(ICourseService courseService, int studentId, int courseId)
        {
            _courseService = courseService;
            _studentId = studentId;
            _courseId = courseId;
            InitializeComponent();
        }

        public void LoadDetailCourse(int courseId)
        {
            var data = _courseService.GetAllClassByCourseId(courseId);

            if (data == null)
            {
                MessageHelper.ShowWarning("Lớp học chưa được mở", "Trống");
                return;
            }

            listClass.AutoGenerateColumns = true;
            listClass.DataSource = data;

            // Style

            listClass.Columns["ClassId"].Visible = false;

            // Căn chỉnh dòng
            listClass.Columns["ClassName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            listClass.Columns["TeacherName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Căn chỉnh độ rộng cột
            //listClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            listClass.Columns["Shift"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Căn chỉnh văn bản
            // Cho toàn bộ cột
            listClass.Columns["StartDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listClass.Columns["EndDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listClass.Columns["CurrentStudent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listClass.Columns["MaxStudent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listClass.Columns["Shift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Định dạng dữ liệu
            listClass.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            listClass.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private async void listClass_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = listClass.CurrentRow;
            int classId = (int)row.Cells["ClassId"].Value;
            string studyDay = row.Cells["SchoolDay"].Value?.ToString();

            if (studyDay == "Chưa có lịch học")
            {
                MessageHelper.ShowInfo("Chưa có lịch học không thể đăng ký", "Thông báo");
                return;
            }

            var kq = MessageBox.Show(
                "Mua khóa học",
                "Xác nhận đăng ký",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (kq != DialogResult.Yes) return;

            try
            {
                using HttpClient client = new HttpClient();

                var data = new {
                    studentId = _studentId,
                    classId,
                    courseId = _courseId,
                    amount = (int)_courseService.GetAmount(_courseId)
                };
                string json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync(
                    "http://localhost:5080/api/vnpay/create",
                    content
                );

                if (!res.IsSuccessStatusCode)
                {
                    string err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        $"Lỗi tạo link\nStatus: {res.StatusCode}\n{err}"
                    );
                    return;
                }


                string responseBody = await res.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(responseBody);

                string payUrl = doc.RootElement.GetProperty("url").GetString();

                Process.Start(new ProcessStartInfo
                {
                    FileName = payUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

    }
}
