using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class RemovingRoutedEventArgs : CancelableRoutedEventArgs
    {
        public RemovingRoutedEventArgs(object item, RoutedEvent routedEvent) : base(routedEvent)
        {
            Item = item;
        }

        public object Item { get; set; }
    }

    public delegate void RemovingRoutedEventHandler(object sender, RemovingRoutedEventArgs e);
}
