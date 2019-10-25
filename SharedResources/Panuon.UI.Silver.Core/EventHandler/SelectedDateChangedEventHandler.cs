using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SelectedDateChangedEventArgs : RoutedEventArgs
    {
        public SelectedDateChangedEventArgs(DateTime dateTime, RoutedEvent routedEvent) : base(routedEvent)
        {
            Date = dateTime.Date;
        }

        public DateTime Date { get; set; }
    }

    public delegate void SelectedDateChangedEventHandler(object sender, SelectedDateChangedEventArgs e);
}
