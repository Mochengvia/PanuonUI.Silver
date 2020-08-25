using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    class CalendarXDayPresenter : ItemsControl
    {
        #region Fields
        private bool _isItemsInitialized;
        #endregion

        #region Ctor
        public CalendarXDayPresenter()
        {
            AddHandler(CalendarXItem.ClickEvent, new RoutedEventHandler(OnCalendarXItemClicked));
        }

        static CalendarXDayPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXDayPresenter), new FrameworkPropertyMetadata(typeof(CalendarXDayPresenter)));
        }
        #endregion

        #region Events
        public event SelectedDateChangedEventHandler Selected;

        public event SelectedDateChangedEventHandler Unselected;
        #endregion

        #region Overrides
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is CalendarXItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CalendarXItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var calendarXItem = element as CalendarXItem;
            BindingUtils.BindingProperty(calendarXItem, CalendarXItem.ContentProperty, item, CalendarXItemModel.ContentProperty);
            BindingUtils.BindingProperty(calendarXItem, CalendarXItem.IsCheckedProperty, item, CalendarXItemModel.IsCheckedProperty, System.Windows.Data.BindingMode.TwoWay);
            BindingUtils.BindingProperty(calendarXItem, CalendarXItem.IsDownplayProperty, item, CalendarXItemModel.IsDownplayProperty);
            BindingUtils.BindingProperty(calendarXItem, CalendarXItem.IsTodayProperty, item, CalendarXItemModel.IsTodayProperty);
            BindingUtils.BindingProperty(calendarXItem, CalendarXItem.IsInRangeProperty, item, CalendarXItemModel.IsInRangeProperty);
            BindingUtils.BindingProperty(calendarXItem, CalendarXItem.IsEnabledProperty, item, CalendarXItemModel.IsEnabledProperty);
        }
        #endregion

        #region Properties

        #region Mode
        public CalendarXMode Mode
        {
            get { return (CalendarXMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(CalendarXMode), typeof(CalendarXDayPresenter));
        #endregion

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarXDayPresenter));

        #endregion

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarXDayPresenter));

        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarXDayPresenter));
        #endregion

        #region IsTodayHighlighted
        public bool IsTodayHighlighted
        {
            get { return (bool)GetValue(IsTodayHighlightedProperty); }
            set { SetValue(IsTodayHighlightedProperty, value); }
        }

        public static readonly DependencyProperty IsTodayHighlightedProperty =
            DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(CalendarXDayPresenter));
        #endregion

        #endregion

        #region Internal Properties
        internal ObservableCollection<CalendarXItemModel> CalendarXItemModels
        {
            get { return (ObservableCollection<CalendarXItemModel>)GetValue(CalendarXItemModelsProperty); }
            set { SetValue(CalendarXItemModelsProperty, value); }
        }

        internal static readonly DependencyProperty CalendarXItemModelsProperty =
           DependencyProperty.Register("CalendarXItemModels", typeof(ObservableCollection<CalendarXItemModel>), typeof(CalendarXDayPresenter));
        #endregion

        #region Methods
        internal void Update(int year,
            int month,
            IEnumerable<DateTime> selectedDates)
        {
            if (!_isItemsInitialized)
            {
                CalendarXItemModels = new ObservableCollection<CalendarXItemModel>();
            }

            var currentDay = new DateTime(year, month, 1);
            var dayOfWeek = currentDay.DayOfWeek;
            var preDelta = dayOfWeek - FirstDayOfWeek;
            preDelta = preDelta < 0 ? (preDelta + 7) : preDelta;

            currentDay = currentDay.AddDays(-preDelta);

            for (var i = 0; i < 42; i++)
            {
                CalendarXItemModel dayItem = null;
                if(!_isItemsInitialized)
                {
                    dayItem = new CalendarXItemModel();
                    CalendarXItemModels.Add(dayItem);
                }
                else
                {
                    dayItem = CalendarXItemModels[i];
                }

                dayItem.Content = currentDay.Day;
                if (IsDateAvailable(currentDay))
                {
                    dayItem.IsEnabled = true;
                    dayItem.IsChecked = selectedDates == null ? false : selectedDates.Any(x => x.Equals(currentDay));
                    dayItem.Date = currentDay;
                    dayItem.IsDownplay = !(currentDay.Year == year && currentDay.Month == month);
                    dayItem.IsToday = IsTodayHighlighted ? IsToday(currentDay) : false;
                    dayItem.IsInRange = Mode == CalendarXMode.DateRange ?
                        IsInRange(currentDay, selectedDates?.ToArray())
                        : false;
                }
                else
                {
                    dayItem.IsEnabled = false;
                }


                currentDay = currentDay.AddDays(1);
            }

            _isItemsInitialized = true;
        }
        #endregion

        #region Event Handlers
        private void OnCalendarXItemClicked(object sender, RoutedEventArgs e)
        {
            var calendarXItem = e.OriginalSource as CalendarXItem;
            var calendarXItemModel = calendarXItem?.DataContext as CalendarXItemModel;
            if (calendarXItemModel == null)
            {
                return;
            }

            if (calendarXItemModel.IsChecked)
            {
                Selected?.Invoke(this, new SelectedDateChangedEventArgs(calendarXItemModel.Date));
            }
            else
            {
                Unselected?.Invoke(this, new SelectedDateChangedEventArgs(calendarXItemModel.Date));
            }
        }
        #endregion

        #region Functions
        
        private bool IsInRange(DateTime date, params DateTime[] selectedDates)
        {
            if(selectedDates == null || selectedDates.Length < 2)
            {
                return false;
            }
            var startDate = selectedDates.Min();
            var endDate = selectedDates.Max();
            return date < endDate && date > startDate;
        }
        private bool IsToday(DateTime date)
        {
            return date.Date.Equals(DateTime.Now.Date);
        }

        private bool IsDateAvailable(DateTime date)
        {
            return date > MaxDate ? false : !(date < MinDate);
        }
        #endregion
    }
}
