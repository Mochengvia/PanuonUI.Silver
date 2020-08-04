using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TextBoxHelper
    {
        #region Properties

        #region Icon
        public static object GetIcon(TextBox textBox)
        {
            return (object)textBox.GetValue(IconProperty);
        }

        public static void SetIcon(TextBox textBox, object value)
        {
            textBox.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(TextBoxHelper));
        #endregion

        #region FocusedBorderBrush
        public static Brush GetFocusedBorderBrush(TextBox textBox)
        {
            return (Brush)textBox.GetValue(FocusedBorderBrushProperty);
        }

        public static void SetFocusedBorderBrush(TextBox textBox, Brush value)
        {
            textBox.SetValue(FocusedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(TextBoxHelper));
        #endregion

        #region FocusedShadowColor
        public static Color? GetFocusedShadowColor(TextBox textBox)
        {
            return (Color?)textBox.GetValue(FocusedShadowColorProperty);
        }

        public static void SetFocusedShadowColor(TextBox textBox, Color? value)
        {
            textBox.SetValue(FocusedShadowColorProperty, value);
        }
        public static readonly DependencyProperty FocusedShadowColorProperty =
            DependencyProperty.RegisterAttached("FocusedShadowColor", typeof(Color?), typeof(TextBoxHelper));
        #endregion

        #region FocusedCaretBrush
        public static Brush GetFocusedCaretBrush(TextBox textBox)
        {
            return (Brush)textBox.GetValue(FocusedCaretBrushProperty);
        }

        public static void SetFocusedCaretBrush(TextBox textBox, Brush value)
        {
            textBox.SetValue(FocusedCaretBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedCaretBrushProperty =
            DependencyProperty.RegisterAttached("FocusedCaretBrush", typeof(Brush), typeof(TextBoxHelper));
        #endregion

        #region FocusedForeground
        public static Brush GetFocusedForeground(TextBox textBox)
        {
            return (Brush)textBox.GetValue(FocusedForegroundProperty);
        }

        public static void SetFocusedForeground(TextBox textBox, Brush value)
        {
            textBox.SetValue(FocusedForegroundProperty, value);
        }

        public static readonly DependencyProperty FocusedForegroundProperty =
            DependencyProperty.RegisterAttached("FocusedForeground", typeof(Brush), typeof(TextBoxHelper));
        #endregion

        #region Watermark
        public static string GetWatermark(TextBox textBox)
        {
            return (string)textBox.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(TextBox textBox, string value)
        {
            textBox.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(TextBox textBox)
        {
            return (CornerRadius)textBox.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(TextBox textBox, CornerRadius value)
        {
            textBox.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(TextBoxHelper));
        #endregion

        #region CanClear
        public static bool GetCanClear(TextBox textBox)
        {
            return (bool)textBox.GetValue(CanClearProperty);
        }

        public static void SetCanClear(TextBox textBox, bool value)
        {
            textBox.SetValue(CanClearProperty, value);
        }

        public static readonly DependencyProperty CanClearProperty =
            DependencyProperty.RegisterAttached("CanClear", typeof(bool), typeof(TextBoxHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region Hook
        internal static bool GetHook(TextBox textBox)
        {
            return (bool)textBox.GetValue(HookProperty);
        }

        internal static void SetHook(TextBox textBox, bool value)
        {
            textBox.SetValue(HookProperty, value);
        }

        public static readonly DependencyProperty HookProperty =
            DependencyProperty.RegisterAttached("Hook", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(OnHookChanged));
        #endregion

        #region (Internal) ClearTextBoxCommand
        internal static readonly DependencyProperty ClearTextBoxCommandProperty =
            DependencyProperty.RegisterAttached("ClearTextBoxCommand", typeof(ICommand), typeof(TextBoxHelper), new PropertyMetadata(new RelayCommand(OnClearTextBoxCommandExecute)));
        #endregion

        #endregion

        #region Event Handler
        private static void OnHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            textBox.GotFocus -= OnTextBoxGotFocus;
            textBox.LostFocus -= OnTextBoxLostFocus;

            if ((bool)e.NewValue)
            {
                textBox.GotFocus += OnTextBoxGotFocus;
                textBox.LostFocus += OnTextBoxLostFocus;
            }
        }

        private static void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            var fcBorderBrush = GetFocusedBorderBrush(textBox);
            var fcForeground = GetFocusedForeground(textBox);

            if (fcBorderBrush == null && fcForeground == null)
                return;

            var dic = new Dictionary<DependencyProperty, Brush>();
            if (fcBorderBrush != null)
                dic.Add(TextBox.BorderBrushProperty, fcBorderBrush);
            if (fcForeground != null)
                dic.Add(TextBox.ForegroundProperty, fcForeground);

            UIElementUtils.BeginStoryboard(textBox, dic);
        }

        private static void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            var fcBorderBrush = GetFocusedBorderBrush(textBox);
            var fcForeground = GetFocusedForeground(textBox);

            if (fcBorderBrush == null && fcForeground == null)
                return;

            var list = new List<DependencyProperty>();
            if (fcBorderBrush != null)
                list.Add(TextBox.BorderBrushProperty);
            if (fcForeground != null)
                list.Add(TextBox.ForegroundProperty);

            UIElementUtils.BeginStoryboard(textBox, list);
        }

        private static void OnClearTextBoxCommandExecute(object textBox)
        {
            var textbox = (textBox as TextBox);
            textbox.Text = null;
        }
        #endregion
    }
}
