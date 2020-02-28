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
        #region Ctor
        static PasswordBoxHelper()
        {
            EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.GotFocusEvent, new RoutedEventHandler(OnPasswordBoxGotFocus));
            EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.LostFocusEvent, new RoutedEventHandler(OnPasswordBoxLostFocus));
        }

        #endregion

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

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            var newPassword = (string)e.NewValue;
            if (newPassword != passwordBox.Password)
                passwordBox.Password = newPassword;
        }
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

        #region IsWaiting
        public static bool GetIsWaiting(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(PasswordBoxHelper));
        #endregion

        #region ValidationErrorTips
        public static string GetValidationErrorTips(PasswordBox passwordBox)
        {
            return (string)passwordBox.GetValue(ValidationErrorTipsProperty);
        }

        public static void SetValidationErrorTips(PasswordBox passwordBox, string value)
        {
            passwordBox.SetValue(ValidationErrorTipsProperty, value);
        }

        public static readonly DependencyProperty ValidationErrorTipsProperty =
            DependencyProperty.RegisterAttached("ValidationErrorTips", typeof(string), typeof(PasswordBoxHelper));
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

        #region (Internal) ClearPasswordBoxCommand
        internal static ICommand GetClearPasswordBoxCommand(PasswordBox passwordBox)
        {
            return (ICommand)passwordBox.GetValue(ClearPasswordBoxCommandProperty);
        }

        internal static void SetClearPasswordBoxCommand(PasswordBox passwordBox, ICommand value)
        {
            passwordBox.SetValue(ClearPasswordBoxCommandProperty, value);
        }

        internal static readonly DependencyProperty ClearPasswordBoxCommandProperty =
            DependencyProperty.RegisterAttached("ClearPasswordBoxCommand", typeof(ICommand), typeof(PasswordBoxHelper), new PropertyMetadata(new RelayCommand(OnClearPasswordBoxCommandExecute)));

        #endregion

        #region (Internal) PasswordBoxHook
        public static bool GetPasswordBoxHook(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(PasswordBoxHookProperty);
        }

        public static void SetPasswordBoxHook(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(PasswordBoxHookProperty, value);
        }

        public static readonly DependencyProperty PasswordBoxHookProperty =
            DependencyProperty.RegisterAttached("PasswordBoxHook", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(OnPasswordBoxHookChanged));

        private static void OnPasswordBoxHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
            if ((bool)e.NewValue)
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            SetPassword(passwordBox, passwordBox.Password);
        }
        #endregion
        #endregion

        #region Event Handler

       
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

            StoryboardUtils.BeginBrushStoryboard(passwordBox, dic);
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

            StoryboardUtils.BeginBrushStoryboard(passwordBox, list);
        }

        private static void OnClearPasswordBoxCommandExecute(object obj)
        {
            var passwordBox = (obj as PasswordBox);
            passwordBox.Password = null;
        }

        #endregion
    }
}
