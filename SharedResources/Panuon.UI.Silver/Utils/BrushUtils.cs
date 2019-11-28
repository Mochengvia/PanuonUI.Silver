using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Panuon.UI.Silver.Utils
{
    internal static class BrushUtils
    {
        public static Brush GetBrush(double percent, Brush foreground, Brush hoverBrush)
        {
            if (percent == 0)
                return foreground;
            if (percent == 1)
                return hoverBrush;

            return new VisualBrush(new System.Windows.Controls.Border()
            {
                Width = 1,
                Height = 1,
                Background = foreground,
                Child = new System.Windows.Controls.Border()
                {
                    Background = hoverBrush,
                    Opacity = percent,
                }
            });
        }
    }
}
