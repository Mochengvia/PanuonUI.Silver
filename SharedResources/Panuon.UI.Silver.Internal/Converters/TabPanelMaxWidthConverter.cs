using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class TabPanelMaxWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var totalWidth = (double)values[0];
            var frontWidth = (double)values[1];
            var endWidth = (double)values[2];
            var upWidth = (double)values[3];
            var upVisibility = (Visibility)values[4];
            var downWidth = (double)values[5];
            var downVisibility = (Visibility)values[6];

            var upActual = upVisibility == Visibility.Collapsed ? 0 : upWidth;
            var downActual = downVisibility == Visibility.Collapsed ? 0 : downWidth;

            if (upVisibility == downVisibility)
            {
                return totalWidth - frontWidth - endWidth - upActual - downActual;
            }
            else
            {
                return totalWidth - frontWidth - endWidth;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
