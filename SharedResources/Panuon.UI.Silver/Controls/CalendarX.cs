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
    public class CalendarX : Control
    {
        #region Fields
        private const string _CalendarX_GROUP_DAYS = "CalendarX_GROUP_DAYS";
        private const string _CalendarX_GROUP_MONTHS = "CalendarX_GROUP_MONTHS";
        private const string _CalendarX_GROUP_YEARS = "CalendarX_GROUP_YEARS";
        #endregion

        #region Ctor
        static CalendarX()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarX), new FrameworkPropertyMetadata(typeof(CalendarX)));
        }

        public CalendarX()
        {
            AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(OnRadioButtonClicked));
            Days = new ObservableCollection<CalendarXModelItem>();
            Months = new ObservableCollection<CalendarXModelItem>();
            Years = new ObservableCollection<CalendarXModelItem>();
            Weeks = new ObservableCollection<CalendarXModelItem>();
            Loaded += CalendarX_Loaded;
        }

        #endregion

        #region RoutedEvent

        #region SelectedDateChanged
        public static readonly RoutedEvent SelectedDateChangedEvent = EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Bubble, typeof(DateTimeChangedRoutedEventHandler), typeof(CalendarX));
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
        public static readonly RoutedEvent DayPanelToMonthEvent = EventManager.RegisterRoutedEvent("DayPanelToMonth", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CalendarX));
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
        public static readonly RoutedEvent MonthPanelToDayEvent = EventManager.RegisterRoutedEvent("MonthPanelToDay", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CalendarX));
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
        public static readonly RoutedEvent MonthPanelToYearEvent = EventManager.RegisterRoutedEvent("MonthPanelToYear", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CalendarX));
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
        public static readonly RoutedEvent YearPanelToMonthEvent = EventManager.RegisterRoutedEvent("YearPanelToMonth", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CalendarX));
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
        public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent("Selected", RoutingStrategy.Bubble, typeof(DateTimeChangedRoutedEventHandler), typeof(CalendarX));
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
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(CalendarX), new FrameworkPropertyMetadata(default(DateTime), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedDateChanged, OnSelectedDateCoerceValue));

        #endregion

        #region ControlButtonStyle
        public Style ControlButtonStyle
        {
            get { return (Style)GetValue(ControlButtonStyleProperty); }
            set { SetValue(ControlButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ControlButtonStyleProperty =
            DependencyProperty.Register("ControlButtonStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region CalendarXItemStyle
        public Style CalendarXItemStyle
        {
            get { return (Style)GetValue(CalendarXItemStyleProperty); }
            set { SetValue(CalendarXItemStyleProperty, value); }
        }

        public static readonly DependencyProperty CalendarXItemStyleProperty =
            DependencyProperty.Register("CalendarXItemStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarX), new PropertyMetadata(null, OnMinDateChanged, OnMinDateCoerceValue));
        #endregion

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarX), new PropertyMetadata(null, OnMaxDateChanged, OnMaxDateCoerceValue));
        #endregion

        #region SelectionMode
        public CalendarSelectionMode SelectionMode
        {
            get { return (CalendarSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }

        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(CalendarSelectionMode), typeof(CalendarX));
        #endregion

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarX), new PropertyMetadata(OnFirstDayOfWeekChanged));

        #endregion

        #region HeaderPanelBackground
        public Brush HeaderPanelBackground
        {
            get { return (Brush)GetValue(HeaderPanelBackgroundProperty); }
            set { SetValue(HeaderPanelBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HeaderPanelBackgroundProperty =
            DependencyProperty.Register("HeaderPanelBackground", typeof(Brush), typeof(CalendarX));
        #endregion

        #region HeaderPanelHeight
        public double HeaderPanelHeight
        {
            get { return (double)GetValue(HeaderPanelHeightProperty); }
            set { SetValue(HeaderPanelHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderPanelHeightProperty =
            DependencyProperty.Register("HeaderPanelHeight", typeof(double), typeof(CalendarX));
        #endregion

        #endregion

        #region Internal Properties

        #region Days
        internal ObservableCollection<CalendarXModelItem> Days
        {
            get { return (ObservableCollection<CalendarXModelItem>)GetValue(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }

        internal static readonly DependencyProperty DaysProperty =
            DependencyProperty.Register("Days", typeof(ObservableCollection<CalendarXModelItem>), typeof(CalendarX));
        #endregion

        #region Months
        internal ObservableCollection<CalendarXModelItem> Months
        {
            get { return (ObservableCollection<CalendarXModelItem>)GetValue(MonthsProperty); }
            set { SetValue(MonthsProperty, value); }
        }

        internal static readonly DependencyProperty MonthsProperty =
            DependencyProperty.Register("Months", typeof(ObservableCollection<CalendarXModelItem>), typeof(CalendarX));
        #endregion

        #region Years
        internal ObservableCollection<CalendarXModelItem> Years
        {
            get { return (ObservableCollection<CalendarXModelItem>)GetValue(YearsProperty); }
            set { SetValue(YearsProperty, value); }
        }

        internal static readonly DependencyProperty YearsProperty =
            DependencyProperty.Register("Years", typeof(ObservableCollection<CalendarXModelItem>), typeof(CalendarX));
        #endregion

        #region Weeks
        internal ObservableCollection<CalendarXModelItem> Weeks
        {
            get { return (ObservableCollection<CalendarXModelItem>)GetValue(WeeksProperty); }
            set { SetValue(WeeksProperty, value); }
        }

        internal static readonly DependencyProperty WeeksProperty =
            DependencyProperty.Register("Weeks", typeof(ObservableCollection<CalendarXModelItem>), typeof(CalendarX));
        #endregion

        #region CurrentPanel
        internal YearMonthDay CurrentPanel
        {
            get { return (YearMonthDay)GetValue(CurrentPanelProperty); }
            set { SetValue(CurrentPanelProperty, value); }
        }

        internal static readonly DependencyProperty CurrentPanelProperty =
            DependencyProperty.Register("CurrentPanel", typeof(YearMonthDay), typeof(CalendarX), new PropertyMetadata(YearMonthDay.Day, OnCurrentPanelChanged));

        private static void OnCurrentPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var CalendarX = d as CalendarX;
            if (!CalendarX.IsLoaded)
            {
                return;
            }
            CalendarX.PlayStoryboard((YearMonthDay)e.OldValue, (YearMonthDay)e.NewValue);
        }


        #endregion

        #region Commands
        internal static readonly DependencyProperty CalendarXForewardCommandProperty =
            DependencyProperty.Register("CalendarXForewardCommand", typeof(ICommand), typeof(CalendarX), new PropertyMetadata(new RelayCommand(OnCalendarXForeward)));

        internal static readonly DependencyProperty CalendarXFastForewardCommandProperty =
            DependencyProperty.Register("CalendarXFastForewardCommand", typeof(ICommand), typeof(CalendarX), new PropertyMetadata(new RelayCommand(OnCalendarXFastForeward)));

        internal static readonly DependencyProperty CalendarXBackwardCommandProperty =
            DependencyProperty.Register("CalendarXBackwardCommand", typeof(ICommand), typeof(CalendarX), new PropertyMetadata(new RelayCommand(OnCalendarXBackward)));

        internal static readonly DependencyProperty CalendarXFastBackwardCommandProperty =
            DependencyProperty.Register("CalendarXFastBackwardCommand", typeof(ICommand), typeof(CalendarX), new PropertyMetadata(new RelayCommand(OnCalendarXFastBackward)));

        internal static readonly DependencyProperty CalendarXYearButtonCommandProperty =
            DependencyProperty.Register("CalendarXYearButtonCommand", typeof(ICommand), typeof(CalendarX), new PropertyMetadata(new RelayCommand(OnCalendarXYearButtonCommand)));

        internal static readonly DependencyProperty CalendarXMonthButtonCommandProperty =
            DependencyProperty.Register("CalendarXMonthButtonCommand", typeof(ICommand), typeof(CalendarX), new PropertyMetadata(new RelayCommand(OnCalendarXMonthButtonCommand)));

        #endregion

        #region MonthButton
        internal string MonthButton
        {
            get { return (string)GetValue(MonthButtonProperty); }
            set { SetValue(MonthButtonProperty, value); }
        }

        internal static readonly DependencyProperty MonthButtonProperty =
            DependencyProperty.Register("MonthButton", typeof(string), typeof(CalendarX));
        #endregion

        #region YearButton
        internal string YearButton
        {
            get { return (string)GetValue(YearButtonProperty); }
            set { SetValue(YearButtonProperty, value); }
        }

        internal static readonly DependencyProperty YearButtonProperty =
            DependencyProperty.Register("YearButton", typeof(string), typeof(CalendarX));
        #endregion

        #endregion

        #region Event Handler
        private void CalendarX_Loaded(object sender, RoutedEventArgs e)
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
                UpdateCalendarX();
            }
        }

        private static object OnMinDateCoerceValue(DependencyObject d, object baseValue)
        {
            var CalendarX = d as CalendarX;
            if (baseValue == null)
            {
                return null;
            }
            var minDate = (DateTime)baseValue;
            if (CalendarX.MaxDate != null)
            {
                var maxDate = (DateTime)CalendarX.MaxDate;
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
            var CalendarX = d as CalendarX;
            if (baseValue == null)
            {
                return null;
            }
            var maxDate = (DateTime)baseValue;
            if (CalendarX.MinDate != null)
            {
                var minDate = (DateTime)CalendarX.MinDate;
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
            var CalendarX = d as CalendarX;
            var selectedDate = (DateTime)baseValue;
            if (CalendarX.MinDate != null)
            {
                var minDate = (DateTime)CalendarX.MinDate;
                if (selectedDate < minDate)
                    return minDate;
            }
            if (CalendarX.MaxDate != null)
            {
                var maxDate = (DateTime)CalendarX.MaxDate;
                if (selectedDate > maxDate)
                    return maxDate;
            }
            return selectedDate;
        }

        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var CalendarX = d as CalendarX;
            var newDate = (DateTime)e.NewValue;
            var oldDate = (DateTime)e.OldValue;
            CalendarX.UpdateCalendarX(oldDate, newDate);
            CalendarX.RaiseSelectedDateChanged(newDate);
        }

        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var CalendarX = d as CalendarX;
            CalendarX.LoadWeeks();
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
                case _CalendarX_GROUP_DAYS:
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
                case _CalendarX_GROUP_MONTHS:
                    date = (DateTime)radioButton.Tag;
                    if (!(SelectedDate.Year == date.Year && SelectedDate.Month == date.Month))
                    {
                        var dayInMonth = DateTime.DaysInMonth(date.Year, date.Month);
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
                case _CalendarX_GROUP_YEARS:
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

        private static void OnCalendarXFastForeward(object obj)
        {
            var CalendarX = obj as CalendarX;
            switch (CalendarX.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddYears(1);
                    break;
                case YearMonthDay.Year:
                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddYears(4);
                    break;
            }
        }

        private static void OnCalendarXForeward(object obj)
        {
            var CalendarX = obj as CalendarX;
            switch (CalendarX.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddMonths(1);
                    break;
                case YearMonthDay.Year:
                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddYears(1);
                    break;
            }
        }

        private static void OnCalendarXBackward(object obj)
        {
            var CalendarX = obj as CalendarX;
            switch (CalendarX.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddMonths(-1);
                    break;
                case YearMonthDay.Year:
                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddYears(-1);
                    break;
            }
        }

        private static void OnCalendarXFastBackward(object obj)
        {
            var CalendarX = obj as CalendarX;
            switch (CalendarX.CurrentPanel)
            {
                case YearMonthDay.Day:
                case YearMonthDay.Month:

                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddYears(-1);
                    break;
                case YearMonthDay.Year:
                    CalendarX.SelectedDate = CalendarX.SelectedDate.AddYears(-4);
                    break;
            }
        }

        private static void OnCalendarXYearButtonCommand(object obj)
        {
            var CalendarX = obj as CalendarX;
            CalendarX.CurrentPanel = YearMonthDay.Year;
        }

        private static void OnCalendarXMonthButtonCommand(object obj)
        {
            var CalendarX = obj as CalendarX;

            CalendarX.CurrentPanel = YearMonthDay.Month;
        }

        #endregion

        #region Function
        private void UpdateCalendarX(DateTime oldDate, DateTime newDate)
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

        private void UpdateCalendarX()
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
                    var CalendarXItem = new CalendarXModelItem()
                    {
                        DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(daysOfWeek),
                    };
                    Weeks.Add(CalendarXItem);
                }
                else
                {
                    var CalendarXItem = Weeks[i];
                    CalendarXItem.DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(daysOfWeek);
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
                    var CalendarXItem = new CalendarXModelItem()
                    {
                        Value = date,
                        DisplayName = date.Day.ToString(),
                        IsEnabled = IsDateValidated(date),
                        IsChecked = date == SelectedDate,
                        IsNotCurrentMonth = i < interval ? true : (i >= (interval + dayInMonth)),
                    };
                    Days.Add(CalendarXItem);
                }
                else
                {
                    var CalendarXItem = Days[i];
                    CalendarXItem.Value = date;
                    CalendarXItem.DisplayName = date.Day.ToString();
                    CalendarXItem.IsEnabled = IsDateValidated(date);
                    CalendarXItem.IsChecked = date == SelectedDate;
                    CalendarXItem.IsNotCurrentMonth = i < interval ? true : (i >= (interval + dayInMonth));
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
                    var CalendarXItem = new CalendarXModelItem()
                    {
                        Value = date,
                        DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month),
                        IsEnabled = IsMonthValidated(date),
                        IsChecked = (date.Year == SelectedDate.Year && date.Month == SelectedDate.Month),
                    };
                    Months.Add(CalendarXItem);
                }
                else
                {
                    var CalendarXItem = Months[i];
                    CalendarXItem.Value = date;
                    CalendarXItem.DisplayName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
                    CalendarXItem.IsEnabled = IsMonthValidated(date);
                    CalendarXItem.IsChecked = (date.Year == SelectedDate.Year && date.Month == SelectedDate.Month);
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
                    var CalendarXItem = new CalendarXModelItem()
                    {
                        Value = date,
                        DisplayName = date.Year.ToString(),
                        IsEnabled = IsMonthValidated(date),
                        IsChecked = date.Year == SelectedDate.Year,
                    };
                    Years.Add(CalendarXItem);
                }
                else
                {
                    var CalendarXItem = Years[i];
                    CalendarXItem.Value = date;
                    CalendarXItem.DisplayName = date.Year.ToString();
                    CalendarXItem.IsEnabled = IsMonthValidated(date);
                    CalendarXItem.IsChecked = date.Year == SelectedDate.Year;
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
