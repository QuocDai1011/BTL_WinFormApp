using BaiTapLonWinForm.DTOs;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Utils;
using Guna.UI2.WinForms;

namespace BaiTapLonWinForm.Views.Student.Controllers
{
    public partial class UC_DetailStudent : UserControl
    {
        private readonly IStudentService _service;
        private int _studentId;
        public UC_DetailStudent(IStudentService service, int studentId)
        {
            _service = service;
            InitializeComponent();
            _studentId = studentId;

        }

        public void LoadDetailStudent(int studentId)
        {
            var student = _service.GetStudentByStudentId(studentId);

            if (student == null)
            {
                MessageHelper.ShowError("Không tìm thấy sinh viên", "Lỗi");
                return;
            }

            var user = student.User;
            lbId.Text = user.UserId.ToString();
            gunaFirstName.Text = user.FirstName;
            gunaLastName.Text = user.LastName;
            gunaFullName.Text = $"{user.FirstName} {user.LastName}";
            gunaEmail.Text = user.Email;

            gunaGender.Text = user.Gender switch
            {
                true => "Nam",
                false => "Nữ",
                null => "Chưa rõ"
            };

            gunaAddress.Text = user.Address;
            gunaBirth.Text = user.DateOfBirth?.ToString("dd/MM/yyyy") ?? "";
            gunaPhone.Text = user.PhoneNumber;
            gunaPhoneParent.Text = student.PhoneNumberOfParents;

            gunaDate.Value =
                user.DateOfBirth.HasValue
                    ? user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
                    : DateTime.Now;
        }

        private void gunaEdit_Click(object sender, EventArgs e)
        {
            gunaSave.Visible = true;

            lbFullName.Visible = false;
            gunaFullName.Visible = false;

            lbFirstName.Visible = true;
            gunaFirstName.Visible = true;
            lbLastName.Visible = true;
            gunaLastName.Visible = true;

            gunaEmail.ReadOnly = false;
            gunaEmail.Enabled = true;

            if (gunaGender.Text == "Nam")
                gunaBoy.Checked = true;
            else
                gunaGirl.Checked = true;

            gunaGender.Visible = false;
            gunaBoy.Visible = true;
            gunaGirl.Visible = true;

            gunaAddress.ReadOnly = false;
            gunaAddress.Enabled = true;

            gunaBirth.Visible = false;
            gunaDate.Visible = true;

            gunaPhone.ReadOnly = false;
            gunaPhone.Enabled = true;
            gunaPhoneParent.ReadOnly = false;
            gunaPhoneParent.Enabled = true;
        }

        private bool UpdateStudent(int studentId, UpdateStudentDto data)
        {
            data.FirstName = gunaFirstName.Text;
            data.LastName = gunaLastName.Text;
            data.Email = gunaEmail.Text;
            data.Gender = gunaBoy.Checked;
            data.Address = gunaAddress.Text;
            data.DateOfBirth = DateOnly.FromDateTime(gunaDate.Value);
            data.PhoneNumber = gunaPhone.Text;
            data.PhoneNumberOfParents = gunaPhoneParent.Text;

            if (!_service.UpdateStudentByStudentId(studentId, data))
                return false;

            return true;
        }

        private void gunaSave_Click(object sender, EventArgs e)
        {
            // Validate chung
            if( !ValidateString(gunaFirstName.Text.Trim(), "FirstName") ||
                !ValidateString(gunaLastName.Text.Trim(), "LastName") ||
                !ValidateString(gunaEmail.Text.Trim(), "Email") ||
                !ValidateString(gunaAddress.Text.Trim(), "Address") ||
                !ValidateString(gunaPhone.Text.Trim(), "PhoneNumber") ||
                !ValidateString(gunaPhoneParent.Text.Trim(), "PhoneNumberOfParents"))
            {
                MessageHelper.ShowError("Thông tin không được để trống", "Lỗi");
                return;
            }

            if (!RegexUtilities.IsValidEmail(gunaEmail.Text.Trim()))
            {
                string email = $"Email {gunaEmail.Text} không hợp lệ";
                MessageHelper.ShowError(email, "Lỗi");
                return;
            }
            
            if (!RegexUtilities.IsValidPhone(gunaPhone.Text.Trim()))
            {
                MessageHelper.ShowError("Số điện thoại không hợp lệ", "Lỗi");
                return;
            }

            if (!RegexUtilities.IsValidPhone(gunaPhoneParent.Text.Trim()))
            {
                MessageHelper.ShowError("Số điện thoại của phụ huynh không hợp lệ", "Lỗi");
                return;
            }
            
            if (gunaPhone.Text.Trim() == gunaPhoneParent.Text.Trim())
            {
                MessageHelper.ShowError("Số điện thoại bị trùng với số phụ hunh", "Lỗi");
                return;
            }

            if (!RegexUtilities.IsVaidDate(gunaDate.Value))
            {
                MessageHelper.ShowError("Năm sinh không hợp lệ", "Lỗi");
                return;
            }


            var data = new UpdateStudentDto();
            bool isSuccess = UpdateStudent(_studentId, data);

            if (!isSuccess) MessageHelper.ShowError("Cập nhật không hành công", "Lỗi");

            MessageHelper.ShowSuccess("Cập nhật thông tin thành công", "Thành công");

            this.LoadDetailStudent(_studentId);

            gunaSave.Visible = false;

            lbFullName.Visible = true;
            gunaFullName.Visible = true;

            lbFirstName.Visible = false;
            gunaFirstName.Visible = false;
            lbLastName.Visible = false;
            gunaLastName.Visible = false;

            gunaEmail.ReadOnly = true;
            gunaEmail.Enabled = false;

            gunaGender.Visible = true;
            gunaBoy.Visible = false;
            gunaGirl.Visible = false;

            gunaAddress.ReadOnly = true;
            gunaAddress.Enabled = false;

            gunaBirth.Visible = true;
            gunaDate.Visible = false;

            gunaPhone.ReadOnly = true;
            gunaPhone.Enabled = false;
            gunaPhoneParent.ReadOnly = true;
            gunaPhoneParent.Enabled = false;
        }

        private void gunaFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập chữ cái và phím Backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void gunaPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as Guna2TextBox;

            if (txt == null) return;

            // Chặn mọi ký tự không phải số và không phải phím điều khiển (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Giới hạn tối đa 10 ký tự (chỉ tính khi người dùng đang gõ số)
            if (char.IsDigit(e.KeyChar))
            {
                if (txt.Text.Length >= 10)
                {
                    e.Handled = true; // Tràn 10 ký tự → không cho nhập nữa
                }
            }
        }

        private bool ValidateString(string? str, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            return true;
        }
    }
}
