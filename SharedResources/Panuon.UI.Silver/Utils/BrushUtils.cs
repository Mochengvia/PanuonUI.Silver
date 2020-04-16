using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver.Utils
{
    internal static class BrushUtils
    {
        public static VisualBrush GetVisualBrush(Brush background, Brush foreground, double opacity)
        {
            return new VisualBrush(new Border()
            {
                Width = 1,
                Height = 1,
                Background = background,

                Child = new Border()
                {
                    Background = foreground,
                    Opacity = opacity
                }

            });
        }
    }
}
