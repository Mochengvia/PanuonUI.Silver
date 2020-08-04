using System;
using System.ComponentModel;

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
        event CancelEventHandler Cancelling;
        #endregion

        #region Methods
        void UpdateMessage(string message);

        void Close();
        #endregion
    }
}
