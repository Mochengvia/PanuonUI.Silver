using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class CheckBoxStandardGlyphPathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (double)values[0];
            var actualHeight = (double)values[1];
            return Geometry.Parse($"M {actualWidth / 6},{ actualHeight * 7 / 12 - 1} L{actualWidth / 2 - 1},{actualHeight * 5 / 6 - 1} L{ actualWidth * 5 / 6},{actualHeight * 3 / 12 - 1}");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class CheckBoxSwitchToggleMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var boxWidth = values[0] as double? ?? 0;
            var toggleWidth = values[1] as double? ?? 0;
            return new Thickness(0, 0, boxWidth - toggleWidth, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class CheckBoxSwitch2DecorationMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boxWidth = value as double? ?? 0;
            var thickness = boxWidth / 3;
            return new Thickness(thickness, thickness, 0, thickness);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class CheckBoxSwitch3ToggleMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var boxWidth = values[0] as double? ?? 0;
            var toggleWidth = values[1] as double? ?? 0;
            return new Thickness(0, 0, boxWidth - toggleWidth - 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class CheckBoxSwitch3ToggleTrackMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boxWidth = value as double? ?? 0;
            return new Thickness(boxWidth / 5);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
