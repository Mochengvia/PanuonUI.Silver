using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Converters
{
    internal class ProgressBarCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var radius = (double)value;
            return new CornerRadius(radius, 0, 0, radius);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    internal class RingProgressBarConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (double)values[0];
            var height = (double)values[1];

            double radius = 0;
            if (values[2] is Thickness)
                radius = ((Thickness)values[2]).Left;
            else if (values[2] is double)
                radius = ((double)values[2]);

            var percent = 0.33;
            if (values.Length == 6)
            {
                var min = (double)values[3];
                var max = (double)values[4];
                var value = (double)values[5];
                value = value > max ? max : value;
                value = value < min ? min : value;
                percent = (value - min) / (max - min);
            }

            var point1X = height / 2 * Math.Cos((2 * percent - 0.5) * Math.PI) + height / 2;
            var point1Y = height / 2 - height / 2 * Math.Sin((2 * percent + 0.5) * Math.PI);
            var point2X = (height - radius) / 2 * Math.Cos((2 * percent - 0.5) * Math.PI) + height / 2;
            var point2Y = height / 2 - (height - radius) / 2 * Math.Sin((2 * percent + 0.5) * Math.PI);

            var path = "";

            if (percent == 0)
            {
                path = "";
            }
            else if (percent < 0.5)
            {
                path = "M " + width / 2 + "," + radius / 2 + " A " + (width - radius) / 2 + "," + (width - radius) / 2 + " 0 0 1 " + point2X + "," + point2Y + "";
            }
            else if (percent == 0.5)
            {
                path = "M " + width / 2 + "," + radius / 2 + " A " + (width - radius) / 2 + "," + (width - radius) / 2 + " 0 0 1 " + width / 2 + "," + (height - radius / 2);
            }
            else
            {
                path = "M " + width / 2 + "," + radius / 2 + " A " + (width - radius) / 2 + "," + (width - radius) / 2 + " 0 0 1 " + width / 2 + "," + (height - radius / 2) +
                    " A " + (width - radius) / 2 + "," + (width - radius) / 2 + " 0 0 1 " + point2X + "," + point2Y + "";
            }
            return PathGeometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarPercentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var min = (double)values[0];
            var max = (double)values[1];
            var value = (double)values[2];

            return Math.Round((value - min) / (max - min), 2) * 100 + "%";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarOffset1Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var min = (double)values[0];
            var max = (double)values[1];
            var value = (double)values[2];
            var percent = Math.Round((value - min) / (max - min), 2);

            var totalWidth = (double)values[3];
            var actualWidth = (double)values[4];

            var left = (totalWidth - actualWidth) / 2;
            var half = totalWidth * percent;
            var result = (half - left) / actualWidth;
            result = result < 0 ? 0 : result > 1 ? 1 : result;
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarOffset2Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var min = (double)values[0];
            var max = (double)values[1];
            var value = (double)values[2];
            var percent = Math.Round((value - min) / (max - min), 2);

            var totalWidth = (double)values[3];
            var actualWidth = (double)values[4];

            var left = (totalWidth - actualWidth) / 2;
            var half = totalWidth * percent;
            var result = (half - left) / actualWidth;
            result += 0.01;
            result = result < 0 ? 0 : result > 1 ? 1 : result;
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

}
