using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Core
{
    public static class ColorExtension
    {
        #region ToBrush
        /// <summary>
        /// Create solidColorBrush from color.
        /// </summary>
        /// <param name="color">Color.</param>
        public static SolidColorBrush ToBrush(this Color color)
        {
            var brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }

        /// <summary>
        /// Create solidColorBrush from color. Returns transparent brush if color is null.
        /// </summary>
        /// <param name="color">Color.</param>
        public static SolidColorBrush ToBrush(this Color? color)
        {
            return color == null ? Colors.Transparent.ToBrush() : ((Color)color).ToBrush();
        }

        /// <summary>
        /// Create linearGradientBrush from colors.
        /// </summary>
        /// <param name="colors">Colors.</param>
        public static LinearGradientBrush ToBrush(this IEnumerable<Color> colors)
        {
            var brush = new LinearGradientBrush();
            var colorList = colors.ToList();
            for (int i = 0; i < colorList.Count; i++)
            {
                brush.GradientStops.Add(new GradientStop()
                {
                    Color = colorList[i],
                    Offset = i * 1.0 / colorList.Count
                });
            }
            return brush;
        }

        /// <summary>
        /// Create linearGradientBrush from colors.
        /// </summary>
        /// <param name="colors">Colors.</param>
        /// <param name="startPoint">Start point.</param>
        /// <param name="endPoint">End point.</param>
        public static LinearGradientBrush ToBrush(this IEnumerable<Color> colors, Point startPoint, Point endPoint)
        {
            var brush = new LinearGradientBrush()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
            };
            var colorList = colors.ToList();
            for (int i = 0; i < colorList.Count; i++)
            {
                brush.GradientStops.Add(new GradientStop()
                {
                    Color = colorList[i],
                    Offset = i * 1.0 / colorList.Count
                });
            }
            return brush;
        }

        /// <summary>
        /// Create linearGradientBrush from colors.
        /// </summary>
        /// <param name="colors">Colors.</param>
        public static LinearGradientBrush ToBrush(this IList<Color> colors)
        {
            var brush = new LinearGradientBrush();
            for (int i = 0; i < colors.Count; i++)
            {
                brush.GradientStops.Add(new GradientStop()
                {
                    Color = colors[i],
                    Offset = i * 1.0 / colors.Count
                });
            }
            return brush;
        }

        /// <summary>
        /// Create linearGradientBrush from colors.
        /// </summary>
        /// <param name="colors">Colors.</param>
        /// <param name="startPoint">Start point.</param>
        /// <param name="endPoint">End point.</param>
        public static LinearGradientBrush ToBrush(this IList<Color> colors, Point startPoint, Point endPoint)
        {
            var brush = new LinearGradientBrush()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
            };
            for (int i = 0; i < colors.Count; i++)
            {
                brush.GradientStops.Add(new GradientStop()
                {
                    Color = colors[i],
                    Offset = i * 1.0 / colors.Count
                });
            }
            return brush;
        }
        #endregion

        #region ToHexString
        /// <summary>
        /// Convert to hex string.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <param name="withAlpha">Include alpha channel.</param>
        /// <returns></returns>
        public static string ToHexString(this Color color, bool withAlpha = true)
        {
            if (withAlpha)
                return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
            else
                return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        /// <summary>
        /// Convert to hex string.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <param name="withAlpha">Include alpha channel.</param>
        /// <returns></returns>
        public static string ToHexString(this Color? color, bool withAlpha = true)
        {
            if (color == null)
                return null;

            var colorValue = (Color)color;
            if (withAlpha)
                return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", colorValue.A, colorValue.R, colorValue.G, colorValue.B);
            else
                return string.Format("#{0:X2}{1:X2}{2:X2}", colorValue.R, colorValue.G, colorValue.B);
        }
        #endregion
    }
}
