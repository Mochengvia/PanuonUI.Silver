using Panuon.UI.Silver.Internal.Controls;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Internal.Implements
{
    class PendingHanlderImpl : IPendingHandler
    {
        #region Identifier
        private PendingBoxXWindow _window;
        #endregion

        #region Ctor
        public PendingHanlderImpl()
        {
        }
        #endregion

        #region Events
        public event EventHandler Closed;

        public event CancelEventHandler Cancelling;
        #endregion

        #region Methods
        
        public void Close()
        {
            if (_window.Dispatcher.CheckAccess())
            {
                _window.Close();
            }
            else
            {
                _window.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    _window.Close();
                }));
            }
        }

        public void UpdateMessage(string message)
        {
            if (_window.Dispatcher.CheckAccess())
            {
                _window.UpdateMessage(message);
            }
            else
            {
                _window.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    _window.UpdateMessage(message);
                }));
            }
        }

        internal void SetWindow(PendingBoxXWindow window)
        {
            _window = window;
        }

        internal void RaiseClosedEvent()
        {
            Closed?.Invoke(this, null);
        }

        internal void RaiseCancellingEvent(object sender, CancelEventArgs e)
        {
            Cancelling?.Invoke(this, e);
        }
        #endregion
    }
}
