using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class UIElementUtils
    {
        #region Methods

        #region CreateEasingFunction
        public static IEasingFunction CreateEasingFunction(AnimationEase animationEasing)
        {
            switch (animationEasing)
            {
                case AnimationEase.BackIn:
                    return new BackEase() { EasingMode = EasingMode.EaseIn };
                case AnimationEase.BackOut:
                    return new BackEase() { EasingMode = EasingMode.EaseOut };
                case AnimationEase.BackInOut:
                    return new BackEase() { EasingMode = EasingMode.EaseInOut };
                case AnimationEase.CircleIn:
                    return new CircleEase() { EasingMode = EasingMode.EaseIn };
                case AnimationEase.CircleOut:
                    return new CircleEase() { EasingMode = EasingMode.EaseOut };
                case AnimationEase.CircleInOut:
                    return new CircleEase() { EasingMode = EasingMode.EaseInOut };
                case AnimationEase.CubicIn:
                    return new CubicEase() { EasingMode = EasingMode.EaseIn };
                case AnimationEase.CubicOut:
                    return new CubicEase() { EasingMode = EasingMode.EaseOut };
                case AnimationEase.CubicInOut:
                    return new CubicEase() { EasingMode = EasingMode.EaseInOut };
                case AnimationEase.PowerIn:
                    return new PowerEase() { EasingMode = EasingMode.EaseIn };
                case AnimationEase.PowerOut:
                    return new PowerEase() { EasingMode = EasingMode.EaseOut };
                case AnimationEase.PowerInOut:
                    return new PowerEase() { EasingMode = EasingMode.EaseInOut };
                case AnimationEase.QuadraticIn:
                    return new QuadraticEase() { EasingMode = EasingMode.EaseIn };
                case AnimationEase.QuadraticOut:
                    return new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                case AnimationEase.QuadraticInOut:
                    return new QuadraticEase() { EasingMode = EasingMode.EaseInOut };
            }
            return null;
        }
        #endregion

        #region BeginAnimation
        public static void BeginAnimation(IAnimatable animatable, DependencyProperty dependencyProperty, double to, TimeSpan animationDuration, AnimationEase animationEase = AnimationEase.None, bool repeatForever = false,Action callback = null)
        {
            var animation = new DoubleAnimation()
            {
                To = to,
                Duration = animationDuration,
                EasingFunction = CreateEasingFunction(animationEase),
            };
            animation.Completed += delegate
            {
                callback?.Invoke();
            };
            BeginAnimation(animatable, dependencyProperty, animation, repeatForever);
        }

        public static void BeginAnimation(IAnimatable animatable, DependencyProperty dependencyProperty, double from, double to, TimeSpan animationDuration, AnimationEase animationEase = AnimationEase.None, bool repeatForever = false, Action callback = null)
        {
            var animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = animationDuration,
                EasingFunction = CreateEasingFunction(animationEase),
            };
            animation.Completed += delegate
            {
                callback?.Invoke();
            };
            BeginAnimation(animatable, dependencyProperty, animation, repeatForever);
        }
        #endregion

        #region BeginAnimation
        public static void BeginAnimation(IAnimatable animatable, DependencyProperty dependencyProperty, Thickness to, TimeSpan animationDuration, AnimationEase animationEase = AnimationEase.None, bool repeatForever = false, Action callback = null)
        {
            var animation = new ThicknessAnimation()
            {
                To = to,
                Duration = animationDuration,
                EasingFunction = CreateEasingFunction(animationEase),
            };
            animation.Completed += delegate
            {
                callback?.Invoke();
            };
            BeginAnimation(animatable, dependencyProperty, animation, repeatForever);
        }

        public static void BeginAnimation(IAnimatable animatable, DependencyProperty dependencyProperty, Thickness from, Thickness to, TimeSpan animationDuration, AnimationEase animationEase = AnimationEase.None, bool repeatForever = false, Action callback = null)
        {
            var animation = new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = animationDuration,
                EasingFunction = CreateEasingFunction(animationEase),
            };
            animation.Completed += delegate
            {
                callback?.Invoke();
            };
            BeginAnimation(animatable, dependencyProperty, animation, repeatForever);
        }
        #endregion

        #region BeginStoryboard
        public static void BeginStoryboard(DependencyObject dependencyObj, IDictionary<DependencyProperty, Brush> toDictionary)
        {
            var storyboard = new Storyboard();
            foreach (var keyValue in toDictionary)
            {
                var anima = new BrushAnimation()
                {
                    To = keyValue.Value,
                    Duration = TimeSpan.FromSeconds(0.3),
                };
                Storyboard.SetTarget(anima, dependencyObj);
                Storyboard.SetTargetProperty(anima, new PropertyPath(keyValue.Key));
                storyboard.Children.Add(anima);
            }
            storyboard.Begin();
        }

        public static void BeginStoryboard(DependencyObject dependencyObj, IList<DependencyProperty> dpList)
        {
            var storyboard = new Storyboard();
            foreach (var dp in dpList)
            {
                var anima = new BrushAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.3),
                };
                Storyboard.SetTarget(anima, dependencyObj);
                Storyboard.SetTargetProperty(anima, new PropertyPath(dp));
                storyboard.Children.Add(anima);
            }
            storyboard.Begin();
        }

        #endregion

        #region GetVisualChild
        public static T GetVisualChild<T>(DependencyObject parent) where T : FrameworkElement
        {
            var child = default(T);
            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var element = (FrameworkElement)VisualTreeHelper.GetChild(parent, i);
                child = element as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(element);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        #endregion

     
        #region CreateAnimation
        public static ThicknessAnimation CreateAnimation(Thickness? from, Thickness? to, TimeSpan beginTime, TimeSpan duration, AnimationEase animationEase)
        {
            return new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = duration,
                BeginTime = beginTime,
                EasingFunction = CreateEasingFunction(animationEase),
            };
        }

        public static DoubleAnimation CreateAnimation(double? from, double? to, TimeSpan beginTime, TimeSpan duration, AnimationEase animationEase)
        {
            return new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = duration,
                BeginTime = beginTime,
                EasingFunction = CreateEasingFunction(animationEase),
            };
        }
        #endregion

        #region IsDefaultPropertyValue
        #endregion

        #endregion

        #region Function
        private static void BeginAnimation(IAnimatable animatable, DependencyProperty dependencyProperty, AnimationTimeline animation , bool repeatForever)
        {
            if (repeatForever)
            {
                animation.RepeatBehavior = RepeatBehavior.Forever;
            }
            animatable.BeginAnimation(dependencyProperty, animation);
        }

  
        #endregion
    }
}
