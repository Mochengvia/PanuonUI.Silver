using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    class CalendarXWeekPresenter : ItemsControl
    {
        #region Ctor

        static CalendarXWeekPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXWeekPresenter), new FrameworkPropertyMetadata(typeof(CalendarXWeekPresenter)));
        }
        #endregion

        #region Overrides
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TextBlock;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TextBlock();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var textBlock = element as TextBlock;
            textBlock.Text = item.ToString();
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.FontWeight = FontWeights.Bold;
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
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(CalendarXWeekPresenter), new PropertyMetadata(OnFirstDayOfWeekChanged));
        #endregion

        #endregion

        #region Internal Properties
        internal ObservableCollection<string> Weeks
        {
            get { return (ObservableCollection<string>)GetValue(WeeksProperty); }
            set { SetValue(WeeksProperty, value); }
        }

        internal static readonly DependencyProperty WeeksProperty =
            DependencyProperty.Register("Weeks", typeof(ObservableCollection<string>), typeof(CalendarXWeekPresenter));
        #endregion

        #region Event Handlers
        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var presenter = d as CalendarXWeekPresenter;
            presenter.UpdateWeeks();
        }

        #endregion

        #region Methods
        public void UpdateWeeks()
        {
            var daysOfWeek = FirstDayOfWeek;
            var weeks = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                weeks.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(daysOfWeek));
                daysOfWeek = DateTimeUtils.GetNextDayOfWeek(daysOfWeek);
            }

            Weeks = new ObservableCollection<string>(weeks);
        }

        #endregion
    }
}
