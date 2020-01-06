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

        #region Ctor
        static TextBoxHelper()
        {
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(OnTextBoxGotFocus));
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.LostFocusEvent, new RoutedEventHandler(OnTextBoxLostFocus));
        }
        #endregion

        #region Properties

        #region Icon
        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(TextBoxHelper));
        #endregion

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
            DependencyProperty.RegisterAttached("FocusedBorderBrush", typeof(Brush), typeof(TextBoxHelper));
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
            DependencyProperty.RegisterAttached("FocusedShadowColor", typeof(Color?), typeof(TextBoxHelper));
        #endregion

        #region FocusedCaretBrush
        public static Brush GetFocusedCaretBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusedCaretBrushProperty);
        }

        public static void SetFocusedCaretBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusedCaretBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedCaretBrushProperty =
            DependencyProperty.RegisterAttached("FocusedCaretBrush", typeof(Brush), typeof(TextBoxHelper));
        #endregion

        #region FocusedForeground
        public static Brush GetFocusedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(FocusedForegroundProperty);
        }

        public static void SetFocusedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(FocusedForegroundProperty, value);
        }

        public static readonly DependencyProperty FocusedForegroundProperty =
            DependencyProperty.RegisterAttached("FocusedForeground", typeof(Brush), typeof(TextBoxHelper));
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
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper));
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
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(TextBoxHelper));
        #endregion

        #region CanClear
        public static bool GetCanClear(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanClearProperty);
        }

        public static void SetCanClear(DependencyObject obj, bool value)
        {
            obj.SetValue(CanClearProperty, value);
        }

        public static readonly DependencyProperty CanClearProperty =
            DependencyProperty.RegisterAttached("CanClear", typeof(bool), typeof(TextBoxHelper));
        #endregion

        #region IsWaiting
        public static bool GetIsWaiting(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(DependencyObject obj, bool value)
        {
            obj.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(TextBoxHelper));
        #endregion

        #region ValidationErrorTips
        public static string GetValidationErrorTips(DependencyObject obj)
        {
            return (string)obj.GetValue(ValidationErrorTipsProperty);
        }

        public static void SetValidationErrorTips(DependencyObject obj, string value)
        {
            obj.SetValue(ValidationErrorTipsProperty, value);
        }

        public static readonly DependencyProperty ValidationErrorTipsProperty =
            DependencyProperty.RegisterAttached("ValidationErrorTips", typeof(string), typeof(TextBoxHelper));
        #endregion
        #endregion

        #region Internal Properties
        #region (Internal) ClearTextBoxCommand
        internal static ICommand GetClearTextBoxCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ClearTextBoxCommandProperty);
        }

        internal static void SetClearTextBoxCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ClearTextBoxCommandProperty, value);
        }

        internal static readonly DependencyProperty ClearTextBoxCommandProperty =
            DependencyProperty.RegisterAttached("ClearTextBoxCommand", typeof(ICommand), typeof(TextBoxHelper), new PropertyMetadata(new Command(OnClearTextBoxCommandExecute)));

        #endregion

        #endregion

        #region Event Handler

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

            StoryboardUtils.BeginStoryboard(textBox, dic);
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

            StoryboardUtils.BeginStoryboard(textBox, list);
        }

        private static void OnClearTextBoxCommandExecute(object obj)
        {
            var textbox = (obj as TextBox);
            textbox.Text = null;
        }
        #endregion

    }
}
