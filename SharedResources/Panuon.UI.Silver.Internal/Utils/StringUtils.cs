using System;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal class StringUtils
    {
        public static Size MeasureTextSize(string text, TextWrapping textWrapping, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch, double fontSize, double maxWidth)
        {
            var textBlock = new System.Windows.Controls.TextBlock
            {
                Text = text,
                TextWrapping = textWrapping,
                FontSize = fontSize,
                FontFamily = fontFamily,
                FontStretch = fontStretch,
                FontStyle = fontStyle,
                FontWeight = fontWeight,
            };

            textBlock.Measure(new Size(maxWidth, Double.PositiveInfinity));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));
            return new Size(textBlock.ActualWidth, textBlock.ActualHeight);
        }
    }

}
