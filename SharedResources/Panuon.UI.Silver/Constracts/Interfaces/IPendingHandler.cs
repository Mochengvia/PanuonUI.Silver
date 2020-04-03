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
        /// Pending box closed.
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        /// User canceled.
        /// </summary>
        event CancelableEventHandler UserCancel;
        #endregion

        #region Methods

        void UpdateMessage(string message);

        void Close();
        #endregion
    }
}
