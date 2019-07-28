using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// NeonLabel.xaml 的交互逻辑
    /// </summary>
    public partial class NeonLabel : ContentControl
    {
        #region Identity
        #endregion

        public NeonLabel()
        {
            InitializeComponent();
            Padding = new Thickness(10, 0, 0, 0);
        }

        #region Property
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(NeonLabel));

        public new object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(NeonLabel));
        #endregion

        #region APIs
        /// <summary>
        /// Change to Next.
        /// </summary>
        /// <param name="neonLabelType">Neon label type.</param>
        /// <param name="next">Next content, or brush.</param>
        /// <param name="durationSecond"></param>
        public void Next(NeonLabelType neonLabelType, object next = null, double durationSecond = 0.5)
        {
            switch (neonLabelType)
            {
                case NeonLabelType.FadeBackground:
                    ChangeBackground(next as Brush, durationSecond);
                    break;
                case NeonLabelType.FadeForeground:
                    ChangeForeground(next as Brush, durationSecond);
                    break;
                case NeonLabelType.FadeNext:
                    FadeNext(next, durationSecond);
                    break;
                case NeonLabelType.SlideNext:
                    SlideNext(next, durationSecond);
                    break;
                case NeonLabelType.ScrollToEnd:
                    ScrollToEnd(durationSecond);
                    break;

            }
        }
        #endregion

        #region Function
        private void ChangeBackground(Brush nextBackground, double durationSecond)
        {
            BdrAnima.Background = nextBackground;
            var doubleAnima1 = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            var doubleAnima2 = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            doubleAnima2.Completed += delegate
            {
                BdrAnima.BeginAnimation(OpacityProperty, null);
                BdrBack.BeginAnimation(OpacityProperty, null);
                BdrBack.Background = nextBackground;
                BdrAnima.Opacity = 0;
                BdrAnima.Opacity = 1;
            };
            BdrAnima.BeginAnimation(OpacityProperty, doubleAnima1);
            BdrBack.BeginAnimation(OpacityProperty, doubleAnima2);

        }

        private void ChangeForeground(Brush nextForeground, double durationSecond)
        {
            LblAnima.Content = LblContent.Content;
            LblContent.Margin = new Thickness(0, 0, 0, 0);
            LblAnima.Foreground = nextForeground;
            var doubleAnima1 = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            var doubleAnima2 = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            doubleAnima2.Completed += delegate
            {
                LblAnima.BeginAnimation(OpacityProperty, null);
                LblContent.BeginAnimation(OpacityProperty, null);
                LblContent.Foreground = nextForeground;
                LblAnima.Opacity = 0;
                LblContent.Opacity = 1;
            };
            LblAnima.BeginAnimation(OpacityProperty, doubleAnima1);
            LblContent.BeginAnimation(OpacityProperty, doubleAnima2);

        }

        private void FadeNext(object nextContent, double durationSecond)
        {
            LblAnima.Foreground = LblContent.Foreground;
            LblContent.Margin = new Thickness(0, 0, 0, 0);
            LblAnima.Content = nextContent;
            var doubleAnima1 = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            var doubleAnima2 = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            doubleAnima2.Completed += delegate
            {
                LblAnima.BeginAnimation(OpacityProperty, null);
                LblContent.BeginAnimation(OpacityProperty, null);
                Content = nextContent;
                LblAnima.Opacity = 0;
                LblContent.Opacity = 1;
            };
            LblAnima.BeginAnimation(OpacityProperty, doubleAnima1);
            LblContent.BeginAnimation(OpacityProperty, doubleAnima2);

        }

        private void SlideNext(object nextContent, double durationSecond)
        {
            LblAnima.Foreground = LblContent.Foreground;
            LblAnima.Opacity = 1;
            LblContent.Margin = new Thickness(0, 0, 0, 0);
            LblAnima.Content = nextContent;
            var thicknessAnima1 = new ThicknessAnimation()
            {
                From = new Thickness(0, ActualHeight * 2, 0, 0),
                To = new Thickness(0),
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            var thicknessAnima2 = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(0, -ActualHeight * 2, 0, 0),
                Duration = TimeSpan.FromSeconds(durationSecond),
            };
            thicknessAnima2.Completed += delegate
            {
                LblAnima.BeginAnimation(MarginProperty, null);
                LblContent.BeginAnimation(MarginProperty, null);
                Content = nextContent;
                LblContent.Margin = new Thickness(0);
                LblAnima.Opacity = 0;
            };
            LblAnima.BeginAnimation(MarginProperty, thicknessAnima1);
            LblContent.BeginAnimation(MarginProperty, thicknessAnima2);

        }

        private void ScrollToEnd(double durationSecond)
        {
            var offset = LblContent.ActualWidth - GrdMain.ActualWidth + FontSize;
            LblContent.Margin = new Thickness(0, 0, 0, 0);

            if (offset < 0)
                offset = 0;

            var thicknessAnima = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(-offset, 0, 0, 0),
                BeginTime = TimeSpan.FromSeconds(durationSecond * 0.3),
                Duration = TimeSpan.FromSeconds(durationSecond * 0.7),
            };
            thicknessAnima.Completed += delegate
            {
                LblContent.BeginAnimation(MarginProperty, null);
                LblContent.Margin = new Thickness(-offset, 0, 0, 0);
            };
            LblContent.BeginAnimation(MarginProperty, thicknessAnima);


        }

        #endregion

        private void CvaMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GrdMain.Width = CvaMain.ActualWidth;
            GrdMain.Height = CvaMain.ActualHeight;
        }

    }
}
