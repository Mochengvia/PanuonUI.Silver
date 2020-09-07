using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class RollerItem : ContentControl
    {
        #region Fields
        private bool _isInternalSet;
        #endregion

        #region Events
        public event RoutedEventHandler Selected
        {
            add { AddHandler(SelectedEvent, value); }
            remove { RemoveHandler(SelectedEvent, value); }
        }

        public static readonly RoutedEvent SelectedEvent = Roller.SelectedEvent.AddOwner(typeof(RollerItem));


        public event RoutedEventHandler Unselected
        {
            add { AddHandler(UnselectedEvent, value); }
            remove { RemoveHandler(UnselectedEvent, value); }
        }

        public static readonly RoutedEvent UnselectedEvent = Roller.UnselectedEvent.AddOwner(typeof(RollerItem));
        #endregion

        #region Ctor
        static RollerItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RollerItem), new FrameworkPropertyMetadata(typeof(RollerItem)));
        }
        #endregion

        #region Properties

        #region IsSelected
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(RollerItem), new PropertyMetadata(OnIsSelectedChanged));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = d as RollerItem;

            if (item._isInternalSet)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                item.RaiseEvent(new RoutedEventArgs(Roller.SelectedEvent, item));
            }
            else
            {
                item.RaiseEvent(new RoutedEventArgs(Roller.UnselectedEvent, item));
            }
        }
        #endregion

        #region Functions
        internal void InternalSetIsSelected(bool isSelected)
        {
            _isInternalSet = true;
            IsSelected = isSelected;
            _isInternalSet = false;
        }
        #endregion
    }
}
