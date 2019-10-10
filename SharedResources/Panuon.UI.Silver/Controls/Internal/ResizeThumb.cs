using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Panuon.UI.Silver.Controls.Internal
{
    internal class ResizeThumb : Thumb
    {
        public ResizeThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
        }

        #region Property
        public bool IsSquare
        {
            get { return (bool)GetValue(IsSquareProperty); }
            set { SetValue(IsSquareProperty, value); }
        }

        public static readonly DependencyProperty IsSquareProperty =
            DependencyProperty.Register("IsSquare", typeof(bool), typeof(ResizeThumb));

        public bool LimitInParent
        {
            get { return (bool)GetValue(LimitInParentProperty); }
            set { SetValue(LimitInParentProperty, value); }
        }

        public static readonly DependencyProperty LimitInParentProperty =
            DependencyProperty.Register("LimitInParent", typeof(bool), typeof(ResizeThumb));

        #endregion

        #region Event
        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var element = this.DataContext as FrameworkElement;
            if (double.IsNaN(Canvas.GetLeft(element)))
                Canvas.SetLeft(element, 0);
            if (double.IsNaN(Canvas.GetTop(element)))
                Canvas.SetTop(element, 0);

            var parentCanvas = element.Parent as Canvas;
            double width = 0.0;
            double height = 0.0;
            var left = Canvas.GetLeft(element);
            var top = Canvas.GetTop(element);

            if (HorizontalAlignment == HorizontalAlignment.Left || HorizontalAlignment == HorizontalAlignment.Right)
            {
                if (HorizontalAlignment == HorizontalAlignment.Left)
                {
                    width = element.ActualWidth - e.HorizontalChange;
                    if (LimitInParent && parentCanvas != null)
                    {
                        if (left + e.HorizontalChange < 0 && element.ActualWidth != element.MaxWidth)
                            width = element.ActualWidth + left;
                    }
                }
                else
                {
                    width = element.ActualWidth + e.HorizontalChange;
                    if (LimitInParent && parentCanvas != null)
                    {
                        if (left + element.ActualWidth + e.HorizontalChange > parentCanvas.ActualWidth && element.ActualWidth != element.MaxWidth)
                            width = parentCanvas.ActualWidth - left;
                    }
                }

                width = width > element.MaxWidth ? element.MaxWidth : width;
                width = width < element.MinWidth ? element.MinWidth : width;
            }

            if (VerticalAlignment == VerticalAlignment.Top || VerticalAlignment == VerticalAlignment.Bottom)
            {
                if (VerticalAlignment == VerticalAlignment.Top)
                {
                    height = element.ActualHeight - e.VerticalChange;
                    if (LimitInParent && parentCanvas != null)
                    {
                        if (top + e.VerticalChange < 0 && element.ActualHeight != element.MaxHeight)
                            height = element.ActualHeight + top;
                    }
                }
                else
                {
                    height = element.ActualHeight + e.VerticalChange;
                    if (LimitInParent && parentCanvas != null)
                    {
                        if (top + element.ActualHeight + e.VerticalChange > parentCanvas.ActualHeight && element.ActualHeight != element.MaxHeight)
                            height = parentCanvas.ActualHeight - top;
                    }
                }
                height = height > element.MaxHeight ? element.MaxHeight : height;
                height = height < element.MinHeight ? element.MinHeight : height;
            }

            if (!IsSquare)
            {
                if (width != 0)
                    SetElementWidth(element, width, left);
                if (height != 0)
                    SetElementHeight(element, height, top);
            }
            else
            {
                if(width != 0)
                {
                    if (!LimitInParent)
                    {
                        SetElementWidth(element, width, left);
                        SetElementHeight(element, width, top);

                    }
                    if (LimitInParent)
                    {
                        if (width + top < parentCanvas.ActualHeight)
                        {
                            SetElementWidth(element, width, left);
                            SetElementHeight(element, width, top);
                        }
                    }
                }
                else if(height != 0)
                {
                    if (!LimitInParent)
                    {
                        SetElementWidth(element, height, left);
                        SetElementHeight(element, height, top);

                    }
                    if (LimitInParent)
                    {
                        if (height + left <= parentCanvas.ActualWidth)
                        {
                            SetElementWidth(element, height, left);
                            SetElementHeight(element, height, top);
                        }
                    }
                }
            }
        }
        #endregion

        #region Function
        private void SetElementWidth(FrameworkElement element, double width, double left)
        {
            if (HorizontalAlignment == HorizontalAlignment.Left)
            {
                var delta = element.ActualWidth - width;
                Canvas.SetLeft(element, left + delta);
            }
            element.Width = width;
        }

        private void SetElementHeight(FrameworkElement element, double height, double top)
        {
            if (VerticalAlignment == VerticalAlignment.Top)
            {
                var delta = element.ActualHeight - height;
                Canvas.SetTop(element, Canvas.GetTop(element) + delta);
            }
            element.Height = height;
        }
        #endregion
    }
}
