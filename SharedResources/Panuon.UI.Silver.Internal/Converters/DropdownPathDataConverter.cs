using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Converters
{
    internal class DropDownPathDataConverter : IMultiValueConverter
    {
        private const double _angleHeight = 6;

        private const double _angleWidth = 10;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var popupWidth = (double)values[0];
            var popupHeight = (double)values[1];
            if(popupHeight == 0 || popupWidth == 0)
            {
                return null;
            }
            var targetWidth = (double)values[2];
            var targetHeight = (double)values[3];
            var cornerRadius = (CornerRadius)values[4];
            var placement = (PopupXPlacement)values[5];
            var dropDownStyle = (DropDownStyle)values[6];
            var margin = (Thickness)values[7];
            var relativePosition = (Point)values[8];
            var cTopLeft = cornerRadius.TopLeft;
            var cTopRight = cornerRadius.TopRight;
            var cBottomLeft = cornerRadius.BottomLeft;
            var cBottomRight = cornerRadius.BottomRight;
            var mLeft = margin.Left;
            var mTop = margin.Top;
            var mRight = margin.Right;
            var mBottom = margin.Bottom;
      

            var path = new StringBuilder();
            switch (dropDownStyle)
            {
                case DropDownStyle.Standard:
                    switch (placement)
                    {
                        case PopupXPlacement.Bottom:
                        case PopupXPlacement.BottomLeft:
                        case PopupXPlacement.BottomRight:
                            path.Append($"M{mLeft},{mTop + cTopLeft + _angleHeight}");
                            path.Append(DrawLine(Dock.Left, popupHeight - cTopLeft - mTop));
                            path.Append(DrawCorner(cBottomLeft, cBottomLeft + mLeft, popupHeight - mBottom));
                            path.Append(DrawLine(Dock.Bottom, popupWidth - cBottomRight - mRight));
                            path.Append(DrawCorner(cBottomRight, popupWidth - mRight, popupHeight - cBottomRight - mBottom));
                            path.Append(DrawLine(Dock.Right, cTopRight + mTop + _angleHeight));
                            path.Append(DrawCorner(cTopRight, popupWidth - cTopRight - mRight, mTop + _angleHeight));
                            path.Append(DrawLine(Dock.Top, cTopLeft + mLeft, mTop + _angleHeight, -relativePosition.X + targetWidth / 2 + _angleWidth / 2 - mLeft));
                            path.Append(DrawCorner(cTopLeft, mLeft, cTopLeft + mTop + _angleHeight));
                            break;
                        case PopupXPlacement.Top:
                        case PopupXPlacement.TopLeft:
                        case PopupXPlacement.TopRight:
                            path.Append($"M{mLeft},{mTop + cTopLeft}");
                            path.Append(DrawLine(Dock.Left, popupHeight - cTopLeft - mTop - _angleHeight));
                            path.Append(DrawCorner(cBottomLeft, cBottomLeft + mLeft, popupHeight - mBottom - _angleHeight));
                            path.Append(DrawLine(Dock.Bottom, popupWidth - cBottomRight - mRight, popupHeight - mBottom - _angleHeight, -relativePosition.X + targetWidth / 2 - _angleWidth / 2 - mLeft));
                            path.Append(DrawCorner(cBottomRight, popupWidth - mRight, popupHeight - cBottomRight - mBottom - _angleHeight));
                            path.Append(DrawLine(Dock.Right, cTopRight + mTop));
                            path.Append(DrawCorner(cTopRight, popupWidth - cTopRight - mRight, mTop));
                            path.Append(DrawLine(Dock.Top, cTopLeft + mLeft));
                            path.Append(DrawCorner(cTopLeft, mLeft, cTopLeft + mTop));
                            break;
                        case PopupXPlacement.Left:
                            path.Append($"M{mLeft},{mTop + cTopLeft}");
                            path.Append(DrawLine(Dock.Left, popupHeight - cTopLeft - mTop));
                            path.Append(DrawCorner(cBottomLeft, cBottomLeft + mLeft, popupHeight - mBottom));
                            path.Append(DrawLine(Dock.Bottom, popupWidth - cBottomRight - mRight - _angleHeight));
                            path.Append(DrawCorner(cBottomRight, popupWidth - mRight - _angleHeight, popupHeight - cBottomRight - mBottom));
                            path.Append(DrawLine(Dock.Right, cTopRight + mTop, popupWidth - mRight - _angleHeight, -relativePosition.Y + targetHeight / 2 + _angleWidth / 2 - mTop));
                            path.Append(DrawCorner(cTopRight, popupWidth - cTopRight - mRight - _angleHeight, mTop));
                            path.Append(DrawLine(Dock.Top, cTopLeft + mLeft));
                            path.Append(DrawCorner(cTopLeft, mLeft, cTopLeft + mTop));
                            break;
                        case PopupXPlacement.Right:
                            path.Append($"M{mLeft + _angleHeight},{mTop + cTopLeft}");
                            path.Append(DrawLine(Dock.Left, popupHeight - cTopLeft - mTop, mLeft + _angleHeight, -relativePosition.Y + targetHeight / 2 - _angleWidth / 2 - mTop));
                            path.Append(DrawCorner(cBottomLeft, cBottomLeft + mLeft + _angleHeight, popupHeight - mBottom));
                            path.Append(DrawLine(Dock.Bottom, popupWidth - cBottomRight - mRight));
                            path.Append(DrawCorner(cBottomRight, popupWidth - mRight, popupHeight - cBottomRight - mBottom));
                            path.Append(DrawLine(Dock.Right, cTopRight + mTop));
                            path.Append(DrawCorner(cTopRight, popupWidth - cTopRight - mRight, mTop));
                            path.Append(DrawLine(Dock.Top, cTopLeft + mLeft + _angleHeight));
                            path.Append(DrawCorner(cTopLeft, mLeft + _angleHeight, cTopLeft + mTop));
                            break;
                    }
                    break;
                case DropDownStyle.Smooth:
                    path.Append($"M{mLeft},{mTop + cTopLeft}");
                    path.Append(DrawLine(Dock.Left, popupHeight - cTopLeft - mTop));
                    path.Append(DrawCorner(cBottomLeft, cBottomLeft + mLeft, popupHeight - mBottom));
                    path.Append(DrawLine(Dock.Bottom, popupWidth - cBottomRight - mRight));
                    path.Append(DrawCorner(cBottomRight, popupWidth - mRight, popupHeight - cBottomRight - mBottom));
                    path.Append(DrawLine(Dock.Right, cTopRight + mTop));
                    path.Append(DrawCorner(cTopRight, popupWidth - cTopRight - mRight, mTop));
                    path.Append(DrawLine(Dock.Top, cTopLeft + mLeft));
                    path.Append(DrawCorner(cTopLeft, mLeft, cTopLeft + mTop));
                    break;
            }

            return Geometry.Parse(path.ToString());

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }

        private string DrawCorner(double corner, double endX, double endY)
        {
            return $" A {corner},{corner} 0 0 0 {endX},{endY}";
        }

        private string DrawLine(Dock placement, double end)
        {
            switch (placement)
            {
                case Dock.Top:
                case Dock.Bottom:
                    return $" H {end}";
                default:
                    return $" V {end}";
            }
        }

        private string DrawLine(Dock placement, double end, double current, double angleStart)
        {
            switch (placement)
            {
                case Dock.Top:
                    return $" H {angleStart} L {angleStart - _angleWidth / 2},{current - _angleHeight} L {angleStart - _angleWidth},{current} H {end}";
                case Dock.Bottom:
                    return $" H {angleStart} L {angleStart + _angleWidth / 2},{ current + _angleHeight} L {angleStart + _angleWidth},{current} H {end}";
                case Dock.Left:
                    return $" V {angleStart} L {current - _angleHeight},{angleStart + _angleWidth / 2} L {current},{angleStart + _angleWidth} V {end}";
                default:
                    return $" V {angleStart} L {current + _angleHeight},{angleStart - _angleWidth / 2} L {current},{angleStart - _angleWidth} V {end}";
            }
        }
    }
}

