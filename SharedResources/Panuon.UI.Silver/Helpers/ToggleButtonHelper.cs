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
        public static object GetIcon(ToggleButton toggleButton)
        {
            return (object)toggleButton.GetValue(IconProperty);
        }

        public static void SetIcon(ToggleButton toggleButton, object value)
        {
            toggleButton.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ToggleButtonHelper));
        #endregion

        #region IconPosition
        public static IconPosition GetIconPosition(ToggleButton toggleButton)
        {
            return (IconPosition)toggleButton.GetValue(IconPositionProperty);
        }

        public static void SetIconPosition(ToggleButton toggleButton, IconPosition value)
        {
            toggleButton.SetValue(IconPositionProperty, value);
        }

        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.RegisterAttached("IconPosition", typeof(IconPosition), typeof(ToggleButtonHelper));
        #endregion

        #region ToggleButtonStyle
        public static ToggleButtonStyle GetToggleButtonStyle(ToggleButton toggleButton)
        {
            return (ToggleButtonStyle)toggleButton.GetValue(ToggleButtonStyleProperty);
        }

        public static void SetToggleButtonStyle(ToggleButton toggleButton, ToggleButtonStyle value)
        {
            toggleButton.SetValue(ToggleButtonStyleProperty, value);
        }

        public static readonly DependencyProperty ToggleButtonStyleProperty =
            DependencyProperty.RegisterAttached("ToggleButtonStyle", typeof(ToggleButtonStyle), typeof(ToggleButtonHelper));
        #endregion

        #region ClickStyle
        public static ClickStyle GetClickStyle(ToggleButton toggleButton)
        {
            return (ClickStyle)toggleButton.GetValue(ClickStyleProperty);
        }

        public static void SetClickStyle(ToggleButton toggleButton, ClickStyle value)
        {
            toggleButton.SetValue(ClickStyleProperty, value);
        }

        public static readonly DependencyProperty ClickStyleProperty =
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(ToggleButtonHelper));
        #endregion

        #region HoverBrush
        public static Brush GetHoverBrush(ToggleButton toggleButton)
        {
            return (Brush)toggleButton.GetValue(HoverBrushProperty);
        }

        public static void SetHoverBrush(ToggleButton toggleButton, Brush value)
        {
            toggleButton.SetValue(HoverBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedBrush
        public static Brush GetCheckedBrush(ToggleButton toggleButton)
        {
            return (Brush)toggleButton.GetValue(CheckedBrushProperty);
        }

        public static void SetCheckedBrush(ToggleButton toggleButton, Brush value)
        {
            toggleButton.SetValue(CheckedBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBrushProperty =
            DependencyProperty.RegisterAttached("CheckedBrush", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(ToggleButton toggleButton)
        {
            return (CornerRadius)toggleButton.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(ToggleButton toggleButton, CornerRadius value)
        {
            toggleButton.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedContent
        public static object GetCheckedContent(ToggleButton toggleButton)
        {
            return (object)toggleButton.GetValue(CheckedContentProperty);
        }

        public static void SetCheckedContent(ToggleButton toggleButton, object value)
        {
            toggleButton.SetValue(CheckedContentProperty, value);
        }

        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.RegisterAttached("CheckedContent", typeof(object), typeof(ToggleButtonHelper));
        #endregion

        #region IsWaiting
        public static bool GetIsWaiting(ToggleButton toggleButton)
        {
            return (bool)toggleButton.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(ToggleButton toggleButton, bool value)
        {
            toggleButton.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(ToggleButtonHelper));
        #endregion

        #region WaitingContent
        public static object GetWaitingContent(ToggleButton toggleButton)
        {
            return (object)toggleButton.GetValue(WaitingContentProperty);
        }

        public static void SetWaitingContent(ToggleButton toggleButton, object value)
        {
            toggleButton.SetValue(WaitingContentProperty, value);
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
                    dic.Add(IconHelper.ForegroundProperty, Brushes.White);
                    break;
                case ToggleButtonStyle.Outline:
                    dic.Add(ToggleButton.BorderBrushProperty, hoverBrush);
                    dic.Add(ToggleButton.ForegroundProperty, hoverBrush);
                    dic.Add(IconHelper.ForegroundProperty, hoverBrush);
                    break;
                case ToggleButtonStyle.Link:
                    dic.Add(ToggleButton.ForegroundProperty, hoverBrush);
                    dic.Add(IconHelper.ForegroundProperty, hoverBrush);
                    break;
            }
            StoryboardUtils.BeginBrushStoryboard(button, dic);
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
                    list.Add(IconHelper.ForegroundProperty);
                    break;
                case ToggleButtonStyle.Outline:
                    list.Add(ToggleButton.BorderBrushProperty);
                    list.Add(ToggleButton.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
                case ToggleButtonStyle.Link:
                    list.Add(ToggleButton.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
            }
            StoryboardUtils.BeginBrushStoryboard(button, list);
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
