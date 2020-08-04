using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class CalendarXItem : CheckBox
    {
        #region Fields
        #endregion

        #region Ctor
        static CalendarXItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarXItem), new FrameworkPropertyMetadata(typeof(CalendarXItem)));
        }

        public CalendarXItem()
        {
        }
        #endregion

        #region Properties

        #region CheckedBackground
        public Brush CheckedBackground
        {
            get { return (Brush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(CalendarXItem));

        #endregion

        #region CheckedForeground
        public Brush CheckedForeground
        {
            get { return (Brush)GetValue(CheckedForegroundProperty); }
            set { SetValue(CheckedForegroundProperty, value); }
        }

        public static readonly DependencyProperty CheckedForegroundProperty =
            DependencyProperty.Register("CheckedForeground", typeof(Brush), typeof(CalendarXItem));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CalendarXItem));
        #endregion

        #region IsToday
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }

        public static readonly DependencyProperty IsTodayProperty =
            DependencyProperty.Register("IsToday", typeof(bool), typeof(CalendarXItem));
        #endregion

        #region IsWeakenDisplay
        public bool IsWeakenDisplay
        {
            get { return (bool)GetValue(IsWeakenDisplayProperty); }
            set { SetValue(IsWeakenDisplayProperty, value); }
        }

        public static readonly DependencyProperty IsWeakenDisplayProperty =
            DependencyProperty.Register("IsWeakenDisplay", typeof(bool), typeof(CalendarXItem));
        #endregion

        #region Category
        public CalendarXItemCategory Category
        {
            get { return (CalendarXItemCategory)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("Category", typeof(CalendarXItemCategory), typeof(CalendarXItem));
        #endregion

        #region Value
        public DateTime Value
        {
            get { return (DateTime)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(DateTime), typeof(CalendarXItem));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        #endregion
    }
}
