using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class RepeatButtonHelper
    {
        #region Properties

        #region Icon
        public static object GetIcon(RepeatButton button)
        {
            return (object)button.GetValue(IconProperty);
        }

        public static void SetIcon(RepeatButton button, object value)
        {
            button.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(RepeatButtonHelper));
        #endregion

        #region IconPlacement
        public static IconPlacement GetIconPlacement(RepeatButton button)
        {
            return (IconPlacement)button.GetValue(IconPlacementProperty);
        }

        public static void SetIconPlacement(RepeatButton button, IconPlacement value)
        {
            button.SetValue(IconPlacementProperty, value);
        }

        public static readonly DependencyProperty IconPlacementProperty =
            DependencyProperty.RegisterAttached("IconPlacement", typeof(IconPlacement), typeof(RepeatButtonHelper));
        #endregion

        #region ClickStyle
        public static ClickStyle GetClickStyle(RepeatButton button)
        {
            return (ClickStyle)button.GetValue(ClickStyleProperty);
        }

        public static void SetClickStyle(RepeatButton button, ClickStyle value)
        {
            button.SetValue(ClickStyleProperty, value);
        }

        public static readonly DependencyProperty ClickStyleProperty =
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(RepeatButtonHelper));
        #endregion

        #region HoverBackground
        public static Brush GetHoverBackground(RepeatButton button)
        {
            return (Brush)button.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(RepeatButton button, Brush value)
        {
            button.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion

        #region HoverForeground
        public static Brush GetHoverForeground(RepeatButton button)
        {
            return (Brush)button.GetValue(HoverForegroundProperty);
        }

        public static void SetHoverForeground(RepeatButton button, Brush value)
        {
            button.SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion

        #region HoverBorderBrush
        public static Brush GetHoverBorderBrush(RepeatButton button)
        {
            return (Brush)button.GetValue(HoverBorderBrushProperty);
        }

        public static void SetHoverBorderBrush(RepeatButton button, Brush value)
        {
            button.SetValue(HoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("HoverBorderBrush", typeof(Brush), typeof(RepeatButtonHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(RepeatButton button)
        {
            return (CornerRadius)button.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(RepeatButton button, CornerRadius value)
        {
            button.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(RepeatButtonHelper));
        #endregion

        #region IsWaiting
        public static bool GetIsWaiting(RepeatButton button)
        {
            return (bool)button.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(RepeatButton button, bool value)
        {
            button.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(RepeatButtonHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region Hook
        internal static bool GetHook(RepeatButton repeatButton)
        {
            return (bool)repeatButton.GetValue(HookProperty);
        }

        internal static void SetHook(RepeatButton repeatButton, bool value)
        {
            repeatButton.SetValue(HookProperty, value);
        }

         internal static readonly DependencyProperty HookProperty =
            DependencyProperty.RegisterAttached("Hook", typeof(bool), typeof(RepeatButtonHelper), new PropertyMetadata(OnHookChanged));
        #endregion

        #endregion

        #region Event Handlers
        private static void OnHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as RepeatButton;
            if (button == null)
            {
                return;
            }

            button.MouseEnter -= OnRepeatButtonMouseEnter;
            button.MouseLeave -= OnRepeatButtonMouseLeave;

            if ((bool)e.NewValue)
            {
                button.MouseEnter += OnRepeatButtonMouseEnter;
                button.MouseLeave += OnRepeatButtonMouseLeave;
            }
        }

        private static void OnRepeatButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as RepeatButton;
            var hoverBackground = GetHoverBackground(button);
            var hoverForeground = GetHoverForeground(button);
            var hoverBorderBrush = GetHoverBorderBrush(button);

            var dic = new Dictionary<DependencyProperty, Brush>();
            if (hoverBackground != null)
            {
                dic.Add(RepeatButton.BackgroundProperty, hoverBackground);
            }
            if (hoverForeground != null)
            {
                dic.Add(RepeatButton.ForegroundProperty, hoverForeground);
            }
            if (hoverBorderBrush != null)
            {
                dic.Add(RepeatButton.BorderBrushProperty, hoverBorderBrush);
            }
            if (dic.Any())
            {
                UIElementUtils.BeginStoryboard(button, dic);
            }
        }

        private static void OnRepeatButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as RepeatButton;
            var hoverBackground = GetHoverBackground(button);
            var hoverForeground = GetHoverForeground(button);
            var hoverBorderBrush = GetHoverBorderBrush(button);

            var list = new List<DependencyProperty>();
            if (hoverBackground != null)
            {
                list.Add(RepeatButton.BackgroundProperty);
            }
            if (hoverForeground != null)
            {
                list.Add(RepeatButton.ForegroundProperty);
            }
            if (hoverBorderBrush != null)
            {
                list.Add(RepeatButton.BorderBrushProperty);
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
