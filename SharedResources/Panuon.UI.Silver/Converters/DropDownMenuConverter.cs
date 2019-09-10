using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Converters
{
    internal class DropDownBorderPathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var width = values[0] as double? ?? 0;
            var height = values[1] as double? ?? 0;

            var contentWidth = values[2] as double? ?? 0;
            var contentHeight = values[3] as double? ?? 0;

            var placement = values[4] as DropDownPlacement? ?? DropDownPlacement.LeftBottom;
            var radius = values[5] as double? ?? 0;
            var isAngleVisible = values[6] as bool? ?? false;

            var path = "";
            if (isAngleVisible)
            {
                switch (placement)
                {
                    case DropDownPlacement.LeftBottom:
                        path = $"M 1,{radius + 7} A{radius},{radius} 0 0 1 {radius + 1}, 7 H {width - contentWidth / 2 - 5} L {width - contentWidth / 2},1 L {width - contentWidth / 2 + 5},7   H {width - radius - 1} A{radius},{radius} 0 0 1 {width - 1}, {radius + 7}" +
                            $"V {height - radius - 1} A{radius},{radius} 0 0 1 {width - radius - 1}, {height - 1} H {radius + 1} A{radius},{radius} 0 0 1 1, {height - radius - 1} Z";
                        break;
                }
            }
            else
            {
                switch (placement)
                {
                    case DropDownPlacement.LeftBottom:
                        path = $"M 1,{radius + 1} A{radius},{radius} 0 0 1 {radius + 1}, 1 H {width - radius - 1} A{radius},{radius} 0 0 1 {width - 1}, {radius + 1}" +
                            $"V {height - radius - 1} A{radius},{radius} 0 0 1 {width - radius - 1}, {height - 1} H {radius + 1} A{radius},{radius} 0 0 1 1, {height - radius - 1} Z";
                        break;
                }
            }

            return Geometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
