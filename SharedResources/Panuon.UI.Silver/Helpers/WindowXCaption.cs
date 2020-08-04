using Panuon.UI.Silver.Utils;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class WindowXCaption
    {
        #region Height
        public static double GetHeight(WindowX windowX)
        {
            return (double)windowX.GetValue(HeightProperty);
        }

        public static void SetHeight(WindowX windowX, double value)
        {
            windowX.SetValue(HeightProperty, value);
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(WindowXCaption), new PropertyMetadata(OnHeightChanged));

        private static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var windowX = d as WindowX;
            if (windowX == null)
                return;

            WindowChromeUtils.SetCaptionHeight(windowX, (double)e.NewValue);
        }
        #endregion

        #region Foreground
        public static Brush GetForeground(WindowX windowX)
        {
            return (Brush)windowX.GetValue(ForegroundProperty);
        }

        public static void SetForeground(WindowX windowX, Brush value)
        {
            windowX.SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(WindowXCaption));
        #endregion

        #region Background
        public static Brush GetBackground(WindowX windowX)
        {
            return (Brush)windowX.GetValue(BackgroundProperty);
        }

        public static void SetBackground(WindowX windowX, Brush value)
        {
            windowX.SetValue(BackgroundProperty, value);
        }

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(WindowXCaption));
        #endregion

        #region Header
        public static object GetHeader(WindowX windowX)
        {
            return (object)windowX.GetValue(HeaderProperty);
        }

        public static void SetHeader(WindowX windowX, object value)
        {
            windowX.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(WindowXCaption));
        #endregion

        #region HorizontalHeaderAlignment
        public static HorizontalHeaderAlignment GetHorizontalHeaderAlignment(WindowX windowX)
        {
            return (HorizontalHeaderAlignment)windowX.GetValue(HorizontalHeaderAlignmentProperty);
        }

        public static void SetHorizontalHeaderAlignment(WindowX windowX, HorizontalHeaderAlignment value)
        {
            windowX.SetValue(HorizontalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("HorizontalHeaderAlignment", typeof(HorizontalHeaderAlignment), typeof(WindowXCaption));
        #endregion

        #region ExtendControl
        public static object GetExtendControl(WindowX windowX)
        {
            return (object)windowX.GetValue(ExtendControlProperty);
        }

        public static void SetExtendControl(WindowX windowX, object value)
        {
            windowX.SetValue(ExtendControlProperty, value);
        }

        public static readonly DependencyProperty ExtendControlProperty =
            DependencyProperty.RegisterAttached("ExtendControl", typeof(object), typeof(WindowXCaption));
        #endregion

        #region Buttons
        public static CaptionButtons GetButtons(WindowX windowX)
        {
            return (CaptionButtons)windowX.GetValue(ButtonsProperty);
        }

        public static void SetButtons(WindowX windowX, CaptionButtons value)
        {
            windowX.SetValue(ButtonsProperty, value);
        }

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.RegisterAttached("Buttons", typeof(CaptionButtons), typeof(WindowXCaption));
        #endregion

        #region MinimizeButtonStyle
        public static Style GetMinimizeButtonStyle(WindowX windowX)
        {
            return (Style)windowX.GetValue(MinimizeButtonStyleProperty);
        }

        public static void SetMinimizeButtonStyle(WindowX windowX, Style value)
        {
            windowX.SetValue(MinimizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty MinimizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("MinimizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region MaximizeButtonStyle
        public static Style GetMaximizeButtonStyle(WindowX windowX)
        {
            return (Style)windowX.GetValue(MaximizeButtonStyleProperty);
        }

        public static void SetMaximizeButtonStyle(WindowX windowX, Style value)
        {
            windowX.SetValue(MaximizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty MaximizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("MaximizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region CloseButtonStyle
        public static Style GetCloseButtonStyle(WindowX windowX)
        {
            return (Style)windowX.GetValue(CloseButtonStyleProperty);
        }

        public static void SetCloseButtonStyle(WindowX windowX, Style value)
        {
            windowX.SetValue(CloseButtonStyleProperty, value);
        }

        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.RegisterAttached("CloseButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region BackstageMinimizeButtonStyle
        public static Style GetBackstageMinimizeButtonStyle(WindowX windowX)
        {
            return (Style)windowX.GetValue(BackstageMinimizeButtonStyleProperty);
        }

        public static void SetBackstageMinimizeButtonStyle(WindowX windowX, Style value)
        {
            windowX.SetValue(BackstageMinimizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty BackstageMinimizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("BackstageMinimizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region BackstageMaximizeButtonStyle
        public static Style GetBackstageMaximizeButtonStyle(WindowX windowX)
        {
            return (Style)windowX.GetValue(BackstageMaximizeButtonStyleProperty);
        }

        public static void SetBackstageMaximizeButtonStyle(WindowX windowX, Style value)
        {
            windowX.SetValue(BackstageMaximizeButtonStyleProperty, value);
        }

        public static readonly DependencyProperty BackstageMaximizeButtonStyleProperty =
            DependencyProperty.RegisterAttached("BackstageMaximizeButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

        #region BackstageCloseButtonStyle
        public static Style GetBackstageCloseButtonStyle(WindowX windowX)
        {
            return (Style)windowX.GetValue(BackstageCloseButtonStyleProperty);
        }

        public static void SetBackstageCloseButtonStyle(WindowX windowX, Style value)
        {
            windowX.SetValue(BackstageCloseButtonStyleProperty, value);
        }

        public static readonly DependencyProperty BackstageCloseButtonStyleProperty =
            DependencyProperty.RegisterAttached("BackstageCloseButtonStyle", typeof(Style), typeof(WindowXCaption));
        #endregion

    }
}
