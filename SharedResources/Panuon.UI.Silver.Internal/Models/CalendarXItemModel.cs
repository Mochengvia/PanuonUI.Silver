using Panuon.UI.Silver.Core;
using System;
using System.Windows;

namespace Panuon.UI.Silver.Internal.Models
{
    internal class CalendarXItemModel : DependencyObject
    {
        #region Properties

        #region IsChecked
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(CalendarXItemModel));
        #endregion

        #region Content
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(CalendarXItemModel));
        #endregion

        #region DateTime
        public DateTime Date { get; set; }
        #endregion

        #region IsToday
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }

        public static readonly DependencyProperty IsTodayProperty =
            DependencyProperty.Register("IsToday", typeof(bool), typeof(CalendarXItemModel));
        #endregion

        #region IsEnabled
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register("IsEnabled", typeof(bool), typeof(CalendarXItemModel));
        #endregion

        #region IsDownplay
        public bool IsDownplay
        {
            get { return (bool)GetValue(IsDownplayProperty); }
            set { SetValue(IsDownplayProperty, value); }
        }

        public static readonly DependencyProperty IsDownplayProperty =
            DependencyProperty.Register("IsDownplay", typeof(bool), typeof(CalendarXItemModel));
        #endregion

        #region IsInRange
        public bool IsInRange
        {
            get { return (bool)GetValue(IsInRangeProperty); }
            set { SetValue(IsInRangeProperty, value); }
        }

        public static readonly DependencyProperty IsInRangeProperty =
            DependencyProperty.Register("IsInRange", typeof(bool), typeof(CalendarXItemModel));
        #endregion

        #endregion

    }
}
