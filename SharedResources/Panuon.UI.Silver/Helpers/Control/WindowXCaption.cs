using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class WindowXCaption
    {
        #region Base


        public static Thickness GetPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(PaddingProperty);
        }

        public static void SetPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(PaddingProperty, value);
        }

        public static readonly DependencyProperty PaddingProperty =
            DependencyProperty.RegisterAttached("Padding", typeof(Thickness), typeof(WindowXCaption));


        /// <summary>
        /// Caption Height.
        /// </summary>
        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }

        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(WindowXCaption));


        /// <summary>
        /// Caption Foreground.
        /// </summary>
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

        /// <summary>
        /// Caption Background.
        /// </summary>
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

        #region Base Button Styles

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

        #region Rewrite Header
        /// <summary>
        /// Collapse icon and window title, rewrite new window header.
        /// </summary>
        public static object GetHeader(DependencyObject obj)
        {
            return obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(WindowXCaption));
        #endregion

        #region ExtendControl
        /// <summary>
        /// Caption Extend Control
        /// </summary>
        public static UIElement GetExtendControl(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(ExtendControlProperty);
        }

        public static void SetExtendControl(DependencyObject obj, UIElement value)
        {
            obj.SetValue(ExtendControlProperty, value);
        }

        public static readonly DependencyProperty ExtendControlProperty =
            DependencyProperty.RegisterAttached("ExtendControl", typeof(UIElement), typeof(WindowXCaption));
        #endregion

        #region Disable & Visibility

        /// <summary>
        /// Disable close button.
        /// </summary>
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


        /// <summary>
        /// Hide basic buttons (miximize , maximize and close)
        /// </summary>
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

    }
}
