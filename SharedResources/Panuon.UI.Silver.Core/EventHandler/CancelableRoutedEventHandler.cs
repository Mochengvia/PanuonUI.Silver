using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class CancelableRoutedEventArgs : RoutedEventArgs
    {
        public CancelableRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent) 
        {

        }

        public bool Cancel { get; set; }
    }

    public delegate void CancelableRoutedEventHandler(object sender, CancelableRoutedEventArgs e);
}
