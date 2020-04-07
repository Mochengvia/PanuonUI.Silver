using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class AnimationStackPanel : Panel
    {

        #region Ctor
        #endregion

        #region Properties

        #region Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(AnimationStackPanel), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(AnimationStackPanel), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(AnimationStackPanel), new PropertyMetadata(AnimationEase.CubicOut));
        #endregion

        #region Direction
        public StackDirection Direction
        {
            get { return (StackDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(StackDirection), typeof(AnimationStackPanel));
        #endregion

        #endregion

        #region Internal Properties

        #region TargetOffset
        internal static double GetTargetOffset(DependencyObject obj)
        {
            return (double)obj.GetValue(TargetOffsetProperty);
        }

        internal static void SetOffset(DependencyObject obj, double value)
        {
            obj.SetValue(TargetOffsetProperty, value);
        }

        internal static readonly DependencyProperty TargetOffsetProperty =
            DependencyProperty.RegisterAttached("TargetOffset", typeof(double), typeof(AnimationStackPanel));
        #endregion

        #region LastOffset
        public static double GetLastOffset(DependencyObject obj)
        {
            return (double)obj.GetValue(LastOffsetProperty);
        }

        public static void SetLastOffset(DependencyObject obj, double value)
        {
            obj.SetValue(LastOffsetProperty, value);
        }

        public static readonly DependencyProperty LastOffsetProperty =
            DependencyProperty.RegisterAttached("LastOffset", typeof(double), typeof(AnimationStackPanel), new PropertyMetadata(double.NaN));
        #endregion

        #region CurrentOffset
        public static double GetCurrentOffset(DependencyObject obj)
        {
            return (double)obj.GetValue(CurrentOffsetProperty);
        }

        public static void SetCurrentOffset(DependencyObject obj, double value)
        {
            obj.SetValue(CurrentOffsetProperty, value);
        }

        public static readonly DependencyProperty CurrentOffsetProperty =
            DependencyProperty.RegisterAttached("CurrentOffset", typeof(double), typeof(AnimationStackPanel), new PropertyMetadata(double.NaN));
        #endregion

        #region Percent
        internal double Percent
        {
            get { return (double)GetValue(PercentProperty); }
            set { SetValue(PercentProperty, value); }
        }

        internal static readonly DependencyProperty PercentProperty =
            DependencyProperty.Register("Percent", typeof(double), typeof(AnimationStackPanel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion


        #endregion

        #region Event Handlers
        protected override Size MeasureOverride(Size availableSize)
        {
            if (InternalChildren.Count == 0)
            {
                return availableSize;
            }

            var offset = Direction == StackDirection.Normal
                ? 0.0 : (Orientation == Orientation.Vertical
                    ? availableSize.Height : availableSize.Width);

            for (int i = 0; i < InternalChildren.Count; i++)
            {
                UIElement child = InternalChildren[i];
                child.Measure(availableSize);
                if (i == 0 && Direction == StackDirection.Reverse)
                {
                    offset -= Orientation == Orientation.Vertical
                        ? child.DesiredSize.Height : child.DesiredSize.Width;
                }
                SetOffset(child, offset);
                if (Orientation == Orientation.Vertical)
                {
                    offset = Direction == StackDirection.Normal
                        ? (offset + child.DesiredSize.Height) : (offset - child.DesiredSize.Height);
                }
                else
                {
                    offset = Direction == StackDirection.Normal
                        ? (offset + child.DesiredSize.Width) : (offset - child.DesiredSize.Width);
                }
            }
            if (IsLoaded)
            {
                BeginArrangeAnimation();
            }
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                var offset = GetTargetOffset(child);
                if (!IsLoaded || Percent == 100)
                {
                    SetLastOffset(child, offset);
                }
                else
                {
                    var lastOffset = GetLastOffset(child);
                    if (IsLoaded && double.IsNaN(lastOffset))
                    {
                        lastOffset = offset;
                    }
                    offset = Percent == 0 ? lastOffset : (lastOffset + (offset - lastOffset) * Percent / 100.0);
                }
                SetCurrentOffset(child, offset);

                if (Orientation == Orientation.Vertical)
                {
                    child.Arrange(new Rect(0, offset, finalSize.Width, child.DesiredSize.Height));
                }
                else
                {
                    child.Arrange(new Rect(offset, 0, child.DesiredSize.Width, finalSize.Height));
                }
            }

            return finalSize;
        }

        #endregion

        #region Function
        private void BeginArrangeAnimation()
        {
            BeginAnimation(PercentProperty, null);
            foreach(UIElement child in InternalChildren)
            {
                var currentOffset = GetCurrentOffset(child);
                if (!double.IsNaN(currentOffset))
                {
                    SetLastOffset(child, GetCurrentOffset(child));
                }
            }
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = 100,
                Duration = AnimationDuration,
                EasingFunction = AnimationUtils.CreateEasingFunction(AnimationEase),
            };
            BeginAnimation(PercentProperty, animation);
        }
        #endregion
    }
}
