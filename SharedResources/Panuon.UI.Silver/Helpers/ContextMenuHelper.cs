using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ContextMenuHelper
    {
        #region Properties

        #region CornerRadius
        public static CornerRadius GetCornerRadius(ContextMenu contextMenu)
        {
            return (CornerRadius)contextMenu.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(ContextMenu contextMenu, CornerRadius value)
        {
            contextMenu.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ContextMenuHelper));
        #endregion

        #region ItemForeground
        public static Brush GetItemsForeground(ContextMenu contextMenu)
        {
            return (Brush)contextMenu.GetValue(ItemsForegroundProperty);
        }

        public static void SetItemsForeground(ContextMenu contextMenu, Brush value)
        {
            contextMenu.SetValue(ItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsForeground", typeof(Brush), typeof(ContextMenuHelper));


        public static Brush GetItemForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(ItemForegroundProperty);
        }

        public static void SetItemForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(ItemForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyProperty.RegisterAttached("ItemForeground", typeof(Brush), typeof(ContextMenuHelper));
        #endregion

        #region ItemBackground
        public static Brush GetItemsBackground(ContextMenu contextMenu)
        {
            return (Brush)contextMenu.GetValue(ItemsBackgroundProperty);
        }

        public static void SetItemsBackground(ContextMenu contextMenu, Brush value)
        {
            contextMenu.SetValue(ItemsBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsBackground", typeof(Brush), typeof(ContextMenuHelper));

        #endregion

        #region ItemBorderBrush
        public static Brush GetItemsBorderBrush(ContextMenu contextMenu)
        {
            return (Brush)contextMenu.GetValue(ItemsBorderBrushProperty);
        }

        public static void SetItemsBorderBrush(ContextMenu contextMenu, Brush value)
        {
            contextMenu.SetValue(ItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsBorderBrush", typeof(Brush), typeof(ContextMenuHelper));

        #endregion

        #region ItemHoverBackground
        public static Brush GetItemsHoverBackground(ContextMenu contextMenu)
        {
            return (Brush)contextMenu.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemsHoverBackground(ContextMenu contextMenu, Brush value)
        {
            contextMenu.SetValue(ItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBackground", typeof(Brush), typeof(ContextMenuHelper));

        public static Brush GetItemHoverBackground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemHoverBackground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(ItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverBackground", typeof(Brush), typeof(ContextMenuHelper));
        #endregion

        #region ItemHoverForeground
        public static Brush GetItemsHoverForeground(ContextMenu contextMenu)
        {
            return (Brush)contextMenu.GetValue(ItemsHoverForegroundProperty);
        }

        public static void SetItemsHoverForeground(ContextMenu contextMenu, Brush value)
        {
            contextMenu.SetValue(ItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverForeground", typeof(Brush), typeof(ContextMenuHelper));



        public static Brush GetItemHoverForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemHoverForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverForeground", typeof(Brush), typeof(ContextMenuHelper));


        #endregion

        #region ItemHoverBorderBrush
        public static Brush GetItemsHoverBorderBrush(ContextMenu contextMenu)
        {
            return (Brush)contextMenu.GetValue(ItemsHoverBorderBrushProperty);
        }

        public static void SetItemsHoverBorderBrush(ContextMenu contextMenu, Brush value)
        {
            contextMenu.SetValue(ItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBorderBrush", typeof(Brush), typeof(ContextMenuHelper));

        public static Brush GetItemHoverBorderBrush(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(ItemHoverBorderBrushProperty);
        }

        public static void SetItemHoverBorderBrush(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderBrush", typeof(Brush), typeof(ContextMenuHelper));
        #endregion

        #region ItemsHeight
        public static double GetItemsHeight(ContextMenu contextMneu)
        {
            return (double)contextMneu.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(ContextMenu contextMenu, double value)
        {
            contextMenu.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(ContextMenuHelper));
        #endregion

        #region ItemMinWidth
        public static double GetItemsMinWidth(ContextMenu contextMenu)
        {
            return (double)contextMenu.GetValue(ItemsMinWidthProperty);
        }

        public static void SetItemsMinWidth(ContextMenu contextMenu, double value)
        {
            contextMenu.SetValue(ItemsMinWidthProperty, value);
        }

        public static readonly DependencyProperty ItemsMinWidthProperty =
            DependencyProperty.RegisterAttached("ItemsMinWidth", typeof(double), typeof(ContextMenuHelper));
        #endregion


        #region ItemIcon
        public static object GetItemsIcon(ContextMenu contextMenu)
        {
            return (object)contextMenu.GetValue(ItemsIconProperty);
        }

        public static void SetItemsIcon(ContextMenu contextMenu, object value)
        {
            contextMenu.SetValue(ItemsIconProperty, value);
        }

        public static readonly DependencyProperty ItemsIconProperty =
            DependencyProperty.RegisterAttached("ItemsIcon", typeof(object), typeof(ContextMenuHelper));
        #endregion

        #region ShadowColor
        public static Color? GetShadowColor(ContextMenu contextMenu)
        {
            return (Color?)contextMenu.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(ContextMenu contextMenu, Color? value)
        {
            contextMenu.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color?), typeof(ContextMenuHelper));
        #endregion

        #endregion
    }
}
