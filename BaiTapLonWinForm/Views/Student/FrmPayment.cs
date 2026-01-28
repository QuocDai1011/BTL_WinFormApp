using BaiTapLonWinForm.Services.Interfaces;

using BaiTapLonWinForm.Utils;

namespace BaiTapLonWinForm.Views.Student
{
    public partial class FrmPayment : Form
    {
        private readonly ICourseService _service;
        private readonly int _classId;
        private readonly int _studentId;

        public FrmPayment(ICourseService service, int classID, int studentId)
        {
            InitializeComponent();
            _classId = classID;
            _service = service;
            _studentId = studentId;
        }

        private async void FrmPayment_Load(object sender, EventArgs e)
        {

            decimal amount = _service.GetAmount(_classId);

            string transferContent = $"PAY_CLASS_{_classId}";

            pictureBoxQr.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQr.Image = await GenerateVietQrAsync(
                bankId: "ICB",
                accountNo: "9704150211229532",
                accountName: "DINH NHAT HUYEN NHAN",
                amount: amount,
                addInfo: transferContent
            );
        }

        private void GenerateReceipt(int classId, int studentId)
        {
            decimal amount = _service.GetAmount(classId);

            _service.CreateReceipt(studentId, classId, amount);
            MessageHelper.ShowSuccess("Sau khi nhấn hoàn thành thanh toán, đợi xác nhận!", "Thành công");
        }

        private async Task<Image> GenerateVietQrAsync(
            string bankId,
            string accountNo,
            string accountName,
            decimal amount,
            string addInfo)
        {
            var url =
                $"https://api.vietqr.io/image/{bankId}-{accountNo}-compact2.png" +
                $"?amount={amount}" +
                $"&addInfo={Uri.EscapeDataString(addInfo)}" +
                $"&accountName={Uri.EscapeDataString(accountName)}";

            using var client = new HttpClient();
            var bytes = await client.GetByteArrayAsync(url);

            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private void btnClassDetail_Click(object sender, EventArgs e)
        {
            GenerateReceipt(_classId, _studentId);
        }
    }
}
