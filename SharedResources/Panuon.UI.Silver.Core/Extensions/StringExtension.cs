using System.Windows.Media;

namespace Panuon.UI.Silver.Core
{
    public static class StringExtension
    {
        #region IsNullOrEmpty & IsNullOrWhiteSpace
        /// <summary>
        /// Validate is string null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Validate is string null or white space.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
        #endregion

        #region Cut
        /// <summary>
        /// Cut string if exceed max length.
        /// </summary>
        /// <param name="maxLength">Max length.</param>
        /// <param name="exceededFiller">String to append if exceeded max length.</param>
        public static string Cut(this string text,int maxLength, string exceededFiller = "...")
        {
            if (text.Length <= maxLength)
                return text;
            else
                return text.Remove(maxLength) + exceededFiller;
        }
        #endregion

        #region Int
        /// <summary>
        /// Try parse to integer value. Returns null if parse failed.
        /// </summary>
        public static int? ToInt(this string text)
        {
            int result;
            if (int.TryParse(text, out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Try parse to integer value.
        /// <paramref name="failedValue">Value to return if parse failed.</paramref>
        /// </summary>
        public static int ToInt(this string text, int failedValue)
        {
            return text.ToInt() ?? failedValue;
        }
        #endregion

        #region Double
        /// <summary>
        /// Try parse to double value. Returns null if parse failed.
        /// </summary>
        public static double? ToDouble(this string text)
        {
            double result;
            if (double.TryParse(text, out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Try parse to double value.
        /// <paramref name="failedValue">Value to return if parse failed.</paramref>
        /// </summary>
        public static double ToDouble(this string text, double failedValue)
        {
            return text.ToDouble() ?? failedValue;
        }
        #endregion

        #region Color
        /// <summary>
        /// Try parse to color. Returns null if parse failed.
        /// </summary>
        public static Color? ToColor(this string text)
        {
            return ColorConverter.ConvertFromString(text) as Color?;
        }

        /// <summary>
        /// Try parse to color.
        /// </summary>
        public static Color ToColor(this string text, Color failedValue)
        {
            return (ColorConverter.ConvertFromString(text) as Color?) ?? failedValue;
        }
        #endregion

        #region Range
        public static string Range(this string text, int index, int count)
        {
            var newText = text.Remove(0, index);
            return (count >= newText.Length) ? newText : newText.Remove(count);
        }
        #endregion

    }
}
