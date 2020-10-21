using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class StickyPanel : Panel
    {
        #region Ctor
        static StickyPanel()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(StickyPanel), new PropertyMetadata(true));
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
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(StickyPanel), new PropertyMetadata(-1, OnCurrentIndexChanged, CoerceCurrentIndex));

        #endregion

        #region StickyAnimation
        public StickyAnimation Animation
        {
            get { return (StickyAnimation)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly DependencyProperty AnimationProperty =
            DependencyProperty.Register("Animation", typeof(StickyAnimation), typeof(StickyPanel));
        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(StickyPanel), new PropertyMetadata(TimeSpan.FromSeconds(0.3)));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(StickyPanel), new PropertyMetadata(AnimationEase.CubicOut));
        #endregion

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

        #region Overrides
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                var bounds = new Rect(0, 0, finalSize.Width, finalSize.Height);
                child.Arrange(bounds);
            }
            return finalSize;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            CoerceValue(CurrentIndexProperty);

            for (int i = 0; i < Children.Count; i++)
            {
                if (i == CurrentIndex)
                {
                    continue;
                }
                else
                {
                    Children[i].IsHitTestVisible = false;
                    Children[i].Opacity = 0;
                }
            }
        }
        #endregion

        #region Event Handlers
        private static object CoerceCurrentIndex(DependencyObject d, object baseValue)
        {
            var winkPanel = d as StickyPanel;
            var currentIndex = baseValue as int? ?? 0;
            if (currentIndex > winkPanel.Children.Count - 1)
            {
                currentIndex = winkPanel.Children.Count - 1;
            }
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }
            return currentIndex;
        }

        private static void OnCurrentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var winkPanel = d as StickyPanel;
            var oldIndex = (int)e.OldValue;
            var newIndex = (int)e.NewValue;
            winkPanel.Tore(oldIndex, newIndex, winkPanel.IsLoaded);
        }
        #endregion

        #region Functions
        private void Tore(int oldIndex, int newIndex, bool useAnimate)
        {
            if (!IsInitialized)
            {
                return;
            }
            var totalCount = Children.Count;
            if (oldIndex < 0 || newIndex < 0 || oldIndex > totalCount || newIndex > totalCount)
            {
                return;
            }
            var isUpward = newIndex > oldIndex;

            var oldChild = Children[oldIndex];
            var newChild = Children[newIndex];

            newChild.Opacity = 0;
            newChild.IsHitTestVisible = true;
            oldChild.RenderTransformOrigin = new Point(0.5, 0.5);
            newChild.RenderTransformOrigin = new Point(0.5, 0.5);

            switch (Animation)
            {
                case StickyAnimation.Scale:
                    var oldScale = new ScaleTransform() { ScaleX = 1, ScaleY = 1 };
                    var newScale = new ScaleTransform() { ScaleX = isUpward ? 1.5 : 0.75, ScaleY = isUpward ? 1.5 : 0.75 };

                    oldChild.RenderTransform = oldScale;
                    oldChild.IsHitTestVisible = false;
                    newChild.RenderTransform = newScale;

                    UIElementUtils.BeginAnimation(oldScale, ScaleTransform.ScaleXProperty, isUpward ? 0.75 : 1.5, AnimationDuration, AnimationEase);
                    UIElementUtils.BeginAnimation(oldScale, ScaleTransform.ScaleYProperty, isUpward ? 0.75 : 1.5, AnimationDuration, AnimationEase);
                    UIElementUtils.BeginAnimation(oldChild, OpacityProperty, 0, AnimationDuration, AnimationEase);
                    UIElementUtils.BeginAnimation(newScale, ScaleTransform.ScaleXProperty, 1, AnimationDuration, AnimationEase);
                    UIElementUtils.BeginAnimation(newScale, ScaleTransform.ScaleYProperty, 1, AnimationDuration, AnimationEase);
                    UIElementUtils.BeginAnimation(newChild, OpacityProperty, 1, AnimationDuration, AnimationEase);
                    break;
                case StickyAnimation.Slide:
                    if (isUpward)
                    {
                        var oldTranslate = new TranslateTransform() { X = 0 };
                        oldChild.RenderTransform = oldTranslate;
                        UIElementUtils.BeginAnimation(oldTranslate, TranslateTransform.XProperty, -ActualWidth, AnimationDuration, AnimationEase);
                        UIElementUtils.BeginAnimation(newChild, OpacityProperty, 1, AnimationDuration, AnimationEase);
                    }
                    else
                    {
                        var newTranslate = new TranslateTransform() { X = -ActualWidth };
                        newChild.RenderTransform = newTranslate;
                        oldChild.IsHitTestVisible = false;
                        UIElementUtils.BeginAnimation(newTranslate, TranslateTransform.XProperty, 0, AnimationDuration, AnimationEase);
                        UIElementUtils.BeginAnimation(newChild, OpacityProperty, 1, AnimationDuration, AnimationEase);
                        UIElementUtils.BeginAnimation(oldChild, OpacityProperty, 0, AnimationDuration, AnimationEase);
                    }
                    break;
            }

        }
        #endregion
    }
}
