using Panuon.UI.Silver.Internal.Utils;
using Panuon.UI.Silver.Components;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Interop;
using Panuon.UI.Silver.Internal.Win32;

namespace Panuon.UI.Silver.Internal.Controls
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class NoticeWindow : Window
    {
        #region Fields
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int GWL_EXSTYLE = (-20);
        #endregion

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
            }

        }
        #endregion

        #region Methods
        public void AddCard(string message, string caption, MessageBoxIcon? icon, string imageSource, int? intervalMs, bool canClose)
        {
            Dispatcher.Invoke(new Action(() =>
            {
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
             
            }));
        }


        #endregion

        #region Event Handler
        protected override void OnSourceInitialized(EventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            var extendedStyle = User32.GetWindowLong(hwnd, GWL_EXSTYLE);
            User32.SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TOOLWINDOW | WS_EX_NOACTIVATE | WS_EX_TRANSPARENT);
            base.OnSourceInitialized(e);
        }

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
                };
                noticeCard.BeginAnimation(OpacityProperty, opacityAnimation);
            }));
        }
        #endregion
    }
}
