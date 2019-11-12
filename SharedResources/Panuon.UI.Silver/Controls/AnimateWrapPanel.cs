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
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(AnimateWrapPanel));

        /// <summary>
        /// Gets or sets item height.
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(AnimateWrapPanel), new PropertyMetadata(double.NaN));

        /// <summary>
        /// Gets or sets item width.
        /// </summary>
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register("ItemWidth", typeof(double), typeof(AnimateWrapPanel), new PropertyMetadata(double.NaN));

        /// <summary>
        /// Gets or sets vertical spacing.
        /// </summary>
        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }

        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(AnimateWrapPanel));


        /// <summary>
        /// Gets or sets horizontal spacing.
        /// </summary>
        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register("HorizontalSpacing", typeof(double), typeof(AnimateWrapPanel));
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
            var x = 0.0;
            var y = 0.0;
            Size panelDesiredSize;

            var itemWidth = ItemWidth;
            var itemHeight = ItemHeight;
            var itemWidthSet = !double.IsNaN(itemWidth) && !double.IsPositiveInfinity(itemWidth);
            var itemHeightSet = !double.IsNaN(itemHeight) && !double.IsPositiveInfinity(itemHeight);

            if (Orientation == Orientation.Horizontal)
            {
                foreach (FrameworkElement child in InternalChildren)
                {
                    child.Height = itemHeightSet ? itemHeight : child.Height;
                    child.Width = itemWidthSet ? itemWidth : child.Width;

                    child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

                    var height = child.DesiredSize.Height;

                    var width = child.DesiredSize.Width;
                    if (x + width > constraint.Width)
                    {
                        y += (height + VerticalSpacing);
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
                        if (!(child.RenderTransform is TranslateTransform))
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
                    }

                    x += (width + HorizontalSpacing);
                    System.Diagnostics.Debug.WriteLine(x);

                }
                panelDesiredSize = new Size(constraint.Width, y + (itemHeightSet ? itemHeight : 0));
            }
            else
            {
                foreach (FrameworkElement child in InternalChildren)
                {
                    child.Height = itemHeightSet ? itemHeight : child.Height;
                    child.Width = itemWidthSet ? itemWidth : child.Width;

                    child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

                    var height = child.DesiredSize.Height;
                    var width = child.DesiredSize.Width;

                    if (y + height > constraint.Height)
                    {
                        x += (width + HorizontalSpacing);
                        y = 0;
                    }

                    if (!IsLoaded)
                    {
                        child.Arrange(new Rect(x, y, width, height));
                        child.RenderTransformOrigin = new Point(0, 0);
                        child.RenderTransform = new TranslateTransform() { X = 0, Y = 0 };
                        SetPosition(child, new Point(x, y));
                    }
                    else
                    {
                        if (!(child.RenderTransform is TranslateTransform))
                        {
                            child.Arrange(new Rect(x, y, width, height));
                            child.RenderTransformOrigin = new Point(0, 0);
                            child.RenderTransform = new TranslateTransform() { X = 0, Y = 0 };
                            SetPosition(child, new Point(x, y));
                        }
                        else
                        {
                            var point = GetPosition(child);
                            child.Arrange(new Rect(point.X, point.Y, width, height));
                            AnimateArrange(child, x - point.X, y - point.Y);
                        }
                    }

                    y += (height + VerticalSpacing);
                }
                panelDesiredSize = new Size(x + (itemWidthSet ? itemWidth : 0), constraint.Height);
            }


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
