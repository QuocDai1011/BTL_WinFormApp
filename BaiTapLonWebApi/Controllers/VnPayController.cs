using BaiTapLonWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapLonWebApi.Controllers
{
    [ApiController]
    [Route("api/vnpay")]
    public class VnPayController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly EnglistCenterContext _context;

        public VnPayController(IConfiguration config, EnglistCenterContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest req)
        {
            if (req == null)
                return BadRequest("req is null");

            Console.WriteLine(req.studentId);
            Console.WriteLine(req.classId);
            Console.WriteLine(req.courseId);
            Console.WriteLine(req.amount);

            var txnRef = Guid.NewGuid().ToString("N");

            var newReceipt = new Receipt
            {
                StudentId = req.studentId,
                ClassId = req.classId,
                PromotionId = 1,
                TotalAmount = req.amount,
                TxnRef = txnRef,
                Status = "PENDING"
            };


            var vnp = new VnPayLibrary();

            string tmnCode = _config["VnPay:TmnCode"];
            string hashSecret = _config["VnPay:HashSecret"];
            string baseUrl = _config["VnPay:BaseUrl"];
            string returnUrl = _config["VnPay:ReturnUrl"];

            vnp.AddRequestData("vnp_Version", "2.1.0");
            vnp.AddRequestData("vnp_Command", "pay");
            vnp.AddRequestData("vnp_TmnCode", tmnCode);
            vnp.AddRequestData("vnp_Amount", (req.amount * 100).ToString());
            vnp.AddRequestData("vnp_CurrCode", "VND");
            vnp.AddRequestData("vnp_TxnRef", txnRef);
            vnp.AddRequestData("vnp_OrderInfo", "Thanh toan don hang");
            vnp.AddRequestData("vnp_OrderType", "other");
            vnp.AddRequestData("vnp_Locale", "vn");
            vnp.AddRequestData("vnp_ReturnUrl", returnUrl);
            vnp.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1");
            vnp.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));

            string paymentUrl = vnp.CreateRequestUrl(baseUrl, hashSecret);
                        
            await _context.Receipts.AddAsync(newReceipt);
            await _context.SaveChangesAsync();
            return Ok(new { url = paymentUrl });
        }

        [HttpGet("return")]
        public async Task<IActionResult> VnPayReturn()
        {
            var vnp = new VnPayLibrary();

            foreach (var key in Request.Query.Keys)
            {
                if (key.StartsWith("vnp_"))
                {
                    vnp.AddResponseData(key, Request.Query[key]);
                }
            }

            string hashSecret = _config["VnPay:HashSecret"];
            bool isValidSignature = vnp.ValidateSignature(
                Request.Query["vnp_SecureHash"],
                hashSecret
            );

            if (!isValidSignature)
                return Content("Sai chữ ký");

            string responseCode = Request.Query["vnp_ResponseCode"];

            // Tiến hành xác nhận thanh toán và lưu hóa đơn vào databasse
            string txnRef = Request.Query["vnp_TxnRef"];

            var receipt = _context.Receipts
                .FirstOrDefault(r => r.TxnRef == txnRef);

            if (receipt == null)
                return Content("Không tìm thấy hóa đơn");

            if (responseCode == "00")
            {
                receipt.Status = "PAID";
                receipt.PaidAmount = receipt.TotalAmount;
            }
            else
            {
                receipt.Status = "FAILED";
            }

            await _context.SaveChangesAsync();
            return Ok("OK");
        }
    }

    public class PaymentRequest
    {
        public int studentId { get; set; }
        public int classId { get; set; }
        public int courseId { get; set; }
        public int amount { get; set; }
    }
}
