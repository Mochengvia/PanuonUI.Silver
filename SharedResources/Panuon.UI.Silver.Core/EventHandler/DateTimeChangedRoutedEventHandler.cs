using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class DateTimeChangedRoutedEventArgs : RoutedEventArgs
    {
        public DateTimeChangedRoutedEventArgs(DateTime dateTime, RoutedEvent routedEvent) : base(routedEvent)
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; private set; }

    }

    public delegate void DateTimeChangedRoutedEventHandler(object sender, DateTimeChangedRoutedEventArgs e);
}
