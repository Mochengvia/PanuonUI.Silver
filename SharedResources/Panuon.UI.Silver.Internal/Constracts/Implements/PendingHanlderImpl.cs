using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Internal.Constracts.Implements
{
    internal class PendingHanlderImpl : IPendingHandler
    {
        #region Identifier
        private PendingWindow _pendingWindow;
        #endregion

        #region Ctor
        public PendingHanlderImpl(PendingWindow pendingWindow)
        {
            _pendingWindow = pendingWindow;
        }
        #endregion

        #region Events
        public event EventHandler Closed;

        public event CancelableEventHandler UserCancel;
        #endregion

        #region Methods
        public void Close()
        {
            if (_pendingWindow.Dispatcher.CheckAccess())
            {
                _pendingWindow.Close();
            }
            else
            {
                _pendingWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(_pendingWindow.Close));
            }
        }

        public void UpdateMessage(string message)
        {
            _pendingWindow.UpdateMessage(message);
        }

        public void RaiseClosedEvent(object sender, EventArgs e)
        {
            Closed?.Invoke(sender, e);
        }

        public void RaiseCanceledEvent(object sender, CancelableEventArgs e)
        {
            UserCancel?.Invoke(sender, e);
        }

        #endregion
    }
}
