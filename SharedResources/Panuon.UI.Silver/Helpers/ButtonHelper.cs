using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ButtonHelper
    {
        #region Ctor
        static ButtonHelper()
        {
            EventManager.RegisterClassHandler(typeof(Button), Button.MouseEnterEvent, new RoutedEventHandler(OnButtonMouseEnter));
            EventManager.RegisterClassHandler(typeof(Button), Button.MouseLeaveEvent, new RoutedEventHandler(OnButtonMouseLeave));
        }

        #endregion

        #region Properties

        #region Icon
        public static object GetIcon(Button button)
        {
            return (object)button.GetValue(IconProperty);
        }

        public static void SetIcon(Button button, object value)
        {
            button.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ButtonHelper));
        #endregion

        #region IconPosition
        public static IconPosition GetIconPosition(Button button)
        {
            return (IconPosition)button.GetValue(IconPositionProperty);
        }

        public static void SetIconPosition(Button button, IconPosition value)
        {
            button.SetValue(IconPositionProperty, value);
        }

        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.RegisterAttached("IconPosition", typeof(IconPosition), typeof(ButtonHelper));
        #endregion

        #region ButtonStyle
        public static ButtonStyle GetButtonStyle(Button button)
        {
            return (ButtonStyle)button.GetValue(ButtonStyleProperty);
        }

        public static void SetButtonStyle(Button button, ButtonStyle value)
        {
            button.SetValue(ButtonStyleProperty, value);
        }

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.RegisterAttached("ButtonStyle", typeof(ButtonStyle), typeof(ButtonHelper));
        #endregion

        #region ClickStyle
        public static ClickStyle GetClickStyle(Button button)
        {
            return (ClickStyle)button.GetValue(ClickStyleProperty);
        }

        public static void SetClickStyle(Button button, ClickStyle value)
        {
            button.SetValue(ClickStyleProperty, value);
        }

        public static readonly DependencyProperty ClickStyleProperty =
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(ButtonHelper));
        #endregion

        #region HoverBrush
        public static Brush GetHoverBrush(Button button)
        {
            return (Brush)button.GetValue(HoverBrushProperty);
        }

        public static void SetHoverBrush(Button button, Brush value)
        {
            button.SetValue(HoverBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(ButtonHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(Button button)
        {
            return (CornerRadius)button.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(Button button, CornerRadius value)
        {
            button.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonHelper));
        #endregion

        #region IsWaiting
        public static bool GetIsWaiting(Button button)
        {
            return (bool)button.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(Button button, bool value)
        {
            button.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(ButtonHelper));
        #endregion

        #region WaitingContent
        public static object GetWaitingContent(Button button)
        {
            return (object)button.GetValue(WaitingContentProperty);
        }

        public static void SetWaitingContent(Button button, object value)
        {
            button.SetValue(WaitingContentProperty, value);
        }

        public static readonly DependencyProperty WaitingContentProperty =
            DependencyProperty.RegisterAttached("WaitingContent", typeof(object), typeof(ButtonHelper));
        #endregion

        #endregion

        #region Event Handler
        private static void OnButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var buttonStyle = GetButtonStyle(button);
            var hoverBrush = GetHoverBrush(button);

            if (hoverBrush == null)
                return;

            var dic = new Dictionary<DependencyProperty, Brush>();
            switch (buttonStyle)
            {
                case ButtonStyle.Standard:
                    dic.Add(Button.BackgroundProperty, hoverBrush);
                    break;
                case ButtonStyle.Hollow:
                    dic.Add(Button.BackgroundProperty, hoverBrush);
                    dic.Add(Button.ForegroundProperty, Brushes.White);
                    dic.Add(IconHelper.ForegroundProperty, Brushes.White);

                    break;
                case ButtonStyle.Outline:
                    dic.Add(Button.BorderBrushProperty, hoverBrush);
                    dic.Add(Button.ForegroundProperty, hoverBrush);
                    dic.Add(IconHelper.ForegroundProperty, hoverBrush);
                    break;
                case ButtonStyle.Link:
                    dic.Add(Button.ForegroundProperty, hoverBrush);
                    dic.Add(IconHelper.ForegroundProperty, hoverBrush);
                    break;
            }
            StoryboardUtils.BeginBrushStoryboard(button, dic);
        }

        private static void OnButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var buttonStyle = GetButtonStyle(button);
            var hoverBrush = GetHoverBrush(button);

            if (hoverBrush == null)
                return;

            var list = new List<DependencyProperty>();
            switch (buttonStyle)
            {
                case ButtonStyle.Standard:
                    list.Add(Button.BackgroundProperty);
                    break;
                case ButtonStyle.Hollow:
                    list.Add(Button.BackgroundProperty);
                    list.Add(Button.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
                case ButtonStyle.Outline:
                    list.Add(Button.BorderBrushProperty);
                    list.Add(Button.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
                case ButtonStyle.Link:
                    list.Add(Button.ForegroundProperty);
                    list.Add(IconHelper.ForegroundProperty);
                    break;
            }
            StoryboardUtils.BeginBrushStoryboard(button, list);
        }

        #endregion
    }
}
