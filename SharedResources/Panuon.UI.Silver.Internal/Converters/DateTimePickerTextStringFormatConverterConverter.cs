using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class DateTimePickerTextStringFormatConverterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var stringFormat = (string)values[0];
            var mode = (DateTimePickerMode)values[1];
            if (!string.IsNullOrEmpty(stringFormat))
            {
                return stringFormat;
            }
            else
            {
                switch (mode)
                {
                    case DateTimePickerMode.Date:
                        return "MM/dd/yyyy";
                    case DateTimePickerMode.Time:
                        return "HH:mm:ss";
                    case DateTimePickerMode.Year:
                        return "yyyy";
                    case DateTimePickerMode.YearMonth:
                        return "MM/yyyy";
                    default:
                        return "MM/dd/yyyy HH:mm:ss";
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
