using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class MenuHelper
    {
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
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region ShadowColor
        public static Color GetShadowColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(DependencyObject obj, Color value)
        {
            obj.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color), typeof(MenuHelper));
        #endregion

        #region ItemHeight
        public static double GetItemHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemHeightProperty);
        }

        public static void SetItemHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemHeightProperty, value);
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(MenuHelper));
        #endregion

        #region ItemIcon
        public static object GetItemIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(DependencyObject obj, object value)
        {
            obj.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(MenuHelper));
        #endregion

        #region MinItemWidth
        public static double GetMinItemWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(MinItemWidthProperty);
        }

        public static void SetMinItemWidth(DependencyObject obj, double value)
        {
            obj.SetValue(MinItemWidthProperty, value);
        }

        public static readonly DependencyProperty MinItemWidthProperty =
            DependencyProperty.RegisterAttached("MinItemWidth", typeof(double), typeof(MenuHelper));
        #endregion

        #region PopupAnimation
        public static PopupAnimation GetPopupAnimation(DependencyObject obj)
        {
            return (PopupAnimation)obj.GetValue(PopupAnimationProperty);
        }

        public static void SetPopupAnimation(DependencyObject obj, PopupAnimation value)
        {
            obj.SetValue(PopupAnimationProperty, value);
        }

        public static readonly DependencyProperty PopupAnimationProperty =
            DependencyProperty.RegisterAttached("PopupAnimation", typeof(PopupAnimation), typeof(MenuHelper), new PropertyMetadata(PopupAnimation.Slide));
        #endregion

        #region MenuStyle
        public static MenuStyle GetMenuStyle(DependencyObject obj)
        {
            return (MenuStyle)obj.GetValue(MenuStyleProperty);
        }

        public static void SetMenuStyle(DependencyObject obj, MenuStyle value)
        {
            obj.SetValue(MenuStyleProperty, value);
        }

        public static readonly DependencyProperty MenuStyleProperty =
            DependencyProperty.RegisterAttached("MenuStyle", typeof(MenuStyle), typeof(MenuHelper), new PropertyMetadata(MenuStyle.Standard));


        #endregion

    }
}
