using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ToggleButtonHelper
    {
        #region Ctor
        static ToggleButtonHelper()
        {
            EventManager.RegisterClassHandler(typeof(ToggleButton), ToggleButton.MouseEnterEvent, new RoutedEventHandler(OnButtonMouseEnter));
            EventManager.RegisterClassHandler(typeof(ToggleButton), ToggleButton.MouseLeaveEvent, new RoutedEventHandler(OnButtonMouseLeave));
            EventManager.RegisterClassHandler(typeof(ToggleButton), ToggleButton.UncheckedEvent, new RoutedEventHandler(OnButtonMouseUnchecked));
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
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ToggleButtonHelper));
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
            DependencyProperty.RegisterAttached("IconPosition", typeof(IconPosition), typeof(ToggleButtonHelper));
        #endregion

        #region ToggleButtonStyle
        public static ToggleButtonStyle GetToggleButtonStyle(DependencyObject obj)
        {
            return (ToggleButtonStyle)obj.GetValue(ToggleButtonStyleProperty);
        }

        public static void SetToggleButtonStyle(DependencyObject obj, ToggleButtonStyle value)
        {
            obj.SetValue(ToggleButtonStyleProperty, value);
        }

        public static readonly DependencyProperty ToggleButtonStyleProperty =
            DependencyProperty.RegisterAttached("ToggleButtonStyle", typeof(ToggleButtonStyle), typeof(ToggleButtonHelper));
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
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(ToggleButtonHelper));
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
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedBrush
        public static Brush GetCheckedBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(CheckedBrushProperty);
        }

        public static void SetCheckedBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(CheckedBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBrushProperty =
            DependencyProperty.RegisterAttached("CheckedBrush", typeof(Brush), typeof(ToggleButtonHelper));
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
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ToggleButtonHelper));
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
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(ToggleButtonHelper));
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
            DependencyProperty.RegisterAttached("WaitingContent", typeof(object), typeof(ToggleButtonHelper));
        #endregion

        #endregion

        #region Event Handler

        private static void OnButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            var ToggleButtonStyle = GetToggleButtonStyle(button);
            var hoverBrush = GetHoverBrush(button);

            if (hoverBrush == null || button.IsChecked == true)
                return;

            var dic = new Dictionary<DependencyProperty, Brush>();
            switch (ToggleButtonStyle)
            {
                case ToggleButtonStyle.Standard:
                    dic.Add(ToggleButton.BackgroundProperty, hoverBrush);
                    break;
                case ToggleButtonStyle.Hollow:
                    dic.Add(ToggleButton.BackgroundProperty, hoverBrush);
                    dic.Add(ToggleButton.ForegroundProperty, Brushes.White);
                    break;
                case ToggleButtonStyle.Outline:
                    dic.Add(ToggleButton.BorderBrushProperty, hoverBrush);
                    dic.Add(ToggleButton.ForegroundProperty, hoverBrush);
                    break;
                case ToggleButtonStyle.Link:
                    dic.Add(ToggleButton.ForegroundProperty, hoverBrush);
                    break;
            }
            StoryboardUtils.BeginStoryboard(button, dic);
        }


        private static void OnButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            var ToggleButtonStyle = GetToggleButtonStyle(button);
            var hoverBrush = GetHoverBrush(button);

            if (hoverBrush == null || button.IsChecked == true)
                return;

            var list = new List<DependencyProperty>();
            switch (ToggleButtonStyle)
            {
                case ToggleButtonStyle.Standard:
                    list.Add(ToggleButton.BackgroundProperty);
                    break;
                case ToggleButtonStyle.Hollow:
                    list.Add(ToggleButton.BackgroundProperty);
                    list.Add(ToggleButton.ForegroundProperty);
                    break;
                case ToggleButtonStyle.Outline:
                    list.Add(ToggleButton.BorderBrushProperty);
                    list.Add(ToggleButton.ForegroundProperty);
                    break;
                case ToggleButtonStyle.Link:
                    list.Add(ToggleButton.ForegroundProperty);
                    break;
            }
            StoryboardUtils.BeginStoryboard(button, list);
        }


        private static void OnButtonMouseUnchecked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            if (!button.IsMouseOver)
            {
                OnButtonMouseLeave(sender, e);
            }
        }

        #endregion
    }
}
