using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Panuon.UI.Silver
{
    public static class Extension
    {
        #region String
        /// <summary>
        /// 指示该字符串是否是Null或空字符串。
        /// </summary>
        /// <summary xml:lang="en">
        /// 
        /// </summary>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static string Cut(this string text, int length, string filler = null)
        {
            if (text.Length <= length)
                return text;
            else
            {
                return text.Remove(length) + filler;
            }
        }
        #endregion

        #region Timestamp <-> Datetime
        public static long ToTimeStamp(this DateTime date, bool withMilliseconds = true)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1);
            if (withMilliseconds)
                return Convert.ToInt64(ts.TotalMilliseconds);
            else
                return Convert.ToInt64(ts.TotalSeconds);
        }

        public static DateTime ToDateTime(this long timeStamp, bool withMilliseconds = true)
        {
            if (withMilliseconds)
                return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds(timeStamp);
            else
                return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
        }
        #endregion

        #region Color
        public static SolidColorBrush ToBrush(this Color color)
        {
            var brush = new SolidColorBrush(color);
            brush.Freeze();
            return brush;
        }

        public static SolidColorBrush ToBrush(this Color? color)
        {
            if (color == null)
                return new SolidColorBrush(Colors.Transparent);
            return new SolidColorBrush((Color)color);
        }

        public static Color ToColor(this string color)
        {
            return (Color)ColorConverter.ConvertFromString(color);
        }

        public static Color ToColor(this SolidColorBrush brush)
        {
            if (brush == null)
                return Colors.Transparent;
            return brush.Color;
        }

        public static Color ToColor(this Brush brush)
        {
            if (brush == null)
                return Colors.Transparent;
            if (brush is SolidColorBrush)
                return (brush as SolidColorBrush).Color;
            else if (brush is LinearGradientBrush)
                return (brush as LinearGradientBrush).GradientStops[0].Color;
            else if (brush is RadialGradientBrush)
                return (brush as RadialGradientBrush).GradientStops[0].Color;
            else
                return Colors.Transparent;
        }

        public static string ToHexString(this Color color, bool withAlpha = true)
        {
            if (withAlpha)
                return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
            else
                return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static string ToHexString(this Color? color, bool withAlpha = true)
        {
            if (color == null)
                return "";

            var realColor = (Color)color;
            if (withAlpha)
                return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", realColor.A, realColor.R, realColor.G, realColor.B);
            else
                return string.Format("#{0:X2}{1:X2}{2:X2}", realColor.R, realColor.G, realColor.B);
        }

        public static LinearGradientBrush ToBrush(this Color[] colors)
        {
            var lcb = new LinearGradientBrush();
            for (int i = 0; i < colors.Length; i++)
            {
                lcb.GradientStops.Add(new GradientStop()
                {
                    Color = colors[i],
                    Offset = i * 1.0 / colors.Length
                });
            }
            return lcb;
        }

        public static bool IsEqual(this Color thisColor, Color color)
        {
            return thisColor.A == color.A && thisColor.R == color.R && thisColor.G == color.G
                && thisColor.B == color.B;
        }
        #endregion

        #region List

        #endregion

        #region 

        #endregion

        #region Brushes


        #endregion

        #region Converter
        public static int? ToInt(this string text)
        {
            var result = 0;
            if (int.TryParse(text, out result))
                return result;
            else
                return null;
        }

        public static double? ToDouble(this string text)
        {
            var result = 0.0;
            if (double.TryParse(text, out result))
                return result;
            else
                return null;
        }
        #endregion

        #region Bitmap -> BitmapImage
        public static BitmapImage ToBitmapImage(this System.Drawing.Bitmap bmp)
        {
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static BitmapImage ToBitmapImage(this BitmapSource source)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                BitmapImage bImg = new BitmapImage();

                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(memoryStream);

                memoryStream.Position = 0;
                bImg.BeginInit();
                bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
                bImg.EndInit();
                return bImg;
            }
        }
        #endregion
    }
}
