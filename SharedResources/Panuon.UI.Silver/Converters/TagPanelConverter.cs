using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Converters
{
    internal class TagControlBackgroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var item = values[0];
            var displayMemberPath = values[1] as string;
            if (item == null || displayMemberPath.IsNullOrEmpty())
                return values[2];

            var propertyInfo = item.GetType().GetProperty(displayMemberPath);
            if (propertyInfo == null)
                return values[2];

            var result = propertyInfo.GetValue(item, null);
            if (result is Brush)
            {
                return result;
            }
            if (result is Color)
            {
                return new SolidColorBrush((Color)result);
            }
            if (result is string)
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(result as string));
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class TagControlRemovableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var item = values[0];
            var displayMemberPath = values[1] as string;
            if (item == null || displayMemberPath.IsNullOrEmpty())
                return null;

            var propertyInfo = item.GetType().GetProperty(displayMemberPath);
            if (propertyInfo == null)
                return null;
            var result = propertyInfo.GetValue(item, null) as bool? ?? false;

            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
