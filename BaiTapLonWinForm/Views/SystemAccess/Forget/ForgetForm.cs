using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BaiTapLonWinForm.Views.SystemAcess.Pages.ForgetForm
{
    public partial class ForgetForm : Form
    {
        private readonly OtpStorage otp;
        private readonly ServiceHub _serviceHub;
        public ForgetForm(ServiceHub serviceHub)
        {
            InitializeComponent();
            otp = new OtpStorage();
            _serviceHub = serviceHub;
        }

        private void ForgetForm_Load(object sender, EventArgs e)
        {
            CenterLoginPanel();
            for (int i = 0; i < 6; i++)
            {
                var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();
                if (ctl is Guna2TextBox gtb)
                {
                    gtb.MaxLength = 1;
                    gtb.TextAlign = HorizontalAlignment.Center;
                    gtb.KeyDown += Txb_KeyDown;
                }
            }

            this.Controls.Find("txbOTPcode0", true).FirstOrDefault()?.Focus();
        }
        private void CenterLoginPanel()
        {
            if (pnB1 == null || pnB2 == null || pnB3 == null || this == null) return;

            // Căn ngang + dọc
            pnB1.Left = (this.ClientSize.Width - pnB1.Width) / 2;
            pnB1.Top = (this.ClientSize.Height - pnB1.Height) / 2;
            pnB2.Left = (this.ClientSize.Width - pnB2.Width) / 2;
            pnB2.Top = (this.ClientSize.Height - pnB2.Height) / 2;
            pnB3.Left = (this.ClientSize.Width - pnB3.Width) / 2;
            pnB3.Top = (this.ClientSize.Height - pnB3.Height) / 2;
            // Khi form resize, tự động căn lại
            this.Resize -= Form_Resize;
            this.Resize += Form_Resize;

            void Form_Resize(object sender, EventArgs e)
            {
                // Phải dùng cùng panel, không dùng pnBackgroundLogin
                pnB1.Left = (this.ClientSize.Width - pnB1.Width) / 2;
                pnB1.Top = (this.ClientSize.Height - pnB1.Height) / 2;
                pnB2.Left = (this.ClientSize.Width - pnB2.Width) / 2;
                pnB2.Top = (this.ClientSize.Height - pnB2.Height) / 2;
                pnB3.Left = (this.ClientSize.Width - pnB3.Width) / 2;
                pnB3.Top = (this.ClientSize.Height - pnB3.Height) / 2;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string email = txbCurrentEmail.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageHelper.ShowValidationErrors("Email không hợp lệ!");
                return;
            }

            string otp = new Random().Next(100000, 999999).ToString();

            OtpStorage.CurrentOtp = otp;
            OtpStorage.CurrentEmail = email;
            OtpStorage.ExpireAt = DateTime.UtcNow.AddMinutes(2);
            OtpStorage.AttemptCount = 0;
            try
            {
                OtpStorage.SendOtpEmail(email, otp);
                MessageHelper.ShowInfo("Vui lòng kiểm tra email để lấy mã OTP");
                pnB2.Visible = true;
                pnB1.Visible = false;
                this.Controls.Find("txbOTPcode0", true).FirstOrDefault()?.Focus();

            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Gửi email thất bại. Vui lòng thử lại!");
            }
        }
        private void otpClear()
        {
            for (int i = 0; i < 6; i++)
            {
                var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault() as TextBox;
                if (ctl != null)
                    ctl.Text = "";
            }
        }
        private void Txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string clipboardText = Clipboard.GetText().Trim();
                if (clipboardText.Length == 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();
                        if (ctl is Guna2TextBox gtb)
                            gtb.Text = clipboardText[i].ToString();
                    }
                }
                e.Handled = true;
                return;
            }
            if (sender is Guna2TextBox current)
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (string.IsNullOrEmpty(current.Text))
                    {
                        var name = current.Name;
                        if (name.StartsWith("txbOTPcode"))
                        {
                            if (int.TryParse(name.Substring("txbOTPcode".Length), out int idx) && idx > 0)
                            {
                                var prev = this.Controls.Find("txbOTPcode" + (idx - 1), true).FirstOrDefault() as Guna2TextBox;
                                prev?.Focus();
                            }
                        }
                    }
                }
                else
                {
                    if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                    {
                        this.BeginInvoke((Action)(() =>
                        {
                            var name = current.Name;
                            if (name.StartsWith("txbOTPcode"))
                            {
                                if (int.TryParse(name.Substring("txbOTPcode".Length), out int idx) && idx < 5)
                                {
                                    var next = this.Controls.Find("txbOTPcode" + (idx + 1), true).FirstOrDefault() as Guna2TextBox;
                                    next?.Focus();
                                }
                            }
                        }));
                    }
                }
            }
        }

        private void btnConfirmOPT_Click(object sender, EventArgs e)
        {
            string inputOtp = "";
            for (int i = 0; i < 6; i++)
            {
                Control ctl = null;
                if (guna2Panel2 != null)
                    ctl = guna2Panel2.Controls.Find("txbOTPcode" + i, false).FirstOrDefault();
                if (ctl == null)
                    ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();

                if (ctl is Guna2TextBox gtb)
                    inputOtp += gtb.Text.Trim();
                else
                    inputOtp += "";
            }
            if (OtpStorage.ExpireAt.HasValue && DateTime.UtcNow > OtpStorage.ExpireAt.Value)
            {
                MessageHelper.ShowWarning("OTP đã hết hạn. Vui lòng yêu cầu gửi lại.");
                OtpStorage.Clear();
                return;
            }

            OtpStorage.AttemptCount++;
            if (OtpStorage.AttemptCount > 5)
            {
                MessageHelper.ShowInfo("Bạn đã thử quá nhiều lần! Vui lòng ấn gửi gửi lại OTP.");
                OtpStorage.Clear();
                return;
            }

            if (!string.IsNullOrEmpty(inputOtp) && inputOtp == OtpStorage.CurrentOtp)
            {
                MessageHelper.ShowSuccess("Xác thực OTP thành công!");
                otpClear();
                pnB2.Visible = false;
                pnB3.Visible = true;
            }
            else
            {
                MessageHelper.ShowValidationErrors("OTP không đúng, vui lòng thử lại.");
                for (int i = 0; i < 6; i++)
                {
                    var ctl = this.Controls.Find("txbOTPcode" + i, true).FirstOrDefault();
                    if (ctl is Guna2TextBox gtb) gtb.Text = "";
                }
                this.Controls.Find("txbOTPcode0", true).FirstOrDefault()?.Focus();
            }
        }
        private async void btnSubmitPass_Click(object sender, EventArgs e)
        {
            string newPass = txbNewPass.Text.Trim();
            string confirm = txbConfirmNewPass.Text.Trim();
            string email = OtpStorage.CurrentEmail;
            int isSuccess = await _serviceHub.AuthService.ChangePasswordAsync(email, newPass, confirm);
            if (isSuccess == 3)
            {
                txbNewPass.Text = null;
                txbConfirmNewPass.Text = null;
            }
            else if(isSuccess == 1) {
                txbNewPass.Text = null;
                txbConfirmNewPass.Text = null;
                pnB3.Visible = false;
                pnB1.Visible = true;
            }
            else if(isSuccess == 0)
            {
                MessageHelper.ShowSuccess("Tạo mật khẩu mới thành công!");
                this.Close();
            }
        }

    }
}
