using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class CurrentIndexChangedEventArgs : RoutedEventArgs
    {
        public CurrentIndexChangedEventArgs(int currentIndex, RoutedEvent routedEvent) : base(routedEvent)
        {
            CurrentIndex = currentIndex;
        }

        public int CurrentIndex { get; set; }
    }

    public delegate void CurrentIndexChangedEventHandler(object sender, CurrentIndexChangedEventArgs e);
}
