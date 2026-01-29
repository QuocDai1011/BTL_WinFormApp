using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiTapLonWinForm.CoreSystem
{
    public static class ThemeManager
    {
        public static event EventHandler ThemeChanged;

        // Theme colors - Cải tiến màu sắc đẹp hơn
        public static class DarkTheme
        {
            public static readonly Color Background = Color.FromArgb(30, 30, 30);
            public static readonly Color Surface = Color.FromArgb(40, 40, 40);
            public static readonly Color Sidebar = Color.FromArgb(35, 39, 42);
            public static readonly Color SidebarHover = Color.White;
            public static readonly Color Primary = Color.FromArgb(0, 122, 204);
            public static readonly Color PrimaryHover = Color.FromArgb(0, 102, 180);
            public static readonly Color Secondary = Color.FromArgb(99, 110, 114);
            public static readonly Color TextPrimary = Color.FromArgb(255, 255, 255);
            public static readonly Color TextSecondary = Color.FromArgb(200, 200, 200);
            public static readonly Color Border = Color.FromArgb(60, 63, 65);
            public static readonly Color Input = Color.FromArgb(50, 50, 50);
            public static readonly Color Success = Color.FromArgb(76, 175, 80);
            public static readonly Color Warning = Color.FromArgb(255, 152, 0);
            public static readonly Color Error = Color.FromArgb(244, 67, 54);
            public static readonly Color Info = Color.FromArgb(33, 150, 243);
        }

        public static class LightTheme
        {
            public static readonly Color Background = Color.FromArgb(250, 250, 250);
            public static readonly Color Surface = Color.White;
            public static readonly Color Sidebar = Color.FromArgb(41, 128, 185);
            public static readonly Color SidebarHover = Color.FromArgb(52, 152, 219);
            public static readonly Color Primary = Color.FromArgb(52, 152, 219);
            public static readonly Color PrimaryHover = Color.FromArgb(41, 128, 185);
            public static readonly Color Secondary = Color.FromArgb(149, 165, 166);
            public static readonly Color TextPrimary = Color.FromArgb(33, 33, 33);
            public static readonly Color TextSecondary = Color.FromArgb(117, 117, 117);
            public static readonly Color Border = Color.FromArgb(224, 224, 224);
            public static readonly Color Input = Color.White;
            public static readonly Color Success = Color.FromArgb(76, 175, 80);
            public static readonly Color Warning = Color.FromArgb(255, 152, 0);
            public static readonly Color Error = Color.FromArgb(244, 67, 54);
            public static readonly Color Info = Color.FromArgb(33, 150, 243);
        }

        public static string CurrentTheme
        {
            get => Properties.Settings.Default.Theme ?? "light";
            set
            {
                Properties.Settings.Default.Theme = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool IsDarkMode => CurrentTheme.ToLower() == "dark";

        public static void ApplyTheme(string theme)
        {
            try
            {
                bool isDarkMode = theme.ToLower().Contains("tối") ||
                                 theme.ToLower().Contains("dark") ||
                                 theme.ToLower().Contains("tăm");

                CurrentTheme = isDarkMode ? "dark" : "light";
                ApplyThemeToAllForms(isDarkMode);
                ThemeChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng theme: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ApplyThemeToAllForms(bool isDarkMode)
        {
            foreach (Form form in Application.OpenForms)
            {
                ApplyThemeToForm(form, isDarkMode);
            }
        }

        public static void ApplyThemeToForm(Form form, bool isDarkMode)
        {
            form.BackColor = isDarkMode ? DarkTheme.Background : LightTheme.Background;
            form.ForeColor = isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary;

            ApplyThemeToControl(form, isDarkMode);
            form.Invalidate();
            form.Refresh();
        }

        private static void ApplyThemeToControl(Control control, bool isDarkMode)
        {
            if (control is UserControl)
            {
                return; 
            }

            if (control is PictureBox)
            {
                return;
            }

            if (control is DataGridView || control.GetType().Name.Contains("DataGridView"))
            {
                return;
            }

            if (IsInsideDataGridView(control))
            {
                return;
            }

            string controlName = control.Name?.ToLower() ?? "";
            string controlType = control.GetType().Name;

            // SIDEBAR - Xử lý đặc biệt
            if (controlName.Contains("sidebar") ||
                controlName.Contains("panel") && controlName.Contains("left") ||
                controlName.Contains("menu") ||
                (control.Parent != null && (control.Parent.Name?.ToLower().Contains("sidebar") ?? false)))
            {
                ApplySidebarTheme(control, isDarkMode);

                foreach (Control child in control.Controls)
                {
                    if (child is DataGridView || child.GetType().Name.Contains("DataGridView"))
                    {
                        continue;
                    }
                    ApplyThemeToControl(child, isDarkMode);
                }
                return;
            }

            // Apply theme theo loại control
            if (controlType.Contains("Guna"))
            {
                ApplyGunaTheme(control, isDarkMode);
            }
            else if (control is Panel)
            {
                ApplyPanelTheme((Panel)control, isDarkMode);
            }
            else if (control is GroupBox)
            {
                ApplyGroupBoxTheme((GroupBox)control, isDarkMode);
            }
            else if (control is Button)
            {
                ApplyButtonTheme((Button)control, isDarkMode);
            }
            else if (control is TextBox)
            {
                ApplyTextBoxTheme((TextBox)control, isDarkMode);
            }
            else if (control is ComboBox)
            {
                ApplyComboBoxTheme((ComboBox)control, isDarkMode);
            }
            else if (control is Label)
            {
                ApplyLabelTheme((Label)control, isDarkMode);
            }

            foreach (Control child in control.Controls)
            {
                if (child is UserControl ||
                    child is DataGridView ||
                    child.GetType().Name.Contains("DataGridView"))
                {
                    continue;
                }
                ApplyThemeToControl(child, isDarkMode);
            }
        }

        #region Apply Theme Methods

        private static void ApplySidebarTheme(Control control, bool isDarkMode)
        {
            Color bgColor = isDarkMode ? DarkTheme.Sidebar : LightTheme.Sidebar;
            Color textColor =Color.White; // text trong sidebar luôn là màu trắng

            control.BackColor = bgColor;
            control.ForeColor = textColor;

            if (control is Label lbl)
            {
                lbl.ForeColor = Color.White; // Sidebar luôn dùng text trắng
                lbl.BackColor = Color.Transparent;
            }
            // Nếu là button trong sidebar
            if (control is Button btn)
            {
                btn.BackColor = bgColor;
                btn.ForeColor = textColor;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = isDarkMode ? DarkTheme.SidebarHover : LightTheme.SidebarHover;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(15, 0, 0, 0);
            }

            // Nếu là Guna2Button trong sidebar
            var type = control.GetType();
            if (type.Name.Contains("Guna2Button"))
            {
                SetGunaProperty(control, "FillColor", bgColor);
                SetGunaProperty(control, "ForeColor", textColor);
                SetGunaProperty(control, "BorderRadius", 0);
                SetGunaProperty(control, "BorderThickness", 0);
                SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? DarkTheme.SidebarHover : LightTheme.SidebarHover);
                SetGunaProperty(control, "TextAlign", System.Drawing.ContentAlignment.MiddleLeft);
                SetGunaProperty(control, "TextOffset", new Point(10, 0));
            }

            // Panel trong sidebar
            if (control is Panel)
            {
                control.BackColor = bgColor;
            }
        }

        private static void ApplyPanelTheme(Panel panel, bool isDarkMode)
        {
            panel.BackColor = isDarkMode ? DarkTheme.Background : LightTheme.Background;
            panel.ForeColor = isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary;
        }

        private static void ApplyGroupBoxTheme(GroupBox groupBox, bool isDarkMode)
        {
            groupBox.BackColor = isDarkMode ? DarkTheme.Surface : LightTheme.Surface;
            groupBox.ForeColor = isDarkMode ? DarkTheme.Primary : LightTheme.Primary;
        }

        private static void ApplyButtonTheme(Button button, bool isDarkMode)
        {
            button.BackColor = isDarkMode ? DarkTheme.Primary : LightTheme.Primary;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = isDarkMode ? DarkTheme.PrimaryHover : LightTheme.PrimaryHover;
            button.Cursor = Cursors.Hand;
        }

        private static void ApplyTextBoxTheme(TextBox textBox, bool isDarkMode)
        {
            textBox.BackColor = isDarkMode ? DarkTheme.Input : LightTheme.Input;
            textBox.ForeColor = isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary;
            textBox.BorderStyle = BorderStyle.None;
        }

        private static void ApplyComboBoxTheme(ComboBox comboBox, bool isDarkMode)
        {
            comboBox.BackColor = isDarkMode ? DarkTheme.Input : LightTheme.Input;
            comboBox.ForeColor = isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        

        private static void ApplyLabelTheme(Label label, bool isDarkMode)
        {
            // label trong sidebar luôn là màu trắng 
            if (IsInsideSidebar(label))
            {
                label.ForeColor = Color.White; // Sidebar luôn dùng màu trắng
                label.BackColor = Color.Transparent;
                return;
            }
            if (label.BackColor == Color.Transparent || label.Parent is GroupBox)
            {
                label.BackColor = Color.Transparent;
            }

            // Label lỗi (error) - màu đỏ
            if (label.Name.ToLower().Contains("err") || label.Name.ToLower().Contains("error"))
            {
                label.ForeColor = isDarkMode ? DarkTheme.Error : LightTheme.Error;
            }
            else if (label.Name.ToLower().Contains("title") ||
             label.Name.ToLower().Contains("header") ||
             label.Font.Size >= 14) // giữ màu xanh cho title và admin user
            {
                label.ForeColor = isDarkMode ? DarkTheme.Primary : LightTheme.Primary;
            }
            else
            {
                label.ForeColor = isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary;
            }
        }

        private static void ApplyGunaTheme(Control control, bool isDarkMode)
        {
            var type = control.GetType();
            string typeName = type.Name;

            // Guna2TextBox
            if (typeName.Contains("TextBox"))
            {
                SetGunaProperty(control, "FillColor", isDarkMode ? DarkTheme.Input : LightTheme.Input);
                SetGunaProperty(control, "ForeColor", isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary);
                SetGunaProperty(control, "BorderColor", isDarkMode ? Color.FromArgb(70, 70, 70) : Color.FromArgb(213, 218, 223));
                SetGunaProperty(control, "BorderThickness", 1);
                SetGunaProperty(control, "BorderRadius", 6);
                SetGunaProperty(control, "PlaceholderForeColor", isDarkMode ? DarkTheme.TextSecondary : LightTheme.TextSecondary);
                SetGunaProperty(control, "FocusedState.BorderColor", isDarkMode ? DarkTheme.Primary : LightTheme.Primary);
            }
            // Guna2ComboBox
            else if (typeName.Contains("ComboBox"))
            {
                SetGunaProperty(control, "FillColor", isDarkMode ? DarkTheme.Input : LightTheme.Input);
                SetGunaProperty(control, "ForeColor", isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary);
                SetGunaProperty(control, "BorderColor", isDarkMode ? Color.FromArgb(70, 70, 70) : Color.FromArgb(213, 218, 223));
                SetGunaProperty(control, "BorderThickness", 1);
                SetGunaProperty(control, "BorderRadius", 6);
                SetGunaProperty(control, "FocusedState.BorderColor", isDarkMode ? DarkTheme.Primary : LightTheme.Primary);

                // Dropdown style
                SetGunaProperty(control, "ItemsAppearance.BackColor", isDarkMode ? DarkTheme.Surface : Color.White);
                SetGunaProperty(control, "ItemsAppearance.ForeColor", isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary);
                SetGunaProperty(control, "ItemsAppearance.SelectedBackColor", isDarkMode ? DarkTheme.Primary : LightTheme.Primary);
                SetGunaProperty(control, "ItemsAppearance.SelectedForeColor", Color.White);
            }
            // Guna2Button
            else if (typeName.Contains("Button"))
            {
                string buttonName = control.Name?.ToLower() ?? "";

                // Button theo chức năng
                if (buttonName.Contains("save") || buttonName.Contains("update") || buttonName.Contains("apply") || buttonName.Contains("cap"))
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? Color.FromArgb(56, 142, 60) : Color.FromArgb(76, 175, 80));
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? Color.FromArgb(46, 125, 50) : Color.FromArgb(67, 160, 71));
                }
                else if (buttonName.Contains("delete") || buttonName.Contains("remove") || buttonName.Contains("xoa"))
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? Color.FromArgb(211, 47, 47) : Color.FromArgb(244, 67, 54));
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? Color.FromArgb(198, 40, 40) : Color.FromArgb(229, 57, 53));
                }
                else if (buttonName.Contains("change") || buttonName.Contains("edit") || buttonName.Contains("doi"))
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? Color.FromArgb(25, 118, 210) : Color.FromArgb(33, 150, 243));
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? Color.FromArgb(21, 101, 192) : Color.FromArgb(30, 136, 229));
                }
                else if (buttonName.Contains("them") || buttonName.Contains("add"))
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? Color.FromArgb(56, 142, 60) : Color.FromArgb(76, 175, 80));
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? Color.FromArgb(46, 125, 50) : Color.FromArgb(67, 160, 71));
                }
                else if (buttonName.Contains("search") || buttonName.Contains("tim"))
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? Color.FromArgb(66, 66, 66) : Color.FromArgb(97, 97, 97));
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? Color.FromArgb(77, 77, 77) : Color.FromArgb(117, 117, 117));
                }
                else if (buttonName.Contains("reset") || buttonName.Contains("tai"))
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? Color.FromArgb(251, 140, 0) : Color.FromArgb(255, 152, 0));
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? Color.FromArgb(245, 124, 0) : Color.FromArgb(251, 140, 0));
                }
                else
                {
                    SetGunaProperty(control, "FillColor", isDarkMode ? DarkTheme.Primary : LightTheme.Primary);
                    SetGunaProperty(control, "HoverState.FillColor", isDarkMode ? DarkTheme.PrimaryHover : LightTheme.PrimaryHover);
                }

                SetGunaProperty(control, "ForeColor", Color.White);
                SetGunaProperty(control, "BorderRadius", 8);
                SetGunaProperty(control, "BorderThickness", 0);
                SetGunaProperty(control, "Font", new Font("Segoe UI", 10F, FontStyle.Bold));
                control.Cursor = Cursors.Hand;
            }
            // Guna2GroupBox
            else if (typeName.Contains("GroupBox"))
            {
                SetGunaProperty(control, "FillColor", isDarkMode ? DarkTheme.Surface : LightTheme.Surface);
                SetGunaProperty(control, "CustomBorderColor", isDarkMode ? DarkTheme.Primary : LightTheme.Primary);
                SetGunaProperty(control, "ForeColor", isDarkMode ? Color.White : Color.FromArgb(44, 62, 80));
                SetGunaProperty(control, "BorderColor", isDarkMode ? DarkTheme.Border : LightTheme.Border);
                SetGunaProperty(control, "BorderRadius", 8);
                SetGunaProperty(control, "BorderThickness", 1);
                SetGunaProperty(control, "Font", new Font("Segoe UI", 11F, FontStyle.Bold));
            }
            // Guna2Panel
            else if (typeName.Contains("Panel"))
            {
                SetGunaProperty(control, "FillColor", isDarkMode ? DarkTheme.Background : LightTheme.Background);
                SetGunaProperty(control, "ForeColor", isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary);
                SetGunaProperty(control, "BorderRadius", 0);
            }
            // Guna2DateTimePicker
            else if (typeName.Contains("DateTimePicker"))
            {
                SetGunaProperty(control, "FillColor", isDarkMode ? DarkTheme.Input : LightTheme.Input);
                SetGunaProperty(control, "ForeColor", isDarkMode ? DarkTheme.TextPrimary : LightTheme.TextPrimary);
                SetGunaProperty(control, "BorderColor", isDarkMode ? Color.FromArgb(70, 70, 70) : Color.FromArgb(213, 218, 223));
                SetGunaProperty(control, "BorderThickness", 1);
                SetGunaProperty(control, "BorderRadius", 6);
                SetGunaProperty(control, "FocusedColor", isDarkMode ? DarkTheme.Primary : LightTheme.Primary);
            }
           
        }

        
        private static void SetGunaProperty(Control control, string propertyPath, object value)
        {
            try
            {
                var type = control.GetType();
                var properties = propertyPath.Split('.');

                object current = control;
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    var prop = current.GetType().GetProperty(properties[i]);
                    if (prop == null) return;
                    current = prop.GetValue(current);
                    if (current == null) return;
                }

                var finalProp = current.GetType().GetProperty(properties[properties.Length - 1]);
                if (finalProp != null && finalProp.CanWrite)
                {
                    finalProp.SetValue(current, value);
                }
            }
            catch { }
        }

        #endregion

        public static void Initialize()
        {
            string savedTheme = CurrentTheme;
            bool isDarkMode = savedTheme.ToLower() == "dark";
            ApplyThemeToAllForms(isDarkMode);
        }
        #region helper methods
        private static bool IsInsideSidebar(Control control)
        {
            Control parent = control.Parent;
            while (parent != null)
            {
                string parentName = parent.Name?.ToLower() ?? "";
                if (parentName.Contains("sidebar") ||
                    parentName.Contains("menu") ||
                    (parentName.Contains("panel") && parentName.Contains("left")))
                {
                    return true;
                }
                parent = parent.Parent;
            }
            return false;
        }
        private static bool IsInsideDataGridView(Control control)
        {
            Control parent = control.Parent;
            while (parent != null)
            {
                if (parent is DataGridView || parent.GetType().Name.Contains("DataGridView"))
                {
                    return true;
                }
                parent = parent.Parent;
            }
            return false;
        }
        #endregion
    }
}