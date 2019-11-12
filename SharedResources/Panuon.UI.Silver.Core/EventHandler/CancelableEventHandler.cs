using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Core
{
    public class CancelableEventArgs : EventArgs
    {
        public CancelableEventArgs() : base()
        {
        }

        public bool Cancel { get; set; }
    }

    public delegate void CancelableEventHandler(object sender, CancelableEventArgs e);
}
