namespace BaiTapLonWinForm.Views.Teacher.MyClass.MyExercise
{
    partial class ExerciseDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAddNew = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2ComboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
            flpnExerciseList = new FlowLayoutPanel();
            guna2GradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddNew
            // 
            btnAddNew.AutoRoundedCorners = true;
            btnAddNew.BackColor = Color.Transparent;
            btnAddNew.BorderColor = Color.Transparent;
            btnAddNew.BorderRadius = 23;
            btnAddNew.CustomizableEdges = customizableEdges1;
            btnAddNew.DisabledState.BorderColor = Color.DarkGray;
            btnAddNew.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddNew.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddNew.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnAddNew.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddNew.FillColor = Color.FromArgb(135, 237, 201);
            btnAddNew.FillColor2 = Color.Teal;
            btnAddNew.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnAddNew.Location = new Point(10, 10);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.PressedColor = SystemColors.GrayText;
            btnAddNew.ShadowDecoration.Color = SystemColors.ActiveCaptionText;
            btnAddNew.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddNew.ShadowDecoration.Depth = 15;
            btnAddNew.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnAddNew.ShadowDecoration.Shadow = new Padding(3, 3, 3, 7);
            btnAddNew.Size = new Size(172, 48);
            btnAddNew.TabIndex = 9;
            btnAddNew.Text = "Tạo bài tập";
            btnAddNew.Click += btnAddNew_Click;
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.CustomizableEdges = customizableEdges3;
            guna2ComboBox1.DisabledState.FillColor = Color.Gainsboro;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FocusedColor = Color.Transparent;
            guna2ComboBox1.FocusedState.BorderColor = Color.Transparent;
            guna2ComboBox1.FocusedState.FillColor = Color.Teal;
            guna2ComboBox1.FocusedState.ForeColor = Color.White;
            guna2ComboBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2ComboBox1.ForeColor = Color.Black;
            guna2ComboBox1.HoverState.FillColor = Color.Teal;
            guna2ComboBox1.HoverState.ForeColor = Color.White;
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Items.AddRange(new object[] { "Tiến độ chấm", "Chưa chấm xong", "Chưa nộp", "Đã nộp" });
            guna2ComboBox1.Location = new Point(1056, 16);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ComboBox1.Size = new Size(210, 36);
            guna2ComboBox1.StartIndex = 0;
            guna2ComboBox1.TabIndex = 10;
            guna2ComboBox1.Visible = false;
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(guna2DateTimePicker1);
            guna2GradientPanel1.Controls.Add(guna2ComboBox2);
            guna2GradientPanel1.Controls.Add(btnAddNew);
            guna2GradientPanel1.Controls.Add(guna2ComboBox1);
            guna2GradientPanel1.CustomizableEdges = customizableEdges9;
            guna2GradientPanel1.Dock = DockStyle.Top;
            guna2GradientPanel1.Location = new Point(0, 0);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2GradientPanel1.Size = new Size(1430, 81);
            guna2GradientPanel1.TabIndex = 11;
            // 
            // guna2DateTimePicker1
            // 
            guna2DateTimePicker1.Checked = true;
            guna2DateTimePicker1.CheckedState.FillColor = Color.Teal;
            guna2DateTimePicker1.CheckedState.ForeColor = Color.White;
            guna2DateTimePicker1.CustomizableEdges = customizableEdges5;
            guna2DateTimePicker1.FillColor = Color.White;
            guna2DateTimePicker1.FocusedColor = Color.Teal;
            guna2DateTimePicker1.Font = new Font("Segoe UI", 9F);
            guna2DateTimePicker1.Format = DateTimePickerFormat.Short;
            guna2DateTimePicker1.HoverState.FillColor = Color.Teal;
            guna2DateTimePicker1.HoverState.ForeColor = Color.White;
            guna2DateTimePicker1.Location = new Point(1281, 16);
            guna2DateTimePicker1.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            guna2DateTimePicker1.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            guna2DateTimePicker1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2DateTimePicker1.Size = new Size(146, 36);
            guna2DateTimePicker1.TabIndex = 12;
            guna2DateTimePicker1.Value = new DateTime(2026, 1, 22, 17, 47, 3, 946);
            guna2DateTimePicker1.Visible = false;
            // 
            // guna2ComboBox2
            // 
            guna2ComboBox2.BackColor = Color.Transparent;
            guna2ComboBox2.CustomizableEdges = customizableEdges7;
            guna2ComboBox2.DisabledState.FillColor = Color.Gainsboro;
            guna2ComboBox2.DisplayMember = "-1";
            guna2ComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox2.FocusedColor = Color.Transparent;
            guna2ComboBox2.FocusedState.BorderColor = Color.Transparent;
            guna2ComboBox2.FocusedState.FillColor = Color.Teal;
            guna2ComboBox2.FocusedState.ForeColor = Color.White;
            guna2ComboBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2ComboBox2.ForeColor = Color.Black;
            guna2ComboBox2.HoverState.FillColor = Color.Teal;
            guna2ComboBox2.HoverState.ForeColor = Color.White;
            guna2ComboBox2.ItemHeight = 30;
            guna2ComboBox2.Items.AddRange(new object[] { "Trạng thái bài tập", "Đang diễn ra", "Đã kết thúc", "Đã lên lịch" });
            guna2ComboBox2.Location = new Point(831, 16);
            guna2ComboBox2.Name = "guna2ComboBox2";
            guna2ComboBox2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2ComboBox2.Size = new Size(210, 36);
            guna2ComboBox2.StartIndex = 0;
            guna2ComboBox2.TabIndex = 11;
            guna2ComboBox2.Visible = false;
            // 
            // flpnExerciseList
            // 
            flpnExerciseList.AutoScroll = true;
            flpnExerciseList.Dock = DockStyle.Fill;
            flpnExerciseList.Location = new Point(0, 81);
            flpnExerciseList.Name = "flpnExerciseList";
            flpnExerciseList.Size = new Size(1430, 667);
            flpnExerciseList.TabIndex = 12;
            // 
            // ExerciseDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpnExerciseList);
            Controls.Add(guna2GradientPanel1);
            Name = "ExerciseDetail";
            Size = new Size(1430, 748);
            guna2GradientPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnAddNew;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox2;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private FlowLayoutPanel flpnExerciseList;
    }
}
