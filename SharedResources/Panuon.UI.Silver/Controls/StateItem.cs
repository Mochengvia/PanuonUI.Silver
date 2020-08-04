using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class StateItem : ContentControl
    {
        #region Properties
        public object State
        {
            get { return (object)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(object), typeof(StateItem));
        #endregion
    }
}
