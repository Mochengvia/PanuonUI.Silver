using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Clock : Control
    {
        #region Ctor
        public Clock()
        {

        }
        #endregion

        #region RoutedEvent

        #region SelectedTimeChanged
        public static readonly RoutedEvent SelectedTimeChangedEvent = EventManager.RegisterRoutedEvent("SelectedTimeChanged", RoutingStrategy.Bubble, typeof(DateTimeChangedRoutedEventHandler), typeof(Clock));
        public event DateTimeChangedRoutedEventHandler SelectedTimeChanged
        {
            add { AddHandler(SelectedTimeChangedEvent, value); }
            remove { RemoveHandler(SelectedTimeChangedEvent, value); }
        }
        void RaiseSelectedTimeChanged(DateTime newValue)
        {
            var arg = new DateTimeChangedRoutedEventArgs(newValue, SelectedTimeChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Selected
        public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent("Selected", RoutingStrategy.Bubble, typeof(DateTimeChangedRoutedEventHandler), typeof(Clock));
        public event DateTimeChangedRoutedEventHandler Selected
        {
            add { AddHandler(SelectedEvent, value); }
            remove { RemoveHandler(SelectedEvent, value); }
        }
        void RaiseSelected(DateTime newValue)
        {
            var arg = new DateTimeChangedRoutedEventArgs(newValue, SelectedEvent);
            RaiseEvent(arg);
        }

        #endregion

        #endregion

        #region Properties

        #region SelectedTime


        public DateTime SelectedTime
        {
            get { return (DateTime)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(DateTime), typeof(Clock), new PropertyMetadata(default(DateTime), OnSelectedTimeChanged, OnSelectedTimeCoerceValue));


        #endregion

        #region MaxTime
        public DateTime MaxTime
        {
            get { return (DateTime)GetValue(MaxTimeProperty); }
            set { SetValue(MaxTimeProperty, value); }
        }

        public static readonly DependencyProperty MaxTimeProperty =
            DependencyProperty.Register("MaxTime", typeof(DateTime), typeof(Clock), new PropertyMetadata(default(DateTime), OnMaxTimeChanged, OnMaxTimeCoerceValue));
        #endregion

        #region MinTime


        public DateTime MinTime
        {
            get { return (DateTime)GetValue(MinTimeProperty); }
            set { SetValue(MinTimeProperty, value); }
        }

        public static readonly DependencyProperty MinTimeProperty =
            DependencyProperty.Register("MinTime", typeof(DateTime), typeof(Clock), new PropertyMetadata(default(DateTime), OnMinTimeChanged, OnMinTimeCoerceValue));
        #endregion

        #region ControlButtonStyle


        public Style ControlButtonStyle
        {
            get { return (Style)GetValue(ControlButtonStyleProperty); }
            set { SetValue(ControlButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ControlButtonStyleProperty =
            DependencyProperty.Register("ControlButtonStyle", typeof(Style), typeof(Clock));


        #endregion

        #region ClockItemStyle


        public Style ClockItemStyle
        {
            get { return (Style)GetValue(ClockItemStyleProperty); }
            set { SetValue(ClockItemStyleProperty, value); }
        }

        public static readonly DependencyProperty ClockItemStyleProperty =
            DependencyProperty.Register("ClockItemStyle", typeof(Style), typeof(Clock));


        #endregion

        #region ThemeBrush


        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(Clock));
        #endregion

        #endregion

        #region Internal Properties

        #region Hour
        internal int Hour
        {
            get { return (int)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        internal static readonly DependencyProperty HourProperty =
            DependencyProperty.Register("Hour", typeof(int), typeof(Clock));
        #endregion

        #region Minute
        internal int Minute
        {
            get { return (int)GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        internal static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register("Minute", typeof(int), typeof(Clock));
        #endregion

        #region Second
        internal int Second
        {
            get { return (int)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        internal static readonly DependencyProperty SecondProperty =
            DependencyProperty.Register("Second", typeof(int), typeof(Clock));
        #endregion

        #endregion

        #region Event Handler
        private static object OnMinTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var calendar = d as Clock;
            var minTime = (DateTime)baseValue;
            if (calendar.MaxTime != null)
            {
                var maxTime = (DateTime)calendar.MaxTime;
                if (minTime.Time() > maxTime.Time())
                    return maxTime;
            }
            return minTime;
        }

        private static void OnMinTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SelectedTimeProperty);
        }

        private static object OnMaxTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var calendar = d as Clock;
            var maxTime = (DateTime)baseValue;
            if (calendar.MinTime != null)
            {
                var minTime = (DateTime)calendar.MinTime;
                if (maxTime.Time() < minTime.Time())
                    return minTime;
            }
            return maxTime;
        }

        private static void OnMaxTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SelectedTimeProperty);
        }

        private static object OnSelectedTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var calendar = d as Clock;
            var selectedDate = (DateTime)baseValue;
            if (calendar.MinTime != null)
            {
                var minTime = (DateTime)calendar.MinTime;
                if (selectedDate.Time() < minTime.Time())
                    return minTime.Time();
            }
            if (calendar.MaxTime != null)
            {
                var maxTime = (DateTime)calendar.MaxTime;
                if (selectedDate.Time() > maxTime.Time())
                    return maxTime.Time();
            }
            return selectedDate.Time();
        }

        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Clock;
            if (!calendar.IsLoaded)
            {
                return;
            }
            var newTime = (DateTime)e.NewValue;
            calendar.UpdateClock(newTime);
            calendar.RaiseSelectedTimeChanged(newTime);
        }

        #endregion

        #region Methods
        #endregion

        #region Function
        private void UpdateClock(DateTime newTime)
        {
            Hour = newTime.Hour;
            Minute = newTime.Minute;
            Second = newTime.Second;
        }
        #endregion
    }
}
