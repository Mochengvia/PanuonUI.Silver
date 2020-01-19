using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Clock : Control
    {
        #region Fields
        private RadioButton _amRadioButton;

        private RadioButton _pmRadioButton;

        private ClockItem _hourClockItem;

        private ClockItem _minuteClockItem;

        private ClockItem _secondClockItem;
        #endregion

        #region Ctor
        public Clock()
        {
            AddHandler(ClockItem.MouseLeftButtonDownEvent, new RoutedEventHandler(OnClockItemMouseLeftDown));
            AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(OnRadioButtonClicked));
            MouseMove += Clock_MouseMove;
            Loaded += Clock_Loaded;
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
        public DateTime? MaxTime
        {
            get { return (DateTime?)GetValue(MaxTimeProperty); }
            set { SetValue(MaxTimeProperty, value); }
        }

        public static readonly DependencyProperty MaxTimeProperty =
            DependencyProperty.Register("MaxTime", typeof(DateTime?), typeof(Clock), new PropertyMetadata(null, OnMaxTimeChanged, OnMaxTimeCoerceValue));
        #endregion

        #region MinTime
        public DateTime? MinTime
        {
            get { return (DateTime?)GetValue(MinTimeProperty); }
            set { SetValue(MinTimeProperty, value); }
        }

        public static readonly DependencyProperty MinTimeProperty =
            DependencyProperty.Register("MinTime", typeof(DateTime?), typeof(Clock), new PropertyMetadata(null, OnMinTimeChanged, OnMinTimeCoerceValue));
        #endregion

        #region TimeInputStyle


        public Style TimeInputStyle
        {
            get { return (Style)GetValue(TimeInputStyleProperty); }
            set { SetValue(TimeInputStyleProperty, value); }
        }

        public static readonly DependencyProperty TimeInputStyleProperty =
            DependencyProperty.Register("TimeInputStyle", typeof(Style), typeof(Clock));


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

        #region TimePeriod
        public TimePeriod TimePeriod
        {
            get { return (TimePeriod)GetValue(TimePeriodProperty); }
            set { SetValue(TimePeriodProperty, value); }
        }

        public static readonly DependencyProperty TimePeriodProperty =
            DependencyProperty.Register("TimePeriod", typeof(TimePeriod), typeof(Clock), new PropertyMetadata(OnTimePeriodChanged));

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

        #region CanInputTime
        public bool CanInputTime
        {
            get { return (bool)GetValue(CanInputTimeProperty); }
            set { SetValue(CanInputTimeProperty, value); }
        }

        public static readonly DependencyProperty CanInputTimeProperty =
            DependencyProperty.Register("CanInputTime", typeof(bool), typeof(Clock));
        #endregion

        #region CanSelectTimePeriod
        public bool CanSelectTimePeriod
        {
            get { return (bool)GetValue(CanSelectTimePeriodProperty); }
            set { SetValue(CanSelectTimePeriodProperty, value); }
        }

        public static readonly DependencyProperty CanSelectTimePeriodProperty =
            DependencyProperty.Register("CanSelectTimePeriod", typeof(bool), typeof(Clock));
        #endregion

        #endregion

        #region Internal Properties

        #region HourAngle
        internal int HourAngle
        {
            get { return (int)GetValue(HourAngleProperty); }
            set { SetValue(HourAngleProperty, value); }
        }

        internal static readonly DependencyProperty HourAngleProperty =
            DependencyProperty.Register("HourAngle", typeof(int), typeof(Clock));
        #endregion

        #region Hour
        internal int Hour
        {
            get { return (int)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        internal static readonly DependencyProperty HourProperty =
            DependencyProperty.Register("Hour", typeof(int), typeof(Clock), new PropertyMetadata(1, OnHourChanged, OnHourCoerceValue));
        #endregion

        #region MinuteAngle


        internal int MinuteAngle
        {
            get { return (int)GetValue(MinuteAngleProperty); }
            set { SetValue(MinuteAngleProperty, value); }
        }

        internal static readonly DependencyProperty MinuteAngleProperty =
            DependencyProperty.Register("MinuteAngle", typeof(int), typeof(Clock));
        #endregion

        #region Minute


        internal int Minute
        {
            get { return (int)GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        internal static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register("Minute", typeof(int), typeof(Clock), new PropertyMetadata(1, OnMinuteChanged, OnMinuteCoerceValue));

        #endregion

        #region SecondAngle
        internal int SecondAngle
        {
            get { return (int)GetValue(SecondAngleProperty); }
            set { SetValue(SecondAngleProperty, value); }
        }

        internal static readonly DependencyProperty SecondAngleProperty =
            DependencyProperty.Register("SecondAngle", typeof(int), typeof(Clock));
        #endregion

        #region Second
        internal int Second
        {
            get { return (int)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        internal static readonly DependencyProperty SecondProperty =
            DependencyProperty.Register("Second", typeof(int), typeof(Clock), new PropertyMetadata(1, OnSecondChanged, OnSecondCoerceValue));
        #endregion

        #endregion

        #region Event Handler

        private static void OnHourChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clock = d as Clock;
            var hour = clock.Hour;
            if(clock.SelectedTime.Hour != hour)
            {
                clock.SelectedTime = new DateTime(1, 1, 1, hour, clock.SelectedTime.Minute, clock.SelectedTime.Second);
            }
        }

        private static object OnHourCoerceValue(DependencyObject d, object baseValue)
        {
            var value = (int)baseValue;
            if(value < 0)
            {
                return 0;
            }
            else if(value > 23)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }


        private static object OnMinuteCoerceValue(DependencyObject d, object baseValue)
        {
            var value = (int)baseValue;
            if (value < 0)
            {
                return 0;
            }
            else if (value > 59)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        private static void OnMinuteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clock = d as Clock;
            var minute = clock.Minute;
            if (clock.SelectedTime.Minute != minute)
            {
                clock.SelectedTime = new DateTime(1, 1, 1, clock.SelectedTime.Hour, minute, clock.SelectedTime.Second);
            }
        }

        private static object OnSecondCoerceValue(DependencyObject d, object baseValue)
        {
            var value = (int)baseValue;
            if (value < 0)
            {
                return 0;
            }
            else if (value > 59)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }

        private static void OnSecondChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clock = d as Clock;
            var second = clock.Second;
            if (clock.SelectedTime.Second != second)
            {
                clock.SelectedTime = new DateTime(1, 1, 1, clock.SelectedTime.Hour, clock.SelectedTime.Minute, second);
            }
        }

        private void OnRadioButtonClicked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if(radioButton == null)
            {
                return;
            }

            switch (radioButton.Name)
            {
                case "PART_RdbPM":
                    TimePeriod = TimePeriod.PM;
                    break;
                default:
                    TimePeriod = TimePeriod.AM;
                    break;
            }
        }

        private static void OnTimePeriodChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clock = d as Clock;
            if (!clock.IsLoaded)
            {
                return;
            }
            clock.UpdatePeriods();
        }

        private void Clock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var center = new Point(ActualWidth / 2, ActualHeight / 2);
            var point = Mouse.GetPosition(this);
            var angle = Math.Atan2(point.Y - center.Y, point.X - center.X) * (180 / Math.PI)  + 90;
            if (angle < 0)
                angle += 360;

            if (_hourClockItem.Hooked)
            {
                var percent = angle / 30;
                var hour = Math.Floor(percent);
                hour = (percent - hour) > 0.5 ? hour + 1 : hour;
                hour = hour >= 12 ? 0 : hour;
                hour = TimePeriod == TimePeriod.AM ? hour : hour + 12;
                SelectedTime = new DateTime(1, 1, 1, (int)hour, SelectedTime.Minute, SelectedTime.Second);
            }
            else if (_minuteClockItem.Hooked)
            {
                var percent = angle / 6;
                var minute = Math.Floor(percent);
                minute = (percent - minute) > 0.5 ? minute + 1 : minute;
                minute = minute >= 60 ? 0 : minute;
                SelectedTime = new DateTime(1, 1, 1, SelectedTime.Hour, (int)minute, SelectedTime.Second);
            }
            else if (_secondClockItem.Hooked)
            {
                var percent = angle / 6;
                var second = Math.Floor(percent);
                second = (percent - second) > 0.5 ? second + 1 : second;
                second = second >= 60 ? 0 : second;
                SelectedTime = new DateTime(1, 1, 1, SelectedTime.Hour, SelectedTime.Minute, (int)second);
            }
        }

        private void Clock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.Source is ClockItem) 
            {
                return;
            }
            _hourClockItem.Hooked = false;
            _minuteClockItem.Hooked = false;
            _secondClockItem.Hooked = false;

        }

        private void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            var grdDial = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 0), 0) as Grid;
            grdDial.MouseDown += Clock_MouseDown;
            _hourClockItem = VisualTreeHelper.GetChild(grdDial, 1) as ClockItem;
            _minuteClockItem = VisualTreeHelper.GetChild(grdDial, 2) as ClockItem; 
            _secondClockItem = VisualTreeHelper.GetChild(grdDial, 3) as ClockItem;
            var stkPeriod = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 1) as StackPanel;
            _amRadioButton = VisualTreeHelper.GetChild(stkPeriod, 0) as RadioButton;
            _pmRadioButton = VisualTreeHelper.GetChild(stkPeriod, 1) as RadioButton;
            UpdateClock(SelectedTime);
            UpdatePeriods();
        }

        private static object OnMinTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var clock = d as Clock;
            var minTime = (DateTime)baseValue;
            if (clock.MaxTime != null)
            {
                var maxTime = (DateTime)clock.MaxTime;
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
            var clock = d as Clock;
            var maxTime = (DateTime)baseValue;
            if (clock.MinTime != null)
            {
                var minTime = (DateTime)clock.MinTime;
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
            var clock = d as Clock;
            var selectedDate = (DateTime)baseValue;
            if (clock.MinTime != null)
            {
                var minTime = (DateTime)clock.MinTime;
                if (selectedDate.Time() < minTime.Time())
                    return minTime.Time();
            }
            if (clock.MaxTime != null)
            {
                var maxTime = (DateTime)clock.MaxTime;
                if (selectedDate.Time() > maxTime.Time())
                    return maxTime.Time();
            }
            return selectedDate.Time();
        }

        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clock = d as Clock;
            var newTime = (DateTime)e.NewValue;
            clock.Hour = newTime.Hour;
            clock.Minute = newTime.Minute;
            clock.Second = newTime.Second;
            clock.TimePeriod = newTime.Hour >= 12 ? TimePeriod.PM : TimePeriod.AM;
            if (!clock.IsLoaded)
            {
                return;
            }
            clock.UpdateClock(newTime);
            clock.UpdatePeriods();
            clock.RaiseSelectedTimeChanged(newTime);
        }

        private void OnClockItemMouseLeftDown(object sender, RoutedEventArgs e)
        {
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        private void UpdateClock(DateTime newTime)
        {
            var hour = newTime.Hour;
            hour = hour >= 12 ? hour - 12 : hour;
            HourAngle = hour * 30;
            MinuteAngle = newTime.Minute * 6;
            SecondAngle = newTime.Second * 6;
        }

        private void UpdatePeriods()
        {
            var hour = SelectedTime.Hour;
            switch (TimePeriod)
            {
                case TimePeriod.AM:
                    if (_amRadioButton.IsChecked != true)
                    {
                        _amRadioButton.IsChecked = true;
                    }
                    if(hour >= 12)
                    {
                        hour -= 12;
                        SelectedTime = new DateTime(1, 1, 1, hour, SelectedTime.Minute, SelectedTime.Second);
                    }
                    break;
                case TimePeriod.PM:
                    if (_pmRadioButton.IsChecked != true)
                    {
                        _pmRadioButton.IsChecked = true;
                    }
                    if(hour < 12)
                    {
                        hour += 12;
                        SelectedTime = new DateTime(1, 1, 1, hour, SelectedTime.Minute, SelectedTime.Second);
                    }
                    break;
            }
        }
        #endregion
    }
}
