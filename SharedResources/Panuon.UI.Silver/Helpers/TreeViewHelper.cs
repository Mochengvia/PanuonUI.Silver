using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TreeViewHelper
    {
        #region Properties

        #region TreeViewStyle
        public static TreeViewStyle GetTreeViewStyle(TreeView treeView)
        {
            return (TreeViewStyle)treeView.GetValue(TreeViewStyleProperty);
        }

        public static void SetTreeViewStyle(TreeView treeView, TreeViewStyle value)
        {
            treeView.SetValue(TreeViewStyleProperty, value);
        }

        public static readonly DependencyProperty TreeViewStyleProperty =
            DependencyProperty.RegisterAttached("TreeViewStyle", typeof(TreeViewStyle), typeof(TreeViewHelper), new FrameworkPropertyMetadata(TreeViewStyle.Standard, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemHeight
        public static double GetItemsHeight(TreeView treeView)
        {
            return (double)treeView.GetValue(ItemHeightProperty);
        }

        public static void SetItemsHeight(TreeView treeView, double value)
        {
            treeView.SetValue(ItemHeightProperty, value);
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
            return (object)treeView.GetValue(ItemIconProperty);
        }

        public static void SetItemsIcon(TreeView treeView, object value)
        {
            treeView.SetValue(ItemIconProperty, value);
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
            return (Thickness)treeView.GetValue(ItemPaddingProperty);
        }

        public static void SetItemsPadding(TreeView treeView, Thickness value)
        {
            treeView.SetValue(ItemPaddingProperty, value);
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

        #region ItemToggleEnabled
        public static bool GetItemsToggleEnabled(TreeView treeView)
        {
            return (bool)treeView.GetValue(ItemToggleEnabledProperty);
        }

        public static void SetItemsToggleEnabled(TreeView treeView, bool value)
        {
            treeView.SetValue(ItemToggleEnabledProperty, value);
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
            return (Brush)treeView.GetValue(ItemToggleBrushProperty);
        }

        public static void SetItemsToggleBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemToggleBrushProperty, value);
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

        #region ItemHoverToggleBrush
        public static Brush GetItemsHoverToggleBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemHoverToggleBrushProperty);
        }

        public static void SetItemsHoverToggleBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemHoverToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemsHoverToggleBrush", typeof(Brush), typeof(TreeViewHelper));

        public static Brush GetItemHoverToggleBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(ItemHoverToggleBrushProperty);
        }

        public static void SetItemHoverToggleBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(ItemHoverToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverToggleBrush", typeof(Brush), typeof(TreeViewHelper));
        #endregion

        #region ItemExpandedToggleBrush
        public static Brush GetItemsSelectedToggleBrush(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemExpandedToggleBrushProperty);
        }

        public static void ItemsExpandedToggleBrush(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemExpandedToggleBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedToggleBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedToggleBrush", typeof(Brush), typeof(TreeViewHelper));

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
            return (Brush)treeView.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemsHoverForeground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemHoverForegroundProperty, value);
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
            return (Brush)treeView.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemsHoverBackground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemHoverBackgroundProperty, value);
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

        #region ItemSelectedForeground
        public static Brush GetItemsSelectedForeground(TreeView treeView)
        {
            return (Brush)treeView.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemsSelectedForeground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemSelectedForegroundProperty, value);
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
            return (Brush)treeView.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemsSelectedBackground(TreeView treeView, Brush value)
        {
            treeView.SetValue(ItemSelectedBackgroundProperty, value);
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

        #region IsMouseOver
        internal static bool GetIsMouseOver(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(IsMouseOverProperty);
        }

        internal static void SetIsMouseOver(TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(IsMouseOverProperty, value);
        }

        internal static readonly DependencyProperty IsMouseOverProperty =
            DependencyProperty.RegisterAttached("IsMouseOver", typeof(bool), typeof(TreeViewHelper));
        #endregion

        #region RightClickToSelect
        public static bool GetCanMouseRightButtonSelect(TreeView treeView)
        {
            return (bool)treeView.GetValue(CanMouseRightButtonSelectProperty);
        }

        public static void SetCanMouseRightButtonSelect(TreeView treeView, bool value)
        {
            treeView.SetValue(CanMouseRightButtonSelectProperty, value);
        }

        public static readonly DependencyProperty CanMouseRightButtonSelectProperty =
            DependencyProperty.RegisterAttached("CanMouseRightButtonSelect", typeof(bool), typeof(TreeViewHelper), new PropertyMetadata(OnCanMouseRightButtonSelectChanged));

        private static void OnCanMouseRightButtonSelectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeView = d as TreeView;
            treeView.RemoveHandler(TreeViewItem.PreviewMouseRightButtonDownEvent, new RoutedEventHandler(OnTreeViewItemPreviewMouseRightButtonDown));
            if((bool)e.NewValue)
            {
                treeView.AddHandler(TreeViewItem.PreviewMouseRightButtonDownEvent, new RoutedEventHandler(OnTreeViewItemPreviewMouseRightButtonDown));
            }
        }

        private static void OnTreeViewItemPreviewMouseRightButtonDown(object sender, RoutedEventArgs e)
        {
            var treeViewItem = e.Source as TreeViewItem;
            if(treeViewItem != null)
            {
                treeViewItem.IsSelected = true;
            }
        }


        #endregion

        #endregion
    }
}
