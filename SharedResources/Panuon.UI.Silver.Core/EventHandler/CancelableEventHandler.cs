using System;

namespace Panuon.UI.Silver.Core
{
    public class CancelableEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
    }

    public delegate void CancelableEventHandler(object sender, CancelableEventArgs e);
}
