using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Panuon.UI.Silver.Controls.Internal
{
    internal class DragableThumb : Thumb
    {
        static DragableThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragableThumb), new FrameworkPropertyMetadata(typeof(DragableThumb)));
        }

        public DragableThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var element = DragTarget as FrameworkElement;

            if (double.IsNaN(Canvas.GetLeft(element)))
                Canvas.SetLeft(element, 0);
            if (double.IsNaN(Canvas.GetTop(element)))
                Canvas.SetTop(element, 0);

            var width = element.ActualWidth;
            var height = element.ActualHeight;
            var left = Canvas.GetLeft(element);
            var targetLeft = left + e.HorizontalChange;
            var top = Canvas.GetTop(element);
            var targetTop = top + e.VerticalChange;
            var parentCanvas = element.Parent as Canvas;

            if (LimitInParent && parentCanvas != null)
            {
                if (targetLeft < 0)
                    targetLeft = 0;
                else if (targetLeft + width > parentCanvas.ActualWidth)
                    targetLeft = parentCanvas.ActualWidth - width;

                if (targetTop < 0)
                    targetTop = 0;
                else if (targetTop + height > parentCanvas.ActualHeight)
                    targetTop = parentCanvas.ActualHeight - height;
            }


            Canvas.SetLeft(element, targetLeft);
            Canvas.SetTop(element, targetTop);

        }

        #region Property
        public DependencyObject DragTarget
        {
            get { return (DependencyObject)GetValue(DragTargetProperty); }
            set { SetValue(DragTargetProperty, value); }
        }

        public static readonly DependencyProperty DragTargetProperty =
            DependencyProperty.Register("DragTarget", typeof(DependencyObject), typeof(DragableThumb));



        public bool LimitInParent
        {
            get { return (bool)GetValue(LimitInParentProperty); }
            set { SetValue(LimitInParentProperty, value); }
        }

        public static readonly DependencyProperty LimitInParentProperty =
            DependencyProperty.Register("LimitInParent", typeof(bool), typeof(DragableThumb));


        #endregion
    }
}
