using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class ProgressBarHelper
    {
        #region ProgressBarStyle
        public static ProgressBarStyle GetProgressBarStyle(DependencyObject obj)
        {
            return (ProgressBarStyle)obj.GetValue(ProgressBarStyleProperty);
        }

        public static void SetProgressBarStyle(DependencyObject obj, ProgressBarStyle value)
        {
            obj.SetValue(ProgressBarStyleProperty, value);
        }

        public static readonly DependencyProperty ProgressBarStyleProperty =
            DependencyProperty.RegisterAttached("ProgressBarStyle", typeof(ProgressBarStyle), typeof(ProgressBarHelper), new PropertyMetadata(ProgressBarStyle.Standard));
        #endregion

        #region CornerRadius
        public static double GetCornerRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, double value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(double), typeof(ProgressBarHelper));

        #endregion

        #region AnimateTo
        public static double GetAnimateTo(DependencyObject obj)
        {
            return (double)obj.GetValue(AnimateToProperty);
        }

        public static void SetAnimateTo(DependencyObject obj, double value)
        {
            obj.SetValue(AnimateToProperty, value);
        }

        public static readonly DependencyProperty AnimateToProperty =
            DependencyProperty.RegisterAttached("AnimateTo", typeof(double), typeof(ProgressBarHelper), new PropertyMetadata(OnAnimateToChanged));

        private static void OnAnimateToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var value = (double)e.NewValue;
            var progressBar = d as ProgressBar;
            var anima = new DoubleAnimation()
            {
                To = value,
                Duration = GetAnimationDuration(progressBar),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
            };
            progressBar.BeginAnimation(ProgressBar.ValueProperty, anima);
        }
        #endregion

        #region AnimationDuration
        public static TimeSpan GetAnimationDuration(DependencyObject obj)
        {
            return (TimeSpan)obj.GetValue(AnimationDurationProperty);
        }

        public static void SetAnimationDuration(DependencyObject obj, TimeSpan value)
        {
            obj.SetValue(AnimationDurationProperty, value);
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.RegisterAttached("AnimationDuration", typeof(TimeSpan), typeof(ProgressBarHelper), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));


        #endregion
    }
}
