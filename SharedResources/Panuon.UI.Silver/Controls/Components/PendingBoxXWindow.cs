using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Components
{
    public sealed class PendingBoxXWindow : WindowX
    {
        #region Fields
        private Window _owner;

        private Rect _ownerRect;

        private string _message;

        private bool _canCancel;

        private object _cancelButtonContent;

        private bool _isEscEnabled;

        private PendingBoxXControl _control;
        #endregion

        #region Events
        internal event CancelEventHandler OnCancel;
        #endregion

        #region Ctor
        static PendingBoxXWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PendingBoxXWindow), new FrameworkPropertyMetadata(typeof(PendingBoxXWindow)));
        }

        internal PendingBoxXWindow(string message, string caption, bool canCancel, PendingBoxXSettings settings)
        {
            _message = message;
            if (!string.IsNullOrEmpty(caption))
            {
                Title = caption;
            }

            _canCancel = canCancel;
            _cancelButtonContent = settings.CancelButtonContent;
            _isEscEnabled = settings.IsEscEnabled;
        }

        public PendingBoxXWindow(string message, string caption, bool canCancel, Window owner, PendingBoxXSettings settings)
            : this(message, caption, canCancel, settings)
        {
            _owner = owner;
            SetOwner();
        }

        public PendingBoxXWindow(string message, string caption, bool canCancel, Rect ownerRect, PendingBoxXSettings settings)
            : this(message, caption, canCancel, settings)
        {
            _ownerRect = ownerRect;
            SetOwner();
        }
        #endregion

        #region Override
        protected override void OnContentTemplateChanged(DataTemplate oldContentTemplate, DataTemplate newContentTemplate)
        {
            base.OnContentTemplateChanged(oldContentTemplate, newContentTemplate);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var adorner = UIElementUtils.GetVisualChild<AdornerDecorator>(this);
                var presenter = UIElementUtils.GetVisualChild<ContentPresenter>(adorner);
                _control = newContentTemplate?.FindName("PART_Control", presenter) as PendingBoxXControl;
                if (_control != null)
                {
                    _control.OnTemplatedChanged -= Control_OnTemplatedChanged;
                    _control.OnTemplatedChanged += Control_OnTemplatedChanged;
                }
            }), DispatcherPriority.DataBind);
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        public void UpdateMessage(string message)
        {
            if (_control != null)
            {
                if (Dispatcher.CheckAccess())
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        _control.Message = message;
                    }));
                }
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
                var action = new Action(() =>
                {
                    Left = _ownerRect.X + (_ownerRect.Width - ActualWidth) / 2;
                    Top = _ownerRect.Y + (_ownerRect.Height - ActualHeight) / 2;
                });

                if (IsInitialized)
                {
                    action.Invoke();
                }
                else
                {
                    Initialized += delegate
                    {
                        action.Invoke();
                    };
                }

                Topmost = true;
            }
        }
        #endregion

        #region Event Handlers

        private void Control_OnTemplatedChanged(object sender, EventArgs e)
        {
            _control.Message = _message;

            if (_control._cancelButton != null)
            {
                _control._cancelButton.Visibility = _canCancel ? Visibility.Visible : Visibility.Hidden;
                _control._cancelButton.IsEnabled = _canCancel;
                _control._cancelButton.IsCancel = _isEscEnabled;

                _control._cancelButton.Content = _cancelButtonContent;
                _control._cancelButton.Click -= CancelButton_Click;
                _control._cancelButton.Click += CancelButton_Click;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var args = new CancelEventArgs();
            OnCancel?.Invoke(this, args);
            if (args.Cancel)
            {
                return;
            }
            Close();
        }

        #endregion
    }
}
