namespace BaiTapLonWinForm.View.Admin.Course
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            // ... (Lưu ý: WinForms sẽ tự sinh các customizableEdges này khi bạn lưu trong Designer, 
            // ở đây tôi tập trung vào cấu trúc thuộc tính Control)

            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeader = new System.Windows.Forms.Label();

            // Student Info Group
            this.pnlStudentInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStudentTitle = new System.Windows.Forms.Label();
            this.txtStudentCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtStudentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();

            // Class Info Group
            this.pnlClassInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblClassTitle = new System.Windows.Forms.Label();
            this.txtClassName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCourseName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTuition = new Guna.UI2.WinForms.Guna2TextBox();

            // Payment Info Group
            this.pnlPaymentInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.numDiscount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtDiscountReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.rbCash = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbTransfer = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbCard = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblTxnCode = new System.Windows.Forms.Label();
            this.txtTransactionCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFinalAmount = new System.Windows.Forms.Label();
            this.lblAmountDisplay = new System.Windows.Forms.Label();

            // Actions
            this.chkPrintReceipt = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlStudentInfo.SuspendLayout();
            this.pnlClassInfo.SuspendLayout();
            this.pnlPaymentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnPay);
            this.pnlMain.Controls.Add(this.chkPrintReceipt);
            this.pnlMain.Controls.Add(this.pnlPaymentInfo);
            this.pnlMain.Controls.Add(this.pnlClassInfo);
            this.pnlMain.Controls.Add(this.pnlStudentInfo);
            this.pnlMain.Controls.Add(this.lblHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Size = new System.Drawing.Size(640, 800);

            // lblHeader
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblHeader.Location = new System.Drawing.Point(20, 20);
            this.lblHeader.Text = "💳 THU HỌC PHÍ TẠI QUẦY";

            // pnlStudentInfo
            this.pnlStudentInfo.BorderRadius = 10;
            this.pnlStudentInfo.FillColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.pnlStudentInfo.Location = new System.Drawing.Point(20, 70);
            this.pnlStudentInfo.Size = new System.Drawing.Size(600, 140);
            this.pnlStudentInfo.Controls.Add(this.lblStudentTitle);
            this.pnlStudentInfo.Controls.Add(this.txtStudentCode);
            this.pnlStudentInfo.Controls.Add(this.txtStudentName);
            this.pnlStudentInfo.Controls.Add(this.txtPhone);

            this.lblStudentTitle.Text = "👤 THÔNG TIN HỌC VIÊN";
            this.lblStudentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStudentTitle.Location = new System.Drawing.Point(15, 10);

            ConfigureTextBox(this.txtStudentCode, "Mã HV", new System.Drawing.Point(15, 45), new System.Drawing.Size(270, 36), true);
            ConfigureTextBox(this.txtStudentName, "Họ tên", new System.Drawing.Point(305, 45), new System.Drawing.Size(280, 36), true);
            ConfigureTextBox(this.txtPhone, "SĐT", new System.Drawing.Point(15, 90), new System.Drawing.Size(270, 36), true);

            // pnlClassInfo
            this.pnlClassInfo.BorderRadius = 10;
            this.pnlClassInfo.FillColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.pnlClassInfo.Location = new System.Drawing.Point(20, 220);
            this.pnlClassInfo.Size = new System.Drawing.Size(600, 120);
            this.pnlClassInfo.Controls.Add(this.lblClassTitle);
            this.pnlClassInfo.Controls.Add(this.txtClassName);
            this.pnlClassInfo.Controls.Add(this.txtCourseName);
            this.pnlClassInfo.Controls.Add(this.txtTuition);

            this.lblClassTitle.Text = "📚 THÔNG TIN LỚP HỌC";
            this.lblClassTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblClassTitle.Location = new System.Drawing.Point(15, 10);

            ConfigureTextBox(this.txtClassName, "Lớp", new System.Drawing.Point(15, 45), new System.Drawing.Size(270, 36), true);
            ConfigureTextBox(this.txtTuition, "Học phí gốc", new System.Drawing.Point(305, 45), new System.Drawing.Size(280, 36), true);
            this.txtTuition.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            ConfigureTextBox(this.txtCourseName, "Khóa học", new System.Drawing.Point(15, 85), new System.Drawing.Size(570, 30), true);

            // pnlPaymentInfo
            this.pnlPaymentInfo.BorderRadius = 10;
            this.pnlPaymentInfo.FillColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.pnlPaymentInfo.Location = new System.Drawing.Point(20, 350);
            this.pnlPaymentInfo.Size = new System.Drawing.Size(600, 320);
            this.pnlPaymentInfo.Controls.Add(this.lblPaymentTitle);
            this.pnlPaymentInfo.Controls.Add(this.lblDiscount);
            this.pnlPaymentInfo.Controls.Add(this.numDiscount);
            this.pnlPaymentInfo.Controls.Add(this.txtDiscountReason);
            this.pnlPaymentInfo.Controls.Add(this.lblMethod);
            this.pnlPaymentInfo.Controls.Add(this.rbCash);
            this.pnlPaymentInfo.Controls.Add(this.rbTransfer);
            this.pnlPaymentInfo.Controls.Add(this.rbCard);
            this.pnlPaymentInfo.Controls.Add(this.lblTxnCode);
            this.pnlPaymentInfo.Controls.Add(this.txtTransactionCode);
            this.pnlPaymentInfo.Controls.Add(this.lblFinalAmount);
            this.pnlPaymentInfo.Controls.Add(this.lblAmountDisplay);

            this.lblPaymentTitle.Text = "💰 THÔNG TIN THANH TOÁN";
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.Location = new System.Drawing.Point(15, 10);

            this.lblDiscount.Text = "Giảm giá (%)";
            this.lblDiscount.Location = new System.Drawing.Point(15, 50);

            this.numDiscount.Location = new System.Drawing.Point(130, 45);
            this.numDiscount.Size = new System.Drawing.Size(80, 36);
            this.numDiscount.BorderRadius = 8;

            ConfigureTextBox(this.txtDiscountReason, "Lý do miễn giảm", new System.Drawing.Point(220, 45), new System.Drawing.Size(365, 36), false);

            this.lblMethod.Text = "Phương thức";
            this.lblMethod.Location = new System.Drawing.Point(15, 105);

            ConfigureRadio(this.rbCash, "Tiền mặt", new System.Drawing.Point(130, 102), true);
            ConfigureRadio(this.rbTransfer, "Chuyển khoản", new System.Drawing.Point(230, 102), false);
            ConfigureRadio(this.rbCard, "Quẹt thẻ", new System.Drawing.Point(360, 102), false);

            this.lblTxnCode.Text = "Mã giao dịch";
            this.lblTxnCode.Location = new System.Drawing.Point(15, 155);
            ConfigureTextBox(this.txtTransactionCode, "Nhập mã giao dịch ngân hàng", new System.Drawing.Point(130, 150), new System.Drawing.Size(455, 36), false);

            this.lblFinalAmount.Text = "TỔNG THỰC THU:";
            this.lblFinalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFinalAmount.Location = new System.Drawing.Point(15, 260);

            this.lblAmountDisplay.Text = "0 VNĐ";
            this.lblAmountDisplay.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAmountDisplay.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblAmountDisplay.Location = new System.Drawing.Point(250, 250);
            this.lblAmountDisplay.Size = new System.Drawing.Size(335, 50);
            this.lblAmountDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // chkPrintReceipt
            this.chkPrintReceipt.Text = "In hóa đơn sau khi xác nhận";
            this.chkPrintReceipt.Location = new System.Drawing.Point(35, 680);
            this.chkPrintReceipt.Checked = true;

            // btnPay
            this.btnPay.Text = "XÁC NHẬN THANH TOÁN";
            this.btnPay.FillColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(380, 720);
            this.btnPay.Size = new System.Drawing.Size(240, 50);
            this.btnPay.BorderRadius = 10;

            // btnCancel
            this.btnCancel.Text = "HỦY BỎ";
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 720);
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.BorderRadius = 10;

            // Final Form Setup
            this.ClientSize = new System.Drawing.Size(640, 800);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Thu học phí";

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlStudentInfo.ResumeLayout(false);
            this.pnlClassInfo.ResumeLayout(false);
            this.pnlPaymentInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
        }

        // Helper Methods để code Designer gọn hơn
        private void ConfigureTextBox(Guna.UI2.WinForms.Guna2TextBox txt, string placeholder, System.Drawing.Point loc, System.Drawing.Size size, bool readOnly)
        {
            txt.PlaceholderText = placeholder;
            txt.Location = loc;
            txt.Size = size;
            txt.ReadOnly = readOnly;
            txt.BorderRadius = 8;
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
        }

        private void ConfigureRadio(Guna.UI2.WinForms.Guna2RadioButton rb, string text, System.Drawing.Point loc, bool checkedState)
        {
            rb.Text = text;
            rb.Location = loc;
            rb.Checked = checkedState;
            rb.Font = new System.Drawing.Font("Segoe UI", 10F);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlStudentInfo;
        private System.Windows.Forms.Label lblStudentTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtStudentCode;
        private Guna.UI2.WinForms.Guna2TextBox txtStudentName;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2Panel pnlClassInfo;
        private System.Windows.Forms.Label lblClassTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtClassName;
        private Guna.UI2.WinForms.Guna2TextBox txtCourseName;
        private Guna.UI2.WinForms.Guna2TextBox txtTuition;
        private Guna.UI2.WinForms.Guna2Panel pnlPaymentInfo;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Label lblDiscount;
        private Guna.UI2.WinForms.Guna2NumericUpDown numDiscount;
        private Guna.UI2.WinForms.Guna2TextBox txtDiscountReason;
        private System.Windows.Forms.Label lblFinalAmount;
        private System.Windows.Forms.Label lblAmountDisplay;
        private System.Windows.Forms.Label lblMethod;
        private Guna.UI2.WinForms.Guna2RadioButton rbCash;
        private Guna.UI2.WinForms.Guna2RadioButton rbTransfer;
        private Guna.UI2.WinForms.Guna2RadioButton rbCard;
        private System.Windows.Forms.Label lblTxnCode;
        private Guna.UI2.WinForms.Guna2TextBox txtTransactionCode;
        private Guna.UI2.WinForms.Guna2CheckBox chkPrintReceipt;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}