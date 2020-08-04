using System.Windows.Media;

namespace Panuon.UI.Silver.Core
{
    public static class ColorExtension
    {
        #region ToColor
        public static Color ToColor(this string hex)
        {
            return (Color)ColorConverter.ConvertFromString(hex);
        }

        public static Color ToColor(this string hex, Color defaultColor)
        {
            try
            {
                return (Color)ColorConverter.ConvertFromString(hex);
            }
            catch
            {
                return defaultColor;
            }
        }
        #endregion

        #region ToHexString
        /// <summary>
        /// Convert to hex string.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <param name="alpha">Include alpha channel.</param>
        /// <returns></returns>
        public static string ToHexString(this Color color, bool alpha = true)
        {
            if (alpha)
                return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
            else
                return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        /// <summary>
        /// Convert to hex string.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <param name="alpha">Include alpha channel.</param>
        /// <returns></returns>
        public static string ToHexString(this Color? color, bool alpha = true)
        {
            if (color == null)
                return null;

            var colorValue = (Color)color;
            if (alpha)
                return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", colorValue.A, colorValue.R, colorValue.G, colorValue.B);
            else
                return string.Format("#{0:X2}{1:X2}{2:X2}", colorValue.R, colorValue.G, colorValue.B);
        }
        #endregion

    }
}
