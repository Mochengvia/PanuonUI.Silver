using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Converters
{
    internal class CheckBoxGlyphPathConverter : IMultiValueConverter
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

    internal class SwitchToggleMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue)
                return new Thickness(0, 0, 0, 0);

            var width = ((double?)values[0]).GetValueOrDefault();
            var height = ((double?)values[1]).GetValueOrDefault();
            return new Thickness(0, 0, width - height + 1, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
