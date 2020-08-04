using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ListBoxHelper
    {
        #region Properties

        #region ItemsCornerRadius
        public static CornerRadius GetItemsCornerRadius(ListBox listBox)
        {
            return (CornerRadius)listBox.GetValue(ItemCornerRadiusProperty);
        }

        public static void SetItemsCornerRadius(ListBox listBox, CornerRadius value)
        {
            listBox.SetValue(ItemsCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemsCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemsCornerRadius", typeof(CornerRadius), typeof(ListBoxHelper));

        public static CornerRadius GetItemCornerRadius(ListBoxItem listBoxItem)
        {
            return (CornerRadius)listBoxItem.GetValue(ItemCornerRadiusProperty);
        }

        public static void SetItemCornerRadius(ListBoxItem listBoxItem, CornerRadius value)
        {
            listBoxItem.SetValue(ItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemCornerRadius", typeof(CornerRadius), typeof(ListBoxHelper));

        #endregion

        #region ItemForeground
        public static Brush GetItemsForeground(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsForegroundProperty);
        }

        public static void SetItemsForeground(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsForeground", typeof(Brush), typeof(ListBoxHelper));


        public static Brush GetItemForeground(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemForegroundProperty);
        }

        public static void SetItemForeground(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyProperty.RegisterAttached("ItemForeground", typeof(Brush), typeof(ListBoxHelper));
        #endregion

        #region ItemBackground
        public static Brush GetItemsBackground(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsBackgroundProperty);
        }

        public static void SetItemsBackground(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsBackground", typeof(Brush), typeof(ListBoxHelper));

        #endregion

        #region ItemBorderBrush
        public static Brush GetItemsBorderBrush(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsBorderBrushProperty);
        }

        public static void SetItemsBorderBrush(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsBorderBrush", typeof(Brush), typeof(ListBoxHelper));

        #endregion

        #region ItemHoverBackground
        public static Brush GetItemsHoverBackground(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemsHoverBackground(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBackground", typeof(Brush), typeof(ListBoxHelper));

        public static Brush GetItemHoverBackground(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemHoverBackground(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverBackground", typeof(Brush), typeof(ListBoxHelper));
        #endregion

        #region ItemHoverForeground
        public static Brush GetItemsHoverForeground(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsHoverForegroundProperty);
        }

        public static void SetItemsHoverForeground(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverForeground", typeof(Brush), typeof(ListBoxHelper));



        public static Brush GetItemHoverForeground(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemHoverForeground(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverForeground", typeof(Brush), typeof(ListBoxHelper));


        #endregion

        #region ItemHoverBorderBrush
        public static Brush GetItemsHoverBorderBrush(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsHoverBorderBrushProperty);
        }

        public static void SetItemsHoverBorderBrush(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBorderBrush", typeof(Brush), typeof(ListBoxHelper));

        public static Brush GetItemHoverBorderBrush(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemHoverBorderBrushProperty);
        }

        public static void SetItemHoverBorderBrush(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderBrush", typeof(Brush), typeof(ListBoxHelper));
        #endregion

        #region ItemSelectedBackground
        public static Brush GetItemsSelectedBackground(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsSelectedBackgroundProperty);
        }

        public static void SetItemsSelectedBackground(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBackground", typeof(Brush), typeof(ListBoxHelper));

        public static Brush GetItemSelectedBackground(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(ListBoxHelper));
        #endregion

        #region ItemSelectedForeground
        public static Brush GetItemsSelectedForeground(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsSelectedForegroundProperty);
        }

        public static void SetItemsSelectedForeground(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedForeground", typeof(Brush), typeof(ListBoxHelper));


        public static Brush GetItemSelectedForeground(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(ListBoxHelper));


        #endregion

        #region ItemSelectedBorderBrush
        public static Brush GetItemsSelectedBorderBrush(ListBox listBox)
        {
            return (Brush)listBox.GetValue(ItemsSelectedBorderBrushProperty);
        }

        public static void SetItemsSelectedBorderBrush(ListBox listBox, Brush value)
        {
            listBox.SetValue(ItemsSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderBrush", typeof(Brush), typeof(ListBoxHelper));

        public static Brush GetItemSelectedBorderBrush(ListBoxItem listBoxItem)
        {
            return (Brush)listBoxItem.GetValue(ItemSelectedBorderBrushProperty);
        }

        public static void SetItemSelectedBorderBrush(ListBoxItem listBoxItem, Brush value)
        {
            listBoxItem.SetValue(ItemSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderBrush", typeof(Brush), typeof(ListBoxHelper));
        #endregion

        #region ItemsHeight
        public static double GetItemsHeight(ListBox listBox)
        {
            return (double)listBox.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(ListBox listBox, double value)
        {
            listBox.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(ListBoxHelper));
        #endregion

        #region ItemsWidth
        public static double GetItemsWidth(ListBox listBox)
        {
            return (double)listBox.GetValue(ItemsWidthProperty);
        }

        public static void SetItemsWidth(ListBox listBox, double value)
        {
            listBox.SetValue(ItemsWidthProperty, value);
        }

        public static readonly DependencyProperty ItemsWidthProperty =
            DependencyProperty.RegisterAttached("ItemsWidth", typeof(double), typeof(ListBoxHelper));
        #endregion

        #region ItemIcon
        public static object GetItemsIcon(ListBox listBox)
        {
            return (object)listBox.GetValue(ItemsIconProperty);
        }

        public static void SetItemsIcon(ListBox listBox, object value)
        {
            listBox.SetValue(ItemsIconProperty, value);
        }

        public static readonly DependencyProperty ItemsIconProperty =
            DependencyProperty.RegisterAttached("ItemsIcon", typeof(object), typeof(ListBoxHelper));

        public static object GetItemIcon(ListBoxItem listBoxItem)
        {
            return (object)listBoxItem.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(ListBoxItem listBoxItem, object value)
        {
            listBoxItem.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(ListBoxHelper));

        #endregion

        #endregion
    }
}
