using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class ArcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = values[0] as double? ?? 0;
            var actualHeight = values[1] as double? ?? 0;
            if(actualWidth == 0 || actualWidth == 0)
            {
                return null;
            }
            var percent = values[2] as double? ?? 0;
            var thickness = 0.0;
            if (values[3] is double)
                thickness = values[3] as double? ?? 0;
            else if(values[3] is Thickness)
                thickness = (values[3] as Thickness?)?.Left ?? 0;

            var centerX = actualWidth / 2;
            var centerY = actualHeight / 2;
            var radius = actualWidth - thickness;
            var startX = centerX;
            var startY = thickness / 2;
            var endX = (radius / 2) * (Math.Cos((2 * percent - 0.5) * Math.PI)) + centerX;
            var endY = (centerY) - (radius / 2 * Math.Sin((2 * percent + 0.5) * Math.PI));
            var path = "";
            if (percent > 0)
            {
                path = $"M{startX},{startY} A{radius / 2},{radius / 2} 0 0 1 ";
                if (percent <= 0.5)
                    path += $"{endX},{endY}";
                else
                    path += $"{centerX},{radius + thickness / 2} A{radius / 2},{radius / 2} 0 0 1 {endX},{endY}";
            }

            return PathGeometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
