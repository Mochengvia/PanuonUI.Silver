using Panuon.UI.Silver.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class DoubleLimitMin1Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            return doubleValue < 1 ? 1 : doubleValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class DoubleToLeftMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            if (parameter == null)
            {
                return new Thickness(doubleValue, 0, 0, 0);
            }
            var para = double.Parse(parameter.ToString());
            return new Thickness(doubleValue * para, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

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

    internal class DoubleToTopMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            if (parameter == null)
            {
                return new Thickness(0, doubleValue, 0, 0);
            }
            var para = double.Parse(parameter.ToString());
            return new Thickness(0, doubleValue * para, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class DoubleToBottomMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = value as double? ?? 0;
            if (parameter == null)
            {
                return new Thickness(0, 0, 0, doubleValue);
            }
            var para = double.Parse(parameter.ToString());
            return new Thickness(0, 0, 0, doubleValue * para);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

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
            propertyValues.Init(DependencyProperty.UnsetValue);
            return propertyValues;
        }
    }

}
