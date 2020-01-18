using Panuon.UI.Silver.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class ClockItem : Control
    {
        #region Ctor
        #endregion

        #region Properties

        #region Hand
        public HourMinuteSecond Hand
        {
            get { return (HourMinuteSecond)GetValue(HandProperty); }
            set { SetValue(HandProperty, value); }
        }

        public static readonly DependencyProperty HandProperty =
            DependencyProperty.Register("Hand", typeof(HourMinuteSecond), typeof(ClockItem));
        #endregion

        #endregion

        #region Internal Properties

        #endregion

        #region Methods
        #endregion

        #region Function
        #endregion
    }
}
