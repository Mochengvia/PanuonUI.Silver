using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TreeViewHelper
    {
        #region Properties

        #region ReferenceLineVisibility
        public static Visibility GetReferenceLineVisibility(TreeView treeView)
        {
            return (Visibility)treeView.GetValue(ItemIconProperty);
        }

        public static void SetReferenceLineVisibility(TreeView treeView, Visibility value)
        {
            treeView.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ReferenceLineVisibilityProperty =
            DependencyProperty.RegisterAttached("ReferenceLineVisibility", typeof(Visibility), typeof(TreeViewHelper));
        #endregion

        #region ItemsHeight
        public static double GetItemsHeight(TreeView treeView)
        {
            return (double)treeView.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(TreeView treeView, double value)
        {
            treeView.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(TreeViewHelper));

        public static double GetItemHeight(TreeViewItem treeViewItem)
        {
            return (double)treeViewItem.GetValue(ItemHeightProperty);
        }

        public static void SetItemHeight(TreeViewItem treeViewItem, double value)
        {
            treeViewItem.SetValue(ItemHeightProperty, value);
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(TreeViewHelper));

        #endregion

        #region ItemIcon
        public static object GetItemsIcon(TreeView treeView)
        {
            return (object)treeView.GetValue(ItemsIconProperty);
        }

        public static void SetItemsIcon(TreeView treeView, object value)
        {
            treeView.SetValue(ItemsIconProperty, value);
        }

        public static readonly DependencyProperty ItemsIconProperty =
            DependencyProperty.RegisterAttached("ItemsIcon", typeof(object), typeof(TreeViewHelper));

        public static object GetItemIcon(TreeViewItem treeViewItem)
        {
            return (object)treeViewItem.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(TreeViewItem treeViewItem, object value)
        {
            treeViewItem.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(TreeViewHelper));
        #endregion

        #region ItemPadding
        public static Thickness GetItemsPadding(TreeView treeView)
        {
            return (Thickness)treeView.GetValue(ItemsPaddingProperty);
        }

        public static void SetItemsPadding(TreeView treeView, Thickness value)
        {
            treeView.SetValue(ItemsPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemsPaddingProperty =
            DependencyProperty.RegisterAttached("ItemsPadding", typeof(Thickness), typeof(TreeViewHelper));

        public static Thickness GetItemPadding(TreeViewItem treeViewItem)
        {
            return (Thickness)treeViewItem.GetValue(ItemPaddingProperty);
        }

        public static void SetItemPadding(TreeViewItem treeViewItem, Thickness value)
        {
            treeViewItem.SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.RegisterAttached("ItemPadding", typeof(Thickness), typeof(TreeViewHelper));

        #endregion

        #region ItemToggleStyle
        public static Style GetItemsToggleStyle(TreeView treeView)
        {
            return (Style)treeView.GetValue(ItemsToggleStyleProperty);
        }

        public static void SetItemsToggleStyle(TreeView treeView, Style value)
        {
            treeView.SetValue(ItemsToggleStyleProperty, value);
        }

        public static readonly DependencyProperty ItemsToggleStyleProperty =
            DependencyProperty.RegisterAttached("ItemsToggleStyle", typeof(Style), typeof(TreeViewHelper));

        public static Style GetItemToggleStyle(TreeViewItem treeViewItem)
        {
            return (Style)treeViewItem.GetValue(ItemToggleStyleProperty);
        }

        public static void SetItemToggleStyle(TreeViewItem treeViewItem, Style value)
        {
            treeViewItem.SetValue(ItemToggleStyleProperty, value);
        }

        public static readonly DependencyProperty ItemToggleStyleProperty =
            DependencyProperty.RegisterAttached("ItemToggleStyle", typeof(Style), typeof(TreeViewHelper));
        #endregion

        #region ItemToggleEnabled
        public static bool GetItemsToggleEnabled(TreeView treeView)
        {
            return (bool)treeView.GetValue(ItemsToggleEnabledProperty);
        }

        public static void SetItemsToggleEnabled(TreeView treeView, bool value)
        {
            treeView.SetValue(ItemsToggleEnabledProperty, value);
        }

        public static readonly DependencyProperty ItemsToggleEnabledProperty =
            DependencyProperty.RegisterAttached("ItemsToggleEnabled", typeof(bool), typeof(TreeViewHelper));

        public static bool GetItemToggleEnabled(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(ItemToggleEnabledProperty);
        }

        public static void SetItemToggleEnabled(TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(ItemToggleEnabledProperty, value);
        }

        public static readonly DependencyProperty ItemToggleEnabledProperty =
            DependencyProperty.RegisterAttached("ItemToggleEnabled", typeof(bool), typeof(TreeViewHelper));
        #endregion

        #region ItemToggleBrush
        public static Brush GetItemsToggleBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsToggleBrushProperty);
        }

        public static void SetItemsToggleBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemsToggleBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemToggleBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemToggleBrushProperty);
        }

        public static void SetItemToggleBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemToggleBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemBorderBrush
        public static Brush GetItemsBorderBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsBorderBrushProperty);
        }

        public static void SetItemsBorderBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsBorderBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemBorderThickness
        public static Thickness GetItemsBorderThickness(TreeView treeView)
        {
            return (Thickness)treeView.GetValue(ItemsBorderThicknessProperty);
        }

        public static void SetItemsBorderThickness(TreeView treeView, Thickness value)
        {
            treeView.SetValue(ItemsBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemsBorderThickness", typeof(Thickness), typeof(TreeViewHelper));
        #endregion

        #region ItemToggleHoverBrush
        public static Brush GetItemsToggleHoverBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsToggleHoverBrushProperty);
        }

        public static void SetItemsToggleHoverBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsToggleHoverBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsToggleHoverBrushProperty =
            DependencyProperty.RegisterAttached("ItemsToggleHoverBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemToggleHoverBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemToggleHoverBrushProperty);
        }

        public static void SetItemToggleHoverBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemToggleHoverBrushProperty, value);
        }

        public static readonly DependencyProperty ItemToggleHoverBrushProperty =
            DependencyProperty.RegisterAttached("ItemToggleHoverBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemSelectedToggleBrush


        public static Brush GetItemsSelectedToggleBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsSelectedToggleBrushProperty);
        }

        public static void SetItemsSelectedToggleBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsSelectedToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedToggleBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemSelectedToggleBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemSelectedToggleBrushProperty);
        }

        public static void SetItemSelectedToggleBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemSelectedToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedToggleBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemExpandedToggleBrush
        public static Brush GetItemsExpandedToggleBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsExpandedToggleBrushProperty);
        }

        public static void SetItemsExpandedToggleBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsExpandedToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsExpandedToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemsExpandedToggleBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemExpandedToggleBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemExpandedToggleBrushProperty);
        }

        public static void SetItemExpandedToggleBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemExpandedToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemExpandedToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemExpandedToggleBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemHoverForeground
        public static Brush GetItemsHoverForeground(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsHoverForegroundProperty);
        }

        public static void SetItemsHoverForeground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverForeground", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemHoverForeground(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemHoverForeground(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverForeground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemHoverBackground
        public static Brush GetItemsHoverBackground(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsHoverBackgroundProperty);
        }

        public static void SetItemsHoverBackground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBackground", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemHoverBackground(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemHoverBackground(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverBackground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemHoverBorderBrush
        public static Brush GetItemsHoverBorderBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsHoverBorderBrushProperty);
        }

        public static void SetItemsHoverBorderBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBorderBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemHoverBorderBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemHoverBorderBrushProperty);
        }

        public static void SetItemHoverBorderBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemHoverBorderThickness
        public static Thickness GetItemsHoverBorderThickness(TreeView treeView)
        {
            return (Thickness)treeView.GetValue(ItemsHoverBorderThicknessProperty);
        }

        public static void SetItemsHoverBorderThickness(TreeView treeView, Thickness value)
        {
            treeView.SetValue(ItemsHoverBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBorderThickness", typeof(Thickness), typeof(TreeViewHelper));

        public static Thickness GetItemHoverBorderThickness(TreeViewItem treeViewItem)
        {
            return (Thickness)treeViewItem.GetValue(ItemHoverBorderThicknessProperty);
        }

        public static void SetItemHoverBorderThickness(TreeViewItem treeViewItem, Thickness value)
        {
            treeViewItem.SetValue(ItemHoverBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderThickness", typeof(Thickness), typeof(TreeViewHelper));
        #endregion

        #region ItemSelectedForeground
        public static Brush GetItemsSelectedForeground(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsSelectedForegroundProperty);
        }

        public static void SetItemsSelectedForeground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedForeground", typeof(Brush), typeof(TreeViewHelper));


        public static Brush GetItemSelectedForeground(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemSelectedBackground
        public static Brush GetItemsSelectedBackground(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsSelectedBackgroundProperty);
        }

        public static void SetItemsSelectedBackground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBackground", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemSelectedBackground(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemSelectedBorderThickness
        public static Thickness GetItemsSelectedBorderThickness(TreeView treeView)
        {
            return (Thickness)treeView.GetValue(ItemsSelectedBorderThicknessProperty);
        }

        public static void SetItemsSelectedBorderThickness(TreeView treeView, Thickness value)
        {
            treeView.SetValue(ItemsSelectedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderThickness", typeof(Thickness), typeof(TreeViewHelper));

        public static Thickness GetItemSelectedBorderThickness(TreeViewItem treeViewItem)
        {
            return (Thickness)treeViewItem.GetValue(ItemSelectedBorderThicknessProperty);
        }

        public static void SetItemSelectedBorderThickness(TreeViewItem treeViewItem, Thickness value)
        {
            treeViewItem.SetValue(ItemSelectedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderThickness", typeof(Thickness), typeof(TreeViewHelper));
        #endregion

        #region ItemSelectedBorderBrush
        public static Brush GetItemsSelectedBorderBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemsSelectedBorderBrushProperty);
        }

        public static void SetItemsSelectedBorderBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemsSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemSelectedBorderBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemSelectedBorderBrushProperty);
        }

        public static void SetItemSelectedBorderBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemIsMouseOver
        internal static bool GetItemIsMouseOver(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(ItemIsMouseOverProperty);
        }

        internal static void SetItemIsMouseOver(TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(ItemIsMouseOverProperty, value);
        }

        internal static readonly DependencyProperty ItemIsMouseOverProperty =
            DependencyProperty.RegisterAttached("ItemIsMouseOver", typeof(bool), typeof(TreeViewHelper));
        #endregion

        #endregion
    }
}
