using System;
using System.Collections.Generic;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SelectedDatesChangedRoutedEventArgs : RoutedEventArgs
    {
        public SelectedDatesChangedRoutedEventArgs(RoutedEvent routedEvent, IEnumerable<DateTime> selectedDates) : base(routedEvent)
        {
            SelectedDates = selectedDates;
        }

        public IEnumerable<DateTime> SelectedDates { get; private set; }
    }

    public delegate void SelectedDatesChangedRoutedEventHandler(object sender, SelectedDatesChangedRoutedEventArgs e);
}
