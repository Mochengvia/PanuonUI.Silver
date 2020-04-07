using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver
{
    public class PendingBoxConfigurations
    {
        #region Ctor
        static PendingBoxConfigurations()
        {

        }
        #endregion

        #region Properties
        public bool InvokeOnNewThread { get; set; }

        public bool InteractOwnerMask { get; set; } = true;

        public object CancelButtonContent { get; set; } = "Cancel";
        #endregion
    }
}
