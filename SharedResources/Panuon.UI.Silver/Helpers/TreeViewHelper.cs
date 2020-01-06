using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TreeViewHelper
    {
        #region TreeViewStyle
        public static TreeViewStyle GetTreeViewStyle(DependencyObject obj)
        {
            return (TreeViewStyle)obj.GetValue(TreeViewStyleProperty);
        }

        public static void SetTreeViewStyle(DependencyObject obj, TreeViewStyle value)
        {
            obj.SetValue(TreeViewStyleProperty, value);
        }

        public static readonly DependencyProperty TreeViewStyleProperty =
            DependencyProperty.RegisterAttached("TreeViewStyle", typeof(TreeViewStyle), typeof(TreeViewHelper), new FrameworkPropertyMetadata(TreeViewStyle.Standard, FrameworkPropertyMetadataOptions.Inherits));
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
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(TreeViewHelper));
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
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(TreeViewHelper));
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
            DependencyProperty.RegisterAttached("ItemPadding", typeof(Thickness), typeof(TreeViewHelper));
        #endregion

        #region IsToggleEnabled
        public static bool GetIsToggleEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsToggleEnabledProperty);
        }

        public static void SetIsToggleEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsToggleEnabledProperty, value);
        }

        public static readonly DependencyProperty IsToggleEnabledProperty =
            DependencyProperty.RegisterAttached("IsToggleEnabled", typeof(bool), typeof(TreeViewHelper));
        #endregion

        #region ToggleBrush
        public static Brush GetToggleBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ToggleBrushProperty);
        }

        public static void SetToggleBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ToggleBrushProperty =
            DependencyProperty.RegisterAttached("ToggleBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region HoverToggleBrush
        public static Brush GetHoverToggleBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverToggleBrushProperty);
        }

        public static void SetHoverToggleBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverToggleBrushProperty, value);
        }

        public static readonly DependencyProperty HoverToggleBrushProperty =
            DependencyProperty.RegisterAttached("HoverToggleBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region SelectedToggleBrush
        public static Brush GetSelectedToggleBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedToggleBrushProperty);
        }

        public static void SetSelectedToggleBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedToggleBrushProperty, value);
        }

        public static readonly DependencyProperty SelectedToggleBrushProperty =
            DependencyProperty.RegisterAttached("SelectedToggleBrush", typeof(Brush), typeof(TreeViewHelper));
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
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(TreeViewHelper));
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
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region SelectedForeground
        public static Brush GetSelectedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedForegroundProperty);
        }

        public static void SetSelectedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region SelectedBackground
        public static Brush GetSelectedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBackgroundProperty);
        }

        public static void SetSelectedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region IsMouseOver
        internal static bool GetIsMouseOver(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseOverProperty);
        }

        internal static void SetIsMouseOver(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMouseOverProperty, value);
        }

        internal static readonly DependencyProperty IsMouseOverProperty =
            DependencyProperty.RegisterAttached("IsMouseOver", typeof(bool), typeof(TreeViewHelper));
        #endregion
    }
}
