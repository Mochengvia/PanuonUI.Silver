using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SearchTextChangedEventArgs : RoutedEventArgs
    {
        public SearchTextChangedEventArgs(string text, RoutedEvent routedEvent) : base(routedEvent)
        {
            Text = text;
        }

        public string Text { get; set; }
    }

    public delegate void SearchTextChangedEventHandler(object sender, SearchTextChangedEventArgs e);
}
