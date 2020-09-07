using System;
using System.Windows;

namespace Panuon.UI.Silver.Internal.Models
{
    internal class TimeSelectorItemModel : DependencyObject
    {
        #region Properties

        #region Content
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(TimeSelectorItemModel));
        #endregion

        #region DateTime
        public DateTime Time { get; set; }
        #endregion

        #region IsEnabled
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register("IsEnabled", typeof(bool), typeof(TimeSelectorItemModel));
        #endregion

        #endregion

    }
}
