using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class IndexChangedEventArgs : RoutedEventArgs
    {
        public IndexChangedEventArgs(int currentIndex, RoutedEvent routedEvent) : base(routedEvent)
        {
            CurrentIndex = currentIndex;
        }

        public int CurrentIndex { get; set; }
    }

    public delegate void IndexChangedEventHandler(object sender, IndexChangedEventArgs e);
}
