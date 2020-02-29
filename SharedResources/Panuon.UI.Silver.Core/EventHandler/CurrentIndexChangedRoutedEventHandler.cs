using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
       public class CurrentIndexChangedRoutedEventArgs : RoutedEventArgs
    {
        public CurrentIndexChangedRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent) 
        {

        }

        public int CurrentIndex { get; set; }
    }

    public delegate void CurrentIndexChangedRoutedEventHandler(object sender, CurrentIndexChangedRoutedEventArgs e);

}
