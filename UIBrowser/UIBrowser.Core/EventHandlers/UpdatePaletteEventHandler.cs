using System;
using System.Collections.Generic;

namespace UIBrowser.Core
{
    public class UpdatePaletteEventArgs : EventArgs
    {
        public UpdatePaletteEventArgs(IDictionary<PaletteComponent, object> values)
        {
            Values = values;
        }

        public IDictionary<PaletteComponent, object> Values { get; set; }
    }

    public delegate void UpdatePaletteEventHandler(object sender, UpdatePaletteEventArgs e);
}
