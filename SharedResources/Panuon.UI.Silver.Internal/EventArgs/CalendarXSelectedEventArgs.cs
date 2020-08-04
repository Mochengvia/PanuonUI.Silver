using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal
{
    class CalendarXSelectedEventArgs : EventArgs
    {
        public DateTime Date { get; set; }
    }

    delegate void CalendarXSelectedEventHandler(CalendarXSelectedEventArgs args);
}
