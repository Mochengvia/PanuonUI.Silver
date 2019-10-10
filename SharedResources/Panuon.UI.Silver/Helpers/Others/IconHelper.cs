using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class IconHelper
    {
        #region FontFamily
        public static FontFamily GetFontFamily(DependencyObject obj)
        {
            return (FontFamily)obj.GetValue(FontFamilyProperty);
        }

        public static void SetFontFamily(DependencyObject obj, FontFamily value)
        {
            obj.SetValue(FontFamilyProperty, value);
        }

        public static readonly DependencyProperty FontFamilyProperty =
            DependencyProperty.RegisterAttached("FontFamily", typeof(FontFamily), typeof(IconHelper));
        #endregion

        #region FontSize
        public static int GetFontSize(DependencyObject obj)
        {
            return (int)obj.GetValue(FontSizeProperty);
        }

        public static void SetFontSize(DependencyObject obj, int value)
        {
            obj.SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.RegisterAttached("FontSize", typeof(int), typeof(IconHelper));
        #endregion

        #region Foreground
        public static Brush GetForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ForegroundProperty);
        }

        public static void SetForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(IconHelper));
        #endregion

        #region Width
        public static string GetWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(WidthProperty);
        }

        public static void SetWidth(DependencyObject obj, string value)
        {
            obj.SetValue(WidthProperty, value);
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached("Width", typeof(string), typeof(IconHelper));
        #endregion
    }
}
