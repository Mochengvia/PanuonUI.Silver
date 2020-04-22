using Panuon.UI.Silver.Components;
using Panuon.UI.Silver.Internal.Win32;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Internal.Controls
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class NoticeWindow : Window
    {
        #region Ctor
        public NoticeWindow()
        {
            InitializeComponent();
            AddHandler(NoticeXCard.CloseEvent, new RoutedEventHandler(OnNoticeCardClose));
        }
        #endregion

        #region Event Handler
        private void NoticeWindow_Initialized(object sender, EventArgs e)
        {
            var area = SystemParameters.WorkArea;
            Left = area.Right - Width;
            Top = 0;
            Height = area.Bottom;

            //必须加这一段，第一次样式不会生效
            {
                var noticeCard = new NoticeXCard();
                AstpCard.Children.Add(noticeCard);
                AstpCard.Children.Remove(noticeCard);
                Hide();
            }

        }
        #endregion

        #region Methods
        public void AddCard(string message, string caption, MessageBoxIcon? icon, string imageSource, int? intervalMs, bool canClose)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                Show();
                NoticeXCard noticeCard = null;
                if (imageSource != null)
                {
                    noticeCard = new NoticeXCard(message, caption, imageSource, intervalMs, canClose);
                }
                else
                {
                    noticeCard = new NoticeXCard(message, caption, icon, intervalMs, canClose);
                }
                noticeCard.Opacity = 0;
                noticeCard.Loaded += NoticeCard_Loaded;
                AstpCard.Children.Add(noticeCard);
                AstpCard.Width = noticeCard.Width;
                Left = SystemParameters.WorkArea.Width - noticeCard.Width;
            }));
        }

        #endregion

        #region Event Handler
        private void NoticeCard_Loaded(object sender, RoutedEventArgs e)
        {
            var noticeCard = sender as NoticeXCard;
            var opacityAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4),
            };
            var marginAnimation = new ThicknessAnimation()
            {
                From = new Thickness(noticeCard.Margin.Left + noticeCard.DesiredSize.Width, noticeCard.Margin.Top, noticeCard.Margin.Right + noticeCard.DesiredSize.Height * -1, noticeCard.Margin.Bottom),
                To = new Thickness(noticeCard.Margin.Left, noticeCard.Margin.Top, noticeCard.Margin.Right, noticeCard.Margin.Bottom),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
                Duration = TimeSpan.FromSeconds(0.4),
            };

            noticeCard.BeginAnimation(OpacityProperty, opacityAnimation);
            noticeCard.BeginAnimation(MarginProperty, marginAnimation);

        }
        private void OnNoticeCardClose(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                var noticeCard = e.Source as NoticeXCard;
                if (noticeCard == null)
                {
                    return;
                }
                var opacityAnimation = new DoubleAnimation()
                {
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.3),
                };

                opacityAnimation.Completed += delegate
                {
                    AstpCard.Children.Remove(noticeCard);
                    if(AstpCard.Children.Count == 0)
                    {
                        Hide();
                    }
                };
                noticeCard.BeginAnimation(OpacityProperty, opacityAnimation);
            }));
        }
        #endregion

        #region Function
        #endregion
    }
}
