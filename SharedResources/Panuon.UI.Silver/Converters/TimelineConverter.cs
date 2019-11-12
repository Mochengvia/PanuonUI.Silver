using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panuon.UI.Silver.Converters
{
    internal class TimelineHeaderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var header = values[0];
            var dataContext = values[1];
            if (dataContext != null)
                return dataContext;
            else
                return header;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class TimelimeStripPlacementToOrientationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var placement = value as TimelimeStripPlacement? ?? TimelimeStripPlacement.Left;
            return (placement == TimelimeStripPlacement.Left || placement == TimelimeStripPlacement.Right) ? Orientation.Vertical : Orientation.Horizontal;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return  DependencyProperty.UnsetValue;
        }
    }
    
}
