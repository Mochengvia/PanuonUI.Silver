using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class RemovedRoutedEventArgs : RoutedEventArgs
    {
        public RemovedRoutedEventArgs(object item, bool hasRemovedFromSource, RoutedEvent routedEvent) : base(routedEvent)
        {
            Item = item;
            HasRemovedFromSource = hasRemovedFromSource;
        }

        public object Item { get; private set; }

        public bool HasRemovedFromSource { get; private set; }
    }

    public delegate void RemovedRoutedEventHandler(object sender, RemovedRoutedEventArgs e);
}
