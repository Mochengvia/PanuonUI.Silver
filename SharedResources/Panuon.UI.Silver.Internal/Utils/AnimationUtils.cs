using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal class AnimationUtils
    {
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

        public static void BeginAnimation(UIElement uiElement, DependencyProperty dependencyProperty, double to, TimeSpan animationDuration, AnimationEase animationEase = AnimationEase.None, bool repeatForever = false)
        {
            var anima = new DoubleAnimation()
            {
                To = to,
                Duration = animationDuration,
                EasingFunction = CreateEasingFunction(animationEase),
            };
            if (repeatForever)
            {
                anima.RepeatBehavior = RepeatBehavior.Forever;
            }
            uiElement.BeginAnimation(dependencyProperty, anima);
        }

        public static void BeginAnimation(UIElement uiElement, DependencyProperty dependencyProperty, double from, double to, TimeSpan animationDuration, AnimationEase animationEase = AnimationEase.None, bool repeatForever = false)
        {
            var anima = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = animationDuration,
                EasingFunction = CreateEasingFunction(animationEase),
            };
            if (repeatForever)
            {
                anima.RepeatBehavior = RepeatBehavior.Forever;
            }
            uiElement.BeginAnimation(dependencyProperty, anima);
        }
    }
}
