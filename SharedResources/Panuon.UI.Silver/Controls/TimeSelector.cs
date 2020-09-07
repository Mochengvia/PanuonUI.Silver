using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Controls;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TimeSelector : Control
    {
        #region Fields
        private TimeSelectorSecondPresenter _secondPresenter;

        private TimeSelectorMinutePresenter _minutePresenter;

        private TimeSelectorHourPresenter _hourPresenter;

        private bool _isInternalSet;
        #endregion

        #region Ctor
        static TimeSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeSelector), new FrameworkPropertyMetadata(typeof(TimeSelector)));
        }
        #endregion

        #region Events
        public event SelectedDateChangedRoutedEventHandler SelectedTimeChanged
        {
            add { AddHandler(SelectedTimeChangedEvent, value); }
            remove { RemoveHandler(SelectedTimeChangedEvent, value); }
        }

        public static readonly RoutedEvent SelectedTimeChangedEvent =
            EventManager.RegisterRoutedEvent("SelectedTimeChanged", RoutingStrategy.Bubble, typeof(SelectedDateChangedRoutedEventHandler), typeof(CalendarX));

        #endregion

        #region Overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _secondPresenter = Template?.FindName("PART_SecondPresenter", this) as TimeSelectorSecondPresenter;
            BindingUtils.BindingProperty(_secondPresenter, TimeSelectorSecondPresenter.TimeSelectorItemStyleProperty, this, TimeSelectorItemStyleProperty, BindingMode.OneWay, UpdateSourceTrigger.PropertyChanged);
            _minutePresenter = Template?.FindName("PART_MinutePresenter", this) as TimeSelectorMinutePresenter;
            BindingUtils.BindingProperty(_minutePresenter, TimeSelectorMinutePresenter.TimeSelectorItemStyleProperty, this, TimeSelectorItemStyleProperty, BindingMode.OneWay, UpdateSourceTrigger.PropertyChanged);
            _hourPresenter = Template?.FindName("PART_HourPresenter", this) as TimeSelectorHourPresenter;
            BindingUtils.BindingProperty(_hourPresenter, TimeSelectorHourPresenter.TimeSelectorItemStyleProperty, this, TimeSelectorItemStyleProperty, BindingMode.OneWay, UpdateSourceTrigger.PropertyChanged);

            _secondPresenter.Selected += SecondPresenter_Selected;
            _minutePresenter.Selected += MinutePresenter_Selected;
            _hourPresenter.Selected += HourPresenter_Selected;
            _hourPresenter.Unselected += HourPresenter_Unselected;

            UpdateSeconds();
            UpdateMinutes();
            UpdateHours();
        }

        #endregion

        #region Properties

        #region HeaderHeight
        public double HeaderHeight
        {
            get { return (double)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(double), typeof(TimeSelector));
        #endregion

        #region HeaderBackground
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(TimeSelector));
        #endregion

        #region SeparatorBrush
        public Brush SeparatorBrush
        {
            get { return (Brush)GetValue(SeparatorBrushProperty); }
            set { SetValue(SeparatorBrushProperty, value); }
        }

        public static readonly DependencyProperty SeparatorBrushProperty =
            DependencyProperty.Register("SeparatorBrush", typeof(Brush), typeof(TimeSelector));
        #endregion

        #region SeparatorVisibility
        public Visibility SeparatorVisibility
        {
            get { return (Visibility)GetValue(SeparatorVisibilityProperty); }
            set { SetValue(SeparatorVisibilityProperty, value); }
        }

        public static readonly DependencyProperty SeparatorVisibilityProperty =
            DependencyProperty.Register("SeparatorVisibility", typeof(Visibility), typeof(TimeSelector));
        #endregion

        #region SelectedTime
        public DateTime SelectedTime
        {
            get { return (DateTime)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(DateTime), typeof(TimeSelector), new PropertyMetadata(new DateTime(),OnSelectedTimeChanged, OnSelectedTimeCoerceValue));

        #endregion

        #region MinTime
        public DateTime? MinTime
        {
            get { return (DateTime?)GetValue(MinTimeProperty); }
            set { SetValue(MinTimeProperty, value); }
        }

        public static readonly DependencyProperty MinTimeProperty =
            DependencyProperty.Register("MinTime", typeof(DateTime?), typeof(TimeSelector), new PropertyMetadata(OnMinTimeChanged));

        #endregion

        #region MaxTime
        public DateTime? MaxTime
        {
            get { return (DateTime?)GetValue(MaxTimeProperty); }
            set { SetValue(MaxTimeProperty, value); }
        }

        public static readonly DependencyProperty MaxTimeProperty =
            DependencyProperty.Register("MaxTime", typeof(DateTime?), typeof(TimeSelector), new PropertyMetadata(OnMaxTimeChanged));

        #endregion

        #region TimeSelectorItemStyle
        public Style TimeSelectorItemStyle
        {
            get { return (Style)GetValue(TimeSelectorItemStyleProperty); }
            set { SetValue(TimeSelectorItemStyleProperty, value); }
        }

        public static readonly DependencyProperty TimeSelectorItemStyleProperty =
            DependencyProperty.Register("TimeSelectorItemStyle", typeof(Style), typeof(TimeSelector));
        #endregion

        #region HourString
        public string HourString
        {
            get { return (string)GetValue(HourStringProperty); }
            set { SetValue(HourStringProperty, value); }
        }

        public static readonly DependencyProperty HourStringProperty =
            DependencyProperty.Register("HourString", typeof(string), typeof(TimeSelector), new PropertyMetadata(LocalizationUtils.Hour));
        #endregion

        #region MinuteString
        public string MinuteString
        {
            get { return (string)GetValue(MinuteStringProperty); }
            set { SetValue(MinuteStringProperty, value); }
        }

        public static readonly DependencyProperty MinuteStringProperty =
            DependencyProperty.Register("MinuteString", typeof(string), typeof(TimeSelector), new PropertyMetadata(LocalizationUtils.Minute));
        #endregion

        #region SecondString
        public string SecondString
        {
            get { return (string)GetValue(SecondStringProperty); }
            set { SetValue(SecondStringProperty, value); }
        }

        public static readonly DependencyProperty SecondStringProperty =
            DependencyProperty.Register("SecondString", typeof(string), typeof(TimeSelector), new PropertyMetadata(LocalizationUtils.Second));
        #endregion

        #endregion

        #region Internal Properties


        #endregion

        #region Methods
        #endregion

        #region Event Handlers

        private static object OnSelectedTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var timeSelector = d as TimeSelector;
            var dateTime = (DateTime)baseValue;
            if (timeSelector.MinTime != null && dateTime < timeSelector.MinTime)
            {
                return timeSelector.MinTime;
            }
            if (timeSelector.MaxTime != null && dateTime > timeSelector.MaxTime)
            {
                return timeSelector.MaxTime;
            }
            return baseValue;
        }

        private void HourPresenter_Selected(object sender, SelectedDateChangedEventArgs e)
        {
            _isInternalSet = true; 
            SelectedTime = (DateTime)e.SelectedDate;
            _isInternalSet = false;
        }

        private void HourPresenter_Unselected(object sender, EventArgs e)
        {
            _isInternalSet = true;
            UpdateHours();
            _isInternalSet = false;
        }

        private void MinutePresenter_Selected(object sender, SelectedDateChangedEventArgs e)
        {
            _isInternalSet = true;
            SelectedTime = (DateTime)e.SelectedDate;
            _isInternalSet = false;
        }

        private void SecondPresenter_Selected(object sender, SelectedDateChangedEventArgs e)
        {
            _isInternalSet = true;
            SelectedTime = (DateTime)e.SelectedDate;
            _isInternalSet = false;
        }

        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var timeSelector = d as TimeSelector;
            if (timeSelector == null)
            {
                return;
            }
            timeSelector.OnSelectedTimeChanged();
        }

        private static void OnMaxTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var timeSelector = d as TimeSelector;
            timeSelector.OnTimeLimitChanged();
        }

        private static void OnMinTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var timeSelector = d as TimeSelector;
            timeSelector.OnTimeLimitChanged();
        }
        #endregion

        #region Functions
        private void OnTimeLimitChanged()
        {
            _isInternalSet = true;
            if(SelectedTime < MinTime)
            {
                SelectedTime = (DateTime)MinTime;
            }
            if(SelectedTime > MaxTime)
            {
                SelectedTime = (DateTime)MaxTime;
            }

            UpdateSeconds();
            UpdateMinutes();
            UpdateHours();
            _isInternalSet = false;
        }

        private void OnSelectedTimeChanged()
        {
            if (_minutePresenter == null)
            {
                return;
            }

                UpdateSeconds();
                UpdateMinutes();
                UpdateHours();
            RaiseSelectedTimeChanged();

        }
        private void UpdateSeconds()
        {
            if (_secondPresenter == null)
            {
                return;
            }
            _secondPresenter.MinTime = MinTime;
            _secondPresenter.MaxTime = MaxTime;
            _secondPresenter.Update(SelectedTime.Hour, SelectedTime.Minute, SelectedTime.Second);
        }

        private void UpdateMinutes()
        {
            if (_minutePresenter == null)
            {
                return;
            }
            _minutePresenter.MinTime = MinTime;
            _minutePresenter.MaxTime = MaxTime;
            _minutePresenter.Update(SelectedTime.Hour, SelectedTime.Minute, SelectedTime.Second);
        }

        private void UpdateHours()
        {
            if (_hourPresenter == null)
            {
                return;
            }
            _hourPresenter.MinTime = MinTime;
            _hourPresenter.MaxTime = MaxTime;
            _hourPresenter.Update(SelectedTime.Hour, SelectedTime.Minute, SelectedTime.Second);
        }

        private void RaiseSelectedTimeChanged()
        {
            RaiseEvent(new SelectedDateChangedRoutedEventArgs(SelectedTimeChangedEvent, SelectedTime));
        }
        #endregion
    }
}
