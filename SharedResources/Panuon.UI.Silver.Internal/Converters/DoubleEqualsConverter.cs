using Panuon.UI.Silver.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class DoubleEqualsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            for (int i = 1; i < values.Length; i++)
            {
                if ((values[i - 1] != null && values[i] == null) || (values[i - 1] == null && values[i] != null))
                {
                    return false;
                }
                if ((values[i - 1] != null && values[i] != null) && !values[i - 1].Equals(values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var propertyValues = new object[targetTypes.Length];
            propertyValues.Fill(DependencyProperty.UnsetValue);
            return propertyValues;
        }
    }
}
