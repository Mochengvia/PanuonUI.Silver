using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ToggleButtonHelper
    {
        #region Properties

        #region Icon
        public static object GetIcon(ToggleButton button)
        {
            return (object)button.GetValue(IconProperty);
        }

        public static void SetIcon(ToggleButton button, object value)
        {
            button.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ToggleButtonHelper));
        #endregion

        #region IconPlacement
        public static IconPlacement GetIconPlacement(ToggleButton button)
        {
            return (IconPlacement)button.GetValue(IconPlacementProperty);
        }

        public static void SetIconPlacement(ToggleButton button, IconPlacement value)
        {
            button.SetValue(IconPlacementProperty, value);
        }

        public static readonly DependencyProperty IconPlacementProperty =
            DependencyProperty.RegisterAttached("IconPlacement", typeof(IconPlacement), typeof(ToggleButtonHelper));
        #endregion

        #region ClickStyle
        public static ClickStyle GetClickStyle(ToggleButton button)
        {
            return (ClickStyle)button.GetValue(ClickStyleProperty);
        }

        public static void SetClickStyle(ToggleButton button, ClickStyle value)
        {
            button.SetValue(ClickStyleProperty, value);
        }

        public static readonly DependencyProperty ClickStyleProperty =
            DependencyProperty.RegisterAttached("ClickStyle", typeof(ClickStyle), typeof(ToggleButtonHelper));
        #endregion

        #region HoverBackground
        public static Brush GetHoverBackground(ToggleButton button)
        {
            return (Brush)button.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(ToggleButton button, Brush value)
        {
            button.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region HoverForeground
        public static Brush GetHoverForeground(ToggleButton button)
        {
            return (Brush)button.GetValue(HoverForegroundProperty);
        }

        public static void SetHoverForeground(ToggleButton button, Brush value)
        {
            button.SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region HoverBorderBrush
        public static Brush GetHoverBorderBrush(ToggleButton button)
        {
            return (Brush)button.GetValue(HoverBorderBrushProperty);
        }

        public static void SetHoverBorderBrush(ToggleButton button, Brush value)
        {
            button.SetValue(HoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("HoverBorderBrush", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedBackground
        public static Brush GetCheckedBackground(ToggleButton button)
        {
            return (Brush)button.GetValue(CheckedBackgroundProperty);
        }

        public static void SetCheckedBackground(ToggleButton button, Brush value)
        {
            button.SetValue(CheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("CheckedBackground", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedForeground
        public static Brush GetCheckedForeground(ToggleButton button)
        {
            return (Brush)button.GetValue(CheckedForegroundProperty);
        }

        public static void SetCheckedForeground(ToggleButton button, Brush value)
        {
            button.SetValue(CheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty CheckedForegroundProperty =
            DependencyProperty.RegisterAttached("CheckedForeground", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedBorderBrush
        public static Brush GetCheckedBorderBrush(ToggleButton button)
        {
            return (Brush)button.GetValue(CheckedBorderBrushProperty);
        }

        public static void SetCheckedBorderBrush(ToggleButton button, Brush value)
        {
            button.SetValue(CheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("CheckedBorderBrush", typeof(Brush), typeof(ToggleButtonHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(ToggleButton button)
        {
            return (CornerRadius)button.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(ToggleButton button, CornerRadius value)
        {
            button.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ToggleButtonHelper));
        #endregion

        #region IsWaiting
        public static bool GetIsWaiting(ToggleButton button)
        {
            return (bool)button.GetValue(IsWaitingProperty);
        }

        public static void SetIsWaiting(ToggleButton button, bool value)
        {
            button.SetValue(IsWaitingProperty, value);
        }

        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.RegisterAttached("IsWaiting", typeof(bool), typeof(ToggleButtonHelper));
        #endregion

        #region CheckedContent
        public static object GetCheckedContent(ToggleButton button)
        {
            return (object)button.GetValue(CheckedContentProperty);
        }

        public static void SetCheckedContent(ToggleButton button, object value)
        {
            button.SetValue(CheckedContentProperty, value);
        }

        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.RegisterAttached("CheckedContent", typeof(object), typeof(ToggleButtonHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region Hook
        internal static bool GetHook(ToggleButton toggleButton)
        {
            return (bool)toggleButton.GetValue(HookProperty);
        }

        internal static void SetHook(ToggleButton toggleButton, bool value)
        {
            toggleButton.SetValue(HookProperty, value);
        }

         internal static readonly DependencyProperty HookProperty =
            DependencyProperty.RegisterAttached("Hook", typeof(bool), typeof(ToggleButtonHelper), new PropertyMetadata(OnHookChanged));
        #endregion

        #endregion

        #region Event Handlers
        private static void OnHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as ToggleButton;
            if (button == null)
            {
                return;
            }

            button.MouseEnter -= OnToggleButtonMouseEnter;
            button.MouseLeave -= OnToggleButtonMouseLeave;

            if ((bool)e.NewValue)
            {
                button.MouseEnter += OnToggleButtonMouseEnter;
                button.MouseLeave += OnToggleButtonMouseLeave;
            }
        }

        private static void OnToggleButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            var hoverBackground = GetHoverBackground(button);
            var hoverForeground = GetHoverForeground(button);
            var hoverBorderBrush = GetHoverBorderBrush(button);

            var dic = new Dictionary<DependencyProperty, Brush>();
            if (hoverBackground != null)
            {
                dic.Add(ToggleButton.BackgroundProperty, hoverBackground);
            }
            if (hoverForeground != null)
            {
                dic.Add(ToggleButton.ForegroundProperty, hoverForeground);
            }
            if (hoverBorderBrush != null)
            {
                dic.Add(ToggleButton.BorderBrushProperty, hoverBorderBrush);
            }
            if (dic.Any())
            {
                UIElementUtils.BeginStoryboard(button, dic);
            }
        }

        private static void OnToggleButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            var hoverBackground = GetHoverBackground(button);
            var hoverForeground = GetHoverForeground(button);
            var hoverBorderBrush = GetHoverBorderBrush(button);

            var list = new List<DependencyProperty>();
            if (hoverBackground != null)
            {
                list.Add(ToggleButton.BackgroundProperty);
            }
            if (hoverForeground != null)
            {
                list.Add(ToggleButton.ForegroundProperty);
            }
            if (hoverBorderBrush != null)
            {
                list.Add(ToggleButton.BorderBrushProperty);
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
