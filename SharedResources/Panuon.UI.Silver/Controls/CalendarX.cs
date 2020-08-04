using Panuon.UI.Silver.Internal.Controls;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class CalendarX : Control
    {
        #region Fields
        private const string PART_Backward = nameof(PART_Backward);
        private const string PART_Previous = nameof(PART_Previous);
        private const string PART_Next = nameof(PART_Next);
        private const string PART_Forward = nameof(PART_Forward);
        private const string PART_Month = nameof(PART_Month);
        private const string PART_Year = nameof(PART_Year);

        private CalendarXDayControl _calendarXDayControl;

        private CalendarXMonthControl _calendarXMonthControl;

        private CalendarXYearControl _calendarXYearControl;
        #endregion

        #region Ctor
        static CalendarX()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarX), new FrameworkPropertyMetadata(typeof(CalendarX)));
        }
        #endregion

        #region Properties

        #region ShadowColor
        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(CalendarX));
        #endregion

        #region CaptionHeight
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register("CaptionHeight", typeof(double), typeof(CalendarX));
        #endregion

        #region SelectedDate
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(CalendarX), new PropertyMetadata(null, OnSelectedDateChanged, CoerceSelectedDate));
        #endregion

        #region SelectedDates
        public ObservableCollection<DateTime> SelectedDates
        {
            get
            {
                if (_selectedDates == null)
                {
                    _selectedDates = new ObservableCollection<DateTime>();
                    _selectedDates.CollectionChanged += SelectedDates_CollectionChanged;
                }
                return _selectedDates;
            }
        }


        private ObservableCollection<DateTime> _selectedDates;
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

        #region Mode
        public CalendarXMode Mode
        {
            get { return (CalendarXMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(CalendarXMode), typeof(CalendarX), new PropertyMetadata(OnModeChanged));
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

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(CalendarX));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(CalendarX));
        #endregion

        #region ButtonStyle
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(CalendarX));
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

        #endregion

        #region Internal Properties

        #region CurrentPanel
        internal int CurrentPanel
        {
            get { return (int)GetValue(CurrentPanelProperty); }
            set { SetValue(CurrentPanelProperty, value); }
        }

        internal static readonly DependencyProperty CurrentPanelProperty =
            DependencyProperty.Register("CurrentPanel", typeof(int), typeof(CalendarX), new PropertyMetadata(0, null, CoerceCurrentPanel));

        #endregion

        #region MonthButton
        internal object MonthButton
        {
            get { return (object)GetValue(MonthButtonProperty); }
            set { SetValue(MonthButtonProperty, value); }
        }

        internal static readonly DependencyProperty MonthButtonProperty =
            DependencyProperty.Register("MonthButton", typeof(object), typeof(CalendarX));
        #endregion

        #region YearButton
        internal object YearButton
        {
            get { return (object)GetValue(YearButtonProperty); }
            set { SetValue(YearButtonProperty, value); }
        }

        internal static readonly DependencyProperty YearButtonProperty =
            DependencyProperty.Register("YearButton", typeof(object), typeof(CalendarX));
        #endregion

        #region CurrentDate
        internal DateTime CurrentDate
        {
            get { return (DateTime)GetValue(CurrentDateProperty); }
            set { SetValue(CurrentDateProperty, value); }
        }

        internal static readonly DependencyProperty CurrentDateProperty =
            DependencyProperty.Register("CurrentDate", typeof(DateTime), typeof(CalendarX), new PropertyMetadata(OnCurrentDateChanged));
        #endregion

        #endregion

        #region Overrides
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                _calendarXDayControl = Template?.FindName("PART_DayControl", this) as CalendarXDayControl;
                _calendarXMonthControl = Template?.FindName("PART_MonthControl", this) as CalendarXMonthControl;
                _calendarXYearControl = Template?.FindName("PART_YearControl", this) as CalendarXYearControl;

                _calendarXMonthControl.Selected += CalendarXMonthControl_Selected;
                _calendarXYearControl.Selected += CalendarXYearControl_Selected;
              var  backwardButton = Template?.FindName(PART_Backward, this) as Button;
                var previousButton = Template?.FindName(PART_Previous, this) as Button;
                var nextButton = Template?.FindName(PART_Next, this) as Button;
                var forwardButton = Template?.FindName(PART_Forward, this) as Button;
                var monthButton = Template?.FindName(PART_Month, this) as Button;
                var yearButton = Template?.FindName(PART_Year, this) as Button;

                backwardButton.Click -= ControlButton_Click;
                backwardButton.Click += ControlButton_Click;
                previousButton.Click -= ControlButton_Click;
                previousButton.Click += ControlButton_Click;
                nextButton.Click -= ControlButton_Click;
                nextButton.Click += ControlButton_Click;
                forwardButton.Click -= ControlButton_Click;
                forwardButton.Click += ControlButton_Click;
                monthButton.Click -= MonthButton_Click;
                monthButton.Click += MonthButton_Click;
                yearButton.Click -= YearButton_Click;
                yearButton.Click += YearButton_Click;

                if (SelectedDate != null)
                {
                    CurrentDate = (DateTime)SelectedDate;
                }
                else
                {
                    CurrentDate = DateTime.Now.Date;
                }
            }));
        }




        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        private void CalendarXMonthControl_Selected(Internal.CalendarXSelectedEventArgs args)
        {
            if (args.Date.Year != CurrentDate.Year || args.Date.Month != CurrentDate.Month)
            {
                CurrentDate = DateTimeUtils.VerifyDateTime(args.Date.Year, args.Date.Month, CurrentDate.Day);
            }
            switch (Mode)
            {
                case CalendarXMode.Year:
                case CalendarXMode.YearMonth:
                    return;
                default:
                    CurrentPanel--;
                    break;
            }
        }

        private void CalendarXYearControl_Selected(Internal.CalendarXSelectedEventArgs args)
        {
            if(args.Date.Year != CurrentDate.Year)
            {
                CurrentDate = DateTimeUtils.VerifyDateTime(args.Date.Year, CurrentDate.Month, CurrentDate.Day);
            }
            switch (Mode)
            {
                case CalendarXMode.Year:
                    return;
                default:
                    CurrentPanel--;
                    break;
            }
        }

        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

        private static void OnCurrentDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as CalendarX;
            calendar.UpdateButtonContent();
            calendar.UpdateDayControl();
            calendar.UpdateMonthControl();
            calendar.UpdateYearControl();
        }

        private static object CoerceCurrentPanel(DependencyObject d, object baseValue)
        {
            var calendar = d as CalendarX;
            if (calendar.Mode != CalendarXMode.Year && calendar.Mode != CalendarXMode.YearMonth)
            {
                return baseValue;
            }
            var index = baseValue as int? ?? 0;
            switch (calendar.Mode)
            {
                case CalendarXMode.Year:
                    return index < 2 ? index : 1;
                case CalendarXMode.YearMonth:
                    return index > 0 ? index : 1;
            }
            throw new NotImplementedException($"CalendarX error : unsupported mode {calendar.Mode}");
        }

        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendar = d as CalendarX;
            if (e.OldValue != null)
            {
                var dateTime = (DateTime)e.OldValue;
                if (calendar.SelectedDates.Any(x => x.Equals(dateTime)))
                {
                    calendar.SelectedDates.Remove(calendar.SelectedDates.First(x => x.Equals(dateTime)));
                }
            }
            if (e.NewValue != null)
            {
                var dateTime = (DateTime)e.NewValue;
                if (!calendar.SelectedDates.Any(x => x.Equals(dateTime)))
                {
                    calendar.SelectedDates.Add(dateTime);
                }
                calendar.CurrentDate = dateTime;
            }
        }

        private static object CoerceSelectedDate(DependencyObject d, object baseValue)
        {
            var dateTime = baseValue as DateTime?;
            if (dateTime == null)
            {
                return null;
            }
            else
            {
                //TODO : Validate datetime
                return ((DateTime)dateTime).Date;
            }
        }

        private static void OnMaxDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnMinDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            switch (button.Name)
            {
                case PART_Backward:
                    switch (CurrentPanel)
                    {
                        case 0:
                            CurrentDate = CurrentDate.AddYears(-1);
                            break;
                        case 1:
                            CurrentDate = CurrentDate.AddYears(-1);
                            break;
                        case 2:
                            CurrentDate = CurrentDate.AddYears(-7);
                            break;
                    }
                    break;
                case PART_Previous:
                    switch (CurrentPanel)
                    {
                        case 0:
                        case 1:
                            CurrentDate = CurrentDate.AddMonths(-1);
                            break;
                        case 2:
                            CurrentDate = CurrentDate.AddYears(-1);
                            break;
                    }
                    break;
                case PART_Next:
                    switch (CurrentPanel)
                    {
                        case 0:
                        case 1:
                            CurrentDate = CurrentDate.AddMonths(1);
                            break;
                        case 2:
                            CurrentDate = CurrentDate.AddYears(1);
                            break;
                    }
                    break;
                case PART_Forward:
                    switch (CurrentPanel)
                    {
                        case 0:
                            CurrentDate = CurrentDate.AddYears(1);
                            break;
                        case 1:
                            CurrentDate = CurrentDate.AddYears(1);
                            break;
                        case 2:
                            CurrentDate = CurrentDate.AddYears(7);
                            break;
                    }
                    break;
            }
        }

        private void YearButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPanel = 2;
        }

        private void MonthButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPanel = 1;
        }
        #endregion

        #region Functions
        private void UpdateButtonContent()
        {
            MonthButton = CultureInfo.CurrentUICulture.DateTimeFormat.GetMonthName(CurrentDate.Month);
            YearButton = CurrentDate.Year;
        }

        private void UpdateDayControl()
        {
            _calendarXDayControl.Update(CurrentDate, SelectedDates);
        }

        private void UpdateMonthControl()
        {
            _calendarXMonthControl.Update(CurrentDate);
        }

        private void UpdateYearControl()
        {
            _calendarXYearControl.Update(CurrentDate);
        }

        #endregion
    }
}
