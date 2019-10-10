using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Controls.Internal
{
    internal class WaterfallPanel : Panel
    {
        #region Identity

        #endregion

        #region Constructor

        #endregion

        #region Property
        /// <summary>
        /// Groups
        /// </summary>
        public int Groups
        {
            get { return (int)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        public static readonly DependencyProperty GroupsProperty =
            DependencyProperty.Register("Groups", typeof(int), typeof(WaterfallPanel), new FrameworkPropertyMetadata(2, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Orientation
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(WaterfallPanel), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Vertical spacing.
        /// </summary>
        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }

        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(WaterfallPanel), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Horizontal spacing.
        /// </summary>
        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register("HorizontalSpacing", typeof(double), typeof(WaterfallPanel), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region EventHandler
        protected override Size MeasureOverride(Size availableSize)
        {
            var panelDesiredSize = new Size();
            var isFirstItem = true;

            if (Orientation == Orientation.Vertical)
            {
                var width = (availableSize.Width - (Groups - 1) * HorizontalSpacing) / Groups;
                var heights = new double[Groups].ToList();

                for (int i = 0; i < Groups; i ++)
                {
                    heights[i] = -VerticalSpacing;
                }

                foreach (UIElement child in InternalChildren)
                {
                    var minHeight = heights.Min();
                    var minHeightIndex = heights.IndexOf(minHeight);

                    child.Measure(availableSize);

                    child.Arrange(new Rect(new Point((width + HorizontalSpacing) * minHeightIndex, minHeight + VerticalSpacing), new Size(width, child.DesiredSize.Height)));

                    heights[minHeightIndex] = heights[minHeightIndex] + child.DesiredSize.Height + VerticalSpacing;

                    panelDesiredSize = new Size(availableSize.Width, heights.Max());
                }
            }
            else
            {
                var height = (availableSize.Height - (Groups - 1) * VerticalSpacing) / Groups;
                var widths = new double[Groups].ToList();

                for (int i = 0; i < Groups; i++)
                {
                    widths[i] = -HorizontalSpacing;
                }

                foreach (UIElement child in InternalChildren)
                {
                    var minWidth = widths.Min();
                    var minWidthIndex = widths.IndexOf(minWidth);

                    child.Measure(availableSize);

                    child.Arrange(new Rect(new Point(minWidth + HorizontalSpacing ,(height + VerticalSpacing) * minWidthIndex), new Size(child.DesiredSize.Width, height)));

                    widths[minWidthIndex] = widths[minWidthIndex] + child.DesiredSize.Width + HorizontalSpacing;

                    panelDesiredSize = new Size(widths.Max(), availableSize.Height);
                }
            }

            return panelDesiredSize;
        }
        #endregion
    }
}
