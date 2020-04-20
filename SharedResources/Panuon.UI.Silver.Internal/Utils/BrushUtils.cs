using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class BrushUtils
    {
        public static VisualBrush GetSuperposedVisualBrush(Brush background, Brush foreground, double opacity)
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

        public static VisualBrush GetStackedVisualBrush(Brush brush1, Brush brush2, Orientation oritention, double offset)
        {
            var grid = new Grid()
            {
                Width = 1,
                Height = 1,
            };
            if(oritention == Orientation.Horizontal)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new System.Windows.GridLength(offset, System.Windows.GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new System.Windows.GridLength(1 - offset, System.Windows.GridUnitType.Star) });

                var rectangle1 = new Rectangle() { Fill = brush1 };
                grid.Children.Add(rectangle1);

                var rectangle2 = new Rectangle() { Fill = brush2 };
                Grid.SetColumn(rectangle2, 1);
                grid.Children.Add(rectangle2);
            }
            else
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new System.Windows.GridLength(offset, System.Windows.GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new System.Windows.GridLength(1 - offset, System.Windows.GridUnitType.Star) });

                var rectangle1 = new Rectangle() { Fill = brush1 };
                grid.Children.Add(rectangle1);

                var rectangle2 = new Rectangle() { Fill = brush2 };
                Grid.SetRow(rectangle2, 1);
                grid.Children.Add(rectangle2);
            }
            

            return new VisualBrush(grid);
        }
    }
}
