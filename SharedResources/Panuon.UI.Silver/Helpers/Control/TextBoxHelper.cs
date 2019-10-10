using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TextBoxHelper
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
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(TextBoxHelper));
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
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(TextBoxHelper));
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
            DependencyProperty.RegisterAttached("HeaderWidth", typeof(string), typeof(TextBoxHelper), new PropertyMetadata("Auto"));
        #endregion

        #region IsClearButtonVisible
        public static bool GetIsClearButtonVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsClearButtonVisibleProperty);
        }

        public static void SetIsClearButtonVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsClearButtonVisibleProperty, value);
        }

        public static readonly DependencyProperty IsClearButtonVisibleProperty =
            DependencyProperty.RegisterAttached("IsClearButtonVisible", typeof(bool), typeof(TextBoxHelper));
        #endregion

        #region (Internal) TextBoxHook
        internal static bool GetTextBoxHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(TextBoxHookProperty);
        }

        internal static void SetTextBoxHook(DependencyObject obj, bool value)
        {
            obj.SetValue(TextBoxHookProperty, value);
        }

        internal static readonly DependencyProperty TextBoxHookProperty =
            DependencyProperty.RegisterAttached("TextBoxHook", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(OnTextBoxHookChanged));


        private static void OnTextBoxHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as TextBox;
            textbox.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(ClearButtonClicked));
            textbox.AddHandler(Button.ClickEvent, new RoutedEventHandler(ClearButtonClicked));
        }

        private static void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;

            if (button == null || button.Name != "PART_BtnClear")
                return;

            var textbox = sender as TextBox;

            if (textbox == null)
                return;

            textbox.Text = "";
        }


        #endregion
    }
}
