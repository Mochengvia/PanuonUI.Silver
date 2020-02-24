using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ListBoxHelper
    {
        #region Properties

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


        public static double GetItemsHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(ListBoxHelper));


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
