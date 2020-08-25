using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SelectedDateChangedRoutedEventArgs : RoutedEventArgs
    {
        public SelectedDateChangedRoutedEventArgs(DateTime? selectedDate, RoutedEvent routedEvent) : base(routedEvent)
        {
            SelectedDate = selectedDate;
        }

        public DateTime? SelectedDate { get; private set; }
    }

    public delegate void SelectedDateChangedRoutedEventHandler(object sender, SelectedDateChangedRoutedEventArgs e);
}
