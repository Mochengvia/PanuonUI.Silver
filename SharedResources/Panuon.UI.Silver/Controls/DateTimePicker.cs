using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class DateTimePicker : Control
    {
        #region Fields
        private CalendarX _calendarX;

        private TimeSelector _timeSelector;

        private Button _clearButton;

        private bool _isInternalSet;
        #endregion

        #region Ctor
        static DateTimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimePicker), new FrameworkPropertyMetadata(typeof(DateTimePicker)));
        }
        #endregion

        #region Overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _calendarX = Template?.FindName("PART_CalendarX", this) as CalendarX;
            _calendarX.SelectedDateChanged += CalendarX_SelectedDateChanged;
            _timeSelector = Template?.FindName("PART_TimeSelector", this) as TimeSelector;
            _timeSelector.SelectedTimeChanged += TimeSelector_SelectedTimeChanged;
            _clearButton = Template?.FindName("PART_ClearButton", this) as Button;
            _clearButton.Click += ClearButton_Click;

            LimitCalendarXDate();
            LimitTimeSelectorTime();
        }

        #endregion

        #region Properties

        #region Icon
        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(DateTimePicker));
        #endregion

        #region Watermark
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(DateTimePicker));
        #endregion

        #region IsDropDownOpen
        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }

        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(DateTimePicker));
        #endregion

        #region ToggleArrow
        public ToggleArrow ToggleArrow
        {
            get { return (ToggleArrow)GetValue(ToggleArrowProperty); }
            set { SetValue(ToggleArrowProperty, value); }
        }

        public static readonly DependencyProperty ToggleArrowProperty =
            DependencyProperty.Register("ToggleArrow", typeof(ToggleArrow), typeof(DateTimePicker));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DateTimePicker));
        #endregion

        #region SeparatorBrush
        public Brush SeparatorBrush
        {
            get { return (Brush)GetValue(SeparatorBrushProperty); }
            set { SetValue(SeparatorBrushProperty, value); }
        }

        public static readonly DependencyProperty SeparatorBrushProperty =
            DependencyProperty.Register("SeparatorBrush", typeof(Brush), typeof(DateTimePicker));
        #endregion

        #region MaxDropDownHeight
        public double MaxDropDownHeight
        {
            get { return (double)GetValue(MaxDropDownHeightProperty); }
            set { SetValue(MaxDropDownHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxDropDownHeightProperty =
            DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(DateTimePicker));
        #endregion

        #region DropDownCornerRadius
        public CornerRadius DropDownCornerRadius
        {
            get { return (CornerRadius)GetValue(DropDownCornerRadiusProperty); }
            set { SetValue(DropDownCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.Register("DropDownCornerRadius", typeof(CornerRadius), typeof(DateTimePicker));
        #endregion

        #region DropDownShadowColor
        public Color? DropDownShadowColor
        {
            get { return (Color?)GetValue(DropDownShadowColorProperty); }
            set { SetValue(DropDownShadowColorProperty, value); }
        }

        public static readonly DependencyProperty DropDownShadowColorProperty =
            DependencyProperty.Register("DropDownShadowColor", typeof(Color?), typeof(DateTimePicker));
        #endregion

        #region DropDownPadding
        public Thickness DropDownPadding
        {
            get { return (Thickness)GetValue(DropDownPaddingProperty); }
            set { SetValue(DropDownPaddingProperty, value); }
        }

        public static readonly DependencyProperty DropDownPaddingProperty =
            DependencyProperty.Register("DropDownPadding", typeof(Thickness), typeof(DateTimePicker));
        #endregion

        #region TextStringFormat
        public string TextStringFormat
        {
            get { return (string)GetValue(TextStringFormatProperty); }
            set { SetValue(TextStringFormatProperty, value); }
        }

        public static readonly DependencyProperty TextStringFormatProperty =
            DependencyProperty.Register("TextStringFormat", typeof(string), typeof(DateTimePicker));
        #endregion

        #region Mode
        public DateTimePickerMode Mode
        {
            get { return (DateTimePickerMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(DateTimePickerMode), typeof(DateTimePicker));
        #endregion

        #region SelectedDateTime
        public DateTime? SelectedDateTime
        {
            get { return (DateTime?)GetValue(SelectedDateTimeProperty); }
            set { SetValue(SelectedDateTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateTimeProperty =
            DependencyProperty.Register("SelectedDateTime", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(OnSelectedDateTimeChanged));

        #endregion

        //#region SelectedDateTimes
        //public ObservableCollection<DateTime> SelectedDateTimes
        //{
        //    get { return (ObservableCollection<DateTime>)GetValue(SelectedDateTimesProperty); }
        //    set { SetValue(SelectedDateTimesProperty, value); }
        //}

        //public static readonly DependencyProperty SelectedDateTimesProperty =
        //    DependencyProperty.Register("SelectedDateTimes", typeof(ObservableCollection<DateTime>), typeof(DateTimePicker));
        //#endregion

        #region MinDateTime
        public DateTime? MinDateTime
        {
            get { return (DateTime?)GetValue(MinDateTimeProperty); }
            set { SetValue(MinDateTimeProperty, value); }
        }

        public static readonly DependencyProperty MinDateTimeProperty =
            DependencyProperty.Register("MinDateTime", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(OnMinDateTimeChanged));
        #endregion

        #region MaxDateTime
        public DateTime? MaxDateTime
        {
            get { return (DateTime?)GetValue(MaxDateTimeProperty); }
            set { SetValue(MaxDateTimeProperty, value); }
        }

        public static readonly DependencyProperty MaxDateTimeProperty =
            DependencyProperty.Register("MaxDateTime", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(OnMaxDateTimeChanged));

        #endregion

        #region IsTodayHighlighted
        public bool IsTodayHighlighted
        {
            get { return (bool)GetValue(IsTodayHighlightedProperty); }
            set { SetValue(IsTodayHighlightedProperty, value); }
        }

        public static readonly DependencyProperty IsTodayHighlightedProperty =
            DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(DateTimePicker));
        #endregion

        #region IsEditable
        public bool IsEditable
        {
            get { return (bool)GetValue(IsEditableProperty); }
            set { SetValue(IsEditableProperty, value); }
        }

        public static readonly DependencyProperty IsEditableProperty =
            DependencyProperty.Register("IsEditable", typeof(bool), typeof(DateTimePicker));
        #endregion

        #region IsReadOnly
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(DateTimePicker));
        #endregion

        #region CanClear
        public bool CanClear
        {
            get { return (bool)GetValue(CanClearProperty); }
            set { SetValue(CanClearProperty, value); }
        }

        public static readonly DependencyProperty CanClearProperty =
            DependencyProperty.Register("CanClear", typeof(bool), typeof(DateTimePicker));
        #endregion

        #region CalendarXStyle
        public Style CalendarXStyle
        {
            get { return (Style)GetValue(CalendarXStyleProperty); }
            set { SetValue(CalendarXStyleProperty, value); }
        }

        public static readonly DependencyProperty CalendarXStyleProperty =
            DependencyProperty.Register("CalendarXStyle", typeof(Style), typeof(DateTimePicker));
        #endregion

        #region TimeSelectorStyle
        public Style TimeSelectorStyle
        {
            get { return (Style)GetValue(TimeSelectorStyleProperty); }
            set { SetValue(TimeSelectorStyleProperty, value); }
        }

        public static readonly DependencyProperty TimeSelectorStyleProperty =
            DependencyProperty.Register("TimeSelectorStyle", typeof(Style), typeof(DateTimePicker));
        #endregion

        #endregion

        #region Internal Properties

        #region CalendarXSelectedDate
        #endregion

        #region CalendarXMaxDate
        #endregion

        #region CalendarXMinDate
        #endregion

        #endregion

        #region Event Handlers

        private static void OnMinDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as DateTimePicker;
            picker.LimitCalendarXDate();
            picker.LimitTimeSelectorTime();
        }

        private static void OnMaxDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as DateTimePicker;
            picker.LimitCalendarXDate();
            picker.LimitTimeSelectorTime();
        }

        private static void OnSelectedDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as DateTimePicker;
            picker.OnSelectedDateTimeChanged();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _isInternalSet = true;
            SelectedDateTime = null;
            _isInternalSet = false;
        }

        private void TimeSelector_SelectedTimeChanged(object sender, Core.SelectedDateChangedRoutedEventArgs e)
        {
            _isInternalSet = true;
            var time = _timeSelector.SelectedTime;
            switch (Mode)
            {
                case DateTimePickerMode.Time:
                    SelectedDateTime = new DateTime(1, 1, 1, time.Hour, time.Minute, time.Second);
                    break;
                case DateTimePickerMode.DateTime:
                    if (_calendarX.SelectedDate == null)
                    {
                        SelectedDateTime = null;
                    }
                    else
                    {
                        var date = (DateTime)_calendarX.SelectedDate;
                        SelectedDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                    }
                    break;
            }
           
            _isInternalSet = false;
        }

        private void CalendarX_SelectedDateChanged(object sender, Core.SelectedDateChangedRoutedEventArgs e)
        {
            _isInternalSet = true;
            if (_calendarX.SelectedDate == null)
            {
                SelectedDateTime = null;
            }
            else
            {
                var date = (DateTime)_calendarX.SelectedDate;
                var time = _timeSelector.SelectedTime;
                SelectedDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            }
            LimitTimeSelectorTime();
            _isInternalSet = false;
        }
        #endregion

        #region Functions 
        private void LimitTimeSelectorTime()
        {
            if (_timeSelector == null)
            {
                return;
            }

            if (MinDateTime == null)
            {
                _timeSelector.MinTime = null;
            }
            else
            {
                var minDateTime = (DateTime)MinDateTime;
                if (Mode == DateTimePickerMode.Time|| (_calendarX.SelectedDate != null && minDateTime.Date.Equals(((DateTime)_calendarX.SelectedDate).Date)))
                {
                    if (_timeSelector.MinTime == null)
                    {
                        _timeSelector.MinTime = new DateTime(1, 1, 1, minDateTime.Hour, minDateTime.Minute, minDateTime.Second);
                    }
                    else
                    {
                        var minTime = (DateTime)_timeSelector.MinTime;
                        if (minTime.Hour != minDateTime.Hour || minTime.Minute != minDateTime.Minute || minTime.Second == minDateTime.Second)
                        {
                            _timeSelector.MinTime = new DateTime(1, 1, 1, minDateTime.Hour, minDateTime.Minute, minDateTime.Second);
                        }
                    }
                }
                else
                {
                    _timeSelector.MinTime = null;
                }
            }

            if (MaxDateTime == null)
            {
                _timeSelector.MaxTime = null;
            }
            else
            {
                var maxDateTime = (DateTime)MaxDateTime;
                if (Mode == DateTimePickerMode.Time || (_calendarX.SelectedDate != null && maxDateTime.Date.Equals(((DateTime)_calendarX.SelectedDate).Date)))
                {

                    if (_timeSelector.MaxTime == null)
                    {
                        _timeSelector.MaxTime = new DateTime(1, 1, 1, maxDateTime.Hour, maxDateTime.Minute, maxDateTime.Second);
                    }
                    else
                    {
                        var maxTime = (DateTime)_timeSelector.MaxTime;
                        if (maxTime.Hour != maxDateTime.Hour || maxTime.Minute != maxDateTime.Minute || maxTime.Second == maxDateTime.Second)
                        {
                            _timeSelector.MaxTime = new DateTime(1, 1, 1, maxDateTime.Hour, maxDateTime.Minute, maxDateTime.Second);
                        }
                    }
                }
                else
                {
                    _timeSelector.MaxTime = null;
                }
            }
        }

        private void LimitCalendarXDate()
        {
            if (_calendarX == null)
            {
                return;
            }

            if (MinDateTime == null)
            {
                _calendarX.MinDate = null;
            }
            else
            {
                var minDateTime = (DateTime)MinDateTime;
                _calendarX.MinDate = minDateTime.Date;
            }

            if (MaxDateTime == null)
            {
                _calendarX.MaxDate = null;
            }
            else
            {
                var maxDateTime = (DateTime)MaxDateTime;
                _calendarX.MaxDate = maxDateTime.Date;
            }
        }

        private void OnSelectedDateTimeChanged()
        {
            if (_calendarX == null || _timeSelector == null)
            {
                return;
            }

            if (SelectedDateTime == null)
            {
                _calendarX.SelectedDate = null;
                _timeSelector.SelectedTime = new DateTime(1, 1, 1);
            }
            else
            {
                var dateTime = (DateTime)SelectedDateTime;
                _calendarX.SelectedDate = dateTime.Date;
                _timeSelector.SelectedTime = new DateTime(1, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second);
            }
        }
        #endregion
    }
}
