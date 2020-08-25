using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class Signboard : Control
    {
        #region Fields
        private Queue<string> _queue;

        private TextBlock _textBlock;

        private Storyboard _storyboard;

        private double _boundingWidth;

        private double _boundingHeight;

        private double _textWidth;

        private object _checkLock = new object();
        #endregion

        #region Ctor
        static Signboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Signboard), new FrameworkPropertyMetadata(typeof(Signboard)));
        }
        #endregion

        #region Properties

        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Signboard), new PropertyMetadata(OnTextChanged));
        #endregion

        #region QueueStrategy
        public QueueStrategy QueueStrategy
        {
            get { return (QueueStrategy)GetValue(QueueStrategyProperty); }
            set { SetValue(QueueStrategyProperty, value); }
        }

        public static readonly DependencyProperty QueueStrategyProperty =
            DependencyProperty.Register("QueueStrategy", typeof(QueueStrategy), typeof(Signboard), new PropertyMetadata(OnQueueStrategyChanged));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Signboard));
        #endregion

        #region Animation
        public SignboardAnimation Animation
        {
            get { return (SignboardAnimation)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly DependencyProperty AnimationProperty =
            DependencyProperty.Register("Animation", typeof(SignboardAnimation), typeof(Signboard));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(Signboard));
        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(Signboard));
        #endregion

        #region AnimationBeginTime
        public TimeSpan AnimationBeginTime
        {
            get { return (TimeSpan)GetValue(AnimationBeginTimeProperty); }
            set { SetValue(AnimationBeginTimeProperty, value); }
        }

        public static readonly DependencyProperty AnimationBeginTimeProperty =
            DependencyProperty.Register("AnimationBeginTime", typeof(TimeSpan), typeof(Signboard));
        #endregion

        #region AnimationInterval
        public TimeSpan AnimationInterval
        {
            get { return (TimeSpan)GetValue(AnimationIntervalProperty); }
            set { SetValue(AnimationIntervalProperty, value); }
        }

        public static readonly DependencyProperty AnimationIntervalProperty =
            DependencyProperty.Register("AnimationInterval", typeof(TimeSpan), typeof(Signboard));
        #endregion

        #region AutoRepeat
        public bool AutoRepeat
        {
            get { return (bool)GetValue(AutoRepeatProperty); }
            set { SetValue(AutoRepeatProperty, value); }
        }

        public static readonly DependencyProperty AutoRepeatProperty =
            DependencyProperty.Register("AutoRepeat", typeof(bool), typeof(Signboard));
        #endregion

        #endregion

        #region Overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _textBlock = Template?.FindName("PART_TextBlock", this) as TextBlock;
            AutoCheck();
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            _boundingWidth = arrangeBounds.Width - Padding.Left - Padding.Right;
            _boundingHeight = arrangeBounds.Height;
            return base.ArrangeOverride(arrangeBounds);
        }
        #endregion

        #region Event Handlers

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var signboard = d as Signboard;
            signboard.Enqueue(e.NewValue as string);
            if (signboard.IsInitialized)
            {
                signboard.AutoCheck();
            }
        }

        private static void OnQueueStrategyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var signboard = d as Signboard;
            if (!signboard.IsInitialized)
            {
                return;
            }
            signboard.AutoCheck();
        }

        #endregion

        #region Functions
        private void Enqueue(string text)
        {
            if (_queue == null)
            {
                _queue = new Queue<string>();
            }
            if (QueueStrategy == QueueStrategy.Priority)
            {
                _queue.Clear();
            }
            _queue.Enqueue(text);
        }

        private bool Dequeue(out string text)
        {
            text = null;
            if (_queue == null || !_queue.Any())
            {
                return false;
            }
            text = _queue.Dequeue();
            return true;
        }

        private void AutoCheck()
        {
            lock (_checkLock)
            {
                if (_storyboard != null)
                {
                    switch (QueueStrategy)
                    {
                        case QueueStrategy.None:
                            _storyboard.Completed -= Storyboard_Completed;
                            _storyboard.Stop();
                            break;
                        default:
                            return;
                    }
                }

                if (Dequeue(out string text))
                {
                    _textBlock.Text = text;
                    MeasureText(text);
                }
                else if (!AutoRepeat)
                {
                    return;
                }

                _storyboard = CreateStoryboard();
                _storyboard.Completed += Storyboard_Completed;
                _textBlock.BeginStoryboard(_storyboard);
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            _storyboard.Completed -= Storyboard_Completed;
            _storyboard = null;
            AutoCheck();
        }

        private Storyboard CreateStoryboard()
        {
            switch (Animation)
            {
                case SignboardAnimation.Barrage:
                    return CreateBarrageStoryboard();
                case SignboardAnimation.Marble:
                    return CreateMarbleStoryboard();
                case SignboardAnimation.Fade:
                    return CreateFadeStoryboard();
                case SignboardAnimation.Notice:
                    return CreateNoticeStoryboard();
                default:
                    throw new NotImplementedException($"Unsupported signboard animation : {Animation}");
            }
        }

        private Storyboard CreateBarrageStoryboard()
        {
            var storyboard = new Storyboard();

            var anima = UIElementUtils.CreateAnimation(new Thickness(_boundingWidth, 0, 0, 0),
                new Thickness(-_textWidth, 0, 0, 0),
                AnimationBeginTime,
                AnimationDuration,
                AnimationEase);
            Storyboard.SetTarget(anima, _textBlock);
            Storyboard.SetTargetProperty(anima, new PropertyPath(TextBlock.MarginProperty));
            storyboard.Children.Add(anima);
            return storyboard;
        }

        private Storyboard CreateMarbleStoryboard()
        {
            var storyboard = new Storyboard();
            var anima = UIElementUtils.CreateAnimation(
                new Thickness(0),
                new Thickness(_boundingWidth - _textWidth, 0, 0, 0),
                AnimationBeginTime,
                AnimationDuration,
                AnimationEase);

            Storyboard.SetTarget(anima, _textBlock);
            Storyboard.SetTargetProperty(anima, new PropertyPath(TextBlock.MarginProperty));

            var totalMs = AnimationDuration.TotalMilliseconds + AnimationInterval.TotalMilliseconds;

            var animaReverse = UIElementUtils.CreateAnimation((Thickness?)null,
                null,
                TimeSpan.FromMilliseconds(totalMs),
                AnimationDuration,
                AnimationEase);

            Storyboard.SetTarget(animaReverse, _textBlock);
            Storyboard.SetTargetProperty(animaReverse, new PropertyPath(TextBlock.MarginProperty));

            storyboard.Children.Add(anima);
            storyboard.Children.Add(animaReverse);

            return storyboard;

        }

        private Storyboard CreateFadeStoryboard()
        {
            var storyboard = new Storyboard();

            var animaForeground = UIElementUtils.CreateAnimation(null,
                      0,
                      AnimationBeginTime,
                      AnimationDuration,
                      AnimationEase);

            Storyboard.SetTarget(animaForeground, _textBlock);
            Storyboard.SetTargetProperty(animaForeground, new PropertyPath(TextBlock.OpacityProperty));

            var totalMs = AnimationDuration.TotalMilliseconds + AnimationInterval.TotalMilliseconds;

            var animaForegroundReverse = UIElementUtils.CreateAnimation(null,
                    1,
                    TimeSpan.FromMilliseconds(totalMs),
                    AnimationDuration,
                    AnimationEase);

            Storyboard.SetTarget(animaForegroundReverse, _textBlock);
            Storyboard.SetTargetProperty(animaForegroundReverse, new PropertyPath(TextBlock.OpacityProperty));

            var animaString = new StringAnimationUsingKeyFrames();
            animaString.KeyFrames.Add(new DiscreteStringKeyFrame()
            {
                Value = Text,
                KeyTime = KeyTime.FromTimeSpan(AnimationDuration),
            });
            Storyboard.SetTarget(animaString, _textBlock);
            Storyboard.SetTargetProperty(animaString, new PropertyPath(TextBlock.TextProperty));

            storyboard.Children.Add(animaForeground);
            storyboard.Children.Add(animaForegroundReverse);
            storyboard.Children.Add(animaString);

            return storyboard;

        }

        private Storyboard CreateNoticeStoryboard()
        {
            var delta = _boundingWidth - _textWidth;
            if (delta > 0)
            {
                delta = 0;
            }

            var storyboard = new Storyboard();

            var anima = UIElementUtils.CreateAnimation(new Thickness(0),
                  new Thickness(delta, 0, 0, 0),
                  AnimationBeginTime,
                  AnimationDuration,
                  AnimationEase);

            Storyboard.SetTarget(anima, _textBlock);
            Storyboard.SetTargetProperty(anima, new PropertyPath(TextBlock.MarginProperty));
            storyboard.Children.Add(anima);
            return storyboard;
        }

        private void MeasureText(string newText)
        {
            var size = StringUtils.MeasureTextSize(newText, TextWrapping.NoWrap, FontFamily, FontStyle, FontWeight, FontStretch, FontSize, double.PositiveInfinity);
            _textWidth = size.Width;
        }

        #endregion
    }
}
