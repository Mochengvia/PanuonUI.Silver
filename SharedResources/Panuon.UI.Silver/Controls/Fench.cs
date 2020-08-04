using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Panuon.UI.Silver
{
    public class Fench : Canvas
    {
        #region Fields
        #endregion

        #region Ctor
        static Fench()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(Fench), new PropertyMetadata(true));
        }

        public Fench()
        {
            AddHandler(Thumb.DragDeltaEvent, new DragDeltaEventHandler(OnThumbDragDelta));
        }
        #endregion

        #region Properties

        #region FenchStrategy
        public FenchStrategy Strategy
        {
            get { return (FenchStrategy)GetValue(StrategyProperty); }
            set { SetValue(StrategyProperty, value); }
        }

        public static readonly DependencyProperty StrategyProperty =
            DependencyProperty.Register("Strategy", typeof(FenchStrategy), typeof(Fench), new PropertyMetadata(OnStrategyChanged));
        #endregion

        #endregion

        #region Overrides
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            RelocationAll();
        }
        #endregion

        #region Event Handlers
        private void OnThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = e.Source as Thumb;
            Relocation(thumb, e.HorizontalChange, e.VerticalChange);
        }

        private static void OnStrategyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fench = d as Fench;
            fench.RelocationAll();
        }
        #endregion

        #region Functions
        private void RelocationAll()
        {
            if (Children != null)
            {
                foreach (UIElement child in Children)
                {
                    Relocation(child);
                }
            }
        }

        private void Relocation(UIElement uiElement, double horizontalChange = 0, double verticalChange = 0)
        {
            var left = GetLeft(uiElement);
            left = double.IsNaN(left) ? 0 : left;
            var top = GetTop(uiElement);
            top = double.IsNaN(top) ? 0 : top;

            var x = left + horizontalChange;
            var y = top + verticalChange;
            var width = uiElement.DesiredSize.Width;
            var height = uiElement.DesiredSize.Height;

            var location = CalcLocation(x, y, width, height);
            SetLeft(uiElement, location.X);
            SetTop(uiElement, location.Y);
        }

        private Point CalcLocation(double x, double y, double width, double height)
        {
            if (Strategy != FenchStrategy.Free)
            {
                var widthDelta = ActualWidth - width;
                var heightDelta = ActualHeight - height;

                switch (Strategy)
                {
                    case FenchStrategy.Edged:
                        x = x < 0 ? 0 : x;
                        y = y < 0 ? 0 : y;
                        x = x > widthDelta ? widthDelta : x;
                        y = y > heightDelta ? heightDelta : y;
                        break;
                    case FenchStrategy.Crossed:
                        var halfHeight = height / 2;
                        var halfWidth = width / 2;

                        x = x < -halfWidth ? -halfWidth : x;
                        y = y < -halfHeight ? -halfHeight : y;
                        x = x > (widthDelta + halfWidth) ? (widthDelta + halfWidth) : x;
                        y = y > (heightDelta + halfHeight) ? (heightDelta + halfHeight) : y;
                        break;
                    default:
                        break;
                }
            }

            return new Point(x, y);
        }
        #endregion
    }
}
