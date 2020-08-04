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
    class CalendarXMonthControl : Control
    {
        #region Ctor
        static CalendarXMonthControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXMonthControl), new FrameworkPropertyMetadata(typeof(CalendarXMonthControl)));
        }

        public CalendarXMonthControl()
        {
            AddHandler(CalendarXItem.ClickEvent, new RoutedEventHandler(OnCalendarXItemClick));
        }

        #endregion

        #region Events
        internal event CalendarXSelectedEventHandler Selected;
        #endregion

        #region Properties

        #region MaxDate
        public DateTime? MaxDate
        {
            get { return (DateTime?)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarXMonthControl), new PropertyMetadata(OnMaxDateChanged));

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
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarXMonthControl), new PropertyMetadata(OnMinDateChanged));

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
            DependencyProperty.Register("Mode", typeof(CalendarXMode), typeof(CalendarXMonthControl), new PropertyMetadata(OnModeChanged));

        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Months
        public ObservableCollection<CalendarXItemModel> Months
        {
            get { return (ObservableCollection<CalendarXItemModel>)GetValue(MonthsProperty); }
            set { SetValue(MonthsProperty, value); }
        }

        public static readonly DependencyProperty MonthsProperty =
            DependencyProperty.Register("Months", typeof(ObservableCollection<CalendarXItemModel>), typeof(CalendarXMonthControl));
        #endregion

        #endregion

        #region Methods

        #region Update
        public void Update(DateTime currentDate)
        {
            var isFirstTime = (Months == null);

            if (isFirstTime)
            {
                Months = new ObservableCollection<CalendarXItemModel>();
            }

            var currentFirstMonth = DateTimeUtils.GetFirstMonthDate(currentDate);

            for (var i = 0; i < 12; i++)
            {
                var monthItem = isFirstTime ? new CalendarXItemModel() : Months[i];
                var date = currentFirstMonth.AddMonths(i);

                UpdateMonthItem(monthItem, currentDate, date, false);
                if (isFirstTime)
                {
                    Months.Add(monthItem);
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

                    if (model.IsChecked)
                    {
                        Months.Where(x => x != model).Apply(x => x.IsChecked = false);
                    }
                    else
                    {
                        model.IsChecked = true;
                    }

            Selected?.Invoke(new CalendarXSelectedEventArgs() { Date = date });
        }
        #endregion

        #region Functions

        private void UpdateMonthItem(CalendarXItemModel item,
            DateTime currentDate,
            DateTime date,
            bool isCurrentMonth)
        {
            item.Content = CultureInfo.CurrentUICulture.DateTimeFormat.GetMonthName(date.Month);
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.YearMonth:
                    item.IsChecked = currentDate == null ? false : (((DateTime)currentDate).Month == date.Month);
                    break;
                default:
                    item.IsChecked = false;
                    break;
            }
            item.Value = date;
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
