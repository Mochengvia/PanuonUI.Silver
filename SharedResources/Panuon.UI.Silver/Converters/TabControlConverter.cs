using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Converters
{
    internal class TabControlSideButtonVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var currentWidth = values[0] as double? ?? 0;
            var maxWidth = values[1] as double? ?? 0;
            if (currentWidth >= maxWidth - 10)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class TabControlPathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var current = values[0] as double? ?? 0;
            var max = values[1] as double? ?? 0;
            var placement = values[2] as Dock? ?? Dock.Top;
            var path = "";

            if (current >= max - 10)
                path = "";
            else if (placement == Dock.Top || placement == Dock.Bottom)
                path = $"M {current},0 H {max}";
            else
                path = $"M 0,{current} V {max}";

            return Geometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class TabControlRemoveButtonPaddingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var padding = values[0] as Thickness? ?? new Thickness(0);
            var canRemove = values[1] as Visibility? ?? Visibility.Collapsed;
            if (canRemove == Visibility.Visible)
            {
                var right = padding.Right > 5 ? padding.Right - 5 : 0;
                return new Thickness(padding.Left, padding.Top, right, padding.Bottom);
            }
            else
            {
                return padding;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
