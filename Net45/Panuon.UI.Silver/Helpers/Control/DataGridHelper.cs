using Panuon.UI.Silver.Converters;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;


namespace Panuon.UI.Silver
{
    public class DataGridHelper
    {

        #region CheckBoxStyle
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
        }

        private static void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            if (e.PropertyType.IsEnum)
            {
                var newColumn = new DataGridComboBoxColumn()
                {
                    Width = e.Column.Width,
                    Header = e.Column.Header,
                };

                newColumn.ItemsSource = Enum.GetValues(e.PropertyType).Cast<Enum>();
                newColumn.SelectedItemBinding = new Binding(e.PropertyName) { Mode = BindingMode.TwoWay };

                newColumn.EditingElementStyle = new Style(typeof(ComboBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(ComboBox))
                };
                newColumn.EditingElementStyle.Setters.Add(new Setter(ComboBox.VerticalAlignmentProperty, dataGrid.VerticalContentAlignment));
                newColumn.EditingElementStyle.Setters.Add(new Setter(ComboBox.HorizontalAlignmentProperty, dataGrid.HorizontalContentAlignment));
                newColumn.EditingElementStyle.Setters.Add(new Setter(ComboBox.HeightProperty, 30.0));
                //newColumn.EditingElementStyle.Setters.Add(new Setter(ComboBox.PaddingProperty, new Thickness(5, 0, 20, 0)));

                e.Column = newColumn;
            }
            else if (e.PropertyType == typeof(bool))
            {
                var newColumn = new DataGridCheckBoxColumn()
                {
                    Width = e.Column.Width,
                    Header = e.Column.Header,
                };

                newColumn.Binding = new Binding(e.PropertyName) { Mode = BindingMode.TwoWay };

                var userStyle = GetAutoGenerateCheckBoxStyle(dataGrid);
                if(userStyle == null)
                {
                    newColumn.ElementStyle = new Style(typeof(CheckBox))
                    {
                        BasedOn = (Style)dataGrid.FindResource(typeof(CheckBox))
                    };
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.VerticalAlignmentProperty, dataGrid.VerticalContentAlignment));
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.HorizontalAlignmentProperty, dataGrid.HorizontalContentAlignment));
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.BorderBrushProperty, "#3E3E3E".ToColor().ToBrush()));
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.BorderThicknessProperty, new Thickness(1)));
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBox.BackgroundProperty, Colors.Transparent.ToBrush()));
                    newColumn.ElementStyle.Setters.Add(new Setter(CheckBoxHelper.GlyphBrushProperty, Colors.Transparent.ToBrush()));
                }
                else
                {
                    newColumn.ElementStyle = userStyle;
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
                newColumn.CellStyle.Setters.Add(new Setter(DataGridCell.PaddingProperty, new Thickness(0, 0, 10, 0)));

                e.Column = newColumn;
            }
            else if (e.PropertyType == typeof(string))
            {
                var newColumn = new DataGridTextColumn()
                {
                    Width = e.Column.Width,
                    Header = e.Column.Header,
                };

                newColumn.Binding = new Binding(e.PropertyName) { Mode = BindingMode.TwoWay };

                newColumn.ElementStyle = new Style(typeof(TextBlock))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(TextBlock))
                };
                newColumn.ElementStyle.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, dataGrid.HorizontalContentAlignment));
                newColumn.ElementStyle.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, dataGrid.VerticalContentAlignment));

                if (dataGrid.HorizontalContentAlignment == HorizontalAlignment.Left)
                    newColumn.ElementStyle.Setters.Add(new Setter(TextBlock.PaddingProperty, new Thickness(0, 0, 21, 0)));

                newColumn.EditingElementStyle = new Style(typeof(TextBox))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(TextBox))
                };
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.VerticalAlignmentProperty, dataGrid.VerticalContentAlignment));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.HorizontalAlignmentProperty, dataGrid.HorizontalContentAlignment));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.PaddingProperty, new Thickness(0)));
                newColumn.EditingElementStyle.Setters.Add(new Setter(TextBox.HeightProperty, 30.0));

                newColumn.CellStyle = new Style(typeof(DataGridCell))
                {
                    BasedOn = (Style)dataGrid.FindResource(typeof(DataGridCell)),
                };
                newColumn.CellStyle.Setters.Add(new Setter(DataGridCell.PaddingProperty, new Thickness(0, 0, 10, 0)));

                e.Column = newColumn;
            }
        }

        #endregion
    }
}