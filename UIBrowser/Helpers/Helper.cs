using System;
using System.Linq;
using System.Windows.Media;

namespace UIBrowser.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Computer render performance. Good = 2, Normal = 1, Bad = 0.
        /// </summary>
        public static int Tier { get; set; }

        static Helper()
        {
            Tier = RenderCapability.Tier >> 16;
        }

        public static Color GetColorByOffset(GradientStopCollection collection, double offset)
        {
            var stops = collection.OrderBy(x => x.Offset).ToArray();
            if (offset <= 0) return stops[0].Color;
            if (offset >= 1) return stops[stops.Length - 1].Color;
            var left = stops.Where(s => s.Offset <= offset).Last();
            var right = stops.Where(s => s.Offset > offset).First();
            offset = Math.Round((offset - left.Offset) / (right.Offset - left.Offset), 2);
            var a = (byte)((right.Color.A - left.Color.A) * offset + left.Color.A);
            var r = (byte)((right.Color.R - left.Color.R) * offset + left.Color.R);
            var g = (byte)((right.Color.G - left.Color.G) * offset + left.Color.G);
            var b = (byte)((right.Color.B - left.Color.B) * offset + left.Color.B);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
