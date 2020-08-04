using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    class CalendarXYearControl : Control
    {
        #region Ctor
        static CalendarXYearControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXYearControl), new FrameworkPropertyMetadata(typeof(CalendarXYearControl)));
        }

        public CalendarXYearControl()
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
            DependencyProperty.Register("MaxDate", typeof(DateTime?), typeof(CalendarXYearControl), new PropertyMetadata(OnMaxDateChanged));

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
            DependencyProperty.Register("MinDate", typeof(DateTime?), typeof(CalendarXYearControl), new PropertyMetadata(OnMinDateChanged));

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
            DependencyProperty.Register("Mode", typeof(CalendarXMode), typeof(CalendarXYearControl), new PropertyMetadata(OnModeChanged));

        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Years
        public ObservableCollection<CalendarXItemModel> Years
        {
            get { return (ObservableCollection<CalendarXItemModel>)GetValue(YearsProperty); }
            set { SetValue(YearsProperty, value); }
        }

        public static readonly DependencyProperty YearsProperty =
            DependencyProperty.Register("Years", typeof(ObservableCollection<CalendarXItemModel>), typeof(CalendarXYearControl));
        #endregion

        #endregion

        #region Events
        internal event CalendarXSelectedEventHandler Selected;
        #endregion

        #region Methods

        #region Update
        public void Update(DateTime currentDate)
        {
            var isFirstTime = (Years == null);

            if (isFirstTime)
            {
                Years = new ObservableCollection<CalendarXItemModel>();
            }

            currentDate = DateTimeUtils.GetFirstMonthDate(currentDate);
            var currentFirstYear = currentDate.AddYears(-7);

            for (var i = 0; i < 15; i++)
            {
                var monthItem = isFirstTime ? new CalendarXItemModel() : Years[i];
                var date = currentFirstYear.AddYears(i);

                UpdateYearItem(monthItem, currentDate, date, false);
                if (isFirstTime)
                {
                    Years.Add(monthItem);
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
                Years.Where(x => x != model).Apply(x => x.IsChecked = false);
            }
            else
            {
                model.IsChecked = true;
            }
            Selected?.Invoke(new CalendarXSelectedEventArgs() { Date = date });
        }
        #endregion

        #region Functions

        private void UpdateYearItem(CalendarXItemModel item,
            DateTime? selectedDate,
            DateTime date,
            bool isCurrentMonth)
        {
            item.Content = date.Year;
            switch (Mode)
            {
                case CalendarXMode.Date:
                case CalendarXMode.Year:
                case CalendarXMode.YearMonth:
                    item.IsChecked = selectedDate == null ? false : (((DateTime)selectedDate).Year == date.Year);
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
