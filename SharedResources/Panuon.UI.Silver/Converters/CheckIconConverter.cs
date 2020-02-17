using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;


namespace Panuon.UI.Silver.Converters
{
    internal class CheckIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var width = values[0] as double? ?? 0;
            var icon = values[1] as MessageBoxIcon? ?? MessageBoxIcon.None;
            var thickness = values[2] as double? ?? 0;
            var path = "";

            switch (icon)
            {
                case MessageBoxIcon.Info:
                    path = $"M {thickness / 2},{0.2 * width} V {0.2 * width} M {thickness / 2},{0.35 * width} V {0.8 * width}";
                    break;
                case MessageBoxIcon.Error:
                    path = $"M {0.3 * width},{0.3 * width} L {0.7 * width},{0.7 * width} M {0.7 * width},{0.3 * width} L {0.3 * width},{0.7 * width}";
                    break;
                case MessageBoxIcon.Success:
                    path = $"M {0.2 * width},{0.55 * width} L {0.45 * width},{0.75 * width} L {0.8 * width},{0.35 * width} ";
                    break;
                case MessageBoxIcon.Warning:
                    path = $"M {0.5 * width},{0.1 * width} L 5,{0.9 * width} H {width - 5} Z M {0.5 * width},{0.3 * width} V {0.70 * width} M {0.5 * width},{0.8 * width} V {0.8 * width}";
                    break;
                case MessageBoxIcon.Question:
                    path = $"M {0.3 * width} {0.375 * width} A {0.21 * width} {0.21 * width} 0 1 1 {0.5 * width} {0.6 * width} V {0.7 * width}  M {0.5 * width},{0.8 * width} V {0.8 * width}";
                    break;
            }

            return PathGeometry.Parse(path);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
