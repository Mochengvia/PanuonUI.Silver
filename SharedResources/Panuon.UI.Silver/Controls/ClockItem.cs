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
        static ClockItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClockItem), new FrameworkPropertyMetadata(typeof(ClockItem)));
        }

        public ClockItem()
        {
            MouseLeftButtonDown += ClockItem_MouseLeftButtonDown;
        }

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

        #region Hooked
        internal bool Hooked
        {
            get { return (bool)GetValue(HookedProperty); }
            set { SetValue(HookedProperty, value); }
        }

        internal static readonly DependencyProperty HookedProperty =
            DependencyProperty.Register("Hooked", typeof(bool), typeof(ClockItem));
        #endregion

        #endregion

        #region Event Handler
        private void ClockItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var clockItem = sender as ClockItem;
            clockItem.Hooked = !clockItem.Hooked;
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        #endregion
    }
}
