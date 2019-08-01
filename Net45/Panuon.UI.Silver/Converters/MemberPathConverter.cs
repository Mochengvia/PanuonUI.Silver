using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Converters
{
    internal class ObjectMemberPathConverter : IMultiValueConverter
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
            return propertyInfo.GetValue(item, null);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }


    internal class BooleanMemberPathConverter : IMultiValueConverter
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
            return propertyInfo.GetValue(item, null) as bool? ?? true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
