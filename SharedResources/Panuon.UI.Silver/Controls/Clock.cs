using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private const string _CLOCK_GROUP_SECONDS = "CLOCK_GROUP_SECONDS";
        private const string _CLOCK_GROUP_MINUTES = "CLOCK_GROUP_MINUTES";
        private const string _CLOCK_GROUP_HOURS = "CLOCK_GROUP_HOURS";
        #endregion

        #region Ctor
        static Clock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock), new FrameworkPropertyMetadata(typeof(Clock)));
        }

        public Clock()
        {
            AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(OnRadioButtonClicked));
            Hours = new ObservableCollection<ClockModelItem>();
            Minutes = new ObservableCollection<ClockModelItem>();
            Seconds = new ObservableCollection<ClockModelItem>();
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
            DependencyProperty.Register("SelectedTime", typeof(DateTime), typeof(Clock), new FrameworkPropertyMetadata(default(DateTime), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedTimeChanged, OnSelectedTimeCoerceValue));
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

        #region ClockItemStyle


        public Style ClockItemStyle
        {
            get { return (Style)GetValue(ClockItemStyleProperty); }
            set { SetValue(ClockItemStyleProperty, value); }
        }

        public static readonly DependencyProperty ClockItemStyleProperty =
            DependencyProperty.Register("ClockItemStyle", typeof(Style), typeof(Clock));


        #endregion

        #endregion

        #region Internal Properties

        #region Hours
        internal ObservableCollection<ClockModelItem> Hours
        {
            get { return (ObservableCollection<ClockModelItem>)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }

        internal static readonly DependencyProperty HoursProperty =
            DependencyProperty.Register("Hours", typeof(ObservableCollection<ClockModelItem>), typeof(Clock));
        #endregion

        #region Minutes
        internal ObservableCollection<ClockModelItem> Minutes
        {
            get { return (ObservableCollection<ClockModelItem>)GetValue(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }

        internal static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register("Minutes", typeof(ObservableCollection<ClockModelItem>), typeof(Clock));
        #endregion

        #region Seconds
        internal ObservableCollection<ClockModelItem> Seconds
        {
            get { return (ObservableCollection<ClockModelItem>)GetValue(SecondsProperty); }
            set { SetValue(SecondsProperty, value); }
        }

        internal static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register("Seconds", typeof(ObservableCollection<ClockModelItem>), typeof(Clock));
        #endregion

        #endregion

        #region Event Handler


        private void OnRadioButtonClicked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if (radioButton == null)
            {
                return;
            }
            var groupName = radioButton.GroupName;
            switch (groupName)
            {
                case _CLOCK_GROUP_SECONDS:
                    var seconds = (int)radioButton.Tag;
                    if (seconds != SelectedTime.Second)
                    {
                        SelectedTime = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, SelectedTime.Hour, SelectedTime.Minute, seconds);
                    }
                    break;
                case _CLOCK_GROUP_MINUTES:
                    var minutes = (int)radioButton.Tag;
                    if (minutes != SelectedTime.Minute)
                    {
                        SelectedTime = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, SelectedTime.Hour, minutes, SelectedTime.Second);
                    }
                    break;
                case _CLOCK_GROUP_HOURS:
                    var hours = (int)radioButton.Tag;
                    if (hours != SelectedTime.Hour)
                    {
                        SelectedTime = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, hours, SelectedTime.Minute, SelectedTime.Second);
                    }
                    break;

            }
        }



        private void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateClock();
        }

        private static object OnMinTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var Clock = d as Clock;
            if (baseValue == null)
            {
                return null;
            }
            var minTime = (DateTime)baseValue;
            if (Clock.MaxTime != null)
            {
                var maxTime = (DateTime)Clock.MaxTime;
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
            var Clock = d as Clock;
            if (baseValue == null)
            {
                return null;
            }
            var maxTime = (DateTime)baseValue;
            if (Clock.MinTime != null)
            {
                var minTime = (DateTime)Clock.MinTime;
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
            var Clock = d as Clock;
            var selectedDate = (DateTime)baseValue;
            if (Clock.MinTime != null)
            {
                var minTime = (DateTime)Clock.MinTime;
                if (selectedDate.Time() < minTime.Time())
                    return minTime.Time();
            }
            if (Clock.MaxTime != null)
            {
                var maxTime = (DateTime)Clock.MaxTime;
                if (selectedDate.Time() > maxTime.Time())
                    return maxTime.Time();
            }
            return selectedDate.Time();
        }

        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Clock = d as Clock;
            var newDate = (DateTime)e.NewValue;
            var oldDate = (DateTime)e.OldValue;
            Clock.UpdateClock(oldDate, newDate);
            Clock.RaiseSelectedTimeChanged(newDate);
        }

        #endregion

        #region Methods
        #endregion

        #region Function
        private void UpdateClock()
        {
            LoadOrUpdateHours();
            LoadOrUpdateMinutes();
            LoadOrUpdateSeconds();
        }

        private void UpdateClock(DateTime oldDate, DateTime newDate)
        {
            if (newDate.Hour == oldDate.Hour)
            {
                if (newDate.Minute == oldDate.Minute)
                {
                    if (newDate.Second != oldDate.Second)
                    {
                        LoadOrUpdateSeconds();
                    }
                }
                else
                {
                    LoadOrUpdateSeconds();
                    LoadOrUpdateMinutes();
                }
            }
            else
            {
                LoadOrUpdateSeconds();
                LoadOrUpdateMinutes();
                LoadOrUpdateHours();
            }
        }


        private void LoadOrUpdateHours()
        {
            for (int i = 0; i < 24; i++)
            {
                if (Hours.Count <= i)
                {
                    var ClockItem = new ClockModelItem()
                    {
                        Value = i,
                        DisplayName = i.ToString(),
                        IsEnabled = IsHourValidated(i),
                        IsChecked = i == SelectedTime.Hour,
                    };
                    Hours.Add(ClockItem);
                }
                else
                {
                    var ClockItem = Hours[i];
                    ClockItem.Value = i;
                    ClockItem.DisplayName = i.ToString();
                    ClockItem.IsEnabled = IsHourValidated(i);
                    ClockItem.IsChecked = i == SelectedTime.Hour;
                }
            }
        }

        private void LoadOrUpdateMinutes()
        {
            for (int i = 0; i < 60; i++)
            {
                if (Minutes.Count <= i)
                {
                    var ClockItem = new ClockModelItem()
                    {
                        Value = i,
                        DisplayName = i.ToString(),
                        IsEnabled = IsMinuteValidated(SelectedTime.Hour, i),
                        IsChecked = i == SelectedTime.Minute,
                    };
                    Minutes.Add(ClockItem);
                }
                else
                {
                    var ClockItem = Minutes[i];
                    ClockItem.Value = i;
                    ClockItem.DisplayName = i.ToString();
                    ClockItem.IsEnabled = IsMinuteValidated(SelectedTime.Hour, i);
                    ClockItem.IsChecked = i == SelectedTime.Minute;
                }
            }
        }

        private void LoadOrUpdateSeconds()
        {
            for (int i = 0; i < 60; i++)
            {
                if (Seconds.Count <= i)
                {
                    var ClockItem = new ClockModelItem()
                    {
                        Value = i,
                        DisplayName = i.ToString(),
                        IsEnabled = IsSecondValidated(SelectedTime.Hour, SelectedTime.Minute, i),
                        IsChecked = i == SelectedTime.Second,
                    };
                    Seconds.Add(ClockItem);
                }
                else
                {
                    var ClockItem = Seconds[i];
                    ClockItem.Value = i;
                    ClockItem.DisplayName = i.ToString();
                    ClockItem.IsEnabled = IsSecondValidated(SelectedTime.Hour, SelectedTime.Minute, i);
                    ClockItem.IsChecked = i == SelectedTime.Second;
                }
            }
        }

        private bool IsHourValidated(int hour)
        {
            if (MaxTime.HasValue)
            {
                if (hour > MaxTime.Value.Hour)
                {
                    return false;
                }
            }
            if (MinTime.HasValue)
            {
                if (hour < MinTime.Value.Minute)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsMinuteValidated(int currentHour, int minute)
        {
            if (MaxTime.HasValue)
            {
                if (currentHour > MaxTime.Value.Hour)
                {
                    return false;
                }
                else if (currentHour == MaxTime.Value.Hour && minute > MaxTime.Value.Hour)
                {
                    return false;
                }
            }
            if (MinTime.HasValue)
            {
                if (currentHour < MinTime.Value.Hour)
                {
                    return false;
                }
                else if (currentHour == MinTime.Value.Hour && minute < MinTime.Value.Hour)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSecondValidated(int currentHour, int currentMinute, int minute)
        {
            if (MaxTime.HasValue)
            {
                if (currentHour > MaxTime.Value.Hour)
                {
                    return false;
                }
                else if (currentHour == MaxTime.Value.Hour && currentMinute > MaxTime.Value.Minute)
                {
                    return false;
                }
                else if (currentHour == MaxTime.Value.Hour && currentMinute == MaxTime.Value.Minute && minute > MaxTime.Value.Hour)
                {
                    return false;
                }
            }
            if (MinTime.HasValue)
            {
                if (currentHour < MinTime.Value.Hour)
                {
                    return false;
                }
                else if (currentHour == MinTime.Value.Hour && currentMinute < MinTime.Value.Minute)
                {
                    return false;
                }
                if (currentHour == MinTime.Value.Hour && currentMinute == MinTime.Value.Minute && minute < MinTime.Value.Hour)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
