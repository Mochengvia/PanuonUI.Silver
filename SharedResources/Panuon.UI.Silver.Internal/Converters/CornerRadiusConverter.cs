using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class CornerRadiusToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cornerRadius = value as CornerRadius? ?? new CornerRadius(0);
            return Math.Max(Math.Max(cornerRadius.TopLeft, cornerRadius.TopRight), Math.Max(cornerRadius.BottomLeft, cornerRadius.BottomRight));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
