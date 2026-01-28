using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace BaiTapLonWinForm.CoreSystem
{
    public static class LanguageManager
    {
        public static event EventHandler LanguageChanged;

        public static string CurrentLanguage
        {
            get => Properties.Settings.Default.Language ?? "vi";
            private set
            {
                Properties.Settings.Default.Language = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void ApplyLanguage(string language)
        {
            try
            {
                CultureInfo culture;

                switch (language.ToLower())
                {
                    case "tiếng việt":
                    case "vietnamese":
                    case "vi":
                        culture = new CultureInfo("vi-VN");
                        CurrentLanguage = "vi";
                        break;
                    case "english":
                    case "en":
                        culture = new CultureInfo("en-US");
                        CurrentLanguage = "en";
                        break;
                    default:
                        culture = new CultureInfo("vi-VN");
                        CurrentLanguage = "vi";
                        break;
                }

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                // CHỈ đổi Text - KHÔNG touch màu
                UpdateAllFormsText();

                LanguageChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng ngôn ngữ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void UpdateAllFormsText()
        {
            foreach (Form form in Application.OpenForms)
            {
                UpdateFormText(form);
            }
        }

        private static void UpdateFormText(Form form)
        {
            try
            {
                var resources = new ResourceManager(form.GetType());
                UpdateControlText(form, resources);
            }
            catch
            {
                // Form không có resource file
            }
        }

        private static void UpdateControlText(Control control, ResourceManager resources)
        {
            try
            {
                // CHỈ lấy Text, KHÔNG dùng ApplyResources
                string textKey = $"{control.Name}.Text";
                string text = resources.GetString(textKey, Thread.CurrentThread.CurrentUICulture);

                if (!string.IsNullOrEmpty(text))
                {
                    control.Text = text;
                }
            }
            catch
            {
                // Control không có text trong resource
            }

            // Đệ quy cho các control con
            foreach (Control child in control.Controls)
            {
                UpdateControlText(child, resources);
            }
        }

        public static void Initialize()
        {
            string savedLanguage = CurrentLanguage;
            CultureInfo culture = savedLanguage == "vi"
                ? new CultureInfo("vi-VN")
                : new CultureInfo("en-US");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}