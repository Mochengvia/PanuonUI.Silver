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
        public static Thickness GetHeaderPadding(DataGrid dataGrid)
        {
            return (Thickness)dataGrid.GetValue(HeaderPaddingProperty);
        }

        public static void SetHeaderPadding(DataGrid dataGrid, Thickness value)
        {
            dataGrid.SetValue(HeaderPaddingProperty, value);
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.RegisterAttached("HeaderPadding", typeof(Thickness), typeof(DataGridHelper));
        #endregion

        #region CellPadding


        public static Thickness GetCellPadding(DataGrid dataGrid)
        {
            return (Thickness)dataGrid.GetValue(CellPaddingProperty);
        }

        public static void SetCellPadding(DataGrid dataGrid, Thickness value)
        {
            dataGrid.SetValue(CellPaddingProperty, value);
        }

        public static readonly DependencyProperty CellPaddingProperty =
            DependencyProperty.RegisterAttached("CellPadding", typeof(Thickness), typeof(DataGridHelper));


        #endregion

        #region MinHeaderHeight


        public static double GetMinHeaderHeight(DataGrid dataGrid)
        {
            return (double)dataGrid.GetValue(MinHeaderHeightProperty);
        }

        public static void SetMinHeaderHeight(DataGrid dataGrid, double value)
        {
            dataGrid.SetValue(MinHeaderHeightProperty, value);
        }

        public static readonly DependencyProperty MinHeaderHeightProperty =
            DependencyProperty.RegisterAttached("MinHeaderHeight", typeof(double), typeof(DataGridHelper));

        #endregion

        #region HeaderBackground


        public static Brush GetHeaderBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region HeaderForeground


        public static Brush GetHeaderForeground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(HeaderForegroundProperty);
        }

        public static void SetHeaderForeground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(HeaderForegroundProperty, value);
        }

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.RegisterAttached("HeaderForeground", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region ResizeThumbThickness
        public static double GetResizeThumbThickness(DataGrid dataGrid)
        {
            return (double)dataGrid.GetValue(ResizeThumbThicknessProperty);
        }

        public static void SetResizeThumbThickness(DataGrid dataGrid, double value)
        {
            dataGrid.SetValue(ResizeThumbThicknessProperty, value);
        }

        public static readonly DependencyProperty ResizeThumbThicknessProperty =
            DependencyProperty.RegisterAttached("ResizeThumbThickness", typeof(double), typeof(DataGridHelper));
        #endregion

        #region ResizeThumbBrush
        public static Brush GetResizeThumbBrush(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(ResizeThumbBrushProperty);
        }

        public static void SetResizeThumbBrush(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(ResizeThumbBrushProperty, value);
        }

        public static readonly DependencyProperty ResizeThumbBrushProperty =
            DependencyProperty.RegisterAttached("ResizeThumbBrush", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region HoverBackground
        public static Brush GetHoverBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region SelectedBackground
        public static Brush GetSelectedBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(SelectedBackgroundProperty);
        }

        public static void SetSelectedBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region SelectedForeground
        public static Brush GetSelectedForeground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(SelectedForegroundProperty);
        }

        public static void SetSelectedForeground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(SelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(DataGridHelper));
        #endregion

        #region AutoGenerateCheckBoxStyle
        public static Style GetAutoGenerateCheckBoxStyle(DataGrid dataGrid)
        {
            return (Style)dataGrid.GetValue(AutoGenerateCheckBoxStyleProperty);
        }

        public static void SetAutoGenerateCheckBoxStyle(DataGrid dataGrid, Style value)
        {
            dataGrid.SetValue(AutoGenerateCheckBoxStyleProperty, value);
        }

        public static readonly DependencyProperty AutoGenerateCheckBoxStyleProperty =
            DependencyProperty.RegisterAttached("AutoGenerateCheckBoxStyle", typeof(Style), typeof(DataGridHelper));
        #endregion

        #region SelectedItems
        public static IList GetSelectedItems(DataGrid dataGrid)
        {
            return (IList)dataGrid.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(DataGrid dataGrid, IList value)
        {
            dataGrid.SetValue(SelectedItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(DataGridHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region DataGridHook
        public static bool GetDataGridHook(DataGrid dataGrid)
        {
            return (bool)dataGrid.GetValue(DataGridHookProperty);
        }

        public static void SetDataGridHook(DataGrid dataGrid, bool value)
        {
            dataGrid.SetValue(DataGridHookProperty, value);
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
