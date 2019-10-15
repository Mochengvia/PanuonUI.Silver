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
            if (currentWidth > maxWidth)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
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

    internal class TabControlScrollViewerMaxWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var actualwidth = (double)values[0];
            var leftsidebuttonwidth = (double)values[1];
            leftsidebuttonwidth = leftsidebuttonwidth == 0 ? leftsidebuttonwidth : (leftsidebuttonwidth + 7);
            var rightsidebuttonwidth = (double)values[2];
            rightsidebuttonwidth = rightsidebuttonwidth == 0 ? rightsidebuttonwidth : (rightsidebuttonwidth + 7);

            return actualwidth - leftsidebuttonwidth - rightsidebuttonwidth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
