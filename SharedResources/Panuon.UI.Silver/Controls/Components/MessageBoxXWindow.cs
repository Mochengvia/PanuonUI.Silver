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
    public sealed class MessageBoxXWindow : WindowX
    {
        #region Fields
        private object _yesButtonContent;

        private object _noButtonContent;

        private object _okButtonContent;

        private object _cancelButtonContent;

        private MessageBoxButton _messageBoxButton;

        private DefaultButton _defaultButton;

        private MessageBoxXControl _control;

        private bool _isEscEnabled;

        private bool _isResultSet;

        private string _message;

        private MessageBoxIcon _icon;

        private MessageBoxButtonArrangement _buttonArrangement;
        #endregion

        #region Ctor
        static MessageBoxXWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBoxXWindow), new FrameworkPropertyMetadata(typeof(MessageBoxXWindow)));
        }

        internal MessageBoxXWindow(string message, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, Window owner, MessageBoxXSettings settings)
        {
            _message = message;
            if (!string.IsNullOrEmpty(caption))
            {
                Title = caption;
            }

            _yesButtonContent = settings.YesButton;
            _noButtonContent = settings.NoButton;
            _okButtonContent = settings.OKButton;
            _cancelButtonContent = settings.CancelButton;

            _messageBoxButton = button;
            CanClose = button != MessageBoxButton.YesNo;

            _defaultButton = defaultButton;
            _isEscEnabled = settings.IsEscEnabled;

            _icon = icon;
            _buttonArrangement = settings.ButtonArrangement;

            if (owner != null)
            {
                Owner = owner;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
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
                _control = newContentTemplate?.FindName("PART_Control", presenter) as MessageBoxXControl;
                if (_control != null)
                {
                    _control.OnTemplatedChanged -= Control_OnTemplatedChanged;
                    _control.OnTemplatedChanged += Control_OnTemplatedChanged;
                }
            }), DispatcherPriority.Loaded);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_isResultSet)
            {
                if (_messageBoxButton == MessageBoxButton.OK)
                {
                    MessageBoxResult = MessageBoxResult.OK;
                }
                else
                {
                    MessageBoxResult = MessageBoxResult.Cancel;
                }
            }
            base.OnClosing(e);
        }
        #endregion

        #region Properties

        #region MessageBoxResult
        public MessageBoxResult MessageBoxResult
        {
            get { return (MessageBoxResult)GetValue(MessageBoxResultProperty); }
            set { SetValue(MessageBoxResultProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxResultProperty =
            DependencyProperty.Register("MessageBoxResult", typeof(MessageBoxResult), typeof(MessageBoxXWindow));
        #endregion


        #endregion

        #region Function

        #endregion

        #region Event Handlers

        private void Control_OnTemplatedChanged(object sender, EventArgs e)
        {
            _control.Message = _message;
            _control.ButtonArrangement = _buttonArrangement;
            _control.Icon = _icon;

            if (_control._yesButton != null)
            {
                _control._yesButton.Content = _yesButtonContent;
                _control._yesButton.Visibility = _messageBoxButton.IsIncludedIn(MessageBoxButton.YesNo, MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
                _control._yesButton.IsDefault = _defaultButton == DefaultButton.YesOK;
                _control._yesButton.Click -= YesButton_Click;
                _control._yesButton.Click += YesButton_Click;
            }

            if (_control._noButton != null)
            {
                _control._noButton.Content = _noButtonContent;
                _control._noButton.Visibility = _messageBoxButton.IsIncludedIn(MessageBoxButton.YesNo, MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
                _control._noButton.IsDefault = _messageBoxButton == MessageBoxButton.YesNoCancel ? _defaultButton == DefaultButton.NoCancel : _defaultButton == DefaultButton.CancelNo;
                _control._noButton.Click -= NoButton_Click;
                _control._noButton.Click += NoButton_Click;
            }

            if (_control._cancelButton != null)
            {
                _control._cancelButton.Content = _cancelButtonContent;
                _control._cancelButton.Visibility = _messageBoxButton.IsIncludedIn(MessageBoxButton.OKCancel, MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
                _control._cancelButton.IsDefault = _messageBoxButton == MessageBoxButton.YesNoCancel ? _defaultButton == DefaultButton.CancelNo : _defaultButton == DefaultButton.NoCancel;
                _control._cancelButton.IsCancel = _isEscEnabled ? _messageBoxButton.IsIncludedIn(MessageBoxButton.OKCancel, MessageBoxButton.YesNoCancel) : false;
                _control._cancelButton.Click -= CancelButton_Click;
                _control._cancelButton.Click += CancelButton_Click;
            }

            if (_control._okButton != null)
            {
                _control._okButton.Content = _okButtonContent;
                _control._okButton.Visibility = _messageBoxButton.IsIncludedIn(MessageBoxButton.OK, MessageBoxButton.OKCancel) ? Visibility.Visible : Visibility.Collapsed;
                _control._okButton.IsDefault = _defaultButton == DefaultButton.YesOK;
                _control._okButton.IsCancel = _isEscEnabled ? _messageBoxButton == MessageBoxButton.OK : false;
                _control._okButton.Click -= OKButton_Click;
                _control._okButton.Click += OKButton_Click;
            }
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Yes;
            _isResultSet = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.No;
            _isResultSet = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Cancel;
            _isResultSet = true;
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.OK;
            _isResultSet = true;
            Close();
        }
        #endregion
    }
}
