using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static partial class WindowXCaption
    {
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
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(WindowXCaption), new PropertyMetadata(OnHeightChanged));

        private static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var windowX = d as WindowX;
            if (windowX == null)
                return;

            SetCaptionHeight(windowX, (double)e.NewValue);
        }
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
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(WindowXCaption));
        #endregion

        #region Background
        public static Brush GetBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackgroundProperty);
        }

        public static void SetBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackgroundProperty, value);
        }

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(WindowXCaption));
        #endregion

        #region Header
        public static object GetHeader(DependencyObject obj)
        {
            return (object)obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(WindowXCaption));
        #endregion

        #region HeaderPadding
        public static Thickness GetHeaderPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HeaderPaddingProperty);
        }

        public static void SetHeaderPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HeaderPaddingProperty, value);
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.RegisterAttached("HeaderPadding", typeof(Thickness), typeof(WindowXCaption));
        #endregion

        #region HorizontalHeaderAlignment
        public static HorizontalHeaderAlignment GetHorizontalHeaderAlignment(DependencyObject obj)
        {
            return (HorizontalHeaderAlignment)obj.GetValue(HorizontalHeaderAlignmentProperty);
        }

        public static void SetHorizontalHeaderAlignment(DependencyObject obj, HorizontalHeaderAlignment value)
        {
            obj.SetValue(HorizontalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("HorizontalHeaderAlignment", typeof(HorizontalHeaderAlignment), typeof(WindowXCaption));
        #endregion

        #region ExtendControl
        public static object GetExtendControl(DependencyObject obj)
        {
            return (object)obj.GetValue(ExtendControlProperty);
        }

        public static void SetExtendControl(DependencyObject obj, object value)
        {
            obj.SetValue(ExtendControlProperty, value);
        }

        public static readonly DependencyProperty ExtendControlProperty =
            DependencyProperty.RegisterAttached("ExtendControl", typeof(object), typeof(WindowXCaption));
        #endregion

        #region DisableCloseButton
        public static bool GetDisableCloseButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableCloseButtonProperty);
        }

        public static void SetDisableCloseButton(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableCloseButtonProperty, value);
        }

        public static readonly DependencyProperty DisableCloseButtonProperty =
            DependencyProperty.RegisterAttached("DisableCloseButton", typeof(bool), typeof(WindowXCaption));
        #endregion

        #region HideBasicButtons
        public static bool GetHideBasicButtons(DependencyObject obj)
        {
            return (bool)obj.GetValue(HideBasicButtonsProperty);
        }

        public static void SetHideBasicButtons(DependencyObject obj, bool value)
        {
            obj.SetValue(HideBasicButtonsProperty, value);
        }

        public static readonly DependencyProperty HideBasicButtonsProperty =
            DependencyProperty.RegisterAttached("HideBasicButtons", typeof(bool), typeof(WindowXCaption));
        #endregion

        #region ButtonStyle

        #region MinimizeButtonStyle
        public static Style GetMinimizeButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(MinimizeButtonStyleProperty);
        }

        public static void SetMinimizeButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(MinimizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty MinimizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("MinimizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region MaximizeButtonStyle
        public static Style GetMaximizeButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(MaximizeButtonStyleProperty);
        }

        public static void SetMaximizeButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(MaximizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty MaximizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("MaximizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region CloseButtonStyle
        public static Style GetCloseButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(CloseButtonStyleProperty);
        }

        public static void SetCloseButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(CloseButtonStyleProperty, value);
        }

        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.RegisterAttached("CloseButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region BackstageMinimizeButtonStyle
        public static Style GetBackstageMinimizeButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(BackstageMinimizeButtonStyleProperty);
        }

        public static void SetBackstageMinimizeButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(BackstageMinimizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty BackstageMinimizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("BackstageMinimizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region BackstageMaximizeButtonStyle
        public static Style GetBackstageMaximizeButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(BackstageMaximizeButtonStyleProperty);
        }

        public static void SetBackstageMaximizeButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(BackstageMaximizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty BackstageMaximizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("BackstageMaximizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region BackstageCloseButtonStyle
        public static Style GetBackstageCloseButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(BackstageCloseButtonStyleProperty);
        }

        public static void SetBackstageCloseButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(BackstageCloseButtonStyleProperty, value);
        }

        public static readonly DependencyProperty BackstageCloseButtonStyleProperty =
            DependencyProperty.RegisterAttached("BackstageCloseButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #endregion
    }
}
