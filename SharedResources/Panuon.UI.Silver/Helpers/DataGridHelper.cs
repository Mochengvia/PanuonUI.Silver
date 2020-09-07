using Panuon.UI.Silver.Core;
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
    public static class DataGridHelper
    {
        #region Ctor
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

        #region HorizontalHeaderAlignment
        public static HorizontalAlignment GetHorizontalHeaderAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(HorizontalHeaderAlignmentProperty);
        }

        public static void SetHorizontalHeaderAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(HorizontalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("HorizontalHeaderAlignment", typeof(HorizontalAlignment), typeof(DataGridHelper));
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

        #region HeaderGridLinesVisibility
        public static DataGridGridLinesVisibility GetHeaderGridLinesVisibility(DataGrid dataGrid)
        {
            return (DataGridGridLinesVisibility)dataGrid.GetValue(HeaderGridLinesVisibilityProperty);
        }

        public static void SetHeaderGridLinesVisibility(DataGrid dataGrid, DataGridGridLinesVisibility value)
        {
            dataGrid.SetValue(HeaderGridLinesVisibilityProperty, value);
        }

        public static readonly DependencyProperty HeaderGridLinesVisibilityProperty =
            DependencyProperty.RegisterAttached("HeaderGridLinesVisibility", typeof(DataGridGridLinesVisibility), typeof(DataGridHelper));
        #endregion

        #region HeaderVerticalGridLinesBrush
        public static Brush GetHeaderVerticalGridLinesBrush(DataGrid dataGrid)
        {
            return (Brush)dataGrid.GetValue(HeaderVerticalGridLinesBrushProperty);
        }

        public static void SetHeaderVerticalGridLinesBrush(DataGrid dataGrid, Brush value)
        {
            dataGrid.SetValue(HeaderVerticalGridLinesBrushProperty, value);
        }

        public static readonly DependencyProperty HeaderVerticalGridLinesBrushProperty =
            DependencyProperty.RegisterAttached("HeaderVerticalGridLinesBrush", typeof(Brush), typeof(DataGridHelper));
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
            if (dataGrid != null)
            {
                dataGrid.AutoGeneratingColumn -= DataGrid_AutoGeneratingColumn;
                dataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
                SetSelectedItems(dataGrid, dataGrid.SelectedItems);
            }
        }

        private static void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            var descriptor = e.PropertyDescriptor as PropertyDescriptor;
            var ignoreAttribute = descriptor.Attributes.OfType<ColumnIgnoreAttribute>().FirstOrDefault();
            if (ignoreAttribute != null)
            {
                e.Cancel = true;
                return;
            }

            var readOnlyAttribute = descriptor.Attributes.OfType<ReadOnlyAttribute>().FirstOrDefault();
            var displayNameAttribute = descriptor.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            var columnWidthAttribute = descriptor.Attributes.OfType<ColumnWidthAttribute>().FirstOrDefault();
            var templateAttribute = descriptor.Attributes.OfType<ColumnTemplateAttribute>().FirstOrDefault();
            var bindingAttribute = descriptor.Attributes.OfType<ColumnBindingAttribute>().FirstOrDefault();
            var canSortAttribute = descriptor.Attributes.OfType<ColumnSortAttribute>().FirstOrDefault();

            if (templateAttribute != null)
            {
                var bindingMode = bindingAttribute == null
                    ? (e.Column.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay)
                    : bindingAttribute.BindingMode;

                var updateSourceTrigger = bindingAttribute == null
                    ? UpdateSourceTrigger.Default
                    : bindingAttribute.UpdateSourceTrigger;

                var stringFormat = bindingAttribute?.StringFormat;

                var cellTemplate = templateAttribute.ElementType == null
                    ? CreateDefaultElementTemplated(dataGrid, e.PropertyName, bindingMode, updateSourceTrigger, stringFormat)
                    : CreateTemplate(dataGrid, templateAttribute.ElementType, templateAttribute.BindingProperty, templateAttribute.ElementStyleKey, e.PropertyName, bindingMode, updateSourceTrigger, stringFormat);

                var cellEditingTemplate = CreateTemplate(dataGrid, templateAttribute.EditingElementType, templateAttribute.EditingElementBindingProperty, templateAttribute.EditingElementStyleKey, e.PropertyName, bindingMode, updateSourceTrigger, stringFormat);

                e.Column = new DataGridTemplateColumn()
                {
                    Header = e.Column.Header,
                    Width = e.Column.Width,
                    IsReadOnly = e.Column.IsReadOnly,
                    CanUserSort = e.Column.CanUserSort,
                    SortMemberPath = e.Column.SortMemberPath,
                    SortDirection = e.Column.SortDirection,
                    CellTemplate = cellTemplate,
                    CellEditingTemplate = cellEditingTemplate,
                };
            }

            if (readOnlyAttribute != null)
            {
                e.Column.IsReadOnly = readOnlyAttribute.IsReadOnly;
            }
            if (displayNameAttribute != null)
            {
                e.Column.Header = displayNameAttribute.DisplayName;
            }
            if (columnWidthAttribute != null)
            {
                e.Column.Width = columnWidthAttribute.Width;
                if(columnWidthAttribute.MaxWidth != null)
                {
                    e.Column.MaxWidth = (double)columnWidthAttribute.MaxWidth;
                }
                if (columnWidthAttribute.MinWidth != null)
                {
                    e.Column.MinWidth = (double)columnWidthAttribute.MinWidth;
                }
            }
            if (canSortAttribute != null)
            {
                e.Column.CanUserSort = canSortAttribute.CanUserSort;
            }


            if (e.Column is DataGridComboBoxColumn)
            {
                var comboBoxColumn = e.Column as DataGridComboBoxColumn;
                if (bindingAttribute != null)
                {
                    comboBoxColumn.SelectedItemBinding = new Binding(e.PropertyName)
                    {
                        Mode = bindingAttribute.BindingMode,
                        UpdateSourceTrigger = bindingAttribute.UpdateSourceTrigger,
                        StringFormat = bindingAttribute.StringFormat,
                    };
                }

                var elementStyle = new Style(typeof(ComboBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(Internal.Resources.ResourceKeys.DataGridComboBoxStyle)
                };
                elementStyle.Setters.Add(new Setter(ComboBox.HorizontalContentAlignmentProperty, new Binding()
                {
                    Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                    Source = dataGrid,
                }));
               
                comboBoxColumn.ElementStyle = elementStyle;

                var editingElementStyle = new Style(typeof(ComboBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(ComboBox))
                };
                editingElementStyle.Setters.Add(new Setter(ComboBox.VerticalContentAlignmentProperty, VerticalAlignment.Center));
                editingElementStyle.Setters.Add(new Setter(ComboBox.HorizontalContentAlignmentProperty, new Binding()
                {
                    Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                    Source = dataGrid,
                }));

                comboBoxColumn.EditingElementStyle = editingElementStyle;
            }
            else if (e.Column is DataGridCheckBoxColumn)
            {
                var checkBoxColumn = e.Column as DataGridCheckBoxColumn;
                if (bindingAttribute != null)
                {
                    checkBoxColumn.Binding = new Binding(e.PropertyName)
                    {
                        Mode = bindingAttribute.BindingMode,
                        UpdateSourceTrigger = bindingAttribute.UpdateSourceTrigger,
                        StringFormat = bindingAttribute.StringFormat,
                    };
                }

                var elementStyle = new Style(typeof(CheckBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(CheckBox))
                };
                elementStyle.Setters.Add(new Setter(CheckBox.IsEnabledProperty, false));
                elementStyle.Setters.Add(new Setter(CheckBox.VerticalAlignmentProperty, VerticalAlignment.Center));
                elementStyle.Setters.Add(new Setter(CheckBox.HorizontalContentAlignmentProperty, new Binding()
                {
                    Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                    Source = dataGrid,
                }));
                checkBoxColumn.ElementStyle = elementStyle;
                var editingElementStyle = new Style(typeof(CheckBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(CheckBox))
                };
                editingElementStyle.Setters.Add(new Setter(CheckBox.VerticalAlignmentProperty, VerticalAlignment.Center));
                editingElementStyle.Setters.Add(new Setter(CheckBox.HorizontalContentAlignmentProperty, new Binding()
                {
                    Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                    Source = dataGrid,
                }));
                checkBoxColumn.EditingElementStyle = editingElementStyle;

            }
            else if (e.Column is DataGridTextColumn)
            {
                var textColumn = e.Column as DataGridTextColumn;
                if (bindingAttribute != null)
                {
                    textColumn.Binding = new Binding(e.PropertyName)
                    {
                        Mode = bindingAttribute.BindingMode,
                        UpdateSourceTrigger = bindingAttribute.UpdateSourceTrigger,
                        StringFormat = bindingAttribute.StringFormat,
                    };
                }

                textColumn.ElementStyle = CreateDefaultElementStyle(dataGrid);

                var editingElementStyle = new Style(typeof(TextBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(TextBox))
                };
                editingElementStyle.Setters.Add(new Setter(TextBox.MaxHeightProperty, 100.0));
                editingElementStyle.Setters.Add(new Setter(TextBox.VerticalContentAlignmentProperty, VerticalAlignment.Center));
                textColumn.EditingElementStyle = editingElementStyle;

            }

        }

        #endregion

        #endregion

        #region Functions

        private static Style CreateDefaultElementStyle(DataGrid dataGrid)
        {
            var style = new Style(typeof(TextBlock))
            {
                BasedOn = (Style)dataGrid.FindResource(typeof(TextBlock))
            };
            style.Setters.Add(new Setter(TextBlock.PaddingProperty, new Thickness(7, 0, 7, 0)));
            style.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
            style.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, new Binding()
            {
                Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                Source = dataGrid,
            }));

            style.Setters.Add(new Setter(TextBlock.MaxHeightProperty, 100.0));
            return style;
        }

        private static DataTemplate CreateTemplate(DataGrid dataGrid,
            Type elementType, 
            DependencyProperty property,
            object elementStyleKey,
            string propertyName,
            BindingMode bindingMode,
            UpdateSourceTrigger updateSourceTrigger,
            string stringFormat)
        {
            var factory = new FrameworkElementFactory(elementType);
            factory.SetBinding(property, new Binding(propertyName)
            {
                Mode = bindingMode,
                UpdateSourceTrigger = updateSourceTrigger,
                StringFormat = stringFormat,
            });
            if (typeof(FrameworkElement).IsAssignableFrom(elementType))
            {
                factory.SetBinding(FrameworkElement.DataContextProperty, new Binding()
                {
                    Path = new PropertyPath(DataGridRow.DataContextProperty),
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridRow), 1),
                    Mode = bindingMode,
                    UpdateSourceTrigger = updateSourceTrigger,
                });
            }
            if (elementStyleKey != null)
            {
                factory.SetValue(FrameworkElement.StyleProperty, dataGrid.FindResource(elementStyleKey) as Style);
            }
            if (typeof(Control).IsAssignableFrom(elementType))
            {
                factory.SetBinding(Control.HorizontalContentAlignmentProperty, new Binding()
                {
                    Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                    Source = dataGrid,
                });
            }
            else
            {
                factory.SetBinding(FrameworkElement.HorizontalAlignmentProperty, new Binding()
                {
                    Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                    Source = dataGrid,
                });
            }

            return new DataTemplate()
            {
                VisualTree = factory,
            };
        }

        private static DataTemplate CreateDefaultElementTemplated(DataGrid dataGrid,
            string propertyName,
            BindingMode bindingMode,
            UpdateSourceTrigger updateSourceTrigger,
            string stringFormat)
        {
            var factory = new FrameworkElementFactory(typeof(TextBlock));
            factory.SetValue(TextBlock.StyleProperty, CreateDefaultElementStyle(dataGrid));
            factory.SetBinding(TextBlock.TextProperty, new Binding(propertyName)
            {
                Mode = bindingMode,
                UpdateSourceTrigger = updateSourceTrigger,
                StringFormat = stringFormat
            });
            factory.SetBinding(TextBlock.HorizontalAlignmentProperty, new Binding()
            {
                Path = new PropertyPath(DataGrid.HorizontalContentAlignmentProperty),
                Source = dataGrid,
            });
            return new DataTemplate()
            {
                VisualTree = factory,
            };
        }
        #endregion
    }
}
