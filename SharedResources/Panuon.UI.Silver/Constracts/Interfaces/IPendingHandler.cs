using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver
{
    public interface IPendingHandler
    {
        #region Events
        /// <summary>
        /// Fired on pending box closed.
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        /// Fired on user click cancel button.
        /// </summary>
        event PendingBoxCancellingEventHandler Cancelling;
        #endregion

        #region Methods

        void UpdateMessage(string message);

        void Close();
        #endregion
    }
}
