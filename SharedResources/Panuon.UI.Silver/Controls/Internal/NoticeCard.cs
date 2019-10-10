using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Controls.Internal
{
    internal class NoticeCard : Control
    {
        #region Identifier
        private DispatcherTimer _dispatcherTimer;
        #endregion

        static NoticeCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NoticeCard), new FrameworkPropertyMetadata(typeof(NoticeCard)));
        }

        public NoticeCard(double? durationSeconds)
        {
            if (durationSeconds == null)
                return;

            _dispatcherTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds((double)durationSeconds),
            };
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            RaiseTimeup();
            _dispatcherTimer.Stop();
        }

        #region RoutedEvent
        public static readonly RoutedEvent TimeupEvent = EventManager.RegisterRoutedEvent("Timeup", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NoticeCard));
        public event RoutedEventHandler Timeup
        {
            add { AddHandler(TimeupEvent, value); }
            remove { RemoveHandler(TimeupEvent, value); }
        }

        internal void RaiseTimeup()
        {
            var arg = new RoutedEventArgs(TimeupEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(NoticeCard));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NoticeCard));


        public MessageBoxIcon MessageBoxIcon
        {
            get { return (MessageBoxIcon)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxIconProperty =
            DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxIcon), typeof(NoticeCard));



        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(NoticeCard), new PropertyMetadata(new CloseCommand()));


        #endregion
    }

    internal class CloseCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var card = (parameter as NoticeCard);
            card.RaiseTimeup();
        }
    }
}
