using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public static class ProgressBarHelper
    {
        #region Properties

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
            DependencyProperty.RegisterAttached("ProgressBarStyle", typeof(ProgressBarStyle), typeof(ProgressBarHelper));
        #endregion

        #region ProgressDirection
        public static ProgressDirection GetProgressDirection(DependencyObject obj)
        {
            return (ProgressDirection)obj.GetValue(ProgressDirectionProperty);
        }

        public static void SetProgressDirection(DependencyObject obj, ProgressDirection value)
        {
            obj.SetValue(ProgressDirectionProperty, value);
        }

        public static readonly DependencyProperty ProgressDirectionProperty =
            DependencyProperty.RegisterAttached("ProgressDirection", typeof(ProgressDirection), typeof(ProgressBarHelper));

        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ProgressBarHelper));
        #endregion

        #region IsPercentVisible
        public static bool GetIsPercentVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPercentVisibleProperty);
        }

        public static void SetIsPercentVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPercentVisibleProperty, value);
        }

        public static readonly DependencyProperty IsPercentVisibleProperty =
            DependencyProperty.RegisterAttached("IsPercentVisible", typeof(bool), typeof(ProgressBarHelper));
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

        #endregion

        #region AnimationEase
        public static AnimationEase GetAnimationEase(DependencyObject obj)
        {
            return (AnimationEase)obj.GetValue(AnimationEaseProperty);
        }

        public static void SetAnimationEase(DependencyObject obj, AnimationEase value)
        {
            obj.SetValue(AnimationEaseProperty, value);
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.RegisterAttached("AnimationEase", typeof(AnimationEase), typeof(ProgressBarHelper));
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
            DependencyProperty.RegisterAttached("AnimationDuration", typeof(TimeSpan), typeof(ProgressBarHelper));
        #endregion

        #endregion

        #region Event Handlers
        private static void OnAnimateToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = d as ProgressBar;
            AnimationUtils.BeginAnimation(progressBar, ProgressBar.ValueProperty, (double)e.NewValue, GetAnimationDuration(progressBar), GetAnimationEase(progressBar));
        }
        #endregion
    }
}
