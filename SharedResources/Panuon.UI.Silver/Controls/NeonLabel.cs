using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Components;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace Panuon.UI.Silver
{
    public class NeonLabel : Control
    {
        #region Fields
        private TextBlock _textBlock;

        private TextBlock _assistTextBlock;

        private double _boundingWidth;

        private double _boundingHeight;

        private double _textWidth;

        private DisposableTimer _timer;

        private Queue<NeonNext> _nextQueue = new Queue<NeonNext>();

        private NeonNext _playImmediately;

        private Storyboard _storyboard;

        private NeonAnimation _lastAnimation;
        #endregion

        #region Ctor
        static NeonLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NeonLabel), new FrameworkPropertyMetadata(typeof(NeonLabel)));
        }
        public NeonLabel()
        {
            Loaded += NeonLabel_Loaded;
        }

        #endregion

        #region Properties

        #region Text
        /// <summary>
        /// Gets or sets text of neon label.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.Text dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NeonLabel), new PropertyMetadata(OnTextChanged));

        #endregion

        #region CornerRadius
        /// <summary>
        /// Gets or sets corner radius of neon label.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.CornerRadius dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(NeonLabel));
        #endregion

        #region Animation
        /// <summary>
        /// Gets or sets animation of neon label.
        /// </summary>
        public NeonAnimation Animation
        {
            get { return (NeonAnimation)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.Animation dependency property.
        /// </summary>
        public static readonly DependencyProperty AnimationProperty =
            DependencyProperty.Register("Animation", typeof(NeonAnimation), typeof(NeonLabel));
        #endregion

        #region BeginTime
        /// <summary>
        /// Gets or sets delay time before play.
        /// </summary>
        public TimeSpan? BeginTime
        {
            get { return (TimeSpan?)GetValue(BeginTimeProperty); }
            set { SetValue(BeginTimeProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.BeginTime dependency property.
        /// </summary>
        public static readonly DependencyProperty BeginTimeProperty =
            DependencyProperty.Register("BeginTime", typeof(TimeSpan?), typeof(NeonLabel));
        #endregion

        #region Duration
        /// <summary>
        /// Gets or sets duration of neon label.
        /// </summary>
        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.Animation dependency property.
        /// </summary>
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(NeonLabel));
        #endregion

        #region Interval
        /// <summary>
        /// Gets or sets interval of neon label.
        /// </summary>
        public TimeSpan? Interval
        {
            get { return (TimeSpan?)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.Animation dependency property.
        /// </summary>
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(TimeSpan?), typeof(NeonLabel));
        #endregion

        #region AutoPlay
        /// <summary>
        /// Gets or sets auto play of neon label.
        /// </summary>
        public bool AutoPlay
        {
            get { return (bool)GetValue(AutoPlayProperty); }
            set { SetValue(AutoPlayProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.NeonLabel.AutoPlay dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoPlayProperty =
            DependencyProperty.Register("AutoPlay", typeof(bool), typeof(NeonLabel), new PropertyMetadata(OnAutoPlayChanged));
        #endregion

        #endregion

        #region Override
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            _boundingWidth = arrangeBounds.Width - Padding.Left - Padding.Right;
            _boundingHeight = arrangeBounds.Height;
            return base.ArrangeOverride(arrangeBounds);
        }
        #endregion

        #region Event Handler
        private void NeonLabel_Loaded(object sender, RoutedEventArgs e)
        {
            if (_textBlock == null)
            {
                _textBlock = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 0), 0) as TextBlock;
            }

            if (AutoPlay || _nextQueue.Count != 0)
                StartTimer(true);
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var neonLabel = d as NeonLabel;
            neonLabel.MeasureText();
        }

        private static void OnAutoPlayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var neonLabel = d as NeonLabel;

            if (!neonLabel.IsLoaded)
                return;

            if (neonLabel.AutoPlay)
                neonLabel.StartTimer(false);
        }

        private void OnTimerTicked()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (!AutoPlay && _nextQueue.Count == 0 && _playImmediately == null)
                {
                    _timer.Dispose();
                    _timer = null;
                    return;
                }
                UpdateProperty();
                Reset();
                PlayStoryboard(() =>
                {
                    _timer.Change(Interval);
                });
            }));

        }
        #endregion

        #region Methods
        public void Play()
        {
            _nextQueue.Enqueue(new NeonNext());
            StartTimer(true);
        }

        public void Play(string text)
        {
            _playImmediately = new NeonNext()
            {
                Text = text
            };
            StartTimer(true);
        }

        public void Play(string text, NeonAnimation animation)
        {
            _playImmediately = new NeonNext()
            {
                Text = text,
                Animation = animation,
            };
            StartTimer(true);
        }

        public void Play(string text, NeonAnimation animation, TimeSpan duration)
        {
            _playImmediately = new NeonNext()
            {
                Text = text,
                Animation = animation,
                Duration = duration,
            };
            StartTimer(true);
        }

        public void Play(string text, NeonAnimation animation, TimeSpan duration, TimeSpan? interval)
        {
            _playImmediately = new NeonNext()
            {
                Text = text,
                Animation = animation,
                Duration = duration,
                Interval = interval,
            };
            StartTimer(true);
        }

        public void Next()
        {
            _nextQueue.Enqueue(new NeonNext());
            StartTimer(false);
        }

        public void Next(string text)
        {
            _nextQueue.Enqueue(new NeonNext()
            {
                Text = text
            });
            StartTimer(false);
        }

        public void Next(string text, NeonAnimation animation)
        {
            _nextQueue.Enqueue(new NeonNext()
            {
                Text = text,
                Animation = animation,
            });
            StartTimer(false);
        }

        public void Next(string text, NeonAnimation animation, TimeSpan duration)
        {
            _nextQueue.Enqueue(new NeonNext()
            {
                Text = text,
                Animation = animation,
                Duration = duration,
            });
            StartTimer(false);
        }

        public void Next(string text, NeonAnimation animation, TimeSpan duration, TimeSpan? interval)
        {
            _nextQueue.Enqueue(new NeonNext()
            {
                Text = text,
                Animation = animation,
                Duration = duration,
                Interval = interval,
            });
            StartTimer(false);
        }

        public void Stop()
        {
            Reset();
            AutoPlay = false;
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }

        public void Clear()
        {
            _nextQueue.Clear();
        }
        #endregion

        #region Function
        private void PlayStoryboard(Action completeAction)
        {
            switch (Animation)
            {
                case NeonAnimation.Notice:
                    _storyboard = CreateNoticeStoryboard();
                    break;
                case NeonAnimation.Marble:
                    _storyboard = CreateMarbleStoryboard();
                    break;
                case NeonAnimation.Barrage:
                    _storyboard = CreateBarrageStoryboard();
                    break;
                case NeonAnimation.Conspicuous:
                    _storyboard = CreateConspicuousStoryboard();
                    break;
                case NeonAnimation.FadeNext:
                    _storyboard = CreateFadeNextStoryboard();
                    break;
                default:
                    return;
            }
            if (_storyboard == null)
            {
                    completeAction?.Invoke();
                return;
            }
            _lastAnimation = Animation;
            if (BeginTime != null)
            {
                _storyboard.BeginTime = BeginTime;
            }
            _storyboard.Completed += delegate
            {
                completeAction?.Invoke();
            };

            _storyboard.Begin();
        }


        private void MeasureText()
        {
            var size = TextUtils.MeasureTextSize(Text, TextWrapping.NoWrap, FontFamily, FontStyle, FontWeight, FontStretch, FontSize, double.PositiveInfinity);
            _textWidth = size.Width;
        }

        private void StartTimer(bool forceRestart)
        {
            if (_timer == null || forceRestart)
            {
                if (_timer != null)
                    _timer.Dispose();

                _timer = new DisposableTimer(OnTimerTicked, BeginTime);
            }
        }

        private void Reset()
        {
            if (_storyboard != null)
                _storyboard.Stop();

            if (_textBlock != null)
            {
                _textBlock.BeginAnimation(MarginProperty, null);
                _textBlock.Text = Text;

                switch (Animation)
                {
                    case NeonAnimation.Barrage:
                        _textBlock.Margin = new Thickness(_boundingWidth, 0, 0, 0);
                        break;
                    default:
                        _textBlock.Margin = new Thickness(0, 0, 0, 0);
                        break;
                }

                switch (_lastAnimation)
                {
                    case NeonAnimation.Conspicuous:
                        BeginAnimation(BackgroundProperty, null);
                        BeginAnimation(ForegroundProperty, null);
                        break;
                    case NeonAnimation.FadeNext:
                        BeginAnimation(ForegroundProperty, null);
                        break;
                }
            }
        }

        private void UpdateProperty()
        {
            NeonNext next;

            if (_playImmediately != null)
            {
                next = _playImmediately;
                _playImmediately = null;
            }
            else
            {
                if (_nextQueue.Count == 0)
                    return;
                next = _nextQueue.Dequeue();
            }

            if (next.TextChanged)
            {
                Text = next.Text;
            }
            if (next.Animation != null)
            {
                Animation = (NeonAnimation)next.Animation;
            }
            if (next.IntervalChanged)
            {
                Interval = next.Interval;
            }
            if (next.Duration != null)
            {
                Duration = (TimeSpan)next.Duration;
            }
        }

        #region Storyboards
        private Storyboard CreateNoticeStoryboard()
        {
            if (_textWidth <= _boundingWidth)
                return null;

            var storyboard = new Storyboard();
            var anima = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(_boundingWidth - _textWidth, 0, 0, 0),
                Duration = Duration,
            };
            Storyboard.SetTarget(anima, _textBlock);
            Storyboard.SetTargetProperty(anima, new PropertyPath("Margin"));
            storyboard.Children.Add(anima);
            return storyboard;
        }

        private Storyboard CreateMarbleStoryboard()
        {
            var storyboard = new Storyboard();
            var anima = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(_boundingWidth - _textWidth, 0, 0, 0),
                Duration = Duration,
            };
            Storyboard.SetTarget(anima, _textBlock);
            Storyboard.SetTargetProperty(anima, new PropertyPath("Margin"));

            var totalMs = Duration.TotalMilliseconds;
            if (Interval != null)
            {
                totalMs += ((TimeSpan)Interval).TotalMilliseconds;
            }

            var animaReverse = new ThicknessAnimation()
            {
                Duration = Duration,
                BeginTime = TimeSpan.FromMilliseconds(totalMs),
            };

            Storyboard.SetTarget(animaReverse, _textBlock);
            Storyboard.SetTargetProperty(animaReverse, new PropertyPath("Margin"));

            storyboard.Children.Add(anima);
            storyboard.Children.Add(animaReverse);

            return storyboard;
        }

        private Storyboard CreateBarrageStoryboard()
        {
            var storyboard = new Storyboard();
            var anima = new ThicknessAnimation()
            {
                From = new Thickness(_boundingWidth, 0, 0, 0),
                To = new Thickness(-_textWidth, 0, 0, 0),
                Duration = Duration,
            };
            Storyboard.SetTarget(anima, _textBlock);
            Storyboard.SetTargetProperty(anima, new PropertyPath("Margin"));
            storyboard.Children.Add(anima);
            return storyboard;
        }

        private Storyboard CreateConspicuousStoryboard()
        {
            var storyboard = new Storyboard();
            var animaBackground = new BrushAnimation()
            {
                From = Brushes.Transparent,
                To = Background,
                Duration = Duration,
            };
            Storyboard.SetTarget(animaBackground, this);
            Storyboard.SetTargetProperty(animaBackground, new PropertyPath("Background"));

            var animaForeground = new BrushAnimation()
            {
                From = Foreground,
                To = Brushes.White,
                Duration = TimeSpan.FromMilliseconds(Duration.TotalMilliseconds * 0.7),
            };
            Storyboard.SetTarget(animaForeground, this);
            Storyboard.SetTargetProperty(animaForeground, new PropertyPath("Foreground"));

            var totalMs = Duration.TotalMilliseconds;
            if (Interval != null)
            {
                totalMs += ((TimeSpan)Interval).TotalMilliseconds;
            }

            var animaBackgroundReverse = new BrushAnimation()
            {
                To = Brushes.Transparent,
                Duration = Duration,
                BeginTime = TimeSpan.FromMilliseconds(totalMs),
            };

            Storyboard.SetTarget(animaBackgroundReverse, this);
            Storyboard.SetTargetProperty(animaBackgroundReverse, new PropertyPath("Background"));

            var animaForegroundReverse = new BrushAnimation()
            {
                To = Foreground,
                Duration = Duration,
                BeginTime = TimeSpan.FromMilliseconds(totalMs),
            };

            Storyboard.SetTarget(animaForegroundReverse, this);
            Storyboard.SetTargetProperty(animaForegroundReverse, new PropertyPath("Foreground"));

            storyboard.Children.Add(animaBackground);
            storyboard.Children.Add(animaForeground);
            storyboard.Children.Add(animaBackgroundReverse);
            storyboard.Children.Add(animaForegroundReverse);

            return storyboard;
        }

        private Storyboard CreateFadeNextStoryboard()
        {
            var storyboard = new Storyboard();

            var animaForeground = new DoubleAnimation()
            {
                To = 0,
                Duration = Duration,
            };
            Storyboard.SetTarget(animaForeground, _textBlock);
            Storyboard.SetTargetProperty(animaForeground, new PropertyPath("Opacity"));

            var totalMs = Duration.TotalMilliseconds;
            if (Interval != null)
            {
                totalMs += ((TimeSpan)Interval).TotalMilliseconds;
            }

            var animaForegroundReverse = new DoubleAnimation()
            {
                To = 1,
                Duration = Duration,
                BeginTime = TimeSpan.FromMilliseconds(totalMs),
            };

            Storyboard.SetTarget(animaForegroundReverse, _textBlock);
            Storyboard.SetTargetProperty(animaForegroundReverse, new PropertyPath("Opacity"));

            var animaString = new StringAnimationUsingKeyFrames();
            animaString.KeyFrames.Add(new DiscreteStringKeyFrame()
            {
                Value = Text,
                KeyTime = KeyTime.FromTimeSpan(Duration),
            });
            Storyboard.SetTarget(animaString, _textBlock);
            Storyboard.SetTargetProperty(animaString, new PropertyPath("Text"));

            storyboard.Children.Add(animaForeground);
            storyboard.Children.Add(animaForegroundReverse);
            storyboard.Children.Add(animaString);

            return storyboard;
        }

        #endregion

        #endregion
    }
}
