using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Converters
{
    internal class CloneConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var objs = new object[targetTypes.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i] = DependencyProperty.UnsetValue;
            }
            return objs;
        }
    }
}
