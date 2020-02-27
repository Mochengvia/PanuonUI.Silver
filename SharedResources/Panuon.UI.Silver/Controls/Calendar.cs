using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class Calendar : Control
    {
        #region Fields
        private const string _CALENDAR_GROUP_DAYS = "CALENDAR_GROUP_DAYS";
        private const string _CALENDAR_GROUP_MONTHS = "CALENDAR_GROUP_MONTHS";
        private const string _CALENDAR_GROUP_YEARS = "CALENDAR_GROUP_YEARS";
        #endregion

        #region Ctor
        static Calendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(typeof(Calendar)));
        }

        public Calendar()
        {
            AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(OnRadioButtonClicked));
            Days = new ObservableCollection<CalendarModelItem>();
            Months = new ObservableCollection<CalendarModelItem>();
            Years = new ObservableCollection<CalendarModelItem>();
            Weeks = new ObservableCollection<CalendarModelItem>();
            Loaded += Calendar_Loaded;
        }

        #endregion

        #region RoutedEvent

        #region SelectedDateChanged
        public static readonly RoutedEvent SelectedDateChangedEvent = EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Bubble, typeof(DateTimeChangedRoutedEventHandler), typeof(Calendar));
        public event DateTimeChangedRoutedEventHandler SelectedDateChanged
        {
            add { AddHandler(SelectedDateChangedEvent, value); }
            remove { RemoveHandler(SelectedDateChangedEvent, value); }
        }
        void RaiseSelectedDateChanged(DateTime newValue)
        {
            var arg = new DateTimeChangedRoutedEventArgs(newValue, SelectedDateChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Internal Event

        #region DayPanelToMonth
        public static readonly RoutedEvent DayPanelToMonthEvent = EventManager.RegisterRoutedEvent("DayPanelToMonth", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Calendar));
        public event RoutedEventHandler DayPanelToMonth
        {
            add { AddHandler(DayPanelToMonthEvent, value); }
            remove { RemoveHandler(DayPanelToMonthEvent, value); }
        }
        void RaiseDayPanelToMonth()
        {
            var arg = new RoutedEventArgs(DayPanelToMonthEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region MonthPanelToDay
        public static readonly RoutedEvent MonthPanelToDayEvent = EventManager.RegisterRoutedEvent("MonthPanelToDay", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Calendar));
        public event RoutedEventHandler MonthPanelToDay
        {
            add { AddHandler(MonthPanelToDayEvent, value); }
            remove { RemoveHandler(MonthPanelToDayEvent, value); }
        }
        void RaiseMonthPanelToDay()
        {
            var arg = new RoutedEventArgs(MonthPanelToDayEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region MonthPanelToYear
        public static readonly RoutedEvent MonthPanelToYearEvent = EventManager.RegisterRoutedEvent("MonthPanelToYear", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Calendar));
        public event RoutedEventHandler MonthPanelToYear
        {
            add { AddHandler(MonthPanelToYearEvent, value); }
            remove { RemoveHandler(MonthPanelToYearEvent, value); }
        }
        void RaiseMonthPanelToYear()
        {
            var arg = new RoutedEventArgs(MonthPanelToYearEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region YearPanelToMonth
        public static readonly RoutedEvent YearPanelToMonthEvent = EventManager.RegisterRoutedEvent("YearPanelToMonth", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Calendar));
        public event RoutedEventHandler YearPanelToMonth
        {
            add { AddHandler(YearPanelToMonthEvent, value); }
            remove { RemoveHandler(YearPanelToMonthEvent, value); }
        }
        void RaiseYearPanelToMonth()
        {
            var arg = new RoutedEventArgs(YearPanelToMonthEvent);
            RaiseEvent(arg);
        }
        #endregion

        #endregion

        #region Selected
        public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent("Selected", RoutingStrategy.Bubble, typeof(DateTimeChangedRoutedEventHandler), typeof(Calendar));
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

        #region SelectedDate
        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(Calendar), new FrameworkPropertyMetadata(default(DateTime), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedDateChanged, OnSelectedDateCoerceValue));

        #endregion

        #region ControlButtonStyle
        public Style ControlButtonStyle
        {
            get { return (Style)GetValue(ControlButtonStyleProperty); }
            set { SetValue(ControlButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ControlButtonStyleProperty =
            DependencyProperty.Register("ControlButtonStyle", typeof(Style), typeof(Calendar));
        #endregion

        #region CalendarItemStyle
        public Style CalendarItemStyle
        {
            get { return (Style)GetValue(CalendarItemStyleProperty); }
            set { SetValue(CalendarItemStyleProperty, value); }
        }

        public static readonly DependencyProperty CalendarItemStyleProperty =
            DependencyProperty.Register("CalendarItemStyle", typeof(Style), typeof(Calendar));
        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(Calendar), new PropertyMetadata(null, OnMinDateChanged, OnMinDateCoerceValue));
        #endregion

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(Calendar), new PropertyMetadata(null, OnMaxDateChanged, OnMaxDateCoerceValue));
        #endregion

        #region SelectionMode
        public CalendarSelectionMode SelectionMode
        {
            get { return (CalendarSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(CalendarSelectionMode), typeof(Calendar));
        #endregion

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(Calendar), new PropertyMetadata(OnFirstDayOfWeekChanged));

        #endregion

        #region ThemeBrush
        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(Calendar));
        #endregion

        #region HeaderPanelBackground
        public Brush HeaderPanelBackground
        {
            get { return (Brush)GetValue(HeaderPanelBackgroundProperty); }
            set { SetValue(HeaderPanelBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HeaderPanelBackgroundProperty =
            DependencyProperty.Register("HeaderPanelBackground", typeof(Brush), typeof(Calendar));
        #endregion

        #region HeaderPanelHeight
        public double HeaderPanelHeight
        {
            get { return (double)GetValue(HeaderPanelHeightProperty); }
            set { SetValue(HeaderPanelHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderPanelHeightProperty =
            DependencyProperty.Register("HeaderPanelHeight", typeof(double), typeof(Calendar));
        #endregion

        #endregion

        #region Internal Properties

        #region Days
        internal ObservableCollection<CalendarModelItem> Days
        {
            get { return (ObservableCollection<CalendarModelItem>)GetValue(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }

        internal static readonly DependencyProperty DaysProperty =
            DependencyProperty.Register("Days", typeof(ObservableCollection<CalendarModelItem>), typeof(Calendar));
        #endregion

        #region Months
        internal ObservableCollection<CalendarModelItem> Months
        {
            get { return (ObservableCollection<CalendarModelItem>)GetValue(MonthsProperty); }
            set { SetValue(MonthsProperty, value); }
        }

        internal static readonly DependencyProperty MonthsProperty =
            DependencyProperty.Register("Months", typeof(ObservableCollection<CalendarModelItem>), typeof(Calendar));
        #endregion

        #region Years
        internal ObservableCollection<CalendarModelItem> Years
        {
            get { return (ObservableCollection<CalendarModelItem>)GetValue(YearsProperty); }
            set { SetValue(YearsProperty, value); }
        }

        internal static readonly DependencyProperty YearsProperty =
            DependencyProperty.Register("Years", typeof(ObservableCollection<CalendarModelItem>), typeof(Calendar));
        #endregion

        #region Weeks
        internal ObservableCollection<CalendarModelItem> Weeks
        {
            get { return (ObservableCollection<CalendarModelItem>)GetValue(WeeksProperty); }
            set { SetValue(WeeksProperty, value); }
        }

        internal static readonly DependencyProperty WeeksProperty =
            DependencyProperty.Register("Weeks", typeof(ObservableCollection<CalendarModelItem>), typeof(Calendar));
        #endregion

        #region CurrentPanel
        internal YearMonthDay CurrentPanel
        {
            get { return (YearMonthDay)GetValue(CurrentPanelProperty); }
            set { SetValue(CurrentPanelProperty, value); }
        }

        internal static readonly DependencyProperty CurrentPanelProperty =
            DependencyProperty.Register("CurrentPanel", typeof(YearMonthDay), typeof(Calendar), new PropertyMetadata(YearMonthDay.Day, OnCurrentPanelChanged));

        private static void OnCurrentPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            if (!calendar.IsLoaded)
            {
                return;
            }
            calendar.PlayStoryboard((YearMonthDay)e.OldValue, (YearMonthDay)e.NewValue);
        }


        #endregion

        #region Commands
        internal static readonly DependencyProperty CalendarForewardCommandProperty =
            DependencyProperty.Register("CalendarForewardCommand", typeof(ICommand), typeof(Calendar), new PropertyMetadata(new RelayCommand(OnCalendarForeward)));

        internal static readonly DependencyProperty CalendarFastForewardCommandProperty =
            DependencyProperty.Register("CalendarFastForewardCommand", typeof(ICommand), typeof(Calendar), new PropertyMetadata(new RelayCommand(OnCalendarFastForeward)));

        internal static readonly DependencyProperty CalendarBackwardCommandProperty =
            DependencyProperty.Register("CalendarBackwardCommand", typeof(ICommand), typeof(Calendar), new PropertyMetadata(new RelayCommand(OnCalendarBackward)));

        internal static readonly DependencyProperty CalendarFastBackwardCommandProperty =
            DependencyProperty.Register("CalendarFastBackwardCommand", typeof(ICommand), typeof(Calendar), new PropertyMetadata(new RelayCommand(OnCalendarFastBackward)));

        internal static readonly DependencyProperty CalendarYearButtonCommandProperty =
            DependencyProperty.Register("CalendarYearButtonCommand", typeof(ICommand), typeof(Calendar), new PropertyMetadata(new RelayCommand(OnCalendarYearButtonCommand)));

        internal static readonly DependencyProperty CalendarMonthButtonCommandProperty =
            DependencyProperty.Register("CalendarMonthButtonCommand", typeof(ICommand), typeof(Calendar), new PropertyMetadata(new RelayCommand(OnCalendarMonthButtonCommand)));

        #endregion

        #region MonthButton
        internal string MonthButton
        {
            get { return (string)GetValue(MonthButtonProperty); }
            set { SetValue(MonthButtonProperty, value); }
        }

        internal static readonly DependencyProperty MonthButtonProperty =
            DependencyProperty.Register("MonthButton", typeof(string), typeof(Calendar));
        #endregion

        #region YearButton
        internal string YearButton
        {
            get { return (string)GetValue(YearButtonProperty); }
            set { SetValue(YearButtonProperty, value); }
        }

        internal static readonly DependencyProperty YearButtonProperty =
            DependencyProperty.Register("YearButton", typeof(string), typeof(Calendar));
        #endregion

        #endregion

        #region Event Handler
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            switch (SelectionMode)
            {
                case CalendarSelectionMode.Date:
                    CurrentPanel = YearMonthDay.Day;
                    break;
                case CalendarSelectionMode.Year:
                    CurrentPanel = YearMonthDay.Year;
                    break;
                case CalendarSelectionMode.YearMonth:
                    CurrentPanel = YearMonthDay.Month;
                    break;
            }
            LoadWeeks();
            if (SelectedDate == default)
            {
                SelectedDate = DateTime.Now.Date;
            }
            else
            {
                UpdateCalendar();
            }
        }

        private static object OnMinDateCoerceValue(DependencyObject d, object baseValue)
        {
            var calendar = d as Calendar;
            if (baseValue == null)
            {
                return null;
            }
            var minDate = (DateTime)baseValue;
            if (calendar.MaxDate != null)
            {
                var maxDate = (DateTime)calendar.MaxDate;
                if (minDate > maxDate)
                    return maxDate;
            }
            return minDate;
        }

        private static void OnMinDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SelectedDateProperty);
        }

        private static object OnMaxDateCoerceValue(DependencyObject d, object baseValue)
        {
            var calendar = d as Calendar;
            if (baseValue == null)
            {
                return null;
            }
            var maxDate = (DateTime)baseValue;
            if (calendar.MinDate != null)
            {
                var minDate = (DateTime)calendar.MinDate;
                if (maxDate < minDate)
                {
                    return minDate;
                }
            }
            return maxDate;
        }

        private static void OnMaxDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SelectedDateProperty);
        }

        private static object OnSelectedDateCoerceValue(DependencyObject d, object baseValue)
        {
            var calendar = d as Calendar;
            var selectedDate = (DateTime)baseValue;
            if (calendar.MinDate != null)
            {
                var minDate = (DateTime)calendar.MinDate;
                if (selectedDate < minDate)
                    return minDate;
            }
            if (calendar.MaxDate != null)
            {
                var maxDate = (DateTime)calendar.MaxDate;
                if (selectedDate > maxDate)
                    return maxDate;
            }
            return selectedDate;
        }

        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            var newDate = (DateTime)e.NewValue;
            var oldDate = (DateTime)e.OldValue;
            calendar.UpdateCalendar(oldDate, newDate);
            calendar.RaiseSelectedDateChanged(newDate);
        }

        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            calendar.LoadWeeks();
        }

        private void OnRadioButtonClicked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if (radioButton == null || radioButton.IsChecked != true)
            {
                return;
            }

            var groupName = radioButton.GroupName;
            DateTime date;
            switch (groupName)
            {
                case _CALENDAR_GROUP_DAYS:
                    date = (DateTime)radioButton.Tag;
                    if (SelectedDate != date)
                    {
                        SelectedDate = date;
                    }
                    if (SelectionMode == CalendarSelectionMode.Date)
                    {
                        RaiseSelected(SelectedDate);
                    }
                    break;
                case _CALENDAR_GROUP_MONTHS:
                    date = (DateTime)radioButton.Tag;
                    if (!(SelectedDate.Year == date.Year && SelectedDate.Month == date.Month))
                    {
                        var dayInMonth = DateTime.DaysInMonth(SelectedDate.Year, SelectedDate.Month);
                        var day = SelectedDate.Day > dayInMonth ? dayInMonth : SelectedDate.Day;
                        SelectedDate = new DateTime(SelectedDate.Year, date.Month, day);
                    }
                    switch (SelectionMode)
                    {
                        case CalendarSelectionMode.Date:
                            CurrentPanel = YearMonthDay.Day;
                            break;
                        case CalendarSelectionMode.YearMonth:
                            RaiseSelected(SelectedDate);
                            break;
                    }
                    break;
                case _CALENDAR_GROUP_YEARS:
                    date = (DateTime)radioButton.Tag;
                    if (SelectedDate.Year != date.Year)
                    {
                        var dayInMonth = DateTime.DaysInMonth(date.Year, SelectedDate.Month);
                        var day = SelectedDate.Day > dayInMonth ? dayInMonth : SelectedDate.Day;
                        SelectedDate = new DateTime(date.Year, SelectedDate.Month, day);
                    }
                    switch (SelectionMode)
                    {
                        case CalendarSelectionMode.Date:
                        case CalendarSelectionMode.YearMonth:
                            CurrentPanel = YearMonthDay.Month;
                            break;
                        case CalendarSelectionMode.Year:
                            RaiseSelected(SelectedDate);
                            break;
                    }
                    break;
            }
        }

        private static void OnCalendarFastForeward(object obj)
        {
            var calendar = obj as Calendar;
            switch (calendar.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    calendar.SelectedDate = calendar.SelectedDate.AddYears(1);
                    break;
                case YearMonthDay.Year:
                    calendar.SelectedDate = calendar.SelectedDate.AddYears(4);
                    break;
            }
        }

        private static void OnCalendarForeward(object obj)
        {
            var calendar = obj as Calendar;
            switch (calendar.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    calendar.SelectedDate = calendar.SelectedDate.AddMonths(1);
                    break;
                case YearMonthDay.Year:
                    calendar.SelectedDate = calendar.SelectedDate.AddYears(1);
                    break;
            }
        }

        private static void OnCalendarBackward(object obj)
        {
            var calendar = obj as Calendar;
            switch (calendar.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    calendar.SelectedDate = calendar.SelectedDate.AddMonths(-1);
                    break;
                case YearMonthDay.Year:
                    calendar.SelectedDate = calendar.SelectedDate.AddYears(-1);
                    break;
            }
        }

        private static void OnCalendarFastBackward(object obj)
        {
            var calendar = obj as Calendar;
            switch (calendar.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    calendar.SelectedDate = calendar.SelectedDate.AddYears(-1);
                    break;
                case YearMonthDay.Year:
                    calendar.SelectedDate = calendar.SelectedDate.AddYears(-4);
                    break;
            }
        }

        private static void OnCalendarYearButtonCommand(object obj)
        {
            var calendar = obj as Calendar;
            calendar.CurrentPanel = YearMonthDay.Year;
        }

        private static void OnCalendarMonthButtonCommand(object obj)
        {
            var calendar = obj as Calendar;

            calendar.CurrentPanel = YearMonthDay.Month;
        }

        #endregion

        #region Function
        private void UpdateCalendar(DateTime oldDate, DateTime newDate)
        {
            if (newDate.Year == oldDate.Year)
            {
                if (newDate.Month == oldDate.Month)
                {
                    if (newDate.Day != oldDate.Day)
                    {
                        LoadOrUpdateDays();
                    }
                }
                else
                {
                    MonthButton = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(newDate.Month);
                    LoadOrUpdateDays();
                    LoadOrUpdateMonths();
                }
            }
            else
            {
                YearButton = newDate.Year.ToString();
                MonthButton = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(newDate.Month);
                LoadOrUpdateDays();
                LoadOrUpdateMonths();
                LoadOrUpdateYears();
            }
        }

        private void UpdateCalendar()
        {
            YearButton = SelectedDate.Year.ToString();
            MonthButton = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SelectedDate.Month);
            LoadOrUpdateDays();
            LoadOrUpdateMonths();
            LoadOrUpdateYears();
        }

        private void LoadWeeks()
        {
            var daysOfWeek = FirstDayOfWeek;

            for (int i = 0; i < 7; i++)
            {
                if (Weeks.Count <= i)
                {
                    var calendarItem = new CalendarModelItem()
                    {
                        DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(daysOfWeek),
                    };
                    Weeks.Add(calendarItem);
                }
                else
                {
                    var calendarItem = Weeks[i];
                    calendarItem.DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(daysOfWeek);
                }
                daysOfWeek = DateTimeUtils.GetNextDayOfWeek(daysOfWeek);
            }

        }

        private void LoadOrUpdateDays()
        {
            var firstDayDate = DateTimeUtils.GetFirstDayDate(SelectedDate);
            var dayInMonth = DateTimeUtils.GetDayInMonth(firstDayDate);
            var dayOfWeek = DateTimeUtils.GetDayOfWeek(firstDayDate.DayOfWeek);
            var firstDayOfWeek = DateTimeUtils.GetDayOfWeek(FirstDayOfWeek);
            int interval;
            if (dayOfWeek < firstDayOfWeek)
            {
                interval = 7 - (firstDayOfWeek - dayOfWeek);
            }
            else
            {
                interval = dayOfWeek - firstDayOfWeek;
            }
            if (interval == 0)
            {
                interval = 7;
            }
            var date = firstDayDate.AddDays(-interval);
            for (int i = 0; i < 42; i++)
            {
                if (Days.Count <= i)
                {
                    var calendarItem = new CalendarModelItem()
                    {
                        Value = date,
                        DisplayName = date.Day.ToString(),
                        IsEnabled = IsDateValidated(date),
                        IsChecked = date == SelectedDate,
                        IsNotCurrentMonth = i < interval ? true : (i >= (interval + dayInMonth)),
                    };
                    Days.Add(calendarItem);
                }
                else
                {
                    var calendarItem = Days[i];
                    calendarItem.Value = date;
                    calendarItem.DisplayName = date.Day.ToString();
                    calendarItem.IsEnabled = IsDateValidated(date);
                    calendarItem.IsChecked = date == SelectedDate;
                    calendarItem.IsNotCurrentMonth = i < interval ? true : (i >= (interval + dayInMonth));
                }
                date = date.AddDays(1);
            }
        }

        private void LoadOrUpdateMonths()
        {
            var date = new DateTime(SelectedDate.Year, 1, 1);
            for (int i = 0; i < 12; i++)
            {
                if (Months.Count <= i)
                {
                    var calendarItem = new CalendarModelItem()
                    {
                        Value = date,
                        DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month),
                        IsEnabled = IsMonthValidated(date),
                        IsChecked = (date.Year == SelectedDate.Year && date.Month == SelectedDate.Month),
                    };
                    Months.Add(calendarItem);
                }
                else
                {
                    var calendarItem = Months[i];
                    calendarItem.Value = date;
                    calendarItem.DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
                    calendarItem.IsEnabled = IsMonthValidated(date);
                    calendarItem.IsChecked = (date.Year == SelectedDate.Year && date.Month == SelectedDate.Month);
                }
                date = date.AddMonths(1);
            }
        }

        private void LoadOrUpdateYears()
        {
            var interval = 7;
            var date = new DateTime(SelectedDate.Year, 1, 1).AddYears(-interval);

            for (int i = 0; i < 15; i++)
            {
                if (Years.Count <= i)
                {
                    var calendarItem = new CalendarModelItem()
                    {
                        Value = date,
                        DisplayName = date.Year.ToString(),
                        IsEnabled = IsMonthValidated(date),
                        IsChecked = date.Year == SelectedDate.Year,
                    };
                    Years.Add(calendarItem);
                }
                else
                {
                    var calendarItem = Years[i];
                    calendarItem.Value = date;
                    calendarItem.DisplayName = date.Year.ToString();
                    calendarItem.IsEnabled = IsMonthValidated(date);
                    calendarItem.IsChecked = date.Year == SelectedDate.Year;
                }
                date = date.AddYears(1);
            }

        }

        private bool IsDateValidated(DateTime dateTime)
        {
            if (MinDate != null)
            {
                var minDate = (DateTime)MinDate;
                if (dateTime < minDate)
                    return false;
            }
            if (MaxDate != null)
            {
                var maxDate = (DateTime)MaxDate;
                if (dateTime > maxDate)
                    return false;
            }
            return true;
        }

        private bool IsMonthValidated(DateTime dateTime)
        {
            if (MinDate != null)
            {
                var minDate = (DateTime)MinDate;
                if (dateTime.Year > minDate.Year)
                {
                    return false;
                }
                else if (dateTime.Month > minDate.Month)
                {
                    return false;
                }
            }
            if (MaxDate != null)
            {
                var maxDate = (DateTime)MaxDate;
                if (dateTime.Year < maxDate.Year)
                {
                    return false;
                }
                else if (dateTime.Month < maxDate.Month)
                {
                    return false;
                }
            }
            return true;
        }

        private void PlayStoryboard(YearMonthDay oldValue, YearMonthDay newValue)
        {
            switch (newValue)
            {
                case YearMonthDay.Month:
                    switch (oldValue)
                    {
                        case YearMonthDay.Day:
                            RaiseDayPanelToMonth();
                            break;
                        case YearMonthDay.Year:
                            RaiseYearPanelToMonth();
                            break;
                    }
                    break;
                case YearMonthDay.Day:
                    switch (oldValue)
                    {
                        case YearMonthDay.Month:
                            RaiseMonthPanelToDay();
                            break;
                        case YearMonthDay.Year:
                            RaiseYearPanelToMonth();
                            RaiseMonthPanelToDay();
                            break;
                    }
                    break;
                case YearMonthDay.Year:
                    switch (oldValue)
                    {
                        case YearMonthDay.Month:
                            RaiseMonthPanelToYear();
                            break;
                        case YearMonthDay.Day:
                            RaiseDayPanelToMonth();
                            RaiseMonthPanelToYear();
                            break;
                    }
                    break;
            }
        }
    }
    #endregion
}
