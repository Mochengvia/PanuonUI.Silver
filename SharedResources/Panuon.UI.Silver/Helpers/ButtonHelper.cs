using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ButtonHelper
    {
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

        #region IconPlacement
        public static IconPlacement GetIconPlacement(Button button)
        {
            return (IconPlacement)button.GetValue(IconPlacementProperty);
        }

        public static void SetIconPlacement(Button button, IconPlacement value)
        {
            button.SetValue(IconPlacementProperty, value);
        }

        public static readonly DependencyProperty IconPlacementProperty =
            DependencyProperty.RegisterAttached("IconPlacement", typeof(IconPlacement), typeof(ButtonHelper));
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

        #region HoverBackground
        public static Brush GetHoverBackground(Button button)
        {
            return (Brush)button.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(Button button, Brush value)
        {
            button.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(ButtonHelper));
        #endregion

        #region HoverForeground
        public static Brush GetHoverForeground(Button button)
        {
            return (Brush)button.GetValue(HoverForegroundProperty);
        }

        public static void SetHoverForeground(Button button, Brush value)
        {
            button.SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(ButtonHelper));
        #endregion

        #region HoverBorderBrush
        public static Brush GetHoverBorderBrush(Button button)
        {
            return (Brush)button.GetValue(HoverBorderBrushProperty);
        }

        public static void SetHoverBorderBrush(Button button, Brush value)
        {
            button.SetValue(HoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("HoverBorderBrush", typeof(Brush), typeof(ButtonHelper));
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

        #endregion

        #region Internal Properties

        #region Hook
        internal static bool GetHook(Button button)
        {
            return (bool)button.GetValue(HookProperty);
        }

        internal static void SetHook(Button button, bool value)
        {
            button.SetValue(HookProperty, value);
        }

         internal static readonly DependencyProperty HookProperty =
            DependencyProperty.RegisterAttached("Hook", typeof(bool), typeof(ButtonHelper), new PropertyMetadata(OnHookChanged));
        #endregion

        #endregion

        #region Event Handlers
        private static void OnHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Button;
            if (button == null)
            {
                return;
            }

            button.MouseEnter -= OnButtonMouseEnter;
            button.MouseLeave -= OnButtonMouseLeave;

            if ((bool)e.NewValue)
            {
                button.MouseEnter += OnButtonMouseEnter;
                button.MouseLeave += OnButtonMouseLeave;
            }
        }

        private static void OnButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var hoverBackground = GetHoverBackground(button);
            var hoverForeground = GetHoverForeground(button);
            var hoverBorderBrush = GetHoverBorderBrush(button);

            var dic = new Dictionary<DependencyProperty, Brush>();
            if(hoverBackground != null)
            {
                dic.Add(Button.BackgroundProperty, hoverBackground);
            }
            if (hoverForeground != null)
            {
                dic.Add(Button.ForegroundProperty, hoverForeground);
            }
            if (hoverBorderBrush != null)
            {
                dic.Add(Button.BorderBrushProperty, hoverBorderBrush);
            }
            if (dic.Any())
            {
                UIElementUtils.BeginStoryboard(button, dic);
            }
        }

        private static void OnButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var hoverBackground = GetHoverBackground(button);
            var hoverForeground = GetHoverForeground(button);
            var hoverBorderBrush = GetHoverBorderBrush(button);

            var list = new List<DependencyProperty>();
            if (hoverBackground != null)
            {
                list.Add(Button.BackgroundProperty);
            }
            if (hoverForeground != null)
            {
                list.Add(Button.ForegroundProperty);
            }
            if (hoverBorderBrush != null)
            {
                list.Add(Button.BorderBrushProperty);
            }
            if (list.Any())
            {
                UIElementUtils.BeginStoryboard(button, list);
            }
        }
        #endregion

        #region Functions
        #endregion
    }
}
