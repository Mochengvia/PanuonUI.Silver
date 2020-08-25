using System.Collections;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SelectionChangedRoutedEventArgs : RoutedEventArgs
    {
        public SelectionChangedRoutedEventArgs(IEnumerable selectedItems, RoutedEvent routedEvent) : base(routedEvent)
        {
            SelectedItems = selectedItems;
        }

        public IEnumerable SelectedItems { get; private set; }
    }

    public delegate void SelectionChangedRoutedEventHandler(object sender, SelectionChangedRoutedEventArgs e);
}
