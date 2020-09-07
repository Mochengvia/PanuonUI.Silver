using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Core
{
    public class BrushAnimation : AnimationTimeline
    {
        #region Properties
        public Brush From
        {
            get { return (Brush)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(Brush), typeof(BrushAnimation));

        public Brush To
        {
            get { return (Brush)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(Brush), typeof(BrushAnimation));

        #endregion

        #region Override
        public override Type TargetPropertyType => typeof(Brush);

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationTimeSelector)
        {
            return GetCurrentValue(defaultOriginValue as Brush, defaultDestinationValue as Brush, animationTimeSelector);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new BrushAnimation();
        }

        public object GetCurrentValue(Brush defaultOriginValue, Brush defaultDestinationValue, AnimationClock animationTimeSelector)
        {
            if (!animationTimeSelector.CurrentProgress.HasValue)
                return Brushes.Transparent;

            defaultOriginValue = this.From ?? defaultOriginValue;
            defaultDestinationValue = this.To ?? defaultDestinationValue;

            if (animationTimeSelector.CurrentProgress.Value == 0)
                return defaultOriginValue;
            if (animationTimeSelector.CurrentProgress.Value == 1)
                return defaultDestinationValue;

            if (To != null)
            {
                if (defaultDestinationValue is SolidColorBrush && ((SolidColorBrush)defaultDestinationValue).Color.A < 255
                    && (!(defaultOriginValue is SolidColorBrush) || (((SolidColorBrush)defaultOriginValue).Color.A == 255)))
                {
                    return BrushUtils.GetSuperposedVisualBrush(defaultDestinationValue, defaultOriginValue, 1 - animationTimeSelector.CurrentProgress.Value);
                }
                else
                {
                    return BrushUtils.GetSuperposedVisualBrush(defaultOriginValue, defaultDestinationValue, animationTimeSelector.CurrentProgress.Value);
                }
            }
            else
            {
                if (defaultOriginValue is SolidColorBrush && ((SolidColorBrush)defaultOriginValue).Color.A < 255
                    && (!(defaultDestinationValue is SolidColorBrush) || (((SolidColorBrush)defaultDestinationValue).Color.A == 255)))
                {
                    return BrushUtils.GetSuperposedVisualBrush(defaultOriginValue, defaultDestinationValue, animationTimeSelector.CurrentProgress.Value);
                }
                else
                {
                    return BrushUtils.GetSuperposedVisualBrush(defaultDestinationValue, defaultOriginValue, 1 - animationTimeSelector.CurrentProgress.Value);
                }
            }
        }
        #endregion
    }
}
