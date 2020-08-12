using Panuon.UI.Silver.Components;
using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Internal.Controls
{
    internal sealed class PendingBoxXWindow : Window
    {
        #region Fields
        private Window _owner;

        private Rect _ownerRect;

        private string _message;

        private bool _canCancel;

        private object _cancelButtonContent;

        private bool _isEscEnabled;

        private string _caption;

        private PendingBoxXControl _control;

        private bool _canClose = false;
        #endregion

        #region Events
        internal event CancelEventHandler OnCancel;
        #endregion

        #region Ctor
        internal PendingBoxXWindow()
        {
            ShowInTaskbar = false;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Background = Brushes.Transparent;
            var factory = new FrameworkElementFactory(typeof(PendingBoxXControl));
            factory.SetValue(PendingBoxXControl.NameProperty, "PART_Control");
            Template = new ControlTemplate()
            {
                VisualTree = factory
            };
        }

        internal PendingBoxXWindow(string message, string caption, bool canCancel, PendingBoxXSettings settings)
            : this()
        {
            _message = message;
            if (!string.IsNullOrEmpty(caption))
            {
                Title = caption;
            }
            _caption = caption;

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
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _control = VisualTreeHelper.GetChild(this, 0) as PendingBoxXControl;
                _control.TemplateApplied += Control_TemplateApplied;
            }), DispatcherPriority.Loaded);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_canClose)
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        public new void Close()
        {
            _canClose = true;
            base.Close();
        }

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
                    SizeChanged += delegate
                    {
                        action.Invoke();
                    };
                }

                Topmost = true;
            }
        }
        #endregion

        #region Event Handlers

        private void Control_TemplateApplied(object sender, EventArgs e)
        {
            _control.Message = _message;
            _control.CanCancel = _canCancel;
            _control.Caption = _caption;
            _control.IsEscEnabled = _isEscEnabled;

            if (_control._cancelButton != null)
            {
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
