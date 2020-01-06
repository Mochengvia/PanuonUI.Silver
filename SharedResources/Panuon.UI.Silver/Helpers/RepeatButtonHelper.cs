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
        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(RepeatButtonHelper));
        #endregion

        #region IconPosition
        public static IconPosition GetIconPosition(DependencyObject obj)
        {
            return (IconPosition)obj.GetValue(IconPositionProperty);
        }

        public static void SetIconPosition(DependencyObject obj, IconPosition value)
        {
            obj.SetValue(IconPositionProperty, value);
        }

        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.RegisterAttached("IconPosition", typeof(IconPosition), typeof(RepeatButtonHelper));
        #endregion

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
            DependencyProperty.RegisterAttached("RepeatButtonStyle", typeof(RepeatButtonStyle), typeof(RepeatButtonHelper));
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
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(RepeatButtonHelper));
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
            return (object)obj.GetValue(WaitingContentProperty);
        }

        public static void SetWaitingContent(DependencyObject obj, object value)
        {
            obj.SetValue(WaitingContentProperty, value);
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
                    break;
                case RepeatButtonStyle.Outline:
                    dic.Add(RepeatButton.BorderBrushProperty, hoverBrush);
                    dic.Add(RepeatButton.ForegroundProperty, hoverBrush);
                    break;
                case RepeatButtonStyle.Link:
                    dic.Add(RepeatButton.ForegroundProperty, hoverBrush);
                    break;
            }
            StoryboardUtils.BeginStoryboard(repeatButton, dic);
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
                    break;
                case RepeatButtonStyle.Outline:
                    list.Add(RepeatButton.BorderBrushProperty);
                    list.Add(RepeatButton.ForegroundProperty);
                    break;
                case RepeatButtonStyle.Link:
                    list.Add(RepeatButton.ForegroundProperty);
                    break;
            }
            StoryboardUtils.BeginStoryboard(repeatButton, list);
        }

        #endregion
    }
}
