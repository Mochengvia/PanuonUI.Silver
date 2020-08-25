using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    class CalendarXMonthPresenter : ItemsControl
    {
        #region Fields
        private bool _isItemsInitialized;
        #endregion

        #region Ctor
        public CalendarXMonthPresenter()
        {
            AddHandler(CalendarXItem.ClickEvent, new RoutedEventHandler(OnCalendarXItemClicked));
        }

        static CalendarXMonthPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXMonthPresenter), new FrameworkPropertyMetadata(typeof(CalendarXMonthPresenter)));
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

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarXMonthPresenter));

        #endregion

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarXMonthPresenter));

        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarXMonthPresenter));
        #endregion

        #endregion

        #region Internal Properties
        internal ObservableCollection<CalendarXItemModel> CalendarXItemModels
        {
            get { return (ObservableCollection<CalendarXItemModel>)GetValue(CalendarXItemModelsProperty); }
            set { SetValue(CalendarXItemModelsProperty, value); }
        }

        internal static readonly DependencyProperty CalendarXItemModelsProperty =
           DependencyProperty.Register("CalendarXItemModels", typeof(ObservableCollection<CalendarXItemModel>), typeof(CalendarXMonthPresenter));
        #endregion

        #region Methods
        internal void Update(int year,
            int month)
        {
            if (!_isItemsInitialized)
            {
                CalendarXItemModels = new ObservableCollection<CalendarXItemModel>();
            }
            for (var i = 0; i < 12; i++)
            {
                var currentMonth = new DateTime(year, i + 1, 1);
                CalendarXItemModel dayItem = null;
                if (!_isItemsInitialized)
                {
                    dayItem = new CalendarXItemModel()
                    {
                        Content = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1),
                    };
                    CalendarXItemModels.Add(dayItem);
                }
                else
                {
                    dayItem = CalendarXItemModels[i];
                }

                if (IsDateAvailable(currentMonth))
                {
                    dayItem.IsEnabled = true;
                    dayItem.IsChecked = month == i + 1;
                    dayItem.Date = currentMonth;
                    dayItem.IsDownplay = false;
                    dayItem.IsToday = false;
                    dayItem.IsInRange = false;
                }
                else
                {
                    dayItem.IsEnabled = false;
                }
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
        private bool IsDateAvailable(DateTime date)
        {
            if (MaxDate != null)
            {
                var maxDate = (DateTime)MaxDate;
                if (date.Year > maxDate.Year)
                {
                    return false;
                }
                else if (date.Year == maxDate.Year && date.Month > maxDate.Month)
                {
                    return false;
                }
            }
            if (MinDate != null)
            {
                var minDate = (DateTime)MinDate;
                if (date.Year < minDate.Year)
                {
                    return false;
                }
                else if (date.Year == minDate.Year && date.Month < minDate.Month)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
