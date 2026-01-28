using System;
using System.Globalization;

namespace BaiTapLonWinForm.CoreSystem
{
    public static class SettingsManager
    {
        public static event EventHandler ThemeChanged
        {
            add => ThemeManager.ThemeChanged += value;
            remove => ThemeManager.ThemeChanged -= value;
        }


        #region Theme Management (SỬ DỤNG ThemeManager)

        public static string CurrentTheme => ThemeManager.CurrentTheme;

        public static void ApplyTheme(string theme)
        {
            ThemeManager.ApplyTheme(theme);
        }

        #endregion

        #region Initialization

        public static void LoadSettings()
        {
            // Load theme
            ThemeManager.Initialize();
        }

        #endregion
    }
}