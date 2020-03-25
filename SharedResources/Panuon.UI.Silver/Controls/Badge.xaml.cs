using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// Badge.xaml 的交互逻辑
    /// </summary>
    public partial class Badge : ContentControl
    {
        #region Identity
        private Storyboard _storyboard_ScaleBigger;

        private Storyboard _storyboard_ScaleSmaller;
        #endregion

        #region Constructor
        public Badge()
        {
            InitializeComponent();
            AlwaysCenter = true;
            _storyboard_ScaleBigger = FindResource("Storyboard_ScaleBigger") as Storyboard;
            _storyboard_ScaleSmaller = FindResource("Storyboard_ScaleSmaller") as Storyboard;
        }
        #endregion

        #region Property
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Badge), new PropertyMetadata(OnTextChanged));

        public bool IsWaving
        {
            get { return (bool)GetValue(IsWavingProperty); }
            set { SetValue(IsWavingProperty, value); }
        }

        public static readonly DependencyProperty IsWavingProperty =
            DependencyProperty.Register("IsWaving", typeof(bool), typeof(Badge), new PropertyMetadata(OnIsWavingChanged));

        public bool AlwaysCenter
        {
            get { return (bool)GetValue(AlwaysCenterProperty); }
            set { SetValue(AlwaysCenterProperty, value); }
        }

        public static readonly DependencyProperty AlwaysCenterProperty =
            DependencyProperty.Register("AlwaysCenter", typeof(bool), typeof(Badge), new PropertyMetadata(false, OnAlwaysCenterChanged));
        #endregion

        #region Internal Property
        internal new object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        internal new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(Badge));
        #endregion

        #region Event Handler
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = d as Badge;

            if (!badge.IsLoaded)
            {
                badge.Scale.ScaleX = 1;
                badge.Scale.ScaleY = 1;
                badge.TxtBlock.Text = badge.Text;
                return;
            }

            if ((e.OldValue as string).IsNullOrEmpty())
            {
                badge.StopWave();
                badge._storyboard_ScaleBigger.Completed += badge.Storyboard_ScaleBigger_Completed;
                badge._storyboard_ScaleBigger.Begin();
                return;
            }
            else if ((e.NewValue as string).IsNullOrEmpty())
            {
                badge.StopWave();
                badge.ShowText("");
                badge._storyboard_ScaleSmaller.Completed += badge.Storyboard_ScaleSmaller_Completed;
                badge._storyboard_ScaleSmaller.Begin();
                return;
            }
            else
            {
                badge.ShowText(badge.Text);
            }

        }

        private void Storyboard_ScaleSmaller_Completed(object sender, EventArgs e)
        {
            ChangeWaving();
            _storyboard_ScaleSmaller.Completed -= Storyboard_ScaleSmaller_Completed;
        }

        private void Storyboard_ScaleBigger_Completed(object sender, EventArgs e)
        {
            ChangeWaving();
            ShowText(Text);
            _storyboard_ScaleBigger.Completed -= Storyboard_ScaleBigger_Completed;

        }

        private static void OnIsWavingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = d as Badge;
            badge.ChangeWaving();
        }

        private void ChangeWaving()
        {
            if (IsWaving)
            {
                RectWave.Visibility = Visibility.Visible;
                BeginWave();

            }
            else
            {
                RectWave.Visibility = Visibility.Collapsed;
                StopWave();
            }
        }

        private static void OnAlwaysCenterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badge = d as Badge;
            badge.SizeChanged -= badge.Badge_SizeChanged;

            if (badge.AlwaysCenter)
            {
                badge.SizeChanged += badge.Badge_SizeChanged;
            }
        }

        private void Badge_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (HorizontalAlignment == HorizontalAlignment.Center)
            {
                RenderTransform = null;
                return;
            }
            else if (HorizontalAlignment == HorizontalAlignment.Left)
            {
                var delta = (ActualWidth - ActualHeight) / 2;
                RenderTransform = new TranslateTransform() { X = -delta };
            }
            else if (HorizontalAlignment == HorizontalAlignment.Right)
            {
                var delta = (ActualWidth - ActualHeight) / 2;
                RenderTransform = new TranslateTransform() { X = delta };
            }
        }

        #endregion

        #region Function

        private void BeginWave()
        {
            var anima1 = new DoubleAnimation()
            {
                From = Text.IsNullOrEmpty() ? 0.4 : 1,
                To = 2,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(1.5),
            };
            ScaleWave.BeginAnimation(ScaleTransform.ScaleXProperty, anima1);

            var anima2 = new DoubleAnimation()
            {
                From = Text.IsNullOrEmpty() ? 0.4 : 1,
                To =  2,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(1.5),
            };
            ScaleWave.BeginAnimation(ScaleTransform.ScaleYProperty, anima2);

            var anima3 = new DoubleAnimation()
            {
                To = 0,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(1.5),
            };
            RectWave.BeginAnimation(OpacityProperty, anima3);
        }

        private void StopWave()
        {
            ScaleWave.BeginAnimation(ScaleTransform.ScaleXProperty, null);
            ScaleWave.BeginAnimation(ScaleTransform.ScaleYProperty, null);
            RectWave.BeginAnimation(OpacityProperty, null);
        }

        private void ShowText(string text)
        {
            var anima1 = new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.1),
            };
            anima1.Completed += delegate
            {
                TxtBlock.Text = text;
                var anima2 = new DoubleAnimation()
                {
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.1),
                };
                TxtBlock.BeginAnimation(OpacityProperty, anima2);
            };
            TxtBlock.BeginAnimation(OpacityProperty, anima1);
        }
        #endregion

    }
}
