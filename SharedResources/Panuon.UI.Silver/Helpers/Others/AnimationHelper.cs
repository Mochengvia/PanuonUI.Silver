using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class AnimationHelper
    {
        #region FadeIn
        /// <summary>
        /// 使控件立即进行透明度从0至1的渐变动画。若控件尚未加载完成，则将在其加载完成后再执行动画。
        /// </summary>
        public static readonly DependencyProperty FadeInProperty =
            DependencyProperty.RegisterAttached("FadeIn", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnFadeInChanged));

        public static bool GetFadeIn(DependencyObject obj)
        {
            return (bool)obj.GetValue(FadeInProperty);
        }

        public static void SetFadeIn(DependencyObject obj, bool value)
        {
            obj.SetValue(FadeInProperty, value);
        }

        private static void OnFadeInChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            if (element == null)
                return;
            element.Opacity = 0;

            if (element.IsLoaded)
                element.BeginAnimation(FrameworkElement.OpacityProperty, GetDoubleAnimation(1, element));
            else
            {
                element.Loaded += delegate
                {
                    element.BeginAnimation(FrameworkElement.OpacityProperty, GetDoubleAnimation(1, element));
                };
            }
            SetFadeIn(element, false);
        }
        #endregion

        #region FadeOut
        public static bool GetFadeOut(DependencyObject obj)
        {
            return (bool)obj.GetValue(FadeOutProperty);
        }

        public static void SetFadeOut(DependencyObject obj, bool value)
        {
            obj.SetValue(FadeOutProperty, value);
        }

        public static readonly DependencyProperty FadeOutProperty =
            DependencyProperty.RegisterAttached("FadeOut", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnFadeOutChanged));

        private static void OnFadeOutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            if (element == null)
                return;

            if (element.IsLoaded)
                element.BeginAnimation(FrameworkElement.OpacityProperty, GetDoubleAnimation(0, element));
            else
            {
                element.Loaded += delegate
                {
                    element.BeginAnimation(FrameworkElement.OpacityProperty, GetDoubleAnimation(0, element));
                };
            }
            SetFadeOut(element, false);
        }
        #endregion

        #region SlideIn
        /// <summary>
        /// 使控件立即进行从相对右侧偏移20px的位置，移动至当前位置的渐变动画。若控件尚未加载完成，则将在其加载完成后再执行动画。
        /// </summary>
        public static readonly DependencyProperty SlideInFromRightProperty =
            DependencyProperty.RegisterAttached("SlideInFromRight", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnSlideInFromRightChanged));

        public static bool GetSlideInFromRight(DependencyObject obj)
        {
            return (bool)obj.GetValue(SlideInFromRightProperty);
        }

        public static void SetSlideInFromRight(DependencyObject obj, bool value)
        {
            obj.SetValue(SlideInFromRightProperty, value);
        }

        private static void OnSlideInFromRightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            if (element == null)
                return;

            var transform = new TranslateTransform()
            {
                X = 20,
            };
            if (element.RenderTransform != null)
            {
                if (element.RenderTransform.GetType() == typeof(TransformGroup))
                {
                    ((TransformGroup)element.RenderTransform).Children.Add(transform);
                }
                else if (element.RenderTransform.GetType() == typeof(Transform))
                {
                    var group = new TransformGroup();
                    group.Children.Add(element.RenderTransform);
                    group.Children.Add(transform);
                }
                else
                {
                    element.RenderTransform = transform;
                }
            }
            else
            {
                element.RenderTransform = transform;
            }

            if (element.IsLoaded)
                transform.BeginAnimation(TranslateTransform.XProperty, GetDoubleAnimation(0, element));
            else
            {
                element.Loaded += delegate
                {
                    transform.BeginAnimation(TranslateTransform.XProperty, GetDoubleAnimation(0, element));
                };
            }
        }

        /// <summary>
        /// 使控件立即进行从相对左侧偏移20px的位置，移动至当前位置的渐变动画。若控件尚未加载完成，则将在其加载完成后再执行动画。
        /// </summary>
        public static readonly DependencyProperty SlideInFromLeftProperty =
            DependencyProperty.RegisterAttached("SlideInFromLeft", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnSlideInFromLeftChanged));

        public static bool GetSlideInFromLeft(DependencyObject obj)
        {
            return (bool)obj.GetValue(SlideInFromLeftProperty);
        }

        public static void SetSlideInFromLeft(DependencyObject obj, bool value)
        {
            obj.SetValue(SlideInFromLeftProperty, value);
        }

        private static void OnSlideInFromLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            if (element == null)
                return;

            var transform = new TranslateTransform()
            {
                X = -20,
            };
            if (element.RenderTransform != null)
            {
                if (element.RenderTransform.GetType() == typeof(TransformGroup))
                {
                    ((TransformGroup)element.RenderTransform).Children.Add(transform);
                }
                else if (element.RenderTransform.GetType() == typeof(Transform))
                {
                    var group = new TransformGroup();
                    group.Children.Add(element.RenderTransform);
                    group.Children.Add(transform);
                }
                else
                {
                    element.RenderTransform = transform;
                }
            }
            else
            {
                element.RenderTransform = transform;
            }

            if (element.IsLoaded)
                transform.BeginAnimation(TranslateTransform.XProperty, GetDoubleAnimation(0, element));
            else
            {
                element.Loaded += delegate
                {
                    transform.BeginAnimation(TranslateTransform.XProperty, GetDoubleAnimation(0, element));
                };
            }
            SetSlideInFromLeft(element, false);
        }

        /// <summary>
        /// 使控件立即进行从相对顶部偏移20px的位置，移动至当前位置的渐变动画。若控件尚未加载完成，则将在其加载完成后再执行动画。
        /// </summary>
        public static readonly DependencyProperty SlideInFromTopProperty =
            DependencyProperty.RegisterAttached("SlideInFromTop", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnSlideInFromTopChanged));

        public static bool GetSlideInFromTop(DependencyObject obj)
        {
            return (bool)obj.GetValue(SlideInFromTopProperty);
        }

        public static void SetSlideInFromTop(DependencyObject obj, bool value)
        {
            obj.SetValue(SlideInFromTopProperty, value);
        }

        private static void OnSlideInFromTopChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            if (element == null)
                return;

            var transform = new TranslateTransform()
            {
                Y = -20,
            };
            if (element.RenderTransform != null)
            {
                if (element.RenderTransform.GetType() == typeof(TransformGroup))
                {
                    ((TransformGroup)element.RenderTransform).Children.Add(transform);
                }
                else if (element.RenderTransform.GetType() == typeof(Transform))
                {
                    var group = new TransformGroup();
                    group.Children.Add(element.RenderTransform);
                    group.Children.Add(transform);
                }
                else
                {
                    element.RenderTransform = transform;
                }
            }
            else
            {
                element.RenderTransform = transform;
            }

            if (element.IsLoaded)
                transform.BeginAnimation(TranslateTransform.YProperty, GetDoubleAnimation(0, element));
            else
            {
                element.Loaded += delegate
                {
                    transform.BeginAnimation(TranslateTransform.YProperty, GetDoubleAnimation(0, element));
                };
            }
            SetSlideInFromTop(element, false);
        }


        /// <summary>
        /// 使控件立即进行从相对底部偏移20px的位置，移动至当前位置的渐变动画。若控件尚未加载完成，则将在其加载完成后再执行动画。
        /// </summary>
        public static readonly DependencyProperty SlideInFromBottomProperty =
            DependencyProperty.RegisterAttached("SlideInFromBottom", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnSlideInFromBottomChanged));

        public static bool GetSlideInFromBottom(DependencyObject obj)
        {
            return (bool)obj.GetValue(SlideInFromBottomProperty);
        }

        public static void SetSlideInFromBottom(DependencyObject obj, bool value)
        {
            obj.SetValue(SlideInFromBottomProperty, value);
        }

        private static void OnSlideInFromBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            if (element == null)
                return;

            var transform = new TranslateTransform()
            {
                Y = 20,
            };
            if (element.RenderTransform != null)
            {
                if (element.RenderTransform.GetType() == typeof(TransformGroup))
                {
                    ((TransformGroup)element.RenderTransform).Children.Add(transform);
                }
                else if (element.RenderTransform.GetType() == typeof(Transform))
                {
                    var group = new TransformGroup();
                    group.Children.Add(element.RenderTransform);
                    group.Children.Add(transform);
                }
                else
                {
                    element.RenderTransform = transform;
                }
            }
            else
            {
                element.RenderTransform = transform;
            }

            if (element.IsLoaded)
                transform.BeginAnimation(TranslateTransform.YProperty, GetDoubleAnimation(0, element));
            else
            {
                element.Loaded += delegate
                {
                    transform.BeginAnimation(TranslateTransform.YProperty, GetDoubleAnimation(0, element));
                };
            }
            SetSlideInFromBottom(element, false);
        }
        #endregion

        #region GradualIn
        public static bool GetGradualIn(DependencyObject obj)
        {
            return (bool)obj.GetValue(GradualInProperty);
        }

        public static void SetGradualIn(DependencyObject obj, bool value)
        {
            obj.SetValue(GradualInProperty, value);
        }

        public static readonly DependencyProperty GradualInProperty =
            DependencyProperty.RegisterAttached("GradualIn", typeof(bool), typeof(AnimationHelper), new PropertyMetadata(OnGradualInChanged));

        private static void OnGradualInChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue as bool? != true)
                return;

            var element = d as FrameworkElement;
            var collection = new GradientStopCollection();

            var stop1 = new GradientStop() { Offset = 0, Color = Colors.White };
            var stop2 = new GradientStop() { Offset = 0, Color = Colors.Transparent };

            collection.Add(stop1);
            collection.Add(stop2);

            var brush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1),
                GradientStops = collection,
            };

            element.OpacityMask = brush;

            if (element.IsLoaded)
            {
                var duration = GetDurationSeconds(element);
                var beginSeconds = GetBeginTimeSeconds(element);
                var easingFunction = GetEasingFunction(element);

                stop2.BeginAnimation(GradientStop.OffsetProperty, GetDoubleAnimation(1, TimeSpan.FromSeconds(duration), element, TimeSpan.FromSeconds(beginSeconds), easingFunction));
                stop2.BeginAnimation(GradientStop.ColorProperty, GetColorAnimation(Colors.White, TimeSpan.FromSeconds(duration / 0.5), element, TimeSpan.FromSeconds(duration * 0.75), easingFunction));
            }
            else
            {
                element.Loaded += delegate
                {
                    var duration = GetDurationSeconds(element);
                    var beginSeconds = GetBeginTimeSeconds(element);
                    var easingFunction = GetEasingFunction(element);
                    stop2.BeginAnimation(GradientStop.OffsetProperty, GetDoubleAnimation(1, TimeSpan.FromSeconds(duration), element, TimeSpan.FromSeconds(beginSeconds), easingFunction));
                    stop2.BeginAnimation(GradientStop.ColorProperty, GetColorAnimation(Colors.White, TimeSpan.FromSeconds(duration / 0.5), element, TimeSpan.FromSeconds(duration * 0.75), easingFunction));
                };
            }
            SetGradualIn(element, false);
        }
        #endregion

        #region MarginTo
        public static Thickness GetMarginTo(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(MarginToProperty);
        }

        public static void SetMarginTo(DependencyObject obj, Thickness value)
        {
            obj.SetValue(MarginToProperty, value);
        }

        public static readonly DependencyProperty MarginToProperty =
            DependencyProperty.RegisterAttached("MarginTo", typeof(Thickness), typeof(AnimationHelper), new PropertyMetadata(OnMarginToChanged));

        private static void OnMarginToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element == null)
                return;

            var thickness = e.NewValue as Thickness? ?? new Thickness(0);

            if (element.IsLoaded)
                element.BeginAnimation(FrameworkElement.MarginProperty, GetThicknessAnimation(thickness, element));
            else
            {
                element.Loaded += delegate
                {
                    element.BeginAnimation(FrameworkElement.MarginProperty, GetThicknessAnimation(thickness, element));
                };
            }
        }
        #endregion

        #region Duration & BeginTime
        /// <summary>BeginTimeSeconds
        /// 获取或设置动画的执行持续时间。默认为0.5秒。
        /// </summary>
        public static readonly DependencyProperty DurationSecondsProperty =
            DependencyProperty.RegisterAttached("DurationSeconds", typeof(double), typeof(AnimationHelper), new PropertyMetadata(0.5));

        public static double GetDurationSeconds(DependencyObject obj)
        {
            return (double)obj.GetValue(DurationSecondsProperty);
        }

        public static void SetDurationSeconds(DependencyObject obj, double value)
        {
            obj.SetValue(DurationSecondsProperty, value);
        }

        /// <summary>
        /// 获取或设置动画的执行开始时间。默认为0秒。
        /// </summary>
        public static readonly DependencyProperty BeginTimeSecondsProperty =
            DependencyProperty.RegisterAttached("BeginTimeSeconds", typeof(double), typeof(AnimationHelper), new PropertyMetadata(0.0));

        public static double GetBeginTimeSeconds(DependencyObject obj)
        {
            return (double)obj.GetValue(BeginTimeSecondsProperty);
        }

        public static void SetBeginTimeSeconds(DependencyObject obj, double value)
        {
            obj.SetValue(BeginTimeSecondsProperty, value);
        }

        #endregion

        #region EasingFunction
        public static IEasingFunction GetEasingFunction(DependencyObject obj)
        {
            return (IEasingFunction)obj.GetValue(EasingFunctionProperty);
        }

        public static void SetEasingFunction(DependencyObject obj, IEasingFunction value)
        {
            obj.SetValue(EasingFunctionProperty, value);
        }

        public static readonly DependencyProperty EasingFunctionProperty =
            DependencyProperty.RegisterAttached("EasingFunction", typeof(IEasingFunction), typeof(AnimationHelper));
        #endregion

        #region Function
        private static DoubleAnimation GetDoubleAnimation(double to, FrameworkElement element)
        {
            var anima = new DoubleAnimation()
            {
                To = to,
                Duration = TimeSpan.FromSeconds(GetDurationSeconds(element)),
                BeginTime = TimeSpan.FromSeconds(GetBeginTimeSeconds(element)),
                EasingFunction = GetEasingFunction(element),
            };

            anima.Completed += delegate
            {
                RaiseCompleted(element);
            };

            return anima;
        }

        private static DoubleAnimation GetDoubleAnimation(double to, TimeSpan duration, FrameworkElement element, TimeSpan? beginTime = null, IEasingFunction easingFunction = null)
        {
            var anima = new DoubleAnimation()
            {
                To = to,
                Duration = duration,
                BeginTime = beginTime ?? TimeSpan.FromSeconds(0),
                EasingFunction = easingFunction,
            };

            anima.Completed += delegate
            {
                RaiseCompleted(element);
            };

            return anima;
        }


        private static ColorAnimation GetColorAnimation(Color to, FrameworkElement element)
        {
            var anima = new ColorAnimation()
            {
                To = to,
                Duration = TimeSpan.FromSeconds(GetDurationSeconds(element)),
                BeginTime = TimeSpan.FromSeconds(GetBeginTimeSeconds(element)),
                EasingFunction = GetEasingFunction(element),
            };


            anima.Completed += delegate
            {
                RaiseCompleted(element);
            };

            return anima;
        }

        private static ColorAnimation GetColorAnimation(Color to, TimeSpan duration, FrameworkElement element, TimeSpan? beginTime = null, IEasingFunction easingFunction = null)
        {
            var anima = new ColorAnimation()
            {
                To = to,
                Duration = duration,
                BeginTime = beginTime ?? TimeSpan.FromSeconds(0),
                EasingFunction = easingFunction,
            };


            anima.Completed += delegate
            {
                RaiseCompleted(element);
            };

            return anima;
        }

        private static ThicknessAnimation GetThicknessAnimation(Thickness to, FrameworkElement element)
        {
            var anima = new ThicknessAnimation()
            {
                To = to,
                Duration = TimeSpan.FromSeconds(GetDurationSeconds(element)),
                BeginTime = TimeSpan.FromSeconds(GetBeginTimeSeconds(element)),
                EasingFunction = GetEasingFunction(element),
            };


            anima.Completed += delegate
            {
                RaiseCompleted(element);
            };

            return anima;
        }

        #endregion

        #region (Event) 
        public static readonly RoutedEvent CompletedEvent = EventManager.RegisterRoutedEvent("Completed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabControlHelper));
        public static void AddCompletedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(CompletedEvent, handler);
            }
        }
        public static void RemoveCompletedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(CompletedEvent, handler);
            }
        }

        internal static void RaiseCompleted(UIElement uie)
        {
            var arg = new RoutedEventArgs(CompletedEvent);
            uie.RaiseEvent(arg);
        }


        #endregion
    }
}
