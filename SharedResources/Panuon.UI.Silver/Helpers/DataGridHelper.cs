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

        #region HeaderHoverBackground


        public static Brush GetHeaderHoverBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(HeaderHoverBackgroundProperty);
        }

        public static void SetHeaderHoverBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(HeaderHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderHoverBackground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region HeaderHoverForeground


        public static Brush GetHeaderHoverForeground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(HeaderHoverForegroundProperty);
        }

        public static void SetHeaderHoverForeground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(HeaderHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HeaderHoverForegroundProperty =
            DependencyProperty.RegisterAttached("HeaderHoverForeground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region UnitPadding


        public static Thickness GetUnitPadding(DataGrid dataGrid)
        {
            return (Thickness)dataGrid.GetValue(UnitPaddingProperty);
        }

        public static void SetUnitPadding(DataGrid dataGrid, Thickness value)
        {
            dataGrid.SetValue(UnitPaddingProperty, value);
        }

        public static readonly DependencyProperty UnitPaddingProperty =
            DependencyProperty.RegisterAttached("UnitPadding", typeof(Thickness), typeof(DataGridHelper));


        #endregion

        #region UnitHoverBackground


        public static Brush GetUnitHoverBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(UnitHoverBackgroundProperty);
        }

        public static void SetUnitHoverBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(UnitHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty UnitHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("UnitHoverBackground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region UnitHoverForeground


        public static Brush GetUnitHoverForeground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(UnitHoverForegroundProperty);
        }

        public static void SetUnitHoverForeground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(UnitHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty UnitHoverForegroundProperty =
            DependencyProperty.RegisterAttached("UnitHoverForeground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region UnitSelectedBackground


        public static Brush GetUnitSelectedBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(UnitSelectedBackgroundProperty);
        }

        public static void SetUnitSelectedBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(UnitSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty UnitSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("UnitSelectedBackground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region UnitSelectedForeground


        public static Brush GetUnitSelectedForeground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(UnitSelectedForegroundProperty);
        }

        public static void SetUnitSelectedForeground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(UnitSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty UnitSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("UnitSelectedForeground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region RowHeaderBackground


        public static Brush GetRowHeaderBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(RowHeaderBackgroundProperty);
        }

        public static void SetRowHeaderBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(RowHeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty RowHeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("RowHeaderBackground", typeof(Brush), typeof(DataGridHelper));


        #endregion

        #region RowHeaderHoverBackground


        public static Brush GetRowHeaderHoverBackground(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(RowHeaderHoverBackgroundProperty);
        }

        public static void SetRowHeaderHoverBackground(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(RowHeaderHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty RowHeaderHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("RowHeaderHoverBackground", typeof(Brush), typeof(DataGridHelper));


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

        #region CellFocusedHightlightBorderBrush


        public static Brush GetCellFocusedHightlightBorderBrush(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(CellFocusedHightlightBorderBrushProperty);
        }

        public static void SetCellFocusedHightlightBorderBrush(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(CellFocusedHightlightBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CellFocusedHightlightBorderBrushProperty =
            DependencyProperty.RegisterAttached("CellFocusedHightlightBorderBrush", typeof(Brush), typeof(DataGridHelper));

        #endregion

        #endregion
    }
}
