
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class CancelRoutedEventArgs : RoutedEventArgs
    {
        public CancelRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent) 
        {

        }

        public bool Cancel { get; set; }
    }

    public delegate void CancelRoutedEventHandler(object sender, CancelRoutedEventArgs e);
}
