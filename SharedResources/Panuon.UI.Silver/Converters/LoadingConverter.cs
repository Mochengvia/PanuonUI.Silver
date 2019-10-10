using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Converters
{
    internal class LoadingBackgroundThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (value as double?).GetValueOrDefault();
            if (actualWidth == 0)
                return 0;
            return Math.Ceiling(actualWidth / 15);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class LoadingLineYConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (value as double?).GetValueOrDefault();
            if (actualWidth == 0)
                return 0;
            return Math.Ceiling(actualWidth / 4);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class LoadingClassicMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (value as double?).GetValueOrDefault();
            if (actualWidth == 0)
                return 0;
            return new Thickness(actualWidth / 2, actualWidth / 2, 0, 0);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class LoadingClassicEllipseSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (value as double?).GetValueOrDefault();
            if (actualWidth == 0)
                return 0;
            return Math.Ceiling(actualWidth / 8);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
