using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Controls.Internal
{
    /// <summary>
    /// NoticeWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class NoticeWindow : Window
    {
        public NoticeWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        #region Property
        public static NoticeWindow Instance { get; set; }
        #endregion

        #region EventHandler

        private void NoticeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Instance = null;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = 0;
            Height = desktopWorkingArea.Bottom;
        }
        #endregion

        #region Calling Method
        public void AddNotice(string message, string title, double? durationSeconds, MessageBoxIcon messageBoxIcon)
        {
            var noticeCard = new NoticeCard(durationSeconds)
            {
                Message = message,
                Title = title,
                Background = Brushes.White,
                MessageBoxIcon = messageBoxIcon,
            };

            Canvas.SetTop(noticeCard, Height - (cvaMain.Children.Count + 1) * 155);
            Canvas.SetLeft(noticeCard, 400);

            noticeCard.Timeup += NoticeCard_Timeup;

            cvaMain.Children.Add(noticeCard);

            BeginAnimation(noticeCard, true);
        }

        private void NoticeCard_Timeup(object sender, RoutedEventArgs e)
        {
            var noticeCard = sender as NoticeCard;

            BeginSortAnimation(cvaMain.Children.IndexOf(noticeCard));

            BeginAnimation(noticeCard, false, new Action(() =>
            {
                cvaMain.Children.Remove(noticeCard);
            }));

        }

        #endregion

        #region Function
        private void BeginAnimation(NoticeCard noticeCard, bool toShow, Action callback = null)
        {
            if (toShow)
            {
                var animaLeft = new DoubleAnimation()
                {
                    To = 0,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
                    Duration = TimeSpan.FromSeconds(0.4),
                };
                animaLeft.Completed += delegate
                {
                    callback?.Invoke();
                };

                noticeCard.BeginAnimation(Canvas.LeftProperty, animaLeft);
            }
            else
            {
                var anima = new DoubleAnimation()
                {
                    To = 0,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
                    Duration = TimeSpan.FromSeconds(0.4),
                };
                anima.Completed += delegate
                {
                    callback?.Invoke();
                };
                noticeCard.BeginAnimation(OpacityProperty, anima);
            }
        }

        private void BeginSortAnimation(int expect)
        {
            var count = 0;
            for(int i = 0; i < cvaMain.Children.Count; i++)
            {
                if (i == expect)
                    continue;

                var noticeCard = cvaMain.Children[i] as NoticeCard;

                var animaTop = new DoubleAnimation()
                {
                    To = Height - (count + 1) * 155,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
                    Duration = TimeSpan.FromSeconds(0.4),
                    BeginTime = TimeSpan.FromSeconds(0.05 * i),
                };

                noticeCard.BeginAnimation(Canvas.TopProperty, animaTop);
                count++;
            }
        }
        #endregion


    }
}
