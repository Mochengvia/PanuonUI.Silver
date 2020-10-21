using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Controls;
using Panuon.UI.Silver.Internal.Converters;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class CalendarX : Control
    {
        #region Fields
        private CalendarXDayPresenter _dayPresenter;

        private CalendarXMonthPresenter _monthPresenter;

        private CalendarXYearPresenter _yearPresenter;

        private CalendarXWeekPresenter _weekPresenter;

        private RepeatButton _backwardButton;

        private RepeatButton _previousButton;

        private RepeatButton _nextButton;

        private RepeatButton _forwardButton;

        private Button _yearButton;

        private Button _monthButton;

        private bool _isInternalSet;
        #endregion

        #region Ctor
        static CalendarX()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarX), new FrameworkPropertyMetadata(typeof(CalendarX)));
        }
        #endregion

        #region Events

        public event SelectedDatesChangedRoutedEventHandler SelectedDatesChanged
        {
            add { AddHandler(SelectedDatesChangedEvent, value); }
            remove { RemoveHandler(SelectedDatesChangedEvent, value); }
        }

        public static readonly RoutedEvent SelectedDatesChangedEvent =
            EventManager.RegisterRoutedEvent("SelectedDatesChanged", RoutingStrategy.Bubble, typeof(SelectedDatesChangedRoutedEventHandler), typeof(CalendarX));


        public event SelectedDateChangedRoutedEventHandler SelectedDateChanged
        {
            add { AddHandler(SelectedDateChangedEvent, value); }
            remove { RemoveHandler(SelectedDateChangedEvent, value); }
        }

        public static readonly RoutedEvent SelectedDateChangedEvent =
            EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Bubble, typeof(SelectedDateChangedRoutedEventHandler), typeof(CalendarX));
        #endregion

        #region Overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _backwardButton = Template?.FindName("PART_BackwardButton", this) as RepeatButton;
            _backwardButton.Click += BackwardButton_Click;
            _previousButton = Template?.FindName("PART_PreviousButton", this) as RepeatButton;
            _previousButton.Click += PreviousButton_Click;
            _nextButton = Template?.FindName("PART_NextButton", this) as RepeatButton;
            _nextButton.Click += NextButton_Click;
            _forwardButton = Template?.FindName("PART_ForwardButton", this) as RepeatButton;
            _forwardButton.Click += ForwardButton_Click;
            _yearButton = Template?.FindName("PART_YearButton", this) as Button;
            BindingUtils.BindingProperty(_yearButton, Button.ContentProperty, this, CurrentYearProperty, "D4");
            _yearButton.Click += YearButton_Click;
            _monthButton = Template?.FindName("PART_MonthButton", this) as Button;
            BindingUtils.BindingProperty(_monthButton, Button.ContentProperty, this, CurrentMonthProperty, new LocalizedMonthStringConverter());
            _monthButton.Click += MonthButton_Click;

            _weekPresenter = Template?.FindName("PART_WeekPresenter", this) as CalendarXWeekPresenter;
            BindingUtils.BindingProperty(_weekPresenter, CalendarXWeekPresenter.FirstDayOfWeekProperty, this, FirstDayOfWeekProperty);
            _dayPresenter = Template?.FindName("PART_DayPresenter", this) as CalendarXDayPresenter;
            BindingUtils.BindingProperty(_dayPresenter, CalendarXDayPresenter.ItemContainerStyleProperty, this, CalendarXItemStyleProperty);
            _monthPresenter = Template?.FindName("PART_MonthPresenter", this) as CalendarXMonthPresenter;
            BindingUtils.BindingProperty(_monthPresenter, CalendarXMonthPresenter.ItemContainerStyleProperty, this, CalendarXItemStyleProperty);
            _yearPresenter = Template?.FindName("PART_YearPresenter", this) as CalendarXYearPresenter;

            BindingUtils.BindingProperty(_yearPresenter, CalendarXYearPresenter.ItemContainerStyleProperty, this, CalendarXItemStyleProperty);

            _dayPresenter.Selected += DayPresenter_Selected;
            _dayPresenter.Unselected += DayPresenter_Unselected;
            _monthPresenter.Selected += MonthPresenter_Selected;
            _monthPresenter.Unselected += MonthPresenter_Unselected;
            _yearPresenter.Selected += YearPresenter_Selected;
            _yearPresenter.Unselected += YearPresenter_Unselected;
            _weekPresenter.UpdateWeeks();

            var dayDate = SelectedDate ?? DateTime.Now.Date;

            UpdateDays(dayDate.Year, dayDate.Month);
            UpdateMonths(dayDate.Year, dayDate.Month);
            UpdateYears(dayDate.Year, dayDate.Month);
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
            DependencyProperty.Register("HeaderHeight", typeof(double), typeof(CalendarX));
        #endregion

        #region HeaderBackground
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(CalendarX));
        #endregion

        #region ForwardButtonStyle
        public Style ForwardButtonStyle
        {
            get { return (Style)GetValue(ForwardButtonStyleProperty); }
            set { SetValue(ForwardButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ForwardButtonStyleProperty =
            DependencyProperty.Register("ForwardButtonStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region PreviousButtonStyle
        public Style PreviousButtonStyle
        {
            get { return (Style)GetValue(PreviousButtonStyleProperty); }
            set { SetValue(PreviousButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty PreviousButtonStyleProperty =
            DependencyProperty.Register("PreviousButtonStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region NextButtonStyle
        public Style NextButtonStyle
        {
            get { return (Style)GetValue(NextButtonStyleProperty); }
            set { SetValue(NextButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty NextButtonStyleProperty =
            DependencyProperty.Register("NextButtonStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region YearButtonStyle
        public Style YearButtonStyle
        {
            get { return (Style)GetValue(YearButtonStyleProperty); }
            set { SetValue(YearButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty YearButtonStyleProperty =
            DependencyProperty.Register("YearButtonStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region MonthButtonStyle
        public Style MonthButtonStyle
        {
            get { return (Style)GetValue(MonthButtonStyleProperty); }
            set { SetValue(MonthButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty MonthButtonStyleProperty =
            DependencyProperty.Register("MonthButtonStyle", typeof(Style), typeof(CalendarX));
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

        #region BackwardButtonStyle
        public Style BackwardButtonStyle
        {
            get { return (Style)GetValue(BackwardButtonStyleProperty); }
            set { SetValue(BackwardButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty BackwardButtonStyleProperty =
            DependencyProperty.Register("BackwardButtonStyle", typeof(Style), typeof(CalendarX));
        #endregion

        #region IsTodayHighlighted
        public bool IsTodayHighlighted
        {
            get { return (bool)GetValue(IsTodayHighlightedProperty); }
            set { SetValue(IsTodayHighlightedProperty, value); }
        }

        public static readonly DependencyProperty IsTodayHighlightedProperty =
            DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(CalendarX));
        #endregion

        #region Mode
        public CalendarXMode Mode
        {
            get { return (CalendarXMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(CalendarXMode), typeof(CalendarX));

        #endregion

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarX));
        #endregion

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarX), new PropertyMetadata(OnMaxDateChanged));
        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarX), new PropertyMetadata(OnMinDateChanged));
        #endregion

        #region SelectedDate
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(CalendarX), new PropertyMetadata(null, OnSelectedDateChanged));
        #endregion

        #region SelectedDates
        public ObservableCollection<DateTime> SelectedDates
        {
            get { return (ObservableCollection<DateTime>)GetValue(SelectedDatesProperty); }
            set { SetValue(SelectedDatesProperty, value); }
        }

        public static readonly DependencyProperty SelectedDatesProperty =
            DependencyProperty.Register("SelectedDates", typeof(ObservableCollection<DateTime>), typeof(CalendarX), new PropertyMetadata(OnSelectedDatesChanged));


        #endregion

        #endregion

        #region Internal Properties

        #region CurrentYear
        internal int CurrentYear
        {
            get { return (int)GetValue(CurrentYearProperty); }
            set { SetValue(CurrentYearProperty, value); }
        }

        internal static readonly DependencyProperty CurrentYearProperty =
            DependencyProperty.Register("CurrentYear", typeof(int), typeof(CalendarX));
        #endregion

        #region CurrentMonth
        internal int CurrentMonth
        {
            get { return (int)GetValue(CurrentMonthProperty); }
            set { SetValue(CurrentMonthProperty, value); }
        }

        internal static readonly DependencyProperty CurrentMonthProperty =
            DependencyProperty.Register("CurrentMonth", typeof(int), typeof(CalendarX), new PropertyMetadata(1));
        #endregion

        #region CurrentPanel
        internal int CurrentPanel
        {
            get { return (int)GetValue(CurrentPanelProperty); }
            set { SetValue(CurrentPanelProperty, value); }
        }

        internal static readonly DependencyProperty CurrentPanelProperty =
            DependencyProperty.Register("CurrentPanel", typeof(int), typeof(CalendarX));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        private static void OnMaxDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as CalendarX;
            calendar.OnDateLimitChanged();
        }

        private static void OnMinDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as CalendarX;
            calendar.OnDateLimitChanged();
        }

        private void MonthButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.DateRange:
                case CalendarXMode.MultipleDate:
                case CalendarXMode.YearMonth:
                    CurrentPanel = 1;
                    break;
            }
        }

        private void YearButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Mode)
            {
                default:
                    CurrentPanel = 2;
                    break;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);

                switch (CurrentPanel)
                {
                    case 0:
                        date = date.AddMonths(1);
                        break;
                    case 1:
                        date = date.AddYears(1);
                        break;
                    case 2:
                        date = date.AddYears(7);
                        break;
                    default:
                        return;
                }
                UpdateDays(date.Year, date.Month);
                UpdateMonths(date.Year, date.Month);
                UpdateYears(date.Year, date.Month);
            }
            catch
            {
            }
        }

        private void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);
                switch (CurrentPanel)
                {
                    case 0:
                        date = date.AddYears(-1);
                        break;
                    default:
                        return;
                }
                UpdateDays(date.Year, date.Month);
                UpdateMonths(date.Year, date.Month);
                UpdateYears(date.Year, date.Month);
            }
            catch
            {
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);

                switch (CurrentPanel)
                {
                    case 0:
                        date = date.AddMonths(-1);
                        break;
                    case 1:
                        date = date.AddYears(-1);
                        break;
                    case 2:
                        date = date.AddYears(-7);
                        break;
                    default:
                        return;
                }
                UpdateDays(date.Year, date.Month);
                UpdateMonths(date.Year, date.Month);
                UpdateYears(date.Year, date.Month);
            }
            catch
            {
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);

                switch (CurrentPanel)
                {
                    case 0:
                        date = date.AddYears(1);
                        break;
                    default:
                        return;
                }

                UpdateDays(date.Year, date.Month);
                UpdateMonths(date.Year, date.Month);
                UpdateYears(date.Year, date.Month);
            }
            catch
            {
            }
        }

        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as CalendarX;
            if (calendar == null)
            {
                return;
            }
            calendar.OnSelectedDateChanged();
        }

        private static void OnSelectedDatesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as CalendarX;
            if (calendar == null)
            {
                return;
            }
            if (e.OldValue != null)
            {
                (e.OldValue as ObservableCollection<DateTime>).CollectionChanged -= calendar.CalendarX_CollectionChanged;
            }
            if (e.NewValue != null)
            {
                (e.NewValue as ObservableCollection<DateTime>).CollectionChanged -= calendar.CalendarX_CollectionChanged;
                (e.NewValue as ObservableCollection<DateTime>).CollectionChanged += calendar.CalendarX_CollectionChanged;
                calendar.OnSelectedDatesChanged();
            }
            calendar.RaiseSelectedDatesChanged();
        }

        private void CalendarX_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnSelectedDatesChanged();
        }

        private void DayPresenter_Unselected(object sender, SelectedDateChangedEventArgs e)
        {
            var dateTime = (DateTime)e.SelectedDate;
            _isInternalSet = true;
            if (SelectedDates == null)
            {
                SelectedDates = new ObservableCollection<DateTime>();
            }
            switch (Mode)
            {
                case CalendarXMode.Date:
                    break;
                case CalendarXMode.DateRange:
                    SelectedDate = null;
                    break;
                case CalendarXMode.MultipleDate:
                    if (SelectedDates.Contains(dateTime))
                    {
                        SelectedDates.Remove(dateTime);
                    }
                    SelectedDate = null;
                    break;
            }
            UpdateDays(CurrentYear, CurrentMonth);
            UpdateYears(CurrentYear, CurrentMonth);
            UpdateMonths(CurrentYear, CurrentMonth);
            _isInternalSet = false;
        }

        private void DayPresenter_Selected(object sender, SelectedDateChangedEventArgs e)
        {
            var dateTime = (DateTime)e.SelectedDate;
            _isInternalSet = true;
            if (SelectedDates == null)
            {
                SelectedDates = new ObservableCollection<DateTime>();
            }
            switch (Mode)
            {
                case CalendarXMode.MultipleDate:
                    if (!SelectedDates.Any(x => x.Date.Equals(dateTime)))
                    {
                        SelectedDates.Add(dateTime);
                    }
                    break;
                case CalendarXMode.Date:
                    SelectedDates.Clear();
                    SelectedDates.Add(dateTime);
                    break;
                case CalendarXMode.DateRange:
                    for (int i = 0; i < SelectedDates.Count - 1; i++)
                    {
                        SelectedDates.RemoveAt(0);
                    }
                    SelectedDates.Add(dateTime);
                    break;
            }

            SelectedDate = dateTime;
            UpdateDays(dateTime.Year, dateTime.Month);
            _isInternalSet = false;
        }

        private void MonthPresenter_Unselected(object sender, SelectedDateChangedEventArgs e)
        {
            var dateTime = (DateTime)e.SelectedDate;
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.DateRange:
                case CalendarXMode.MultipleDate:
                    CurrentPanel = 0;
                    break;
            }
            UpdateMonths(CurrentYear, CurrentMonth);
            UpdateDays(CurrentYear, CurrentMonth);
        }

        private void MonthPresenter_Selected(object sender, SelectedDateChangedEventArgs e)
        {
            var dateTime = (DateTime)e.SelectedDate;
            _isInternalSet = true;
            if (SelectedDates == null)
            {
                SelectedDates = new ObservableCollection<DateTime>();
            }
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.DateRange:
                case CalendarXMode.MultipleDate:
                    CurrentPanel = 0;
                    break;
                case CalendarXMode.YearMonth:
                    SelectedDate = dateTime;
                    SelectedDates.Clear();
                    SelectedDates.Add(dateTime);
                    break;
            }
            UpdateYears(dateTime.Year, dateTime.Month);
            UpdateMonths(dateTime.Year, dateTime.Month);
            UpdateDays(dateTime.Year, dateTime.Month);
            _isInternalSet = false;
        }

        private void YearPresenter_Unselected(object sender, SelectedDateChangedEventArgs e)
        {
            var dateTime = (DateTime)e.SelectedDate;
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.DateRange:
                case CalendarXMode.MultipleDate:
                case CalendarXMode.YearMonth:
                    CurrentPanel = 1;
                    break;
            }
            UpdateYears(CurrentYear, CurrentMonth);
            UpdateMonths(CurrentYear, CurrentMonth);
            UpdateDays(CurrentYear, CurrentMonth);
        }

        private void YearPresenter_Selected(object sender, SelectedDateChangedEventArgs e)
        {
            var dateTime = (DateTime)e.SelectedDate;
            _isInternalSet = true;
            if (SelectedDates == null)
            {
                SelectedDates = new ObservableCollection<DateTime>();
            }
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.DateRange:
                case CalendarXMode.MultipleDate:
                case CalendarXMode.YearMonth:
                    CurrentPanel = 1;
                    break;
                case CalendarXMode.Year:
                    SelectedDate = dateTime;
                    SelectedDates.Clear();
                    SelectedDates.Add(dateTime);
                    break;
            }
            UpdateYears(dateTime.Year, dateTime.Month);
            UpdateMonths(dateTime.Year, dateTime.Month);
            UpdateDays(dateTime.Year, dateTime.Month);
            _isInternalSet = false;
        }

        #endregion

        #region Functions
        private void OnSelectedDatesChanged()
        {
            if (_dayPresenter == null)
            {
                return;
            }

            if (!_isInternalSet)
            {
                UpdateDays(CurrentYear, CurrentMonth);
                UpdateMonths(CurrentYear, CurrentMonth);
                UpdateYears(CurrentYear, CurrentMonth);
            }
            RaiseSelectedDatesChanged();
        }

        private void OnSelectedDateChanged()
        {
            if (_dayPresenter == null)
            {
                return;
            }

            if (!_isInternalSet)
            {
                if (SelectedDates == null)
                {
                    SelectedDates = new ObservableCollection<DateTime>();
                }
                if (SelectedDate != null && !SelectedDates.Contains((DateTime)SelectedDate))
                {
                    _isInternalSet = true;
                    SelectedDates.Add((DateTime)SelectedDate);
                    _isInternalSet = false;
                }
                var date = SelectedDate ?? new DateTime(CurrentYear, CurrentMonth, 1);
                UpdateDays(date.Year, date.Month);
                UpdateMonths(date.Year, date.Month);
                UpdateYears(date.Year, date.Month);
            }
            RaiseSelectedDateChanged();
        }

        private void UpdateDays(int year, int month)
        {
            if (_dayPresenter == null)
            {
                return;
            }
            CurrentYear = year;
            CurrentMonth = month;

            BindingUtils.BindingProperty(_dayPresenter, CalendarXDayPresenter.ModeProperty, this, ModeProperty);
            BindingUtils.BindingProperty(_dayPresenter, CalendarXDayPresenter.FirstDayOfWeekProperty, this, FirstDayOfWeekProperty);
            BindingUtils.BindingProperty(_dayPresenter, CalendarXDayPresenter.MinDateProperty, this, MinDateProperty);
            BindingUtils.BindingProperty(_dayPresenter, CalendarXDayPresenter.MaxDateProperty, this, MaxDateProperty);
            BindingUtils.BindingProperty(_dayPresenter, CalendarXDayPresenter.IsTodayHighlightedProperty, this, IsTodayHighlightedProperty);


            _dayPresenter.Mode = Mode;
            _dayPresenter.FirstDayOfWeek = FirstDayOfWeek;
            _dayPresenter.MinDate = MinDate;
            _dayPresenter.MaxDate = MaxDate;
            _dayPresenter.IsTodayHighlighted = IsTodayHighlighted;

            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);
                _dayPresenter.Update(date.Year, date.Month, SelectedDates);
            }
            catch
            {

            }
        }

        private void UpdateMonths(int year, int month)
        {
            if (_monthPresenter == null)
            {
                return;
            }
            CurrentYear = year;
            CurrentMonth = month;

            _monthPresenter.FirstDayOfWeek = FirstDayOfWeek;
            _monthPresenter.MinDate = MinDate;
            _monthPresenter.MaxDate = MaxDate;

            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);
                _monthPresenter.Update(date.Year, date.Month);
            }
            catch
            {

            }
        }

        private void UpdateYears(int year, int month)
        {
            if (_monthPresenter == null)
            {
                return;
            }
            CurrentYear = year;
            CurrentMonth = month;
            _yearPresenter.FirstDayOfWeek = FirstDayOfWeek;
            _yearPresenter.MinDate = MinDate;
            _yearPresenter.MaxDate = MaxDate;
            try
            {
                var date = new DateTime(CurrentYear, CurrentMonth, 1);
                _yearPresenter.Update(date.Year, date.Month);
            }
            catch
            {

            }
        }

        private void OnDateLimitChanged()
        {
            _isInternalSet = true;
            if (SelectedDates == null)
            {
                SelectedDates = new ObservableCollection<DateTime>();
            }
            if (SelectedDate != null && MinDate != null && SelectedDate < MinDate)
            {
                var date = (DateTime)SelectedDate;
                if (SelectedDates.Contains(date))
                {
                    SelectedDates.Remove(date);
                }
                SelectedDate = MinDate;
                SelectedDates.Add((DateTime)SelectedDate);
            }
            else if(SelectedDate != null && MaxDate != null && SelectedDate > MaxDate)
            {
                var date = (DateTime)SelectedDate;
                if (SelectedDates.Contains(date))
                {
                    SelectedDates.Remove(date);
                }
                SelectedDate = MaxDate;
                SelectedDates.Add((DateTime)SelectedDate);
            }
            if (SelectedDates != null)
            {
                for (int i = SelectedDates.Count - 1; i >= 0; i--)
                {
                    var date = SelectedDates[i];
                    if (date < MinDate || date > MaxDate)
                    {
                        SelectedDates.RemoveAt(i);
                    }
                }
            }
            UpdateDays(CurrentYear, CurrentMonth);
            UpdateMonths(CurrentYear, CurrentMonth);
            UpdateYears(CurrentYear, CurrentMonth);
        }

        private void RaiseSelectedDatesChanged()
        {
            RaiseEvent(new SelectedDatesChangedRoutedEventArgs(SelectedDatesChangedEvent, SelectedDates));
        }

        private void RaiseSelectedDateChanged()
        {
            RaiseEvent(new SelectedDateChangedRoutedEventArgs(SelectedDateChangedEvent, SelectedDate));
        }
        #endregion
    }
}
