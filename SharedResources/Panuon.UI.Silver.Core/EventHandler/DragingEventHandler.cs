using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class DragingEventArgs : RoutedEventArgs
    {
        public DragingEventArgs(Point startPosition, Point endPosition, RoutedEvent routedEvent) : base(routedEvent)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
        public Point StartPosition { get; set; }

        public Point EndPosition { get; set; }

        public Size Size => new Size()
        {
            Height = Math.Abs(StartPosition.Y - EndPosition.Y),
            Width = Math.Abs(StartPosition.X - EndPosition.X),
        };
    }

    public delegate void DragingEventHandler(object sender, DragingEventArgs e);
}
