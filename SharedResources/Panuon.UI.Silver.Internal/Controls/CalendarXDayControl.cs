using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    class CalendarXDayControl : Control
    {
        #region Ctor
        static CalendarXDayControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXDayControl), new FrameworkPropertyMetadata(typeof(CalendarXDayControl)));
        }

        public CalendarXDayControl()
        {
            AddHandler(CalendarXItem.ClickEvent, new RoutedEventHandler(OnCalendarXItemClick));
        }

        #endregion

        #region Properties

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarXDayControl), new PropertyMetadata(OnMaxDateChanged));

        private static void OnMaxDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MinDate
        public DateTime? MinDate
        {
            get { return (DateTime?)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarXDayControl), new PropertyMetadata(OnMinDateChanged));

        private static void OnMinDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Mode
        public CalendarXMode Mode
        {
            get { return (CalendarXMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(CalendarXMode), typeof(CalendarXDayControl), new PropertyMetadata(OnModeChanged));

        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarXDayControl), new PropertyMetadata(OnFirstDayOfWeekChanged));

        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Days
        public ObservableCollection<CalendarXItemModel> Days
        {
            get { return (ObservableCollection<CalendarXItemModel>)GetValue(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }

        public static readonly DependencyProperty DaysProperty =
            DependencyProperty.Register("Days", typeof(ObservableCollection<CalendarXItemModel>), typeof(CalendarXDayControl));
        #endregion

        #region Weeks
        public ObservableCollection<string> Weeks
        {
            get { return (ObservableCollection<string>)GetValue(WeeksProperty); }
            set { SetValue(WeeksProperty, value); }
        }

        public static readonly DependencyProperty WeeksProperty =
            DependencyProperty.Register("Weeks", typeof(ObservableCollection<string>), typeof(CalendarXDayControl));
        #endregion

        #endregion

        #region Methods

        #region Update
        public void Update(DateTime currentDate,
            IEnumerable<DateTime> selectedDates)
        {
            var isFirstTime = (Days == null);

            if (isFirstTime)
            {
                Days = new ObservableCollection<CalendarXItemModel>();
                Weeks = new ObservableCollection<string>();
                for (var i = 0; i < 7; i++)
                {
                    Weeks.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(FirstDayOfWeek + i));
                }
            }
            var currentFirstDay = DateTimeUtils.GetFirstDayDate(currentDate);
            var dayOfWeek = currentFirstDay.DayOfWeek;
            var daysInMonth = DateTimeUtils.GetDayInMonth(currentFirstDay);

            var preDelta = dayOfWeek - FirstDayOfWeek;
            preDelta = preDelta < 0 ? (preDelta + 7) : preDelta;

            for (var i = 0; i < preDelta; i++)
            {
                var dayItem = isFirstTime ? new CalendarXItemModel() : Days[i];
                var date = currentFirstDay.AddDays(-preDelta + i);

                UpdateDayItem(dayItem, selectedDates, date, false);
                if (isFirstTime)
                {
                    Days.Add(dayItem);
                }
            }

            for (var i = 0; i < daysInMonth; i++)
            {
                var dayItem = isFirstTime ? new CalendarXItemModel() : Days[i + preDelta];
                var date = currentFirstDay.AddDays(i);

                UpdateDayItem(dayItem, selectedDates, date, true);
                if (isFirstTime)
                {
                    Days.Add(dayItem);
                }
            }

            for (var i = 0; i < 42 - preDelta - daysInMonth; i++)
            {
                var dayItem = isFirstTime ? new CalendarXItemModel() : Days[i + preDelta + daysInMonth];
                var date = currentFirstDay.AddDays(i);

                UpdateDayItem(dayItem, selectedDates, date, false);
                if (isFirstTime)
                {
                    Days.Add(dayItem);
                }
            }
        }
        #endregion

        #endregion

        #region Event Handlers

        private void OnCalendarXItemClick(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as CalendarXItem;
            if (item == null)
            {
                return;
            }
            var model = item.DataContext as CalendarXItemModel;
            if (model == null)
            {
                return;
            }

            var isSelected = model.IsChecked == true;
            var date = model.Value;

            switch (Mode)
            {
                case CalendarXMode.Date:
                    if (model.IsChecked)
                    {
                        Days.Where(x => x != model).Apply(x => x.IsChecked = false);
                    }
                    else
                    {
                        model.IsChecked = true;
                        return;
                    }
                    break;
            }
        }
        #endregion

        #region Functions

        private void UpdateDayItem(CalendarXItemModel item,
            IEnumerable<DateTime> selectedDates,
            DateTime date,
            bool isCurrentMonth)
        {
            item.Content = date.Day;
            item.IsChecked = selectedDates.Any(x => x.Equals(date));
            item.Value = date;
            item.IsWeakenDisplay = !isCurrentMonth;
            item.IsToday = IsToday(date);
            item.IsEnabled = IsDateAvailable(date);
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
