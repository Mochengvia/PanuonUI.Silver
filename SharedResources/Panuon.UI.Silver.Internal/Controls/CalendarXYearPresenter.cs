using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    class CalendarXYearPresenter : ItemsControl
    {
        #region Fields
        private bool _isItemsInitialized;
        #endregion

        #region Ctor
        public CalendarXYearPresenter()
        {
            AddHandler(CalendarXItem.ClickEvent, new RoutedEventHandler(OnCalendarXItemClicked));
        }

        static CalendarXYearPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXYearPresenter), new FrameworkPropertyMetadata(typeof(CalendarXYearPresenter)));
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
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarXYearPresenter));

        #endregion

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarXYearPresenter));

        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarXYearPresenter));
        #endregion


        #endregion

        #region Internal Properties
        internal ObservableCollection<CalendarXItemModel> CalendarXItemModels
        {
            get { return (ObservableCollection<CalendarXItemModel>)GetValue(CalendarXItemModelsProperty); }
            set { SetValue(CalendarXItemModelsProperty, value); }
        }

        internal static readonly DependencyProperty CalendarXItemModelsProperty =
           DependencyProperty.Register("CalendarXItemModels", typeof(ObservableCollection<CalendarXItemModel>), typeof(CalendarXYearPresenter));
        #endregion

        #region Methods
        internal void Update(int year, int month)
        {
            if (!_isItemsInitialized)
            {
                CalendarXItemModels = new ObservableCollection<CalendarXItemModel>();
            }
            var startYear = year - 7;
            if(startYear < 1)
            {
                startYear = 1;
            }

            for (var i = 0; i < 15; i++)
            {
                var currentYear = new DateTime(startYear + i, month, 1);
                CalendarXItemModel dayItem = null;
                if (!_isItemsInitialized)
                {
                    dayItem = new CalendarXItemModel();
                    CalendarXItemModels.Add(dayItem);
                }
                else
                {
                    dayItem = CalendarXItemModels[i];
                }

                dayItem.Content = (startYear + i).ToString("D4");

                if (IsDateAvailable(currentYear))
                {
                    dayItem.IsEnabled = true;
                    dayItem.IsChecked = year == (startYear + i);
                    dayItem.Date = currentYear;
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
