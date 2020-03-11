using Panuon.UI.Silver.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// Calendar.xaml 的交互逻辑
    /// </summary>
    public partial class Calendar : UserControl
    {
        #region Identity
        private bool isLoaded = false;

        enum DayMonthYear
        {
            Day,
            Month,
            Year,
        }

        private Storyboard _storyboard_yeartoMonth;

        private Storyboard _storyboard_monthtoYear;

        private Storyboard _storyboard_daytoMonth;

        private Storyboard _storyboard_monthtoDay;

        private DayMonthYear _currentPosition = DayMonthYear.Day;
        #endregion

        #region Constructor
        public Calendar()
        {
            InitializeComponent();
            FontSize = (double)FindResource("Default_FontSize");
            _storyboard_daytoMonth = FindResource("Storyboard_DayToMonth") as Storyboard;
            _storyboard_monthtoDay = FindResource("Storyboard_MonthToDay") as Storyboard;
            _storyboard_yeartoMonth = FindResource("Storyboard_YearToMonth") as Storyboard;
            _storyboard_monthtoYear = FindResource("Storyboard_MonthToYear") as Storyboard;
            Loaded += Calendar_Loaded;
        }
        #endregion

        #region RoutedEvent
        public static readonly RoutedEvent SelectedDateChangedEvent = EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Bubble, typeof(SelectedDateChangedEventHandler), typeof(Calendar));
        public event SelectedDateChangedEventHandler SelectedDateChanged
        {
            add { AddHandler(SelectedDateChangedEvent, value); }
            remove { RemoveHandler(SelectedDateChangedEvent, value); }
        }
        void RaiseSelectedDateChanged(DateTime newValue)
        {
            var arg = new SelectedDateChangedEventArgs(newValue, SelectedDateChangedEvent);
            RaiseEvent(arg);
        }

        public static readonly RoutedEvent SelectedEvent = EventManager.RegisterRoutedEvent("Selected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Calendar));
        public event RoutedEventHandler Selected
        {
            add { AddHandler(SelectedEvent, value); }
            remove { RemoveHandler(SelectedEvent, value); }
        }
        void RaiseSelectedEvent()
        {
            var arg = new RoutedEventArgs(SelectedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property

        public CalendarMode CalendarMode
        {
            get { return (CalendarMode)GetValue(CalendarModeProperty); }
            set { SetValue(CalendarModeProperty, value); }
        }

        public static readonly DependencyProperty CalendarModeProperty =
            DependencyProperty.Register(" CalendarMode", typeof(CalendarMode), typeof(Calendar), new PropertyMetadata(OnCalendarModeChanged));

        /// <summary>
        /// get or set selected datetime.
        /// </summary>
        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value.Date); }
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(Calendar), new PropertyMetadata(DateTime.Now.Date, OnSelectedDateChanged, OnSelectedDateCoerceValue));

        /// <summary>
        /// get or set max datetime.
        /// </summary>
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(Calendar), new PropertyMetadata(OnDateTimeLimitChanged));

        /// <summary>
        /// get or set min datetime.
        /// </summary>
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(Calendar), new PropertyMetadata(OnDateTimeLimitChanged));

        /// <summary>
        /// get or set theme brush.
        /// </summary>
        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3E3E3E"))));

        public bool IsSundayFirst
        {
            get { return (bool)GetValue(IsSundayFirstProperty); }
            set { SetValue(IsSundayFirstProperty, value); }
        }

        public static readonly DependencyProperty IsSundayFirstProperty =
            DependencyProperty.Register("IsSundayFirst", typeof(bool), typeof(Calendar), new PropertyMetadata(true, OnIsSundayFirstChanged));




        public bool IsSplitLineVisible
        {
            get { return (bool)GetValue(IsSplitLineVisibleProperty); }
            set { SetValue(IsSplitLineVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsSplitLineVisibleProperty =
            DependencyProperty.Register("IsSplitLineVisible", typeof(bool), typeof(Calendar));


        #endregion

        #region Property Changed Handler
        private static object OnSelectedDateCoerceValue(DependencyObject d, object baseValue)
        {
            var date = (DateTime)baseValue;
            if(date.Year < 5)
            {
                return new DateTime(5, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            }
            return date;
        }

        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            if (calendar.ActualWidth == 0)
                return;

            var oldDate = (DateTime)e.OldValue;
            var newDate = (DateTime)e.NewValue;
            if (oldDate == newDate)
                return;

            if (!calendar.CheckDateLimit(newDate, DayMonthYear.Day))
            {
                if (newDate >= oldDate)
                    calendar.SelectedDate = calendar.MaxDate ?? oldDate;
                else
                    calendar.SelectedDate = calendar.MinDate ?? oldDate;

                return;
            }

            if (calendar._currentPosition == DayMonthYear.Day && (oldDate.Year != newDate.Year || oldDate.Month != newDate.Month))
            {
                calendar.InitDayPanel(newDate.Year, newDate.Month);
            }

            if (calendar._currentPosition == DayMonthYear.Month && (oldDate.Year != newDate.Year || oldDate.Month != newDate.Month))
            {
                calendar.InitMonthPanel(newDate.Year);
            }

            if (calendar._currentPosition == DayMonthYear.Year && oldDate.Year != newDate.Year)
            {
                calendar.InitYearPanel(newDate.Year);
            }

            switch (calendar._currentPosition)
            {
                case DayMonthYear.Day:
                    calendar.BtnMonthYear.Content = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(newDate.Month)}  {newDate.Year}";
                    break;
                case DayMonthYear.Month:
                    calendar.BtnMonthYear.Content = $"{newDate.Year}";
                    break;
                case DayMonthYear.Year:
                    calendar.BtnMonthYear.Content = $"{newDate.Year - 7} - {newDate.Year + 7}";
                    break;
            }

            calendar.CheckButtonVisible();
            calendar.RaiseSelectedDateChanged(newDate);
        }

        private static void OnDateTimeLimitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            if (calendar.ActualWidth == 0)
                return;

            switch (calendar._currentPosition)
            {
                case DayMonthYear.Day:
                    calendar.InitDayPanel(calendar.SelectedDate.Year, calendar.SelectedDate.Month);
                    break;
                case DayMonthYear.Month:
                    calendar.InitMonthPanel(calendar.SelectedDate.Year);
                    break;
                case DayMonthYear.Year:
                    calendar.InitYearPanel(calendar.SelectedDate.Year);
                    break;
            }
            if (calendar.MaxDate != null)
            {
                if (calendar.SelectedDate > (DateTime)calendar.MaxDate)
                {
                    calendar.SelectedDate = (DateTime)calendar.MaxDate;
                    return;
                }
            }
            if (calendar.MinDate != null)
            {
                if (calendar.SelectedDate < (DateTime)calendar.MinDate)
                {
                    calendar.SelectedDate = (DateTime)calendar.MinDate;
                    return;
                }
            }
            calendar.CheckButtonVisible();
        }

        private static void OnCalendarModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            if (calendar.ActualWidth == 0)
                return;

            switch (calendar.CalendarMode)
            {
                case CalendarMode.YearMonth:
                    if (calendar._currentPosition != DayMonthYear.Month)
                        calendar.ChangePanel(DayMonthYear.Month);
                    break;
                case CalendarMode.Year:
                    if (calendar._currentPosition != DayMonthYear.Year)
                        calendar.ChangePanel(DayMonthYear.Year);
                    break;
                case CalendarMode.Date:
                    if (calendar._currentPosition != DayMonthYear.Day)
                        calendar.ChangePanel(DayMonthYear.Day);
                    break;
            }

            calendar.CheckButtonVisible();
        }

        private static void OnIsSundayFirstChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as Calendar;
            if (calendar.ActualWidth == 0)
                return;

            calendar.InitWeekTitle();
            calendar.InitDayPanel(calendar.SelectedDate.Year, calendar.SelectedDate.Month);
        }
        #endregion

        #region Event
        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            if (isLoaded)
                return;

            isLoaded = true;

            InitWeekTitle();

            if (CalendarMode == CalendarMode.Date)
            {
                ChangePanel(DayMonthYear.Day);
            }
            else if (CalendarMode == CalendarMode.YearMonth)
            {
                ChangePanel(DayMonthYear.Month);
            }
            else
            {
                ChangePanel(DayMonthYear.Year);
            }
        }

        private void RdbDay_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var currentDate = (DateTime)radioButton.Tag;
            SelectedDate = GetNewDateTime(currentDate.Year, currentDate.Month, currentDate.Day, SelectedDate.Hour, SelectedDate.Minute, SelectedDate.Second);
            if (CalendarMode == CalendarMode.Date)
                RaiseSelectedEvent();
        }

        private void RdbMonth_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var currentDate = (DateTime)radioButton.Tag;
            SelectedDate = GetNewDateTime(currentDate.Year, currentDate.Month, SelectedDate.Day, SelectedDate.Hour, SelectedDate.Minute, SelectedDate.Second);
            if (CalendarMode == CalendarMode.Date)
                ChangePanel(DayMonthYear.Day);
            if (CalendarMode == CalendarMode.YearMonth)
                RaiseSelectedEvent();
        }

        private void RdbYear_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var currentDate = (DateTime)radioButton.Tag;
            SelectedDate = GetNewDateTime(currentDate.Year, SelectedDate.Month, SelectedDate.Day, SelectedDate.Hour, SelectedDate.Minute, SelectedDate.Second);
            if (CalendarMode != CalendarMode.Year)
                ChangePanel(DayMonthYear.Month);
            if (CalendarMode == CalendarMode.Year)
                RaiseSelectedEvent();
        }

        private void BtnDecMonth_Click(object sender, RoutedEventArgs e)
        {
            SelectedDate = SelectedDate.AddMonths(-1);
        }

        private void BtnDecYear_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPosition == DayMonthYear.Year)
                SelectedDate = SelectedDate.AddYears(-15);
            else
                SelectedDate = SelectedDate.AddYears(-1);
        }

        private void BtnIncMonth_Click(object sender, RoutedEventArgs e)
        {
            SelectedDate = SelectedDate.AddMonths(1);
        }

        private void BtnIncYear_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPosition == DayMonthYear.Year)
                SelectedDate = SelectedDate.AddYears(15);
            else
                SelectedDate = SelectedDate.AddYears(1);
        }

        private void BtnMonthYear_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentPosition)
            {
                case DayMonthYear.Day:
                    ChangePanel(DayMonthYear.Month);
                    break;
                case DayMonthYear.Month:
                    ChangePanel(DayMonthYear.Year);
                    break;
            }
        }
        #endregion

        #region Function
        private DateTime GetNewDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            var maxDay = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, day > maxDay ? maxDay : day, hour, minute, second);
        }

        private void ChangePanel(DayMonthYear dayMonthYear)
        {
            switch (dayMonthYear)
            {
                case DayMonthYear.Day:
                    BtnIncMonth.Visibility = Visibility.Visible;
                    BtnDecMonth.Visibility = Visibility.Visible;
                    InitDayPanel(SelectedDate.Year, SelectedDate.Month);
                    if (_currentPosition == DayMonthYear.Year)
                    {
                        _storyboard_yeartoMonth.Begin();
                        _storyboard_monthtoDay.Begin();
                    }
                    if (_currentPosition == DayMonthYear.Month)
                        _storyboard_monthtoDay.Begin();
                    BtnMonthYear.Content = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SelectedDate.Month)}  {SelectedDate.Year}";
                    break;
                case DayMonthYear.Month:
                    BtnIncMonth.Visibility = Visibility.Visible;
                    BtnDecMonth.Visibility = Visibility.Visible;
                    InitMonthPanel(SelectedDate.Year);
                    if (_currentPosition == DayMonthYear.Year)
                        _storyboard_yeartoMonth.Begin();
                    if (_currentPosition == DayMonthYear.Day)
                        _storyboard_daytoMonth.Begin();
                    BtnMonthYear.Content = $"{SelectedDate.Year}";
                    break;
                case DayMonthYear.Year:
                    BtnIncMonth.Visibility = Visibility.Collapsed;
                    BtnDecMonth.Visibility = Visibility.Collapsed;
                    InitYearPanel(SelectedDate.Year);
                    if (_currentPosition == DayMonthYear.Day)
                    {
                        _storyboard_daytoMonth.Begin();
                        _storyboard_monthtoYear.Begin();
                    }
                    if (_currentPosition == DayMonthYear.Month)
                        _storyboard_monthtoYear.Begin();


                    BtnMonthYear.Content = $"{SelectedDate.Year - 7} - {SelectedDate.Year + 7}";
                    break;
            }
            CheckButtonVisible();
            _currentPosition = dayMonthYear;
        }

        private void InitWeekTitle()
        {
            GrdWeek.Children.Clear();
            int count = 0;

            if (IsSundayFirst)
                GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Sunday), count++));

            GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Monday), count++));
            GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Tuesday), count++));
            GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Wednesday), count++));
            GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Thursday), count++));
            GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Friday), count++));
            GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Saturday), count++));

            if (!IsSundayFirst)
                GrdWeek.Children.Add(GetWeekTitleTextBlock(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DayOfWeek.Sunday), count++));
        }

        private void InitDayPanel(int year, int month)
        {
            var count = GrdDay.Children.Count;

            var group = Guid.NewGuid().ToString();
            for (int i = 0; i < 42 - count; i++)
            {
                var border = new Border();
                Grid.SetRow(border, (int)(i / 7));
                Grid.SetColumn(border, i % 7);

                var radioButton = new RadioButton()
                {
                    GroupName = group,
                    Padding = new Thickness(0),
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(0));
                radioButton.Click += RdbDay_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                GrdDay.Children.Add(border);
            }

            var currentMonthFirstDay = new DateTime(year, month, 1);
            var date = currentMonthFirstDay.AddDays((int)currentMonthFirstDay.DayOfWeek * -1 + (IsSundayFirst ? 0 : 1));

            for (int i = 0; i < 42; i++)
            {
                var currentDate = date.AddDays(i);
                var radioButton = (GrdDay.Children[i] as Border).Child as RadioButton;

                var isUnlimit = CheckDateLimit(currentDate, DayMonthYear.Day);

                radioButton.IsChecked = isUnlimit ? SelectedDate.Date == currentDate.Date : false;
                radioButton.Opacity = isUnlimit ? (currentDate.Month == month ? 1 : 0.5) : 0.2;
                radioButton.IsEnabled = isUnlimit;
                radioButton.Content = currentDate.Day;
                radioButton.Tag = currentDate;
            }
        }

        private void InitMonthPanel(int year)
        {
            var count = GrdMonth.Children.Count;
            var group = Guid.NewGuid().ToString();
            for (int i = 0; i < 12 - count; i++)
            {
                var border = new Border();
                Grid.SetRow(border, (int)(i / 4));
                Grid.SetColumn(border, i % 4);

                var radioButton = new RadioButton()
                {
                    GroupName = group,
                    Padding = new Thickness(0),
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(0));
                radioButton.Click += RdbMonth_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                GrdMonth.Children.Add(border);
            }

            var currentMonthFirstDay = new DateTime(year, 1, 1);

            for (int i = 0; i < 12; i++)
            {
                var currentDate = currentMonthFirstDay.AddMonths(i);

                var radioButton = (GrdMonth.Children[i] as Border).Child as RadioButton;

                var isUnlimit = CheckDateLimit(currentDate, DayMonthYear.Month);

                radioButton.IsChecked = isUnlimit ? (SelectedDate.Year == currentDate.Year && SelectedDate.Month == currentDate.Month) : false;
                radioButton.Opacity = isUnlimit ? 1 : 0.2;
                radioButton.IsEnabled = isUnlimit;
                radioButton.Content = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i + 1);
                radioButton.Tag = currentDate;
            }
        }

        private void InitYearPanel(int year)
        {
            var count = GrdYear.Children.Count;
            var group = Guid.NewGuid().ToString();
            for (int i = 0; i < 15 - count; i++)
            {
                var border = new Border();
                Grid.SetRow(border, (int)(i / 3));
                Grid.SetColumn(border, i % 3);

                var radioButton = new RadioButton()
                {
                    GroupName = group,
                    Padding = new Thickness(0),
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                };
                RadioButtonHelper.SetRadioButtonStyle(radioButton, RadioButtonStyle.Button);
                RadioButtonHelper.SetCornerRadius(radioButton, new CornerRadius(0));
                radioButton.Click += RdbYear_Click;

                SetBinding("Foreground", radioButton, ForegroundProperty);
                SetBinding("FontSize", radioButton, FontSizeProperty);
                SetBinding("ThemeBrush", radioButton, RadioButtonHelper.CheckedBackgroundProperty);
                border.Child = radioButton;
                GrdYear.Children.Add(border);
            }

            var firstYear = new DateTime(year, 1, 1).AddYears(-7);

            for (int i = 0; i < 15; i++)
            {
                var currentDate = firstYear.AddYears(i);
                var radioButton = (GrdYear.Children[i] as Border).Child as RadioButton;
                var isUnlimit = CheckDateLimit(currentDate, DayMonthYear.Year);
                radioButton.IsChecked = isUnlimit ? (SelectedDate.Year == currentDate.Year) : false;
                radioButton.Opacity = isUnlimit ? 1 : 0.2;
                radioButton.IsEnabled = isUnlimit;
                radioButton.Content = currentDate.Year;
                radioButton.Tag = currentDate;
            }
        }

        private System.Windows.Controls.TextBlock GetWeekTitleTextBlock(string week, int column)
        {
            var textBlock = new System.Windows.Controls.TextBlock()
            {
                Text = week,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            SetBinding("Foreground", textBlock, ForegroundProperty);
            Grid.SetColumn(textBlock, column);
            return textBlock;
        }

        private bool CheckDateLimit(DateTime date, DayMonthYear limitCompareMode)
        {
            date = date.Date;
            var result = true;
            if (MaxDate != null)
            {
                var maxDate = ((DateTime)MaxDate).Date;
                switch (limitCompareMode)
                {
                    case DayMonthYear.Day:
                        result = date.Date <= maxDate.Date;
                        break;
                    case DayMonthYear.Month:
                        result = date.Year < maxDate.Year ? true : (date.Year == maxDate.Year ? (date.Month <= maxDate.Month) : false);
                        break;
                    case DayMonthYear.Year:
                        result = date.Year <= maxDate.Year;
                        break;
                }
            }
            if (result && MinDate != null)
            {
                var minDate = ((DateTime)MinDate).Date;
                switch (limitCompareMode)
                {
                    case DayMonthYear.Day:
                        result = date >= minDate;
                        break;
                    case DayMonthYear.Month:
                        result = date.Year > minDate.Year ? true : (date.Year == minDate.Year ? (date.Month >= minDate.Month) : false);
                        break;
                    case DayMonthYear.Year:
                        result = date.Year >= minDate.Year;
                        break;
                }
            }
            return result;
        }

        private void CheckButtonVisible()
        {
            var selectedDate = SelectedDate.Date;
            if (MaxDate != null)
            {
                var maxDate = ((DateTime)MaxDate).Date;

                if (selectedDate.Year == maxDate.Year && selectedDate.Month == maxDate.Month)
                {
                    BtnIncYear.Visibility = Visibility.Collapsed;
                    BtnIncMonth.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnIncYear.Visibility = Visibility.Visible;
                    if (_currentPosition != DayMonthYear.Year)
                        BtnIncMonth.Visibility = Visibility.Visible;
                }
            }
            else
            {
                BtnIncYear.Visibility = Visibility.Visible;
                BtnIncMonth.Visibility = Visibility.Visible;
            }
            if (MinDate != null)
            {
                var minDate = ((DateTime)MinDate).Date;
                if (selectedDate.Year == minDate.Year && selectedDate.Month == minDate.Month)
                {
                    BtnDecYear.Visibility = Visibility.Collapsed;
                    BtnDecMonth.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnDecYear.Visibility = Visibility.Visible;
                    if (_currentPosition != DayMonthYear.Year)
                        BtnDecMonth.Visibility = Visibility.Visible;
                }
            }
            else
            {
                BtnDecYear.Visibility = Visibility.Visible;
                BtnDecMonth.Visibility = Visibility.Visible;
            }

        }

        private void SetBinding(string propertyName, DependencyObject target, DependencyProperty targetProperty)
        {
            var binding = new Binding { Path = new PropertyPath(propertyName), Source = this, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            BindingOperations.SetBinding(target, targetProperty, binding);
        }

        #endregion


    }

}
