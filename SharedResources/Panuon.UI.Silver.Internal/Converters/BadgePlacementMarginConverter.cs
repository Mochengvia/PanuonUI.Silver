using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class BadgePlacementMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var width = values[0] as double? ?? 0;
            var height = values[1] as double? ?? 0;
           var placement = values[2] as BadgePlacement? ?? BadgePlacement.Strench;
            switch (placement)
            {
                case BadgePlacement.TopLeft:
                    return new Thickness(-width / 2, -height / 2, 0, 0);
                case BadgePlacement.TopRight:
                    return new Thickness(0, -height / 2, -width / 2, 0);
                case BadgePlacement.BottomLeft:
                    return new Thickness(-width / 2, 0, 0 , -height / 2);
                case BadgePlacement.BottomRight:
                    return new Thickness(0, -height / 2, 0, -width / 2);
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
