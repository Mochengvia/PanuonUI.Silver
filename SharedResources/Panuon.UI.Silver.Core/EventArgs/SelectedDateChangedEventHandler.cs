using System;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SelectedDateChangedEventArgs : EventArgs
    {
        public SelectedDateChangedEventArgs(DateTime? selectedDate)
        {
            SelectedDate = selectedDate;
        }

        public DateTime? SelectedDate { get; private set; }
    }

    public delegate void SelectedDateChangedEventHandler(object sender, SelectedDateChangedEventArgs e);
}
