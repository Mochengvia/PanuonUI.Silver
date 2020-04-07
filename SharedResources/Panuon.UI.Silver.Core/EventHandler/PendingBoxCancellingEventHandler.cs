using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Core
{
    public class PendingBoxCancellingEventArgs : CancelableEventArgs
    {
    }

    public delegate void PendingBoxCancellingEventHandler(IPendingHandler sender, PendingBoxCancellingEventArgs e);
}
