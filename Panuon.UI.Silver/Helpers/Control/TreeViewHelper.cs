using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TreeViewHelper
    {
        //#region TreeViewStyle
        //public static TreeViewStyle GetTreeViewStyle(DependencyObject obj)
        //{
        //    return (TreeViewStyle)obj.GetValue(TreeViewStyleProperty);
        //}

        //public static void SetTreeViewStyle(DependencyObject obj, TreeViewStyle value)
        //{
        //    obj.SetValue(TreeViewStyleProperty, value);
        //}

        //public static readonly DependencyProperty TreeViewStyleProperty =
        //    DependencyProperty.RegisterAttached("TreeViewStyle", typeof(TreeViewStyle), typeof(TreeViewHelper));
        //#endregion

        #region SelectMode
        public static SelectMode GetSelectMode(DependencyObject obj)
        {
            return (SelectMode)obj.GetValue(SelectModeProperty);
        }

        public static void SetSelectMode(DependencyObject obj, SelectMode value)
        {
            obj.SetValue(SelectModeProperty, value);
        }

        public static readonly DependencyProperty SelectModeProperty =
            DependencyProperty.RegisterAttached("SelectMode", typeof(SelectMode), typeof(TreeViewHelper), new PropertyMetadata(SelectMode.Any, OnSelectModeChanged));

        private static void OnSelectModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeView = d as TreeView;

            treeView.SelectedItemChanged -= TreeView_SelectedItemChanged;
            treeView.RemoveHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(OnSelectModeItemSelected));

            if ((SelectMode)e.NewValue == SelectMode.ChildOnly)
            {
                treeView.SelectedItemChanged += TreeView_SelectedItemChanged;
                treeView.AddHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(OnSelectModeItemSelected));
            }
        }

        private static void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = sender as TreeView;

            if (e.NewValue is TreeViewItem)
            {
                if (((TreeViewItem)e.NewValue).HasItems)
                    e.Handled = true;
            }
            else
            {
                var sourceData = e.NewValue;
                if (!(treeView.ItemTemplate is HierarchicalDataTemplate))
                    return;
                var itemsPath = ((Binding)((HierarchicalDataTemplate)treeView.ItemTemplate)?.ItemsSource)?.Path?.Path;
                if (string.IsNullOrEmpty(itemsPath))
                    return;

                var propertyInfo = sourceData.GetType().GetProperty(itemsPath);
                if (propertyInfo == null)
                    return;

                var children = propertyInfo.GetValue(sourceData, null) as ICollection;
                if (children == null)
                    return;

                if (children != null && children.Count != 0)
                    e.Handled = true;
            }

        }

        private static void OnSelectModeItemSelected(object sender, RoutedEventArgs e)
        {
            var treeView = sender as TreeView;
            if (e.OriginalSource is TreeViewItem)
            {
                var treeViewItem = e.OriginalSource as TreeViewItem;

                var oldItem = GetLastSelectedItem(treeView);
                if (treeViewItem.HasItems)
                {
                    treeViewItem.IsSelected = false;

                    if (oldItem != null && !oldItem.IsSelected)
                    {
                        SetLastSelecteedItem(treeView, null);
                        oldItem.IsSelected = true;
                    }
                }
                else
                {
                    if (oldItem != null)
                        oldItem.IsSelected = false;
                    SetLastSelecteedItem(treeView, treeViewItem);
                }
            }
        }

        #endregion

        #region ExpandMode
        public static ExpandMode GetExpandMode(DependencyObject obj)
        {
            return (ExpandMode)obj.GetValue(ExpandModeProperty);
        }

        public static void SetExpandMode(DependencyObject obj, ExpandMode value)
        {
            obj.SetValue(ExpandModeProperty, value);
        }

        public static readonly DependencyProperty ExpandModeProperty =
            DependencyProperty.RegisterAttached("ExpandMode", typeof(ExpandMode), typeof(TreeViewHelper), new PropertyMetadata(ExpandMode.DoubleClick, OnExpandModeChanged));

        private static void OnExpandModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeView = d as TreeView;

            treeView.RemoveHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(OnExpandModeItemSelected));

            if ((ExpandMode)e.NewValue == ExpandMode.SingleClick)
            {
                treeView.AddHandler(TreeViewItem.SelectedEvent, new RoutedEventHandler(OnExpandModeItemSelected));
            }
        }

        private static void OnExpandModeItemSelected(object sender, RoutedEventArgs e)
        {
            var treeView = sender as TreeView;
            if (e.OriginalSource is TreeViewItem)
            {
                var treeViewItem = e.OriginalSource as TreeViewItem;
                if (treeViewItem.HasItems)
                {
                    treeViewItem.IsExpanded = !treeViewItem.IsExpanded;
                }
            }
        }


        #endregion

        #region SelectedBrush
        public static Brush GetSelectedBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBrushProperty);
        }

        public static void SetSelectedBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBrushProperty, value);
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.RegisterAttached("SelectedBrush", typeof(Brush), typeof(TreeViewHelper));
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

        #region (Internal) LastSelectedItem
        internal static TreeViewItem GetLastSelectedItem(DependencyObject obj)
        {
            return (TreeViewItem)obj.GetValue(LastSelecteedItemProperty);
        }

        internal static void SetLastSelecteedItem(DependencyObject obj, TreeViewItem value)
        {
            obj.SetValue(LastSelecteedItemProperty, value);
        }

        internal static readonly DependencyProperty LastSelecteedItemProperty =
            DependencyProperty.RegisterAttached("LastSelecteedItem", typeof(TreeViewItem), typeof(TreeViewHelper));
        #endregion

    }
}
