
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Core
{
    public class SelectionChangingRoutedEventArgs : RoutedEventArgs
    {
        public SelectionChangingRoutedEventArgs(RoutedEvent routedEvent, IList removedItems, IList addedItems, int selectedIndex)
            : base(routedEvent)
        {
            RemovedItems = removedItems;
            AddedItems = addedItems;
            SelectedIndex = selectedIndex;
        }

        public IList RemovedItems { get; }

        public IList AddedItems { get; }

        public int SelectedIndex { get; set; }

        public bool Cancel { get; set; }
    }

    public delegate void SelectionChangingRoutedEventHandler(object sender, SelectionChangingRoutedEventArgs e);
}
