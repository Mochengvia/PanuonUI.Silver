using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TreeViewHelper
    {
        static TreeViewHelper()
        {
            EventManager.RegisterClassHandler(typeof(TreeView), TreeView.SelectedItemChangedEvent, new RoutedEventHandler(TreeView_SelectedItemChanged));
            EventManager.RegisterClassHandler(typeof(TreeView), TreeViewItem.SelectedEvent, new RoutedEventHandler(TreeViewItem_Selected));
        }

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
            DependencyProperty.RegisterAttached("TreeViewStyle", typeof(TreeViewStyle), typeof(TreeViewHelper), new PropertyMetadata(TreeViewStyle.Standard));
        #endregion

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
            DependencyProperty.RegisterAttached("SelectMode", typeof(SelectMode), typeof(TreeViewHelper), new PropertyMetadata(SelectMode.Any));
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

            treeView.RemoveHandler(TreeViewItem.PreviewMouseDownEvent, new RoutedEventHandler(OnExpandModeItemSelected));

            if ((ExpandMode)e.NewValue == ExpandMode.SingleClick)
            {
                treeView.AddHandler(TreeViewItem.PreviewMouseDownEvent, new RoutedEventHandler(OnExpandModeItemSelected));
            }
        }

        private static void OnExpandModeItemSelected(object sender, RoutedEventArgs e)
        {
            var treeView = sender as TreeView;
            TreeViewItem treeViewItem = null;


            if (e.Source is TreeViewItem)
            {
                treeViewItem = e.Source as TreeViewItem;
            }
            else
            {
                treeViewItem = GetTreeViewItemFromChild(treeView, e.OriginalSource as UIElement);
            }

            if (treeViewItem != null && treeViewItem.HasItems)
            {
                treeViewItem.IsExpanded = !treeViewItem.IsExpanded;
            }
        }

        private static TreeViewItem GetTreeViewItemFromChild(TreeView treeView, UIElement child)
        {
            try
            {
                UIElement target = child;

                while ((target != null) && !(target is TreeViewItem))
                    target = VisualTreeHelper.GetParent(target) as UIElement;

                return target as TreeViewItem;
            }
            catch
            {
                return null;
            }

        }
        #endregion

        #region ExpandBehaviour
        public static ExpandBehaviour GetExpandBehaviour(DependencyObject obj)
        {
            return (ExpandBehaviour)obj.GetValue(ExpandBehaviourProperty);
        }

        public static void SetExpandBehaviour(DependencyObject obj, ExpandBehaviour value)
        {
            obj.SetValue(ExpandBehaviourProperty, value);
        }

        public static readonly DependencyProperty ExpandBehaviourProperty =
            DependencyProperty.RegisterAttached("ExpandBehaviour", typeof(ExpandBehaviour), typeof(TreeViewHelper), new PropertyMetadata(OnExpandBehaviourChanged));

        private static void OnExpandBehaviourChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeView = d as TreeView;

            treeView.RemoveHandler(TreeViewItem.ExpandedEvent, new RoutedEventHandler(OnExpandBehaviourItemSelected));

            if ((ExpandBehaviour)e.NewValue == ExpandBehaviour.OnlyOne)
            {
                treeView.AddHandler(TreeViewItem.ExpandedEvent, new RoutedEventHandler(OnExpandBehaviourItemSelected));
            }
        }

        private static void OnExpandBehaviourItemSelected(object sender, RoutedEventArgs e)
        {
            var treeView = sender as TreeView;
            TreeViewItem treeViewItem = null;

            if (e.Source is TreeViewItem)
            {
                treeViewItem = e.Source as TreeViewItem;
            }
            else
            {
                treeViewItem = GetTreeViewItemFromChild(treeView, e.OriginalSource as UIElement);
            }

            if (treeViewItem != null && treeViewItem.HasItems)
            {
                var lastTreeViewItem = GetLastExpandedItem(treeView);
                if (lastTreeViewItem != null)
                {
                    if (lastTreeViewItem == treeViewItem)
                        return;
                    lastTreeViewItem.IsExpanded = false;
                }

                SetLastExpandedItem(treeView, treeViewItem);
            }
        }

        #endregion

        #region ExpandedBrush
        public static Brush GetExpandedBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ExpandedBrushProperty);
        }

        public static void SetExpandedBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ExpandedBrushProperty, value);
        }

        public static readonly DependencyProperty ExpandedBrushProperty =
            DependencyProperty.RegisterAttached("ExpandedBrush", typeof(Brush), typeof(TreeViewHelper));
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
            return obj.GetValue(ItemIconProperty);
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

        #region (Internal) LastExpandedItem
        internal static TreeViewItem GetLastExpandedItem(DependencyObject obj)
        {
            return (TreeViewItem)obj.GetValue(LastExpandedItemProperty);
        }

        internal static void SetLastExpandedItem(DependencyObject obj, TreeViewItem value)
        {
            obj.SetValue(LastExpandedItemProperty, value);
        }

        internal static readonly DependencyProperty LastExpandedItemProperty =
            DependencyProperty.RegisterAttached("LastExpandedItem", typeof(TreeViewItem), typeof(TreeViewHelper));
        #endregion

        #region (Internal) TreeViewHook
        private static void TreeView_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                var treeView = sender as TreeView;
                var selectMode = GetSelectMode(treeView);

                if (selectMode == SelectMode.Any)
                    return;

                var sourceData = treeView.SelectedItem;
                if (sourceData is TreeViewItem)
                {
                    if (selectMode == SelectMode.ChildOnly && ((TreeViewItem)sourceData).HasItems)
                        e.Handled = true;
                    else if (selectMode == SelectMode.Disabled)
                        e.Handled = true;
                }
                else
                {
                    if (selectMode == SelectMode.Disabled)
                        e.Handled = true;
                    else if (selectMode == SelectMode.ChildOnly)
                    {
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
            }
            catch { }
        }

        private static void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var treeView = sender as TreeView;

                var selectMode = GetSelectMode(treeView);

                if (selectMode == SelectMode.Any)
                    return;

                if (e.OriginalSource is TreeViewItem)
                {
                    var treeViewItem = e.OriginalSource as TreeViewItem;

                    var oldItem = GetLastSelectedItem(treeView);
                    if ((selectMode == SelectMode.ChildOnly && treeViewItem.HasItems) || selectMode == SelectMode.Disabled)
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
            catch { }
        }

        #endregion

    }
}
