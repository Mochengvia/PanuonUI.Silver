using System;

namespace Panuon.UI.Silver.Core
{
    public interface IPendingHandler
    {
        /// <summary>
        /// Pending box closed.
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        /// User canceled.
        /// </summary>
        event EventHandler Cancel;

        /// <summary>
        /// Close pending box.
        /// </summary>
        void Close();

        /// <summary>
        /// Update message of pending box.
        /// </summary>
        void UpdateMessage(string message);
    }

    internal class PendingHandler : IPendingHandler
    {
        #region Identifier
        private Action _closeAction;
        private Action<string> _updateMessageAction;
        #endregion

        #region Constructor
        public PendingHandler(Action closeAction, Action<string> updateMessageAction)
        {
            _closeAction = closeAction;
            _updateMessageAction = updateMessageAction;
        }
        #endregion

        #region Event
        public event EventHandler Closed;
        public event EventHandler Cancel;

        public void Close()
        {
            _closeAction();
        }
        #endregion

        #region Calling Methods
        public void RaiseClosedEvent(object sender, EventArgs e)
        {
            Closed?.Invoke(sender, e);
        }

        public void RaiseCanceledEvent(object sender, EventArgs e)
        {
            Cancel?.Invoke(sender, e);
        }

        public void UpdateMessage(string message)
        {
            _updateMessageAction(message);
        }
        #endregion

    }

}
