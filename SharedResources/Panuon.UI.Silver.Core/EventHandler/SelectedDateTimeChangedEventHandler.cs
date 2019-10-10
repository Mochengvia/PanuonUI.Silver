using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SelectedDateTimeChangedEventArgs : RoutedEventArgs
    {
        public SelectedDateTimeChangedEventArgs(DateTime dateTime, RoutedEvent routedEvent) : base(routedEvent)
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; set; }
    }

    public delegate void SelectedDateTimeChangedEventHandler(object sender, SelectedDateTimeChangedEventArgs e);
}
