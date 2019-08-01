using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Converters
{
    internal class ThicknessToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Thickness)value).Left;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
