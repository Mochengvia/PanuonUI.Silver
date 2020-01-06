using Panuon.UI.Silver.Internal.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class DataGridHelper
    {
        #region Ctor
        static DataGridHelper()
        {
        }
        #endregion

        #region Properties

        #region HeaderPadding
        public static Thickness GetHeaderPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HeaderPaddingProperty);
        }

        public static void SetHeaderPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HeaderPaddingProperty, value);
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.RegisterAttached("HeaderPadding", typeof(Thickness), typeof(DataGridHelper));
        #endregion

        #region CellPadding


        public static Thickness GetCellPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(CellPaddingProperty);
        }

        public static void SetCellPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(CellPaddingProperty, value);
        }

        public static readonly DependencyProperty CellPaddingProperty =
            DependencyProperty.RegisterAttached("CellPadding", typeof(Thickness), typeof(DataGridHelper));


        #endregion

        #region MinHeaderHeight


        public static double GetMinHeaderHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(MinHeaderHeightProperty);
        }

        public static void SetMinHeaderHeight(DependencyObject obj, double value)
        {
            obj.SetValue(MinHeaderHeightProperty, value);
        }

        public static readonly DependencyProperty MinHeaderHeightProperty =
            DependencyProperty.RegisterAttached("MinHeaderHeight", typeof(double), typeof(DataGridHelper));

        #endregion

        #region HeaderBackground


        public static Brush GetHeaderBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region HeaderForeground


        public static Brush GetHeaderForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderForegroundProperty);
        }

        public static void SetHeaderForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderForegroundProperty, value);
        }

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.RegisterAttached("HeaderForeground", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region ResizeThumbThickness
        public static double GetResizeThumbThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(ResizeThumbThicknessProperty);
        }

        public static void SetResizeThumbThickness(DependencyObject obj, double value)
        {
            obj.SetValue(ResizeThumbThicknessProperty, value);
        }

        public static readonly DependencyProperty ResizeThumbThicknessProperty =
            DependencyProperty.RegisterAttached("ResizeThumbThickness", typeof(double), typeof(DataGridHelper));
        #endregion

        #region ResizeThumbBrush
        public static Brush GetResizeThumbBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ResizeThumbBrushProperty);
        }

        public static void SetResizeThumbBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ResizeThumbBrushProperty, value);
        }

        public static readonly DependencyProperty ResizeThumbBrushProperty =
            DependencyProperty.RegisterAttached("ResizeThumbBrush", typeof(Brush), typeof(DataGridHelper));
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
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(DataGridHelper));
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
            DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(DataGridHelper));
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
            DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region AutoGenerateCheckBoxStyle
        public static Style GetAutoGenerateCheckBoxStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(AutoGenerateCheckBoxStyleProperty);
        }

        public static void SetAutoGenerateCheckBoxStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(AutoGenerateCheckBoxStyleProperty, value);
        }

        public static readonly DependencyProperty AutoGenerateCheckBoxStyleProperty =
            DependencyProperty.RegisterAttached("AutoGenerateCheckBoxStyle", typeof(Style), typeof(DataGridHelper));
        #endregion

        #region SelectedItems
        public static IList GetSelectedItems(DependencyObject obj)
        {
            return (IList)obj.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(DependencyObject obj, IList value)
        {
            obj.SetValue(SelectedItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(DataGridHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region DataGridHook
        public static bool GetDataGridHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(DataGridHookProperty);
        }

        public static void SetDataGridHook(DependencyObject obj, bool value)
        {
            obj.SetValue(DataGridHookProperty, value);
        }

        public static readonly DependencyProperty DataGridHookProperty =
            DependencyProperty.RegisterAttached("DataGridHook", typeof(bool), typeof(DataGridHelper));
        #endregion

        #endregion

        #region Event Handler
        private static void OnDataGridHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;
        }

        #endregion
    }
}
