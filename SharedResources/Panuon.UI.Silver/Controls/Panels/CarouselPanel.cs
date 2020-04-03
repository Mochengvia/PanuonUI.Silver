using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class CarouselPanel : Panel
    {
        #region Ctor
        public CarouselPanel()
            : base()
        {
            ClipToBounds = true;
            Loaded += CarouselPanel_Loaded;
        }

       
        #endregion

        #region Properties

        #region CurrentIndex


        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(CarouselPanel), new PropertyMetadata(1, OnCurrentIndexChanged, OnCurrentIndexCoerceValue));


        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(CarouselPanel), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(CarouselPanel), new PropertyMetadata(AnimationEase.CubicOut));
        #endregion

        #region Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(CarouselPanel), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #endregion

        #region Internal Properties

        #region PositionOffset

        internal Rect PositionOffset
        {
            get { return (Rect)GetValue(PositionOffsetProperty); }
            set { SetValue(PositionOffsetProperty, value); }
        }

        internal static readonly DependencyProperty PositionOffsetProperty =
            DependencyProperty.Register("PositionOffset", typeof(Rect), typeof(CarouselPanel), new FrameworkPropertyMetadata(new Rect(), FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #endregion

        #region Routed Event
        private void CarouselPanel_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateChildren(false);
        }

        private static object OnCurrentIndexCoerceValue(DependencyObject d, object baseValue)
        {
            var carousel = d as CarouselPanel;
            var index = (int)baseValue;
            if(index < 1)
            {
                index = 1;
            }
            else
            {
                if(carousel.InternalChildren.Count > 1 && index > carousel.InternalChildren.Count)
                {
                    index = carousel.InternalChildren.Count;
                }
            }
            return index;
        }

        private static void OnCurrentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var carousel = d as CarouselPanel;
            if (carousel.IsLoaded)
            {
                carousel.UpdateChildren(true);
            }
        }
        #endregion

        #region Override

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }
            UpdateChildren(true);
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            for (int i = 0, count = InternalChildren.Count; i < count; ++i)
            {
                UIElement child = InternalChildren[i];
                var bounds = new Rect(0, 0, finalSize.Width, finalSize.Height);
                if(Orientation == Orientation.Horizontal)
                {
                    bounds.X = i * finalSize.Width - PositionOffset.X;
                }
                else
                {
                    bounds.Y = i * finalSize.Height - PositionOffset.Y;
                }
                child.Arrange(bounds);
            }
            return finalSize;
        }

        #endregion

        #region Methods
        public void Next()
        {
            CurrentIndex++;
        }

        public void Previous()
        {
            CurrentIndex--;
        }
        #endregion

        #region Function
        private void UpdateChildren(bool useAnimation)
        {
            var targetX = (CurrentIndex - 1) * DesiredSize.Width;
            var targetY = (CurrentIndex - 1) * DesiredSize.Height;
            var targetPositionOffset = new Rect(targetX, targetY, 0, 0);

            if (!IsLoaded || !useAnimation || AnimationDuration.TotalMilliseconds == 0)
            {
                PositionOffset = targetPositionOffset;
            }
            else
            {
                var animation = new RectAnimation()
                {
                    To = targetPositionOffset,
                    Duration = AnimationDuration,
                    EasingFunction = AnimationUtils.CreateEasingFunction(AnimationEase),
                };
                BeginAnimation(PositionOffsetProperty, animation);
            }
        }
        #endregion

    }
}
