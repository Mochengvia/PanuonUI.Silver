using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Panuon.UI.Silver.Core;

namespace Panuon.UI.Silver
{
    public class DateTimePicker : Control
    {
        #region Ctor
        #endregion

        #region Properties

        #region DropDownPlacement
        public DropDownPlacement DropDownPlacement
        {
            get { return (DropDownPlacement)GetValue(DropDownPlacementProperty); }
            set { SetValue(DropDownPlacementProperty, value); }
        }

        public static readonly DependencyProperty DropDownPlacementProperty =
            DependencyProperty.Register("DropDownPlacement", typeof(DropDownPlacement), typeof(DateTimePicker));
        #endregion

        #region TextTemplate
        public DataTemplate TextTemplate
        {
            get { return (DataTemplate)GetValue(TextTemplateProperty); }
            set { SetValue(TextTemplateProperty, value); }
        }

        public static readonly DependencyProperty TextTemplateProperty =
            DependencyProperty.Register("TextTemplate", typeof(DataTemplate), typeof(DateTimePicker));
        #endregion

        #region TextTemplateSelector
        public DataTemplateSelector TextTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(TextTemplateSelectorProperty); }
            set { SetValue(TextTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty TextTemplateSelectorProperty =
            DependencyProperty.Register("TextTemplateSelector", typeof(DataTemplateSelector), typeof(DateTimePicker));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DateTimePicker));
        #endregion

        #region SelectedDateTime
        public DateTime SelectedDateTime
        {
            get { return (DateTime)GetValue(SelectedDateTimeProperty); }
            set { SetValue(SelectedDateTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateTimeProperty =
            DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(DateTimePicker), new PropertyMetadata(default(DateTime), OnSelectedDateTimeChanged, OnSelectedDateTimeCoerceValue));

        #endregion

        #region MaxDateTime
        public DateTime? MaxDateTime
        {
            get { return (DateTime?)GetValue(MaxDateTimeProperty); }
            set { SetValue(MaxDateTimeProperty, value); }
        }

        public static readonly DependencyProperty MaxDateTimeProperty =
            DependencyProperty.Register("MaxDateTime", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(null, OnMaxDateTimeChanged, OnMaxDateTimeCoerceValue));

        #endregion

        #region MinDateTime
        public DateTime? MinDateTime
        {
            get { return (DateTime?)GetValue(MinDateTimeProperty); }
            set { SetValue(MinDateTimeProperty, value); }
        }

        public static readonly DependencyProperty MinDateTimeProperty =
            DependencyProperty.Register("MinDateTime", typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(null, OnMinDateTimeChanged, OnMinDateTimeCoerceValue));

        #endregion

        #region IsOpen
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(DateTimePicker));
        #endregion

        #region DropDownHeight
        public double DropDownHeight
        {
            get { return (double)GetValue(DropDownHeightProperty); }
            set { SetValue(DropDownHeightProperty, value); }
        }

        public static readonly DependencyProperty DropDownHeightProperty =
            DependencyProperty.Register("DropDownHeight", typeof(double), typeof(DateTimePicker));
        #endregion

        #region DropDownWidth
        public double DropDownWidth
        {
            get { return (double)GetValue(DropDownWidthProperty); }
            set { SetValue(DropDownWidthProperty, value); }
        }

        public static readonly DependencyProperty DropDownWidthProperty =
            DependencyProperty.Register("DropDownWidth", typeof(double), typeof(DateTimePicker));
        #endregion

        #region DropDownCornerRadius
        public CornerRadius DropDownCornerRadius
        {
            get { return (CornerRadius)GetValue(DropDownCornerRadiusProperty); }
            set { SetValue(DropDownCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.Register("DropDownCornerRadius", typeof(CornerRadius), typeof(DateTimePicker));
        #endregion

        #region CalendarStyle
        public Style CalendarStyle
        {
            get { return (Style)GetValue(CalendarStyleProperty); }
            set { SetValue(CalendarStyleProperty, value); }
        }

        public static readonly DependencyProperty CalendarStyleProperty =
            DependencyProperty.Register("CalendarStyle", typeof(Style), typeof(DateTimePicker));
        #endregion

        #region ClockStyle
        public Style ClockStyle
        {
            get { return (Style)GetValue(ClockStyleProperty); }
            set { SetValue(ClockStyleProperty, value); }
        }

        public static readonly DependencyProperty ClockStyleProperty =
            DependencyProperty.Register("ClockStyle", typeof(Style), typeof(DateTimePicker));
        #endregion

        #endregion

        #region Internal Properties

        #region SelectedDate
        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime), typeof(DateTimePicker), new PropertyMetadata(OnSelectedDateChanged));

        #endregion

        #region SelectedTime
        public DateTime SelectedTime
        {
            get { return (DateTime)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(DateTime), typeof(DateTimePicker), new PropertyMetadata(OnSelectedTimeChanged));

        #endregion

        #endregion

        #region Event Handler
        private static void OnSelectedDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as DateTimePicker;
            picker.SelectedDate = picker.SelectedDateTime.Date;
            picker.SelectedTime = picker.SelectedDateTime.Time();
        }

        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as DateTimePicker;
            var selectedDate = (DateTime)e.NewValue;
            var selectedDateTime = (DateTime)picker.SelectedDateTime;
            if(selectedDate.Year != selectedDateTime.Year || selectedDate.Month != selectedDateTime.Month || selectedDate.Day != selectedDateTime.Day)
            {
                picker.SelectedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedDateTime.Hour, selectedDateTime.Minute, selectedDateTime.Second);
            }
        }
      
        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as DateTimePicker;
            var selectedTime = (DateTime)e.NewValue;
            var selectedDateTime = (DateTime)picker.SelectedDateTime;
            if (selectedTime.Hour != selectedDateTime.Hour || selectedTime.Minute != selectedDateTime.Minute || selectedTime.Second != selectedDateTime.Second)
            {
                 picker.SelectedDateTime = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second);
            }
        }

        private static object OnMaxDateTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var picker = d as DateTimePicker;
            var maxDateTime = (DateTime)baseValue;
            if(picker.MinDateTime != null)
            {
                var minDateTime = (DateTime)picker.MinDateTime;
                if(maxDateTime < minDateTime)
                {
                    return minDateTime;
                }
            }
            return maxDateTime;
        }

        private static void OnMaxDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SelectedDateTimeProperty);
        }

        private static object OnMinDateTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var picker = d as DateTimePicker;
            var minDateTime = (DateTime)baseValue;
            if (picker.MinDateTime != null)
            {
                var maxDateTime = (DateTime)picker.MinDateTime;
                if (minDateTime > maxDateTime)
                {
                    return maxDateTime;
                }
            }
            return minDateTime;
        }

        private static void OnMinDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(SelectedDateTimeProperty);
        }

        private static object OnSelectedDateTimeCoerceValue(DependencyObject d, object baseValue)
        {
            var picker = d as DateTimePicker;
            var selectedDateTime = (DateTime)baseValue;
            if(picker.MinDateTime != null)
            {
                var minDateTime = (DateTime)picker.MinDateTime;
                if(selectedDateTime < minDateTime)
                {
                    return minDateTime;
                }
            }
            if(picker.MaxDateTime != null)
            {
                var maxDateTime = (DateTime)picker.MaxDateTime;
                if(selectedDateTime > maxDateTime)
                {
                    return maxDateTime;
                }
            }
            return selectedDateTime;
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        #endregion

    }
}
