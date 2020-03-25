using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class PasswordBoxHelper
    {
        #region FocusedBorderBrush
        public static Brush GetFocusedBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusedBorderBrushProperty);
        }

        public static void SetFocusedBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(PasswordBoxHelper));
        #endregion

        #region FocusedShadowColor
        public static Color? GetFocusedShadowColor(DependencyObject obj)
        {
            return (Color?)obj.GetValue(FocusedShadowColorProperty);
        }

        public static void SetFocusedShadowColor(DependencyObject obj, Color? value)
        {
            obj.SetValue(FocusedShadowColorProperty, value);
        }

        public static readonly DependencyProperty FocusedShadowColorProperty =
            DependencyProperty.RegisterAttached("FocusedShadowColor", typeof(Color?), typeof(PasswordBoxHelper));

        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(PasswordBoxHelper));
        #endregion

        #region Icon
        public static object GetIcon(DependencyObject obj)
        {
            return obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(PasswordBoxHelper));
        #endregion

        #region Watermark
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(PasswordBoxHelper));


        #endregion

        #region Password
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as System.Windows.Controls.PasswordBox;
            var password = e.NewValue as string;

            if (password != passwordBox.Password)
            {
                passwordBox.Password = password;
            }

        }
        #endregion

        #region Header
        public static object GetHeader(DependencyObject obj)
        {
            return obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(PasswordBoxHelper));
        #endregion

        #region HeaderWidth
        public static string GetHeaderWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderWidthProperty);
        }

        public static void SetHeaderWidth(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderWidthProperty, value);
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.RegisterAttached("HeaderWidth", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata("Auto"));
        #endregion

        #region IsShowPwdButtonVisible
        public static bool GetIsShowPwdButtonVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsShowPwdButtonVisibleProperty);
        }

        public static void SetIsShowPwdButtonVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsShowPwdButtonVisibleProperty, value);
        }

        public static readonly DependencyProperty IsShowPwdButtonVisibleProperty =
            DependencyProperty.RegisterAttached("IsShowPwdButtonVisible", typeof(bool), typeof(PasswordBoxHelper));
        #endregion

        #region (Internal) PasswordHook (Default is true)
        internal static bool GetPasswordHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(PasswordHookProperty);
        }

        internal static void SetPasswordHook(DependencyObject obj, bool value)
        {
            obj.SetValue(PasswordHookProperty, value);
        }

        internal static readonly DependencyProperty PasswordHookProperty =
            DependencyProperty.RegisterAttached("PasswordHook", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(OnPasswordHookChanged));

        private static void OnPasswordHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as System.Windows.Controls.PasswordBox;
            if (!passwordBox.Password.IsNullOrEmpty())
                SetPassword(passwordBox, passwordBox.Password);
            passwordBox.PasswordChanged += new RoutedEventHandler(PasswordBox_PasswordChanged);
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as System.Windows.Controls.PasswordBox;
            SetPassword(passwordBox, passwordBox.Password);
        }
        #endregion
    }
}
