using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class IconHelper
    {
        #region Properties

        #region Margin
        public static Thickness GetMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(MarginProperty);
        }

        public static void SetMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(MarginProperty, value);
        }

        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.RegisterAttached("Margin", typeof(Thickness), typeof(IconHelper), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region Width
        public static double GetWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthProperty);
        }

        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached("Width", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region Height
        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }

        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region MinHeight
        public static double GetMinHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(MinHeightProperty);
        }

        public static void SetMinHeight(DependencyObject obj, double value)
        {
            obj.SetValue(MinHeightProperty, value);
        }

        public static readonly DependencyProperty MinHeightProperty =
            DependencyProperty.RegisterAttached("MinHeight", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region MinWidth
        public static double GetMinWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(MinWidthProperty);
        }

        public static void SetMinWidth(DependencyObject obj, double value)
        {
            obj.SetValue(MinWidthProperty, value);
        }

        public static readonly DependencyProperty MinWidthProperty =
            DependencyProperty.RegisterAttached("MinWidth", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region MaxHeight
        public static double GetMaxHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(MaxHeightProperty);
        }

        public static void SetMaxHeight(DependencyObject obj, double value)
        {
            obj.SetValue(MaxHeightProperty, value);
        }

        public static readonly DependencyProperty MaxHeightProperty =
            DependencyProperty.RegisterAttached("MaxHeight", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region MaxWidth
        public static double GetMaxWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(MaxWidthProperty);
        }

        public static void SetMaxWidth(DependencyObject obj, double value)
        {
            obj.SetValue(MaxWidthProperty, value);
        }

        public static readonly DependencyProperty MaxWidthProperty =
            DependencyProperty.RegisterAttached("MaxWidth", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(double.PositiveInfinity, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region FontSize
        public static double GetFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(FontSizeProperty);
        }

        public static void SetFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.RegisterAttached("FontSize", typeof(double), typeof(IconHelper), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

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
            DependencyProperty.RegisterAttached("FontFamily", typeof(FontFamily), typeof(IconHelper), new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.Inherits));
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
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(IconHelper), new PropertyMetadata(Brushes.Black));
        #endregion
        #endregion
    }
}
