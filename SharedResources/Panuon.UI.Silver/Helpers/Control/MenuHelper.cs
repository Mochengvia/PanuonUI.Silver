using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class MenuHelper
    {
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

        #region Orientation
        public static Orientation GetOrientation(DependencyObject obj)
        {
            return (Orientation)obj.GetValue(OrientationProperty);
        }

        public static void SetOrientation(DependencyObject obj, Orientation value)
        {
            obj.SetValue(OrientationProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.RegisterAttached("Orientation", typeof(Orientation), typeof(MenuHelper), new PropertyMetadata(Orientation.Horizontal));
        #endregion

        #region SubmenuCornerRadius
        public static CornerRadius GetSubmenuCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(SubmenuCornerRadiusProperty);
        }

        public static void SetSubmenuCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(SubmenuCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty SubmenuCornerRadiusProperty =
            DependencyProperty.RegisterAttached("SubmenuCornerRadius", typeof(CornerRadius), typeof(MenuHelper));
        #endregion

        #region HoverForeground
        public static Brush GetHoverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverForegroundProperty);
        }

        public static void SetHoverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region HoverBackground
        public static Brush GetHoverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region ShadowColor
        public static Color? GetShadowColor(DependencyObject obj)
        {
            return (Color?)obj.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(DependencyObject obj, Color? value)
        {
            obj.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color?), typeof(MenuHelper));
        #endregion

        #region SubmenuItemHeight
        public static double GetSubmenuItemHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(SubmenuItemHeightProperty);
        }

        public static void SetSubmenuItemHeight(DependencyObject obj, double value)
        {
            obj.SetValue(SubmenuItemHeightProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemHeightProperty =
            DependencyProperty.RegisterAttached("SubmenuItemHeight", typeof(double), typeof(MenuHelper));
        #endregion

        #region SubmenuWidth
        public static double GetSubmenuWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(SubmenuWidthProperty);
        }

        public static void SetSubmenuWidth(DependencyObject obj, double value)
        {
            obj.SetValue(SubmenuWidthProperty, value);
        }

        public static readonly DependencyProperty SubmenuWidthProperty =
            DependencyProperty.RegisterAttached("SubmenuWidth", typeof(double), typeof(MenuHelper), new PropertyMetadata(double.NaN));
        #endregion

        #region ItemPadding
        public static Thickness GetItemPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ItemPaddingProperty);
        }

        public static void SetItemPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.RegisterAttached("ItemPadding", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region CheckableCheckboxStyle
        public static Style GetCheckableCheckboxStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(CheckableCheckboxStyleProperty);
        }

        public static void SetCheckableCheckboxStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(CheckableCheckboxStyleProperty, value);
        }

        public static readonly DependencyProperty CheckableCheckboxStyleProperty =
            DependencyProperty.RegisterAttached("CheckableCheckboxStyle", typeof(Style), typeof(MenuHelper));
        #endregion

    }
}
