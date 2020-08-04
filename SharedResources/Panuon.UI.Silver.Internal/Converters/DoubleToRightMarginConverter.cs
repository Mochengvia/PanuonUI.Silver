using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class DoubleToRightMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            if (parameter == null)
            {
                return new Thickness(0, 0, doubleValue, 0);
            }
            var para = double.Parse(parameter.ToString());
            return new Thickness(0, 0, doubleValue * para, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

}
