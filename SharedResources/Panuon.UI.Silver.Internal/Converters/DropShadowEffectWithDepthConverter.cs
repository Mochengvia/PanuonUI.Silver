using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Panuon.UI.Silver.Internal.Converters
{
    class DropShadowEffectWithDepthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)values[0];
            var depth = (double)values[1];
            int.TryParse(parameter?.ToString(), out int blur);
            blur = blur == 0 ? 10 : blur;
            return new DropShadowEffect()
            {
                Color = color,
                ShadowDepth = depth,
                BlurRadius = blur,
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
