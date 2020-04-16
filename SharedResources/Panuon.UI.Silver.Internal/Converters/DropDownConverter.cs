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
            var angleHeight = 7;
            var angleWidth = 10;

            var path = new StringBuilder();
            switch (dropDownStyle)
            {
                case DropDownStyle.Standard:
                    switch (placement)
                    {
                        case ActualPlacement.BottomRight:
                            path.Append($@"M{left},{top + cTopLeft + angleHeight} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                                H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V {top + cTopRight + angleHeight}
                                A {cTopRight},{cTopRight} 0 0 0 {w - right - cTopRight},{top + angleHeight} H {left + cTopLeft + angleWidth + 1} L {left + cTopLeft + angleWidth * 0.5 + 1}, 1 L {left + cTopLeft + 1},{top + angleHeight} H {left + cTopLeft + 1} A {cTopLeft},{cTopLeft} 0 0 0 {left},{top + cTopLeft + angleHeight}");
                            break;
                        case ActualPlacement.Bottom:
                            path.Append($@"M{left},{top + cTopLeft + angleHeight} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                                H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V {top + cTopRight + angleHeight}
                                A {cTopRight},{cTopRight} 0 0 0 {w - right - cTopRight},{top + angleHeight} H {w / 2 + angleWidth * 0.5} L {w / 2}, 1 L {w / 2 - angleWidth * 0.5},{top + angleHeight} H {left + cTopLeft} A {cTopLeft},{cTopLeft} 0 0 0 {left},{top + cTopLeft + angleHeight}");
                            break;
                        case ActualPlacement.BottomLeft:
                            path.Append($@"M{left},{top + cTopLeft + angleHeight} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                                H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V {top + cTopRight + angleHeight}
                                A {cTopRight},{cTopRight} 0 0 0 {w - right - cTopRight},{top + angleHeight} H {w - right - cTopRight - 1} L {w - right - cTopRight - angleWidth * 0.5 - 1},1 L {w - right - cTopRight - angleWidth - 1},{top + angleHeight}  H {left + cTopLeft} A {cTopLeft},{cTopLeft} 0 0 0 {left},{top + cTopLeft + angleHeight}");
                            break;
                        default:
                            break;
                    }
                    break;
                case DropDownStyle.Standard2:
                    angleHeight = 9;
                    angleWidth = 7;
                    switch (placement)
                    {
                        case ActualPlacement.BottomRight:
                            path.Append($@"M{left},{top + cTopLeft + angleHeight} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                                H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V {top + cTopRight + angleHeight}
                                A {cTopRight},{cTopRight} 0 0 0 {w - right - cTopRight},{top + angleHeight} H {left + angleWidth} L {left}, 1 Z");
                            break;
                        case ActualPlacement.Bottom:
                            path.Append($@"M{left},{top + cTopLeft + angleHeight} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                                H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V {top + cTopRight + angleHeight}
                                A {cTopRight},{cTopRight} 0 0 0 {w - right - cTopRight},{top + angleHeight} H {w / 2 + angleWidth * 0.5} L {w / 2}, 1 L {w / 2 - angleWidth * 0.5},{top + angleHeight} H {left + cTopLeft} A {cTopLeft},{cTopLeft} 0 0 0 {left},{top + cTopLeft + angleHeight}");
                            break;
                        case ActualPlacement.BottomLeft:
                            path.Append($@"M{left},{top + cTopLeft + angleHeight} V {h - bottom - cBottomLeft} A {cBottomLeft},{cBottomLeft} 0 0 0 {cBottomLeft + left},{h - bottom}
                                H {w - cBottomRight - right} A {cBottomRight},{cBottomRight} 0 0 0 {w - right},{h - bottom - cBottomRight} V 1 
                                L {w - right - angleWidth},{top + angleHeight}  H {left + cTopLeft} A {cTopLeft},{cTopLeft} 0 0 0 {left},{top + cTopLeft + angleHeight}");
                            break;
                        default:
                            break;
                    }
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

