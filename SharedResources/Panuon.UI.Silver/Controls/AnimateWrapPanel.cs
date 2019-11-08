using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Media;
using System.Collections.Generic;

namespace Panuon.UI.Silver
{
    public class AnimateWrapPanel : Panel
    {
        #region Property
        /// <summary>
        /// Gets or sets item height.
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(AnimateWrapPanel), new PropertyMetadata(30.0));

        /// <summary>
        /// Gets or sets vertical spacing.
        /// </summary>
        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }

        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(AnimateWrapPanel), new PropertyMetadata(20.0));


        /// <summary>
        /// Gets or sets horizontal spacing.
        /// </summary>
        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register("HorizontalSpacing", typeof(double), typeof(AnimateWrapPanel), new PropertyMetadata(10.0));
        #endregion

        #region Internal Property
        internal static Point GetPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(PositionProperty);
        }

        internal static void SetPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(PositionProperty, value);
        }

        internal static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached("Position", typeof(Point), typeof(AnimateWrapPanel));
        #endregion

        protected override Size MeasureOverride(Size constraint)
        {
            var panelDesiredSize = new Size();

            var x = 0.0;
            var y = 0.0;

            foreach (FrameworkElement child in InternalChildren)
            {
                child.Height = ItemHeight;
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

                var height = child.DesiredSize.Height;

                var width = child.DesiredSize.Width;
                if (x + width > constraint.Width)
                {
                    y += (ItemHeight + VerticalSpacing);
                    x = 0;
                }

                if (!IsLoaded)
                {
                    child.Arrange(new Rect(x, y, child.DesiredSize.Width, child.DesiredSize.Height));
                    child.RenderTransformOrigin = new Point(0, 0);
                    child.RenderTransform = new TranslateTransform() { X = 0, Y = 0 };
                    SetPosition(child, new Point(x, y));
                }
                else
                {
                    var point = GetPosition(child);
                    child.Arrange(new Rect(point.X, point.Y, child.DesiredSize.Width, child.DesiredSize.Height));
                    AnimateArrange(child, x - point.X, y - point.Y);
                }

                x += (width + HorizontalSpacing);
                System.Diagnostics.Debug.WriteLine(x);

            }
            panelDesiredSize = new Size(constraint.Width, y + ItemHeight);

            return panelDesiredSize;
        }

        private void AnimateArrange(FrameworkElement element, double x, double y)
        {
            element.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation()
            {
                To = x,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
            });
            element.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation()
            {
                To = y,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
            });
        }
    }
}
