using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class RepeatButtonHelper
    {
        #region Ctor
        static RepeatButtonHelper()
        {
            EventManager.RegisterClassHandler(typeof(RepeatButton), RepeatButton.MouseEnterEvent, new RoutedEventHandler(OnRepeatButtonMouseEnter));
            EventManager.RegisterClassHandler(typeof(RepeatButton), RepeatButton.MouseLeaveEvent, new RoutedEventHandler(OnRepeatButtonMouseLeave));
        }

        #endregion

        #region Properties

        #region Icon
        public static object GetIcon(RepeatButton repeatButton)
        {
            return (object)repeatButton.GetValue(IconProperty);
        }

        public static void SetIcon(RepeatButton repeatButton, object value)
        {
            repeatButton.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(RepeatButtonHelper));
        #endregion

        #region IconPosition
        public static IconPosition GetIconPosition(RepeatButton repeatButton)
        {
            return (IconPosition)repeatButton.GetValue(IconPositionProperty);
        }

        public static void SetIconPosition(RepeatButton repeatButton, IconPosition value)
        {
            repeatButton.SetValue(IconPositionProperty, value);
        }

        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.RegisterAttached("IconPosition", typeof(IconPosition), typeof(RepeatButtonHelper));
        #endregion

        #region RepeatButtonStyle
        public static RepeatButtonStyle GetRepeatButtonStyle(RepeatButton repeatButton)
        {
            return (RepeatButtonStyle)repeatButton.GetValue(RepeatButtonStyleProperty);
        }

        public static void SetRepeatButtonStyle(RepeatButton repeatButton, RepeatButtonStyle value)
        {
            repeatButton.SetValue(RepeatButtonStyleProperty, value);
        }

        public static readonly DependencyProperty RepeatButtonStyleProperty =
            DependencyProperty.RegisterAttached("RepeatButtonStyle", typeof(RepeatButtonStyle), typeof(RepeatButtonHelper));
        #endregion

        #region ClickStyle
        public static ClickStyle GetClickStyle(RepeatButton repeatButton)
        {
            return (ClickStyle)repeatButton.GetValue(ClickStyleProperty);
        }

        public static void SetClickStyle(RepeatButton repeatButton, ClickStyle value)
        {
            repeatButton.SetValue(ClickStyleProperty, value);
        }

        public static readonly DependencyProperty ClickStyleProperty =
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(RepeatButtonHelper));
        #endregion

        #region HoverBrush
        public static Brush GetHoverBrush(RepeatButton repeatButton)
        {
            return (Brush)repeatButton.GetValue(HoverBrushProperty);
        }

        public static void SetHoverBrush(RepeatButton repeatButton, Brush value)
        {
            repeatButton.SetValue(HoverBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(RepeatButton repeatButton)
        {
            return (CornerRadius)repeatButton.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(RepeatButton repeatButton, CornerRadius value)
        {
            repeatButton.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(RepeatButtonHelper));
        #endregion

        #region IsWaiting
        public static bool GetIsWaiting(RepeatButton repeatButton)
        {
            return (bool)repeatButton.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(RepeatButton repeatButton, bool value)
        {
            repeatButton.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(RepeatButtonHelper));
        #endregion

        #region WaitingContent
        public static object GetWaitingContent(RepeatButton repeatButton)
        {
            return (object)repeatButton.GetValue(WaitingContentProperty);
        }

        public static void SetWaitingContent(RepeatButton repeatButton, object value)
        {
            repeatButton.SetValue(WaitingContentProperty, value);
        }

        public static readonly DependencyProperty WaitingContentProperty =
            DependencyProperty.RegisterAttached("WaitingContent", typeof(object), typeof(RepeatButtonHelper));
        #endregion

        #endregion

        #region Event Handler

        private static void OnRepeatButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            var repeatButton = sender as RepeatButton;
            var repeatButtonStyle = GetRepeatButtonStyle(repeatButton);
            var hoverBrush = GetHoverBrush(repeatButton);

            if (hoverBrush == null)
                return;

            var dic = new Dictionary<DependencyProperty, Brush>();
            switch (repeatButtonStyle)
            {
                case RepeatButtonStyle.Standard:
                    dic.Add(RepeatButton.BackgroundProperty, hoverBrush);
                    break;
                case RepeatButtonStyle.Hollow:
                    dic.Add(RepeatButton.BackgroundProperty, hoverBrush);
                    dic.Add(RepeatButton.ForegroundProperty, Brushes.White);
                    dic.Add(IconHelper.ForegroundProperty, Brushes.White);
                    break;
                case RepeatButtonStyle.Outline:
                    dic.Add(RepeatButton.BorderBrushProperty, hoverBrush);
                    dic.Add(RepeatButton.ForegroundProperty, hoverBrush);
                    dic.Add(IconHelper.ForegroundProperty, hoverBrush);
                    break;
                case RepeatButtonStyle.Link:
                    dic.Add(RepeatButton.ForegroundProperty, hoverBrush);
                    dic.Add(IconHelper.ForegroundProperty, hoverBrush);
                    break;
            }
            StoryboardUtils.BeginBrushStoryboard(repeatButton, dic);
        }


        private static void OnRepeatButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            var repeatButton = sender as RepeatButton;
            var repeatButtonStyle = GetRepeatButtonStyle(repeatButton);
            var hoverBrush = GetHoverBrush(repeatButton);

            if (hoverBrush == null)
                return;

            var list = new List<DependencyProperty>();
            switch (repeatButtonStyle)
            {
                case RepeatButtonStyle.Standard:
                    list.Add(RepeatButton.BackgroundProperty);
                    break;
                case RepeatButtonStyle.Hollow:
                    list.Add(RepeatButton.BackgroundProperty);
                    list.Add(RepeatButton.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
                case RepeatButtonStyle.Outline:
                    list.Add(RepeatButton.BorderBrushProperty);
                    list.Add(RepeatButton.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
                case RepeatButtonStyle.Link:
                    list.Add(RepeatButton.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
            }
            StoryboardUtils.BeginBrushStoryboard(repeatButton, list);
        }

        #endregion
    }
}
