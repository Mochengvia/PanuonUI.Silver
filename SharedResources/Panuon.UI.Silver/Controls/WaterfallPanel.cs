using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class WaterfallPanel : Panel
    {
        #region Property

        #region Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(WaterfallPanel));
        #endregion

        #region Groups
        public int Groups
        {
            get { return (int)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        public static readonly DependencyProperty GroupsProperty =
            DependencyProperty.Register("Groups", typeof(int), typeof(WaterfallPanel));
        #endregion

        #region VerticalSpacing


        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }

        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(WaterfallPanel));

        #endregion

        #region HorizontalSpacing


        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register("HorizontalSpacing", typeof(double), typeof(WaterfallPanel));


        #endregion

        #region ItemWidth
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register("ItemWidth", typeof(double), typeof(WaterfallPanel), new PropertyMetadata(double.NaN, null, OnItemWidthOrHeightCoerceValue));
        #endregion

        #region ItemHeight
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(WaterfallPanel), new PropertyMetadata(double.NaN, null, OnItemWidthOrHeightCoerceValue));
        #endregion

        #endregion

        #region Event Handler
        private static object OnItemWidthOrHeightCoerceValue(DependencyObject d, object baseValue)
        {
            var value = (double)baseValue;
            if (double.IsInfinity(value))
                return double.NaN;
            else if (value < 0)
                return 0;
            else
                return value;

        }
        #endregion

        #region Override
        protected override Size MeasureOverride(Size availableSize)
        {
            Size panelDesiredSize;

            var panelWidth = availableSize.Width;
            var panelHeight = availableSize.Height;

            if (Orientation == Orientation.Vertical)
            {
                var columnHeights = new double[Groups].ToList();
                columnHeights.ForEach(x => x = -VerticalSpacing);

                foreach (UIElement child in InternalChildren)
                {
                    child.Measure(availableSize);

                    var width = (panelWidth - (Groups - 1) * HorizontalSpacing) / Groups;
                    var height = child.DesiredSize.Height;
                    if (!double.IsNaN(ItemHeight))
                        height = ItemHeight;

                    var minColumnHeight = columnHeights.Min();
                    var minColumnIndex = columnHeights.IndexOf(minColumnHeight);

                    child.Arrange(new Rect(new Point((width + HorizontalSpacing) * minColumnIndex, minColumnHeight + VerticalSpacing), new Size(width, height)));
                    columnHeights[minColumnIndex] = columnHeights[minColumnIndex] + height + VerticalSpacing;
                }
                panelDesiredSize = new Size(panelWidth, columnHeights.Max());
            }
            else
            {
                var rowWidths = new double[Groups].ToList();
                rowWidths.ForEach(x => x = -HorizontalSpacing);

                foreach (UIElement child in InternalChildren)
                {
                    child.Measure(availableSize);

                    var height = (panelHeight - (Groups - 1) * VerticalSpacing) / Groups;
                    var width = child.DesiredSize.Width;
                    if (!double.IsNaN(ItemWidth))
                        width = ItemWidth;

                    var minRowWidth = rowWidths.Min();
                    var minRowIndex = rowWidths.IndexOf(minRowWidth);

                    child.Arrange(new Rect(new Point(minRowWidth + HorizontalSpacing, (height + VerticalSpacing) * minRowIndex), new Size(width, height)));
                    rowWidths[minRowIndex] = rowWidths[minRowIndex] + width + HorizontalSpacing;
                }
                panelDesiredSize = new Size(rowWidths.Max(), panelHeight);
            }

            return panelDesiredSize;
        }
        #endregion
    }
}
