using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Panuon.UI.Silver
{
    public class CalendarXItem : ToggleButton
    {
        #region Fields
        #endregion

        #region Ctor
        static CalendarXItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXItem), new FrameworkPropertyMetadata(typeof(CalendarXItem)));
        }
        #endregion

        #region Properties

        #region IsToday
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }

        public static readonly DependencyProperty IsTodayProperty =
            DependencyProperty.Register("IsToday", typeof(bool), typeof(CalendarXItem));
        #endregion

        #region IsDownplay
        public bool IsDownplay
        {
            get { return (bool)GetValue(IsDownplayProperty); }
            set { SetValue(IsDownplayProperty, value); }
        }

        public static readonly DependencyProperty IsDownplayProperty =
            DependencyProperty.Register("IsDownplay", typeof(bool), typeof(CalendarXItem));
        #endregion

        #region IsInRange
        public bool IsInRange
        {
            get { return (bool)GetValue(IsInRangeProperty); }
            set { SetValue(IsInRangeProperty, value); }
        }

        public static readonly DependencyProperty IsInRangeProperty =
            DependencyProperty.Register("IsInRange", typeof(bool), typeof(CalendarXItem));
        #endregion

        #endregion
    }
}
