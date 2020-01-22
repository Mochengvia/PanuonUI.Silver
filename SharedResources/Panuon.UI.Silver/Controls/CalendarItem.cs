using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class CalendarItem : RadioButton
    {
        #region Ctor
        static CalendarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarItem), new FrameworkPropertyMetadata(typeof(CalendarItem)));
        }
        #endregion
    }
}
