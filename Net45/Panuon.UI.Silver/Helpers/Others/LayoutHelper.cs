using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class LayoutHelper
    {
        #region RowDefinition
        public static string GetRowDefinition(DependencyObject obj)
        {
            return (string)obj.GetValue(RowDefinitionProperty);
        }

        public static void SetRowDefinition(DependencyObject obj, string value)
        {
            obj.SetValue(RowDefinitionProperty, value);
        }

        public static readonly DependencyProperty RowDefinitionProperty =
            DependencyProperty.RegisterAttached("RowDefinition", typeof(string), typeof(LayoutHelper), new PropertyMetadata(OnRowDefinitionChanged));

        private static void OnRowDefinitionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var row = (string)e.NewValue;
            var element = d as FrameworkElement;
            var parentGrid = element.Parent as Grid;

            if (parentGrid == null)
                return;

            Grid.SetRow(element, parentGrid.RowDefinitions.Count);

            var length = 0.0;

            if (row.Contains("*"))
            {
                row = row.Replace("*", "");
                if (row == "")
                    row = "1";

                if (double.TryParse(row, out length))
                {
                    parentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(length, GridUnitType.Star) });
                }
                else
                {
                    parentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                }
            }
            else
            {
                if (double.TryParse(row, out length))
                {
                    parentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(length, GridUnitType.Pixel) });
                }
                else
                {
                    parentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                }
            }
        }


        #endregion

        #region ColumnDefinition
        public static string GetColumnDefinition(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnDefinitionProperty);
        }

        public static void SetColumnDefinition(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnDefinitionProperty, value);
        }

        public static readonly DependencyProperty ColumnDefinitionProperty =
            DependencyProperty.RegisterAttached("ColumnDefinition", typeof(string), typeof(LayoutHelper), new PropertyMetadata(OnColumnDefinitionChanged));

        private static void OnColumnDefinitionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = (string)e.NewValue;
            var element = d as FrameworkElement;
            var parentGrid = element.Parent as Grid;

            if (parentGrid == null)
                return;

            Grid.SetColumn(element, parentGrid.ColumnDefinitions.Count);

            var length = 0.0;

            if (column.Contains("*"))
            {
                column = column.Replace("*", "");
                if (column == "")
                    column = "1";

                if (double.TryParse(column, out length))
                {
                    parentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(length, GridUnitType.Star) });
                }
                else
                {
                    parentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                }
            }
            else
            {
                if (double.TryParse(column, out length))
                {
                    parentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(length, GridUnitType.Pixel) });
                }
                else
                {
                    parentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                }
            }
        }


        #endregion

    }
}
