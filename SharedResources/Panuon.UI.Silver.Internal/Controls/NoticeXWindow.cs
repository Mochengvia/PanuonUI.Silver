using Panuon.UI.Silver.Components;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Internal.Controls
{
    internal sealed class NoticeXWindow : Window
    {
        #region Fields
        private AnimationStackPanel _cardStack;

        private bool _canClose = false;
        #endregion

        #region Ctor
        internal NoticeXWindow()
        {
            ShowInTaskbar = false;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Background = Brushes.Transparent;
            Top = 0;
            var factory = new FrameworkElementFactory(typeof(AnimationStackPanel));
            factory.SetValue(AnimationStackPanel.DirectionProperty, StackDirection.Reverse);
            factory.SetValue(AnimationStackPanel.HeightProperty, SystemParameters.WorkArea.Height);
            Template = new ControlTemplate()
            {
                VisualTree = factory
            };
            AddHandler(NoticeXCard.CloseEvent, new RoutedEventHandler(OnNoticeXCardClose));
        }


        #endregion

        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _cardStack = VisualTreeHelper.GetChild(this, 0) as AnimationStackPanel;
            var noticeCard = new NoticeXCard();
            _cardStack.Children.Add(noticeCard);
            _cardStack.Children.Remove(noticeCard);
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_canClose)
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        public new void Close()
        {
            _canClose = true;
            base.Close();
        }

        public void AddCard(string message, string caption, MessageBoxIcon? icon, string imageSource, int? intervalMs, bool canClose)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                Show();
                Topmost = true;
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
                _cardStack.Children.Add(noticeCard);
                _cardStack.Width = noticeCard.Width;
                Left = SystemParameters.WorkArea.Width - noticeCard.Width;
            }));
        }
        #endregion

        #region Event Handlers

        private void OnNoticeXCardClose(object sender, RoutedEventArgs e)
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
                    _cardStack.Children.Remove(noticeCard);
                    if (_cardStack.Children.Count == 0)
                    {
                        Hide();
                    }
                };
                noticeCard.BeginAnimation(OpacityProperty, opacityAnimation);
            }));

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
        #endregion
    }
}
