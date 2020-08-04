using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class PasswordBoxHelper
    {
        #region Properties

        #region Icon
        public static object GetIcon(PasswordBox passwordBox)
        {
            return (object)passwordBox.GetValue(IconProperty);
        }

        public static void SetIcon(PasswordBox passwordBox, object value)
        {
            passwordBox.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(PasswordBoxHelper));
        #endregion

        #region Password
        public static string GetPassword(PasswordBox passwordBox)
        {
            return (string)passwordBox.GetValue(PasswordProperty);
        }

        public static void SetPassword(PasswordBox passwordBox, string value)
        {
            passwordBox.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));
        #endregion

        #region FocusedBorderBrush
        public static Brush GetFocusedBorderBrush(PasswordBox passwordBox)
        {
            return (Brush)passwordBox.GetValue(FocusedBorderBrushProperty);
        }

        public static void SetFocusedBorderBrush(PasswordBox passwordBox, Brush value)
        {
            passwordBox.SetValue(FocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(PasswordBoxHelper));
        #endregion

        #region FocusedShadowColor
        public static Color? GetFocusedShadowColor(PasswordBox passwordBox)
        {
            return (Color?)passwordBox.GetValue(FocusedShadowColorProperty);
        }

        public static void SetFocusedShadowColor(PasswordBox passwordBox, Color? value)
        {
            passwordBox.SetValue(FocusedShadowColorProperty, value);
        }
        public static readonly DependencyProperty FocusedShadowColorProperty =
            DependencyProperty.RegisterAttached("FocusedShadowColor", typeof(Color?), typeof(PasswordBoxHelper));
        #endregion

        #region FocusedCaretBrush
        public static Brush GetFocusedCaretBrush(PasswordBox passwordBox)
        {
            return (Brush)passwordBox.GetValue(FocusedCaretBrushProperty);
        }

        public static void SetFocusedCaretBrush(PasswordBox passwordBox, Brush value)
        {
            passwordBox.SetValue(FocusedCaretBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedCaretBrushProperty =
            DependencyProperty.RegisterAttached("FocusedCaretBrush", typeof(Brush), typeof(PasswordBoxHelper));
        #endregion

        #region FocusedForeground
        public static Brush GetFocusedForeground(PasswordBox passwordBox)
        {
            return (Brush)passwordBox.GetValue(FocusedForegroundProperty);
        }

        public static void SetFocusedForeground(PasswordBox passwordBox, Brush value)
        {
            passwordBox.SetValue(FocusedForegroundProperty, value);
        }

        public static readonly DependencyProperty FocusedForegroundProperty =
            DependencyProperty.RegisterAttached("FocusedForeground", typeof(Brush), typeof(PasswordBoxHelper));
        #endregion

        #region Watermark
        public static string GetWatermark(PasswordBox passwordBox)
        {
            return (string)passwordBox.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(PasswordBox passwordBox, string value)
        {
            passwordBox.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(PasswordBoxHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(PasswordBox passwordBox)
        {
            return (CornerRadius)passwordBox.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(PasswordBox passwordBox, CornerRadius value)
        {
            passwordBox.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(PasswordBoxHelper));
        #endregion

        #region CanClear
        public static bool GetCanClear(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(CanClearProperty);
        }

        public static void SetCanClear(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(CanClearProperty, value);
        }

        public static readonly DependencyProperty CanClearProperty =
            DependencyProperty.RegisterAttached("CanClear", typeof(bool), typeof(PasswordBoxHelper));
        #endregion

        #region CanPlain
        public static bool GetCanPlain(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(CanPlainProperty);
        }

        public static void SetCanPlain(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(CanPlainProperty, value);
        }

        public static readonly DependencyProperty CanPlainProperty =
            DependencyProperty.RegisterAttached("CanPlain", typeof(bool), typeof(PasswordBoxHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region Hook
        internal static bool GetHook(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(HookProperty);
        }

        internal static void SetHook(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(HookProperty, value);
        }

        public static readonly DependencyProperty HookProperty =
            DependencyProperty.RegisterAttached("Hook", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(OnHookChanged));
        #endregion

        #region (Internal) ClearPasswordBoxCommand
        internal static readonly DependencyProperty ClearPasswordBoxCommandProperty =
            DependencyProperty.RegisterAttached("ClearPasswordBoxCommand", typeof(ICommand), typeof(PasswordBoxHelper), new PropertyMetadata(new RelayCommand(OnClearPasswordBoxCommandExecute)));
        #endregion

        #endregion

        #region Event Handler
        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            var newPassword = (string)e.NewValue;
            if (newPassword != passwordBox.Password)
            {
                passwordBox.Password = newPassword;
            }
        }

        private static void OnHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            passwordBox.GotFocus -= OnPasswordBoxGotFocus;
            passwordBox.LostFocus -= OnPasswordBoxLostFocus;
            passwordBox.PasswordChanged -= OnPasswordChanged;

            if ((bool)e.NewValue)
            {
                passwordBox.GotFocus += OnPasswordBoxGotFocus;
                passwordBox.LostFocus += OnPasswordBoxLostFocus;
                passwordBox.PasswordChanged += OnPasswordChanged; ;
            }
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            SetPassword(passwordBox, passwordBox.Password);
        }

        private static void OnPasswordBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var fcBorderBrush = GetFocusedBorderBrush(passwordBox);
            var fcForeground = GetFocusedForeground(passwordBox);

            if (fcBorderBrush == null && fcForeground == null)
                return;

            var dic = new Dictionary<DependencyProperty, Brush>();
            if (fcBorderBrush != null)
                dic.Add(PasswordBox.BorderBrushProperty, fcBorderBrush);
            if (fcForeground != null)
                dic.Add(PasswordBox.ForegroundProperty, fcForeground);

            UIElementUtils.BeginStoryboard(passwordBox, dic);
        }

        private static void OnPasswordBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var fcBorderBrush = GetFocusedBorderBrush(passwordBox);
            var fcForeground = GetFocusedForeground(passwordBox);

            if (fcBorderBrush == null && fcForeground == null)
                return;

            var list = new List<DependencyProperty>();
            if (fcBorderBrush != null)
                list.Add(PasswordBox.BorderBrushProperty);
            if (fcForeground != null)
                list.Add(PasswordBox.ForegroundProperty);

            UIElementUtils.BeginStoryboard(passwordBox, list);
        }

        private static void OnClearPasswordBoxCommandExecute(object passwordBox)
        {
            var textbox = (passwordBox as PasswordBox);
            textbox.Password = null;
        }
        #endregion
    }
}
