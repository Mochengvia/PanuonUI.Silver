using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
namespace Panuon.UI.Silver.Internal.Converters
{
    internal class DropDownPathDataConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var w = values[0] as double? ?? 0;
            var h = values[1] as double? ?? 0;
            var cornerRadius = values[2] as CornerRadius? ?? new CornerRadius();
            var placement = values[3] as ActualPlacement? ?? ActualPlacement.Bottom;
            var dropDownStyle = values[4] as DropDownStyle? ?? DropDownStyle.Standard;
            var margin = values[5] as Thickness? ?? new Thickness();
            var left = margin.Left;
            var top = margin.Top;
            var right = margin.Right;
            var bottom = margin.Bottom;
            var cTopLeft = cornerRadius.TopLeft;
            var cTopRight = cornerRadius.TopRight;
            var cBottomLeft = cornerRadius.BottomLeft;
            var cBottomRight = cornerRadius.BottomRight;

            var path = new StringBuilder();
            switch (dropDownStyle)
            {
                case DropDownStyle.Standard:
                    break;
                case DropDownStyle.Standard2:
                    break;
                case DropDownStyle.Smooth:
                    path.Append($@"M{left},{top + cTopLeft} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                        H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V {top + cTopRight}
                        A {cTopRight},{cTopRight} 0 0 0 {w - right - cTopRight},{top} H {left + cTopLeft} A {cTopLeft},{cTopLeft} 0 0 0 {left},{top + cTopLeft}");
                    break;
            }

            return Geometry.Parse(path.ToString());

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}

