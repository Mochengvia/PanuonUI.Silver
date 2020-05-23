using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ListViewHelper
    {
        #region Properties

        #region HeaderSeparatorBrush
        public static Brush GetHeaderSeparatorBrush(ListView listView)
        {
            return (Brush)listView.GetValue(HeaderSeparatorBrushProperty);
        }

        public static void SetHeaderSeparatorBrush(ListView listView, Brush value)
        {
            listView.SetValue(HeaderSeparatorBrushProperty, value);
        }

        public static readonly DependencyProperty HeaderSeparatorBrushProperty =
            DependencyProperty.RegisterAttached("HeaderSeparatorBrush", typeof(Brush), typeof(ListViewHelper));

        #endregion

        #region HeaderPadding
        public static Thickness GetHeaderPadding(ListView listView)
        {
            return (Thickness)listView.GetValue(HeaderPaddingProperty);
        }

        public static void SetHeaderPadding(ListView listView, Thickness value)
        {
            listView.SetValue(HeaderPaddingProperty, value);
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.RegisterAttached("HeaderPadding", typeof(Thickness), typeof(ListViewHelper));
        #endregion

        #region HeaderBackground


        public static Brush GetHeaderBackground(ListView listView)
        {
            return (Brush)listView.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(ListView listView, Brush value)
        {
            listView.SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(ListViewHelper));


        #endregion

        #region HeaderForeground


        public static Brush GetHeaderForeground(ListView listView)
        {
            return (Brush)listView.GetValue(HeaderForegroundProperty);
        }

        public static void SetHeaderForeground(ListView listView, Brush value)
        {
            listView.SetValue(HeaderForegroundProperty, value);
        }

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.RegisterAttached("HeaderForeground", typeof(Brush), typeof(ListViewHelper));


        #endregion

        #region HeaderHoverBackground


        public static Brush GetHeaderHoverBackground(ListView listView)
        {
            return (Brush)listView.GetValue(HeaderHoverBackgroundProperty);
        }

        public static void SetHeaderHoverBackground(ListView listView, Brush value)
        {
            listView.SetValue(HeaderHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderHoverBackground", typeof(Brush), typeof(ListViewHelper));


        #endregion

        #region HeaderHoverForeground


        public static Brush GetHeaderHoverForeground(ListView listView)
        {
            return (Brush)listView.GetValue(HeaderHoverForegroundProperty);
        }

        public static void SetHeaderHoverForeground(ListView listView, Brush value)
        {
            listView.SetValue(HeaderHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HeaderHoverForegroundProperty =
            DependencyProperty.RegisterAttached("HeaderHoverForeground", typeof(Brush), typeof(ListViewHelper));


        #endregion

        #region HeaderHeight
        public static double GetHeaderHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeaderHeightProperty);
        }

        public static void SetHeaderHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeaderHeightProperty, value);
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.RegisterAttached("HeaderHeight", typeof(double), typeof(ListViewHelper));
        #endregion

        #region HeaderHorizontalContentAlignment
        public static HorizontalAlignment GetHeaderHorizontalContentAlignment(ListView listView)
        {
            return (HorizontalAlignment)listView.GetValue(HeaderHorizontalContentAlignmentProperty);
        }

        public static void SetHeaderHorizontalContentAlignment(ListView listView, HorizontalAlignment value)
        {
            listView.SetValue(HeaderHorizontalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty HeaderHorizontalContentAlignmentProperty =
            DependencyProperty.RegisterAttached("HeaderHorizontalContentAlignment", typeof(HorizontalAlignment), typeof(ListViewHelper));
        #endregion

        #region ResizeThumbThickness
        public static double GetResizeThumbThickness(ListView ListView)
        {
            return (double)ListView.GetValue(ResizeThumbThicknessProperty);
        }

        public static void SetResizeThumbThickness(ListView ListView, double value)
        {
            ListView.SetValue(ResizeThumbThicknessProperty, value);
        }

        public static readonly DependencyProperty ResizeThumbThicknessProperty =
            DependencyProperty.RegisterAttached("ResizeThumbThickness", typeof(double), typeof(ListViewHelper));
        #endregion

        #region ItemsCornerRadius
        public static CornerRadius GetItemsCornerRadius(ListView listView)
        {
            return (CornerRadius)listView.GetValue(ItemCornerRadiusProperty);
        }

        public static void SetItemsCornerRadius(ListView listView, CornerRadius value)
        {
            listView.SetValue(ItemsCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemsCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemsCornerRadius", typeof(CornerRadius), typeof(ListViewHelper));

        public static CornerRadius GetItemCornerRadius(ListViewItem listViewItem)
        {
            return (CornerRadius)listViewItem.GetValue(ItemCornerRadiusProperty);
        }

        public static void SetItemCornerRadius(ListViewItem listViewItem, CornerRadius value)
        {
            listViewItem.SetValue(ItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemCornerRadius", typeof(CornerRadius), typeof(ListViewHelper));

        #endregion

        #region ItemForeground
        public static Brush GetItemsForeground(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsForegroundProperty);
        }

        public static void SetItemsForeground(ListView listView, Brush value)
        {
            listView.SetValue(ItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsForeground", typeof(Brush), typeof(ListViewHelper));


        public static Brush GetItemForeground(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemForegroundProperty);
        }

        public static void SetItemForeground(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyProperty.RegisterAttached("ItemForeground", typeof(Brush), typeof(ListViewHelper));
        #endregion

        #region ItemBackground
        public static Brush GetItemsBackground(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsBackgroundProperty);
        }

        public static void SetItemsBackground(ListView listView, Brush value)
        {
            listView.SetValue(ItemsBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsBackground", typeof(Brush), typeof(ListViewHelper));

        #endregion

        #region ItemBorderBrush
        public static Brush GetItemsBorderBrush(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsBorderBrushProperty);
        }

        public static void SetItemsBorderBrush(ListView listView, Brush value)
        {
            listView.SetValue(ItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsBorderBrush", typeof(Brush), typeof(ListViewHelper));

        #endregion

        #region ItemHoverBackground
        public static Brush GetItemsHoverBackground(ListView listView)
        {
            return (Brush)listView.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemsHoverBackground(ListView listView, Brush value)
        {
            listView.SetValue(ItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBackground", typeof(Brush), typeof(ListViewHelper));

        public static Brush GetItemHoverBackground(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemHoverBackground(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverBackground", typeof(Brush), typeof(ListViewHelper));
#endregion

        #region ItemHoverForeground
        public static Brush GetItemsHoverForeground(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsHoverForegroundProperty);
        }

        public static void SetItemsHoverForeground(ListView listView, Brush value)
        {
            listView.SetValue(ItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverForeground", typeof(Brush), typeof(ListViewHelper));



        public static Brush GetItemHoverForeground(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemHoverForeground(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverForeground", typeof(Brush), typeof(ListViewHelper));


        #endregion

        #region ItemHoverBorderBrush
        public static Brush GetItemsHoverBorderBrush(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsHoverBorderBrushProperty);
        }

        public static void SetItemsHoverBorderBrush(ListView listView, Brush value)
        {
            listView.SetValue(ItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBorderBrush", typeof(Brush), typeof(ListViewHelper));

        public static Brush GetItemHoverBorderBrush(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemHoverBorderBrushProperty);
        }

        public static void SetItemHoverBorderBrush(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderBrush", typeof(Brush), typeof(ListViewHelper));
        #endregion

        #region ItemSelectedBackground
        public static Brush GetItemsSelectedBackground(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsSelectedBackgroundProperty);
        }

        public static void SetItemsSelectedBackground(ListView listView, Brush value)
        {
            listView.SetValue(ItemsSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBackground", typeof(Brush), typeof(ListViewHelper));

        public static Brush GetItemSelectedBackground(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(ListViewHelper));
        #endregion

        #region ItemSelectedForeground
        public static Brush GetItemsSelectedForeground(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsSelectedForegroundProperty);
        }

        public static void SetItemsSelectedForeground(ListView listView, Brush value)
        {
            listView.SetValue(ItemsSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedForeground", typeof(Brush), typeof(ListViewHelper));


        public static Brush GetItemSelectedForeground(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(ListViewHelper));


        #endregion

        #region ItemSelectedBorderBrush
        public static Brush GetItemsSelectedBorderBrush(ListView listView)
        {
            return (Brush)listView.GetValue(ItemsSelectedBorderBrushProperty);
        }

        public static void SetItemsSelectedBorderBrush(ListView listView, Brush value)
        {
            listView.SetValue(ItemsSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderBrush", typeof(Brush), typeof(ListViewHelper));

        public static Brush GetItemSelectedBorderBrush(ListViewItem listViewItem)
        {
            return (Brush)listViewItem.GetValue(ItemSelectedBorderBrushProperty);
        }

        public static void SetItemSelectedBorderBrush(ListViewItem listViewItem, Brush value)
        {
            listViewItem.SetValue(ItemSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderBrush", typeof(Brush), typeof(ListViewHelper));
        #endregion

        #region ItemsHeight


        public static double GetItemsHeight(ListView listView)
        {
            return (double)listView.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(ListView listView, double value)
        {
            listView.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(ListViewHelper));


        #endregion

        #region ItemIcon
        public static object GetItemsIcon(ListView listView)
        {
            return (object)listView.GetValue(ItemsIconProperty);
        }

        public static void SetItemsIcon(ListView listView, object value)
        {
            listView.SetValue(ItemsIconProperty, value);
        }

        public static readonly DependencyProperty ItemsIconProperty =
            DependencyProperty.RegisterAttached("ItemsIcon", typeof(object), typeof(ListViewHelper));

        public static object GetItemIcon(ListViewItem listViewItem)
        {
            return (object)listViewItem.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(ListViewItem listViewItem, object value)
        {
            listViewItem.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(ListViewHelper));

        #endregion

        #endregion
    }
}
