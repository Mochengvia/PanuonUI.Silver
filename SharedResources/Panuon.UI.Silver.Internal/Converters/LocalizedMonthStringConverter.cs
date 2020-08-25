using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class LocalizedMonthStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var month = (int)value;
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
