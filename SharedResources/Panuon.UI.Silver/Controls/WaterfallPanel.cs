using Panuon.UI.Silver.Core;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class WaterfallPanel : Panel
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

        /// <summary>
        /// Gets or sets children shape.
        /// </summary>
        public ChildrenShape ChildrenShape
        {
            get { return (ChildrenShape)GetValue(ChildrenShapeProperty); }
            set { SetValue(ChildrenShapeProperty, value); }
        }

        public static readonly DependencyProperty ChildrenShapeProperty =
            DependencyProperty.Register("ChildrenShape", typeof(ChildrenShape), typeof(WaterfallPanel));


        /// <summary>
        /// Gets or sets children shape size delta.
        /// </summary>
        public double ChildrenShapeSizeDelta
        {
            get { return (double)GetValue(ChildrenShapeSizeDeltaProperty); }
            set { SetValue(ChildrenShapeSizeDeltaProperty, value); }
        }

        public static readonly DependencyProperty ChildrenShapeSizeDeltaProperty =
            DependencyProperty.Register("ChildrenShapeSizeDelta", typeof(double), typeof(WaterfallPanel));


        #endregion

        #region EventHandler
        protected override Size MeasureOverride(Size availableSize)
        {
            var panelDesiredSize = new Size();

            if (Orientation == Orientation.Vertical)
            {
                var width = (availableSize.Width - (Groups - 1) * HorizontalSpacing) / Groups;
                width = width < 0 ? 0 : width;

                var heights = new double[Groups].ToList();

                for (int i = 0; i < Groups; i ++)
                {
                    heights[i] = -VerticalSpacing;
                }

                foreach (UIElement child in InternalChildren)
                {
                    child.Measure(availableSize);

                    var height = ChildrenShape == ChildrenShape.Square ? (width + ChildrenShapeSizeDelta) : child.DesiredSize.Height;

                    var minHeight = heights.Min();
                    var minHeightIndex = heights.IndexOf(minHeight);

                    child.Arrange(new Rect(new Point((width + HorizontalSpacing) * minHeightIndex, minHeight + VerticalSpacing), new Size(width, height)));

                    heights[minHeightIndex] = heights[minHeightIndex] + height + VerticalSpacing;

                    panelDesiredSize = new Size(availableSize.Width, heights.Max());
                }
            }
            else
            {
                var height = (availableSize.Height - (Groups - 1) * VerticalSpacing) / Groups;
                height = height < 0 ? 0 : height;
                var widths = new double[Groups].ToList();

                for (int i = 0; i < Groups; i++)
                {
                    widths[i] = -HorizontalSpacing;
                }

                foreach (UIElement child in InternalChildren)
                {
                    var width = ChildrenShape == ChildrenShape.Square ? (height + ChildrenShapeSizeDelta) : child.DesiredSize.Width;

                    var minWidth = widths.Min();
                    var minWidthIndex = widths.IndexOf(minWidth);

                    child.Measure(availableSize);

                    child.Arrange(new Rect(new Point(minWidth + HorizontalSpacing ,(height + VerticalSpacing) * minWidthIndex), new Size(width, height)));

                    widths[minWidthIndex] = widths[minWidthIndex] + width + HorizontalSpacing;

                    panelDesiredSize = new Size(widths.Max(), availableSize.Height);
                }
            }

            return panelDesiredSize;
        }
        #endregion
    }
}
