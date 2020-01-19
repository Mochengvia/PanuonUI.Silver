using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Converters
{

    internal class ClockHourTextMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var thickness = (double)values[0];
            var actualWidth = (double)values[1];
            if (actualWidth == 0)
                return new Thickness(0);
            var center = actualWidth / 2;
            var radius = actualWidth - (thickness + 10) * 2;
            var cos30 = Math.Cos(30 * (Math.PI / 180.0));
            switch (parameter)
            {
                case "1":
                    return new Thickness(radius / 2, -cos30 * radius, 0, 0);
                case "2":
                    return new Thickness(cos30 * radius, -radius / 2, 0, 0);
                case "3":
                    return new Thickness(radius, 0, 0, 0);
                case "4":
                    return new Thickness(cos30 * radius, radius / 2, 0, 0);
                case "5":
                    return new Thickness(radius / 2, radius * cos30, 0, 0);
                case "6":
                    return new Thickness(0, radius, 0, 0);
                case "7":
                    return new Thickness(-radius / 2, radius * cos30, 0, 0);
                case "8":
                    return new Thickness(-cos30 * radius, radius / 2, 0, 0);
                case "9":
                    return new Thickness(-radius, 0, 0, 0);
                case "10":
                    return new Thickness(-cos30 * radius, -radius / 2, 0, 0);
                case "11":
                    return new Thickness(-radius / 2, -cos30 * radius, 0, 0);
                default:
                    return new Thickness(0, -radius, 0, 0);
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
