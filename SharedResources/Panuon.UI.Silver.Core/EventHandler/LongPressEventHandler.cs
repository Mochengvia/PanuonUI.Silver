using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class LongPressEventArgs : RoutedEventArgs
    {
        public LongPressEventArgs(Point position, TimeSpan duration, RoutedEvent routedEvent) : base(routedEvent)
        {
            Position = position;
            Duration = duration;
        }

        public Point Position { get; set; }

        public TimeSpan Duration { get; set; }
    }

    public delegate void LongPressEventHandler(object sender, LongPressEventArgs e);
}
