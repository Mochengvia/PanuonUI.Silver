using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class ClickEventArgs : RoutedEventArgs
    {
        public ClickEventArgs(Point position, RoutedEvent routedEvent) : base(routedEvent)
        {
            Position = position;
        }

        public Point Position { get; set; }
    }

    public delegate void ClickEventHandler(object sender, ClickEventArgs e);
}
