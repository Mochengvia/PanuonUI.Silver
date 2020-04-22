using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class ProgressBarWidthOrHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var min = values[0] as double? ?? 0;
            var max = values[1] as double? ?? 0;
            var value = values[2] as double? ?? 0;
            var actualWidth = values[3] as double? ?? 0;
            var percent = ((value - min) / (max - min));
            return actualWidth * percent;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarPercentTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var min = values[0] as double? ?? 0;
            var max = values[1] as double? ?? 0;
            var value = values[2] as double? ?? 0;
            var stringformat = values[3] as string;
            var percent = ((value - min) / (max - min));
            return string.Format(stringformat, percent);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarPercentTextForegroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = values[0] as ProgressDirection? ?? ProgressDirection.LeftToRight;
            var min = values[1] as double? ?? 0;
            var max = values[2] as double? ?? 0;
            var value = values[3] as double? ?? 0;
            var totalWidth = ((direction == ProgressDirection.LeftToRight || direction == ProgressDirection.RightToLeft) ? values[4] : values[5]) as double? ?? 0;
            var actualWidth = ((direction == ProgressDirection.LeftToRight || direction == ProgressDirection.RightToLeft) ? values[6] : values[7]) as double? ?? 0;
            var foreground = values[8] as Brush;
            if (totalWidth == 0 || actualWidth == 0)
            {
                return foreground;
            }

            var totalPercent = ((value - min) / (max - min));
            var percentWidth = totalWidth * totalPercent;
            var innerWidth = percentWidth - ((totalWidth - actualWidth) / 2);
            if (innerWidth <= 0)
            {
                return foreground;
            }
            else if (innerWidth >= actualWidth)
            {
                return Brushes.White;
            }

            var innerPercent = innerWidth / actualWidth;
            switch (direction)
            {
                case ProgressDirection.RightToLeft:
                    return BrushUtils.GetStackedVisualBrush(foreground, Brushes.White, System.Windows.Controls.Orientation.Horizontal, 1 - innerPercent);
                case ProgressDirection.BottomToTop:
                    return BrushUtils.GetStackedVisualBrush(foreground, Brushes.White, System.Windows.Controls.Orientation.Vertical, 1 - innerPercent);
                case ProgressDirection.TopToBottom:
                    return BrushUtils.GetStackedVisualBrush(Brushes.White, foreground, System.Windows.Controls.Orientation.Vertical, innerPercent);
                default:
                    return BrushUtils.GetStackedVisualBrush(Brushes.White, foreground, System.Windows.Controls.Orientation.Horizontal, innerPercent);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarProgressBarIndeterminateMarginTemplate : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = values[0] as ProgressDirection? ?? ProgressDirection.LeftToRight;
            var actualWidth = ((direction == ProgressDirection.LeftToRight || direction == ProgressDirection.RightToLeft) ? values[1] : values[2]) as double? ?? 0;
            var percent = values[3] as double? ?? 0;
            var offset = percent * actualWidth;
            switch (direction)
            {
                case ProgressDirection.RightToLeft:
                    return new Thickness(0, 0, offset, 0);
                case ProgressDirection.BottomToTop:
                    return new Thickness(0, 0, 0, offset);
                case ProgressDirection.TopToBottom:
                    return new Thickness(offset, 0, 0, 0);
                default:
                    return new Thickness(offset, 0, 0, 0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarProgressBarRingArcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (double)values[0];
            var actualHeight = (double)values[1];

            double thickness = 0;
            if (values[2] is Thickness)
                thickness = ((Thickness)values[2]).Left;
            else if (values[2] is double)
                thickness = ((double)values[2]);

            var percent = 0.3;
            if (values.Length == 6)
            {
                var min = (double)values[3];
                var max = (double)values[4];
                var value = (double)values[5];
                value = value > max ? max : value;
                value = value < min ? min : value;
                percent = (value - min) / (max - min);
            }

            var centerX = actualWidth / 2;
            var centerY = actualHeight / 2;
            var radius = actualWidth - thickness;
            var startX = centerX;
            var startY = thickness / 2;
            var endX = (radius / 2) * (Math.Cos((2 * percent - 0.5) * Math.PI)) + centerX;
            var endY = (centerY) - (radius / 2 * Math.Sin((2 * percent + 0.5) * Math.PI));
            var path = "";
            if (percent > 0)
            {
                path = $"M{startX},{startY} A{radius / 2},{radius / 2} 0 0 1 ";
                if (percent <= 0.5)
                    path += $"{endX},{endY}";
                else
                    path += $"{centerX},{radius + thickness / 2} A{radius / 2},{radius / 2} 0 0 1 {endX},{endY}";
            }

            return PathGeometry.Parse(path);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarProgressBarWavePathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = values[0] as ProgressDirection? ?? ProgressDirection.LeftToRight;
            var min = values[1] as double? ?? 0;
            var max = values[2] as double? ?? 0;
            var value = values[3] as double? ?? 0;
            var w = values[4] as double? ?? 0;
            var h = values[5] as double? ?? 0;
            var percent = ((value - min) / (max - min));
            var percentW = percent * w;
            var percentH = percent * h;

            if (w == 0 || h == 0)
            {
                return null;
            }
            var dataBuilder = new StringBuilder();
            switch (direction)
            {
                case ProgressDirection.LeftToRight:
                    dataBuilder.Append($"M 0,0 V{2 * h} H {percentW} A {h / 2},{h / 2} 0 0 1 {percentW},{1.5 * h} A {h / 2},{h / 2} 0 0 0 {percentW},{h} A {h / 2},{h / 2} 0 0 1 {percentW},{0.5 * h} A {h / 2},{h / 2} 0 0 0 {percentW},0 ");
                    break;
                case ProgressDirection.RightToLeft:
                    dataBuilder.Append($"M {w},0 V{2 * h} H {w - percentW} A {h / 2},{h / 2} 0 0 1 {w - percentW},{1.5 * h} A {h / 2},{h / 2} 0 0 0 {w - percentW},{h} A {h / 2},{h / 2} 0 0 1 {w - percentW},{0.5 * h} A {h / 2},{h / 2} 0 0 0 {w - percentW},0 ");
                    break;
                case ProgressDirection.TopToBottom:
                    dataBuilder.Append($"M 0,0 H {2 * w} V {percentH} A {w / 2},{w / 2} 0 0 1 {1.5 * w},{percentH} A {w / 2},{w / 2} 0 0 0 {1 * w},{percentH} A {w / 2},{w / 2} 0 0 1 {0.5 * w},{percentH} A {w / 2},{w / 2} 0 0 0 0,{percentH}");
                    break;
                default:
                    dataBuilder.Append($"M 0,{h} H {2 * w} V {h - percentH} A {w / 2},{w / 2} 0 0 1 {1.5 * w},{h - percentH} A {w / 2},{w / 2} 0 0 0 {1 * w},{h - percentH} A {w / 2},{w / 2} 0 0 1 {0.5 * w},{h - percentH} A {w / 2},{w / 2} 0 0 0 0,{h - percentH}");
                    break;
            }
            return Geometry.Parse(dataBuilder.ToString());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ProgressBarProgressBarWaveMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = values[0] as ProgressDirection? ?? ProgressDirection.LeftToRight;
            var w = values[1] as double? ?? 0;
            var h = values[2] as double? ?? 0;

            switch (direction)
            {
                case ProgressDirection.LeftToRight:
                case ProgressDirection.RightToLeft:
                    return new Thickness(0, -h, 0, 0);
                default:
                    return new Thickness(-w, 0, 0, 0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }


}
