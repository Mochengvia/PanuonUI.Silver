using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class TreeViewPaddingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] == DependencyProperty.UnsetValue)
            {
                return new Thickness(0);
            }
            var parentPadding = values[0] as Thickness? ?? new Thickness(0);
            var padding = values[1] as Thickness? ?? new Thickness(0);
            padding.Left += parentPadding.Left;
            return padding;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class TreeViewChainVerticalMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var toggleWidth = values[0] as double? ?? 0;
            var padding = values[1] as Thickness? ?? new Thickness(0);
            return new Thickness(toggleWidth / 2 + padding.Left, 0, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class TreeViewChainHorizontalMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var width = value as double? ?? 0;
            return new Thickness(-width / 2, 0, 2, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
