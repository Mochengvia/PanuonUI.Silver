using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Forms;

namespace Panuon.UI.Silver.Internal.Controls
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    internal partial class PendingWindow : Window
    {
        #region Fields
        private Window _owner;

        private Rect _ownerRect;

        private bool _canClose;
        #endregion

        #region Ctor
        public PendingWindow(string message, string caption, bool canCancel, object cancelButtonContent)
        {
            InitializeComponent();
            PbcControl.Message = message;
            PbcControl.Caption = caption;
            PbcControl.CanCancel = canCancel;
            PbcControl.CancelButtonContent = cancelButtonContent;

        }


        public PendingWindow(string message, string caption, bool canCancel, Window owner, object cancelButtonContent)
            : this(message, caption, canCancel, cancelButtonContent)
        {
            _owner = owner;
            SetOwner();
        }

        public PendingWindow(string message, string caption, bool canCancel, Rect ownerRect, object cancelButtonContent)
            : this(message, caption, canCancel, cancelButtonContent)
        {
            _ownerRect = ownerRect;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            SetOwner();
            base.OnSourceInitialized(e);
        }

        #endregion

        #region Events
        public event PendingBoxCancellingEventHandler UserCancelling;
        #endregion

        #region Event Handlers

        private void PendingControlControl_PendingBoxCancelling(object sender, EventArgs e)
        {
            var args = new PendingBoxCancellingEventArgs();
            UserCancelling?.Invoke(null, args);
            if (args.Cancel)
            {
                return;
            }
            Close();
        }

        private void PendingWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_canClose)
            {
                e.Cancel = true;
            }
        }

        private void PendingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PbcControl.IsLoading = true;
        }

        #endregion

        #region Methods
        public new void Close()
        {
            _canClose = true;
            base.Close();
        }
        internal void UpdateMessage(string message)
        {
            if (Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    PbcControl.Message = message;
                }));
            }
        }
        #endregion

        #region Function
    
        private void SetOwner()
        {
            if (_owner != null)
            {
                Owner = _owner;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else if (_ownerRect.Width != 0 && _ownerRect.Height != 0)
            {
                Left = _ownerRect.X + (_ownerRect.Width - ActualWidth) / 2;
                Top = _ownerRect.Y + (_ownerRect.Height - ActualHeight) / 2;
                Topmost = true;
            }
        }
        #endregion
    }
}
