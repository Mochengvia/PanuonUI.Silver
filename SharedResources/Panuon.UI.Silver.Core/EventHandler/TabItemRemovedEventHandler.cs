using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Core
{
    public class TabItemRemovedEventArgs : RoutedEventArgs
    {
        public TabItemRemovedEventArgs(TabItem removedItem, bool removedFromSource, RoutedEvent routedEvent) : base(routedEvent)
        {
            RemovedItem = removedItem;
            RemovedFromSource = removedFromSource;
        }

        public TabItem RemovedItem { get; set; }

        public bool RemovedFromSource { get; set; }
    }

    public delegate void TabItemRemovedEventHandler(object sender, TabItemRemovedEventArgs e);
}
