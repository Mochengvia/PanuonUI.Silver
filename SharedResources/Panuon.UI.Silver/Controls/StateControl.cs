using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Items))]
    public class StateControl : Control
    {
        public StateControl()
        {
            Items = new ObservableCollection<StateItem>();
        }

        #region State
        public object State
        {
            get { return (object)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(object), typeof(StateControl));
        #endregion

        #region States

        public ObservableCollection<StateItem> Items
        {
            get { return (ObservableCollection<StateItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<StateItem>), typeof(StateControl));

        #endregion
    }
}
