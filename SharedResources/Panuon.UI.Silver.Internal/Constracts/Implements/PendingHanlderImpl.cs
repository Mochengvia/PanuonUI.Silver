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
        public PendingHanlderImpl()
        {
        }
        #endregion

        #region Events
        public event EventHandler Closed;

        public event PendingBoxCancellingEventHandler Cancelling;
        #endregion

        #region Methods
        public void SetWindow(PendingWindow pendingWindow)
        {
            _pendingWindow = pendingWindow;
        }

        public void Close()
        {
            if (_pendingWindow.Dispatcher.CheckAccess())
            {
                _pendingWindow.Close();
            }
            else
            {
                _pendingWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    _pendingWindow.Close();
                }));
            }
        }

        public void UpdateMessage(string message)
        {
            if (_pendingWindow.Dispatcher.CheckAccess())
            {
                _pendingWindow.UpdateMessage(message);
            }
            else
            {
                _pendingWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    _pendingWindow.UpdateMessage(message);
                }));
            }
        }

        public void RaiseClosedEvent()
        {
            Closed?.Invoke(this, null);

        }

        public void RaiseCancellingEvent(object sender, PendingBoxCancellingEventArgs e)
        {
            Cancelling?.Invoke(this, e);
        }
        #endregion
    }
}
