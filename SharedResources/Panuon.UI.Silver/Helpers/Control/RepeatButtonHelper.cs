using Panuon.UI.Silver.Utils;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class RepeatButtonHelper
    {
        #region RepeatButtonStyle
        public static RepeatButtonStyle GetRepeatButtonStyle(DependencyObject obj)
        {
            return (RepeatButtonStyle)obj.GetValue(RepeatButtonStyleProperty);
        }

        public static void SetRepeatButtonStyle(DependencyObject obj, RepeatButtonStyle value)
        {
            obj.SetValue(RepeatButtonStyleProperty, value);
        }

        public static readonly DependencyProperty RepeatButtonStyleProperty =
            DependencyProperty.RegisterAttached("RepeatButtonStyle", typeof(RepeatButtonStyle), typeof(RepeatButtonHelper), new PropertyMetadata(RepeatButtonStyle.Standard));
        #endregion

        #region ClickStyle
        public static ClickStyle GetClickStyle(DependencyObject obj)
        {
            return (ClickStyle)obj.GetValue(ClickStyleProperty);
        }

        public static void SetClickStyle(DependencyObject obj, ClickStyle value)
        {
            obj.SetValue(ClickStyleProperty, value);
        }

        public static readonly DependencyProperty ClickStyleProperty =
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(RepeatButtonHelper), new PropertyMetadata(ClickStyle.None));
        #endregion

        #region HoverBrush
        public static Brush GetHoverBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverBrushProperty);
        }

        public static void SetHoverBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(RepeatButtonHelper));
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
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(RepeatButtonHelper));
        #endregion

        #region ClickCoverOpacity
        public static double GetClickCoverOpacity(DependencyObject obj)
        {
            return (double)obj.GetValue(ClickCoverOpacityProperty);
        }

        public static void SetClickCoverOpacity(DependencyObject obj, double value)
        {
            obj.SetValue(ClickCoverOpacityProperty, value);
        }

        public static readonly DependencyProperty ClickCoverOpacityProperty =
            DependencyProperty.RegisterAttached("ClickCoverOpacity", typeof(double), typeof(RepeatButtonHelper));
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
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(RepeatButtonHelper));
        #endregion

        #region WaitingContent
        public static object GetWaitingContent(DependencyObject obj)
        {
            return obj.GetValue(WaitingContentProperty);
        }

        public static void SetWaitingContent(DependencyObject obj, object value)
        {
            obj.SetValue(WaitingContentProperty, value);
        }

        public static readonly DependencyProperty WaitingContentProperty =
            DependencyProperty.RegisterAttached("WaitingContent", typeof(object), typeof(RepeatButtonHelper));
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
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(RepeatButtonHelper));


        #endregion

        #region (Internal) HoverBrushPercent
        internal static double GetHoverBrushPercent(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverBrushPercentProperty);
        }

        internal static void SetHoverBrushPercent(DependencyObject obj, double value)
        {
            obj.SetValue(HoverBrushPercentProperty, value);
        }

        public static readonly DependencyProperty HoverBrushPercentProperty =
            DependencyProperty.RegisterAttached("HoverBrushPercent", typeof(double), typeof(RepeatButtonHelper), new PropertyMetadata(OnHoverBrushPercentChanged));

        private static void OnHoverBrushPercentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (RepeatButton)d;

            if (button == null)
                return;

            var buttonStyle = GetRepeatButtonStyle(button);

            var oldValue = (double)e.OldValue;
            var newValue = (double)e.NewValue;

            var previousForeground = GetPreviousForeground(button);
            var previousBorderBrush = GetPreviousBorderBrush(button);
            var previousBackground = GetPreviousBackground(button);

            var hoverBrush = GetHoverBrush(button);

            if (newValue == 0)
            {
                if (buttonStyle != RepeatButtonStyle.Standard)
                    button.Foreground = previousForeground;

                if (buttonStyle == RepeatButtonStyle.Standard || buttonStyle == RepeatButtonStyle.Hollow)
                    button.Background = previousBackground;

                button.BorderBrush = previousBorderBrush;
                return;
            }
            if (oldValue == 0)
            {
                previousForeground = button.Foreground;
                previousBorderBrush = button.BorderBrush;
                previousBackground = button.Background;

                SetPreviousForeground(button, previousForeground);
                SetPreviousBorderBrush(button, previousBorderBrush);
                SetPreviousBackground(button, previousBackground);
            }

            if (buttonStyle == RepeatButtonStyle.Standard || buttonStyle == RepeatButtonStyle.Hollow)
                button.Background = BrushUtils.GetBrush(newValue, previousBackground, hoverBrush);

            if (buttonStyle == RepeatButtonStyle.Hollow)
                button.Foreground = BrushUtils.GetBrush(newValue, previousForeground, Brushes.White);
            else if (buttonStyle != RepeatButtonStyle.Standard)
                button.Foreground = BrushUtils.GetBrush(newValue, previousForeground, hoverBrush);

            button.BorderBrush = BrushUtils.GetBrush(newValue, previousBorderBrush, hoverBrush);
        }
        #endregion

        #region (Internal) PreviousForeground
        internal static Brush GetPreviousForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PreviousForegroundProperty);
        }

        internal static void SetPreviousForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(PreviousForegroundProperty, value);
        }

        internal static readonly DependencyProperty PreviousForegroundProperty =
            DependencyProperty.RegisterAttached("PreviousForeground", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion

        #region (Internal) PreviousForeground
        public static Brush GetPreviousBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PreviousBorderBrushProperty);
        }

        public static void SetPreviousBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(PreviousBorderBrushProperty, value);
        }

        public static readonly DependencyProperty PreviousBorderBrushProperty =
            DependencyProperty.RegisterAttached("PreviousBorderBrush", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion

        #region (Internal) PreviousBackground
        public static Brush GetPreviousBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PreviousBackgroundProperty);
        }

        public static void SetPreviousBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(PreviousBackgroundProperty, value);
        }

        public static readonly DependencyProperty PreviousBackgroundProperty =
            DependencyProperty.RegisterAttached("PreviousBackground", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion
    }
}
