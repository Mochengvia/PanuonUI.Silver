using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Core
{
    public class SelectedBrushChangedEventArgs : RoutedEventArgs
    {
        public SelectedBrushChangedEventArgs(Brush selectedBrush, RoutedEvent routedEvent) : base(routedEvent)
        {
            SelectedBrush = selectedBrush;
        }

        public Brush SelectedBrush { get; set; }
    }

    public delegate void SelectedBrushChangedEventHandler(object sender, SelectedBrushChangedEventArgs e);
}
