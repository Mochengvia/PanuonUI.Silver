using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        #region SelectedItems
        public static IList GetSelectedItems(DataGrid dataGrid)
        {
            return (IList)dataGrid.GetValue(SelectedItemsProperty);
        }

        internal static void SetSelectedItems(DataGrid dataGrid, IList value)
        {
            dataGrid.SetValue(SelectedItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(DataGridHelper));
        #endregion

        #endregion


        #region Internal Properties

        #region (Internal) DataGridHook
        internal static bool GetDataGridHook(DataGrid dataGrid)
        {
            return (bool)dataGrid.GetValue(DataGridHookProperty);
        }

        internal static void SetDataGridHook(DataGrid dataGrid, bool value)
        {
            dataGrid.SetValue(DataGridHookProperty, value);
        }

        internal static readonly DependencyProperty DataGridHookProperty =
            DependencyProperty.RegisterAttached("DataGridHook", typeof(bool), typeof(DataGridHelper), new PropertyMetadata(OnDataGridHookChanged));

        private static void OnDataGridHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;
            dataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            SetSelectedItems(dataGrid, dataGrid.SelectedItems);
        }

        private static void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            #region Get User Custom DataGridColumnAttribute

            var visibility = e.Column.Visibility;
            var width = dataGrid.ColumnWidth;
            var header = e.Column.Header;
            var readOnly = e.Column.IsReadOnly;
            var bindingMode = e.Column.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            var updateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            var descriptor = e.PropertyDescriptor as PropertyDescriptor;
            foreach (Attribute attribute in descriptor.Attributes)
            {
                if (attribute is DataGridColumnAttribute)
                {
                    var dgcAttribute = attribute as DataGridColumnAttribute;
                    if (dgcAttribute.ReadOnly)
                    {
                        readOnly = true;
                    }
                    if (dgcAttribute.Ignore)
                    {
                        visibility = Visibility.Collapsed;
                    }
                    if (!string.IsNullOrEmpty(dgcAttribute.ColumnWidth))
                    {
                        width = GridLengthUtils.ConvertToDataGridLength(dgcAttribute.ColumnWidth);
                    }
                    if (dgcAttribute.BindingMode != null)
                    {
                        bindingMode = (BindingMode)dgcAttribute.BindingMode;
                    }
                    if (dgcAttribute.UpdateSourceTrigger != null)
                    {
                        updateSourceTrigger = (UpdateSourceTrigger)dgcAttribute.UpdateSourceTrigger;
                    }
                }
                if (attribute is DisplayNameAttribute)
                {
                    header = (attribute as DisplayNameAttribute).DisplayName;
                }
            }
            #endregion

            if (e.PropertyType.IsEnum)
            {
                var newColumn = new DataGridComboBoxColumn()
                {
                    Width = width,
                    Header = header,
                    IsReadOnly = readOnly,
                    Visibility = visibility,
                };

                newColumn.ItemsSource = Enum.GetValues(e.PropertyType).Cast<Enum>();
                newColumn.SelectedItemBinding = new Binding(e.PropertyName) { Mode = bindingMode, UpdateSourceTrigger = updateSourceTrigger };
                newColumn.EditingElementStyle = new Style(typeof(ComboBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(ComboBox))
                };
                newColumn.EditingElementStyle.Setters.Add(new Setter(ComboBox.HeightProperty, 30.0));
                newColumn.EditingElementStyle.Setters.Add(new Setter(ComboBox.PaddingProperty, new Thickness(5, 0, 20, 0)));

                e.Column = newColumn;
            }
            else if (e.PropertyType == typeof(bool))
            {
                var newColumn = new DataGridCheckBoxColumn()
                {
                    Width = width,
                    Header = header,
                    IsReadOnly = readOnly,
                    Visibility = visibility,
                };

                newColumn.Binding = new Binding(e.PropertyName) { Mode = bindingMode, UpdateSourceTrigger = updateSourceTrigger };


                newColumn.ElementStyle = new Style(typeof(CheckBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(CheckBox))
                };
                newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.BorderThicknessProperty, new Thickness(1)));
                newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.BackgroundProperty, Colors.Transparent.ToBrush()));
                newColumn.ElementStyle.Setters.Add(new Setter(CheckBoxHelper.GlyphBrushProperty, Colors.Transparent.ToBrush()));


                newColumn.EditingElementStyle = new Style(typeof(CheckBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(CheckBox))
                };
                newColumn.EditingElementStyle.Setters.Add(new Setter(CheckBox.BorderThicknessProperty, new Thickness(1)));
                newColumn.EditingElementStyle.Setters.Add(new Setter(CheckBox.BackgroundProperty, Colors.Transparent.ToBrush()));
                newColumn.EditingElementStyle.Setters.Add(new Setter(CheckBoxHelper.GlyphBrushProperty, Colors.Transparent.ToBrush()));

                if (dataGrid.IsReadOnly)
                {
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.IsEnabledProperty, false));
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.OpacityProperty, 1.0));
                }

                newColumn.CellStyle = new Style(typeof(DataGridCell))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(DataGridCell)),
                };

                e.Column = newColumn;
            }
            else
            {
                var newColumn = new DataGridTextColumn()
                {
                    Width = width,
                    Header = header,
                    IsReadOnly = readOnly,
                    Visibility = visibility,
                };

                newColumn.Binding = new Binding(e.PropertyName) { Mode = bindingMode, UpdateSourceTrigger = updateSourceTrigger };

                newColumn.ElementStyle = new Style(typeof(TextBlock))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(TextBlock))
                };

                newColumn.ElementStyle.Setters.Add(new Setter(TextBox.MaxHeightProperty, 100.0));

                newColumn.EditingElementStyle = new Style(typeof(TextBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(TextBox))
                };

                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.MaxHeightProperty, 100.0));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.MarginProperty, new Thickness(2)));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBoxHelper.FocusedShadowColorProperty, Colors.Transparent));

                newColumn.CellStyle = new Style(typeof(DataGridCell))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(DataGridCell)),
                };
                newColumn.CellStyle.Setters.Add(new Setter(DataGridCell.PaddingProperty, new Thickness(0, 0, 10, 0)));

                e.Column = newColumn;
            }
        }

        #endregion

        #endregion

    }
}
