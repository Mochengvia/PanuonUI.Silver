using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class Countdown : Control
    {
        #region Identity
        private DispatcherTimer _timer;
        #endregion

        static Countdown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Countdown), new FrameworkPropertyMetadata(typeof(Countdown)));
        }

        public Countdown()
        {
            _timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += CountdownTimer_Tick;
            
        }
      
        #region RoutedEvent
        public static readonly RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent("TimeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(Countdown));
        public event RoutedPropertyChangedEventHandler<int> TimeChanged
        {
            add { AddHandler(TimeChangedEvent, value); }
            remove { RemoveHandler(TimeChangedEvent, value); }
        }
        void RaiseTimeChanged(int oldValue, int newValue)
        {
            var arg = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue, TimeChangedEvent);
            RaiseEvent(arg);
        }

        public static readonly RoutedEvent StopedEvent = EventManager.RegisterRoutedEvent("Stoped", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Countdown));
        public event RoutedEventHandler Stoped
        {
            add { AddHandler(StopedEvent, value); }
            remove { RemoveHandler(StopedEvent, value); }
        }
        void RaiseStoped()
        {
            var arg = new RoutedEventArgs(StopedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Countdown));


        public int Second
        {
            get { return (int)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        public static readonly DependencyProperty SecondProperty =
            DependencyProperty.Register("Second", typeof(int), typeof(Countdown), new PropertyMetadata(OnSecondChanged));

        private static void OnSecondChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var countDown = d as Countdown;
            if(countDown.Second < 0)
            {
                countDown.Second = 0;
                return;
            }
            countDown.RaiseTimeChanged(e.OldValue as int? ?? 0, e.NewValue as int? ?? 0);
        }

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static readonly DependencyProperty IsRunningProperty =
            DependencyProperty.Register("IsRunning", typeof(bool), typeof(Countdown), new PropertyMetadata(OnIsRunningChanged));

        private static void OnIsRunningChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var countdown = d as Countdown;
            if (countdown.IsRunning)
            {
                countdown._timer.Start();
            }
            else
            {
                countdown.RaiseStoped();
                countdown._timer.Stop();
            }
        }

        #endregion

        #region Event
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (Second <= 0)
            {
                RaiseStoped();
                _timer.Stop();
            }

            Second--;
        }
        #endregion
    }
}
