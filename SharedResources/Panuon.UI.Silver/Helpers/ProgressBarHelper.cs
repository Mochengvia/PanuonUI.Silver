using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public static class ProgressBarHelper
    {
        #region Properties

        #region ProgressBarStyle
        public static ProgressBarStyle GetProgressBarStyle(ProgressBar progressBar)
        {
            return (ProgressBarStyle)progressBar.GetValue(ProgressBarStyleProperty);
        }

        public static void SetProgressBarStyle(ProgressBar progressBar, ProgressBarStyle value)
        {
            progressBar.SetValue(ProgressBarStyleProperty, value);
        }

        public static readonly DependencyProperty ProgressBarStyleProperty =
            DependencyProperty.RegisterAttached("ProgressBarStyle", typeof(ProgressBarStyle), typeof(ProgressBarHelper));
        #endregion

        #region Direction
        public static ProgressDirection GetDirection(ProgressBar progressBar)
        {
            return (ProgressDirection)progressBar.GetValue(DirectionProperty);
        }

        public static void SetDirection(ProgressBar progressBar, ProgressDirection value)
        {
            progressBar.SetValue(DirectionProperty, value);
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.RegisterAttached("Direction", typeof(ProgressDirection), typeof(ProgressBarHelper));

        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(ProgressBar progressBar)
        {
            return (CornerRadius)progressBar.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(ProgressBar progressBar, CornerRadius value)
        {
            progressBar.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ProgressBarHelper));
        #endregion

        #region IsPercentVisible
        public static bool GetIsPercentVisible(ProgressBar progressBar)
        {
            return (bool)progressBar.GetValue(IsPercentVisibleProperty);
        }

        public static void SetIsPercentVisible(ProgressBar progressBar, bool value)
        {
            progressBar.SetValue(IsPercentVisibleProperty, value);
        }

        public static readonly DependencyProperty IsPercentVisibleProperty =
            DependencyProperty.RegisterAttached("IsPercentVisible", typeof(bool), typeof(ProgressBarHelper));
        #endregion

        #region PercentStringFormat
        public static string GetPercentStringFormat(ProgressBar progressBar)
        {
            return (string)progressBar.GetValue(PercentStringFormatProperty);
        }

        public static void SetPercentStringFormat(ProgressBar progressBar, string value)
        {
            progressBar.SetValue(PercentStringFormatProperty, value);
        }

        public static readonly DependencyProperty PercentStringFormatProperty =
            DependencyProperty.RegisterAttached("PercentStringFormat", typeof(string), typeof(ProgressBarHelper), new PropertyMetadata("{0:P0}"));
        #endregion

        #region AnimateTo
        public static double GetAnimateTo(ProgressBar progressBar)
        {
            return (double)progressBar.GetValue(AnimateToProperty);
        }

        public static void SetAnimateTo(ProgressBar progressBar, double value)
        {
            progressBar.SetValue(AnimateToProperty, value);
        }

        public static readonly DependencyProperty AnimateToProperty =
            DependencyProperty.RegisterAttached("AnimateTo", typeof(double), typeof(ProgressBarHelper), new PropertyMetadata(OnAnimateToChanged));

        #endregion

        #region AnimationEase
        public static AnimationEase GetAnimationEase(ProgressBar progressBar)
        {
            return (AnimationEase)progressBar.GetValue(AnimationEaseProperty);
        }

        public static void SetAnimationEase(ProgressBar progressBar, AnimationEase value)
        {
            progressBar.SetValue(AnimationEaseProperty, value);
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.RegisterAttached("AnimationEase", typeof(AnimationEase), typeof(ProgressBarHelper));
        #endregion

        #region AnimationDuration
        public static TimeSpan GetAnimationDuration(ProgressBar progressBar)
        {
            return (TimeSpan)progressBar.GetValue(AnimationDurationProperty);
        }

        public static void SetAnimationDuration(ProgressBar progressBar, TimeSpan value)
        {
            progressBar.SetValue(AnimationDurationProperty, value);
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.RegisterAttached("AnimationDuration", typeof(TimeSpan), typeof(ProgressBarHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region IndeterminatePercent
        internal static double GetIndeterminatePercent(DependencyObject obj)
        {
            return (double)obj.GetValue(IndeterminatePercentProperty);
        }

        internal static void SetIndeterminatePercent(DependencyObject obj, double value)
        {
            obj.SetValue(IndeterminatePercentProperty, value);
        }

        internal static readonly DependencyProperty IndeterminatePercentProperty =
            DependencyProperty.RegisterAttached("IndeterminatePercent", typeof(double), typeof(ProgressBarHelper), new PropertyMetadata(0.0));
        #endregion

        #endregion

        #region Event Handlers
        private static void OnAnimateToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = d as ProgressBar;
            if(progressBar.Value == (double)e.NewValue)
            {
                return;
            }
            AnimationUtils.BeginAnimation(progressBar, ProgressBar.ValueProperty, (double)e.NewValue, GetAnimationDuration(progressBar), GetAnimationEase(progressBar));
        }
        #endregion
    }
}
