using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Utils;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;


namespace Panuon.UI.Silver
{
    public class DataGridHelper
    {
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

        #region HeaderMinHeight
        public static double GetHeaderMinHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeaderMinHeightProperty);
        }

        public static void SetHeaderMinHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeaderMinHeightProperty, value);
        }

        public static readonly DependencyProperty HeaderMinHeightProperty =
            DependencyProperty.RegisterAttached("HeaderMinHeight", typeof(double), typeof(DataGridHelper));
        #endregion

        #region RowMinHeight
        public static double GetRowMinHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(RowMinHeightProperty);
        }

        public static void SetRowMinHeight(DependencyObject obj, double value)
        {
            obj.SetValue(RowMinHeightProperty, value);
        }

        public static readonly DependencyProperty RowMinHeightProperty =
            DependencyProperty.RegisterAttached("RowMinHeight", typeof(double), typeof(DataGridHelper));


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

        #region ColumnVerticalContentAlignment
        public static VerticalAlignment GetColumnVerticalContentAlignment(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(ColumnVerticalContentAlignmentProperty);
        }

        public static void SetColumnVerticalContentAlignment(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(ColumnVerticalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty ColumnVerticalContentAlignmentProperty =
            DependencyProperty.RegisterAttached("ColumnVerticalContentAlignment", typeof(VerticalAlignment), typeof(DataGridHelper));
        #endregion

        #region ColumnHorizontalContentAlignment
        public static HorizontalAlignment GetColumnHorizontalContentAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(ColumnHorizontalContentAlignmentProperty);
        }

        public static void SetColumnHorizontalContentAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(ColumnHorizontalContentAlignmentProperty, value);
        }

        public static readonly DependencyProperty ColumnHorizontalContentAlignmentProperty =
            DependencyProperty.RegisterAttached("ColumnHorizontalContentAlignment", typeof(HorizontalAlignment), typeof(DataGridHelper));
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

        #region (Internal) DataGridHook
        internal static bool GetDataGridHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(DataGridHookProperty);
        }

        internal static void SetDataGridHook(DependencyObject obj, bool value)
        {
            obj.SetValue(DataGridHookProperty, value);
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
            var width = e.Column.Width;
            var header = e.Column.Header;
            var readOnly = e.Column.IsReadOnly;
            var bindingMode = BindingMode.TwoWay;
            var updateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            var descriptor = e.PropertyDescriptor as PropertyDescriptor;
            foreach (Attribute attribute in descriptor.Attributes)
            {
                if (attribute is IgnoreColumnAttribute)
                {
                    visibility = Visibility.Collapsed;
                }
                if (attribute is ColumnWidthAttribute)
                {
                    width = GridLengthUtil.ConvertToDataGridLength((attribute as ColumnWidthAttribute).Width);
                }
                if (attribute is DisplayNameAttribute)
                {
                    header = (attribute as DisplayNameAttribute).DisplayName;
                }
                if (attribute is ReadOnlyColumnAttribute)
                {
                    readOnly = true;
                }
                if(attribute is ColumnBindingAttribute)
                {
                    var binding = attribute as ColumnBindingAttribute;
                    bindingMode = binding.BindingMode;
                    updateSourceTrigger = binding.UpdateSourceTrigger;
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

                var userStyle = GetAutoGenerateCheckBoxStyle(dataGrid);
                if (userStyle == null)
                {
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
                }
                else
                {
                    newColumn.ElementStyle = userStyle;
                    newColumn.EditingElementStyle = userStyle;
                }

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

        #region Function

        #endregion
    }
}