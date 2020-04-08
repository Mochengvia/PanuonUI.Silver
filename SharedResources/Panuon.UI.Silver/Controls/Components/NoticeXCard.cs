using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Components
{
    public class NoticeXCard : Control
    {
        #region Fields
        private DispatcherTimer _timer;
        #endregion

        #region Ctor
        static NoticeXCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NoticeXCard), new FrameworkPropertyMetadata(typeof(NoticeXCard)));
        }

        internal NoticeXCard()
        {

        }

        public NoticeXCard(string message, string caption, MessageBoxIcon? icon, int? intervalMs, bool canClose)
        {
            Message = message;
            Caption = caption;
            Icon = icon;
            CanClose = canClose;
            if(intervalMs != null)
            {
                StartTimer((int)intervalMs);
            }
        }

        public NoticeXCard(string message, string caption, string imageSource, int? intervalMs, bool canClose)
        {
            Message = message;
            Caption = caption;
            ImageSource = imageSource;
            CanClose = canClose;
            if (intervalMs != null)
            {
                StartTimer((int)intervalMs);
            }
        }
        #endregion

        #region Event 
        public static readonly RoutedEvent CloseEvent = EventManager.RegisterRoutedEvent("Close", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NoticeXCard));
        public event RoutedEventHandler Close
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }

        internal void RaiseClose()
        {

            var arg = new RoutedEventArgs(CloseEvent);
            Dispatcher.Invoke(new Action(() =>
            {
                RaiseEvent(arg);
            }));
        }
        #endregion

        #region Properties

        #region Caption

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(NoticeXCard));

        #endregion

        #region Message

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(NoticeXCard));

        #endregion

        #region Icon
        public MessageBoxIcon? Icon
        {
            get { return (MessageBoxIcon?)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(MessageBoxIcon?), typeof(NoticeXCard));
        #endregion

        #region ImageSource
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(NoticeXCard));
        #endregion

        #region CanClose
        public bool CanClose
        {
            get { return (bool)GetValue(CanCloseProperty); }
            set { SetValue(CanCloseProperty, value); }
        }

        public static readonly DependencyProperty CanCloseProperty =
            DependencyProperty.Register("CanClose", typeof(bool), typeof(NoticeXCard), new PropertyMetadata(true));
        #endregion

        #region CloseCommand

        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(NoticeXCard), new PropertyMetadata(new RelayCommand(OnCloseCommandExecuted)));

        #endregion

        #region ShadowColor

        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(NoticeXCard));

        #endregion

        #region CornerRadius


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(NoticeXCard));


        #endregion

        #region CloseButtonStyle

        public Style CloseButtonStyle
        {
            get { return (Style)GetValue(CloseButtonStyleProperty); }
            set { SetValue(CloseButtonStyleProperty, value); }
        }
        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(NoticeXCard));

        #endregion
        #endregion

        #region Event Handler
        private static void OnCloseCommandExecuted(object obj)
        {
            var noticeXCard = obj as NoticeXCard;
            if(noticeXCard != null)
            {
                noticeXCard.RaiseClose();
            }
        }
        #endregion

        #region Function
        private void StartTimer(int intervalMs)
        {
            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(intervalMs),
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            RaiseClose();
        }

        #endregion
    }
}
