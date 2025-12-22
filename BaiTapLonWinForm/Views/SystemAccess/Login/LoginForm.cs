using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Utils;
using BaiTapLonWinForm.Views.SystemAcess.Pages.ForgetForm;
using BaiTapLonWinForm.Views.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Validator = BaiTapLonWinForm.Utils.Validator;

namespace BaiTapLonWinForm.Views.SystemAcess.Login
{
    public partial class LoginForm : Form
    {
        private readonly ServiceHub _serviceHub;
        public LoginForm(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
        }
        private bool CheckLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageHelper.ShowWarning("Vui lòng nhập email và mật khẩu!");
                return false;
            }
            string userRole;
            var isLogin = _serviceHub.UserService.Login(email, password, out userRole);

            if (isLogin == false)
            {
                MessageHelper.ShowError("Email không tồn tại trong hệ thống hoặc sai mật khẩu!");
                return false;
            }
            else
            {
                MessageHelper.ShowSuccess("Đăng nhập thành công");
                return true;
            }
        }
        public void NavigatePage(string username)
        {
            var existUser = _serviceHub.UserService.GetUserByEmail(username);
            string role = _serviceHub.UserService.GetRoleNameByRoleId(existUser.RoleId);
            if (existUser != null && role != null)
            {
                switch (role)
                {
                    case "admin":
                        {
                            this.Dispose();
                            break;
                        }
                    case "teacher":
                        {
                            int teacherId = _serviceHub.TeacherService.GetTeacherByUserId(existUser.UserId);
                            new TeacherPage(_serviceHub, teacherId).ShowDialog();
                            this.Dispose();
                            break;
                        }
                    case "student":
                        {
                            this.Dispose();
                            break;
                        }
                }
            }
            else
            {
                MessageHelper.ShowError("Người dùng không tồn tại trong hệ thống!");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbEmailLogin.Text.Trim();
            string password = txbPassLogin.Text.Trim();
            bool check = CheckLogin(username, password);
            if(check == true)
            {
               NavigatePage(username);
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

            pnBackgroundLogin.Visible = false;
            pnBackgroundRegister.Visible = true;
            txbEmailLogin.Text = "";
            txbPassLogin.Text = "";
        }
        private void lblNavigationLogin_Click(object sender, EventArgs e)
        {
            pnBackgroundRegister.Visible = false;
            pnBackgroundLogin.Visible = true;
        }
        private void lblNavigationRegister_Click(object sender, EventArgs e)
        {
            pnBackgroundRegister.Visible = true;
            pnBackgroundLogin.Visible = false;
        }
        private void clearRegisterForm()
        {
            txbHoRegister.Text = "";
            txbTenRegister.Text = "";
            txbUsernameRegister.Text = "";
            txbPassRegister.Text = "";
            txbConfirmPass.Text = "";
            txbDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cbxGioiTinh.SelectedIndex = -1;
            txbSdt.Text = "";
            txbSdtPhuHuynh.Text = "";
        }
        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsernameRegister.Text.Trim();
            string password = txbPassRegister.Text.Trim();
            string firstName = txbHoRegister.Text.Trim();
            string lastName = txbTenRegister.Text.Trim();
            string confirmPassword = txbConfirmPass.Text.Trim();
            string address = txbDiaChi.Text.Trim();
            DateTime dob = dtpNgaySinh.Value;
            bool gender;
            if (cbxGioiTinh.Text.Trim() == "Nam") gender = true;
            else gender = false;
            string phone = txbSdt.Text.Trim();
            string parentPhone = txbSdtPhuHuynh.Text.Trim();
            bool check = RegisterUser(firstName, lastName, username, password, confirmPassword, address, dob, gender, phone, parentPhone);
            if (check == true)
            {
                pnBackgroundRegister.Visible = false;
                pnBackgroundLogin.Visible = true;
            }

        }
        private bool checkRegisterForm(
            string firstName,
            string lastName,
            string email,
            string password,
            string confirmPassword,
            string address,
            DateTime dob,
            bool gender,
            string phone,
            string parentPhone)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageHelper.ShowWarning("Vui lòng điền đầy đủ thông tin bắt buộc!");
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    MessageHelper.ShowValidationErrors("Email không hợp lệ!");
                    return false;
                }
                if (Validator.IsValidEmail(email) == false)
                {
                    MessageHelper.ShowValidationErrors("Email không hợp lệ, phải đúng định dạng example@domain.com!");
                    return false;
                }
            }
            catch
            {
                MessageHelper.ShowValidationErrors("Email không hợp lệ!");
                return false;
            }
            if (Validator.IsStrongPassword(password) == false)
            {
                MessageHelper.ShowValidationErrors("Mật khẩu đăng kí không đủ mạnh! Vui lòng đảm bảo mật khẩu có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");
                return false;
            }
            if (password != confirmPassword)
            {
                MessageHelper.ShowValidationErrors("Mật khẩu và xác nhận mật khẩu không khớp!");
                return false;
            }
            if (password.Length < 6)
            {
                MessageHelper.ShowValidationErrors("Mật khẩu phải từ 6 ký tự trở lên!");
                return false;
            }
            if (Validator.IsValidPhone(phone) == false)
            {
                MessageHelper.ShowValidationErrors("Số điện thoại không hợp lệ! Vui lòng nhập đúng định dạng số điện thoại Việt Nam.");
                return false;
            }

            if (Validator.IsValidPhone(parentPhone) == false)
            {
                MessageHelper.ShowValidationErrors("Số điện thoại bố mẹ không hợp lệ! Vui lòng nhập đúng định dạng số điện thoại Việt Nam.");
                return false;
            }
            if (Validator.IsValidAge(DateTime.Now.Year - dob.Year) == false)
            {
                MessageHelper.ShowValidationErrors("Yêu cầu học viên trên 4 tuổi.");
                return false;
            }
            return true;
        }
        private bool RegisterUser(
            string firstName,
            string lastName,
            string email,
            string password,
            string confirmPassword,
            string address,
            DateTime dob,
            bool gender,
            string phone,
            string parentPhone)
        {
            if (!checkRegisterForm(firstName, lastName, email, password, confirmPassword, address, dob, gender, phone, parentPhone))
            {
                return false;
            }
            bool isRegistered = _serviceHub.UserService.RegisterStudent(
              firstName, lastName, email, password, address, dob, gender, phone, parentPhone);
            if (!isRegistered)
            {
                MessageHelper.ShowError("Đăng ký thất bại!");
                return false;
            }
            else MessageHelper.ShowSuccess("Đăng ký thành công!");
            clearRegisterForm();
            return true;
        }

        private void lblForgetPass_Click(object sender, EventArgs e)
        {
            try
            {
                var forgetForm = new ForgetForm(_serviceHub);
                forgetForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Đã xảy ra lỗi khi mở form quên mật khẩu: ");
            }
        }
        private void CenterLoginPanel()
        {
            if (guna2Panel6 == null || guna2Panel3 == null || this == null) return;

            guna2Panel6.Left = (this.ClientSize.Width - guna2Panel6.Width) / 2;
            guna2Panel6.Top = (this.ClientSize.Height - guna2Panel6.Height) / 2;
            guna2Panel3.Left = (this.ClientSize.Width - guna2Panel3.Width) / 2;
            guna2Panel3.Top = (this.ClientSize.Height - guna2Panel3.Height) / 2;
            this.Resize -= Form_Resize;
            this.Resize += Form_Resize;

            void Form_Resize(object sender, EventArgs e)
            {
                guna2Panel6.Left = (this.ClientSize.Width - guna2Panel6.Width) / 2;
                guna2Panel6.Top = (this.ClientSize.Height - guna2Panel6.Height) / 2;
                guna2Panel3.Left = (this.ClientSize.Width - guna2Panel3.Width) / 2;
                guna2Panel3.Top = (this.ClientSize.Height - guna2Panel3.Height) / 2;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterLoginPanel();
        }
    }
}
